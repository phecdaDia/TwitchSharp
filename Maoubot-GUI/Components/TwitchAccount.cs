using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Maoubot_GUI.Component
{
	[DataContract(IsReference = true)]
	public class TwitchAccount
	{
		[DataMember]
		public String Nick { get; set; }
		[DataMember]
		public String OAuth { get; set; }

		public TwitchAccount(String Nick, String OAuth)
		{
			this.Nick = Nick;
			this.OAuth = OAuth;
		}
	}
}
