using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TwitchSharp.EventArguments;

namespace TwitchSharp
{
    public class TwitchChatBot
    {
        public readonly String HOST = "irc.twitch.tv";
        public readonly UInt16 PORT = 6667;

        private TcpClient TcpClient;
        private StreamReader InputStream;
        private StreamWriter OutputStream;

        public String Nick;
        private String OAuth;
        private String Channel;
        private List<String> Channels = new List<string>();

        public bool Active = true;

        public char CommandChar = '!';

        // Events
        public event LoginCompletedEventHandler LoginCompleted;
        public event MessageReceivedEventHandler MessageReceived;
        public event ChannelJoinedEventHandler ChannelJoined;
        public event ChannelPartEventHandler ChannelPart;
        public event CommandExecuteEventHandler CommandExecute;

        public delegate void LoginCompletedEventHandler(object sender, LoginCompletedEventArgs e);
        public delegate void MessageReceivedEventHandler(object sender, MessageReceivedEventArgs e);
        public delegate void ChannelJoinedEventHandler(object sender, ChannelJoinedEventArgs e);
        public delegate void ChannelPartEventHandler(object sender, ChannelPartEventArgs e);
        public delegate void CommandExecuteEventHandler(object sender, CommandExecuteEventArgs e);

        private Thread ReadThread;


        /// <summary>
        /// A Twitch Chat Bot
        /// 
        /// Made by imthe666st/Phecda
        /// </summary>
        /// <param name="Nick">Nickname</param>
        /// <param name="oAuth">oAuth token</param>
        public TwitchChatBot(String Nick, String OAuth)
        {
            
            this.Nick = Nick.ToLower();
            this.OAuth = OAuth;
        }

		/// <summary>
		/// A Twitch Chat Bot
		/// 
		/// Made by imthe666st/Phecda
		/// Call setNick() and setOAuth()
		/// </summary>
		public TwitchChatBot() { }

		/// <summary>
		/// Sets/Changes the nick.
		/// </summary>
		/// <param name="Nick"></param>
		public void setNick(String Nick)
		{
			this.Nick = Nick.ToLower();
		}

		/// <summary>
		/// Sets/Changes the oAuth key
		/// </summary>
		/// <param name="OAuth"></param>
		public void setOAuth(String OAuth)
		{
			this.OAuth = OAuth;
		}

        /// <summary>
        /// Run the bot
        /// Please make sure you added all events
        /// </summary>
        public void Run()
        {
            this.Active = true;
            TcpClient = new TcpClient(HOST, PORT);

            // I/O
            InputStream = new StreamReader(this.TcpClient.GetStream());
            OutputStream = new StreamWriter(this.TcpClient.GetStream());

            // Login
            OutputStream.WriteLine("PASS {0}", OAuth);
            OutputStream.WriteLine("NICK {0}", Nick);
            OutputStream.WriteLine("USER {0} 8 * :{0}", Nick);
            OutputStream.Flush();

            OnLoginCompleted(new LoginCompletedEventArgs(Nick, OAuth));

            // Start Read Loop
            ReadThread = new Thread(() =>
            {
                while (Active)
                {
                    String Message = ReadMessage();

                    //Console.WriteLine(ReadMessage());
                    MessageReceivedEventArgs MREA = new MessageReceivedEventArgs(Message);
                    OnMessageReceived(MREA);
					if (MREA?.Message?.FirstOrDefault() == CommandChar)
					{
						if (MREA?.MessageType == MessageType.Chat) OnCommandExecute(new CommandExecuteEventArgs(MREA.Channel, MREA.Nick, MREA.Message));
						else if (MREA?.MessageType == MessageType.Whisper) OnCommandExecute(new CommandExecuteEventArgs(MREA.Channel, MREA.Nick, MREA.Message, true));
					}

				}
            });

            ReadThread.Start();
        }

        /// <summary>
        /// Stops the bot
		/// Call PartChannel() after
        /// </summary>
        public void Stop()
        {
            Active = false;
            
            
        }

