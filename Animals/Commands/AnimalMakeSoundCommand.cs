using Animals.Console.Commands.Bases;
using Animals.Console.Commands.Extensions;
using Animals.Core.Business;
using Animals.Core.Interfaces;

namespace Animals.Console.Commands
{
	public class AnimalMakeSoundCommand : NotificationAndReaderCommandBase
	{
		public AnimalMakeSoundCommand(Zoo zoo, INotificationService notificationService, IReaderService readerService) : base(zoo, notificationService, readerService)
		{
		}
		
        public override void Execute()
		{
			//Лучше использовать ?.
			Zoo.MakeASound(this.ReadIndex(NotificationService, ReaderService));
		}
		
		public override string ToString()
		{
			return "Заставить животное с номером i издать звук.";
		}
	}
}
