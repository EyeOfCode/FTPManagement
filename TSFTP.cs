using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinSCP;

namespace FTPManagement
{
    class TSFTP
    {
        private SessionOptions sessionOptions;
        private Session session;

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
                    SshPrivateKeyPath = privateKeyPath, // Path to your .ppk file
                    GiveUpSecurityAndAcceptAnySshHostKey = true
                };
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
        public List<string> CheckNewFile(string remotePath, string fileNamePattern)
        {
            List<string> fileList = new List<string>();
            RemoteDirectoryInfo directory = session.ListDirectory(remotePath);

            foreach (RemoteFileInfo fileInfo in directory.Files)
            {
                if (fileInfo.IsDirectory)
                    continue;

                if (fileInfo.Name.StartsWith(fileNamePattern))
                {
                    fileList.Add(fileInfo.Name);
                }
            }

            return fileList;
        }

        public bool DownloadFile(string remoteFilePath, string localDirectory)
        {
            try
            {
                TransferOptions transferOptions = new TransferOptions();
                transferOptions.TransferMode = TransferMode.Binary;

                TransferOperationResult transferResult =
                    session.GetFiles(remoteFilePath, Path.GetFullPath(localDirectory), false, transferOptions);

                transferResult.Check();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error downloading file: {e.Message}");
                return false;
            }
        }

        public bool UploadFile(string localFilePath, string remoteDirectory)
        {
            try
            {
                TransferOptions transferOptions = new TransferOptions();
                transferOptions.TransferMode = TransferMode.Binary;
                transferOptions.FilePermissions = null; // Setting file permissions to null to ignore them
                transferOptions.PreserveTimestamp = false; // Disable preserving timestamp
                TransferOperationResult transferResult =
                    session.PutFiles(Path.GetFullPath(localFilePath), remoteDirectory, false, transferOptions);

                transferResult.Check();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error uploading file: {e.Message}");
                return false;
            }
        }

        public bool MoveFile(string sourceFilePath, string destinationFilePath)
        {

            try
            {
                // Check if the destination file exists
                if (session.FileExists(destinationFilePath))
                {
                    // Remove the existing file first
                    session.RemoveFiles(destinationFilePath);

                    // Move the new file to the destination path
                    session.MoveFile(sourceFilePath, destinationFilePath);

                    Console.WriteLine($"File '{destinationFilePath}' replaced successfully.");
                }
                else
                {
                    // If the file does not exist, simply move the new file to the destination
                    session.MoveFile(sourceFilePath, destinationFilePath);

                    Console.WriteLine($"File '{destinationFilePath}' moved successfully.");
                }

                return true;
            }
            catch (SessionRemoteException ex)
            {
                Console.WriteLine($"Error replacing file: {ex.Message}");
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error replacing file: {e.Message}");
                return false;
            }
        }
    }
}
