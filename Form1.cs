using static System.Net.WebRequestMethods;
using WinSCP;
using static System.Collections.Specialized.BitVector32;
using System.Diagnostics;
using Renci.SshNet.Security;
using System.Windows.Forms;
using System.Xml.Linq;

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
            txtbPort.Text = "";
            txtbUsername.Text = "";
            txtbPassword.Text = "";
            ckIsPrivateKey.Checked = false;
            txtbPPKFile.Text = "";
            txtbTargetDir.Text = "";
            txtbLocalDir.Text = "";
            txtbConfigName.Text = "";
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

        private bool TestConnectionSFTP()
        {
            TSFTP sftp = new TSFTP(configData["SFTP"]["host"],
                                    configData["SFTP"]["port"],
                                    configData["SFTP"]["username"],
                                    configData["SFTP"]["password"],
                                    configData["SFTP"]["privateKey"]
                                    );
            Session session = sftp.Connect();
            bool result = sftp.IsConnected();
            if (result)
            {
                sftp.Disconnect();
            }
            return result;
        }

        private void btnTestConnectFTP_Click(object sender, EventArgs e)
        {
            tsStatusOther.Text = "Test config FTP...";
            Invoke(new Action(() => tsProgressBar.Value = 50));
            string privateKeyPath = ckIsPrivateKey.Checked ? txtbPPKFile.Text : "";
            try
            {
                TSFTP sftp = new TSFTP(txtbHostName.Text, txtbPort.Text, txtbUsername.Text, txtbPassword.Text, privateKeyPath);
                Session session = sftp.Connect();
                Invoke(new Action(() => tsProgressBar.Value = 100));
                if (sftp.IsConnected())
                {
                    sftp.Disconnect();
                    MessageBox.Show("Connection success!!", "SFTP Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Invoke(new Action(() => tsProgressBar.Value = 0));
                tsStatusOther.Text = "";
            }
            catch (Exception ex)
            {
                tsStatusOther.Text = "Connection fail!!";
                tsStatusOther.ForeColor = Color.Red;
                DialogResult error = MessageBox.Show("Connection fail!!", "SFTP Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if(error == DialogResult.OK)
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
            Invoke(new Action(() => tsProgressBar.Value = 50));
            string configName = $"SFTP_{txtbConfigName.Text.ToUpper()}";
            config.Write("host", txtbHostName.Text, configName);
            config.Write("port", txtbPort.Text, configName);
            config.Write("username", txtbUsername.Text, configName);
            config.Write("password", txtbPassword.Text, configName);
            config.Write("localDirectory", txtbLocalDir.Text, configName);
            config.Write("targetDirectory", txtbTargetDir.Text, configName);
            config.Write("usePrivateKey", ckIsPrivateKey.Checked.ToString(), configName);
            config.Write("privateKeyPath", txtbPPKFile.Text, configName);
            config.Write("configName", txtbConfigName.Text, configName);
            Invoke(new Action(() => tsProgressBar.Value = 80));
            LoadConfig(section, txtbConfigName.Text);
            LoadConfig("LIST_SFTP");
            Invoke(new Action(() => tsProgressBar.Value = 100));
            MessageBox.Show("Success to Update!!", "Success", MessageBoxButtons.OK);
            lsbProjectList.Items.Add(txtbConfigName.Text);
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
                List<string> sections = config.GetAllSections();
                var sftpKeys = sections.Where(key => key.StartsWith("SFTP_"));
                lsbProjectList.Items.Clear();
                foreach (var key in sftpKeys)
                {
                    if (configData.ContainsKey(key))
                    {
                        string name = configData[key]["configName"];
                        lsbProjectList.Items.Add(name);
                    }
                }
                lsbProjectList.SelectedIndex = 0;
            }
        }

        private void btnEditProject_Click(object sender, EventArgs e)
        {
            if (lsbProjectList.SelectedItem != null)
            {
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
    }
}
