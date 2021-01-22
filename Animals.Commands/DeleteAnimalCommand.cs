using Animals.Commands.Bases;
using Animals.Core.Business;
using Animals.Core.Interfaces;
using Animals.Commands.Extensions;

namespace Animals.Commands
{
    public class DeleteAnimalCommand : NotificationAndReaderCommandBase
	{
		public DeleteAnimalCommand(Zoo zoo, INotificationService notificationService, IReaderService readerService) : base(zoo, notificationService, readerService)
		{
		}
		//Метод можно было написать лучше
		public override void Execute()
		{
			//Лучше использовать ?.
            //Нужно проверять индекс, который ввёл пользователь
			Zoo.RemoveAt(this.ReadIndex(NotificationService, ReaderService));
		}
		//Метод можно было написать лучше
		public override string ToString()
		{
			return "Удалить животное из зоопарка.";
		}
	}
}
