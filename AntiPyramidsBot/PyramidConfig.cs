using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TwitchSharp.Utilities;

namespace AntiPyramidsBot
{
	public class PyramidConfig : XmlManager
	{
		public int MinimumPyramidSize;
        public String[] Messages;

		public PyramidConfig()
			: base()
		{

		}

		protected override void Init()
		{
			if (this.MinimumPyramidSize == 0) this.MinimumPyramidSize = 3;
			
			if (this.Messages == null)
			{
				this.Messages = new String[]
				{
					@"Nice pyramid Kappa b",
					@"PogChamp",
					@"No pyramids",
				};
			}
		}
		public static new PyramidConfig LoadFromXml(string FilePath)
		{

			try
			{
				// XXX		Make this method return a subclass depending on the inheritance
				using (StreamReader reader = new StreamReader(FilePath))
				{
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(PyramidConfig));
					return (PyramidConfig)xmlSerializer.Deserialize(reader);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Unable to load file\t{0}", FilePath);
				Console.WriteLine(ex.Message);
				//Console.WriteLine(File.Exists(FilePath) ? String.Join("\n", File.ReadAllLines(FilePath)) : "No File Found!");
				//Console.WriteLine(ex.M);

				return null;
			}
		}
	}
}
