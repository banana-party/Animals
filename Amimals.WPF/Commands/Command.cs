using System;
using System.Windows.Input;
// Всё отлично
namespace Amimals.WPF.Commands
{
	class Command : ICommand
	{
		public event EventHandler CanExecuteChanged;
        //Приватное поле, изменяемое только в конструкторе, лучше всего делать readonly
		private Action _action;
		public Command(Action action)
		{
			_action = action;
		}
		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			_action?.Invoke();
		}
	}
}
