using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maoubot_GUI.Dialog
{
	public abstract class AbstractDialog<T> : Form
	{
		public T Result;

		protected Button CloseButton;

		public AbstractDialog(String Title, int Width, int Size)
			: base()
		{
			this.Text = Title;
			this.Width = Width;
			this.Height = Height;

			this.CloseButton = new Button();

			CloseButton.DialogResult = DialogResult.OK;
			this.AcceptButton = CloseButton;
			CloseButton.Click += (s, e) => { SetValue(); };

			CreateComponents();
		}

		protected abstract void CreateComponents();

		protected abstract void SetValue();

	}
}
