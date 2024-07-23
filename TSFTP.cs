using System;
using System.Diagnostics;
using System.Security.Cryptography.Xml;
using System.Linq;
using WinSCP;
using System.IO;
using System.Reflection;

namespace FTPManagement
{
    class TSFTP
    {
        private Session session;
        private SessionOptions sessionOptions;

        public delegate void ProgressReportHandler(string message, int percentage);
        public event ProgressReportHandler OnProgressReport;

        public TSFTP(string host, string port, string username, string password, string privateKeyPath)
        {
            if (!host.Equals("") && !host.Equals("") && !host.Equals(""))
            {
                sessionOptions = new SessionOptions
                {
                    Protocol = Protocol.Sftp,
                    HostName = host,
                    PortNumber = int.Parse(port),
                    UserName = username,
                    Password = password,
                    GiveUpSecurityAndAcceptAnySshHostKey = true
                };

                if (!string.IsNullOrEmpty(privateKeyPath))
                {
                    sessionOptions.SshPrivateKeyPath = privateKeyPath;
                }
            }
        }

        public Session Connect()
        {
            session = new Session();

            try
            {
                session.Open(sessionOptions);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error connecting to SFTP: {e.Message}");
            }
            return session;
        }

        public void Disconnect()
        {
            if (session != null && session.Opened)
            {
                session.Close();
            }
        }

        public bool IsConnected()
        {
            return session.Opened;
        }

        public void UploadFTP(string localPath, string remotePath)
        {
            try
            {
                EnsureDirectoryExists(remotePath);
                TransferOptions transferOptions = new TransferOptions();
                transferOptions.TransferMode = TransferMode.Binary;
                TransferOperationResult transferResult;
                transferOptions.FilePermissions = null;
                transferOptions.PreserveTimestamp = false;
                transferResult = session.PutFiles(localPath, remotePath, false, transferOptions);
                transferResult.Check();
                int totalFiles = transferResult.Transfers.Count;
                int uploadedFiles = 0;
                OnProgressReport?.Invoke($"Upload from {localPath} to {remotePath}", 0);
                foreach (TransferEventArgs transfer in transferResult.Transfers)
                {
                    uploadedFiles++;
                    int progress = (int)((double)uploadedFiles / totalFiles * 100);
                    OnProgressReport?.Invoke($"Upload of {transfer.FileName} succeeded. Progress: {progress}%", progress);
                }
                OnProgressReport?.Invoke("Upload completed successfully!", 100);
            }
            catch (Exception e)
            {
                OnProgressReport?.Invoke($"Upload failed: {e.Message}", 0);
                throw;
            }
        }

        public void RemoveFTP(string remotePath)
        {
            if (!DirectoryExists(remotePath))
            {
                OnProgressReport?.Invoke("Directory does not exist: " + remotePath, 0);
                return;
            }

            OnProgressReport?.Invoke("Directory deleted: " + remotePath + " 50%", 50);
            try
            {
                session.RemoveFiles(remotePath);
                OnProgressReport?.Invoke("Directory deleted: " + remotePath + " 100%", 100);
            }
            catch (Exception ex)
            {
                OnProgressReport?.Invoke($"Error deleting directory: {ex.Message}", 0);
            }
        }

        private bool DirectoryExists(string remotePath)
        {
            try
            {
                RemoteDirectoryInfo directoryInfo = session.ListDirectory(remotePath);
                return directoryInfo != null;
            }
            catch
            {
                return false;
            }
        }

        private void EnsureDirectoryExists(string remotePath)
        {
            string[] directories = remotePath.Split('/');
            string currentPath = "";

            foreach (string directory in directories)
            {
                if (string.IsNullOrEmpty(directory)) continue;

                currentPath += "/" + directory;
                if (!session.FileExists(currentPath))
                {
                    session.CreateDirectory(currentPath);
                }
            }
        }
    }
}
