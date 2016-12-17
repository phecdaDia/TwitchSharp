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
	public class QuoteConfig : XmlManager
	{
		[DataMember]
		public String[] Quotes { get; set; }

		public QuoteConfig()
			: base()
		{
			Init();
		}

		protected override void Init()
		{
			if (this.Quotes == null)
			{
				this.Quotes = new String[0];
			}
		}

		public new static QuoteConfig LoadFromXml(string FilePath)
		{

			try
			{
				using (FileStream stream = File.OpenRead(FilePath))
				{
					DataContractSerializer xmlSerializer = new DataContractSerializer(MethodBase.GetCurrentMethod().DeclaringType);
					return (QuoteConfig)xmlSerializer.ReadObject(stream);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Unable to load file\t{0}", FilePath);
				Console.WriteLine(ex.Message);
				return null;
			}
		}

		public void AddQuote(String q)
		{
			List<String> t = Quotes.ToList();
			t.Add(q);
			this.Quotes = t.ToArray();
			
		}
	}
}
