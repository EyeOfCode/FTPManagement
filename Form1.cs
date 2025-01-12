using static System.Net.WebRequestMethods;
using WinSCP;
using static System.Collections.Specialized.BitVector32;
using System.Diagnostics;
using Renci.SshNet.Security;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Reflection.Metadata.BlobBuilder;
using System;
using Renci.SshNet;
using System.Security.Policy;
using System.Net.NetworkInformation;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.VisualBasic.Logging;

namespace FTPManagement
{
    public partial class FTPManagement : Form
    {
        IniFile config = new IniFile("configuration.ini");
        Dictionary<string, Dictionary<string, string>> configData = new Dictionary<string, Dictionary<string, string>>();

        public FTPManagement()
        {
            InitializeComponent();
            InitialSystem();
        }

        private void InitialSystem()
        {
            LoadConfig();
            main.BringToFront();
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            txtbHostName.Text = "";
            txtbPort.Text = "22";
            txtbUsername.Text = "";
            txtbPassword.Text = "";
            ckIsPrivateKey.Checked = false;
            txtbPPKFile.Text = "";
            txtbTargetDir.Text = "";
            txtbLocalDir.Text = "";
            txtbConfigName.Text = "";
            txtbIgnore.Text = "";
            txtbScriptDir.Text = "";
            enableFTPFORM();
            ftpConfig.BringToFront();
        }

