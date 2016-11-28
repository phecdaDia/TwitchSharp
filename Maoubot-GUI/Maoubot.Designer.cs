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
			this.Chatbox = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.Debugbox = new System.Windows.Forms.TextBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.buttonConfigLoad = new System.Windows.Forms.Button();
			this.buttonConfigSave = new System.Windows.Forms.Button();
			this.textBoxChannel = new System.Windows.Forms.TextBox();
			this.textBoxOAuth = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.buttonConnect = new System.Windows.Forms.Button();
			this.textBoxNickname = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
			this.tableLayoutPanel1.Controls.Add(this.Chatbox, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
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
			this.Chatbox.Location = new System.Drawing.Point(3, 3);
			this.Chatbox.Multiline = true;
			this.Chatbox.Name = "Chatbox";
			this.Chatbox.ReadOnly = true;
			this.Chatbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.Chatbox.Size = new System.Drawing.Size(528, 606);
			this.Chatbox.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel2.Controls.Add(this.Debugbox, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.tabControl1, 0, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(537, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.37294F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.62706F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(344, 606);
			this.tableLayoutPanel2.TabIndex = 1;
			// 
			// Debugbox
			// 
			this.Debugbox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Debugbox.Location = new System.Drawing.Point(3, 181);
			this.Debugbox.Multiline = true;
			this.Debugbox.Name = "Debugbox";
			this.Debugbox.ReadOnly = true;
			this.Debugbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.Debugbox.Size = new System.Drawing.Size(338, 422);
			this.Debugbox.TabIndex = 0;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(3, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(338, 172);
			this.tabControl1.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.buttonConfigLoad);
			this.tabPage1.Controls.Add(this.buttonConfigSave);
			this.tabPage1.Controls.Add(this.textBoxChannel);
			this.tabPage1.Controls.Add(this.textBoxOAuth);
			this.tabPage1.Controls.Add(this.button2);
			this.tabPage1.Controls.Add(this.buttonConnect);
			this.tabPage1.Controls.Add(this.textBoxNickname);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(330, 146);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Login/Connect";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// buttonConfigLoad
			// 
			this.buttonConfigLoad.Location = new System.Drawing.Point(169, 84);
			this.buttonConfigLoad.Name = "buttonConfigLoad";
			this.buttonConfigLoad.Size = new System.Drawing.Size(155, 25);
			this.buttonConfigLoad.TabIndex = 6;
			this.buttonConfigLoad.Text = "Load Config";
			this.buttonConfigLoad.UseVisualStyleBackColor = true;
			// 
			// buttonConfigSave
			// 
			this.buttonConfigSave.Location = new System.Drawing.Point(6, 84);
			this.buttonConfigSave.Name = "buttonConfigSave";
			this.buttonConfigSave.Size = new System.Drawing.Size(155, 25);
			this.buttonConfigSave.TabIndex = 5;
			this.buttonConfigSave.Text = "Save Config";
			this.buttonConfigSave.UseVisualStyleBackColor = true;
			// 
			// textBoxChannel
			// 
			this.textBoxChannel.Location = new System.Drawing.Point(65, 58);
			this.textBoxChannel.Name = "textBoxChannel";
			this.textBoxChannel.Size = new System.Drawing.Size(259, 20);
			this.textBoxChannel.TabIndex = 4;
			this.textBoxChannel.Text = "CHANNEL";
			// 
			// textBoxOAuth
			// 
			this.textBoxOAuth.Location = new System.Drawing.Point(65, 32);
			this.textBoxOAuth.Name = "textBoxOAuth";
			this.textBoxOAuth.Size = new System.Drawing.Size(259, 20);
			this.textBoxOAuth.TabIndex = 3;
			this.textBoxOAuth.Text = "OAUTH_KEY";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(169, 115);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(155, 25);
			this.button2.TabIndex = 2;
			this.button2.Text = "Disconnect/Quit";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// buttonConnect
			// 
			this.buttonConnect.Location = new System.Drawing.Point(6, 115);
			this.buttonConnect.Name = "buttonConnect";
			this.buttonConnect.Size = new System.Drawing.Size(155, 25);
			this.buttonConnect.TabIndex = 1;
			this.buttonConnect.Text = "Connect";
			this.buttonConnect.UseVisualStyleBackColor = true;
			this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
			// 
			// textBoxNickname
			// 
			this.textBoxNickname.Location = new System.Drawing.Point(65, 6);
			this.textBoxNickname.Name = "textBoxNickname";
			this.textBoxNickname.Size = new System.Drawing.Size(259, 20);
			this.textBoxNickname.TabIndex = 0;
			this.textBoxNickname.Text = "NICKNAME";
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(330, 146);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Nickname";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "oAuth Key";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 61);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(46, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Channel";
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
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TextBox Chatbox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TextBox Debugbox;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox textBoxChannel;
		private System.Windows.Forms.TextBox textBoxOAuth;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button buttonConnect;
		private System.Windows.Forms.TextBox textBoxNickname;
		private System.Windows.Forms.Button buttonConfigLoad;
		private System.Windows.Forms.Button buttonConfigSave;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}

