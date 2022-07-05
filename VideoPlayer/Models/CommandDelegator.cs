using System;
using System.Windows.Input;

namespace VideoPlayer.Models;
public class CommandDelegator<T> : ICommand
	where T : class
{
	private readonly Action<T?> _excecute;
	private readonly Func<T?, bool> _canExecute;

	public CommandDelegator(Action<T?> excecute, Func<T?, bool> canExecute)
	{
		_excecute = excecute;
		_canExecute = canExecute;
	}

	public CommandDelegator(Action<T?> excecute)
		: this(excecute, (t) => true) { }

	public event EventHandler? CanExecuteChanged
	{
		add => CommandManager.RequerySuggested += value;
		remove => CommandManager.RequerySuggested -= value;
	}

	public bool CanExecute(object? parameter)
	{
		return parameter switch
		{
			null => _canExecute.Invoke(null),
			T t => _canExecute.Invoke(t),
			_ => throw new ArgumentException($"Invalid {nameof(parameter)} type")
		};
	}

	public void Execute(object? parameter)
	{
		_excecute.Invoke(parameter as T);
	}
}
