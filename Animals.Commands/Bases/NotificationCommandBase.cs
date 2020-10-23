using Animals.Buisness;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
