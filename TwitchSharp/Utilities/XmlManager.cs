using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TwitchSharp.Utilities
{
	public abstract class XmlManager
	{
		public XmlManager()
		{
			Init();
		}
		protected abstract void Init();

		public static void SaveToXml(string FilePath, XmlManager SourceObject)
		{
			try
			{
				using (StreamWriter writer = new StreamWriter(FilePath))
				{
					XmlSerializer xmlSerializer = new XmlSerializer(SourceObject.GetType());
					xmlSerializer.Serialize(writer, SourceObject);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Unable to save file\t{0}", FilePath);
				Console.WriteLine(ex.StackTrace);
			}
		}

		public static XmlManager LoadFromXml(string FilePath)
		{
			
			try
			{
				// XXX		Make this method return a subclass depending on the inheritance
				using (StreamReader reader = new StreamReader(FilePath))
				{
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(XmlManager));
					return (XmlManager)xmlSerializer.Deserialize(reader);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Unable to load file\n\t{0}", FilePath);

				return null;
			}
		}
	}

}
