using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TagLib.Mpeg;

namespace Melodorium
{
	internal class AudioPlayer : IDisposable
	{
		public event EventHandler<EventArgs>? TrackEnded;
		private readonly WaveOutEvent _outputDevice = new();
		private readonly System.Timers.Timer _timer = new();
		private AudioFileReader? _fileReader;
		private string _curPath = "";
		private MusicFile? _file;
		private float _volume = 1;
		private bool _volumeUp = true;
		private bool _changingTrack = false;
		private bool _disposing = false;

		public bool IsPlaying { get => _outputDevice.PlaybackState == PlaybackState.Playing; }
		public float Volume
		{
			get => _volume;
			set { _volume = value; _outputDevice.Volume = value; }
		}
		public TimeSpan TimeCurrent
		{
			get => _fileReader == null ? TimeSpan.Zero : _fileReader.CurrentTime;
			set
			{
				if (_fileReader != null)
					_fileReader.CurrentTime = value;
			}
		}
		public double TimeNormalized
		{
			get => _fileReader == null ? 0 : _fileReader.CurrentTime / _fileReader.TotalTime;
			set
			{
				if (_fileReader != null)
					_fileReader.CurrentTime = _fileReader.TotalTime * value;
			}
		}
		public string CurtimeDisplay => _fileReader == null ? "00:00" :
			$"{_fileReader.CurrentTime:mm\\:ss}";
		public string PlaytimeDisplay => _fileReader == null ? "00:00" :
			$"{CurtimeDisplay}/{_fileReader.TotalTime:mm\\:ss}";

		public AudioPlayer()
		{
			_outputDevice.PlaybackStopped += (object? sender, StoppedEventArgs args) =>
			{
				if (_disposing)
				{
					_outputDevice.Dispose();
					_fileReader?.Dispose();
					_fileReader = null;
				}
				else if (!_changingTrack)
				{
					TrackEnded?.Invoke(this, args);
				}
			};
			_timer.Elapsed += Timer_Tick;
			_timer.Interval = 50;
			_timer.AutoReset = true;
		}

		public void Dispose()
		{
			_disposing = true;
			_outputDevice.Stop();
			_timer.Dispose();
		}

		public bool Play()
		{
			if (_file == null) return false;
			return Play(_file);
		}
		public bool Play(MusicFile file)
		{
			_file = file;
			try
			{
				if (_fileReader == null || _curPath != file.FPath)
				{
					_changingTrack = true;
					_outputDevice.Stop();
					_fileReader?.Dispose();
					_fileReader = new AudioFileReader(file.FPath);
					_curPath = file.FPath;
					_outputDevice.Init(_fileReader);
					_changingTrack = false;
				}
				if (_outputDevice.PlaybackState == PlaybackState.Stopped)
					_fileReader.CurrentTime = TimeSpan.Zero;
				if (_volumeUp)
					_outputDevice.Volume = 0;
				_volumeUp = true;
				_timer.Enabled = true;
				_outputDevice.Play();
				return true;
			}
			catch
			{
				_fileReader?.Dispose();
				_fileReader = null;
				return false;
			}
		}

		public void Pause()
		{
			_volumeUp = false;
			_timer.Enabled = true;
		}

		public void Stop()
		{
			_changingTrack = true;
			_outputDevice.Stop();
			_fileReader?.Dispose();
			_fileReader = null;
			_changingTrack = false;
		}

		public bool PlayPause()
		{
			if (_file == null) return false;
			return PlayPause(_file);
		}
		public bool PlayPause(MusicFile file)
		{
			if (_outputDevice.PlaybackState == PlaybackState.Playing && _volumeUp && _curPath == file.FPath)
			{
				Pause();
				return true;
			}
			else
			{
				return Play(file);
			}
		}

		private void Timer_Tick(object? sender, ElapsedEventArgs e)
		{
			const int fadeTime = 500;
			var v = _outputDevice.Volume;
			if (_volumeUp)
			{
				if (v < _volume)
					v += _volume / fadeTime * 50;
				if (v >= _volume)
				{
					v = _volume;
					_timer.Enabled = false;
				}
			}
			else
			{
				if (v > 0)
					v -= _volume / fadeTime * 50;
				if (v <= 0)
				{
					v = 0;
					_timer.Enabled = false;
					_volumeUp = true;
				}
			}
			_outputDevice.Volume = v;
			if (v == 0) _outputDevice.Pause();
		}
	}
}
