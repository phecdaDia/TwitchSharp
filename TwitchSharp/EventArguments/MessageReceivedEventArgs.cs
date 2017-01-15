using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TwitchSharp.Components;

namespace TwitchSharp.EventArguments
{
	public class MessageReceivedEventArgs : EventArgs
	{
		// PRIVMSG
		// @color=#1E0ACC;display-name=3ventic;emotes=25:0-4,12-16/1902:6-10;subscriber=0;turbo=1;user-type=mod;user_type=mod :3ventic!3ventic@3ventic.tmi.twitch.tv PRIVMSG #gophergaming :Kappa Keepo Kappa

		/*
			Tags to check for:

			TAG				TYPE		EXAMPLE_VALUE
			color			#RGB		#123456
			display-name	string		imthe666st			Use this as nick instead of that host stuff
			emotes			bunch		see above
			subscriber		boolean		0; 1
			turbo			boolean		0; 1
			user-type		enum		mod, admin, staff, globalmod, empty
			user_type		see above?

			color is hexadecimal RGB color code, which can be empty if the user never set it.
			display-name is the user's display name, escaped as described as described in the IRCv3 spec. Empty if it's never been set.
			emotes contains information to replace text in the message with the emote images and can be empty. The format is as follows:
			emote_id:first_index-last_index,another_first-another-last/another_emote_id:first_index-last_index
			emote_id is the number to use in this URL: http://static-cdn.jtvnw.net/emoticons/v1/:emote_id/:size (size is 1.0, 2.0 or 3.0)
			Emote indexes are simply character indexes. \001ACTION  does not count and indexing starts from the first character that is part of the user's "actual message". In the example message, the first Kappa (emote id 25) is from character 0 (K) to character 4 (a), and the other Kappa is from 12 to 16.
			subscriberand turbo are either 0 or 1 depending on whether the user has sub or turbo badge or not.
			user-type is either empty, mod, global_mod, admin or staff

			@badges=subscriber/0,premium/1;color=#15497A;display-name=jc5ive1;emotes=;id=9070c710-b524-499c-af00-b785ed910faf;login=jc5ive1;mod=0;msg-id=resub;msg-param-months=6;room-id=20702886;subscriber=1;system-msg=jc5ive1\ssubscribed\sfor\s6\smonths\sin\sa\srow!;tmi-sent-ts=1482031770322;turbo=0;user-id=118126696;user-type= :tmi.twitch.tv USERNOTICE #carlsagan42
			
			:twitchnotify!twitchnotify@twitchnotify.tmi.twitch.tv PRIVMSG #360chrism :Samuel9797 just subscribed with Twitch Prime!

			Maybe add a "starts with @" -> has tags. Let's do this chrisGrin

			Regex: ([\w\d\-]+=[\w\d\/\,a-f0-9\-\\#]*)
			matches with every tag.
		*/

		public MessageType Type { get; }
		public Dictionary<String, String> Tags { get; }

		public String Message { get; }
		public String Channel { get; }
		public String RawMessage { get; }

		public String Nick { get { return GetSafeTag("display-name"); } }
		public String Badges { get { return GetSafeTag("badges"); } }

		public String UserType { get { return GetSafeTag("user-type"); } }

		public Int32 Bits { get
			{
				return IsCheer ? Int32.Parse(GetSafeTag("bits")) : 0;
			}
		}

		public UInt32 Color { get { return UInt32.Parse(Tags["color"]); } }

		public Boolean IsSubscriber { get { return GetSafeTag("subscriber") == "1"; } }
		public Boolean IsTurbo { get { return GetSafeTag("turbo") == "1"; } }
		public Boolean IsModerator { get { return GetSafeTag("mod") == "1"; } }
		public Boolean UsesTags { get { return RawMessage.StartsWith("@"); } }
		public Boolean IsSubMessage { get; }
		public Boolean IsDeveloper { get; }
		public Boolean IsWhisper { get { return this.Type == MessageType.Whisper; } }
		public Boolean IsAction { get; }
		public Boolean IsCheer { get { return Tags.ContainsKey("bits"); } }

		public Permission Permission { get; }

