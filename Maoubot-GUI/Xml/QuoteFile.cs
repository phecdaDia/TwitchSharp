using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TwitchSharp.Utilities;

namespace Maoubot_GUI.Xml
{
	public class QuoteFile : XmlManager
	{

		public String[] Quotes;

		public QuoteFile()
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

		public static new QuoteFile LoadFromXml(string FilePath)
		{

			try
			{
				// XXX		Make this method return a subclass depending on the inheritance
				using (StreamReader reader = new StreamReader(FilePath))
				{
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(QuoteFile));
					return (QuoteFile)xmlSerializer.Deserialize(reader);
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

		public void AddQuote(String q)
		{
			List<String> t = Quotes.ToList();
			t.Add(q);
			this.Quotes = t.ToArray();
			
		}
	}
}
