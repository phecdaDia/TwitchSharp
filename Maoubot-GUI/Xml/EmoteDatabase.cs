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
			TwitchEmotes.Sort();
		}

		public String GetEmoteById(int Id)
		{
			// do binary search or something. 
			return "Unimplemented";
		}
	}
}
