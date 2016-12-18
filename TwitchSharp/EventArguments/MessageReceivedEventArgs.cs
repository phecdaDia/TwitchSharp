using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TwitchSharp.EventArguments
{
	public class MessageReceivedEventArgs : EventArgs
	{
		public String RawMessage { get; }
		public String Message { get; }
		public String Nick { get; }
		public String Channel { get; }
		public String Host { get; }
		public bool IsColored { get; }

		public String[] RegexSplit { get; }

		public MessageType Type { get; }

		//:imthe666st!imthe666st@imthe666st.tmi.twitch.tv PRIVMSG #imthe666st :HELLO
		//:USERNAME!NICK@HOST PRIVMSG #CHANNEL :MESSAGE

		//SERVER
		//:tmi.twitch.tv 003 maoubot :This server is rather new
		//:HOST CODE NICK :MESSAGE

		public MessageReceivedEventArgs(String Message)
		{
			this.RawMessage = Message;
			if (String.IsNullOrEmpty(Message)) return;
			Console.WriteLine(RawMessage);
			if (Message.StartsWith(":tmi.twitch.tv"))
			{
				String[] p_ = new Regex("([!@ #])+").Split(RawMessage);
				if (p_[2] == @"USERNOTICE")
				{
					this.Type = MessageType.Notification;
					return;
				}

				this.Type = MessageType.Server;
				return;
			} else if (Message.StartsWith("PING"))
			{
				this.Type = MessageType.Ping;
				return;
			} else if (Message.StartsWith(":twitchnotify"))
			{
				this.Type = MessageType.Notification;
				return;
			} else
			{
				this.Type = MessageType.Chat;
				String[] p_ = new Regex("[:!@ #]+").Split(RawMessage);
				if (p_[1].Contains(".") || p_[4] != @"PRIVMSG")
				{
					this.Type = MessageType.Server;
					return;
				}
				this.RegexSplit = p_;
				Console.WriteLine(p_.Length);
				this.Nick = p_[1];
				this.Host = p_[3];
				this.Channel = p_[5];
				this.Message = String.Empty;
				for (int i=6; i<p_.Length; i++)
				{
					this.Message += p_[i];
					if (i < p_.Length - 1) this.Message += " ";
				}
				//Console.WriteLine(Messagce);
				//this.Message = p_[7];
				this.IsColored = this.Message.StartsWith("\u0001");
            }
		}
	}

    public enum MessageType
    {
        Server = 0,
        Chat = 1,
        Ping = 2,
		Whisper = 3,
		Notification = 4,
		ModeratorNotice = 5,
    }
}
