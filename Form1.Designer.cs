namespace FTPManagement
{
    partial class FTPManagement
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            main = new Panel();
            lsbProjectList = new ListBox();
            gbDengerZone = new GroupBox();
            gbManageZone = new GroupBox();
            btnDetailFTP = new Button();
            btnDeleteFTP = new Button();
            btnEditProject = new Button();
            btnAddProject = new Button();
            footer = new StatusStrip();
            tsProgressBar = new ToolStripProgressBar();
            lbStatusOther = new ToolStripStatusLabel();
            tsStatusOther = new ToolStripStatusLabel();
            ftpConfig = new Panel();
            gbFTP = new GroupBox();
            txtbConfigName = new TextBox();
            label3 = new Label();
            btnTestConnectFTP = new Button();
            btnOpenDirLocal = new Button();
            txtbLocalDir = new TextBox();
            label7 = new Label();
            txtbTargetDir = new TextBox();
            label6 = new Label();
            btnOpenFileFTP = new Button();
            txtbPPKFile = new TextBox();
            txtbPassword = new TextBox();
            txtbPort = new TextBox();
            txtbUsername = new TextBox();
            txtbHostName = new TextBox();
            ckIsPrivateKey = new CheckBox();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnCancelFTPConfig = new Button();
            btnSaveFTPConfig = new Button();
            btnQtUpload = new Button();
            main.SuspendLayout();
            gbDengerZone.SuspendLayout();
            gbManageZone.SuspendLayout();
            footer.SuspendLayout();
            ftpConfig.SuspendLayout();
            gbFTP.SuspendLayout();
            SuspendLayout();
            // 
            // main
            // 
            main.Controls.Add(lsbProjectList);
            main.Controls.Add(gbDengerZone);
            main.Controls.Add(gbManageZone);
            main.Location = new Point(0, 0);
            main.Name = "main";
            main.Size = new Size(799, 425);
            main.TabIndex = 1;
            // 
            // lsbProjectList
            // 
            lsbProjectList.Location = new Point(12, 32);
            lsbProjectList.Name = "lsbProjectList";
            lsbProjectList.Size = new Size(265, 384);
            lsbProjectList.TabIndex = 0;
            // 
            // gbDengerZone
            // 
            gbDengerZone.Controls.Add(btnQtUpload);
            gbDengerZone.Location = new Point(539, 9);
            gbDengerZone.Name = "gbDengerZone";
            gbDengerZone.Size = new Size(249, 407);
            gbDengerZone.TabIndex = 1;
            gbDengerZone.TabStop = false;
            gbDengerZone.Text = "DangerZone";
            // 
            // gbManageZone
            // 
            gbManageZone.Controls.Add(btnDetailFTP);
            gbManageZone.Controls.Add(btnDeleteFTP);
            gbManageZone.Controls.Add(btnEditProject);
            gbManageZone.Controls.Add(btnAddProject);
            gbManageZone.Location = new Point(283, 9);
            gbManageZone.Name = "gbManageZone";
            gbManageZone.Size = new Size(249, 407);
            gbManageZone.TabIndex = 0;
            gbManageZone.TabStop = false;
            gbManageZone.Text = "ManageFTP";
            // 
            // btnDetailFTP
            // 
            btnDetailFTP.Location = new Point(26, 367);
            btnDetailFTP.Name = "btnDetailFTP";
            btnDetailFTP.Size = new Size(200, 31);
            btnDetailFTP.TabIndex = 3;
            btnDetailFTP.Text = "Detail";
            btnDetailFTP.UseVisualStyleBackColor = true;
            btnDetailFTP.Click += btnDetailFTP_Click;
            // 
            // btnDeleteFTP
            // 
            btnDeleteFTP.Location = new Point(26, 100);
            btnDeleteFTP.Name = "btnDeleteFTP";
            btnDeleteFTP.Size = new Size(200, 31);
            btnDeleteFTP.TabIndex = 2;
            btnDeleteFTP.Text = "Delete";
            btnDeleteFTP.UseVisualStyleBackColor = true;
            btnDeleteFTP.Click += btnDeleteFTP_Click;
            // 
            // btnEditProject
            // 
            btnEditProject.Location = new Point(26, 70);
            btnEditProject.Name = "btnEditProject";
            btnEditProject.Size = new Size(200, 31);
            btnEditProject.TabIndex = 1;
            btnEditProject.Text = "Edit";
            btnEditProject.UseVisualStyleBackColor = true;
            btnEditProject.Click += btnEditProject_Click;
            // 
            // btnAddProject
            // 
            btnAddProject.Location = new Point(26, 40);
            btnAddProject.Name = "btnAddProject";
            btnAddProject.Size = new Size(200, 31);
            btnAddProject.TabIndex = 0;
            btnAddProject.Text = "New";
            btnAddProject.UseVisualStyleBackColor = true;
            btnAddProject.Click += btnAddProject_Click;
            // 
            // footer
            // 
            footer.ImageScalingSize = new Size(20, 20);
            footer.Items.AddRange(new ToolStripItem[] { tsProgressBar, lbStatusOther, tsStatusOther });
            footer.Location = new Point(0, 424);
            footer.Name = "footer";
            footer.Size = new Size(800, 26);
            footer.TabIndex = 2;
            footer.Text = "statusStrip1";
            // 
            // tsProgressBar
            // 
            tsProgressBar.Margin = new Padding(20, 4, 20, 4);
            tsProgressBar.Name = "tsProgressBar";
            tsProgressBar.Size = new Size(100, 18);
            // 
            // lbStatusOther
            // 
            lbStatusOther.Name = "lbStatusOther";
            lbStatusOther.Size = new Size(43, 20);
            lbStatusOther.Text = "Logs:";
            // 
            // tsStatusOther
            // 
            tsStatusOther.Name = "tsStatusOther";
            tsStatusOther.Size = new Size(0, 20);
            // 
            // ftpConfig
            // 
            ftpConfig.Controls.Add(gbFTP);
            ftpConfig.Location = new Point(0, 0);
            ftpConfig.Name = "ftpConfig";
            ftpConfig.Size = new Size(800, 425);
            ftpConfig.TabIndex = 4;
            // 
            // gbFTP
            // 
            gbFTP.Controls.Add(txtbConfigName);
            gbFTP.Controls.Add(label3);
            gbFTP.Controls.Add(btnTestConnectFTP);
            gbFTP.Controls.Add(btnOpenDirLocal);
            gbFTP.Controls.Add(txtbLocalDir);
            gbFTP.Controls.Add(label7);
            gbFTP.Controls.Add(txtbTargetDir);
            gbFTP.Controls.Add(label6);
            gbFTP.Controls.Add(btnOpenFileFTP);
            gbFTP.Controls.Add(txtbPPKFile);
            gbFTP.Controls.Add(txtbPassword);
            gbFTP.Controls.Add(txtbPort);
            gbFTP.Controls.Add(txtbUsername);
            gbFTP.Controls.Add(txtbHostName);
            gbFTP.Controls.Add(ckIsPrivateKey);
            gbFTP.Controls.Add(label5);
            gbFTP.Controls.Add(label4);
            gbFTP.Controls.Add(label2);
            gbFTP.Controls.Add(label1);
            gbFTP.Controls.Add(btnCancelFTPConfig);
            gbFTP.Controls.Add(btnSaveFTPConfig);
            gbFTP.Location = new Point(13, 17);
            gbFTP.Name = "gbFTP";
            gbFTP.Size = new Size(777, 399);
            gbFTP.TabIndex = 0;
            gbFTP.TabStop = false;
            gbFTP.Text = "FTP Config";
            // 
            // txtbConfigName
            // 
            txtbConfigName.Location = new Point(147, 303);
            txtbConfigName.Name = "txtbConfigName";
            txtbConfigName.Size = new Size(266, 27);
            txtbConfigName.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(72, 306);
            label3.Name = "label3";
            label3.Size = new Size(56, 20);
            label3.TabIndex = 21;
            label3.Text = "Name :";
            // 
            // btnTestConnectFTP
            // 
            btnTestConnectFTP.Location = new Point(6, 359);
            btnTestConnectFTP.Name = "btnTestConnectFTP";
            btnTestConnectFTP.Size = new Size(121, 24);
            btnTestConnectFTP.TabIndex = 20;
            btnTestConnectFTP.Text = "Test";
            btnTestConnectFTP.UseVisualStyleBackColor = true;
            btnTestConnectFTP.Click += btnTestConnectFTP_Click;
            // 
            // btnOpenDirLocal
            // 
            btnOpenDirLocal.Location = new Point(711, 257);
            btnOpenDirLocal.Name = "btnOpenDirLocal";
            btnOpenDirLocal.Size = new Size(44, 27);
            btnOpenDirLocal.TabIndex = 19;
            btnOpenDirLocal.Text = "...";
            btnOpenDirLocal.UseVisualStyleBackColor = true;
            btnOpenDirLocal.Click += btnOpenDirLocal_Click;
            // 
            // txtbLocalDir
            // 
            txtbLocalDir.Location = new Point(147, 257);
            txtbLocalDir.Name = "txtbLocalDir";
            txtbLocalDir.Size = new Size(558, 27);
            txtbLocalDir.TabIndex = 18;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 260);
            label7.Name = "label7";
            label7.Size = new Size(116, 20);
            label7.TabIndex = 17;
            label7.Text = "Local Directory :";
            // 
            // txtbTargetDir
            // 
            txtbTargetDir.Location = new Point(147, 210);
            txtbTargetDir.Name = "txtbTargetDir";
            txtbTargetDir.Size = new Size(266, 27);
            txtbTargetDir.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 213);
            label6.Name = "label6";
            label6.Size = new Size(122, 20);
            label6.TabIndex = 15;
            label6.Text = "Target Directory :";
            // 
            // btnOpenFileFTP
            // 
            btnOpenFileFTP.Location = new Point(711, 163);
            btnOpenFileFTP.Name = "btnOpenFileFTP";
            btnOpenFileFTP.Size = new Size(44, 27);
            btnOpenFileFTP.TabIndex = 14;
            btnOpenFileFTP.Text = "...";
            btnOpenFileFTP.UseVisualStyleBackColor = true;
            btnOpenFileFTP.Click += btnOpenFileFTP_Click;
            // 
            // txtbPPKFile
            // 
            txtbPPKFile.Location = new Point(147, 163);
            txtbPPKFile.Name = "txtbPPKFile";
            txtbPPKFile.Size = new Size(558, 27);
            txtbPPKFile.TabIndex = 13;
            // 
            // txtbPassword
            // 
            txtbPassword.Location = new Point(502, 70);
            txtbPassword.Name = "txtbPassword";
            txtbPassword.Size = new Size(266, 27);
            txtbPassword.TabIndex = 12;
            // 
            // txtbPort
            // 
            txtbPort.Location = new Point(502, 29);
            txtbPort.Name = "txtbPort";
            txtbPort.Size = new Size(266, 27);
            txtbPort.TabIndex = 11;
            // 
            // txtbUsername
            // 
            txtbUsername.Location = new Point(147, 70);
            txtbUsername.Name = "txtbUsername";
            txtbUsername.Size = new Size(266, 27);
            txtbUsername.TabIndex = 9;
            // 
            // txtbHostName
            // 
            txtbHostName.Location = new Point(147, 30);
            txtbHostName.Name = "txtbHostName";
            txtbHostName.Size = new Size(266, 27);
            txtbHostName.TabIndex = 8;
            // 
            // ckIsPrivateKey
            // 
            ckIsPrivateKey.AutoSize = true;
            ckIsPrivateKey.Location = new Point(17, 165);
            ckIsPrivateKey.Name = "ckIsPrivateKey";
            ckIsPrivateKey.Size = new Size(128, 24);
            ckIsPrivateKey.TabIndex = 7;
            ckIsPrivateKey.Text = "PrivateKey.ppk";
            ckIsPrivateKey.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(419, 73);
            label5.Name = "label5";
            label5.Size = new Size(77, 20);
            label5.TabIndex = 6;
            label5.Text = "Password :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(454, 33);
            label4.Name = "label4";
            label4.Size = new Size(42, 20);
            label4.TabIndex = 5;
            label4.Text = "Port :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 73);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 3;
            label2.Text = "Username :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 33);
            label1.Name = "label1";
            label1.Size = new Size(88, 20);
            label1.TabIndex = 2;
            label1.Text = "Host name :";
            // 
            // btnCancelFTPConfig
            // 
            btnCancelFTPConfig.Location = new Point(648, 359);
            btnCancelFTPConfig.Name = "btnCancelFTPConfig";
            btnCancelFTPConfig.Size = new Size(121, 24);
            btnCancelFTPConfig.TabIndex = 1;
            btnCancelFTPConfig.Text = "Cancel";
            btnCancelFTPConfig.UseVisualStyleBackColor = true;
            btnCancelFTPConfig.Click += btnCancelFTPConfig_Click;
            // 
            // btnSaveFTPConfig
            // 
            btnSaveFTPConfig.Location = new Point(521, 359);
            btnSaveFTPConfig.Name = "btnSaveFTPConfig";
            btnSaveFTPConfig.Size = new Size(121, 24);
            btnSaveFTPConfig.TabIndex = 0;
            btnSaveFTPConfig.Text = "Save";
            btnSaveFTPConfig.UseVisualStyleBackColor = true;
            btnSaveFTPConfig.Click += btnSaveFTPConfig_Click;
            // 
            // btnQtUpload
            // 
            btnQtUpload.Location = new Point(29, 41);
            btnQtUpload.Name = "btnQtUpload";
            btnQtUpload.Size = new Size(200, 31);
            btnQtUpload.TabIndex = 4;
            btnQtUpload.Text = "Upload";
            btnQtUpload.UseVisualStyleBackColor = true;
            // 
            // FTPManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(main);
            Controls.Add(ftpConfig);
            Controls.Add(footer);
            Name = "FTPManagement";
            Text = "FTPManagement";
            main.ResumeLayout(false);
            gbDengerZone.ResumeLayout(false);
            gbManageZone.ResumeLayout(false);
            footer.ResumeLayout(false);
            footer.PerformLayout();
            ftpConfig.ResumeLayout(false);
            gbFTP.ResumeLayout(false);
            gbFTP.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel main;
        private StatusStrip footer;
        private ToolStripProgressBar tsProgressBar;
        private ToolStripStatusLabel lbStatusOther;
        private GroupBox gbDengerZone;
        private GroupBox gbManageZone;
        private ListBox lsbProjectList;
        private Button btnDeleteFTP;
        private Button btnEditProject;
        private Button btnAddProject;
        private Panel ftpConfig;
        private GroupBox gbFTP;
        private Button btnCancelFTPConfig;
        private Button btnSaveFTPConfig;
        private TextBox txtbPassword;
        private TextBox txtbPort;
        private TextBox txtbUsername;
        private TextBox txtbHostName;
        private CheckBox ckIsPrivateKey;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label1;
        private TextBox txtbPPKFile;
        private Button btnOpenFileFTP;
        private Button btnOpenDirLocal;
        private TextBox txtbLocalDir;
        private Label label7;
        private TextBox txtbTargetDir;
        private Label label6;
        private Button btnTestConnectFTP;
        private TextBox txtbConfigName;
        private Label label3;
        private ToolStripStatusLabel tsStatusOther;
        private Button btnDetailFTP;
        private Button btnQtUpload;
    }
}
