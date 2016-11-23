using Maoubot_GUI.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwitchSharp.Utilities;

namespace Maoubot_GUI
{
	public partial class Maoubot : Form
	{
		private readonly String ConfigPath = @"Config\";

		private ConfigFile Cf;
		private QuoteFile Qf;

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool AllocConsole();

		public Maoubot()
		{
			InitializeComponent();
			AllocConsole();

			this.Cf = ConfigFile.LoadFromXml(ConfigPath+"twitch.xml");
			if (Cf == null)
			{
				this.Cf = new ConfigFile();
				ConfigFile.SaveToXml(ConfigPath + "twitch.xml", Cf);
			}

			this.Qf = QuoteFile.LoadFromXml(ConfigPath + "quotes.xml");
			if (Qf == null)
			{
				this.Qf = new QuoteFile();
				QuoteFile.SaveToXml(ConfigPath + "quotes.xml", Qf);
			}
			Console.WriteLine(Qf.Quotes.Length);
			foreach (var s in Qf.Quotes) Console.WriteLine(s);
		}
	}
}
