using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public MessageType MessageType { get; }

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

            String[] s1 = Message.Split(' ');
            if (Message.StartsWith(@"PING "))
            {
                this.MessageType = MessageType.Ping;

                this.Message = @"Ping";
            }
            else if (!s1.First().Contains('@') || s1.Length < 4)
            {
                this.MessageType = MessageType.Server;
                
            } else
            {
				if (s1[1] == "PRIVMSG") this.MessageType = MessageType.Chat;
				else if (s1[1] == "WHISPER") this.MessageType = MessageType.Whisper;

                this.Message = s1[3].Substring(1);

				this.IsColored = (s1[3] == ":\u0001ACTION");

				if (IsColored) this.Message = s1[4];
				for (int i = ((IsColored) ? 5 : 4); i < s1.Length; i++)
                {
                    this.Message += " " + s1[i];
                }

                
                this.Nick = s1[0].Split('!').First().Substring(1);
				this.Channel = s1[2].Substring(1);
                this.Host = s1[0].Split('@').Last();
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
    }
}
