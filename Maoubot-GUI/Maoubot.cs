using Maoubot_GUI.Component;
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

		private ConfigFile ConfigFile;
		private QuoteConfig QuoteFile;
		private BotConfig BotFile;

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
				Tcb.SendIrcMessage("CAP REQ :twitch.tv/tags");
				Tcb.JoinChannel(ConfigFile.Channel);
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
			LoadMaoubotConfig();

			RefreshAccounts();

			CreateTwitchChatBot();
		}

		private void ClosingForm(object sender, EventArgs e)
		{
			Tcb?.Stop();

			// Save all configs
			SaveTwitchConfig();
			SaveQuoteConfig();
			SaveMaoubotConfig();

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
			if (this.ConfigFile == null) ConfigFile.SaveToXml(TwitchConfigPath, new ConfigFile());
			else
			{
					this.ConfigFile.Nick = textBoxNickname.Text;
					this.ConfigFile.oAuth = textBoxOAuth.Text;
					this.ConfigFile.Channel = textBoxChannel.Text;

				ConfigFile.SaveToXml(TwitchConfigPath, this.ConfigFile);
			}
		}

		/// <summary>
		/// Load your TwitchConfig
		/// Creates an empty TwitchConfig if none could be found.
		/// </summary>
		private void LoadTwitchConfig()
		{
			this.ConfigFile = ConfigFile.LoadFromXml(TwitchConfigPath);
			if (this.ConfigFile == null)
			{
				// Save an empty config file and load it
				// Return to prevent recursion
				SaveTwitchConfig();
				LoadTwitchConfig();
				return;
			}
			
			// Load config to form
			textBoxNickname.Text = ConfigFile.Nick;
			textBoxOAuth.Text = ConfigFile.oAuth;
			textBoxChannel.Text = ConfigFile.Channel;
		}

		// Quote Methods

		/// <summary>
		/// Saves the QuoteConfig to quotes.xml
		/// </summary>
		private void SaveQuoteConfig()
		{
			if (this.QuoteFile == null) QuoteConfig.SaveToXml(QuotesConfigPath, new QuoteConfig());
			else
			{
				QuoteConfig.SaveToXml(ConfigPath + QuotesConfigPath, QuoteFile);
				
			}
		}


		/// <summary>
		/// Load your QuoteConfig
		/// Creates an empty QuoteConfig if none could be found.
		/// </summary>
		private void LoadQuoteConfig()
		{
			this.QuoteFile = QuoteConfig.LoadFromXml(QuotesConfigPath);
			if (this.QuoteFile == null)
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
			if (this.BotFile == null) BotConfig.SaveToXml(MaoubotConfigPath, new BotConfig());
			else
			{
				BotConfig.SaveToXml(MaoubotConfigPath, BotFile);
			}
		}

		/// <summary>
		/// Loads the BotConfig
		/// </summary>
		public void LoadMaoubotConfig()
		{
			this.BotFile = BotConfig.LoadFromXml(MaoubotConfigPath);
			if (this.BotFile == null)
			{

				Console.ReadLine();
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
			return;
			// TextCommands. 
			foreach(TextCommand tc in BotFile.TextCommands)
			{
				if (tc.Command == e.Command)
				{
					Tcb.SendChatMessage(tc.Format(e));
					return;
				}
			}

			if (e.Command == "cmdadd")
			{
				if (e.CommandArgs.Length >= 2)
				{
					String c = String.Empty;
					for (int i=1; i<e.CommandArgs.Length; i++)
					{
						c += e.CommandArgs[i];
						c += " ";
		}

					TextCommand k = new TextCommand(e.CommandArgs[0], c);
					BotFile.AddCommand(k);
					Tcb.SendChatMessage("{0}: Added command {1}!", e.Nick, e.CommandArgs[0]);
					SaveMaoubotConfig();
				} else
				{
					Tcb.SendChatMessage("{0}: [USAGE] {1}cmdadd <command> <text>", e.Nick, BotFile.CommandPrefix);
				}
			}

		}

		/// <summary>
		/// Fires when any message is received.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Tcb_MessageReceived(object sender, MessageReceivedEventArgs e)
		{
			if (e.Type == MessageType.Ping)
			{
				Tcb.SendIrcMessage("PONG {0}", Tcb.HOST);
				LogDebugWriteLine("Send 'PONG {0}'", Tcb.HOST);
			} else if (e.Type == MessageType.Server)
			{
				LogWriteLine("{0}", e.RawMessage);
			} else if (e.Type == MessageType.Chat)
			{
				LogWriteLine("{0}: {1}", e.Nick, e.Message);
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

				Tcb.setNick(ConfigFile.Nick);
				Tcb.setOAuth(ConfigFile.oAuth);

				// Add the account
				AddAccount();

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
			Tcb.Stop();
			ClearChatlog();
			ClearDebuglog();
		}

		private void buttonPart_Click(object sender, EventArgs e)
		{
			Tcb.PartChannel();
			ClearChatlog();
			ClearDebuglog();
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

		private void buttonAccountsLoad_Click(object sender, EventArgs e)
		{
			try
			{
				TwitchAccount k = BotFile.Accounts[comboBoxAccounts.SelectedIndex];

				this.textBoxNickname.Text = k.Nick;
				this.textBoxOAuth.Text = k.OAuth;

			} catch (Exception) { }
		}

		private void buttonAccountsDelete_Click(object sender, EventArgs e)
		{
			BotFile.DeleteAccount(comboBoxAccounts.Text);
			// refresh the combobox
			RefreshAccounts();
		}

		private void AddAccount()
		{
			String Nick = textBoxNickname.Text;
			String OAuth = textBoxOAuth.Text;

			if (BotFile.GetAccountNames().Contains(Nick))
			{
				int pos = -1;
				for (int i=0; i< BotFile.GetAccountNames().Length; i++)
				{
					if (BotFile.GetAccountNames()[i] == Nick)
					{
						pos = i;
						break;
					}
				}
				if (pos < 0) return;

				// Update the oauth key
				BotFile.Accounts[pos].OAuth = OAuth;
				return;
			} else
			{
				TwitchAccount t = new TwitchAccount(Nick, OAuth);
				BotFile.AddAccount(t);
				RefreshAccounts();
			}
		}

		/// <summary>
		/// Refreshes the combobox to select the accounts.
		/// </summary>
		private void RefreshAccounts()
		{
			comboBoxAccounts.Items.Clear();
			comboBoxAccounts.Items.AddRange(BotFile.GetAccountNames());
			comboBoxAccounts.SelectedIndex = 0;
		}

		private void buttonTwitchConfigSave_Click(object sender, EventArgs e)
		{
			SaveTwitchConfig();
		}

		private void buttonTwitchConfigLoad_Click(object sender, EventArgs e)
		{
			LoadTwitchConfig();
		}

		private void buttonQuotesConfigSave_Click(object sender, EventArgs e)
		{
			SaveQuoteConfig();
		}

		private void buttonQuotesConfigLoad_Click(object sender, EventArgs e)
		{
			LoadQuoteConfig();
		}

		private void buttonMaouBotConfigSave_Click(object sender, EventArgs e)
		{
			SaveMaoubotConfig();
		}

		private void buttonMaouBotConfigLoad_Click(object sender, EventArgs e)
		{
			LoadMaoubotConfig();
		}

		/// <summary>
		/// clears the chatbox.
		/// </summary>
		private void ClearChatlog()
		{
			if (Chatbox.IsDisposed) return;
			if (Chatbox.InvokeRequired)
			{
				Chatbox.Invoke(new Action(() => { Chatbox.Clear(); }));
			}
			else
			{
				Chatbox.Clear();
			}
		}

		/// <summary>
		/// clears the debugbox
		/// </summary>
		private void ClearDebuglog()
		{
			if (Debugbox.IsDisposed) return;
			if (Debugbox.InvokeRequired)
			{
				Debugbox.Invoke(new Action(() => { Debugbox.Clear(); }));
			}
			else
			{
				Debugbox.Clear();
			}
		}
	}
}
