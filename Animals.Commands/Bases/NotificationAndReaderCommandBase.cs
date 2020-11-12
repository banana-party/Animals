using Animals.Core.Business;
using Animals.Core.Interfaces;

namespace Animals.Commands.Bases
{
	public abstract class NotificationAndReaderCommandBase : NotificationCommandBase
	{
		protected readonly IReaderService ReaderService;

		protected NotificationAndReaderCommandBase(Zoo zoo, INotificationService notificationService, IReaderService readerService) : base(zoo, notificationService)
		{
			ReaderService = readerService;
		}


	}
}
