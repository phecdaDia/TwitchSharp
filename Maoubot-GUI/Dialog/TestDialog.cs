using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maoubot_GUI.Dialog
{
	public class TestDialog : AbstractDialog<String>
	{
		public TestDialog()
			: base("Test Dialog", 480, 480)
		{

		}

		protected override void CreateComponents()
		{
			CloseButton.Dock = DockStyle.Fill;
			CloseButton.Text = "OK";

			this.Controls.Add(CloseButton);
		}

		protected override void SetValue()
		{
			this.Result = DateTime.Now.ToString();
		}
	}
}
