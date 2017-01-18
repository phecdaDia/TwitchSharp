namespace Maoubot_GUI.Window
{
	partial class DebugForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebugForm));
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.panelDebug1 = new System.Windows.Forms.Panel();
			this.panelDebug2 = new System.Windows.Forms.Panel();
			this.panelDebug3 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tableLayoutPanel.SuspendLayout();
			this.panelDebug1.SuspendLayout();
			this.panelDebug2.SuspendLayout();
			this.panelDebug3.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
			this.tableLayoutPanel.ColumnCount = 5;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel.Controls.Add(this.panelDebug3, 3, 0);
			this.tableLayoutPanel.Controls.Add(this.panelDebug2, 2, 0);
			this.tableLayoutPanel.Controls.Add(this.panelDebug1, 1, 0);
			this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 1;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(464, 262);
			this.tableLayoutPanel.TabIndex = 0;
			// 
			// panelDebug1
			// 
			this.panelDebug1.Controls.Add(this.label1);
			this.panelDebug1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelDebug1.Location = new System.Drawing.Point(53, 5);
			this.panelDebug1.Name = "panelDebug1";
			this.panelDebug1.Size = new System.Drawing.Size(114, 252);
			this.panelDebug1.TabIndex = 0;
			// 
			// panelDebug2
			// 
			this.panelDebug2.Controls.Add(this.label2);
			this.panelDebug2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelDebug2.Location = new System.Drawing.Point(175, 5);
			this.panelDebug2.Name = "panelDebug2";
			this.panelDebug2.Size = new System.Drawing.Size(114, 252);
			this.panelDebug2.TabIndex = 2;
			// 
			// panelDebug3
			// 
			this.panelDebug3.Controls.Add(this.label3);
			this.panelDebug3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelDebug3.Location = new System.Drawing.Point(297, 5);
			this.panelDebug3.Name = "panelDebug3";
			this.panelDebug3.Size = new System.Drawing.Size(114, 252);
			this.panelDebug3.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(114, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "foo";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Top;
			this.label2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(114, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "foo";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Top;
			this.label3.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(0, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(114, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "foo";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// DebugForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(464, 262);
			this.Controls.Add(this.tableLayoutPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "DebugForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "DebugForm";
			this.Shown += new System.EventHandler(this.DebugForm_Shown);
			this.tableLayoutPanel.ResumeLayout(false);
			this.panelDebug1.ResumeLayout(false);
			this.panelDebug2.ResumeLayout(false);
			this.panelDebug3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.Panel panelDebug3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Panel panelDebug2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panelDebug1;
		private System.Windows.Forms.Label label1;
	}
}