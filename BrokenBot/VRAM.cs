using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokenBot
{
	public class VRAM
	{
		private byte[] Memory;

		public VRAM(Int32 Size)
		{
			this.Memory = new byte[Size];
			for (int i = 0; i < Memory.Length; i++)
			{
				Memory[i] = 0;

			}
		}

		public byte GetByte(Int32 Addr)
		{
			return this.Memory[Addr];
		}

		public Int16 GetInt16(Int32 Addr)
		{
			Int16 d = 0;
			for (int i = 0; i < 2; i++)
			{
				d += (Int16)(this.Memory[Addr + i] << (8 * i));
			}
			return d;
		}

		public Int32 GetInt32(Int32 Addr)
		{
			Int32 d = 0;
			for (int i = 0; i < 4; i++)
			{
				d += (Int32)(this.Memory[Addr + i] << (8 * i));
			}
			return d;
		}

		public String GetString(Int32 Addr, Int32 Length)
		{
			Encoding e = Encoding.Unicode;
			return e.GetString(this.Memory, Addr, Length);
		}

		public void WriteByte(Int32 Addr, byte Data)
		{
			this.Memory[Addr] = Data;
		}

		public void WriteInt16(Int32 Addr, Int16 Data)
		{
			byte[] d = BitConverter.GetBytes(Data);
			for (int i = 0; i < d.Length; i++)
			{
				this.Memory[Addr + i] = d[i];
			}
		}

		public void WriteInt32(Int32 Addr, Int32 Data)
		{
			byte[] d = BitConverter.GetBytes(Data);
			for (int i = 0; i < d.Length; i++)
			{
				this.Memory[Addr + i] = d[i];
			}
		}

		public void WriteString(Int32 Addr, String Data, Int32 Length)
		{
			byte[] d = Encoding.Unicode.GetBytes(Data);
			for (int i = 0; i < Length; i++)
			{
				this.Memory[Addr+i] = (i<d.Length) ? d[i] : (byte) 0;
			}
		}

		public void WriteByteArray(Int32 Addr, byte[] Data, Int32 Length = -1, Int32 StartAddress = 0)
		{
			if (Length == -1) Length = Data.Length;

			for (int i = 0; i < Length; i++)
			{
				this.Memory[Addr + i] = Data[StartAddress + i];
			}
		}
	}
}
