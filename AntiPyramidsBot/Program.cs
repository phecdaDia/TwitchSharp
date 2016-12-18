using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchSharp;
using TwitchSharp.EventArguments;
using TwitchSharp.Utilities;

namespace AntiPyramidsBot
{
	class Program
	{
		/* **************************************************** */

		// Config

		private static int MinPyramidSize;

		private static String[] AntiPyramidMessages;

		/* **************************************************** */
		private static int PyramidCounter = 0;
		private static int MessageCounter = 0;
		private static String CurrentPyramid;
		private static String CurrentNick;

		private static ConfigFile Cf;
		private static PyramidConfig Pc;
		private static TwitchChatBot Tcb;

		static void Main(string[] args)
		{
			Cf = ConfigFile.LoadFromXml("twitch.xml");
			if (Cf == null)
			{
				ConfigFile.SaveToXml("twitch.xml", new ConfigFile());
				Console.ReadLine();
				return;
			}


			Pc = PyramidConfig.LoadFromXml("pyramids.xml");
			if (Pc == null)
			{
				PyramidConfig.SaveToXml("pyramids.xml", new PyramidConfig());
				Console.ReadLine();
				return;
			}

			MinPyramidSize = Pc.MinimumPyramidSize;
			AntiPyramidMessages = Pc.Messages;
			
			Tcb = new TwitchChatBot(Cf.Nick, Cf.oAuth);

			Tcb.LoginCompleted += (s, e) =>
			{
				Tcb.JoinChannel(Cf.Channel);
            };

			Tcb.MessageReceived += (s, e) =>
			{
				if (e.Type == MessageType.Ping) Tcb.SendIrcMessage("PONG! {0}", Tcb.HOST);

				if (e.Type != MessageType.Chat) return;
				Console.WriteLine("{0}: {1}", e.Nick, e.Message);
				CurrentNick = e.Nick;
				
				if (e.Message.Split(' ').Length == 1)
				{
					CurrentPyramid = e.Message;
					PyramidCounter = 1;
					// Now, wait 
					return;
				} else
				{
					if (e.Nick == CurrentNick)
					{
						String[] MessageSplit = e.Message.Split(' ');
						if (MessageSplit.Length == PyramidCounter + 1)
						{
							bool Same = true;
							String Sample = MessageSplit[0];
							for (int i = 1; i < MessageSplit.Length; i++)
							{
								if (MessageSplit[i] != Sample) Same = false;

							}

							if (!Same) return;
							else PyramidCounter++;

							//if (PyramidCounter >= MinPyramidSize)
							//{
							//	Tcb.SendChatMessage(AntiPyramidMessages[MessageCounter]);
							//	MessageCounter++;
							//	MessageCounter %= AntiPyramidMessages.Length;
							//	PyramidCounter = 0;
							//	CurrentNick = Tcb.Nick;

							//}
	                    } else if (PyramidCounter >= MinPyramidSize)
						{
							if (PyramidCounter - 1 == MessageSplit.Length)
							{
								bool Same = true;
								String Sample = MessageSplit[0];
								for (int i = 1; i < MessageSplit.Length; i++)
								{
									if (MessageSplit[i] != Sample) Same = false;

								}

								if (!Same) return;

								Tcb.SendChatMessage(AntiPyramidMessages[MessageCounter]);
								MessageCounter++;
								MessageCounter %= AntiPyramidMessages.Length;
								PyramidCounter = 0;
								CurrentNick = Tcb.Nick;
							} else
							{
								PyramidCounter = 0;
							}
						} else
						{
							PyramidCounter = 0;
						}
					}
				}
			};

			Tcb.Run();

		}
	}
}
