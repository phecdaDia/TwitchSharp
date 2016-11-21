using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchSharp.EventArguments
{
    public class CommandExecuteEventArgs : EventArgs
    {
        public String Channel { get; }
        public String Nick { get; }
        public String Command { get; }
        public String[] CommandArgs { get; }
        public String cArgs { get; }
		
		public bool Whisper { get; }

        public CommandExecuteEventArgs(String Channel, String Nick, String Message, bool Whisper = false)
        {

            Message = Message.Substring(1);
            this.Channel = Channel;
			this.Whisper = Whisper;
            this.Nick = Nick;
            
            List<String> MsgP = Message.Split(' ').ToList();
            this.Command = MsgP[0];
            MsgP.RemoveAt(0);
            this.CommandArgs = MsgP.ToArray();
            this.cArgs = String.Join(" ", this.CommandArgs);
        }
    }
}
