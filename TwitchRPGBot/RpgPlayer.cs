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
	public class RpgPlayer : XmlManager
	{
		public uint Level, Exp;
		public String Class;
		public String TwitchNick;

		public RpgPlayer(String Class, String TwitchNick)
			: base()
		{
			this.Class = Class;
			this.TwitchNick = TwitchNick;
		}

		public RpgPlayer()
			: base()
		{ }

		protected override void Init()
		{
			this.Level = 0;
			this.Exp = 0;
			this.Class = "DUMMY";
			this.TwitchNick = "DUMMY";

		}



		public static new RpgPlayer LoadFromXml(string FilePath)
		{

			try
			{
				// XXX		Make this method return a subclass depending on the inheritance
				using (StreamReader reader = new StreamReader(FilePath))
				{
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(RpgPlayer));
					return (RpgPlayer)xmlSerializer.Deserialize(reader);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Unable to load file\n\t{0}", FilePath);
				//throw ex;
				Console.WriteLine(File.Exists(FilePath) ? String.Join("\n", File.ReadAllLines(FilePath)) : "No File Found!");
				Console.WriteLine(ex.Message);

				return null;
			}
		}

		public void AddExp(uint Amount)
		{
			this.Exp += Amount;
			uint Level2 = this.Level * this.Level;

			while (this.Exp >= Level2)
			{
				this.Exp -= Level2;
				this.Level++;
				Level2 = this.Level * this.Level;

				Console.WriteLine("{0} reached level {1}:{2}", this.TwitchNick, this.Level, this.Exp);
			}
		}

	}
}
