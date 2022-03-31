using System;
using System.Windows.Input;

namespace Animals.WPF.Commands
{
	public class Command : ICommand
	{
		public event EventHandler CanExecuteChanged;
        private readonly Action _action;
		public Command(Action action)
		{
			_action = action;
		}

        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter) => _action?.Invoke();
    }
}