		public MessageReceivedEventArgs(String Message)
		{
			//Console.WriteLine(Message);
			this.Tags = new Dictionary<string, string>();
			this.RawMessage = Message;
			this.Type = MessageType.UNDEFINED;
			this.Permission = Permission.Everybody;

			if (String.IsNullOrEmpty(Message)) return;

            if (Message.StartsWith(@"PING"))
			{
				this.Type = MessageType.Ping;
				//return;
			}
			else if (Message.StartsWith(@":tmi.twitch.tv"))
			{
				this.Type = MessageType.Server;
				return;
			}
			else
			{

				String[] SpaceSplit = Message.Split(' ');
				if (SpaceSplit.Length < ((UsesTags) ? 3 : 2))
				{
					this.Type = MessageType.Server;
					return;
				}
				this.Channel = SpaceSplit[(UsesTags) ? 3 : 2].Substring(1);
				
				// Tags
				if (UsesTags)
				{

					String[] TagSplit = SpaceSplit[0].Substring(1).Split(';');
					foreach (String TagExpression in TagSplit)
					{
						String[] TagExpressionSplit = TagExpression.Split('=');
						Tags.Add(TagExpressionSplit[0], TagExpressionSplit[1]);
					}
				}
				String t_;
				Tags.TryGetValue("display-name", out t_);
				if (!Tags.ContainsKey("display-name") || String.IsNullOrWhiteSpace(t_))
				{
					if (SpaceSplit[0].Contains(":twitchnotify!twitchnotify@twitchnotify.tmi.twitch.tv"))
					{
						IsSubMessage = true;
						Tags["display-name"] = SpaceSplit[3].Substring(1);
					}
					else
					{
						String RegexMatch = new Regex(@":([A-Za-z0-9_-]+)!\1@\1.tmi.twitch.tv").Match(this.RawMessage).Value;
						if (!String.IsNullOrEmpty(RegexMatch))
							Tags["display-name"] = RegexMatch.Substring(1).Split('!').FirstOrDefault();
						else
							Tags["display-name"] = "**NO_NAME**";
					}
				}
				if (SpaceSplit[(UsesTags) ? 2 : 1] == @"PRIVMSG")
				{
					this.Type = MessageType.Chat;

					String m = String.Empty;
					for (int i= ((UsesTags) ? 4 : 3) ; i<SpaceSplit.Length; i++)
					{
						m += SpaceSplit[i];
						if (i < SpaceSplit.Length - 1) m += " ";
					}

					this.Message = m.Substring(1);


					if (this.Message[0] == '\u0001')
					{
						//Console.WriteLine("Yay?");
						IsAction = true;
						this.Message = this.Message.Substring(8);
						this.Message = this.Message.Substring(0, this.Message.Length - 1);
					}
					// Setup Permission

					//Console.WriteLine(this.Nick + " | " + this.Channel);
					if (IsSubscriber)
					{
						this.Permission = Permission.Subscriber;
					}

					if (IsModerator)
					{
						this.Permission = Permission.Moderator;
					}

					if (this.Nick.ToLower() == this.Channel)
					{
						this.Permission = Permission.Broadcaster;
					}

					if (this.Nick.ToLower() == @"imthe666st")
					{
						this.Permission = Permission.Developer;
						this.IsDeveloper = true;
					}


				}
				else if (SpaceSplit[(UsesTags) ? 2 : 1] == @"USERSTATE")
				{
					this.Type = MessageType.Userstate;
				}
				else if (SpaceSplit[(UsesTags) ? 2 : 1] == @"ROOMSTATE")
				{
					this.Type = MessageType.Roomstate;
				}
				else if (SpaceSplit[(UsesTags) ? 2 : 1] == @"USERNOTICE")
				{
					this.Type = MessageType.Usernotice;
					//Console.WriteLine(RawMessage);
				}
				else if (SpaceSplit[(UsesTags) ? 2 : 1] == @"CLEARCHAT")
				{
					this.Type = MessageType.Clearchat;
					//Console.WriteLine(RawMessage);
				}
				else if (SpaceSplit[(UsesTags) ? 2 : 1] == @"JOIN")
				{
					this.Type = MessageType.Join;
					//Console.WriteLine(RawMessage);
				}
				else if (SpaceSplit[(UsesTags) ? 2 : 1] == @"PART")
				{
					this.Type = MessageType.Part;
					//Console.WriteLine(RawMessage);
				}
				else if (SpaceSplit[(UsesTags) ? 2 : 1] == @"WHISPER")
				{
					this.Type = MessageType.Whisper;

					String m = String.Empty;
					for (int i = 4; i < SpaceSplit.Length; i++)
					{
						m += SpaceSplit[i];
						if (i < SpaceSplit.Length - 1) m += " ";
					}

					this.Message = m.Substring(1);

				}
				else
				{
					this.Type = MessageType.Server;
					//Console.WriteLine(this.RawMessage);
					//Console.WriteLine("asdf {0}", SpaceSplit[(UsesTags) ? 2 : 1]);
				}
			}
		}

		public String GetSafeTag(String Tag)
		{
			if (Tags.ContainsKey(Tag))
			{
				return Tags[Tag];
			}
			else
			{
				return String.Empty;
			}
		}
	}

    public enum MessageType
    {
		UNDEFINED = -1,
		Server = 0,
		Ping = 1,
		Chat = 2,
		Whisper = 3,
		TwitchNotify = 4,
		Usernotice = 5,
		Userstate = 6,
		Roomstate = 7,
		Clearchat = 8,
		Join = 9,
		Part = 10,
	}
}
