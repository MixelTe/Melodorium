using Melodorium.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Melodorium
{
	internal class App : ApplicationContext
	{
		private readonly NotifyIcon _trayIcon;

		public App()
		{
			_trayIcon = new NotifyIcon()
			{
				Icon = Resources.AppIcon,
				ContextMenuStrip = new ContextMenuStrip()
				{
					Items = {
						new ToolStripMenuItem("Player (LMB)", null, (object? sender, EventArgs e) => OpenPlayer()),
						new ToolStripMenuItem("Manager", null, (object? sender, EventArgs e) => OpenManager()),
						new ToolStripMenuItem("Exit", null, Quit),
					}
				},
				Visible = true,
				Text = "Melodorium v" + Application.ProductVersion,
			};
			_trayIcon.Click += (object? sender, EventArgs e) =>
			{
				if (e is MouseEventArgs me && me.Button == MouseButtons.Left)
				{
					OpenPlayer();
				}
			};
			OpenManager();
		}

		public void CloseIcon()
		{
			_trayIcon.Visible = false;
		}

		private void OpenPlayer()
		{
			Program.Player.Show();
			Program.Player.Activate();
		}

		private void OpenManager()
		{
			Program.Manager.Show();
			Program.Manager.Activate();
		}

		private void Quit(object? sender, EventArgs e)
		{
			CloseIcon();
			Program.Player.CloseForm();
			Program.Manager.CloseForm();
			Application.Exit();
		}
	}
}
