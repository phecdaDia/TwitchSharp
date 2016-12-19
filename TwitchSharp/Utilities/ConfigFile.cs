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

namespace TwitchSharp.Utilities
{
	[DataContract(IsReference = true)]
	public class ConfigFile : XmlManager<ConfigFile>
	{
		[DataMember]
		public String Nick { get; set; }
		[DataMember]
		public String oAuth { get; set; }
		[DataMember]
		public String Channel { get; set; }
		[DataMember]
		public String[] Moderators { get; set; }

		private bool Valid = true;

		public ConfigFile()
			: base()
		{
			Init();
		}

		protected override void Init()
		{
			this.Valid = true;
			if (String.IsNullOrEmpty(Nick))
			{
				Nick = @"DUMMY_NICK";
				Valid = false;
			}
			if (String.IsNullOrEmpty(oAuth))
			{
				oAuth = @"DUMMY_OAUTH";
				Valid = false;
			}
			if (String.IsNullOrEmpty(Channel))
			{
				Channel = @"DUMMY_CHANNEL";
				Valid = false;
			}

			if (Moderators == null)
			{
				Moderators = new String[]
				{
					@"DUMMY_USER1",
					@"DUMMY_USER2",
					@"DUMMY_USER3"
				};
				Valid = false;
			}
		}

		public bool isValid() { return Valid; }
	}
}
