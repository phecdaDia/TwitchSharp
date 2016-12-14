using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchSharp.EventArguments;
using System.Runtime.Serialization;

namespace Maoubot_GUI.Component
{
	[DataContract(IsReference=true)]
	public class TextCommand
	{
		[DataMember]
		public String Command { get; set; }
		[DataMember]
		public String Output { get; set; }

		public TextCommand(String Command, String Output)
		{
			this.Command = Command;
			this.Output = Output;
		}

		public String Format(CommandExecuteEventArgs e)
		{
			String o = Output;
			o = o.Replace("%nick%", e.Nick);
			o = o.Replace("%time%", DateTime.Now.ToString());

			return o;
		}

	}
}
