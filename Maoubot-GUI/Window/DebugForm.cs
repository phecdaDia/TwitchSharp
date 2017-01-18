using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maoubot_GUI.Window
{
	public partial class DebugForm : Form
	{
		private Thread DebugThread;

		private Maoubot Maoubot;

		private int Counter = 0;

		public DebugForm(Maoubot Maoubot)
		{
			this.Maoubot = Maoubot;
			InitializeComponent();
		}

		private void DebugForm_Shown(object sender, EventArgs e)
		{
			if (DebugThread == null)
			{
				this.DebugThread = new Thread(() =>
					{
						TimeSpan UpdateDelay = new TimeSpan(0, 0, 0, 1, 0);
						TimeSpan ElapsedTime = new TimeSpan();
						DateTime LastExecution = DateTime.Now;
						while (!this.IsDisposed)
						{
							while (ElapsedTime < UpdateDelay)
							{
								ElapsedTime += DateTime.Now.Subtract(LastExecution);
								LastExecution = DateTime.Now;
								if (ElapsedTime < UpdateDelay)
									Thread.Sleep(250); // Todo: Create a better method
							}
							ElapsedTime -= UpdateDelay;

							// Update stuff
							SetTextOfComponent(label1, Counter++.ToString());
							SetTextOfComponent(label2, Counter++.ToString());
							SetTextOfComponent(label3, Counter++.ToString());

						}
					}
				);
			}

			if (!this.DebugThread.IsAlive)
				this.DebugThread.Start();
		}

		// Thread management
		public delegate void SetTextOfComponentDelegate(Control c, String Text);
        public void SetTextOfComponent(Control c, String Text)
		{
			if (!c.IsDisposed)
			{
				if (c.InvokeRequired)
				{
					c.Invoke(new SetTextOfComponentDelegate(SetTextOfComponent), new object[] { c, Text });
				}
				else
				{
					c.Text = Text;
				}
			}
		}
	}
}
