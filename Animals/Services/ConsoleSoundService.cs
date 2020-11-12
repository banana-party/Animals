using Animals.Core.Interfaces;

namespace Animals.Console.Services
{
	public class ConsoleSoundService : IMakeASoundable
	{
		private readonly INotificationService _notificationService;
		private static ConsoleSoundService _soundService;
		private ConsoleSoundService(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}
		public static ConsoleSoundService CreateSoundService(INotificationService notificationService)
		{
			if (_soundService == null)
				_soundService = new ConsoleSoundService(notificationService);
			return _soundService;
		}
		public void MakeASound(string str)
		{
			_notificationService.Write($"{str}\n");
		}
	}
}
