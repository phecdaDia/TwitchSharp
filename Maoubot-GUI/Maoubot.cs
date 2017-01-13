using Maoubot_GUI.Component;
using Maoubot_GUI.Component.Commands;
using Maoubot_GUI.Component.Commands.Fun;
using Maoubot_GUI.Component.Commands.General;
using Maoubot_GUI.Component.Commands.Utility;
using Maoubot_GUI.Dialog;
using Maoubot_GUI.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwitchSharp;
using TwitchSharp.Components;
using TwitchSharp.EventArguments;
using TwitchSharp.Utilities;

namespace Maoubot_GUI
{
	public partial class Maoubot : Form
	{
		// General Todos...


		public static readonly String ConfigPath = @"Config\";
		public static readonly String TwitchConfigPath = ConfigPath + @"twitch.xml";
		public static readonly String QuotesConfigPath = ConfigPath + @"quotes.xml";
		public static readonly String MaoubotConfigPath = ConfigPath + @"maoubot.xml";
		public static readonly String EmoteDatabasePath = ConfigPath + @"twitch_emotes.xml";

		public ConfigFile ConfigFile;
		public QuoteConfig QuoteFile;
		public BotConfig BotFile;

		public EmoteDatabase EmoteDatabase;

		public TwitchChatBot Tcb;

		private List<ChatCommand> Commands = new List<ChatCommand>();

		private List<String> ActiveUsers;

		private Thread WatcherThread;

		private readonly Boolean IsInDebugMode = true;
		
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool AllocConsole();

		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool FreeConsole();


		/// <summary>
		/// Maoubot-GUI
		/// A simple chatbot for use on Twitch.tv ( irc.twitch.tv:6667 )
		/// </summary>
		public Maoubot()
		{
			InitializeComponent();

			if (IsInDebugMode) AllocConsole(); // Console for debugging usage.

			this.Load += LoadForm;
			this.FormClosing += ClosingForm;

			// init some vars

			this.ActiveUsers = new List<string>();

			// Add commands

			// TODO: Add algorythm to load commands automatically, maybe?

			// GENERAL
			Commands.Add(new CommandCommand());
			Commands.Add(new QuoteCommand());
			Commands.Add(new HelpCommand());

			// FUN
			Commands.Add(new BallCommand());
			Commands.Add(new CatCommand());
			//Commands.Add(new CheeredBitsCommand());
			//Commands.Add(new SubsCommand());

			// Utility commands
			Commands.Add(new QueueCommand());
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
				Tcb.JoinChannel(ConfigFile.Channel);
			};

			this.Tcb.MessageReceived += Tcb_MessageReceived;
			this.Tcb.CommandExecute += Tcb_CommandExecute;
			
			this.Tcb.Verbose = IsInDebugMode;

			// Add Coin system

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
			LoadEmoteDatabase();

			RefreshAccounts();
			RefreshCommands();

			CreateTwitchChatBot();

			UpdateStats();
		}

		/// <summary>
		/// Event called when the form is closing
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ClosingForm(object sender, EventArgs e)
		{
			Tcb?.Stop();

			// Save all configs
			SaveTwitchConfig();
			SaveQuoteConfig();
			SaveMaoubotConfig();
			SaveEmoteDatabase();

		}

		#endregion
		#region Logging

