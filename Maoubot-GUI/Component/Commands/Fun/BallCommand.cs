using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchSharp.Components;
using TwitchSharp.EventArguments;

namespace Maoubot_GUI.Component.Commands.Fun
{
	public class BallCommand : ChatCommand
	{
		private String[] BallMessages = new string[]
		{
			@"It is certain",
			@"It is decidedly so",
			@"Without a doubt",
			@"Yes, definitely",
			@"You may rely on it",
			@"As I see it, yes",
			@"Most likely",
			@"Outlook good",
			@"Yes",
			@"Signs point to yes",

			@"Reply hazy try again",
			@"Ask again later",
			@"Better not tell you now",
			@"Cannot predict now",
			@"Concentrate and ask again",

			@"Don't count on it",
			@"My reply is no",
			@"My sources say no",
			@"Outlook not so good",
			@"Very doubtful"
		};

		public BallCommand()
			: base ("8ball", 30, Permission.Subscriber)
		{ }

		public override String Execute(Maoubot mb, CommandExecuteEventArgs e)
		{
			if (this.Permission >= Permission.Subscriber) return "This command is not available in whisper mode";

			if (!MayExecute(e.Permission)) return String.Empty;
			if (e.CommandArgs.Length == 0)
			{
				return String.Format("{0}: You have to ask a question...", e.Nick);
			}

			Random r = new Random();
			return String.Format("{0}: {1}", e.Nick, BallMessages[r.Next(BallMessages.Length)]);
		}
	}
}
