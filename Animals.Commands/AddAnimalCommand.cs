using Animals.Buisness;
using Animals.Commands.Bases;
using Animals.Core.Interfaces;
using System.Collections.Generic;

namespace Animals.Commands
{
	public class AddAnimalCommand : NotificationCommandBase
	{
		private Dictionary<string, ICommand> _dict;
		public AddAnimalCommand(Zoo zoo, IReaderService readerService, INotificationService notificationService) : base(zoo, readerService, notificationService)
		{
			
		}

		public override void Execute()
		{
			_notificationService.WriteLine("Выберете животное, которое хотите добавить:\n1 - Кошка\n2 - Собака\n3 - Курица\n4 - Аист\n5 - Тигр\n6 - Волк");
			string choose = _readerService.ReadLine();
		}
	}
}
