using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchSharp.EventArguments;

namespace Maoubot_GUI.Component.Commands.Fun
{
	public class CatCommand : ChatCommand
	{
		public CatCommand()
			: base ("cat", 10)
		{

		}

		public override string Execute(Maoubot mb, CommandExecuteEventArgs e)
		{
			if (e.CommandArgs.Length == 0) return GetHelp(mb);
			return String.Format("Cat. {0}", String.Join(" ", e.CommandArgs));
		}

		public override string GetHelp(Maoubot mb, String SubCommand = "")
		{
			return String.Format("{0}{1} <*Meow>", mb.Tcb.CommandChar, this.Command);
		}
	}
}
