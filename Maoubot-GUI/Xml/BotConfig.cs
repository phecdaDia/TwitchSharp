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
				TextCommands = new TextCommand[]
				{

				};
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
				Console.WriteLine("Unable to load file\n\t{0}", FilePath);
				return null;
			}
		}

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
	}
}
