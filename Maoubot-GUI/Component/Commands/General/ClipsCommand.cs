using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchSharp.EventArguments;
using TwitchSharp.Components;

namespace Maoubot_GUI.Component.Commands.General
{
	// hacked implementation for quotes - for testing
	public class ClipsCommand : ChatCommand
	{
		private Random random;
		public ClipsCommand()
			: base ("clips", 30, Permission.Subscriber)
		{
			this.random = new Random();
		}


		public override string Execute(Maoubot mb, CommandExecuteEventArgs e)
		{
			if (!MayExecute(e.Permission)) return null;

			if (e.CommandArgs.Length == 0)
			{
				if (mb.BotFile.TwitchClips.Length == 0) return "No clips found!";

				return mb.BotFile.TwitchClips[random.Next(mb.BotFile.TwitchClips.Length)];
			} else
			{
				if (e.Permission >= Permission.Moderator)
				{
					String SubCommand = e.CommandArgs[0];
					if (SubCommand == "add")
					{
						List<String> c = e.CommandArgs.ToList();
						c.RemoveAt(0);
						String Quote = String.Join(" ", c);
						mb.BotFile.TwitchClipList.Add(Quote);
						return "Added clip.";
					}
				}
			}

			return null;
		}
	}
}
