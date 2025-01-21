using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib.Mpeg;

namespace Melodorium
{
	internal class AudioPlayer : IDisposable
	{
		public event EventHandler<StoppedEventArgs>? TrackEnded;
		private readonly WaveOutEvent _outputDevice = new();
		private AudioFileReader? _fileReader;
		private string _curPath = "";
		private MusicFile? _file;
		private bool _changingTrack = false;
		private bool _disposing = false;

		public float Volume
		{
			get => _outputDevice.Volume;
			set => _outputDevice.Volume = value;
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
		public string PlaytimeDisplay => _fileReader == null ? "00:00" :
			$"{_fileReader.CurrentTime:mm\\:ss}/{_fileReader.TotalTime:mm\\:ss}";

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
		}

		public void Dispose()
		{
			_disposing = true;
			_outputDevice.Stop();
		}

		public void Play()
		{
			if (_file == null) return;
			Play(_file);
		}
		public void Play(MusicFile file)
		{
			_file = file;

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
			_outputDevice.Play();
		}

		public void Pause()
		{
			_outputDevice.Pause();
		}

		public void Stop()
		{
			_changingTrack = true;
			_outputDevice.Stop();
			_fileReader?.Dispose();
			_fileReader = null;
			_changingTrack = false;
		}

		/// <returns>Is audio playing</returns>
		public bool PlayPause()
		{
			if (_file == null) return false;
			return PlayPause(_file);
		}
		/// <returns>Is audio playing</returns>
		public bool PlayPause(MusicFile file)
		{
			if (_outputDevice.PlaybackState == PlaybackState.Playing && _curPath == file.FPath)
			{
				Pause();
				return false;
			}
			else
			{
				Play(file);
				return true;
			}
		}
	}
}
