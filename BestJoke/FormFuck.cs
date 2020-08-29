using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestJoke
{
	public partial class FormFuck : Form
	{
		Random rnd = new Random();

		public FormFuck()
		{
			InitializeComponent();
		}

		private void FormFuck_Load(object sender, EventArgs e)
		{
			Size resolution = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;

			this.Location = new Point(rnd.Next(0, resolution.Width), rnd.Next(0, resolution.Height));
		}
	}
}
