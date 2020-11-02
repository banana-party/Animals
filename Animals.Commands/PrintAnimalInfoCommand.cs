using Animals.Commands.Bases;
using Animals.Core.Business;
using Animals.Core.Interfaces;

namespace Animals.Commands
{
	public class PrintAnimalInfoCommand : NotificationCommandBase
	{
		public PrintAnimalInfoCommand(Zoo zoo, IReaderService readerService, INotificationService notificationService) : base(zoo, readerService, notificationService)
		{
		}

		public override void Execute()
		{
			//Избежать дублирование кода в данном услучае
			_notificationService.Write("Введите индекс животного, информацию о котором необходимо вывести: ");
			int index;
			while (!int.TryParse(_readerService.ReadLine(), out index))
			{
				_notificationService.WriteLine("Неверный ввод.");
				_notificationService.Write("Введите индекс животного, информацию о котором необходимо вывести: ");
			}
			_zoo.PrintInfo(--index);
		}
		public override string ToString()
		{
			return "Посмотреть информацию о животном с номером i.";
		}
	}
}
