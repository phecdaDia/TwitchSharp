using Maoubot_GUI.Component;
using Maoubot_GUI.Component.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TwitchSharp.Utilities;

namespace Maoubot_GUI.Xml
{
	[DataContract(IsReference = true)]
	public class BotConfig : XmlManager<BotConfig>
	{
		[DataMember]
		public String CommandPrefix { get; set; }
		[DataMember]
		public TextCommand[] TextCommands { get; set; }
		[DataMember]
		public TwitchAccount[] Accounts { get; set; }
		[DataMember]
		public Boolean EnableSubMessage { get; set; }
		[DataMember]
		public String SubMessageNew { get; set; }
		[DataMember]
		public String SubMessageResub { get; set; }
		[DataMember]
		public Boolean EnableCommands { get; set; }
		
		[DataMember]
		public int ChatLines { get; set; }
		[DataMember]
		public int CheeredBits { get; set; }
		[DataMember]
		public int NewSubs { get; set; }
		[DataMember]
		public int Resubs { get; set; }

		public BotConfig()
			: base()
		{
			Init();
		}

		protected override void Init()
		{
			if (String.IsNullOrEmpty(CommandPrefix)) CommandPrefix = "!";

			if (TextCommands == null)
			{
				TextCommands = new TextCommand[0];
			}
			if (Accounts == null)
			{
				Accounts = new TwitchAccount[0];
			}
			if (String.IsNullOrEmpty(SubMessageNew)) SubMessageNew = @"Thank you for the sub %name%! <3";
			if (String.IsNullOrEmpty(SubMessageResub)) SubMessageResub = @"Thank you for the %months% sub, %name%! <3";

		}

		// Commands

		public void AddCommand(String Command, String Output)
		{
			TextCommand c = new TextCommand(Command, Output);

			AddCommand(c);
		}

		public void AddCommand(TextCommand c)
		{
			List<TextCommand> a = TextCommands.ToList();
			a.Add(c);
			TextCommands = a.ToArray();
		}

		public Boolean UpdateCommand(String Command, String Text)
		{
			foreach (TextCommand t in TextCommands)
			{
				if (t.Command == Command)
				{
					t.Output = Text;
					return true;
				}
			}
			return false;
		}

		public Boolean UpdateCommand(TextCommand tc)
		{
			foreach (TextCommand t in TextCommands)
			{
				if (t.Command == tc.Command)
				{
					t.Output = tc.Output;
					t.Permission = tc.Permission;
					t.Timeout = tc.Timeout;
					return true;
				}
			}
			return false;
		}

		public Boolean DeleteCommand(String Command)
		{
			int Index = -1;
			for (int i=0; i<TextCommands.Length; i++)
			{
				if (TextCommands[i].Command == Command)
				{
					Index = i;
					break;
				}
			}
			if (Index < 0)
				return false;

			List<TextCommand> t = TextCommands.ToList();
			t.RemoveAt(Index);
			TextCommands = t.ToArray();
			Console.WriteLine("Removed " + Index);
			return true;

		}



		// Accounts
		public void AddAccount(String Nick, String OAuth)
		{
			TwitchAccount c = new TwitchAccount(Nick, OAuth);

			AddAccount(c);
		}

		public void AddAccount(TwitchAccount c)
		{
			List<TwitchAccount> a = Accounts.ToList();
			a.Add(c);
			Accounts = a.ToArray();
		}

		public String[] GetAccountNames()
		{
			if (Accounts == null) return new String[0];
			List<String> a = new List<string>();
			foreach (TwitchAccount b in Accounts) a.Add(b.Nick);
			return a.ToArray();
		}

		internal void DeleteAccount(string Nick)
		{
			bool Found = true;
			do
			{
				Found = false;
				List<TwitchAccount> a = Accounts.ToList();
				for (int i=0; i<Accounts.Length; i++)
				{
					if (a[i].Nick == Nick)
					{
						a.RemoveAt(i);
						Found = true;
						break;
					}
				}

				Accounts = a.ToArray();

			} while (Found == true);

		}
	}
}
