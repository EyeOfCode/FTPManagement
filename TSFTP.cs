using Renci.SshNet;
using System;
using WinSCP;

namespace FTPManagement
{
    class TSFTP
    {
        private WinSCP.Session session;
        private SessionOptions sessionOptions;

        public delegate void ProgressReportHandler(string message, int percentage, bool status = true);
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

        public WinSCP.Session Connect()
        {
            session = new WinSCP.Session();

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
        
        public void upload(string localPath, string remotePath)
        {
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
                OnProgressReport?.Invoke($"Upload of {transfer.FileName} succeeded. {progress}%", progress);
            }
        }

        public void UploadFTP(string localPath, string remotePath, string[] ignore = null)
        {
            try
            {
                EnsureDirectoryExists(remotePath);
                if (ignore != null && ignore.Length > 0)
                {
                    var util = new Util();
                    var DirToUpload = Directory.GetDirectories(localPath, "*", SearchOption.AllDirectories).Where(dir => !ignore.Any(pattern => util.IsMatchFileName(Path.GetFileName(dir), pattern) || dir == pattern || dir.EndsWith(pattern, StringComparison.OrdinalIgnoreCase))).ToArray();
                    foreach (var dirPath in DirToUpload)
                    {
                        string relativePath = Path.GetRelativePath(localPath, dirPath);
                        string remoteDirPath = Path.Combine(remotePath, relativePath).Replace("\\", "/");
                        if (!util.IsUnderIgnoredDirectory(relativePath, ignore))
                        {
                            EnsureDirectoryExists(remoteDirPath);
                            if (!DirectoryExists(remoteDirPath))
                            {
                                OnProgressReport?.Invoke($"Upload failed: {remoteDirPath}", 0, false);
                                return;
                            }
                        }
                    }
                    var filesToUpload = Directory.GetFiles(localPath, "*", SearchOption.AllDirectories).Where(file => !ignore.Any(pattern => util.IsMatchFileName(Path.GetFileName(file), pattern) || file == pattern || file.EndsWith(pattern, StringComparison.OrdinalIgnoreCase))).ToArray();
                    foreach (var filePath in filesToUpload)
                    {
                        string relativePath = Path.GetRelativePath(localPath, filePath);
                        if (relativePath != "desktop.ini" && !util.IsUnderIgnoredDirectory(relativePath, ignore))
                        {
                            OnProgressReport?.Invoke($"Start upload: {filePath}", 0);
                            string remoteFilePath = Path.Combine(remotePath, relativePath).Replace("\\", "/");
                            upload(filePath, remoteFilePath);
                        }
                    }
                }
                else
                {
                    upload(localPath, remotePath);
                }
            }
            catch (Exception e)
            {
                OnProgressReport?.Invoke($"Upload failed: {e.Message}", 0, false);
                throw;
            }
        }

        public void RemoveFTP(string remotePath)
        {
            if (!DirectoryExists(remotePath))
            {
                OnProgressReport?.Invoke("Directory does not exist: " + remotePath, 0, false);
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
                OnProgressReport?.Invoke($"Error deleting directory: {ex.Message}", 0, false);
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

        public void CmdFTP(string scriptPath)
        {
            try
            {
                RemoteFileInfo fileInfo = session.GetFileInfo(scriptPath);
                if (fileInfo == null)
                {
                    string errorText = $"File not found";
                    throw new NotSupportedException(errorText);
                }
                OnProgressReport?.Invoke("Execute cmd: " + scriptPath, 0);
                int dotIndex = scriptPath.LastIndexOf('.');
                if (dotIndex < 0)
                {
                    OnProgressReport?.Invoke($"Error run cmd: File not found", 0, false);
                    return;
                }
                string name = scriptPath.Substring(0, dotIndex);
                string extension = scriptPath.Substring(dotIndex);
                OnProgressReport?.Invoke("Start connect cmd", 30);
                using (var sshClient = new SshClient(sessionOptions.HostName, sessionOptions.UserName, sessionOptions.Password))
                {
                    OnProgressReport?.Invoke("Start check type file", 40);
                    sshClient.Connect();
                    OnProgressReport?.Invoke("Connect cmd", 50);
                    string command;
                    switch (extension)
                    {
                        case ".sh":
                        case ".bash":
                            OnProgressReport?.Invoke($"Run chmod +x", 55);
                            sshClient.RunCommand($"chmod +x {scriptPath}");
                            command = $"{scriptPath}";
                            break;
                        case ".ts":
                        case ".js":
                            command = $"node {scriptPath}";
                            break;
                        default:
                            string errorText = $"Script file extension '{extension}' not supported.";
                            throw new NotSupportedException(errorText);
                    }
                    OnProgressReport?.Invoke($"Run cmd {extension}", 60);
                    var sshCommand = sshClient.RunCommand(command);
                    var commandResult = sshCommand.Execute();
                    OnProgressReport?.Invoke($"Result:", 60);
                    using (var reader = new System.IO.StringReader(commandResult))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            OnProgressReport?.Invoke($"{line}", 60);
                        }
                    }
                    OnProgressReport?.Invoke($"End cmd {extension}", 90);
                    sshClient.Disconnect();
                    OnProgressReport?.Invoke("Disconnect cmd: " + scriptPath, 100);
                }
            }
            catch (Exception ex)
            {
                OnProgressReport?.Invoke($"Error run cmd: {ex.Message}", 0, false);
            }
            session.Close();
        }
    }
}
