using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchSharp.Components
{
	public class TwitchEmoteBatch
	{
		// How to do this stuff
		// split on \/
		// split on :
		// get room id as split[0]
		// split split[1] and get length?

		// Example input 137068:0-8/77870:10-18

		public TwitchEmote[] Emotes { get; }

		public TwitchEmoteBatch(String EmoteInfoTag, String ChatMessage)
		{
			List<TwitchEmote> e = new List<TwitchEmote>();

			String[] EmoteSplit = EmoteInfoTag.Split('/');
			foreach (String EmoteString in EmoteSplit)
			{
				TwitchEmote te = new TwitchEmote(EmoteString, ChatMessage);
				Boolean ContainsEmote = false;
				foreach (TwitchEmote te_ in e)
				{
					if (te_.EmoteName == te.EmoteName)
					{
						ContainsEmote = true;
						break;
					}
				}

				if (!ContainsEmote)
				{
					e.Add(te);
				}
			}
		}
	}
}
