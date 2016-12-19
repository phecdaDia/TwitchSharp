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
	public class ConfigFile : XmlManager<ConfigFile>
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
	}
}
