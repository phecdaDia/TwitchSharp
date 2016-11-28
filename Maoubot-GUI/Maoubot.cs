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
using TwitchSharp;
using TwitchSharp.EventArguments;
using TwitchSharp.Utilities;

namespace Maoubot_GUI
{
	public partial class Maoubot : Form
	{
		private static readonly String ConfigPath = @"Config\";
		private static readonly String TwitchConfigPath = ConfigPath + @"twitch.xml";
		private static readonly String QuotesConfigPath = ConfigPath + @"quotes.xml";

		private ConfigFile Cf;
		private QuoteFile Qf;

		private TwitchChatBot Tcb;

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool AllocConsole();


		/// <summary>
		/// Maoubot-GUI
		/// A simple chatbot for use on Twitch.tv ( irc.twitch.tv:6667 )
		/// </summary>
		public Maoubot()
		{
			InitializeComponent();
			AllocConsole(); // Console for debugging usage.

			this.Load += LoadForm;

			
		}

		/// <summary>
		/// Load Event Method
		/// Loads important assets ( Twitch.xml, etc )
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LoadForm(object sender, EventArgs e)
		{
			LoadTwitchConfig();
			LoadQuoteConfig();
			CreateTwitchChatBot();
		}

		/// <summary>
		/// Append Message to the Chatbot
		/// </summary>
		/// <param name="Message"></param>
		private void LogWrite(String Message)
		{
			if (Chatbox.InvokeRequired)
			{
				Chatbox.Invoke(new Action(() => { Chatbox.AppendText(Message); }));
			}
			else
			{
				Chatbox.AppendText(Message);
			}
		}
		
		/// <summary>
		/// Append Message to the Chatbot and a newline.
		/// </summary>
		/// <param name="Message"></param>
		private void LogWriteLine(String Message)
		{
			LogWrite(String.Format("{0}\n", Message));
		}
		
		/// <summary>
		/// Append Message to the Debugbox
		/// </summary>
		/// <param name="Message"></param>
		private void LogDebugWrite(String Message)
		{
			if (Debugbox.InvokeRequired)
			{
				Debugbox.Invoke(new Action(() => { Chatbox.AppendText(Message); }));
			}
			else
			{
				Debugbox.AppendText(Message);
			}
		}
		
		/// <summary>
		/// Append Message to the Debugbox and a newline
		/// </summary>
		/// <param name="Message"></param>
		private void LogDebugWriteLine(String Message)
		{
			LogDebugWrite(String.Format("{0}\n", Message));
		}



		// Config Methods

		/// <summary>
		/// Saves the TwitchConfig to twitch.xml **XXX_TODO_XXX**
		/// </summary>
		/// <param name="ReadFromForm">Shall the config be updated from the form?</param>
		private void SaveTwitchConfig(bool ReadFromForm = true)
		{
			if (this.Cf == null) ConfigFile.SaveToXml(TwitchConfigPath, new ConfigFile());
			else
			{
				if (ReadFromForm)
				{
					this.Cf.Nick = textBoxNickname.Text;
					this.Cf.oAuth = textBoxOAuth.Text;
					this.Cf.Channel = textBoxChannel.Text;
				}

				ConfigFile.SaveToXml(TwitchConfigPath, this.Cf);
			}
		}

		/// <summary>
		/// Load your TwitchConfig
		/// Creates an empty TwitchConfig if none could be found.
		/// </summary>
		private void LoadTwitchConfig()
		{
			this.Cf = ConfigFile.LoadFromXml(TwitchConfigPath);
			if (this.Cf == null)
			{
				// Save an empty config file and load it
				// Return to prevent recursion
				SaveTwitchConfig();
				LoadTwitchConfig();
				return;
			}
			
			// Load config to form
			textBoxNickname.Text = Cf.Nick;
			textBoxOAuth.Text = Cf.oAuth;
			textBoxChannel.Text = Cf.Channel;
		}

		// Quote Methods

		private void SaveQuoteConfig()
		{
			if (this.Qf == null) QuoteFile.SaveToXml(QuotesConfigPath, new QuoteFile());
			else
			{
				QuoteFile.SaveToXml(ConfigPath + QuotesConfigPath, Qf);
				
			}
		}

		private void LoadQuoteConfig()
		{
			this.Qf = QuoteFile.LoadFromXml(QuotesConfigPath);
			if (this.Qf == null)
			{
				SaveQuoteConfig();
				LoadQuoteConfig();
			}
		}

		// TwitchChatBot Methods

		/// <summary>
		/// Creates the TCB object and adds events
		/// </summary>
		private void CreateTwitchChatBot()
		{
			this.Tcb = new TwitchChatBot();
			this.Tcb.LoginCompleted += (s, e) =>
			{
				Tcb.JoinChannel(Cf.Channel);
			};

			this.Tcb.MessageReceived += Tcb_MessageReceived;
			this.Tcb.CommandExecute += Tcb_CommandExecute;
		}

		// Execute a command
		private void Tcb_CommandExecute(object sender, CommandExecuteEventArgs e)
		{
			//throw new NotImplementedException();
		}

		private void Tcb_MessageReceived(object sender, MessageReceivedEventArgs e)
		{
			if (e.MessageType == MessageType.Ping)
			{
				Tcb.SendIrcMessage("PONG {0}", Tcb.HOST);
			}
			else if (e.MessageType == MessageType.Chat || e.MessageType == MessageType.Whisper)
			{

			}
		}

		private void buttonConnect_Click(object sender, EventArgs e)
		{

		}
	}
}
