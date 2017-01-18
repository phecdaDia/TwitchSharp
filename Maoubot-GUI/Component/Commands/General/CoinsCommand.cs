using Maoubot_GUI.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchSharp.Components;
using TwitchSharp.EventArguments;

namespace Maoubot_GUI.Component.Commands.General
{
	public class CoinsCommand : ChatCommand
	{
		public CoinsCommand()
			: base ("coins", 0, Permission.Everybody)
		{

		}

		public override string Execute(Maoubot mb, CommandExecuteEventArgs e)
		{
			if (!MayExecute(e.Permission)) return null;
			if (e.Permission <= Permission.Moderator || e.CommandArgs.Length == 0)
			{
				int Index = mb.BotFile.ContainsTwitchuser(e.Nick);
				if (Index < 0)
				{
					mb.BotFile.TwitchUserList.Add(new TwitchUser(e.Nick));
					Index = mb.BotFile.ContainsTwitchuser(e.CommandArgs[1]);
				}
				TwitchUser tu = mb.BotFile.TwitchUserList.Where(x => x.Username == e.Nick).FirstOrDefault();
				return Format("%name%: You have {0} {1}!", e, tu.Coins, mb.BotFile.CoinName);
			} else
			{
				String SubCommand = e.CommandArgs[0];
				if (SubCommand == "add")
				{
					try
					{
						if (e.CommandArgs.Length < 3) return GetHelp(mb, SubCommand);
						int Amount;
						int.TryParse(e.CommandArgs[2], out Amount);

						int Index = mb.BotFile.ContainsTwitchuser(e.CommandArgs[1]);
						if (Index < 0)
						{
							mb.BotFile.TwitchUserList.Add(new TwitchUser(e.CommandArgs[1]));
							Index = mb.BotFile.ContainsTwitchuser(e.CommandArgs[1]);
						}

						mb.BotFile.TwitchUserList[Index].AddCoins(Amount);
						return Format("%nick%: Added {0} {1} to {2}", e, Amount, mb.BotFile.CoinName, e.CommandArgs[1]);
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.Message);
						Console.WriteLine(ex.StackTrace);
						return GetHelp(mb, SubCommand);
					}
				}
			}

			return GetHelp(mb);
		}

		public override string GetHelp(Maoubot mb, string SubCommand = "")
		{


			return "***TODO***";
		}
	}
}
