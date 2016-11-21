using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchSharp.EventArguments
{
    public class ChannelJoinedEventArgs : EventArgs
    {
        public String Channel { get; }

        public ChannelJoinedEventArgs(String Channel)
        {
            this.Channel = Channel;
        }
    }
}
