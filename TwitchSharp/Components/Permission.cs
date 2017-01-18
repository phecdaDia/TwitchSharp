using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchSharp.Components
{
	public enum Permission
	{
		UNKNOWN = -1,
		Everybody = 0,
		Subscriber = 1,
		//Subscriber3 = 2,
		//Subscriber6 = 3,
		//Subscriber12 = 4,
		//Subscriber24 = 5,
		Moderator = 2,
		Broadcaster = 3,
		Developer = 4,

	}
}
