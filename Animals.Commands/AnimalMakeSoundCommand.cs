using Animals.Commands.Bases;
using Animals.Core.Business;
using Animals.Core.Interfaces;
using Animals.Commands.Extensions;

namespace Animals.Commands
{
	public class AnimalMakeSoundCommand : NotificationAndReaderCommandBase
	{
		public AnimalMakeSoundCommand(Zoo zoo, INotificationService notificationService, IReaderService readerService) : base(zoo, notificationService, readerService)
		{
		}
		//Метод можно было написать лучше
        public override void Execute()
		{
			//Лучше использовать ?.
			Zoo.MakeASound(this.ReadIndex(NotificationService, ReaderService));
		}
		//Метод можно было написать лучше
		public override string ToString()
		{
			return "Заставить животное с номером i издать звук.";
		}
	}
}
