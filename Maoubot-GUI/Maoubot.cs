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
		private static readonly String MaoubotConfigPath = ConfigPath + @"maoubot.xml";

		private ConfigFile Cf;
		private QuoteConfig Qf;
		private BotConfig Bf;

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
			this.FormClosing += ClosingForm;


		}

		/// <summary>
		/// Creates the TCB object and adds events
		/// </summary>
		private void CreateTwitchChatBot()
		{
			this.Tcb = new TwitchChatBot();
			this.Tcb.LoginCompleted += (s, e) =>
			{
				Tcb.ReceiveWhispers();
				Tcb.JoinChannel(Cf.Channel);
			};

			this.Tcb.MessageReceived += Tcb_MessageReceived;
			this.Tcb.CommandExecute += Tcb_CommandExecute;
		}

		#region FormEvents
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

		private void ClosingForm(object sender, EventArgs e)
		{
			if (Tcb.Active)
			{
				Tcb.Stop();
				Tcb.PartChannel();
			}
		}
		#endregion
		#region Logging
		/// <summary>
		/// Append Message to the Chatbox
		/// </summary>
		/// <param name="Message"></param>
		private void LogWrite(String Message, params object[] format)
		{
			Message = String.Format(Message, format);
			if (!IsDisposed)
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
		}
		
		/// <summary>
		/// Append Message to the Chatbox and a newline.
		/// </summary>
		/// <param name="Message"></param>
		private void LogWriteLine(String Message, params object[] format)
		{
			LogWrite(String.Format("{0}\n", Message), format);
		}
		
		/// <summary>
		/// Append Message to the Debugbox
		/// </summary>
		/// <param name="Message"></param>
		private void LogDebugWrite(String Message, params object[] format)
		{
			Message = String.Format(Message, format);
			if (!IsDisposed)
			{
				if (Debugbox.InvokeRequired)
				{
					Debugbox.Invoke(new Action(() => { Debugbox.AppendText(Message); }));
				}
				else
				{
					Debugbox.AppendText(Message);
				}
			}
		}
		
		/// <summary>
		/// Append Message to the Debugbox and a newline
		/// </summary>
		/// <param name="Message"></param>
		private void LogDebugWriteLine(String Message, params object[] format)
		{
			LogDebugWrite(String.Format("{0}\n", Message), format);
		}
		#endregion
		#region Config Save/Load
		/// <summary>
		/// Saves the TwitchConfig to twitch.xml **XXX_TODO_XXX**
		/// </summary>
		/// <param name="ReadFromForm">Shall the config be updated from the form?</param>
		private void SaveTwitchConfig()
		{
			if (this.Cf == null) ConfigFile.SaveToXml(TwitchConfigPath, new ConfigFile());
			else
			{
				this.Cf.Nick = textBoxNickname.Text;
				this.Cf.oAuth = textBoxOAuth.Text;
				this.Cf.Channel = textBoxChannel.Text;

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

		/// <summary>
		/// Saves the QuoteConfig to quotes.xml
		/// </summary>
		private void SaveQuoteConfig()
		{
			if (this.Qf == null) QuoteConfig.SaveToXml(QuotesConfigPath, new QuoteConfig());
			else
			{
				QuoteConfig.SaveToXml(ConfigPath + QuotesConfigPath, Qf);
				
			}
		}


		/// <summary>
		/// Load your QuoteConfig
		/// Creates an empty QuoteConfig if none could be found.
		/// </summary>
		private void LoadQuoteConfig()
		{
			this.Qf = QuoteConfig.LoadFromXml(QuotesConfigPath);
			if (this.Qf == null)
			{
				SaveQuoteConfig();
				LoadQuoteConfig();
			}
		}

		/// <summary>
		/// Saves the BotConfig
		/// Creates an empty BotConfig if none could be found
		/// </summary>
		public void SaveMaoubotConfig()
		{
			if (this.Bf == null) BotConfig.SaveToXml(MaoubotConfigPath, new BotConfig());
			else
			{



				BotConfig.SaveToXml(MaoubotConfigPath, Bf);
			}
		}

		/// <summary>
		/// Loads the BotConfig
		/// </summary>
		public void LoadMaoubotConfig()
		{
			this.Bf = BotConfig.LoadFromXml(MaoubotConfigPath);
			if (this.Bf == null)
			{
				SaveMaoubotConfig();
				LoadMaoubotConfig();
			}
		}
		#endregion
		#region TCB Events
		/// <summary>
		/// Executes the commands
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Tcb_CommandExecute(object sender, CommandExecuteEventArgs e)
		{
			//throw new NotImplementedException();
		}

		/// <summary>
		/// Fires when any message is received.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Tcb_MessageReceived(object sender, MessageReceivedEventArgs e)
		{
			if (e.MessageType == MessageType.Ping)
			{
				Tcb.SendIrcMessage("PONG {0}", Tcb.HOST);
				LogDebugWriteLine("Send 'PONG {0}'", Tcb.HOST);
			}
			else if (e.MessageType == MessageType.Chat || e.MessageType == MessageType.Whisper)
			{
				LogWriteLine("{0}: {1}", e.Nick, e.Message);
			}
			else if (e.MessageType == MessageType.Notification)
			{
				LogWriteLine("[NOTIFY] {0}", e.Message);
			} else if (e.MessageType == MessageType.Server)
			{
				LogDebugWriteLine("{0}", e.RawMessage);
			} else
			{
				LogWriteLine("[UNKNOWN]: {0} -> {1}", e.MessageType, e.RawMessage);
			}
		}
		#endregion
		#region FormComponent Events
		/// <summary>
		/// Connects the bot with the specified settings. 
		/// What else?
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonConnect_Click(object sender, EventArgs e)
		{
			if (!Tcb.Active)
			{
				SaveTwitchConfig();

				Tcb.setNick(Cf.Nick);
				Tcb.setOAuth(Cf.oAuth);

				Tcb.Run();
			} else
			{
				Tcb.JoinChannel(textBoxChannel.Text);
			}

		}

		/// <summary>
		/// Disconnects and stops the bot.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonDisconnect_Click(object sender, EventArgs e)
		{
			//Tcb.Stop();
			Tcb.PartChannel();
		}

		/// <summary>
		/// Saves the TwitchConfig
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonConfigSave_Click(object sender, EventArgs e)
		{
			SaveTwitchConfig();
		}

		/// <summary>
		/// Loads the TwitchConfig
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonConfigLoad_Click(object sender, EventArgs e)
		{
			LoadTwitchConfig();
		}
		#endregion

		private void textBoxMessage_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				String Message = textBoxMessage.Text;
				textBoxMessage.Text = "";
				if (!String.IsNullOrEmpty(Message)) Tcb.SendEscapedChatMessage(Message);
				LogWriteLine("{0}: {1}", Tcb.Nick, Message);
			}
		}

		private void buttonSendMessage_Click(object sender, EventArgs e)
		{
			String Message = textBoxMessage.Text;
			textBoxMessage.Text = "";
			if (!String.IsNullOrEmpty(Message)) Tcb.SendEscapedChatMessage(Message);
			LogWriteLine("{0}: {1}", Tcb.Nick, Message);
		}
	}
}
