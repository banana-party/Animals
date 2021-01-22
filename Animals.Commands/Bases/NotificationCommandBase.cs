using Animals.Core.Business;
using Animals.Core.Interfaces;
//Всё отлично
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
