using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TwitchSharp.Components
{
	[DataContract(IsReference=true)]
	public class TwitchEmote
	{
		[DataMember]
		public int EmoteId { get; set; }
		[DataMember]
		public String EmoteName { get; set; }
		[DataMember]
		public int Amount { get; private set; }

		public TwitchEmote(String EmoteName, int EmoteId, int Amount)
		{
			this.EmoteName = EmoteName;
			this.EmoteId = EmoteId;
			this.Amount = Amount;
		}

		public void UseEmote(int Amount = 1)
		{
			this.Amount += Amount;
		}

		public static IEnumerable<TwitchEmote> SortByAmount(IEnumerable<TwitchEmote> i)
		{
			if (!i.Any())
				return i;
			return i.OrderBy(x => x.Amount).Reverse();
		}

		public override String ToString()
		{
			return String.Format("{0}:{1}:{2}", EmoteName, EmoteId, Amount);
		}
	}
}
