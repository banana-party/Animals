using Animals.Commands.Bases;
using Animals.Core.Business;
using Animals.Core.Interfaces;
using Animals.Commands.Extensions;
using System.Linq;

namespace Animals.Commands
{
	public class PrintAnimalInfoCommand : NotificationAndReaderCommandBase
	{
		public PrintAnimalInfoCommand(Zoo zoo, INotificationService notificationService, IReaderService readerService) : base(zoo, notificationService, readerService)
		{
		}

		public override void Execute()
		{
			var lst = Zoo.Info(this.ReadIndex(NotificationService, ReaderService)).Split(',').ToList();
			NotificationService.Write($"{lst[0]}:\n\t");
			for (int i = 1; i < lst.Count; i++)
			{
				NotificationService.Write($"{lst[i]} ");
			}
		}
		//Метод можно было реализовать лучше
		public override string ToString()
		{
			return "Посмотреть информацию о животном с номером i.";
		}
	}
}
