using System;
using System.Windows.Input;
using DevExpress.Mvvm;

namespace VideoPlayer.Models;

public class CommandDelegator<T> : ICommand<T>
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
			T t => CanExecute(t),
			_ => throw new ArgumentException($"Invalid {nameof(parameter)} type")
		};
	}

	public void Execute(object? parameter)
	{
		if (parameter is null)
		{
			_excecute.Invoke(null);
		}
		else if (parameter is T t)
		{
			Execute(t);
		}
		else
		{
			throw new ArgumentException($"{nameof(parameter)} is not {typeof(T).Name}");
		}
	}

	public void Execute(T param)
	{
		_excecute.Invoke(param);
	}

	public bool CanExecute(T param)
	{
		return _canExecute.Invoke(param);
	}
}
