using Animals.Core.Business;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Commands.Bases
{
	public abstract class NotificationCommandBase : CommandBase
	{
		protected readonly INotificationService NotificationService;
		protected NotificationCommandBase(Zoo zoo, INotificationService notificationService) : base(zoo)
		{
			NotificationService = notificationService;
		}
	}
}