		/// <summary>
		/// Append Message to the Chatbox
		/// </summary>
		/// <param name="Message"></param>
		private void LogWrite(String Message, params object[] format)
		{
			//return;
			Message = String.Format(Message, format);
			if (!IsDisposed)
			{
				if (Chatbox.InvokeRequired)
				{
					Chatbox.Invoke(new LogWriteDelegate(LogWrite), new object[] { Message, format });
				}
				else
				{

					Chatbox.AppendText(Message);
				}
			}
		}
		private delegate void LogWriteDelegate(String Message, params object[] format);
		
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
			//return;
			Message = String.Format(Message, format);
			if (!IsDisposed)
			{
				if (Debugbox.InvokeRequired)
				{
					Debugbox.Invoke(new LogDebugWriteDelegate(LogDebugWrite), new object[] { Message, format });
				}
				else
				{
					Debugbox.AppendText(Message);
				}
			}
		}
		private delegate void LogDebugWriteDelegate(String Message, params object[] format);

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
		/// Saves the TwitchConfig to twitch.xml
		/// </summary>
		/// <param name="ReadFromForm">Shall the config be updated from the form?</param>
		public void SaveTwitchConfig()
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

		/// <summary>
		/// Saves the QuoteConfig to quotes.xml
		/// </summary>
		public void SaveQuoteConfig()
		{
			if (this.QuoteFile == null) QuoteConfig.SaveToXml(QuotesConfigPath, new QuoteConfig());
			else
			{
				QuoteConfig.SaveToXml(QuotesConfigPath, QuoteFile);
				
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
				return;
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
				BotFile.EnableSubMessage = this.checkBoxEnableSubMessage.Checked;
				BotFile.SubMessageNew = this.textBoxSubMessageNew.Text;
				BotFile.SubMessageResub = this.textBoxSubMessageResub.Text;

				BotFile.EnableCommands = this.checkBoxEnableCommands.Checked;

				BotConfig.SaveToXml(MaoubotConfigPath, BotFile);
			}
		}

		/// <summary>
		/// Loads the BotConfig
		/// </summary>
		private void LoadMaoubotConfig()
		{
			this.BotFile = BotConfig.LoadFromXml(MaoubotConfigPath);
			if (this.BotFile == null)
			{
				SaveMaoubotConfig();
				LoadMaoubotConfig();
				return;
			}

			this.checkBoxEnableSubMessage.Checked = BotFile.EnableSubMessage;
			this.textBoxSubMessageNew.Text = BotFile.SubMessageNew;
			this.textBoxSubMessageResub.Text = BotFile.SubMessageResub;

			this.checkBoxEnableCommands.Checked = BotFile.EnableCommands;
		}

		public void SaveEmoteDatabase()
		{
			if (this.EmoteDatabase == null)
			{
				EmoteDatabase.SaveToXml(EmoteDatabasePath, new EmoteDatabase());
				LoadEmoteDatabase();
				return;
			}
			EmoteDatabase.SaveToXml(EmoteDatabasePath, this.EmoteDatabase);
		}

		private void LoadEmoteDatabase()
		{
			this.EmoteDatabase = EmoteDatabase.LoadFromXml(EmoteDatabasePath);
			if (this.EmoteDatabase == null)
			{
				SaveEmoteDatabase();
				return;
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
			if (!BotFile.EnableCommands) return;

			//if (!IsWhisper && OnlyAllowWhisperCommands) return;

			Console.WriteLine("Executing {0}. Whisper: {1}", e.Command, e.IsWhisper);

			// TextCommands. 
			foreach(TextCommand tc in BotFile.TextCommands)
			{
				if (tc.Command == e.Command)
				{
					if (tc.MayExecute(e.Permission))
					{
						if (e.IsWhisper) Tcb.SendWhisperMessage(e.Nick, tc.Format(e));
						else Tcb.SendChatMessage(tc.Format(e));
					}
					return;
				}
			}

			foreach(ChatCommand cc in Commands)
			{
				if (cc.Command == e.Command)
				{
					String Output = cc.Execute(this, e);
					if (String.IsNullOrEmpty(Output)) return;

					if (e.IsWhisper) Tcb.SendWhisperMessage(e.Nick, Output);
					else Tcb.SendChatMessage(Output);
					return;
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
				SaveTwitchConfig();
				//LogDebugWriteLine("Send 'PONG {0}'", Tcb.HOST);
			}
			else if (e.Type == MessageType.Server)
			{
				Console.WriteLine("{0}", e.RawMessage);
				return;
			}
			else if (e.Type == MessageType.Roomstate || e.Type == MessageType.Userstate)
			{
				return;
			}
			else if (e.Type == MessageType.Usernotice)
			{
				//Console.WriteLine("{0}", e.RawMessage);
				LogDebugWriteLine("{0} just resubbed for {1} months! {2}", e.Nick, e.GetSafeTag("msg-param-months"), (++BotFile.Resubs)+ BotFile.NewSubs);

				UpdateStats();

				if (!BotFile.EnableSubMessage) return;

				String Msg = this.BotFile.SubMessageResub + " ";
				// TODO: Replace this.
				Msg = Msg.Replace("%name%", e.Nick);
				Msg = Msg.Replace("%months%", e.GetSafeTag("msg-param-months"));

				Tcb.SendChatMessage(Msg);

			}
			else if (e.Type == MessageType.Chat)
			{
				if (e.IsSubMessage)
				{
					LogDebugWriteLine("{0} just subscribed! {1}", e.Nick, (++BotFile.NewSubs)+ BotFile.Resubs);

					UpdateStats();

					if (!BotFile.EnableSubMessage) return;

					String Msg = this.BotFile.SubMessageNew + " ";
					Msg = Msg.Replace("%name%", e.Nick);

					Tcb.SendChatMessage(Msg);
				}
				else
				{
					String Types = CreatePermissionString(e);
					String k = String.Empty;
					foreach (byte s in Encoding.Unicode.GetBytes(e.Message)) 
					{
						k += String.Format("{0} ", s);
					}
					LogWriteLine("[{0}] {1}: {2}", Types ?? "DUMMY", e.Nick, e.Message);

					TwitchEmoteBatch TemporaryTeb = new TwitchEmoteBatch(e.GetSafeTag("emotes"), e.Message);
					EmoteDatabase.TwitchEmotes.Fusion(TemporaryTeb);

					if (e.IsCheer)
					{
						Console.WriteLine("Cheered bits: {0,6} -> {1}", e.Bits, BotFile.CheeredBits += e.Bits);
						LogDebugWriteLine("{0} cheered {1} bits!", e.Nick, e.Bits);
					}


					if (!ActiveUsers.Contains(e.Nick)) ActiveUsers.Add(e.Nick);

					// finish
					//Console.WriteLine(BotFile.ChatLines);
					BotFile.ChatLines++;
					UpdateStats();
				}
			} else if (e.Type == MessageType.Whisper)
			{
				String Types = CreatePermissionString(e);
				LogWriteLine("[{0}] *{1}*: {2}", Types ?? "DUMMY", e.Nick, e.Message);
			}
		}

		/// <summary>
		/// Creates the Permission String for logging
		/// </summary>
		/// <param name="e"></param>
		/// <returns></returns>
		private String CreatePermissionString(MessageReceivedEventArgs e)
		{

			String Types = String.Empty;
			//Console.Write(String.Join(" ", e.UserType)+" ");

			// \b(cheer|kappa|kreygasm|swiftrage)([0-9]{1,4}0?)\b
			// detect cheers.
			//Console.WriteLine("EMOTES: {0}", e.Tags["emotes"]);

			// Permission string for the console
			List<String> t_ = new List<String>();
			if (e.IsDeveloper) t_.Add("Developer");
			if (!String.IsNullOrEmpty(e.UserType)) t_.Add(e.UserType);
			if (e.IsSubscriber) t_.Add("subscriber");

			//Console.Write(t_.Count);

			for (int i = 0; i < t_.Count; i++)
			{
				Types += t_[i].ToUpper().FirstOrDefault();
				if (i < t_.Count - 1) Types += " ";
			}

			if (t_.Count == 0) Types = "U";

			return Types;

			
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
			if (Tcb == null)
			{
				CreateTwitchChatBot();
            }

			if (!Tcb.Active)
			{
				SaveTwitchConfig();

				Tcb.SetNick(ConfigFile.Nick);
				Tcb.SetOAuth(ConfigFile.oAuth);

				// Add the account
				AddAccount();

				Tcb.Run();
			} else
			{
				Tcb.JoinChannel(textBoxChannel.Text);
			}

			textBoxNickname.Enabled = false;
			textBoxOAuth.Enabled = false;
			textBoxChannel.Enabled = false;

			comboBoxAccounts.Enabled = false;

			buttonAccountsLoad.Enabled = false;
			buttonAccountsDelete.Enabled = false;

			buttonConnect.Enabled = false;

			WatcherThread = new Thread(() =>
			{
				int LastSecond = DateTime.Now.Second;

				DateTime ElapsedTime = new DateTime();

				while (Tcb.Active)
				{
					while (LastSecond == DateTime.Now.Second || !Tcb.InChannel) Thread.Sleep(100);
					ElapsedTime = ElapsedTime.AddSeconds(1);

					if (ElapsedTime.Second == 0) // run every minute once
					{
						Boolean AlreadyHasAccount = false;
						foreach (String Username in ActiveUsers)
						{
							AlreadyHasAccount = false;
							foreach (TwitchUser tu in BotFile.TwitchUsers)
							{
								if (tu.Username == Username)
								{
									tu.AddWatchMinutes(1);
									AlreadyHasAccount = true;
									if (IsInDebugMode) Console.WriteLine("Added 1 WatchMinute to {0}", Username);
								}
							}
							if (!AlreadyHasAccount)
							{
								BotFile.TwitchUserList.Add(new TwitchUser(Username));
								if (IsInDebugMode) Console.WriteLine("Added Account: {0}", Username);
							}
						}

						//Tcb.SendChatMessage("Gave everybody 1 coin.");
						ActiveUsers.Clear();
					}


					Console.WriteLine("Total elapsed time: {0:00}:{1:00}:{2:00}", ElapsedTime.Hour, ElapsedTime.Minute, ElapsedTime.Second);
					LastSecond = DateTime.Now.Second;
				}
			});

			WatcherThread.Start();

		}

		/// <summary>
		/// Disconnects and stops the bot.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonDisconnect_Click(object sender, EventArgs e)
		{
			Tcb?.Stop();
			ClearChatlog();
			ClearDebuglog();

			textBoxNickname.Enabled = true;
			textBoxOAuth.Enabled = true;
			textBoxChannel.Enabled = true;

			comboBoxAccounts.Enabled = true;

			buttonAccountsLoad.Enabled = true;
			buttonAccountsDelete.Enabled = true;

			buttonConnect.Enabled = true;

			WatcherThread?.Abort();
		}

		/// <summary>
		/// Parts from the channel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonPart_Click(object sender, EventArgs e)
		{
			Tcb.PartChannel();
			ClearChatlog();
			ClearDebuglog();
			textBoxChannel.Enabled = true;

			buttonAccountsLoad.Enabled = true;
			buttonAccountsDelete.Enabled = true;

			buttonConnect.Enabled = true;
		}
		/// <summary>
		/// Event called when any key is pressed on the textbox that's used to enter a message to send.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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

		/// <summary>
		/// Sends a message defined by the textboxMessage textbox
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonSendMessage_Click(object sender, EventArgs e)
		{
			String Message = textBoxMessage.Text;
			textBoxMessage.Text = "";
			if (!String.IsNullOrEmpty(Message)) Tcb.SendEscapedChatMessage(Message);
			LogWriteLine("{0}: {1}", Tcb.Nick, Message);
		}

		/// <summary>
		/// Tries to load an account. 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonAccountsLoad_Click(object sender, EventArgs e)
		{
			try
			{
				TwitchAccount k = BotFile.Accounts[comboBoxAccounts.SelectedIndex];

				this.textBoxNickname.Text = k.Nick;
				this.textBoxOAuth.Text = k.OAuth;

			}
			catch (Exception) { }
		}

		/// <summary>
		/// Deletes the currently selected account
		/// WARNING: There is no dialog to confirm.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonAccountsDelete_Click(object sender, EventArgs e)
		{
			BotFile.DeleteAccount(comboBoxAccounts.Text);
			// refresh the combobox
			RefreshAccounts();
		}

		#endregion
		#region Not yet categorized

		/// <summary>
		/// Adds a new account by the currently defined data
		/// </summary>
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
		public void RefreshAccounts()
		{
			comboBoxAccounts.Items.Clear();
			comboBoxAccounts.Items.AddRange(BotFile.GetAccountNames());
			comboBoxAccounts.SelectedIndex = (comboBoxAccounts.Items.Count == 0) ? -1 : 0;
        }

		/// <summary>
		/// Refreshes all commands
		/// </summary>
		public void RefreshCommands()
		{
			if (comboBoxTextCommands.InvokeRequired)
			{
				comboBoxTextCommands.Invoke(new RefreshCommandsDelegate(RefreshCommands));
				return;
			}

			comboBoxTextCommands.Items.Clear();

			foreach (TextCommand tc in BotFile.TextCommands)
			{
				comboBoxTextCommands.Items.Add(tc.Command);

			}

			comboBoxTextCommands.SelectedIndex = (comboBoxTextCommands.Items.Count == 0) ? -1 : 0;
		}
		private delegate void RefreshCommandsDelegate();

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

		/// <summary>
		/// Sends a random color command
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonRandomColor_Click(object sender, EventArgs e)
		{
			if (Tcb != null)
			{
				Random r = new Random();
				int color = r.Next(0x1000000);
                Tcb.SendEscapedChatMessage(".color #{0:X6}", color);
				//Tcb.SendChatMessage("I'm now #{0:X6} chrisGrin", color);
			}
		}

		/// <summary>
		/// TextCommandDialog Test
		/// WARNING: USELESS >:(
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button3_Click(object sender, EventArgs e)
		{
			using (TextCommandDialog tcd = new TextCommandDialog(new TextCommand("EXAMPLE_COMMAND", "EXAMPLE_OUTPUT", Permission.Developer, 33)))
			{
				tcd.ShowDialog();
				if (tcd.DialogResult == DialogResult.OK)
				{
					TextCommand tc = tcd.Result;
					((Button)sender).Text = tc.Command;
				}
			}
		}

		/// <summary>
		/// Deletes the current Dialog. 
		/// WARNING: No confirmation dialog implemented.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonTextCommandDelete_Click(object sender, EventArgs e)
		{
			if (BotFile.DeleteCommand(comboBoxTextCommands.Text))
			{
				Console.WriteLine("Deleted command!");
			} else
			{
				Console.WriteLine("Unable to delete command! >:(");
			}
			RefreshCommands();

			SaveMaoubotConfig();
		}

		/// <summary>
		/// Opens the TextCommandDialog to edit the current command
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonTextCommandEdit_Click(object sender, EventArgs e)
		{
			if (comboBoxTextCommands.SelectedIndex == -1)
			{
				RefreshCommands();
				return;
			}

			using (TextCommandDialog tcd = new TextCommandDialog(BotFile.TextCommands[comboBoxTextCommands.SelectedIndex]))
			{
				tcd.ShowDialog();
				if (tcd.DialogResult == DialogResult.OK)
				{
					TextCommand tc = tcd.Result;
					BotFile.UpdateCommand(tc);
					//RefreshCommands();

					SaveMaoubotConfig();
				}
			}
		}

		/// <summary>
		/// Opens the TextCommandDialog to add a new command
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonTextCommandAdd_Click(object sender, EventArgs e)
		{
			using (TextCommandDialog tcd = new TextCommandDialog())
			{
				tcd.ShowDialog();
				if (tcd.DialogResult == DialogResult.OK)
				{
					TextCommand tc = tcd.Result;
					BotFile.AddCommand(tc);
					RefreshCommands();

					SaveMaoubotConfig();
				}
			}
		}

		/// <summary>
		/// Updates the Statslabel.
		/// </summary>
		private void UpdateStats()
		{
			if (labelCheerTest.InvokeRequired)
			{
				labelCheerTest.Invoke(new UpdateStatsDelegate(UpdateStats));
				return;
			}

			String stats = String.Format(
				"Total Chatlines: {0}" + Environment.NewLine +
				Environment.NewLine +
				"Total Newsubs: {1}" + Environment.NewLine +
				"Total Resubs: {2}" + Environment.NewLine +
				"Total cheered bits: {3}"
			, BotFile.ChatLines, BotFile.NewSubs, BotFile.Resubs, BotFile.CheeredBits);

			labelCheerTest.Text = stats;
		}
		private delegate void UpdateStatsDelegate();

		/// <summary>
		/// Sets all stats to 0 and refreshes them
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonResetStats_Click(object sender, EventArgs e)
		{
			BotFile.ChatLines = 0;
			BotFile.NewSubs = 0;
			BotFile.Resubs = 0;
			BotFile.CheeredBits = 0;

			UpdateStats();
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			SaveTwitchConfig();
			SaveMaoubotConfig();
			SaveQuoteConfig();

			SaveEmoteDatabase();
		}
		
		public ChatCommand[] GetCommands()
		{
			return Commands.ToArray();
		}
		#endregion
	}
}
