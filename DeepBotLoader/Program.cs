using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepBotLoader
{
	/// <summary>
	/// Allows you to deflate Deepbots users.bin if you need it.
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			if (!File.Exists(@"users.bin"))
			{
				Console.WriteLine("Unable to find file.");
				Console.WriteLine("Make sure to place it into the same folder!");
				Console.WriteLine("");
				Console.WriteLine("PRESS [ENTER] TO EXIT");
				Console.ReadLine();
				return;

			}
			int i = 0;
			while (i<0x100)
			{
				try
				{
					byte[] t = File.ReadAllBytes(@"users.bin");
					byte[] o = Decompress(t, i);
					if (o.Length > 10)
					{
						File.WriteAllBytes(@"users2.bin", o);
						Console.WriteLine("FOUND OFFSET: {0}", i);
						break;
					}
					Console.WriteLine("Failed: {0:X}", i);
					i++;

				} catch (Exception)
				{
					Console.WriteLine("Failed: {0:X}", i);
					i++;
				}
			}
			Console.WriteLine("PRESS [ENTER] TO EXIT");
			Console.ReadLine();
		}
		public static byte[] Compress(byte[] Data)
		{
			List<byte> Adler32 = BitConverter.GetBytes(CalculateAdler32(Data)).ToList();
			Adler32.Reverse();
			using (MemoryStream ms = new MemoryStream())
			{
				using (DeflateStream gs = new DeflateStream(ms, CompressionMode.Compress))
				{
					gs.Write(Data, 0, Data.Length);

				}

				List<byte> lData = ms.ToArray().ToList();
				// Add a zlib header. 

				lData.InsertRange(0, new byte[] { 0x78, 0x9C }); // I'll add a different header generation later

				// Add ADLER32
				lData.AddRange(Adler32);


				return lData.ToArray();
			}
		}
		public static byte[] Decompress(byte[] Data, int Offset = 0)
		{
			using (MemoryStream ms = new MemoryStream(Data))
			{
				MemoryStream msInner = new MemoryStream();

				// Read past the first two bytes of the zlib header
				ms.Seek(Offset, SeekOrigin.Begin);


				using (DeflateStream z = new DeflateStream(ms, CompressionMode.Decompress))
				{
					z.CopyTo(msInner);

				}
				return msInner.ToArray();
			}
		}
			
		private static readonly UInt16 MOD_ADLER = 65521;
		private static readonly UInt32 STANDART_ADLER = 0x00000001;

		public static UInt32 CalculateAdler32(UInt32 Adler, byte[] Data, UInt32 Position = 0, Int32 Length = -1)
		{
			// Validating args
			if (Position >= Data.Length) throw new IndexOutOfRangeException();
			if (Length < 0) Length = (int)(Data.Length - Position);

			UInt32 s1 = (Adler & 0xffff) | 0;
			UInt32 s2 = ((Adler >> 16) & 0xffff) | 0;

			for (int n = 0; n < Length; n++)
			{
				s1 = (s1 + Data[Position + n]) % MOD_ADLER;
				s2 = (s1 + s2) % MOD_ADLER;
			}

			return (s1 | (s2 << 16)) | 0;

		}

		public static UInt32 CalculateAdler32(byte[] Data)
		{
			return CalculateAdler32(STANDART_ADLER, Data);
		}
	}
}
