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
	public class RpgPlayer : XmlManager<RpgPlayer>
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
