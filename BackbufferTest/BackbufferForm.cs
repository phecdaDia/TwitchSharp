using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;

namespace BackbufferTest
{
	public class BackbufferForm : Form
	{

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool AllocConsole();

		public BackbufferForm()
		{
			AllocConsole();
			this.Width = 640;
			this.Height = 480;

			this.DoubleBuffered = true;

			last = System.DateTime.Now.Millisecond;
			this.Paint += BackbufferForm_Paint;
			
		}


		private int TotalFrames = 0;
		private long last = 0;
		private void BackbufferForm_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			Random r = new Random();
			Pen p = new Pen(Color.Black);

			for (int i=0; i<1; i++)
			{
				g.DrawLine(p, new Point(r.Next(Width), r.Next(Height)), new Point(r.Next(Width), r.Next(Height)));
			}

			while (DateTime.Now.Millisecond - last < 16)
			{
				Thread.Sleep(20);
			}


			last = DateTime.Now.Millisecond;
			TotalFrames++;
			Console.WriteLine(TotalFrames);
			this.Refresh();

		}
	}
}
