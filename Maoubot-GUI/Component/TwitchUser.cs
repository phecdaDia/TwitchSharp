using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Maoubot_GUI.Component
{
	[DataContract(IsReference=true)]
	public class TwitchUser
	{
		[DataMember]
		public String Username { get; private set; }
		[DataMember]
		public int MinutesWatched { get; private set; }
		[DataMember]
		public int Coins { get; private set; }

		public TwitchUser(String Username)
		{
			this.Username = Username;
			this.MinutesWatched = 0;
			this.Coins = 0;
		}

		public void AddWatchMinutes(int Amount = 1)
		{
			if (Amount <= 0) return;
			this.MinutesWatched += Amount;
			AddCoins(Amount);
		}

		public void AddCoins(int Amount = 1)
		{
			if (Amount <= 0) return;
			this.Coins += Amount;
		}

		public Boolean SpendCoins(int Amount)
		{
			if (Amount <= 0 || this.Coins < Amount) return false;
			this.Coins -= Amount;
			return true;
		}
	}
}
