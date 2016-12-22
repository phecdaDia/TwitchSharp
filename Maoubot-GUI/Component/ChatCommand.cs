using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchSharp.Components;
using TwitchSharp.EventArguments;

namespace Maoubot_GUI.Component
{
	public abstract class ChatCommand
	{
		public String Command;

		protected int Timeout;

		protected Permission CommandPermission;

		protected DateTime LastExecution { get; set; }

		public ChatCommand(String Command, int Timeout, Permission Permission = Permission.Everybody)
		{
			this.Command = Command;
			this.Timeout = Timeout;
			this.CommandPermission = Permission;
			this.LastExecution = DateTime.MinValue;
		}

		protected bool MayExecute(Permission RequestedPermission)
		{
			if (RequestedPermission >= CommandPermission)
			{
				if (RequestedPermission >= Permission.Moderator || (DateTime.Now - LastExecution).TotalSeconds > Timeout)
				{
					this.LastExecution = DateTime.Now;
					return true;
				}
			}

			return false;
		}

		public abstract void Execute(Maoubot mb, CommandExecuteEventArgs e);


	}
}
