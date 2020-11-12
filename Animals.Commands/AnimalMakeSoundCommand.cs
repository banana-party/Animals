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
	
		public override void Execute()
		{
			Zoo.MakeASound(this.ReadIndex(NotificationService, ReaderService));
		}
		public override string ToString()
		{
			return "Заставить животное с номером i издать звук.";
		}
	}
}
