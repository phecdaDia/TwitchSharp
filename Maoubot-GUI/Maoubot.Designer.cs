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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
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
			this.buttonConfigLoad = new System.Windows.Forms.Button();
			this.textBoxChannel = new System.Windows.Forms.TextBox();
			this.buttonConfigSave = new System.Windows.Forms.Button();
			this.Debugbox = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.buttonMaouBotConfigLoad = new System.Windows.Forms.Button();
			this.buttonMaouBotConfigSave = new System.Windows.Forms.Button();
			this.buttonQuotesConfigLoad = new System.Windows.Forms.Button();
			this.buttonQuotesConfigSave = new System.Windows.Forms.Button();
			this.buttonTwitchConfigLoad = new System.Windows.Forms.Button();
			this.buttonTwitchConfigSave = new System.Windows.Forms.Button();
			this.buttonSendMessage = new System.Windows.Forms.Button();
			this.textBoxMessage = new System.Windows.Forms.TextBox();
			this.Chatbox = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.checkBoxEnableSubMessage = new System.Windows.Forms.CheckBox();
			this.textBoxSubMessageNew = new System.Windows.Forms.TextBox();
			this.textBoxSubMessageResub = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
			this.tableLayoutPanel1.Controls.Add(this.tabControl1, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.Chatbox, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 612F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 612);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(537, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(344, 606);
			this.tabControl1.TabIndex = 2;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.splitContainer1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(336, 580);
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
			this.splitContainer1.Panel1.Controls.Add(this.buttonConfigLoad);
			this.splitContainer1.Panel1.Controls.Add(this.textBoxChannel);
			this.splitContainer1.Panel1.Controls.Add(this.buttonConfigSave);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.Debugbox);
			this.splitContainer1.Size = new System.Drawing.Size(330, 574);
			this.splitContainer1.SplitterDistance = 170;
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
			this.comboBoxAccounts.FormattingEnabled = true;
			this.comboBoxAccounts.Location = new System.Drawing.Point(9, 83);
			this.comboBoxAccounts.Name = "comboBoxAccounts";
			this.comboBoxAccounts.Size = new System.Drawing.Size(155, 21);
			this.comboBoxAccounts.TabIndex = 12;
			this.comboBoxAccounts.Text = "NO ACCOUNTS";
			// 
			// buttonPart
			// 
			this.buttonPart.Location = new System.Drawing.Point(172, 141);
			this.buttonPart.Name = "buttonPart";
			this.buttonPart.Size = new System.Drawing.Size(77, 25);
			this.buttonPart.TabIndex = 11;
			this.buttonPart.Text = "Part";
			this.buttonPart.UseVisualStyleBackColor = true;
			this.buttonPart.Click += new System.EventHandler(this.buttonPart_Click);
			// 
			// buttonConnect
			// 
			this.buttonConnect.Location = new System.Drawing.Point(9, 141);
			this.buttonConnect.Name = "buttonConnect";
			this.buttonConnect.Size = new System.Drawing.Size(155, 25);
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
			this.buttonDisconnect.Location = new System.Drawing.Point(255, 141);
			this.buttonDisconnect.Name = "buttonDisconnect";
			this.buttonDisconnect.Size = new System.Drawing.Size(72, 25);
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
			// buttonConfigLoad
			// 
			this.buttonConfigLoad.Location = new System.Drawing.Point(172, 110);
			this.buttonConfigLoad.Name = "buttonConfigLoad";
			this.buttonConfigLoad.Size = new System.Drawing.Size(155, 25);
			this.buttonConfigLoad.TabIndex = 6;
			this.buttonConfigLoad.Text = "Load Config";
			this.buttonConfigLoad.UseVisualStyleBackColor = true;
			this.buttonConfigLoad.Click += new System.EventHandler(this.buttonConfigLoad_Click);
			// 
			// textBoxChannel
			// 
			this.textBoxChannel.Location = new System.Drawing.Point(65, 57);
			this.textBoxChannel.Name = "textBoxChannel";
			this.textBoxChannel.Size = new System.Drawing.Size(259, 20);
			this.textBoxChannel.TabIndex = 4;
			this.textBoxChannel.Text = "CHANNEL";
			// 
			// buttonConfigSave
			// 
			this.buttonConfigSave.Location = new System.Drawing.Point(9, 110);
			this.buttonConfigSave.Name = "buttonConfigSave";
			this.buttonConfigSave.Size = new System.Drawing.Size(155, 25);
			this.buttonConfigSave.TabIndex = 5;
			this.buttonConfigSave.Text = "Save Config";
			this.buttonConfigSave.UseVisualStyleBackColor = true;
			this.buttonConfigSave.Click += new System.EventHandler(this.buttonConfigSave_Click);
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
			this.Debugbox.Size = new System.Drawing.Size(330, 400);
			this.Debugbox.TabIndex = 11;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.panel1);
			this.tabPage2.Controls.Add(this.buttonMaouBotConfigLoad);
			this.tabPage2.Controls.Add(this.buttonMaouBotConfigSave);
			this.tabPage2.Controls.Add(this.buttonQuotesConfigLoad);
			this.tabPage2.Controls.Add(this.buttonQuotesConfigSave);
			this.tabPage2.Controls.Add(this.buttonTwitchConfigLoad);
			this.tabPage2.Controls.Add(this.buttonTwitchConfigSave);
			this.tabPage2.Controls.Add(this.buttonSendMessage);
			this.tabPage2.Controls.Add(this.textBoxMessage);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(336, 580);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Maoubot Config";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// buttonMaouBotConfigLoad
			// 
			this.buttonMaouBotConfigLoad.Location = new System.Drawing.Point(170, 91);
			this.buttonMaouBotConfigLoad.Name = "buttonMaouBotConfigLoad";
			this.buttonMaouBotConfigLoad.Size = new System.Drawing.Size(160, 23);
			this.buttonMaouBotConfigLoad.TabIndex = 7;
			this.buttonMaouBotConfigLoad.Text = "Load MaoubotConfig";
			this.buttonMaouBotConfigLoad.UseVisualStyleBackColor = true;
			this.buttonMaouBotConfigLoad.Click += new System.EventHandler(this.buttonMaouBotConfigLoad_Click);
			// 
			// buttonMaouBotConfigSave
			// 
			this.buttonMaouBotConfigSave.Location = new System.Drawing.Point(7, 91);
			this.buttonMaouBotConfigSave.Name = "buttonMaouBotConfigSave";
			this.buttonMaouBotConfigSave.Size = new System.Drawing.Size(160, 23);
			this.buttonMaouBotConfigSave.TabIndex = 6;
			this.buttonMaouBotConfigSave.Text = "Save MaoubotConfig";
			this.buttonMaouBotConfigSave.UseVisualStyleBackColor = true;
			this.buttonMaouBotConfigSave.Click += new System.EventHandler(this.buttonMaouBotConfigSave_Click);
			// 
			// buttonQuotesConfigLoad
			// 
			this.buttonQuotesConfigLoad.Location = new System.Drawing.Point(170, 62);
			this.buttonQuotesConfigLoad.Name = "buttonQuotesConfigLoad";
			this.buttonQuotesConfigLoad.Size = new System.Drawing.Size(160, 23);
			this.buttonQuotesConfigLoad.TabIndex = 5;
			this.buttonQuotesConfigLoad.Text = "Load QuotesConfig";
			this.buttonQuotesConfigLoad.UseVisualStyleBackColor = true;
			this.buttonQuotesConfigLoad.Click += new System.EventHandler(this.buttonQuotesConfigLoad_Click);
			// 
			// buttonQuotesConfigSave
			// 
			this.buttonQuotesConfigSave.Location = new System.Drawing.Point(7, 62);
			this.buttonQuotesConfigSave.Name = "buttonQuotesConfigSave";
			this.buttonQuotesConfigSave.Size = new System.Drawing.Size(160, 23);
			this.buttonQuotesConfigSave.TabIndex = 4;
			this.buttonQuotesConfigSave.Text = "Save QuotesConfig";
			this.buttonQuotesConfigSave.UseVisualStyleBackColor = true;
			this.buttonQuotesConfigSave.Click += new System.EventHandler(this.buttonQuotesConfigSave_Click);
			// 
			// buttonTwitchConfigLoad
			// 
			this.buttonTwitchConfigLoad.Location = new System.Drawing.Point(170, 33);
			this.buttonTwitchConfigLoad.Name = "buttonTwitchConfigLoad";
			this.buttonTwitchConfigLoad.Size = new System.Drawing.Size(160, 23);
			this.buttonTwitchConfigLoad.TabIndex = 3;
			this.buttonTwitchConfigLoad.Text = "Load TwitchConfig";
			this.buttonTwitchConfigLoad.UseVisualStyleBackColor = true;
			this.buttonTwitchConfigLoad.Click += new System.EventHandler(this.buttonTwitchConfigLoad_Click);
			// 
			// buttonTwitchConfigSave
			// 
			this.buttonTwitchConfigSave.Location = new System.Drawing.Point(7, 33);
			this.buttonTwitchConfigSave.Name = "buttonTwitchConfigSave";
			this.buttonTwitchConfigSave.Size = new System.Drawing.Size(160, 23);
			this.buttonTwitchConfigSave.TabIndex = 2;
			this.buttonTwitchConfigSave.Text = "Save TwitchConfig";
			this.buttonTwitchConfigSave.UseVisualStyleBackColor = true;
			this.buttonTwitchConfigSave.Click += new System.EventHandler(this.buttonTwitchConfigSave_Click);
			// 
			// buttonSendMessage
			// 
			this.buttonSendMessage.Location = new System.Drawing.Point(278, 7);
			this.buttonSendMessage.Name = "buttonSendMessage";
			this.buttonSendMessage.Size = new System.Drawing.Size(52, 23);
			this.buttonSendMessage.TabIndex = 1;
			this.buttonSendMessage.Text = "Send";
			this.buttonSendMessage.UseVisualStyleBackColor = true;
			this.buttonSendMessage.Click += new System.EventHandler(this.buttonSendMessage_Click);
			// 
			// textBoxMessage
			// 
			this.textBoxMessage.Location = new System.Drawing.Point(7, 7);
			this.textBoxMessage.Name = "textBoxMessage";
			this.textBoxMessage.Size = new System.Drawing.Size(265, 20);
			this.textBoxMessage.TabIndex = 0;
			this.textBoxMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxMessage_KeyDown);
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
			// panel1
			// 
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.tableLayoutPanel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(3, 117);
			this.panel1.Margin = new System.Windows.Forms.Padding(0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(330, 460);
			this.panel1.TabIndex = 8;
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
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 4;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(330, 437);
			this.tableLayoutPanel2.TabIndex = 0;
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
			// checkBoxEnableSubMessage
			// 
			this.checkBoxEnableSubMessage.AutoSize = true;
			this.checkBoxEnableSubMessage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.checkBoxEnableSubMessage.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBoxEnableSubMessage.Location = new System.Drawing.Point(105, 4);
			this.checkBoxEnableSubMessage.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
			this.checkBoxEnableSubMessage.Name = "checkBoxEnableSubMessage";
			this.checkBoxEnableSubMessage.Size = new System.Drawing.Size(224, 20);
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
			this.textBoxSubMessageNew.Size = new System.Drawing.Size(227, 20);
			this.textBoxSubMessageNew.TabIndex = 3;
			this.textBoxSubMessageNew.Text = "**SUB_MESSAGE**";
			// 
			// textBoxSubMessageResub
			// 
			this.textBoxSubMessageResub.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxSubMessageResub.Location = new System.Drawing.Point(102, 52);
			this.textBoxSubMessageResub.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.textBoxSubMessageResub.Name = "textBoxSubMessageResub";
			this.textBoxSubMessageResub.Size = new System.Drawing.Size(227, 20);
			this.textBoxSubMessageResub.TabIndex = 4;
			this.textBoxSubMessageResub.Text = "**RESUB_MESSAGE**";
			// 
			// button1
			// 
			this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.button1.Location = new System.Drawing.Point(0, 437);
			this.button1.Margin = new System.Windows.Forms.Padding(0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(330, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Apply / Save";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// Maoubot
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 612);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "Maoubot";
			this.Text = "Maoubot-GUI";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
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
		private System.Windows.Forms.Button buttonConfigLoad;
		private System.Windows.Forms.TextBox textBoxChannel;
		private System.Windows.Forms.Button buttonConfigSave;
		private System.Windows.Forms.TextBox Debugbox;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Button buttonSendMessage;
		private System.Windows.Forms.TextBox textBoxMessage;
		private System.Windows.Forms.Button buttonPart;
		private System.Windows.Forms.Button buttonAccountsDelete;
		private System.Windows.Forms.Button buttonAccountsLoad;
		private System.Windows.Forms.ComboBox comboBoxAccounts;
		private System.Windows.Forms.Button buttonMaouBotConfigLoad;
		private System.Windows.Forms.Button buttonMaouBotConfigSave;
		private System.Windows.Forms.Button buttonQuotesConfigLoad;
		private System.Windows.Forms.Button buttonQuotesConfigSave;
		private System.Windows.Forms.Button buttonTwitchConfigLoad;
		private System.Windows.Forms.Button buttonTwitchConfigSave;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxSubMessageResub;
		private System.Windows.Forms.CheckBox checkBoxEnableSubMessage;
		private System.Windows.Forms.TextBox textBoxSubMessageNew;
		private System.Windows.Forms.Button button1;
	}
}

