using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchSharp.EventArguments
{
    public class LoginCompletedEventArgs : EventArgs
    {
        public String Nick { get; }
        public String OAuth { get; }

        public LoginCompletedEventArgs(String Nick, String OAuth)
        {
            this.Nick = Nick;
            this.OAuth = OAuth;
        }
    }
}
