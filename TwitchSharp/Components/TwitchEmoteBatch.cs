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

		public List<TwitchEmote> Emotes { get; }

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
						te_.UseEmote();
						Console.WriteLine(te_.Amount);
						break;
					}
				}

				if (!ContainsEmote)
				{
					e.Add(te);
				}
			}

			Emotes = e;
		}

		public void AddEmote(String EmoteString, String ChatMessage)
		{
			AddEmote(new TwitchEmote(EmoteString, ChatMessage));
		}

		public void AddEmote(TwitchEmote Emote)
		{
			Boolean ContainsEmote = false;
			foreach (TwitchEmote te_ in this.Emotes)
			{
				if (te_.EmoteName == Emote.EmoteName)
				{
					ContainsEmote = true;
					te_.UseEmote(Emote.Amount);
					Console.WriteLine(te_.Amount);
					break;
				}
			}

			if (!ContainsEmote)
			{
				Emotes.Add(Emote);
			}
		}

		public void Fusion(TwitchEmoteBatch Teb)
		{
			foreach (TwitchEmote Emote in Teb.Emotes)
			{
				AddEmote(Emote);
			}
		}
	}
}
