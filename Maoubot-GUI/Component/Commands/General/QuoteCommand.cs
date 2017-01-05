using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchSharp.Components;
using TwitchSharp.EventArguments;

namespace Maoubot_GUI.Component.Commands.General
{
	public class QuoteCommand : ChatCommand
	{
		public QuoteCommand()
			: base("quote", 0, Permission.Moderator)
		{}

		public override string Execute(Maoubot mb, CommandExecuteEventArgs e)
		{


			return "I'm sorry...";
		}
	}
}
