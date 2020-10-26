using Animals.Buisness;
using Animals.Core.Interfaces;

namespace Animals.Commands.Bases
{
	public abstract class NotificationCommandBase : CommandBase
	{
		protected INotificationService _notificationService;
		protected IReaderService _readerService;
		public NotificationCommandBase(Zoo zoo, IReaderService readerService, INotificationService notificationService) : base(zoo)
		{
			_notificationService = notificationService;
			_readerService = readerService;
		}


	}
}
