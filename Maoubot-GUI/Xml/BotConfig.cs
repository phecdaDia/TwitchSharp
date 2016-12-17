using Maoubot_GUI.Component;
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
	public class BotConfig : XmlManager
	{
		[DataMember]
		public String CommandPrefix { get; set; }
		[DataMember]
		public TextCommand[] TextCommands { get; set; }
		[DataMember]
		public TwitchAccount[] Accounts { get; set; }

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
		}

		public new static BotConfig LoadFromXml(string FilePath)
		{

			try
			{
				using (FileStream stream = File.OpenRead(FilePath))
				{
					DataContractSerializer xmlSerializer = new DataContractSerializer(MethodBase.GetCurrentMethod().DeclaringType);
					var asd = xmlSerializer.ReadObject(stream);
					return (BotConfig)asd;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Unable to load file\t{0}", FilePath);
				Console.WriteLine(ex.Message);
				return null;
			}
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
