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
				this.Quotes = new String[]
				{
					@"QUOTE_001",
					@"QUOTE_002",
					@"QUOTE_003",
					@"QUOTE_004"
				};
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
				Console.WriteLine("Unable to load file\n\t{0}", FilePath);
				//throw ex;
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
