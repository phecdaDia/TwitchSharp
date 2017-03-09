using Maoubot_GUI.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchSharp.Components;
using TwitchSharp.EventArguments;

namespace Maoubot_GUI.Component.Commands.Fun
{
	public class SubsCommand : ChatCommand
	{
		public SubsCommand()
			: base("subs", 1, Permission.Everybody)
		{ }

		public override string Execute(Maoubot mb, CommandExecuteEventArgs e)
		{
			return String.Format("New: {0} | Resub: {1}", mb.BotFile.NewSubs, mb.BotFile.Resubs);
		}

		public override string GetHelp(Maoubot mb, String SubCommand = "")
		{
			return String.Format("{0}{1}", mb.Tcb.CommandChar, this.Command);
		}
	}
}
