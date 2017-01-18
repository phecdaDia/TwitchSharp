using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchSharp.EventArguments;
using System.Runtime.Serialization;
using TwitchSharp.Components;
using Maoubot_GUI.Window;

namespace Maoubot_GUI.Component.Commands
{
	[DataContract(IsReference=true)]
	public class TextCommand : ChatCommand
	{
		[DataMember]
		public String Output { get; protected set; }

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

		public override string GetHelp(Maoubot mb, String SubCommand = "")
		{
			return String.Format("{0}{1}", mb.Tcb.CommandChar, this.Command);
		}

		internal void Update(string Output, Permission Permission, int Timeout)
		{
			this.Output = Output;
			this.Permission = Permission;
			this.Timeout = Timeout;
		}

		public void Update(String Output)
		{
			this.Output = Output;
		}
	}
}
