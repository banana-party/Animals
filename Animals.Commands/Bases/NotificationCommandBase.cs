using Animals.Core.Business;
using Animals.Core.Interfaces;

namespace Animals.Commands.Bases
{
	public abstract class NotificationCommandBase : CommandBase
	{
        //лучше приватные поля, получаемые только в конструкторе делать readonly
		protected INotificationService _notificationService;
		protected IReaderService _readerService;
        //Конструктор должен быть защищённый
		public NotificationCommandBase(Zoo zoo, IReaderService readerService, INotificationService notificationService) : base(zoo)
		{
			_notificationService = notificationService;
			_readerService = readerService;
		}


	}
}
