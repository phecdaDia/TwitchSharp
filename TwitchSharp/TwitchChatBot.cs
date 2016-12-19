﻿using System;
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
		/// <summary>
		/// Hostname address for Twitchchat
		/// </summary>
        public readonly String HOST = "irc.twitch.tv";
		/// <summary>
		/// Hostname port for Twitchchat
		/// </summary>
        public readonly UInt16 PORT = 6667;

		/// <summary>
		/// TCP connection
		/// </summary>
        private TcpClient TcpClient;
		/// <summary>
		/// Reading messages
		/// </summary>
        private StreamReader InputStream;
		/// <summary>
		/// Sending messages
		/// </summary>
        private StreamWriter OutputStream;

		/// <summary>
		/// Nickname set by the user
		/// </summary>
        public String Nick;
		/// <summary>
		/// OAuth set by the user. Kept private for privacy.
		/// </summary>
        private String OAuth;
		/// <summary>
		/// Currently connected channel
		/// </summary>
        public String Channel;

		/// <summary>
		/// Is the bot currently running?
		/// </summary>
        public bool Active = false;
		/// <summary>
		/// Is connected to a channel.
		/// </summary>
		public bool InChannel
		{
			get { return !String.IsNullOrEmpty(Channel); }
		}

		/// <summary>
		/// Char that a message has to begin with so the CommandExecuteEventHandler fires
		/// </summary>
		public char CommandChar = '!';

        // Events
		/// <summary>
		/// Event that fires after successful login
		/// </summary>
        public event LoginCompletedEventHandler LoginCompleted;
		/// <summary>
		/// Event that fires when any message is received
		/// </summary>
        public event MessageReceivedEventHandler MessageReceived;
		/// <summary>
		/// Event that fires when the bot joins a channel
		/// </summary>
        public event ChannelJoinedEventHandler ChannelJoined;
		/// <summary>
		/// Event that fires when we disconnect from a channel
		/// </summary>
        public event ChannelPartEventHandler ChannelPart;
		/// <summary>
		/// Event that fires when a message starting with the CommandChar is received.
		/// MessageReceiveEvent also fires.
		/// </summary>
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
            // all nicks are lowercase
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
			// if the bot is already active, don't do anything.
			if (Active) return;

			// the bot is now running. set Active to true.
            this.Active = true;
			// Create a new TcpClient
            TcpClient = new TcpClient(HOST, PORT);

            // I/O
			// Get the InputStream to receive messages
            InputStream = new StreamReader(this.TcpClient.GetStream());
			// Get the OutputStream to send messages
            OutputStream = new StreamWriter(this.TcpClient.GetStream());

            // Login
			//
			// Twitch login format:
			//		PASS OAuth
			//		NICK Nick
			//		USER 
            OutputStream.WriteLine("PASS {0}", OAuth);
            OutputStream.WriteLine("NICK {0}", Nick);
            OutputStream.WriteLine("USER {0} 8 * :{0}", Nick);
			// Send everything.
            OutputStream.Flush();

			// implement the tag system
			UseTags();

			// Login is completed. Fire the event
			OnLoginCompleted(new LoginCompletedEventArgs(Nick, OAuth));

            // Start Read Loop
			// We start a new thread for reading.
            ReadThread = new Thread(() =>
            {
                while (Active)
                {
					try
					{
					// Read the latest message
                    String Message = ReadMessage();

					// We received a message, fire the MessageReceived event
                    MessageReceivedEventArgs MREA = new MessageReceivedEventArgs(Message);
                    OnMessageReceived(MREA);
					// if the first char is
					if (MREA?.Message?.FirstOrDefault() == CommandChar)
					{
						if (MREA?.Type == MessageType.Chat) OnCommandExecute(new CommandExecuteEventArgs(MREA.Channel, MREA.Nick, MREA.Message));
						else if (MREA?.Type == MessageType.Whisper) OnCommandExecute(new CommandExecuteEventArgs(MREA.Channel, MREA.Nick, MREA.Message, true));
					}
					} catch (Exception ex)
					{
						Console.WriteLine(ex.Message);
						Console.WriteLine(ex.StackTrace);
						//Console.WriteLine("ReadThread Error");
						// An error occured / Stream closed?
					}

				}
            });

            ReadThread.Start();
        }

        /// <summary>
        /// Stops the bot
        /// </summary>
        public void Stop()
        {
            Active = false;
			InputStream?.Close();
			OutputStream?.Close();
            
        }

        /// <summary>
        /// Join a channel
        /// 
        /// Event: OnChannelJoin
        /// </summary>
        /// <param name="Channel">Channel</param>
        public void JoinChannel(String Channel)
        {
			if (InChannel)
			{
				Console.WriteLine("Unable to join multiple channels, disconnecting.");
				this.PartChannel();
			}
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
			if (String.IsNullOrEmpty(this.Channel))
			{
				Console.WriteLine("Unable to part channel: Not connected to any channel");
				return;
			}
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
			if (OutputStream == null)
			{
				Console.WriteLine("Unable to send IRC Message: Outputstream is null");
				return;
			}
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
			if (!String.IsNullOrWhiteSpace(this.Channel))
			{
                String t_ = String.Format(".w {0} {1}", User, Message);
                SendEscapedChatMessage(this.Channel, t_, args);
            }
        }

        /// <summary>
        /// Reads a line from the Inputstream
        /// </summary>
        /// <returns>Message</returns>
        public String ReadMessage()
        {
			try
			{
				return InputStream?.ReadLine() ?? String.Empty;
			}
			catch (Exception)
			{
				Console.WriteLine("ReadMessage() Error");
				return String.Empty;
			}
        }

		/// <summary>
		/// Use this in order to allow receivage of whispers.
		/// </summary>
		public void ReceiveWhispers()
		{
			SendIrcMessage(@"CAP REQ :twitch.tv/commands");
		}

		/// <summary>
		/// Allows us to see tags, this needs to be properly implemented first!
		/// </summary>
		private void UseTags()
		{
			SendIrcMessage(@"CAP REQ :twitch.tv/tags");
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
