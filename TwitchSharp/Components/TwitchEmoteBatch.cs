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
				String[] EmoteIndexInMessageSplit = EmoteIndexSplit.FirstOrDefault().Split('-');
				int l0 = int.Parse(EmoteIndexInMessageSplit[0]);
				int l1 = int.Parse(EmoteIndexInMessageSplit[1]);
				int length = l1 - l0 + 1;
				String EmoteName = ChatMessage.Substring(l0, length);

				AddEmote(new TwitchEmote(EmoteName, EmoteId, EmoteIndexSplit.Length));
			}
		}

		public void AddEmote(TwitchEmote te)
		{
			int Index = this.ContainsEmote(te);
			//Console.WriteLine(te.EmoteName + " | " + Index);

			if (Index != -1)
			{
				
				this.Emotes[Index].UseEmote(te.Amount);
				//Console.WriteLine("Using Emote: {0} - Amount: {1} Index: {2}", this.Emotes[Index].ToString(), te.Amount, Index);
				if (Index > 0)
				{
					if (this.Emotes[Index].Amount > this.Emotes[Index - 1].Amount)
					{
						int OldIndex = Index;
						while (Index > 0 && this.Emotes[OldIndex].Amount > this.Emotes[Index - 1].Amount)
						{
							Index--;
                        }
						TwitchEmote ek = this.Emotes[Index];
						this.EmoteList[Index] = this.Emotes[OldIndex];
						this.EmoteList[OldIndex] = ek;
						Console.WriteLine("Swapped {1} -> {2}\t{0}", this.Emotes[Index].ToString(), OldIndex, Index);
					}
				}
				return;
			}
			else
			{
				//Console.WriteLine("This is a new emote!");
				//Console.WriteLine("Adding emote: {0}", te.ToString());
				if (!HasEmotes)
				{
					this.EmoteList.Add(te);
					return;
				}
				int EmoteIndex = -1;
				int l = 0;
				int r = this.Emotes.Length - 1;
				do
				{
					EmoteIndex = (l + r) / 2;
					if (this.Emotes[l].Amount == this.Emotes[r].Amount) break;
					int Amount = this.Emotes[EmoteIndex].Amount;
					if (this.Emotes[l].Amount == Amount)
					{
						EmoteIndex = l;
						break;
					}
					else if (this.Emotes[r].Amount == Amount)
					{
						EmoteIndex = r;
						break;
					}
					else if (Amount > te.Amount)
					{
						l = EmoteIndex + 1;
					}
					else
					{
						r = EmoteIndex - 1;
					}

				} while (this.Emotes[EmoteIndex].Amount != te.Amount);
                if (this.Emotes.Length > 10) Console.WriteLine("Inserting {0} to position {1} | REF: {2}", te.ToString(), EmoteIndex, (EmoteIndex > -1) ? this.Emotes[EmoteIndex].ToString() : "None");
				if (EmoteIndex > -1) this.EmoteList.Insert(EmoteIndex, te);
				else this.EmoteList.Add(te);
			}
		}

		public void Fusion(TwitchEmoteBatch Teb)
		{
			//Console.WriteLine(this.Emotes.Length + " | " + Teb.Emotes.Length); // 843 | 0
			if (!Teb.HasEmotes) return;

			//Console.WriteLine("FUSION! (TEB)");
			for (int j = 0; j < Teb.Emotes.Length; j++)
			{
				this.AddEmote(Teb.Emotes[j]);
			}
		}

		public int ContainsEmote(TwitchEmote te)
		{
			for (int i = 0; i < this.Emotes.Length; i++)
			{
				if (this.Emotes[i].EmoteId == te.EmoteId) return i;
			}
			return -1;
		}

		public void Sort()
		{
			this.Emotes = TwitchEmote.SortByAmount(this.Emotes).ToArray();
		}

		public TwitchEmote GetEmoteById(int Id)
		{
			if (!HasEmotes) return null;
			return this.Emotes.Where(x => x.EmoteId == Id).FirstOrDefault();
		}

		//private TwitchEmote GetEmoteById(TwitchEmote[] e, int Id)
		//{
		//	// TODO: Binary quicksort search


		//	return null;
		//}
	}
}
