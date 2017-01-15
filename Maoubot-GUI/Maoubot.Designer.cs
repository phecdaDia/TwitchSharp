using System;
using System.Collections.Generic;
using Maoubot_GUI.Component.Commands;

namespace Maoubot_GUI
{
	partial class Maoubot
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Maoubot));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.Chatbox = new System.Windows.Forms.TextBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.buttonSave = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.buttonAccountsDelete = new System.Windows.Forms.Button();
			this.buttonAccountsLoad = new System.Windows.Forms.Button();
			this.comboBoxAccounts = new System.Windows.Forms.ComboBox();
			this.buttonPart = new System.Windows.Forms.Button();
			this.buttonConnect = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxNickname = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonDisconnect = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxOAuth = new System.Windows.Forms.TextBox();
			this.textBoxChannel = new System.Windows.Forms.TextBox();
			this.Debugbox = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.textBoxSubMessageResub = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.checkBoxEnableSubMessage = new System.Windows.Forms.CheckBox();
			this.textBoxSubMessageNew = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.textBoxMessage = new System.Windows.Forms.TextBox();
			this.buttonSendMessage = new System.Windows.Forms.Button();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.checkBoxEnableCommands = new System.Windows.Forms.CheckBox();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.buttonTextCommandAdd = new System.Windows.Forms.Button();
			this.buttonTextCommandDelete = new System.Windows.Forms.Button();
			this.buttonTextCommandEdit = new System.Windows.Forms.Button();
			this.comboBoxTextCommands = new System.Windows.Forms.ComboBox();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.labelTwitchEmoteSearch = new System.Windows.Forms.Label();
			this.textBoxTwitchEmoteSearch = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.buttonResetStats = new System.Windows.Forms.Button();
			this.labelCheerTest = new System.Windows.Forms.Label();
			this.buttonRandomColor = new System.Windows.Forms.Button();
			this.buttonTwitchEmoteResort = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel3.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
			this.tableLayoutPanel1.Controls.Add(this.Chatbox, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 612);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// Chatbox
			// 
			this.Chatbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Chatbox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Chatbox.Location = new System.Drawing.Point(3, 3);
			this.Chatbox.Multiline = true;
			this.Chatbox.Name = "Chatbox";
			this.Chatbox.ReadOnly = true;
			this.Chatbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.Chatbox.Size = new System.Drawing.Size(528, 606);
			this.Chatbox.TabIndex = 0;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.buttonSave);
			this.panel3.Controls.Add(this.tabControl1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(534, 0);
			this.panel3.Margin = new System.Windows.Forms.Padding(0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(350, 612);
			this.panel3.TabIndex = 3;
			// 
			// buttonSave
			// 
			this.buttonSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonSave.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonSave.Location = new System.Drawing.Point(0, 584);
			this.buttonSave.Margin = new System.Windows.Forms.Padding(0);
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.Size = new System.Drawing.Size(350, 28);
			this.buttonSave.TabIndex = 3;
			this.buttonSave.Text = "Apply / Save";
			this.buttonSave.UseVisualStyleBackColor = true;
			this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage6);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(350, 584);
			this.tabControl1.TabIndex = 2;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.splitContainer1);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(342, 555);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Login/Connect";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(3, 3);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.buttonAccountsDelete);
			this.splitContainer1.Panel1.Controls.Add(this.buttonAccountsLoad);
			this.splitContainer1.Panel1.Controls.Add(this.comboBoxAccounts);
			this.splitContainer1.Panel1.Controls.Add(this.buttonPart);
			this.splitContainer1.Panel1.Controls.Add(this.buttonConnect);
			this.splitContainer1.Panel1.Controls.Add(this.label3);
			this.splitContainer1.Panel1.Controls.Add(this.textBoxNickname);
			this.splitContainer1.Panel1.Controls.Add(this.label2);
			this.splitContainer1.Panel1.Controls.Add(this.buttonDisconnect);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			this.splitContainer1.Panel1.Controls.Add(this.textBoxOAuth);
			this.splitContainer1.Panel1.Controls.Add(this.textBoxChannel);
			this.splitContainer1.Panel1MinSize = 0;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.Debugbox);
			this.splitContainer1.Size = new System.Drawing.Size(336, 549);
			this.splitContainer1.SplitterDistance = 139;
			this.splitContainer1.TabIndex = 11;
			// 
			// buttonAccountsDelete
			// 
			this.buttonAccountsDelete.Location = new System.Drawing.Point(253, 81);
			this.buttonAccountsDelete.Name = "buttonAccountsDelete";
			this.buttonAccountsDelete.Size = new System.Drawing.Size(77, 23);
			this.buttonAccountsDelete.TabIndex = 14;
			this.buttonAccountsDelete.Text = "Delete";
			this.buttonAccountsDelete.UseVisualStyleBackColor = true;
			this.buttonAccountsDelete.Click += new System.EventHandler(this.buttonAccountsDelete_Click);
			// 
			// buttonAccountsLoad
			// 
			this.buttonAccountsLoad.Location = new System.Drawing.Point(172, 81);
			this.buttonAccountsLoad.Name = "buttonAccountsLoad";
			this.buttonAccountsLoad.Size = new System.Drawing.Size(77, 23);
			this.buttonAccountsLoad.TabIndex = 13;
			this.buttonAccountsLoad.Text = "Load";
			this.buttonAccountsLoad.UseVisualStyleBackColor = true;
			this.buttonAccountsLoad.Click += new System.EventHandler(this.buttonAccountsLoad_Click);
			// 
			// comboBoxAccounts
			// 
			this.comboBoxAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxAccounts.FormattingEnabled = true;
			this.comboBoxAccounts.Items.AddRange(new object[] {
            "NO_ACCOUNT"});
			this.comboBoxAccounts.Location = new System.Drawing.Point(9, 83);
			this.comboBoxAccounts.Name = "comboBoxAccounts";
			this.comboBoxAccounts.Size = new System.Drawing.Size(155, 21);
			this.comboBoxAccounts.TabIndex = 12;
			// 
			// buttonPart
			// 
			this.buttonPart.Location = new System.Drawing.Point(172, 110);
			this.buttonPart.Name = "buttonPart";
			this.buttonPart.Size = new System.Drawing.Size(77, 25);
			this.buttonPart.TabIndex = 11;
			this.buttonPart.Text = "Part";
			this.buttonPart.UseVisualStyleBackColor = true;
			this.buttonPart.Click += new System.EventHandler(this.buttonPart_Click);
			// 
			// buttonConnect
			// 
			this.buttonConnect.Location = new System.Drawing.Point(7, 110);
			this.buttonConnect.Name = "buttonConnect";
			this.buttonConnect.Size = new System.Drawing.Size(157, 25);
			this.buttonConnect.TabIndex = 1;
			this.buttonConnect.Text = "Connect";
			this.buttonConnect.UseVisualStyleBackColor = true;
			this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 60);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(46, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Channel";
			// 
			// textBoxNickname
			// 
			this.textBoxNickname.Location = new System.Drawing.Point(65, 8);
			this.textBoxNickname.Name = "textBoxNickname";
			this.textBoxNickname.Size = new System.Drawing.Size(259, 20);
			this.textBoxNickname.TabIndex = 10;
			this.textBoxNickname.Text = "NICKNAME";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 34);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "oAuth Key";
			// 
			// buttonDisconnect
			// 
			this.buttonDisconnect.Location = new System.Drawing.Point(253, 110);
			this.buttonDisconnect.Name = "buttonDisconnect";
			this.buttonDisconnect.Size = new System.Drawing.Size(77, 25);
			this.buttonDisconnect.TabIndex = 2;
			this.buttonDisconnect.Text = "Disconnect";
			this.buttonDisconnect.UseVisualStyleBackColor = true;
			this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Nickname";
			// 
			// textBoxOAuth
			// 
			this.textBoxOAuth.Location = new System.Drawing.Point(65, 31);
			this.textBoxOAuth.Name = "textBoxOAuth";
			this.textBoxOAuth.Size = new System.Drawing.Size(259, 20);
			this.textBoxOAuth.TabIndex = 3;
			this.textBoxOAuth.Text = "OAUTH_KEY";
			// 
			// textBoxChannel
			// 
			this.textBoxChannel.Location = new System.Drawing.Point(65, 57);
			this.textBoxChannel.Name = "textBoxChannel";
			this.textBoxChannel.Size = new System.Drawing.Size(259, 20);
			this.textBoxChannel.TabIndex = 4;
			this.textBoxChannel.Text = "CHANNEL";
			// 
			// Debugbox
			// 
			this.Debugbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Debugbox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Debugbox.Location = new System.Drawing.Point(0, 0);
			this.Debugbox.Multiline = true;
			this.Debugbox.Name = "Debugbox";
			this.Debugbox.ReadOnly = true;
			this.Debugbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.Debugbox.Size = new System.Drawing.Size(336, 406);
			this.Debugbox.TabIndex = 11;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.tableLayoutPanel3);
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(342, 555);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Maoubot Config";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 0, 1);
			this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 2;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(336, 549);
			this.tableLayoutPanel3.TabIndex = 3;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.textBoxSubMessageResub, 1, 2);
			this.tableLayoutPanel2.Controls.Add(this.label5, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.label4, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.checkBoxEnableSubMessage, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.textBoxSubMessageNew, 1, 1);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 23);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 4;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(336, 526);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// textBoxSubMessageResub
			// 
			this.textBoxSubMessageResub.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxSubMessageResub.Location = new System.Drawing.Point(102, 52);
			this.textBoxSubMessageResub.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.textBoxSubMessageResub.Name = "textBoxSubMessageResub";
			this.textBoxSubMessageResub.Size = new System.Drawing.Size(233, 20);
			this.textBoxSubMessageResub.TabIndex = 4;
			this.textBoxSubMessageResub.Text = "**RESUB_MESSAGE**";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label5.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(1, 52);
			this.label5.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 20);
			this.label5.TabIndex = 1;
			this.label5.Text = "Resub Message";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label4.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(1, 28);
			this.label4.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 20);
			this.label4.TabIndex = 0;
			this.label4.Text = "Sub Message";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// checkBoxEnableSubMessage
			// 
			this.checkBoxEnableSubMessage.AutoSize = true;
			this.checkBoxEnableSubMessage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.checkBoxEnableSubMessage.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxEnableSubMessage.Location = new System.Drawing.Point(105, 4);
			this.checkBoxEnableSubMessage.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
			this.checkBoxEnableSubMessage.Name = "checkBoxEnableSubMessage";
			this.checkBoxEnableSubMessage.Size = new System.Drawing.Size(230, 20);
			this.checkBoxEnableSubMessage.TabIndex = 2;
			this.checkBoxEnableSubMessage.Text = "Enable Sub/Resub Messages";
			this.checkBoxEnableSubMessage.UseVisualStyleBackColor = true;
			// 
			// textBoxSubMessageNew
			// 
			this.textBoxSubMessageNew.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxSubMessageNew.Location = new System.Drawing.Point(102, 28);
			this.textBoxSubMessageNew.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.textBoxSubMessageNew.Name = "textBoxSubMessageNew";
			this.textBoxSubMessageNew.Size = new System.Drawing.Size(233, 20);
			this.textBoxSubMessageNew.TabIndex = 3;
			this.textBoxSubMessageNew.Text = "**SUB_MESSAGE**";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.textBoxMessage);
			this.panel1.Controls.Add(this.buttonSendMessage);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(336, 20);
			this.panel1.TabIndex = 2;
			// 
			// textBoxMessage
			// 
			this.textBoxMessage.Dock = System.Windows.Forms.DockStyle.Left;
			this.textBoxMessage.Location = new System.Drawing.Point(0, 0);
			this.textBoxMessage.Name = "textBoxMessage";
			this.textBoxMessage.Size = new System.Drawing.Size(272, 20);
			this.textBoxMessage.TabIndex = 0;
			this.textBoxMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxMessage_KeyDown);
			// 
			// buttonSendMessage
			// 
			this.buttonSendMessage.Dock = System.Windows.Forms.DockStyle.Right;
			this.buttonSendMessage.Location = new System.Drawing.Point(284, 0);
			this.buttonSendMessage.Name = "buttonSendMessage";
			this.buttonSendMessage.Size = new System.Drawing.Size(52, 20);
			this.buttonSendMessage.TabIndex = 1;
			this.buttonSendMessage.Text = "Send";
			this.buttonSendMessage.UseVisualStyleBackColor = true;
			this.buttonSendMessage.Click += new System.EventHandler(this.buttonSendMessage_Click);
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.tableLayoutPanel4);
			this.tabPage3.Location = new System.Drawing.Point(4, 25);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(342, 555);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Commands";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.ColumnCount = 1;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.Controls.Add(this.checkBoxEnableCommands, 0, 0);
			this.tableLayoutPanel4.Controls.Add(this.tabControl2, 0, 1);
			this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 2;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(342, 555);
			this.tableLayoutPanel4.TabIndex = 1;
			// 
			// checkBoxEnableCommands
			// 
			this.checkBoxEnableCommands.AutoSize = true;
			this.checkBoxEnableCommands.Dock = System.Windows.Forms.DockStyle.Fill;
			this.checkBoxEnableCommands.Location = new System.Drawing.Point(3, 3);
			this.checkBoxEnableCommands.Name = "checkBoxEnableCommands";
			this.checkBoxEnableCommands.Size = new System.Drawing.Size(336, 19);
			this.checkBoxEnableCommands.TabIndex = 0;
			this.checkBoxEnableCommands.Text = "Enable commands";
			this.checkBoxEnableCommands.UseVisualStyleBackColor = true;
			// 
			// tabControl2
			// 
			this.tabControl2.Controls.Add(this.tabPage5);
			this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl2.Location = new System.Drawing.Point(0, 28);
			this.tabControl2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(342, 527);
			this.tabControl2.TabIndex = 1;
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.buttonTextCommandAdd);
			this.tabPage5.Controls.Add(this.buttonTextCommandDelete);
			this.tabPage5.Controls.Add(this.buttonTextCommandEdit);
			this.tabPage5.Controls.Add(this.comboBoxTextCommands);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage5.Size = new System.Drawing.Size(334, 501);
			this.tabPage5.TabIndex = 0;
			this.tabPage5.Text = "TextCommands";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// buttonTextCommandAdd
			// 
			this.buttonTextCommandAdd.Location = new System.Drawing.Point(172, 35);
			this.buttonTextCommandAdd.Name = "buttonTextCommandAdd";
			this.buttonTextCommandAdd.Size = new System.Drawing.Size(156, 23);
			this.buttonTextCommandAdd.TabIndex = 3;
			this.buttonTextCommandAdd.Text = "Add new command";
			this.buttonTextCommandAdd.UseVisualStyleBackColor = true;
			this.buttonTextCommandAdd.Click += new System.EventHandler(this.buttonTextCommandAdd_Click);
			// 
			// buttonTextCommandDelete
			// 
			this.buttonTextCommandDelete.Location = new System.Drawing.Point(172, 6);
			this.buttonTextCommandDelete.Name = "buttonTextCommandDelete";
			this.buttonTextCommandDelete.Size = new System.Drawing.Size(75, 23);
			this.buttonTextCommandDelete.TabIndex = 2;
			this.buttonTextCommandDelete.Text = "Delete";
			this.buttonTextCommandDelete.UseVisualStyleBackColor = true;
			this.buttonTextCommandDelete.Click += new System.EventHandler(this.buttonTextCommandDelete_Click);
			// 
			// buttonTextCommandEdit
			// 
			this.buttonTextCommandEdit.Location = new System.Drawing.Point(253, 6);
			this.buttonTextCommandEdit.Name = "buttonTextCommandEdit";
			this.buttonTextCommandEdit.Size = new System.Drawing.Size(75, 23);
			this.buttonTextCommandEdit.TabIndex = 1;
			this.buttonTextCommandEdit.Text = "Edit";
			this.buttonTextCommandEdit.UseVisualStyleBackColor = true;
			this.buttonTextCommandEdit.Click += new System.EventHandler(this.buttonTextCommandEdit_Click);
			// 
			// comboBoxTextCommands
			// 
			this.comboBoxTextCommands.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxTextCommands.FormattingEnabled = true;
			this.comboBoxTextCommands.Items.AddRange(new object[] {
            "NO_COMMANDS"});
			this.comboBoxTextCommands.Location = new System.Drawing.Point(6, 6);
			this.comboBoxTextCommands.Name = "comboBoxTextCommands";
			this.comboBoxTextCommands.Size = new System.Drawing.Size(160, 21);
			this.comboBoxTextCommands.TabIndex = 0;
			// 
			// tabPage6
			// 
			this.tabPage6.Controls.Add(this.buttonTwitchEmoteResort);
			this.tabPage6.Controls.Add(this.labelTwitchEmoteSearch);
			this.tabPage6.Controls.Add(this.textBoxTwitchEmoteSearch);
			this.tabPage6.Controls.Add(this.label6);
			this.tabPage6.Location = new System.Drawing.Point(4, 25);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage6.Size = new System.Drawing.Size(342, 555);
			this.tabPage6.TabIndex = 4;
			this.tabPage6.Text = "Emote";
			this.tabPage6.UseVisualStyleBackColor = true;
			// 
			// labelTwitchEmoteSearch
			// 
			this.labelTwitchEmoteSearch.AutoSize = true;
			this.labelTwitchEmoteSearch.Location = new System.Drawing.Point(6, 42);
			this.labelTwitchEmoteSearch.Name = "labelTwitchEmoteSearch";
			this.labelTwitchEmoteSearch.Size = new System.Drawing.Size(69, 13);
			this.labelTwitchEmoteSearch.TabIndex = 2;
			this.labelTwitchEmoteSearch.Text = "Emote Data: ";
			// 
			// textBoxTwitchEmoteSearch
			// 
			this.textBoxTwitchEmoteSearch.Location = new System.Drawing.Point(9, 19);
			this.textBoxTwitchEmoteSearch.Name = "textBoxTwitchEmoteSearch";
			this.textBoxTwitchEmoteSearch.Size = new System.Drawing.Size(325, 20);
			this.textBoxTwitchEmoteSearch.TabIndex = 1;
			this.textBoxTwitchEmoteSearch.TextChanged += new System.EventHandler(this.textBoxTwitchEmoteSearch_Changed);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 3);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(74, 13);
			this.label6.TabIndex = 0;
			this.label6.Text = "Emote Search";
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.buttonResetStats);
			this.tabPage4.Controls.Add(this.labelCheerTest);
			this.tabPage4.Controls.Add(this.buttonRandomColor);
			this.tabPage4.Location = new System.Drawing.Point(4, 25);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(342, 555);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Fun";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// buttonResetStats
			// 
			this.buttonResetStats.Location = new System.Drawing.Point(6, 529);
			this.buttonResetStats.Name = "buttonResetStats";
			this.buttonResetStats.Size = new System.Drawing.Size(75, 23);
			this.buttonResetStats.TabIndex = 3;
			this.buttonResetStats.Text = "Reset Stats";
			this.buttonResetStats.UseVisualStyleBackColor = true;
			this.buttonResetStats.Click += new System.EventHandler(this.buttonResetStats_Click);
			// 
			// labelCheerTest
			// 
			this.labelCheerTest.AutoSize = true;
			this.labelCheerTest.Location = new System.Drawing.Point(3, 10);
			this.labelCheerTest.Name = "labelCheerTest";
			this.labelCheerTest.Size = new System.Drawing.Size(35, 13);
			this.labelCheerTest.TabIndex = 2;
			this.labelCheerTest.Text = "label6";
			// 
			// buttonRandomColor
			// 
			this.buttonRandomColor.Location = new System.Drawing.Point(87, 529);
			this.buttonRandomColor.Name = "buttonRandomColor";
			this.buttonRandomColor.Size = new System.Drawing.Size(75, 23);
			this.buttonRandomColor.TabIndex = 0;
			this.buttonRandomColor.Text = "color";
			this.buttonRandomColor.UseVisualStyleBackColor = true;
			this.buttonRandomColor.Click += new System.EventHandler(this.buttonRandomColor_Click);
			// 
			// buttonTwitchEmoteResort
			// 
			this.buttonTwitchEmoteResort.Location = new System.Drawing.Point(9, 68);
			this.buttonTwitchEmoteResort.Name = "buttonTwitchEmoteResort";
			this.buttonTwitchEmoteResort.Size = new System.Drawing.Size(77, 23);
			this.buttonTwitchEmoteResort.TabIndex = 15;
			this.buttonTwitchEmoteResort.Text = "Resort";
			this.buttonTwitchEmoteResort.UseVisualStyleBackColor = true;
			this.buttonTwitchEmoteResort.Click += new System.EventHandler(this.buttonTwitchEmoteResort_Click);
			// 
			// Maoubot
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 612);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Maoubot";
			this.Text = "Maoubot-GUI";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			this.tabControl2.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.tabPage6.ResumeLayout(false);
			this.tabPage6.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.tabPage4.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TextBox Chatbox;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Button buttonConnect;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxNickname;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buttonDisconnect;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxOAuth;
		private System.Windows.Forms.TextBox textBoxChannel;
		private System.Windows.Forms.TextBox Debugbox;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Button buttonSendMessage;
		private System.Windows.Forms.TextBox textBoxMessage;
		private System.Windows.Forms.Button buttonPart;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxSubMessageResub;
		private System.Windows.Forms.CheckBox checkBoxEnableSubMessage;
		private System.Windows.Forms.TextBox textBoxSubMessageNew;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.CheckBox checkBoxEnableCommands;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.Button buttonRandomColor;
		private System.Windows.Forms.TabControl tabControl2;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.ComboBox comboBoxTextCommands;
		private System.Windows.Forms.Button buttonTextCommandDelete;
		private System.Windows.Forms.Button buttonTextCommandEdit;
		private System.Windows.Forms.Button buttonTextCommandAdd;
		private System.Windows.Forms.Label labelCheerTest;
		private System.Windows.Forms.Button buttonResetStats;
		private System.Windows.Forms.Button buttonAccountsDelete;
		private System.Windows.Forms.Button buttonAccountsLoad;
		private System.Windows.Forms.ComboBox comboBoxAccounts;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.TextBox textBoxTwitchEmoteSearch;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label labelTwitchEmoteSearch;
		private System.Windows.Forms.Button buttonTwitchEmoteResort;
	}
}

