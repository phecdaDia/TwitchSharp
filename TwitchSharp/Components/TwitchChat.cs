using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TwitchSharp.Components
{
	public class Chatters
	{
		public List<string> moderators { get; set; }
		public List<string> staff { get; set; }
		public List<string> admins { get; set; }
		public List<string> global_mods { get; set; }
		public List<string> viewers { get; set; }
	}

	public class TwitchChat
	{
		public int chatter_count { get; set; }
		public Chatters chatters { get; set; }

		public String Channel;

		public TwitchChat(String Channel)
		{
			while (!char.IsLetterOrDigit(Channel.FirstOrDefault())) Channel.Substring(1);
			this.Channel = Channel;
		}

		public void RefreshChatters()
		{
			WebClient wc = new WebClient();
			String json = wc.DownloadString(String.Format(@"http://tmi.twitch.tv/group/user/{0}/chatters", Channel));
			JsonConvert.PopulateObject(json, this);
			
        }
	}
}
