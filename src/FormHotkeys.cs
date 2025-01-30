using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Melodorium
{
	public partial class FormHotkeys : Form
	{
		private bool _updatingValues = true;

		public FormHotkeys()
		{
			InitializeComponent();
			InpEnable.Checked = Program.Settings.HotkeyEnabled;
			InpShow.Text = Program.Hotkeys.ShowStr;
			InpPlay.Text = Program.Hotkeys.PlayStr;
			InpStop.Text = Program.Hotkeys.StopStr;
			InpNext.Text = Program.Hotkeys.NextStr;
			InpPrev.Text = Program.Hotkeys.PrevStr;
			_updatingValues = false;
		}

		private void FormHotkeys_Shown(object sender, EventArgs e)
		{
			Program.Hotkeys.ChangingHotkeys = true;
		}

		private void FormHotkeys_FormClosed(object sender, FormClosedEventArgs e)
		{
			Program.Hotkeys.ChangingHotkeys = false;
		}

		private void BtnReset_Click(object sender, EventArgs e)
		{
			_updatingValues = true;
			var def = new Settings();
			Program.Settings.HotkeyEnabled = def.HotkeyEnabled;
			Program.Settings.HotkeyShow = def.HotkeyShow;
			Program.Settings.HotkeyPlay = def.HotkeyPlay;
			Program.Settings.HotkeyStop = def.HotkeyStop;
			Program.Settings.HotkeyNext = def.HotkeyNext;
			Program.Settings.HotkeyPrev = def.HotkeyPrev;
			Program.Settings.Save();
			Program.Hotkeys.UpdateHotkeysBySettings();
		}

		private void InpEnable_CheckedChanged(object sender, EventArgs e)
		{
			if (_updatingValues) return;
			Program.Settings.HotkeyEnabled = InpEnable.Checked;
			Program.Settings.Save();
			if (Program.Settings.HotkeyEnabled)
				Program.Hotkeys.Register();
			else
				Program.Hotkeys.Unregister();
		}

		private void InpShow_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		private void InpShow_KeyDown(object sender, KeyEventArgs e)
		{
			Program.Hotkeys.UpdateShow(e);
			InpShow.Text = Program.Hotkeys.ShowStr;
		}

		private void InpPlay_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		private void InpPlay_KeyDown(object sender, KeyEventArgs e)
		{
			Program.Hotkeys.UpdatePlay(e);
			InpPlay.Text = Program.Hotkeys.PlayStr;
		}

		private void InpStop_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		private void InpStop_KeyDown(object sender, KeyEventArgs e)
		{
			Program.Hotkeys.UpdateStop(e);
			InpStop.Text = Program.Hotkeys.StopStr;
		}

		private void InpNext_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		private void InpNext_KeyDown(object sender, KeyEventArgs e)
		{
			Program.Hotkeys.UpdateNext(e);
			InpNext.Text = Program.Hotkeys.NextStr;
		}

		private void InpPrev_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		private void InpPrev_KeyDown(object sender, KeyEventArgs e)
		{
			Program.Hotkeys.UpdatePrev(e);
			InpPrev.Text = Program.Hotkeys.PrevStr;
		}
	}
}
