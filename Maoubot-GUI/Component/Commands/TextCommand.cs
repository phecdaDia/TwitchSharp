using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchSharp.EventArguments;
using System.Runtime.Serialization;
using TwitchSharp.Components;

namespace Maoubot_GUI.Component.Commands
{
	[DataContract(IsReference=true)]
	public class TextCommand : ChatCommand
	{
		[DataMember]
		public String Output { get; set; }

		// Non-serializable


		public TextCommand(String Command, String Output, Permission Permission = Permission.Everybody, int Timeout = 10)
			: base (Command, Timeout, Permission)
		{
			this.Output = Output;
		}

		public String Format(CommandExecuteEventArgs e)
		{
			return Format(Output, e);
		}

		public override string Execute(Maoubot mb, CommandExecuteEventArgs e)
		{
			if (!MayExecute(e.Permission)) return String.Empty;
			return Format(Output, e);
		}
	}
}
