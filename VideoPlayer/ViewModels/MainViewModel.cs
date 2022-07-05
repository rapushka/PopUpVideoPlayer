using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using VideoPlayer.Models;

namespace VideoPlayer.ViewModels;
internal class MainViewModel : INotifyPropertyChanged
{
	private const string EmptyString = "";
	private string _path;

	public event PropertyChangedEventHandler? PropertyChanged;

	public MainViewModel()
	{
		_path = @"C:\Самазанятак\[ЗАРАЗ] Архитектура мобильных игр на UNITY для профессионалов\01\Input. 2 Bootstrapper.mp4";
	}

	public string Path
	{
		get => _path;
		set
		{
			_path = value;
			OnPropertyChanged();
		}
	}

	public ICommand PathAdd
	{
		get
		{
			return new FileOpener((obj) =>
			{
				Path = obj?.ToString()
					?? throw new NullReferenceException();
			});
		}
	}
	public void OnPropertyChanged([CallerMemberName] string prop = EmptyString)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
	}
}
