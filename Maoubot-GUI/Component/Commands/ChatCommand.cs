using Maoubot_GUI.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TwitchSharp.Components;
using TwitchSharp.EventArguments;

namespace Maoubot_GUI.Component.Commands
{
	[DataContract(IsReference=true)]
	public abstract class ChatCommand
	{
		[DataMember]
		public String Command { get; protected set; }
		[DataMember]
		public int Timeout { get; protected set; }
		[DataMember]
		public Permission Permission { get; protected set; }
		[IgnoreDataMember]
		public DateTime LastExecution { get; set; }

		[IgnoreDataMember]
		public static readonly int MAX_MESSAGE_LENGTH = 250;

		public ChatCommand(String Command, int Timeout, Permission Permission = Permission.Everybody)
		{
			this.Command = Command;
			this.Timeout = Timeout;
			this.Permission = Permission;
			this.LastExecution = DateTime.MinValue;
		}

		public static String Format(String Input, CommandExecuteEventArgs e, params Object[] format)
		{
			String LastIteration = Input;
			int Depth = 0;
			do
			{
				Depth++;
				LastIteration = Input;
				Input = String.Format(Input, format);

				Input = Input.Replace("%nick%", e.Nick);
				Input = Input.Replace("%name%", e.Nick);

				Input = Input.Replace("%permission%", e.Permission.ToString());

				Input = Input.Replace("%turbo%", e.IsTurbo.ToString());

				Input = Input.Replace("%time%", DateTime.Now.ToString());

				Input = Input.Replace("%cargs%", String.Join(" ", e.CommandArgs));

				Input = Input.Replace("%noma-brainpower%", @"O-oooooooooo AAAAE-A-A-I-A-U- JO-oooooooooooo AAE-O-A-A-U-U-A- E-eee-ee-eee AAAAE-A-E-I-E-A- JO-ooo-oo-oo-oo EEEEO-A-AAA-AAAA﻿");

				// replace "tag[/w+]" to the e.GetSafeTag(/w+)
				Regex TagRegex = new Regex(@"%tag\[[\w|\-]+\]%");
				MatchCollection TagRegexCollection = TagRegex.Matches(Input);
				foreach (Match Match in TagRegexCollection)
				{
					String Result = Match.Value;
					if (!Result.Substring(1, Result.Length-2).Contains("%")) // Make sure it isn't a layered tag ( Like: %tag[%cArgs%]% )
					{
						String TagName = e.GetSafeTag(Result.Substring(5, Result.Length - 7));
						Input = Input.Replace(Result, TagName);
					}
				}
			}
			while (LastIteration != Input && !(Depth >= 10));

			if (Input.Length >= MAX_MESSAGE_LENGTH)
			{
				Console.WriteLine("String cut, Length: {0}", Input.Length);
				Input = Input.Substring(0, MAX_MESSAGE_LENGTH);
			}

			return Input;
		}

		public Boolean MayExecute(Permission RequestedPermission)
		{
			if (RequestedPermission >= Permission)
			{
				if (RequestedPermission >= Permission.Moderator || (DateTime.Now - LastExecution).TotalSeconds > Timeout)
				{
					this.LastExecution = DateTime.Now;
					return true;
				}
			}

			return false;
		}

		public abstract String Execute(Maoubot mb, CommandExecuteEventArgs e);

		public abstract String GetHelp(Maoubot mb, String SubCommand = "");


	}
}
