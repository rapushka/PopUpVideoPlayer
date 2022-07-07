using System;
using DevExpress.Mvvm;
using System.Windows.Input;
using VideoPlayer.Models;

namespace VideoPlayer.ViewModels;
public class MainViewModel : ViewModelBase
{
	private string _path;

	public MainViewModel()
	{
		_path = string.Empty;
	}
	
	public event EventHandler PlayRequested;

	public string Path
	{
		get => _path;
		private set
		{
			_path = value;
			RaisePropertyChanged(() => Path);
		}
	}

	public ICommand OpenVideo
		=> new CommandDelegator<object>((x)
			=> DialogFileWindow());

	public ICommand Play
		=> new CommandDelegator<object>((x)
			=> PlayRequested(this, EventArgs.Empty));

	private void DialogFileWindow()
	{
		Microsoft.Win32.OpenFileDialog dialog = new()
		{
			FileName = "Video",
			DefaultExt = ".mp4",
			Filter = "Videos (.mp4)|*.mp4"
		};

		bool? result = dialog.ShowDialog();

		if (result is false or null)
		{
			return;
		}
		
		Path = dialog.FileName;
	}
}
