using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TwitchSharp;
using TwitchSharp.Components;
using TwitchSharp.EventArguments;

namespace TwitchRPGBot
{
    class Program
    {
		//private static bool verbose =;

		private static ConfigFile cf;
		private static List<String> Moderators;
		private static List<RpgPlayer> Players;

		private static TwitchChatBot Tcb;
		private static TwitchChat Tc;

		private static String PlayerDirectoryPath = @"Players";
		private static String Version = "ChatRPG 0.1 - 'It works'-Edition";

        static void Main(string[] args)
        {
			PreInit();
			Init();
			MainRoutine();
			Cleanup();
			Finish();

        }

		public static void PreInit()
		{
			/*
				Loading assets, etc
			*/
			cf = ConfigFile.LoadFromXml("Config.xml") ?? new ConfigFile();
			Console.WriteLine("NICK:\t{0}", cf.Nick);
			Console.WriteLine("OAUTH:\t{0}", cf.oAuth);

			Console.WriteLine("Loading lists...");

			Moderators = cf.Moderators.ToList();
			List<String> pNames = cf.Players.ToList();

			Console.WriteLine("Loading player data...");
			String[] PlayerFiles = Directory.GetFiles(PlayerDirectoryPath, "*.xml");
			Players = new List<RpgPlayer>();

			foreach (String Nick in pNames)
			{
				Console.Write("Now loading {0}: ", Nick);

				String FilePath = String.Format("{0}\\{1}.xml", PlayerDirectoryPath, Nick);
				Console.Write("{0} ", FilePath.Split('\\').Last());

				if (File.Exists(FilePath))
				{
					RpgPlayer p = RpgPlayer.LoadFromXml(FilePath);
					if (p != null)
					{
						Players.Add(p);
						Console.Write("{0}:{1}:{2}:{3}\n", p.TwitchNick, p.Class, p.Level, p.Exp);
					}
					else Console.Write("FAILED\n");
				}
				else Console.Write("FAILED\n");
			}
			

			// Load TCB
			Tcb = new TwitchChatBot(cf.Nick, cf.oAuth);

			Tc = new TwitchChat(cf.Channel);
		}

		public static void Init()
		{
			/* 
				Add Events
			*/
			Tcb.CommandChar = '!';

			Tcb.LoginCompleted += (s, e) => { Tcb.JoinChannel(cf.Channel); Tcb.SendIrcMessage(@"CAP REQ :twitch.tv/commands"); };
            Tcb.MessageReceived += Tcb_MessageReceived;
			Tcb.CommandExecute += Tcb_CommandExecute;

			// 


		}

		public static void MainRoutine()
		{

			Tcb.Run();
			while (Tcb.Active)
			{
				Thread.Sleep(100);
			}
		}

		public static void Cleanup()
		{
			Console.WriteLine("Starting Cleanup!");
			cf.Moderators = Moderators.ToArray();
			List<String> pNames = new List<string>();
			foreach (RpgPlayer Player in Players)
			{
				Console.Write("{0}: ", Player.TwitchNick);
				RpgPlayer.SaveToXml(String.Format("{0}\\{1}\\{2}.xml", Directory.GetCurrentDirectory(), PlayerDirectoryPath, Player.TwitchNick), Player);
				pNames.Add(Player.TwitchNick);
				Console.Write("OK!\n");
			}
			cf.Players = pNames.ToArray();

			ConfigFile.SaveToXml("Config.xml", cf);
		}

		public static void Finish()
		{
			Console.WriteLine();
			Console.WriteLine("Finished everything!");
			Console.WriteLine("\tBye!");
			Console.ReadLine();
		}

		/***************************************************************************************/
		
		private static bool isModerator(String Nick)
		{
			return Moderators.Contains(Nick);
		}

		/***************************************************************************************/

		// Handle events
		
		private static void Tcb_MessageReceived(object sender, MessageReceivedEventArgs e)
		{
			if (e.MessageType == MessageType.Server) Console.WriteLine(e.RawMessage);
			else if (e.MessageType == MessageType.Ping)
			{
				Tcb.SendIrcMessage("PONG {0}", Tcb.HOST);
				Tc.RefreshChatters();
				
				Tcb.SendChatMessage("All {0} players gained 1 xp!", Tc.chatter_count);
				List<String> AllChatters = new List<string>();
				AllChatters.AddRange(Tc.chatters.moderators);
				AllChatters.AddRange(Tc.chatters.staff);
				AllChatters.AddRange(Tc.chatters.global_mods);
				AllChatters.AddRange(Tc.chatters.admins);
				AllChatters.AddRange(Tc.chatters.viewers);

				foreach (String Nick in AllChatters)
				{
					foreach (RpgPlayer p in Players)
					{
						if (p.TwitchNick == Nick)
						{
							p.AddExp(1);
						}
					}
					// Check if User is a player of TwitchRPG
					
				}
			}
			else if (e.MessageType == MessageType.Chat || e.MessageType == MessageType.Whisper)
			{

				Console.WriteLine("{0}\t: [{1}] {2}: {3}", e.MessageType, isModerator(e.Nick) ? "M" : "U", e.Nick, e.Message);
				if (e.Message.StartsWith("q!") && isModerator(e.Nick))
				{
					Tcb.SendEscapedChatMessage(e.Message.Substring(3));
				}
			}
		}

