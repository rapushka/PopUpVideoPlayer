using System;
using System.Windows.Input;

namespace VideoPlayer.Models;
public class FileOpener : ICommand
{
	private Action<object?>? _excecute;
	private Func<object?, bool>? _canExecute;

	public FileOpener(Action<object?>? excecute, Func<object?, bool>? canExecute)
	{
		_excecute = excecute;
		_canExecute = canExecute;
	}

	public FileOpener(Action<object?>? excecute)
		: this(excecute, null) { }

	public event EventHandler? CanExecuteChanged
	{
		add => CommandManager.RequerySuggested += value;
		remove => CommandManager.RequerySuggested -= value;
	}

	public bool CanExecute(object? parameter)
	{
		return _canExecute?.Invoke(parameter)
			?? true;
	}

	public void Execute(object? parameter)
	{
		_excecute?.Invoke(parameter);
	}
}
