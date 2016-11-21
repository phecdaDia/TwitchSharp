using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TwitchSharp.Utilities;

namespace TwitchRPGBot
{
	public class ConfigFile : XmlManager
	{
		public String Nick, oAuth, Channel;
		public String[] Moderators, Players;
		
		public ConfigFile()
			: base()
		{

		}

		protected override void Init()
		{
			if (String.IsNullOrEmpty(Nick)) Nick = @"DUMMY_NICK";
			if (String.IsNullOrEmpty(oAuth)) oAuth = @"DUMMY_OAUTH";
			if (String.IsNullOrEmpty(Channel)) Channel = @"DUMMY_CHANNEL";

			if (Moderators == null)
			{
				Moderators = new String[]
				{
					@"DUMMY_USER1",
					@"DUMMY_USER2",
					@"DUMMY_USER3"
				};
			}

			if (Players == null)
			{
				Players = new String[0];
			}
		}



		public static new ConfigFile LoadFromXml(string FilePath)
		{

			try
			{
				// XXX		Make this method return a subclass depending on the inheritance
				using (StreamReader reader = new StreamReader(FilePath))
				{
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(ConfigFile));
					return (ConfigFile)xmlSerializer.Deserialize(reader);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Unable to load file\n\t{0}", FilePath);
				//throw ex;
				Console.WriteLine(File.Exists(FilePath) ? String.Join("\n",File.ReadAllLines(FilePath)) : "No File Found!" );
				Console.WriteLine(ex.Message);

				return null;
			}
		}
	}
}
