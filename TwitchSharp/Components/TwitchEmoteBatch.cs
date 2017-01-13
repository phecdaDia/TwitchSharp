using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TwitchSharp.Components
{
	[DataContract(IsReference=true)]
	public class TwitchEmoteBatch
	{
		// How to do this stuff
		// split on \/
		// split on :
		// get room id as split[0]
		// split split[1] and get length?

		// Example input 137068:0-8/77870:10-18,20-28

		[DataMember]
		public TwitchEmote[] Emotes
		{
			get
			{
				return EmoteList.ToArray();
			}

			set
			{
				this.EmoteList = value.ToList();
			}
		}

		[IgnoreDataMember]
		public List<TwitchEmote> EmoteList { get; set; }

		[IgnoreDataMember]
		public Boolean HasEmotes { get { return Emotes.Length > 0; } }

		public TwitchEmoteBatch()
		{
			this.EmoteList = new List<TwitchEmote>();
		}

		public TwitchEmoteBatch(String EmoteInfoTag, String ChatMessage)
		{
			this.EmoteList = new List<TwitchEmote>();

			if (String.IsNullOrWhiteSpace(EmoteInfoTag)) return;

			String[] EmoteSplit = EmoteInfoTag.Split('/');
			foreach (String EmoteSplitIndex in EmoteSplit)
			{
				String[] EmoteIndexSplit = EmoteSplitIndex.Split(':');
				int EmoteId = int.Parse(EmoteIndexSplit.FirstOrDefault());
				String EmoteIndexText = EmoteIndexSplit.LastOrDefault();
				EmoteIndexSplit = EmoteIndexText.Split(',');
				String[] EmoteIndexInMessageSplit = EmoteIndexSplit.FirstOrDefault().Split('-'); // kill me
				int l0 = int.Parse(EmoteIndexInMessageSplit[0]);
				int l1 = int.Parse(EmoteIndexInMessageSplit[1]);
				int length = l1 - l0 + 1;
				String EmoteName = ChatMessage.Substring(l0, length);

				AddEmote(new TwitchEmote(EmoteName, EmoteId, EmoteIndexSplit.Length));
			}
		}

		public void AddEmote(TwitchEmote te)
		{
			int Index = ContainsEmote(te);

			//Console.Write("We found {0}:{1} at Index {2}\t", te.EmoteName, te.EmoteId, Index);
			
			if (Index != -1)
			{
				this.Emotes[Index].UseEmote(te.Amount);
				//Console.WriteLine("{0}:{1} x{2}", this.Emotes[Index].EmoteName, this.Emotes[Index].EmoteId, this.Emotes[Index].Amount);
			}
			else
			{
				//Console.WriteLine("This is a new emote!");
				EmoteList.Add(te);
				Sort();
			}
		}

		public void Fusion(TwitchEmoteBatch Teb)
		{
			if (!Teb.HasEmotes) return;

			//Console.WriteLine("FUSION! (TEB)");
			for (int j = 0; j < Teb.Emotes.Length; j++)
			{

				AddEmote(Teb.Emotes[j]);
			}
		}

		public int ContainsEmote(TwitchEmote te)
		{
			return ContainsEmote(te, 0, this.Emotes.Length-1);
		}

		public int ContainsEmote(TwitchEmote te, int l, int r)
		{
			if (l > r) return -1;

			int Index = (l + r) / 2;
			if (Index >= this.Emotes.Length || Index < 0) return -1;
            int Id = this.Emotes[Index].EmoteId;
			
			//Console.WriteLine("{0} < {1} < {2} [{3}]?", this.Emotes[l].EmoteId, Id, this.Emotes[r].EmoteId, te.EmoteId);

			if (te.EmoteId == Id) return Index;
			else if (te.EmoteId > Id) return ContainsEmote(te, Index + 1, r);
			else return ContainsEmote(te, l, Index - 1);
		}

		public void Sort()
		{
			this.Emotes = TwitchEmote.QuickSort(this.Emotes).ToArray();
		}
	}
}
