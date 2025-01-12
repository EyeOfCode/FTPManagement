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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTPManagement));
            main = new Panel();
            lsbProjectList = new ListBox();
            gbDengerZone = new GroupBox();
            CurrentConfig = new GroupBox();
            lblIgnoreFileCureent = new Label();
            lblScriptDitCurrent = new Label();
            lblTragetDirCurrent = new Label();
            lblLocalDirCurrent = new Label();
            lblUserNameCurrent = new Label();
            lblHostCurrentName = new Label();
            lblHostCurrent = new Label();
            btnWebConfig = new Button();
            btnQtCmd = new Button();
            btnQtDrop = new Button();
            btnQtUpload = new Button();
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
            txtbIgnore = new TextBox();
            label10 = new Label();
            txtbScriptDir = new TextBox();
            label8 = new Label();
            btnDropFTP = new Button();
            btnCmd = new Button();
            btnUploadFTP = new Button();
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
            logs = new Panel();
            rtbLogs = new RichTextBox();
            webConfig = new Panel();
            btnOpenCmd = new Button();
            btnPingWeb = new Button();
            btnOpenWeb = new Button();
            brnSaveWebConfig = new Button();
            btnWebCancel = new Button();
            gbWebConfig = new GroupBox();
            txtbDomain = new TextBox();
            label9 = new Label();
            main.SuspendLayout();
            gbDengerZone.SuspendLayout();
            CurrentConfig.SuspendLayout();
            gbManageZone.SuspendLayout();
            footer.SuspendLayout();
            ftpConfig.SuspendLayout();
            gbFTP.SuspendLayout();
            logs.SuspendLayout();
            webConfig.SuspendLayout();
            gbWebConfig.SuspendLayout();
            SuspendLayout();
            // 
            // main
            // 
            main.Controls.Add(lsbProjectList);
            main.Controls.Add(gbDengerZone);
            main.Controls.Add(gbManageZone);
            main.Location = new Point(0, 0);
            main.Name = "main";
            main.Size = new Size(799, 421);
            main.TabIndex = 1;
            // 
            // lsbProjectList
            // 
            lsbProjectList.Location = new Point(12, 32);
            lsbProjectList.Name = "lsbProjectList";
            lsbProjectList.Size = new Size(265, 384);
            lsbProjectList.TabIndex = 0;
            lsbProjectList.SelectedIndexChanged += lsbProjectList_SelectedIndexChanged;
            // 
            // gbDengerZone
            // 
            gbDengerZone.Controls.Add(CurrentConfig);
            gbDengerZone.Controls.Add(btnWebConfig);
            gbDengerZone.Controls.Add(btnQtCmd);
            gbDengerZone.Controls.Add(btnQtDrop);
            gbDengerZone.Controls.Add(btnQtUpload);
            gbDengerZone.Location = new Point(539, 9);
            gbDengerZone.Name = "gbDengerZone";
            gbDengerZone.Size = new Size(249, 407);
            gbDengerZone.TabIndex = 1;
            gbDengerZone.TabStop = false;
            gbDengerZone.Text = "DangerZone";
            // 
            // CurrentConfig
            // 
            CurrentConfig.Controls.Add(lblIgnoreFileCureent);
            CurrentConfig.Controls.Add(lblScriptDitCurrent);
            CurrentConfig.Controls.Add(lblTragetDirCurrent);
            CurrentConfig.Controls.Add(lblLocalDirCurrent);
            CurrentConfig.Controls.Add(lblUserNameCurrent);
            CurrentConfig.Controls.Add(lblHostCurrentName);
            CurrentConfig.Controls.Add(lblHostCurrent);
            CurrentConfig.Location = new Point(15, 33);
            CurrentConfig.Name = "CurrentConfig";
            CurrentConfig.Size = new Size(222, 210);
            CurrentConfig.TabIndex = 8;
            CurrentConfig.TabStop = false;
            CurrentConfig.Text = "Current Config";
            // 
            // lblIgnoreFileCureent
            // 
            lblIgnoreFileCureent.AutoSize = true;
            lblIgnoreFileCureent.Location = new Point(11, 181);
            lblIgnoreFileCureent.Name = "lblIgnoreFileCureent";
            lblIgnoreFileCureent.Size = new Size(86, 20);
            lblIgnoreFileCureent.TabIndex = 6;
            lblIgnoreFileCureent.Text = "Ignore File: ";
            // 
            // lblScriptDitCurrent
            // 
            lblScriptDitCurrent.AutoSize = true;
            lblScriptDitCurrent.Location = new Point(11, 159);
            lblScriptDitCurrent.Name = "lblScriptDitCurrent";
            lblScriptDitCurrent.Size = new Size(74, 20);
            lblScriptDitCurrent.TabIndex = 5;
            lblScriptDitCurrent.Text = "Script Dir:";
            // 
            // lblTragetDirCurrent
            // 
            lblTragetDirCurrent.AutoSize = true;
            lblTragetDirCurrent.Location = new Point(11, 132);
            lblTragetDirCurrent.Name = "lblTragetDirCurrent";
            lblTragetDirCurrent.Size = new Size(78, 20);
            lblTragetDirCurrent.TabIndex = 4;
            lblTragetDirCurrent.Text = "Traget Dir:";
            // 
            // lblLocalDirCurrent
            // 
            lblLocalDirCurrent.AutoSize = true;
            lblLocalDirCurrent.Location = new Point(11, 106);
            lblLocalDirCurrent.Name = "lblLocalDirCurrent";
            lblLocalDirCurrent.Size = new Size(71, 20);
            lblLocalDirCurrent.TabIndex = 3;
            lblLocalDirCurrent.Text = "Local Dir:";
            // 
            // lblUserNameCurrent
            // 
            lblUserNameCurrent.AutoSize = true;
            lblUserNameCurrent.Location = new Point(11, 78);
            lblUserNameCurrent.Name = "lblUserNameCurrent";
            lblUserNameCurrent.Size = new Size(78, 20);
            lblUserNameCurrent.TabIndex = 2;
            lblUserNameCurrent.Text = "Username:";
            // 
            // lblHostCurrentName
            // 
            lblHostCurrentName.AutoSize = true;
            lblHostCurrentName.Location = new Point(11, 29);
            lblHostCurrentName.Name = "lblHostCurrentName";
            lblHostCurrentName.Size = new Size(87, 20);
            lblHostCurrentName.TabIndex = 1;
            lblHostCurrentName.Text = "Host Name:";
            // 
            // lblHostCurrent
            // 
            lblHostCurrent.AutoSize = true;
            lblHostCurrent.Location = new Point(11, 54);
            lblHostCurrent.Name = "lblHostCurrent";
            lblHostCurrent.Size = new Size(43, 20);
            lblHostCurrent.TabIndex = 0;
            lblHostCurrent.Text = "Host:";
            // 
            // btnWebConfig
            // 
            btnWebConfig.Location = new Point(26, 367);
            btnWebConfig.Name = "btnWebConfig";
            btnWebConfig.Size = new Size(200, 31);
            btnWebConfig.TabIndex = 7;
            btnWebConfig.Text = "Web";
            btnWebConfig.UseVisualStyleBackColor = true;
            btnWebConfig.Click += btnWebConfig_Click;
            // 
            // btnQtCmd
            // 
            btnQtCmd.Location = new Point(26, 317);
            btnQtCmd.Name = "btnQtCmd";
            btnQtCmd.Size = new Size(200, 31);
            btnQtCmd.TabIndex = 6;
            btnQtCmd.Text = "Run Script";
            btnQtCmd.UseVisualStyleBackColor = true;
            btnQtCmd.Click += btnQtCmd_Click;
            // 
            // btnQtDrop
            // 
            btnQtDrop.Location = new Point(26, 287);
            btnQtDrop.Name = "btnQtDrop";
            btnQtDrop.Size = new Size(200, 31);
            btnQtDrop.TabIndex = 5;
            btnQtDrop.Text = "Drop";
            btnQtDrop.UseVisualStyleBackColor = true;
            btnQtDrop.Click += btnQtDrop_Click;
            // 
            // btnQtUpload
            // 
            btnQtUpload.Location = new Point(26, 257);
            btnQtUpload.Name = "btnQtUpload";
            btnQtUpload.Size = new Size(200, 31);
            btnQtUpload.TabIndex = 4;
            btnQtUpload.Text = "Upload";
            btnQtUpload.UseVisualStyleBackColor = true;
            btnQtUpload.Click += btnQtUpload_Click;
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
            ftpConfig.Size = new Size(800, 421);
            ftpConfig.TabIndex = 4;
            // 
            // gbFTP
            // 
            gbFTP.Controls.Add(txtbIgnore);
            gbFTP.Controls.Add(label10);
            gbFTP.Controls.Add(txtbScriptDir);
            gbFTP.Controls.Add(label8);
            gbFTP.Controls.Add(btnDropFTP);
            gbFTP.Controls.Add(btnCmd);
            gbFTP.Controls.Add(btnUploadFTP);
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
            gbFTP.Location = new Point(10, 12);
            gbFTP.Name = "gbFTP";
            gbFTP.Size = new Size(777, 403);
            gbFTP.TabIndex = 0;
            gbFTP.TabStop = false;
            gbFTP.Text = "FTP Config";
            // 
            // txtbIgnore
            // 
            txtbIgnore.Location = new Point(147, 324);
            txtbIgnore.Name = "txtbIgnore";
            txtbIgnore.Size = new Size(494, 27);
            txtbIgnore.TabIndex = 29;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(69, 327);
            label10.Name = "label10";
            label10.Size = new Size(59, 20);
            label10.TabIndex = 28;
            label10.Text = "Ignore :";
            // 
            // txtbScriptDir
            // 
            txtbScriptDir.Location = new Point(147, 246);
            txtbScriptDir.Name = "txtbScriptDir";
            txtbScriptDir.Size = new Size(558, 27);
            txtbScriptDir.TabIndex = 27;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(33, 249);
            label8.Name = "label8";
            label8.Size = new Size(95, 20);
            label8.TabIndex = 26;
            label8.Text = "Target Script:";
            // 
            // btnDropFTP
            // 
            btnDropFTP.Location = new Point(260, 359);
            btnDropFTP.Name = "btnDropFTP";
            btnDropFTP.Size = new Size(121, 31);
            btnDropFTP.TabIndex = 25;
            btnDropFTP.Text = "Drop";
            btnDropFTP.UseVisualStyleBackColor = true;
            btnDropFTP.Visible = false;
            btnDropFTP.Click += btnDropFTP_Click;
            // 
            // btnCmd
            // 
            btnCmd.Location = new Point(387, 359);
            btnCmd.Name = "btnCmd";
            btnCmd.Size = new Size(121, 31);
            btnCmd.TabIndex = 24;
            btnCmd.Text = "Run Script";
            btnCmd.UseVisualStyleBackColor = true;
            btnCmd.Visible = false;
            btnCmd.Click += btnCmd_Click;
            // 
            // btnUploadFTP
            // 
            btnUploadFTP.Location = new Point(133, 359);
            btnUploadFTP.Name = "btnUploadFTP";
            btnUploadFTP.Size = new Size(121, 31);
            btnUploadFTP.TabIndex = 23;
            btnUploadFTP.Text = "Upload";
            btnUploadFTP.UseVisualStyleBackColor = true;
            btnUploadFTP.Visible = false;
            btnUploadFTP.Click += btnUploadFTP_Click;
            // 
            // txtbConfigName
            // 
            txtbConfigName.Location = new Point(147, 288);
            txtbConfigName.Name = "txtbConfigName";
            txtbConfigName.Size = new Size(266, 27);
            txtbConfigName.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(72, 291);
            label3.Name = "label3";
            label3.Size = new Size(56, 20);
            label3.TabIndex = 21;
            label3.Text = "Name :";
            // 
            // btnTestConnectFTP
            // 
            btnTestConnectFTP.Location = new Point(6, 359);
            btnTestConnectFTP.Name = "btnTestConnectFTP";
            btnTestConnectFTP.Size = new Size(121, 31);
            btnTestConnectFTP.TabIndex = 20;
            btnTestConnectFTP.Text = "Test";
            btnTestConnectFTP.UseVisualStyleBackColor = true;
            btnTestConnectFTP.Click += btnTestConnectFTP_Click;
            // 
            // btnOpenDirLocal
            // 
            btnOpenDirLocal.Location = new Point(711, 159);
            btnOpenDirLocal.Name = "btnOpenDirLocal";
            btnOpenDirLocal.Size = new Size(44, 27);
            btnOpenDirLocal.TabIndex = 19;
            btnOpenDirLocal.Text = "...";
            btnOpenDirLocal.UseVisualStyleBackColor = true;
            btnOpenDirLocal.Click += btnOpenDirLocal_Click;
            // 
            // txtbLocalDir
            // 
            txtbLocalDir.Location = new Point(147, 159);
            txtbLocalDir.Name = "txtbLocalDir";
            txtbLocalDir.Size = new Size(558, 27);
            txtbLocalDir.TabIndex = 18;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 162);
            label7.Name = "label7";
            label7.Size = new Size(116, 20);
            label7.TabIndex = 17;
            label7.Text = "Local Directory :";
            // 
            // txtbTargetDir
            // 
            txtbTargetDir.Location = new Point(147, 204);
            txtbTargetDir.Name = "txtbTargetDir";
            txtbTargetDir.Size = new Size(558, 27);
            txtbTargetDir.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 207);
            label6.Name = "label6";
            label6.Size = new Size(122, 20);
            label6.TabIndex = 15;
            label6.Text = "Target Directory :";
            // 
            // btnOpenFileFTP
            // 
            btnOpenFileFTP.Location = new Point(711, 114);
            btnOpenFileFTP.Name = "btnOpenFileFTP";
            btnOpenFileFTP.Size = new Size(44, 27);
            btnOpenFileFTP.TabIndex = 14;
            btnOpenFileFTP.Text = "...";
            btnOpenFileFTP.UseVisualStyleBackColor = true;
            btnOpenFileFTP.Click += btnOpenFileFTP_Click;
            // 
            // txtbPPKFile
            // 
            txtbPPKFile.Location = new Point(147, 114);
            txtbPPKFile.Name = "txtbPPKFile";
            txtbPPKFile.Size = new Size(558, 27);
            txtbPPKFile.TabIndex = 13;
            // 
            // txtbPassword
            // 
            txtbPassword.Location = new Point(502, 70);
            txtbPassword.Name = "txtbPassword";
            txtbPassword.PasswordChar = '*';
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
            ckIsPrivateKey.Location = new Point(17, 116);
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
            btnCancelFTPConfig.Size = new Size(121, 31);
            btnCancelFTPConfig.TabIndex = 1;
            btnCancelFTPConfig.Text = "Cancel";
            btnCancelFTPConfig.UseVisualStyleBackColor = true;
            btnCancelFTPConfig.Click += btnCancelFTPConfig_Click;
            // 
            // btnSaveFTPConfig
            // 
            btnSaveFTPConfig.Location = new Point(647, 322);
            btnSaveFTPConfig.Name = "btnSaveFTPConfig";
            btnSaveFTPConfig.Size = new Size(121, 31);
            btnSaveFTPConfig.TabIndex = 0;
            btnSaveFTPConfig.Text = "Save";
            btnSaveFTPConfig.UseVisualStyleBackColor = true;
            btnSaveFTPConfig.Click += btnSaveFTPConfig_Click;
            // 
            // logs
            // 
            logs.Controls.Add(rtbLogs);
            logs.Location = new Point(0, 0);
            logs.Name = "logs";
            logs.Size = new Size(797, 420);
            logs.TabIndex = 1;
            // 
            // rtbLogs
            // 
            rtbLogs.Location = new Point(10, 12);
            rtbLogs.Name = "rtbLogs";
            rtbLogs.Size = new Size(777, 403);
            rtbLogs.TabIndex = 6;
            rtbLogs.Text = "";
            // 
            // webConfig
            // 
            webConfig.Controls.Add(btnOpenCmd);
            webConfig.Controls.Add(btnPingWeb);
            webConfig.Controls.Add(btnOpenWeb);
            webConfig.Controls.Add(brnSaveWebConfig);
            webConfig.Controls.Add(btnWebCancel);
            webConfig.Controls.Add(gbWebConfig);
            webConfig.Location = new Point(0, 0);
            webConfig.Name = "webConfig";
            webConfig.Size = new Size(799, 423);
            webConfig.TabIndex = 5;
            // 
            // btnOpenCmd
            // 
            btnOpenCmd.Location = new Point(22, 307);
            btnOpenCmd.Name = "btnOpenCmd";
            btnOpenCmd.Size = new Size(200, 31);
            btnOpenCmd.TabIndex = 11;
            btnOpenCmd.Text = "Cmd";
            btnOpenCmd.UseVisualStyleBackColor = true;
            btnOpenCmd.Click += btnOpenCmd_Click;
            // 
            // btnPingWeb
            // 
            btnPingWeb.Location = new Point(22, 339);
            btnPingWeb.Name = "btnPingWeb";
            btnPingWeb.Size = new Size(200, 31);
            btnPingWeb.TabIndex = 10;
            btnPingWeb.Text = "Ping";
            btnPingWeb.UseVisualStyleBackColor = true;
            btnPingWeb.Click += btnPingWeb_Click;
            // 
            // btnOpenWeb
            // 
            btnOpenWeb.Location = new Point(22, 371);
            btnOpenWeb.Name = "btnOpenWeb";
            btnOpenWeb.Size = new Size(200, 31);
            btnOpenWeb.TabIndex = 8;
            btnOpenWeb.Text = "Open";
            btnOpenWeb.UseVisualStyleBackColor = true;
            btnOpenWeb.Click += btnOpenWeb_Click;
            // 
            // brnSaveWebConfig
            // 
            brnSaveWebConfig.Location = new Point(577, 339);
            brnSaveWebConfig.Name = "brnSaveWebConfig";
            brnSaveWebConfig.Size = new Size(200, 31);
            brnSaveWebConfig.TabIndex = 9;
            brnSaveWebConfig.Text = "Save";
            brnSaveWebConfig.UseVisualStyleBackColor = true;
            brnSaveWebConfig.Click += brnSaveWebConfig_Click;
            // 
            // btnWebCancel
            // 
            btnWebCancel.Location = new Point(577, 371);
            btnWebCancel.Name = "btnWebCancel";
            btnWebCancel.Size = new Size(200, 31);
            btnWebCancel.TabIndex = 8;
            btnWebCancel.Text = "Cancel";
            btnWebCancel.UseVisualStyleBackColor = true;
            btnWebCancel.Click += btnWebCancel_Click_1;
            // 
            // gbWebConfig
            // 
            gbWebConfig.Controls.Add(txtbDomain);
            gbWebConfig.Controls.Add(label9);
            gbWebConfig.Location = new Point(22, 30);
            gbWebConfig.Name = "gbWebConfig";
            gbWebConfig.Size = new Size(755, 73);
            gbWebConfig.TabIndex = 1;
            gbWebConfig.TabStop = false;
            gbWebConfig.Text = "Web";
            // 
            // txtbDomain
            // 
            txtbDomain.Location = new Point(94, 29);
            txtbDomain.Name = "txtbDomain";
            txtbDomain.Size = new Size(639, 27);
            txtbDomain.TabIndex = 1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(19, 32);
            label9.Name = "label9";
            label9.Size = new Size(69, 20);
            label9.TabIndex = 0;
            label9.Text = "Domain :";
            // 
            // FTPManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(main);
            Controls.Add(ftpConfig);
            Controls.Add(webConfig);
            Controls.Add(logs);
            Controls.Add(footer);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FTPManagement";
            Text = "FTPManagement";
            main.ResumeLayout(false);
            gbDengerZone.ResumeLayout(false);
            CurrentConfig.ResumeLayout(false);
            CurrentConfig.PerformLayout();
            gbManageZone.ResumeLayout(false);
            footer.ResumeLayout(false);
            footer.PerformLayout();
            ftpConfig.ResumeLayout(false);
            gbFTP.ResumeLayout(false);
            gbFTP.PerformLayout();
            logs.ResumeLayout(false);
            webConfig.ResumeLayout(false);
            gbWebConfig.ResumeLayout(false);
            gbWebConfig.PerformLayout();
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
        private Button btnUploadFTP;
        private Button btnCmd;
        private Button btnDropFTP;
        private TextBox txtbScriptDir;
        private Label label8;
        private Panel logs;
        private Button btnQtDrop;
        private Button btnQtCmd;
        private Button btnWebConfig;
        private Panel webConfig;
        private Label label9;
        private GroupBox gbWebConfig;
        private TextBox txtbDomain;
        private Button btnPingWeb;
        private Button btnOpenWeb;
        private Button brnSaveWebConfig;
        private Button btnWebCancel;
        private Button btnOpenCmd;
        private TextBox txtbIgnore;
        private Label label10;
        private RichTextBox rtbLogs;
        private GroupBox CurrentConfig;
        private Label lblHostCurrent;
        private Label lblHostCurrentName;
        private Label lblUserNameCurrent;
        private Label lblLocalDirCurrent;
        private Label lblTragetDirCurrent;
        private Label lblScriptDitCurrent;
        private Label lblIgnoreFileCureent;
    }
}