        private void btnOpenFileFTP_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Filter = "PPK files (*.ppk)|*.ppk",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                txtbPPKFile.Text = filePath;
            }
        }

        private void btnOpenDirLocal_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select a folder";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;

                if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string folderPath = folderBrowserDialog.SelectedPath;
                    txtbLocalDir.Text = folderPath;
                }
            }
        }

        private void btnCancelFTPConfig_Click(object sender, EventArgs e)
        {
            main.BringToFront();
        }

        private void btnTestConnectFTP_Click(object sender, EventArgs e)
        {
            tsStatusOther.Text = "Test config FTP...";
            Invoke(new Action(() => tsProgressBar.Value = 50));
            string privateKeyPath = ckIsPrivateKey.Checked ? txtbPPKFile.Text : "";
            try
            {
                Console.WriteLine(txtbHostName.Text);
                TSFTP sftp = new TSFTP(txtbHostName.Text, txtbPort.Text, txtbUsername.Text, txtbPassword.Text, privateKeyPath);
                WinSCP.Session session = sftp.Connect();
                Invoke(new Action(() => tsProgressBar.Value = 100));
                if (sftp.IsConnected())
                {
                    sftp.Disconnect();
                    MessageBox.Show("Connection success!!", "SFTP Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    sftp.Disconnect();
                    tsStatusOther.Text = "Connection fail!!";
                    tsStatusOther.ForeColor = Color.Red;
                    MessageBox.Show("Connection fail!!", "SFTP Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Invoke(new Action(() => tsProgressBar.Value = 0));
                tsStatusOther.ForeColor = Color.Black;
                tsStatusOther.Text = "";
            }
            catch (Exception ex)
            {
                tsStatusOther.Text = "Connection fail!!";
                tsStatusOther.ForeColor = Color.Red;
                DialogResult error = MessageBox.Show("Connection fail!!", "SFTP Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (error == DialogResult.OK)
                {
                    Invoke(new Action(() => tsProgressBar.Value = 0));
                    tsStatusOther.ForeColor = Color.Black;
                    tsStatusOther.Text = "";
                }
            }
        }

        private void btnSaveFTPConfig_Click(object sender, EventArgs e)
        {
            tsStatusOther.Text = "Update config FTP...";
            string section = "SFTP";
            Invoke(new Action(() => tsProgressBar.Value = 30));
            if (txtbConfigName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Invalid Name!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Invoke(new Action(() => tsProgressBar.Value = 0));
                tsStatusOther.Text = "";
                return;
            }
            if (txtbHostName.Text.Equals(string.Empty))
            {
                MessageBox.Show("Invalid Host!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Invoke(new Action(() => tsProgressBar.Value = 0));
                tsStatusOther.Text = "";
                return;
            }
            if (txtbUsername.Text.Equals(string.Empty))
            {
                MessageBox.Show("Invalid Username!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Invoke(new Action(() => tsProgressBar.Value = 0));
                tsStatusOther.Text = "";
                return;
            }
            if (txtbLocalDir.Text.Equals(string.Empty))
            {
                MessageBox.Show("Invalid local directory!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Invoke(new Action(() => tsProgressBar.Value = 0));
                tsStatusOther.Text = "";
                return;
            }
            if (txtbTargetDir.Text.Equals(string.Empty))
            {
                MessageBox.Show("Invalid target directory!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Invoke(new Action(() => tsProgressBar.Value = 0));
                tsStatusOther.Text = "";
                return;
            }
            Invoke(new Action(() => tsProgressBar.Value = 50));
            string prot = string.IsNullOrEmpty(txtbPort.Text) ? "22" : txtbPort.Text;
            string configName = $"SFTP_{txtbConfigName.Text.ToUpper()}";
            config.Write("host", txtbHostName.Text, configName);
            config.Write("port", prot, configName);
            config.Write("username", txtbUsername.Text, configName);
            config.Write("password", txtbPassword.Text, configName);
            config.Write("localDirectory", txtbLocalDir.Text, configName);
            config.Write("targetDirectory", txtbTargetDir.Text, configName);
            config.Write("usePrivateKey", ckIsPrivateKey.Checked.ToString(), configName);
            config.Write("privateKeyPath", txtbPPKFile.Text, configName);
            config.Write("configName", txtbConfigName.Text, configName);
            config.Write("scriptPath", txtbScriptDir.Text, configName);
            config.Write("ignore", txtbIgnore.Text, configName);
            Invoke(new Action(() => tsProgressBar.Value = 80));
            LoadConfig(section, txtbConfigName.Text);
            LoadConfig();
            Invoke(new Action(() => tsProgressBar.Value = 100));
            MessageBox.Show("Success to Update!!", "Success", MessageBoxButtons.OK);
            main.BringToFront();
            Invoke(new Action(() => tsProgressBar.Value = 0));
            tsStatusOther.Text = "";
        }

        private void LoadSFTPConfig(string session)
        {
            configData[session] = new Dictionary<string, string>();
            configData[session]["host"] = config.Read("host", session);
            configData[session]["port"] = config.Read("port", session);
            configData[session]["username"] = config.Read("username", session);
            configData[session]["password"] = config.Read("password", session);
            configData[session]["usePrivateKey"] = config.Read("usePrivateKey", session);
            configData[session]["privateKeyPath"] = config.Read("privateKeyPath", session);
            configData[session]["targetDirectory"] = config.Read("targetDirectory", session);
            configData[session]["localDirectory"] = config.Read("localDirectory", session);
            configData[session]["configName"] = config.Read("configName", session);
            configData[session]["scriptPath"] = config.Read("scriptPath", session);
            configData[session]["ignore"] = config.Read("ignore", session);

            if (!configData[session]["usePrivateKey"].ToLower().Equals("true"))
            {
                configData[session]["privateKeyPath"] = "";
            }
        }

        private void LoadConfig(string _section = "", string option = null)
        {
            string section;

            section = "SFTP";
            if (_section.ToLower().Equals(section.ToLower()) || _section.Equals(string.Empty))
            {
                if (option != null)
                {
                    string configName = $"{section}_{option}";
                    LoadSFTPConfig(configName);
                    txtbHostName.Text = configData[configName]["host"];
                    txtbPort.Text = configData[configName]["port"];
                    txtbUsername.Text = configData[configName]["username"];
                    txtbPassword.Text = configData[configName]["password"];
                    ckIsPrivateKey.Checked = configData[configName]["usePrivateKey"] == "True" ? true : false;
                    txtbPPKFile.Text = configData[configName]["privateKeyPath"];
                    txtbTargetDir.Text = configData[configName]["targetDirectory"];
                    txtbLocalDir.Text = configData[configName]["localDirectory"];
                    txtbConfigName.Text = configData[configName]["configName"];
                    txtbScriptDir.Text = configData[configName]["scriptPath"];
                    txtbIgnore.Text = configData[configName]["ignore"];
                }
                else
                {
                    List<string> sections = config.GetAllSections();
                    var sftpKeys = sections.Where(key => key.StartsWith("SFTP_"));
                    foreach (var key in sftpKeys)
                    {
                        LoadSFTPConfig(key);
                    }
                }
            }

            section = "LIST_SFTP";
            if (_section.ToLower().Equals(section.ToLower()) || _section.Equals(string.Empty))
            {
                Dictionary<string, Dictionary<string, string>> projectData = new Dictionary<string, Dictionary<string, string>>();
                List<string> sections = config.GetAllSections();
                var sftpKeys = sections.Where(key => key.StartsWith("SFTP_"));
                lsbProjectList.Items.Clear();
                foreach (var key in sftpKeys)
                {
                    if (configData.ContainsKey(key))
                    {
                        string name = configData[key]["configName"];
                        string host = configData[key]["host"];
                        string username = configData[key]["username"];
                        string port = configData[key]["port"];
                        string localDir = configData[key]["localDirectory"];
                        string tagetDir = configData[key]["targetDirectory"];
                        string scripDir = configData[key]["scriptPath"];
                        string ignoreFile = configData[key]["ignore"];

                        projectData[name] = new Dictionary<string, string>
                        {
                            { "host", host },
                            { "port", port },
                            { "username", username },
                            { "localDir", localDir },
                            { "targetDir", tagetDir },
                            { "ignore", ignoreFile },
                            { "scriptDir", scripDir },
                        };

                        lsbProjectList.Items.Add(name);
                    }
                }
                if (lsbProjectList.Items.Count > 0)
                {
                    lsbProjectList.SelectedIndex = 0;
                    string selectedName = lsbProjectList.Text;

                    if (projectData.ContainsKey(selectedName))
                    {
                        var data = projectData[selectedName];
                        int maxLength = 15;

                        lblHostCurrentName.Text = $"Host Name: {selectedName}";
                        lblHostCurrent.Text = $"Host: {data.GetValueOrDefault("host", "-")}:{data.GetValueOrDefault("port", "-")}";
                        lblUserNameCurrent.Text = $"Username: {data.GetValueOrDefault("username", "-")}";
                        lblLocalDirCurrent.Text = $"Local Dir: {TruncateText(data.GetValueOrDefault("localDir", "-"), maxLength)}";
                        lblTragetDirCurrent.Text = $"Target Dir: {TruncateText(data.GetValueOrDefault("targetDir", "-"), maxLength)}";
                        lblScriptDitCurrent.Text = $"Script Dir: {TruncateText(data.GetValueOrDefault("scriptDir", "-"), maxLength)}";
                        lblIgnoreFileCureent.Text = $"Ignore File: {TruncateText(data.GetValueOrDefault("ignore", "-"), maxLength)}";
                    }
                }
            }

            section = "WEB_CONFIG";
            if (_section.ToLower().Equals(section.ToLower()) || _section.Equals(string.Empty))
            {
                if (option != null)
                {
                    string configName = $"{section}_{option}";
                    configData[configName] = new Dictionary<string, string>();
                    configData[configName]["domain"] = config.Read("domain", configName);

                    txtbDomain.Text = configData[configName]["domain"];
                }
                else
                {
                    List<string> sections = config.GetAllSections();
                    var sftpKeys = sections.Where(key => key.StartsWith("WEB_CONFIG_"));
                    foreach (var key in sftpKeys)
                    {
                        configData[key] = new Dictionary<string, string>();
                        configData[key]["domain"] = config.Read("domain", key);
                    }
                }
            }
        }

        private string TruncateText(string text, int maxLength)
        {
            if (string.IsNullOrEmpty(text)) return "-";
            return text.Length > maxLength ? text.Substring(0, maxLength) + "..." : text;
        }

        private void btnEditProject_Click(object sender, EventArgs e)
        {
            if (lsbProjectList.SelectedItem != null)
            {
                enableFTPFORM();
                string selectedItem = lsbProjectList.SelectedItem.ToString();
                if (selectedItem != null)
                {
                    LoadConfig("SFTP", selectedItem);
                    ftpConfig.BringToFront();
                }
            }
        }

        private void btnDeleteFTP_Click(object sender, EventArgs e)
        {
            tsStatusOther.Text = "Deleted FTP...";
            DialogResult result = MessageBox.Show("Success to Deleted!!", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Invoke(new Action(() => tsProgressBar.Value = 50));
                string selectedItem = lsbProjectList.SelectedItem.ToString();
                string configName = $"SFTP_{selectedItem.ToUpper()}";
                config.DeleteKey("host", configName);
                config.DeleteKey("port", configName);
                config.DeleteKey("username", configName);
                config.DeleteKey("password", configName);
                config.DeleteKey("localDirectory", configName);
                config.DeleteKey("targetDirectory", configName);
                config.DeleteKey("usePrivateKey", configName);
                config.DeleteKey("privateKeyPath", configName);
                config.DeleteKey("configName", configName);
                config.DeleteKey("scriptPath", configName);
                config.DeleteKey("txtbIgnore", configName);
                config.DeleteSection(configName);
                lsbProjectList.Items.Remove(selectedItem);
                Invoke(new Action(() => tsProgressBar.Value = 100));
            }
            Invoke(new Action(() => tsProgressBar.Value = 0));
            tsStatusOther.Text = "";
        }

        private void enableFTPFORM()
        {
            txtbHostName.ReadOnly = false;
            txtbPort.ReadOnly = false;
            txtbUsername.ReadOnly = false;
            txtbPassword.ReadOnly = false;
            ckIsPrivateKey.Enabled = true;
            txtbPPKFile.ReadOnly = false;
            txtbTargetDir.ReadOnly = false;
            txtbLocalDir.ReadOnly = false;
            txtbConfigName.ReadOnly = false;
            btnSaveFTPConfig.Visible = true;
            btnOpenFileFTP.Visible = true;
            btnOpenDirLocal.Visible = true;
            btnUploadFTP.Visible = false;
            btnCmd.Visible = false;
            btnDropFTP.Visible = false;
            txtbScriptDir.ReadOnly = false;
            txtbIgnore.ReadOnly = false;
        }

        private void disableFTPFORM()
        {
            txtbHostName.ReadOnly = true;
            txtbPort.ReadOnly = true;
            txtbUsername.ReadOnly = true;
            txtbPassword.ReadOnly = true;
            ckIsPrivateKey.Enabled = false;
            txtbPPKFile.ReadOnly = true;
            txtbTargetDir.ReadOnly = true;
            txtbLocalDir.ReadOnly = true;
            txtbConfigName.ReadOnly = true;
            btnSaveFTPConfig.Visible = false;
            btnOpenFileFTP.Visible = false;
            btnOpenDirLocal.Visible = false;
            btnUploadFTP.Visible = true;
            btnCmd.Visible = true;
            btnDropFTP.Visible = true;
            txtbScriptDir.ReadOnly = true;
            txtbIgnore.ReadOnly = true;
        }

        private void btnDetailFTP_Click(object sender, EventArgs e)
        {
            if (lsbProjectList.SelectedItem != null)
            {
                string selectedItem = lsbProjectList.SelectedItem.ToString();
                if (selectedItem != null)
                {
                    LoadConfig("SFTP", selectedItem);
                    ftpConfig.BringToFront();
                    disableFTPFORM();
                }
            }
        }

        private void uploadFTP()
        {
            try
            {
                string selectedItem = lsbProjectList.SelectedItem.ToString();
                if (selectedItem.Equals(string.Empty))
                {
                    return;
                }
                logs.BringToFront();
                Invoke(new Action(() => tsProgressBar.Value = 0));
                tsStatusOther.Text = "Starting connect...";
                string configName = $"SFTP_{selectedItem.ToUpper()}";
                LoadConfig("SFTP", selectedItem);
                TSFTP sftp = new TSFTP(configData[configName]["host"], configData[configName]["port"], configData[configName]["username"], configData[configName]["password"], configData[configName]["privateKeyPath"]);
                WinSCP.Session session = sftp.Connect();
                Invoke(new Action(() => tsProgressBar.Value = 100));
                tsStatusOther.Text = "Starting upload...";
                sftp.OnProgressReport += UpdateProgress;
                string[] ignore = null;
                if (!configData[configName]["ignore"].Equals(string.Empty))
                {
                    ignore = configData[configName]["ignore"].Split(',').Select(s => s.Trim()).ToArray();
                }
                sftp.UploadFTP(configData[configName]["localDirectory"], configData[configName]["targetDirectory"], ignore);
                if (tsProgressBar.Value >= 100)
                {
                    MessageBox.Show("Upload success!!", "Upload FTP", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Upload fail!!", "Upload FTP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Upload fail!!", "Upload FTP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Invoke(new Action(() => tsProgressBar.Value = 0));
            tsStatusOther.ForeColor = Color.Black;
            tsStatusOther.Text = "";
            rtbLogs.Clear();
        }

        private void btnUploadFTP_Click(object sender, EventArgs e)
        {
            uploadFTP();
            ftpConfig.BringToFront();
        }

        private void UpdateProgress(string message, int percentage, bool status = true)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateProgress(message, percentage, status)));
                return;
            }
            tsStatusOther.ForeColor = status ? Color.Green : Color.Red;
            tsProgressBar.Value = percentage;
            rtbLogs.AppendText(message + Environment.NewLine);
            rtbLogs.ForeColor = status ? Color.Green : Color.Red;
            rtbLogs.ScrollToCaret();
        }

        private void runCmdFTP()
        {
            try
            {
                string selectedItem = lsbProjectList.SelectedItem.ToString();
                if (selectedItem.Equals(string.Empty))
                {
                    return;
                }
                logs.BringToFront();
                Invoke(new Action(() => tsProgressBar.Value = 0));
                tsStatusOther.Text = "Starting connect...";
                string configName = $"SFTP_{selectedItem.ToUpper()}";
                LoadConfig("SFTP", selectedItem);
                TSFTP sftp = new TSFTP(configData[configName]["host"], configData[configName]["port"], configData[configName]["username"], configData[configName]["password"], configData[configName]["privateKeyPath"]);
                WinSCP.Session session = sftp.Connect();
                Invoke(new Action(() => tsProgressBar.Value = 100));
                tsStatusOther.Text = "Starting cmd script...";
                sftp.OnProgressReport += UpdateProgress;
                sftp.CmdFTP(configData[configName]["scriptPath"]);
                MessageBox.Show("Run Cmd success!!", "CMD FTP", MessageBoxButtons.OK);
            }
            catch
            {
                MessageBox.Show("Run Cmd fail!!", "CMD FTP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tsStatusOther.ForeColor = Color.Black;
            tsStatusOther.Text = "";
            rtbLogs.Clear();
            Invoke(new Action(() => tsProgressBar.Value = 0));
        }

        private void btnCmd_Click(object sender, EventArgs e)
        {
            runCmdFTP();
            ftpConfig.BringToFront();
        }

        private void dropFTP()
        {
            try
            {
                string selectedItem = lsbProjectList.SelectedItem.ToString();
                if (selectedItem.Equals(string.Empty))
                {
                    return;
                }
                logs.BringToFront();
                Invoke(new Action(() => tsProgressBar.Value = 0));
                tsStatusOther.Text = "Starting connect...";
                string configName = $"SFTP_{selectedItem.ToUpper()}";
                LoadConfig("SFTP", selectedItem);
                TSFTP sftp = new TSFTP(configData[configName]["host"], configData[configName]["port"], configData[configName]["username"], configData[configName]["password"], configData[configName]["privateKeyPath"]);
                WinSCP.Session session = sftp.Connect();
                Invoke(new Action(() => tsProgressBar.Value = 100));
                tsStatusOther.Text = "Starting delete folder...";
                sftp.OnProgressReport += UpdateProgress;
                sftp.RemoveFTP(configData[configName]["targetDirectory"]);
                MessageBox.Show("Upload success!!", "Upload FTP", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Upload fail!!", "Upload FTP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            tsStatusOther.ForeColor = Color.Black;
            tsStatusOther.Text = "";
            rtbLogs.Clear();
            Invoke(new Action(() => tsProgressBar.Value = 0));
        }

        private void btnDropFTP_Click(object sender, EventArgs e)
        {
            dropFTP();
            ftpConfig.BringToFront();
        }

        private void btnQtUpload_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Upload!!", "Upload", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                uploadFTP();
                main.BringToFront();
            }
        }

        private void btnQtDrop_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Drop!!", "Drop", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                dropFTP();
                main.BringToFront();
            }
        }

        private void btnQtCmd_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Run Cmd!!", "CMD", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                runCmdFTP();
                main.BringToFront();
            }
        }

        private void btnWebConfig_Click(object sender, EventArgs e)
        {
            string section = "WEB_CONFIG";
            string selectedItem = lsbProjectList.SelectedItem.ToString();
            if (selectedItem.Equals(string.Empty))
            {
                return;
            }
            LoadConfig("WEB_CONFIG", selectedItem);
            webConfig.BringToFront();
        }

        private void brnSaveWebConfig_Click(object sender, EventArgs e)
        {
            tsStatusOther.Text = "Start save web config ...";
            string selectedItem = lsbProjectList.SelectedItem.ToString();
            if (selectedItem.Equals(string.Empty))
            {
                return;
            }
            string section = "WEB_CONFIG";
            Invoke(new Action(() => tsProgressBar.Value = 0));
            string configName = $"WEB_CONFIG_{selectedItem.ToUpper()}";
            config.Write("domain", txtbDomain.Text, configName);
            config.Write("configName", selectedItem, configName);
            Invoke(new Action(() => tsProgressBar.Value = 80));
            LoadConfig(section, selectedItem);
            tsStatusOther.ForeColor = Color.Green;
            Invoke(new Action(() => tsProgressBar.Value = 100));
            MessageBox.Show("Success to Update!!", "Success", MessageBoxButtons.OK);
            Invoke(new Action(() => tsProgressBar.Value = 0));
            tsStatusOther.ForeColor = Color.Black;
            tsStatusOther.Text = "";
        }

        private void btnWebCancel_Click(object sender, EventArgs e)
        {
            main.BringToFront();
        }

        private void btnOpenWeb_Click(object sender, EventArgs e)
        {
            string selectedItem = lsbProjectList.SelectedItem.ToString();
            if (selectedItem.Equals(string.Empty))
            {
                return;
            }
            string configName = $"WEB_CONFIG_{selectedItem.ToUpper()}";
            Process.Start(new ProcessStartInfo
            {
                FileName = configData[configName]["domain"],
                UseShellExecute = true
            });
        }

        private void btnPingWeb_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedItem = lsbProjectList.SelectedItem.ToString();
                if (selectedItem.Equals(string.Empty))
                {
                    return;
                }
                logs.BringToFront();
                rtbLogs.Clear();
                tsStatusOther.Text = "Start ping ...";
                UpdateProgress("Start ping...", 0);
                string configName = $"WEB_CONFIG_{selectedItem.ToUpper()}";
                Ping pingSender = new Ping();
                string server = configData[configName]["domain"];
                PingReply reply = pingSender.Send(server);
                UpdateProgress($"Check config ping to {server}", 50);

                // Check the status of the ping reply
                if (reply.Status == IPStatus.Success)
                {
                    UpdateProgress($"Ping to {server} successful", 100);
                    UpdateProgress($"Roundtrip time: {reply.RoundtripTime} ms", 100);
                    UpdateProgress($"Time to live: {reply.Options.Ttl}", 100);
                    UpdateProgress($"Don't fragment: {reply.Options.DontFragment}", 100);
                    UpdateProgress($"Buffer size: {reply.Buffer.Length}", 100);
                    UpdateProgress($"Ping success...", 100);
                    tsStatusOther.Text = "Ping success...";
                    MessageBox.Show("Ping success!!", "Ping", MessageBoxButtons.OK);
                }
                else
                {
                    tsStatusOther.Text = "Ping fail...";
                    UpdateProgress($"Ping to {configData[configName]["domain"]} failed. Status: {reply.Status}", 0, false);
                    MessageBox.Show("Ping fail!!", "Ping", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                tsStatusOther.Text = "Ping fail...";
                UpdateProgress("An error occurred: " + ex.Message, 0, false);
                MessageBox.Show("Ping fail!!", "Ping", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Invoke(new Action(() => tsProgressBar.Value = 0));
            tsStatusOther.ForeColor = Color.Black;
            tsStatusOther.Text = "";
            rtbLogs.Clear();
            webConfig.BringToFront();
        }

        private void btnWebCancel_Click_1(object sender, EventArgs e)
        {
            main.BringToFront();
        }

        private void btnOpenCmd_Click(object sender, EventArgs e)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                UseShellExecute = true
            };

            Process process = new Process
            {
                StartInfo = processStartInfo
            };
            process.Start();
        }

        private void lsbProjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbProjectList.SelectedItem == null) return;
            string selectedItem = lsbProjectList.SelectedItem.ToString();
            LoadConfig("SFTP", selectedItem);
            string configName = $"SFTP_{selectedItem}";
            if (configData.ContainsKey(configName))
            {
                var configSection = configData[configName];
                var data = new Dictionary<string, string>
                {
                    ["host"] = configSection["host"],
                    ["port"] = configSection["port"],
                    ["username"] = configSection["username"],
                    ["localDir"] = configSection["localDirectory"],
                    ["targetDir"] = configSection["targetDirectory"],
                    ["scriptDir"] = configSection["scriptPath"],
                    ["ignore"] = configSection["ignore"]
                };

                const int MAX_DISPLAY_LENGTH = 15;
                lblHostCurrentName.Text = $"Host Name: {selectedItem}";
                lblHostCurrent.Text = $"Host: {data.GetValueOrDefault("host", "-")}:{data.GetValueOrDefault("port", "-")}";
                lblUserNameCurrent.Text = $"Username: {data.GetValueOrDefault("username", "-")}";
                lblLocalDirCurrent.Text = $"Local Dir: {TruncateText(data.GetValueOrDefault("localDir", "-"), MAX_DISPLAY_LENGTH)}";
                lblTragetDirCurrent.Text = $"Target Dir: {TruncateText(data.GetValueOrDefault("targetDir", "-"), MAX_DISPLAY_LENGTH)}";
                lblScriptDitCurrent.Text = $"Script Dir: {TruncateText(data.GetValueOrDefault("scriptDir", "-"), MAX_DISPLAY_LENGTH)}";
                lblIgnoreFileCureent.Text = $"Ignore File: {TruncateText(data.GetValueOrDefault("ignore", "-"), MAX_DISPLAY_LENGTH)}";
            }
        }
    }
}
