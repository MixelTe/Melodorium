using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melodorium
{
	internal class Hotkeys
	{
		public bool ChangingHotkeys = false;
		private readonly Hotkey _show = new();
		private readonly Hotkey _play = new();
		private readonly Hotkey _stop = new();
		private readonly Hotkey _next = new();
		private readonly Hotkey _prev = new();

		public string ShowStr => _show.ToString();
		public string PlayStr => _play.ToString();
		public string StopStr => _stop.ToString();
		public string NextStr => _next.ToString();
		public string PrevStr => _prev.ToString();

		public void UpdateShow(KeyEventArgs e) => UpdateHotkey(_show, ref Program.Settings.HotkeyShow, e);
		public void UpdatePlay(KeyEventArgs e) => UpdateHotkey(_play, ref Program.Settings.HotkeyPlay, e);
		public void UpdateStop(KeyEventArgs e) => UpdateHotkey(_stop, ref Program.Settings.HotkeyStop, e);
		public void UpdateNext(KeyEventArgs e) => UpdateHotkey(_next, ref Program.Settings.HotkeyNext, e);
		public void UpdatePrev(KeyEventArgs e) => UpdateHotkey(_prev, ref Program.Settings.HotkeyPrev, e);

		public Hotkeys()
		{
			_show.Pressed += Show_Pressed;
			_play.Pressed += Play_Pressed;
			_stop.Pressed += Stop_Pressed;
			_next.Pressed += Next_Pressed;
			_prev.Pressed += Prev_Pressed;
			UpdateHotkeysBySettings(register: false);
		}

		public void UpdateHotkeysBySettings(bool register = true)
		{
			Unregister();
			_show.SetHotkey(Program.Settings.HotkeyShow);
			_play.SetHotkey(Program.Settings.HotkeyPlay);
			_stop.SetHotkey(Program.Settings.HotkeyStop);
			_next.SetHotkey(Program.Settings.HotkeyNext);
			_prev.SetHotkey(Program.Settings.HotkeyPrev);
			if (register)
				Register();
		}

		public void Register()
		{
			if (!Program.Settings.HotkeyEnabled) return;
			Unregister();

			TryRegister(_show);
			TryRegister(_play);
			TryRegister(_stop);
			TryRegister(_next);
			TryRegister(_prev);
		}

		private void TryRegister(Hotkey hotkey)
		{
			if (!hotkey.TryRegister())
				Program.Manager.ShowBalloonTip($"Can't register hotkey: {hotkey}", ToolTipIcon.Error);
		}

		public void Unregister()
		{
			_show.TryUnregister();
			_play.TryUnregister();
			_stop.TryUnregister();
			_next.TryUnregister();
			_prev.TryUnregister();
		}

		private void Show_Pressed(object? sender, EventArgs e)
		{
			if (ChangingHotkeys) return;
			if (Program.Player.Visible)
			{
				Program.Player.Hide();
			}
			else
			{
				Program.Player.Show();
				Program.Player.Activate();
			}
		}

		private void Play_Pressed(object? sender, EventArgs e)
		{
			if (ChangingHotkeys) return;
			Program.Player.PlayerPlay();
		}

		private void Stop_Pressed(object? sender, EventArgs e)
		{
			if (ChangingHotkeys) return;
			Program.Player.PlayerStop();
		}

		private void Next_Pressed(object? sender, EventArgs e)
		{
			if (ChangingHotkeys) return;
			Program.Player.PlayNext();
		}

		private void Prev_Pressed(object? sender, EventArgs e)
		{
			if (ChangingHotkeys) return;
			Program.Player.PlayPrev();
		}

		private void UpdateHotkey(Hotkey hotkey, ref Keys settingField, KeyEventArgs e)
		{
			hotkey.TryUnregister();
			hotkey.KeyCode = e.KeyCode;
			hotkey.Shift = e.Shift;
			hotkey.Control = e.Control;
			hotkey.Alt = e.Alt;
			if (!hotkey.TryRegister())
				Program.Manager.ShowBalloonTip($"Can't register hotkey: {hotkey}", ToolTipIcon.Error);
			settingField = e.KeyData;
			Program.Settings.Save();
		}
	}
}
