using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchSharp.EventArguments;
using TwitchSharp.Components;
using Maoubot_GUI.Window;

namespace Maoubot_GUI.Component.Commands.General
{
	public class HelpCommand : ChatCommand
	{
		public HelpCommand() : base ("help", 30, Permission.Everybody) { }

		public override string Execute(Maoubot mb, CommandExecuteEventArgs e)
		{
			if (!MayExecute(e.Permission)) return null;

			//if (e.CommandArgs.Length < 1) return GetHelp(mb);

			String c = (e.CommandArgs.Length >= 1) ? e.CommandArgs[0] : String.Empty;
			String sc = (e.CommandArgs.Length >= 2) ? e.CommandArgs[1] : String.Empty;
			String c_ = String.Empty;
			foreach (ChatCommand cc in mb.GetCommands())
			{
				if (cc.MayExecute(e.Permission))
				{
					if (cc.Command == c)
					{
						return cc.GetHelp(mb, sc);
					}
					c_ += cc.Command;
					if (!(cc == mb.GetCommands().Last())) c_ += ", ";
				}
			}

			return String.Format("Available Commands: {0}!", c_);
		}

		public override string GetHelp(Maoubot mb, String SubCommand = "")
		{
			//return "You're funny...";
			return String.Format("{0}{1} <*command>", mb.Tcb.CommandChar, this.Command);
		}
	}
}
