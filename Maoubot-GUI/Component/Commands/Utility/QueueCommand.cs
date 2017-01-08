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
					for (int i = 0; i < 5 && i < Queue.Count; i++)
					{
						l += String.Format("{0}: {1} ", i + 1, Queue[i]);
					}

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
				}
			}

			return null;
		}
	}
}
