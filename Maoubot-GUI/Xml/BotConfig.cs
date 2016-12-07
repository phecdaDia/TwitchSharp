using System;
using System.IO;
using System.Xml.Serialization;
using TwitchSharp.Utilities;

namespace Maoubot_GUI
{
	internal class BotConfig : XmlManager
	{
		private bool Valid = true;

		public BotConfig()
			: base()
		{
			Init();
		}

		protected override void Init()
		{
			
		}

		public static new BotConfig LoadFromXml(string FilePath)
		{

			try
			{
				// XXX		Make this method return a subclass depending on the inheritance
				using (StreamReader reader = new StreamReader(FilePath))
				{
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(BotConfig));
					return (BotConfig)xmlSerializer.Deserialize(reader);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Unable to load file\n\t{0}", FilePath);
				//throw ex;
				Console.WriteLine(File.Exists(FilePath) ? String.Join("\n", File.ReadAllLines(FilePath)) : "No File Found!");
				//Console.WriteLine(ex.Message);

				return null;
			}
		}
	}
}