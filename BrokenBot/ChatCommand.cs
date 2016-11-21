using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokenBot
{
	class ChatCommand
	{
		public String Command;
		public Int32 Arguments;
		public PermissionLevel Permission;

		public String[] CommandData;

		public static Int32 MaxByteLength = 0x30;

		public ChatCommand(String Command, Int32 Arguments, PermissionLevel Permission = PermissionLevel.User, params String[] CommandData)
		{
			this.Command = Command;
			this.Arguments = Arguments;
			this.Permission = Permission;

			this.CommandData = CommandData;
		}

		public ChatCommand(String Command, Int32 Arguments, params String[] CommandData)
		{
			this.Command = Command;
			this.Arguments = Arguments;
			this.Permission = PermissionLevel.User;

			this.CommandData = CommandData;
		}

		public byte[] ToByteArray()
		{
			List<byte> Data = new List<byte>();

			Data.AddRange(Encoding.Unicode.GetBytes(this.Command));
			while (Data.Count < 0x20)
			{
				Data.Add(0x00);
			}

			Data.AddRange(BitConverter.GetBytes(Arguments));
			Data.Add((byte) Permission);

			while (Data.Count < 0x30)
			{
				Data.Add(0x00);
			}
			return Data.ToArray();
		}
	}

	public enum PermissionLevel
	{
		User		=	0x00,
		Moderator	=	0x01,
		Nobody		=	0xFF,

	}
}
