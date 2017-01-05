using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchSharp.Components
{
	public class TwitchEmote
	{
		public String RoomId { get; }
		public String EmoteName { get; }

		public int Length { get; }

		public TwitchEmote(String EmoteString, String ChatMessage)
		{
			try
			{
				String[] s1 = EmoteString.Split(':');
				this.RoomId = s1.FirstOrDefault();
				s1 = s1[1].Split('-');
				int l0 = int.Parse(s1[0]);
				int l1 = int.Parse(s1[1]);
				this.Length = l1 - l0 + 1;

				this.EmoteName = ChatMessage.Substring(l0, Length);

				Console.WriteLine("New emote: {0} of room {1} [{2}]", EmoteName, RoomId, Length);
			} catch (Exception e)
			{
				if (String.IsNullOrEmpty(RoomId)) RoomId = "0";
			}
		}
	}
}
