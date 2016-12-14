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
	public class ConfigFile : XmlManager
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

		public new static ConfigFile LoadFromXml(string FilePath)
		{

			try
			{
				using (FileStream stream = File.OpenRead(FilePath))
				{
					DataContractSerializer xmlSerializer = new DataContractSerializer(MethodBase.GetCurrentMethod().DeclaringType);
					return (ConfigFile)xmlSerializer.ReadObject(stream);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Unable to load file\n\t{0}", FilePath);
				//throw ex;
				return null;
			}
		}

		public bool isValid() { return Valid; }
	}
}
