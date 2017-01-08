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
		private Random random;

		public QuoteCommand()
			: base("quote", 0, Permission.Everybody)
		{
			this.random = new Random();
		}

		public override string Execute(Maoubot mb, CommandExecuteEventArgs e)
		{
			if (!MayExecute(e.Permission)) return null;

			if (e.CommandArgs.Length == 0)
			{
				if (mb.QuoteFile.Quotes.Length == 0) return "No quotes found!";

				return mb.QuoteFile.Quotes[random.Next(mb.QuoteFile.Quotes.Length)];
			}
			else
			{
				// try to get the index
				int Index = -1;
				int.TryParse(e.CommandArgs[0], out Index);
				if (Index > 0)
				{
					if (Index < mb.QuoteFile.Amount)
					{
						return mb.QuoteFile.Quotes[Index];
					}
					else return String.Format("No quote #{0} found.", Index);
				}

				if (e.Permission >= Permission.Moderator)
				{
					String SubCommand = e.CommandArgs[0];
					if (SubCommand == "add")
					{

						if (e.CommandArgs.Length >= 2)
						{
							List<String> c = e.CommandArgs.ToList();
							c.RemoveAt(0);
							String Quote = String.Join(" ", c);
							mb.QuoteFile.QuoteList.Add(Quote);
							mb.SaveQuoteConfig();
							return String.Format("Added quote #{0}.", mb.QuoteFile.Amount);
						}
						else return null;
					} else if (SubCommand == "delete")
					{
						if (e.CommandArgs.Length >= 2)
						{
							int.TryParse(e.CommandArgs[1], out Index);
							if (Index > 0)
							{
								if (Index < mb.QuoteFile.Amount)
								{
									mb.QuoteFile.QuoteList.RemoveAt(Index);
									mb.SaveQuoteConfig();
								} else return String.Format("No quote #{0} found.", Index);
							}
							else return String.Format("Unable to find quote {0}", e.CommandArgs[1]);
						}
						else return null;
					}
				}
			}

			return null;
		}
	}
}
