using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchSharp.Components;
using TwitchSharp.EventArguments;

namespace Maoubot_GUI.Component.Commands.Utility
{
	public class QueueCommand : ChatCommand
	{
		private List<String> Queue;

		public QueueCommand()
			: base ("queue", 0, Permission.Everybody)
		{
			Queue = new List<string>();
		}

		public override string Execute(Maoubot mb, CommandExecuteEventArgs e)
		{
			if (!MayExecute(e.Permission)) return null;

			if (e.CommandArgs.Length == 0)
			{
				// Add somebody to the queue.
				if (!Queue.Contains(e.Nick))
				{
					Queue.Add(e.Nick);
					return String.Format("{0}: Added you to the queue. Position #{1}", e.Nick, Queue.Count);
				}
				else
				{
					return String.Format("{0}: You're at position #{1} in the queue.", e.Nick, Queue.IndexOf(e.Nick));
				}
			}
			else
			{
				String SubCommand = e.CommandArgs[0];
				if (SubCommand == @"list")
				{
					String l = "Current queue: ";
					int names_to_display = 5;
					for (int i = 0; i < names_to_display && i < Queue.Count; i++)
					{
						l += String.Format("{0}", Queue[i]);
						if (i < Queue.Count - 1 && i < names_to_display - 1) l += ", ";
					}

					if (Queue.Count > 5) l += String.Format(" | {0} people left", Queue.Count - 5);

					return l;
				}
				else if (SubCommand == @"next")
				{
					if (e.Permission >= Permission.Moderator)
					{
						if (Queue.Count < 1) return "The queue is empty. :(";

						String NextPerson = Queue[0];
						Queue.RemoveAt(0);
						return String.Format("Next is: {0}", NextPerson);
					}
					else return String.Empty;
				}
				else if (SubCommand == @"clear")
				{
					if (e.Permission >= Permission.Moderator)
					{
						Queue.Clear();
						return "Queue has been cleared.";
					}
					else return String.Empty;
				} else if (SubCommand == @"addrange")
				{
					if (e.Permission < Permission.Moderator) return null;

					List<String> ca = e.CommandArgs.ToList();
					ca.RemoveAt(0);
					ca = String.Join(",", ca).Replace(",,", ",").Split(',').ToList();
					foreach (String name in ca)
					{
						if (!Queue.Contains(name)) Queue.Add(name);
						else ca.Remove(name);
					}
					return String.Format("Added {0} people to the queue. Total: {1}", ca.Count, this.Queue.Count);
				}
			}

			return null;
		}

		public override string GetHelp(Maoubot mb, String SubCommand = "")
		{
			switch (SubCommand)
			{
				case "next":
					return String.Format("{0}{1} {2}", mb.Tcb.CommandChar, this.Command, SubCommand);
				case "clear":
					return String.Format("{0}{1} {2}", mb.Tcb.CommandChar, this.Command, SubCommand);
				case "list":
					return String.Format("{0}{1} {2}", mb.Tcb.CommandChar, this.Command, SubCommand);
				case "addrange":
					return String.Format("{0}{1} {2} <*names+>", mb.Tcb.CommandChar, this.Command, SubCommand);
				default:
					return String.Format("{0}{1} [list|next|clear|addrange]", mb.Tcb.CommandChar, this.Command);
			}
		}
	}
}
