using Maoubot_GUI.Component;
using Maoubot_GUI.Component.Commands;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwitchSharp.Components;

namespace Maoubot_GUI.Dialog
{
	public class TextCommandDialog : AbstractDialog<TextCommand>
	{
		private TextBox textboxCommand;
		private TextBox textboxText;

		private ComboBox comboboxPermission;

		private NumericUpDown nudTimeout;

		private Permission[] Permissions;

		private static readonly String TEXT_TITLE = @"Textcommand Dialog";
		private static readonly int WINDOW_WIDTH = 500;
		private static readonly int WINDOW_HEIGHT = 700;


		public TextCommandDialog()
			: base(TEXT_TITLE, WINDOW_WIDTH, WINDOW_HEIGHT)
		{

		}

		public TextCommandDialog(TextCommand tc)
			: base(TEXT_TITLE, WINDOW_WIDTH, WINDOW_HEIGHT)
		{

			this.textboxCommand.Text = tc.Command;
			this.textboxText.Text = tc.Output;

			this.comboboxPermission.SelectedIndex = Enum.GetValues(typeof(Permission)).Cast<Permission>().ToList().IndexOf(tc.Permission);
			this.nudTimeout.Value = tc.Timeout;

			this.textboxCommand.Enabled = false;
		}

		protected override void CreateComponents()
		{
			Permissions = Enum.GetValues(typeof(Permission)).Cast<Permission>().ToArray();

			TableLayoutPanel tlp1 = new TableLayoutPanel()
			{
				Dock = DockStyle.Fill,
				RowCount = 5,
				ColumnCount = 1,
			};

			tlp1.RowStyles.Clear();
			tlp1.ColumnStyles.Clear();

			tlp1.RowStyles.Add(new RowStyle(SizeType.Absolute, 26));
			tlp1.RowStyles.Add(new RowStyle(SizeType.Absolute, 26));
			tlp1.RowStyles.Add(new RowStyle(SizeType.Absolute, 26));
			tlp1.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
			tlp1.RowStyles.Add(new RowStyle(SizeType.Absolute, 62));

			tlp1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent));

			tlp1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
			

			// TLP1 R0 C0
			tlp1.Controls.Add(new Label()
			{
				Text = @"Command",
				Font = new Font("Consolas", 10),

				TextAlign = ContentAlignment.BottomLeft,
			}, 0, 0);

			// TLP1 R1 C0
			textboxCommand = new TextBox()
			{
				Dock = DockStyle.Fill,
				Font = new Font("Consolas", 10),
			};

			tlp1.Controls.Add(textboxCommand, 0, 1);

			// TLP1 R2 C0
			tlp1.Controls.Add(new Label()
			{
				Text = @"Output text",
				Font = new Font("Consolas", 10),

				TextAlign = ContentAlignment.BottomLeft,
			}, 0, 2);

			// TLP1 R3 C0
			textboxText = new TextBox()
			{
				Multiline = true,

				Dock = DockStyle.Fill,
				Font = new Font("Consolas", 10),
			};

			tlp1.Controls.Add(textboxText, 0, 3);

			// TLP1 R4 C0
			TableLayoutPanel tlp2 = new TableLayoutPanel()
			{
				Dock = DockStyle.Fill,
				RowCount = 2,
				ColumnCount = 2,
			};

			tlp2.RowStyles.Clear();
			tlp2.ColumnStyles.Clear();


			tlp2.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
			tlp2.RowStyles.Add(new RowStyle(SizeType.Percent, 50));

			tlp2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
			tlp2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));

			tlp2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

			tlp1.Controls.Add(tlp2, 0, 4);

			this.comboboxPermission = new ComboBox()
			{
				Dock = DockStyle.Fill,
				DropDownStyle = ComboBoxStyle.DropDownList,
			};
			foreach (Permission p in Permissions)
			{
				comboboxPermission.Items.Add(p.ToString());

			}

			comboboxPermission.SelectedIndex = 0;

			tlp2.Controls.Add(comboboxPermission, 0, 0);

			this.nudTimeout = new NumericUpDown()
			{
				Dock = DockStyle.Fill,

				Minimum = 0,
			};
			tlp2.Controls.Add(nudTimeout, 1, 0);

			CloseButton.Dock = DockStyle.Fill;
			CloseButton.Text = "Finish";

			tlp2.Controls.Add(CloseButton, 1, 1);

			this.Controls.Add(tlp1);

		}

		protected override void SetValue()
		{
			Result = new TextCommand(textboxCommand.Text, textboxText.Text, Permissions[comboboxPermission.SelectedIndex], (int)nudTimeout.Value);
		}
	}
}
