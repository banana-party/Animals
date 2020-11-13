using Animals.Core.Interfaces;

namespace Animals.Console.Services
{
	public class ConsoleSoundService : IMakeASoundable
	{
		private static ConsoleSoundService _soundService;
		private readonly string _soundText;
		private ConsoleSoundService(string text)
		{
			_soundText = text;
		}
		public static ConsoleSoundService CreateSoundService(string text)
		{
			if (_soundService == null)
				_soundService = new ConsoleSoundService(text);
			return _soundService;
		}
		public void MakeASound()
		{
			System.Console.WriteLine(_soundText);
			// Это же Console Sound. Мне не обязательно пользоваться Notification сервисом. Можно сразу юзать консоль.
		}
	}
}