        /// <summary>
        /// Join a channel
        /// 
        /// Event: OnChannelJoin
        /// </summary>
        /// <param name="Channel">Channel</param>
        public void JoinChannel(String Channel)
        {
            if (!String.IsNullOrEmpty(Channel)) this.PartChannel();

            Channel = Channel.ToLower();
            SendIrcMessage("JOIN #{0}", Channel);

            this.Channel = Channel;

            Console.WriteLine("Joined channel #{0}", Channel);

            // Fire Event OnChannelJoin
            OnChannelJoined(new ChannelJoinedEventArgs(Channel));
        }

        /// <summary>
        /// Parts from a channel
        /// </summary>
        /// <param name="Reason">Reason for part</param>
        public void PartChannel(String Reason = "")
        {
            if (String.IsNullOrEmpty(this.Channel)) return;

            Channel = Channel.ToLower();
            OnChannelPart(new ChannelPartEventArgs(Channel, Reason));
               
            SendIrcMessage("PART #{0}", Channel);

            Console.WriteLine("Parted channel {0}: {1}", Channel, Reason);

            this.Channel = String.Empty;
        }

        /// <summary>
        /// Sends a basic IRC Message to the Server
        /// </summary>
        /// <param name="Message">Message</param>
        /// <param name="args">Format</param>
        public void SendIrcMessage(String Message, params object[] args)
        {
            OutputStream.WriteLine(Message, args);
            OutputStream.Flush();
            Console.WriteLine("Send IRC Message\t{0}", String.Format(Message, args));
        }

        /// <summary>
        /// Sends a message into the Twitch Chat
        /// </summary>
        /// <param name="Channel">Channel</param>
        /// <param name="Message">Message</param>
        /// <param name="args">Format</param>
        public void SendChatMessage(String Message, params object[] args)
        {
            if (!String.IsNullOrEmpty(this.Channel))
            {
                Message = String.Format(Message, args);

                // See if the message starts with a . or /
                // Add a LTR unicode then
                if (Message[0] == '.' || Message[0] == '/')
                {
                    Message = "\0" + Message;
                }

                SendIrcMessage("PRIVMSG #{0} :{1}", Channel, Message);
                Console.WriteLine("Send Chat Message\t{0}", Message);
            } else
            {
                Console.WriteLine("Unable to send message. [#{0}]", Channel);
            }
        }

        public void SendEscapedChatMessage(String Message, params object[] args)
        {
            if (!String.IsNullOrWhiteSpace(this.Channel))
            {
                Message = String.Format(Message, args);

                SendIrcMessage("PRIVMSG #{0} :{1}", Channel, Message);
                Console.WriteLine("Send EscapedChat Message\t{0}", Message);
            }
            else
            {
                Console.WriteLine("Unable to send message. [#{0}]", Channel);
            }
        }

        /// <summary>
        /// Sends a private chat message to a user
        /// </summary>
        /// <param name="User"></param>
        /// <param name="Message"></param>
        /// <param name="args"></param>
        public void SendWhisperMessage(String User, String Message, params object[] args)
        {
            if (Channels.Count > 0)
            {
                String t_ = String.Format(".w {0} {1}", User, Message);
                SendEscapedChatMessage(Channels[0], t_, args);
            }
        }

        /// <summary>
        /// Reads a line from the Inputstream
        /// </summary>
        /// <returns>Message</returns>
        public String ReadMessage()
        {
            return InputStream.ReadLine();
        }

		/// <summary>
		/// Use this in order to allow receivage of whispers.
		/// </summary>
		public void ReceiveWhispers()
		{
			SendIrcMessage(@"CAP REQ :twitch.tv/commands");
		}

        // Events
        protected virtual void OnLoginCompleted(LoginCompletedEventArgs e)
        {
            if (LoginCompleted != null) LoginCompleted(this, e);
        }

        protected virtual void OnMessageReceived(MessageReceivedEventArgs e)
        {
            if (MessageReceived != null) MessageReceived(this, e);
        }

        protected virtual void OnChannelJoined(ChannelJoinedEventArgs e)
        {
            if (ChannelJoined != null) ChannelJoined(this, e);
        }

        protected virtual void OnChannelPart(ChannelPartEventArgs e)
        {
            if (ChannelPart != null) ChannelPart(this, e);
        }

        protected virtual void OnCommandExecute(CommandExecuteEventArgs e)
        {
            if (CommandExecute != null) CommandExecute(this, e);
        }
    }
}
