using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwitchSharp;
using TwitchSharp.EventArguments;
using TwitchSharp.Utilities;

namespace BrokenBot
{
	public partial class BrokenBotForm : Form
	{

		// Declare variables
		private TwitchChatBot Tcb;
		private ConfigFile Cf;
		private VRAM Vr;

		private ChatCommand[] Commands = new ChatCommand[]
		{
			new ChatCommand(@"hello", 0),
			new ChatCommand(@"commands", 0, PermissionLevel.Moderator),
			new ChatCommand(@"getbyte", 1),
			new ChatCommand(@"getshort", 1),
			new ChatCommand(@"getint", 1),
			new ChatCommand(@"getstring", 2),
			new ChatCommand(@"writebyte", 2),
			new ChatCommand(@"writeshort", 2),
			new ChatCommand(@"writeint", 2),
			new ChatCommand(@"writestring", 3),
			new ChatCommand(@"win-the-game", 0xFFFF, PermissionLevel.Nobody),
		};



		// Declare events + handlers
		public event ExceptionEventHandler ExceptionOccured;
		public delegate void ExceptionEventHandler(object sender, ExceptionEventArgs e);
		protected virtual void OnExceptionOccured(ExceptionEventArgs e)
		{
			if (ExceptionOccured != null) ExceptionOccured(this, e);
		}

		// Constructors
		public BrokenBotForm()
		{
			InitializeComponent();

			this.ExceptionOccured += (s, e) => { Log("Whoops!\t{0}", e.Message); };
			this.FormClosing += (s, e) => {
				Tcb?.Stop();
				Tcb?.PartChannel();
			};
			SetupVirtualMemory();
			SetupChatbotEvents();

			this.textBoxNickname.Text = Cf.Nick;
			this.textBoxOAuth.Text = Cf.oAuth;
			this.textBoxChannel.Text = Cf.Channel;

			this.buttonConfigSave.Click += (s, e) => { SaveConfig(); };
		}

		// Init Methods
		private void SetupVirtualMemory()
		{
			Int32 RamSize = 0x40000;
			Log("Setting up VRAM: {0:x}", RamSize);
			this.Vr = new VRAM(RamSize);
			int Addr = 0;
			// Setup all commands

			// 
			Log("Setting up Commands...");
			for (int i = 0; i < Commands.Length; i++)
			{
				LogWrite("{0}:\t", Commands[i].Command);
				Addr = 0x100 + i * 0x30;
				Vr.WriteByteArray(Addr, Commands[i].ToByteArray());
				Vr.WriteInt32(Addr + 0x2C, 0x1000 + i * 0x400);

				Log("OK!");
			}
		}

		private void SetupChatbotEvents()
		{
			Cf = ConfigFile.LoadFromXml("twitch.xml");
			if (Cf != null)
			{
				if (Cf.isValid() || true) // TODO: REDO THIS!!!
				{
					Tcb = new TwitchChatBot();

				} else
				{

					OnExceptionOccured(new ExceptionEventArgs(String.Format("Invalid Twitch.xml")));
					ConfigFile.SaveToXml("twitch.xml", Cf);
					return;
				}
			}
			else
			{
				OnExceptionOccured(new ExceptionEventArgs("No Twitch.xml found!"));
				ConfigFile.SaveToXml("twitch.xml", new ConfigFile());
				return;
			}

			Log("Now creating all events..");
			Tcb.LoginCompleted += (s, e) => { Tcb.JoinChannel(textBoxChannel.Text); Tcb.ReceiveWhispers(); };
			Tcb.MessageReceived += HandleChatmessage;


		}

		// Run Method
		private void Run()
		{
			Tcb.setNick(textBoxNickname.Text);
			Tcb.setOAuth(textBoxOAuth.Text);
			SaveConfig();

			Log("Now \"running\"");
			Tcb.Run();
		}

		// Debugging
		private void Log(String Message, params object[] Args)
		{
			LogWrite(Message, Args);

			LogWrite(Environment.NewLine);
		}
		
		private void LogWrite(String Message, params object[] Args)
		{
			if (Args.Length > 0)
				Message = String.Format(Message, Args);
			if (this.Debugbox.InvokeRequired) this.Debugbox.Invoke(new Action(() => this.Debugbox.AppendText(Message)));
			else this.Debugbox.AppendText(Message); 
		}

		private void HandleChatmessage(object s, MessageReceivedEventArgs e)
		{
			if (e.MessageType == MessageType.Ping) Tcb.SendIrcMessage("PONG! {0}", Tcb.HOST);
			else if (e.MessageType == MessageType.Chat) {
				if (Chatbox?.InvokeRequired ?? false) Chatbox?.Invoke(new Action(() => this.Chatbox?.AppendText(String.Format("[{3}]{0}: {1}{2}", e.Nick, e.Message, Environment.NewLine, e.IsColored))));
				else this.Chatbox?.AppendText(String.Format("[{3}]{0}: {1}{2}", e.Nick, e.Message, Environment.NewLine, char.GetNumericValue(e.Message[0])));
			}
		}

		// Button methods
		private void buttonStart_Click(object sender, EventArgs e)
		{
			Run();
		}

		// Private Methods
		private void SaveConfig()
		{
			LogWrite("Saving the config...");
			Cf.Nick = this.textBoxNickname.Text;
			Cf.oAuth = this.textBoxOAuth.Text;
			Cf.Channel = this.textBoxChannel.Text;

			ConfigFile.SaveToXml("twitch.xml", Cf);
			Log("OK!");
		}


		// Bot Events
	}

	public class ExceptionEventArgs : EventArgs
	{
		public String Message;

		public ExceptionEventArgs(String Message)
		{
			this.Message = Message;
		}
	}
}
