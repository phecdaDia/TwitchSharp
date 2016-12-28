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
	public class TextCommand
	{
		[DataMember]
		public String Command { get; set; }
		[DataMember]
		public String Output { get; set; }
		[DataMember]
		public Permission Permission { get; set; }
		[DataMember]
		public int CommandTimeout { get; set; }

		// Non-serializable
		[IgnoreDataMember]
		private DateTime LastExecution { get; set; }


		public TextCommand(String Command, String Output, Permission Permission = Permission.Everybody, int Timeout = 10)
		{
			this.Command = Command;
			this.Output = Output;
			this.Permission = Permission;
			this.CommandTimeout = Timeout;

			this.LastExecution = DateTime.MinValue;
		}

		public String Format(CommandExecuteEventArgs e)
		{
			String o = Output;
			o = o.Replace("%nick%", e.Nick);
			o = o.Replace("%time%", DateTime.Now.ToString());

			return o;
		}

		public bool MayExecute(Permission p)
		{
			if (p >= this.Permission)
			{
				if (p >= Permission.Moderator || (DateTime.Now - LastExecution).TotalSeconds > CommandTimeout)
				{
					this.LastExecution = DateTime.Now;
					return true;
				}
			}

			return false;
		}

	}
}