		private static void Tcb_CommandExecute(object sender, CommandExecuteEventArgs e)
		{
			if (e.Command == "stop" && isModerator(e.Nick))
			{
				Tcb.SendChatMessage("{0}: BYE! Q_Q", e.Nick);
				Tcb.Stop();
				Tcb.PartChannel();

			} else if (e.Command == "hello")
			{
				if (!e.Whisper)
					Tcb.SendChatMessage("Hello!");
				else Tcb.SendWhisperMessage(e.Nick, "Hello!");
			}
			else if (e.Command == "mod" && e.Nick == e.Channel)
			{
				List<String> Names = new List<string>();
				foreach (String nick in e.CommandArgs)
				{
					if (!Moderators.Contains(nick.ToLower()))
					{
						Moderators.Add(nick.ToLower());
						Names.Add(nick);
					}

				}
				Tcb.SendChatMessage("{0} {1} now a moderator of this ChatRPG!", String.Join(", ", Names), Names.Count == 1 ? "is" : "are");
			}
			else if (e.Command == "unmod" && e.Nick == e.Channel)
			{
				List<String> Names = new List<string>();
				foreach (String nick in e.CommandArgs)
				{
					if (Moderators.Contains(nick.ToLower()) && nick != e.Channel)
					{
						Moderators.Remove(nick.ToLower());
						Names.Add(nick);
					}

				}
				Tcb.SendChatMessage("{0} {1} no longer moderator of this ChatRPG!", String.Join(", ", Names), Names.Count == 1 ? "is" : "are");
			} else if (e.Command == "register")
			{
				if (e.CommandArgs.Length >= 1) {

					// Registering a new player
					RpgPlayer p = new RpgPlayer(e.CommandArgs[0], e.Nick);
					Players.Add(p);

					Tcb.SendChatMessage("{0}: You registered your {1}!", e.Nick.ToLower(), p.Class);

				}
			} else if (e.Command == "addexp" && isModerator(e.Nick))
			{
				if (e.CommandArgs.Length >= 1)
				{
					uint Amount;
					uint.TryParse(e.CommandArgs[0], out Amount);
					String Nick = (e.CommandArgs.Length >= 2) ? e.CommandArgs[1] : e.Nick;
					for (int i = 0; i < Players.Count; i++)
					{
						if (Players[i].TwitchNick == Nick.ToLower()) {
							Players[i].AddExp(Amount);
							Tcb.SendChatMessage("{0}: Added {1} Exp to {2}", e.Nick, Amount, Players[i].TwitchNick);
							break;
						}
					}
				}
			} else if (e.Command == "mods")
			{
				Tcb.SendChatMessage("ChatRPG Mods: {0}", String.Join(", ", Moderators));
			} else if (e.Command == "stats")
			{
				if (e.CommandArgs.Length >= 0)
				{
					String Nick = (e.CommandArgs.Length >= 1) ? e.CommandArgs[0] : e.Nick;
					for (int i = 0; i < Players.Count; i++)
					{
						if (Players[i].TwitchNick == Nick)
						{
							RpgPlayer p = Players[i];
							Tcb.SendChatMessage("{0} the {1} Level:{2} ({3}/{4}) {5}", p.TwitchNick, p.Class, p.Level, p.Exp, p.Level * p.Level, isModerator(p.TwitchNick) ? "[M]" : "");
						}
					}
				}
			}
			else if (e.Command == "reset" && isModerator(e.Nick))
			{
				if (e.CommandArgs.Length >= 1)
				{
					String Nick = e.CommandArgs[0];
					for (int i = 0; i < Players.Count; i++)
					{
						if (Players[i].TwitchNick == Nick)
						{
							Players[i].Level = 1;
							Players[i].Exp = 0;

							Tcb.SendChatMessage("Reset Player {0} to level 1", Nick);
						}
					}
				}
			}
			else if (e.Command == "setclass" && isModerator(e.Nick))
			{
				if (e.CommandArgs.Length >= 2)
				{
					String Nick = e.CommandArgs[0];
					String Class = e.CommandArgs[1];
					for (int i = 0; i < Players.Count; i++)
					{
						if (Players[i].TwitchNick == Nick)
						{
							Players[i].Class = Class;
						}
					}
				}
			}
		}

	}
}
