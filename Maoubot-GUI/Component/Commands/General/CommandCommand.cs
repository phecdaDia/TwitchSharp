using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchSharp.Components;
using TwitchSharp.EventArguments;

namespace Maoubot_GUI.Component.Commands.General
{
	public class CommandCommand : ChatCommand
	{
		public CommandCommand()
			: base ("command", 0, Permission.Moderator)
		{ }

		public override void Execute(Maoubot mb, CommandExecuteEventArgs e)
		{
			if (!MayExecute(e.Permission)) return;

			if (e.CommandArgs.Length >= 1)
			{
				String SubCommand = e.CommandArgs[0];

				if (SubCommand == "add")
				{
					if (e.CommandArgs.Length >= 3)
					{
						String Command = e.CommandArgs[1];
						String Text = String.Empty;
						List<String> t_ = e.CommandArgs.ToList();
						t_.RemoveAt(0);     // remove the "add"-subcommand
						t_.RemoveAt(0);     // remove the caller
						Text = String.Join(" ", t_);

						// Check if the command already exists..
						if (mb.BotFile.UpdateCommand(Command, Text))
						{

							mb.Tcb.SendChatMessage("{0}: Command updated.", e.Nick);
							return;
						}

						mb.BotFile.AddCommand(Command, Text);
						mb.Tcb.SendChatMessage("{0}: Added command", e.Nick);
						mb.RefreshCommands();
						return;
					}
					else
					{
						mb.Tcb.SendChatMessage("{0}: Usage: {1}commands add <Command> <Text>", e.Nick, mb.BotFile.CommandPrefix);
						return;
					}
				}
				else if (SubCommand == "delete")
				{
					if (e.CommandArgs.Length >= 2)
					{
						String Command = e.CommandArgs[1];
						if (mb.BotFile.DeleteCommand(Command))
						{
							mb.Tcb.SendChatMessage("{0}: Command deleted", e.Nick);
							mb.RefreshCommands();
							return;
						}
						else
						{
							mb.Tcb.SendChatMessage("{0}: Command not found!", e.Nick);
							return;
						}
					}
					else
					{
						mb.Tcb.SendChatMessage("{0}: Usage: {1}commands delete <Command>", e.Nick, mb.BotFile.CommandPrefix);
						return;
					}
				}
				else
				{
					mb.Tcb.SendChatMessage("{0}: Subcommand not found!", e.Nick);
					return;
				}
			}
			else
			{
				mb.Tcb.SendChatMessage("{0}: Available subcommands: add, delete", e.Nick);
				return;
			}
		}
	}
}
