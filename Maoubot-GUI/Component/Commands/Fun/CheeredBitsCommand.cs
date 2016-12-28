using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchSharp.Components;
using TwitchSharp.EventArguments;

namespace Maoubot_GUI.Component.Commands.Fun
{
	public class CheeredBitsCommand : ChatCommand
	{
		public CheeredBitsCommand()
			: base("cheeredbits", 1, Permission.Everybody)
		{ }

		public override string Execute(Maoubot mb, CommandExecuteEventArgs e)
		{
			return String.Format("Cheered bits: {0}!", mb.BotFile.CheeredBits);
		}
	}
}
