using System;
using DevExpress.Mvvm;
using System.Windows.Input;
using VideoPlayer.Models;

namespace VideoPlayer.ViewModels;
public class MainViewModel : ViewModelBase
{
	private const string TestPath = 
		@"C:\Самазанятак\[ЗАРАЗ] Архитектура мобильных игр на UNITY для профессионалов\01\Input. 1 Intro.mp4";
	private string _path;
	private string _input;

	public MainViewModel()
	{
		_input = TestPath;
		_path = string.Empty;
	}

	public string Input
	{
		get => _input;
		set
		{
			_input = value;
			RaisePropertyChanged(() => Input);
		}
	}
	
	public string Path
	{
		get => _path;
		set
		{
			_path = value;
			RaisePropertyChanged(() => Path);
		}
	}

	public ICommand SetInputAsPath
		=> new CommandDelegator<object>((x)
			=> Path = Input);
}
