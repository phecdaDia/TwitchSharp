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
		public String Command;
		[DataMember]
		public int Timeout;
		[DataMember]
		public Permission Permission;
		[IgnoreDataMember]
		public DateTime LastExecution { get; set; }

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
			do
			{
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
				Regex TagRegex = new Regex(@"%tag\[\w+\]%");
				MatchCollection TagRegexCollection = TagRegex.Matches(Input);
				foreach (Match Match in TagRegexCollection)
				{
					String Result = Match.Value;
					if (!Result.Contains("%")) // Make sure it isn't a layered tag ( Like: %tag[%cArgs%]% )
					{
						String TagName = e.GetSafeTag(Result.Substring(5, Result.Length - 7));
						Input = Input.Replace(Result, TagName);
					}
				}
			}
			while (LastIteration != Input);


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


	}
}
