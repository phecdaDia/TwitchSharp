using Maoubot_GUI.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchSharp.Components;
using TwitchSharp.EventArguments;

namespace Maoubot_GUI.Component.Commands.Utility
{
	public class EmoteCommand : ChatCommand
	{
		public EmoteCommand()
			: base ("emote", 10, Permission.Everybody)
		{

		}

		public override string Execute(Maoubot mb, CommandExecuteEventArgs e)
		{
			if (!MayExecute(e.Permission)) return null;

			if (e.CommandArgs.Length > 0)
			{
				String EmoteName = e.CommandArgs[0];
				int Index = mb.EmoteDatabase.TwitchEmotes.ContainsEmote(EmoteName);
                if (Index < 0) return GetHelp(mb, EmoteName);
				TwitchEmote te = mb.EmoteDatabase.TwitchEmotes.Emotes.Where(x => x.EmoteName == EmoteName).FirstOrDefault();
				return Format("%name%: \"{0}\" has been used {1} times and is #{2} total", e, te.EmoteName, te.Amount, Index);
			}
			else return GetHelp(mb);
		}

		public override string GetHelp(Maoubot mb, string SubCommand = "")
		{
			if (!String.IsNullOrEmpty(SubCommand)) return String.Format("{0} couldn't be found. Make sure it isn't a FFZ emote!", SubCommand);
			return String.Format("***TODO***");
		}
	}
}
