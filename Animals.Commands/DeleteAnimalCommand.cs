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

		public override void Execute()
		{
			Zoo.RemoveAt(this.ReadIndex(NotificationService, ReaderService));
		}
		public override string ToString()
		{
			return "Удалить животное из зоопарка.";
		}
	}
}
