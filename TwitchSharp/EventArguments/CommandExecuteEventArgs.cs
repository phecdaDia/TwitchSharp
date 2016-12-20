using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchSharp.EventArguments
{
    public class CommandExecuteEventArgs : MessageReceivedEventArgs
    {
		public String Command { get; }
		public String[] CommandArgs { get; }

		public CommandExecuteEventArgs(String Message)
			: base(Message)
		{
			this.Command = this.Message.Split(' ').FirstOrDefault().Substring(1);
			List<String> t_ = this.Message.Split(' ').ToList();
			t_.RemoveAt(0);
			this.CommandArgs = t_.ToArray();
		}
    }
}
