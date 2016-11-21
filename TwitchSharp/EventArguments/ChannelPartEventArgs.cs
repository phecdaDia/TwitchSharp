using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchSharp.EventArguments
{
    public class ChannelPartEventArgs : EventArgs
    {
        public String Channel { get; }
        public String Reason { get; }
        public ChannelPartEventArgs(String Channel, String Reason)
        {
            this.Channel = Channel;
            this.Reason = Reason;
        }
    }
}
