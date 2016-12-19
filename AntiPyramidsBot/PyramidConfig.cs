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
	public class PyramidConfig : XmlManager<PyramidConfig>
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
	}
}
