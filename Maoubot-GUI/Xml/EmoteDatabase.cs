using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TwitchSharp.Components;
using TwitchSharp.Utilities;

namespace Maoubot_GUI.Xml
{
	[DataContract(IsReference=true)]
	public class EmoteDatabase : XmlManager<EmoteDatabase>
	{
		[DataMember]
		public TwitchEmoteBatch TwitchEmotes { get; set; }

		protected override void Init()
		{
			if (TwitchEmotes == null) TwitchEmotes = new TwitchEmoteBatch();

			if (TwitchEmotes.HasEmotes) TwitchEmotes.Sort();
		}

		public void AddEmoteBatch(TwitchEmoteBatch Teb)
		{
			TwitchEmotes.Fusion(Teb);
		}

		public TwitchEmote GetMostUsed()
		{
			TwitchEmote TopEmote = null;
			foreach (TwitchEmote te in this.TwitchEmotes.Emotes)
			{
				if (te.Amount > (TopEmote?.Amount ?? -1))
				{
					TopEmote = te;
				}
			}
			return TopEmote;
		}

		public TwitchEmote GetEmoteById(int Id)
		{
			return this.TwitchEmotes.GetEmoteById(Id);
		}
	}
}
