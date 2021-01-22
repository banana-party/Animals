using Animals.Core.Interfaces;

namespace Animals.Console.Services
{
	public class ConsoleSoundService : IMakeASoundable
	{
        //Поле никогда не используется
		private static ConsoleSoundService _soundService;
		private readonly string _soundText;
		private ConsoleSoundService(string text)
		{
			_soundText = text;
		}
		// Все мяукали потому что я Использовал синглтон в этом сервисе. 
		public static ConsoleSoundService CreateSoundService(string text) 
		{
			//if (_soundService == null)
			//	_soundService = new ConsoleSoundService(text);
			return new ConsoleSoundService(text);
		}
        //Метод можно было реализовать лучше
		public void MakeASound()
		{
			System.Console.WriteLine(_soundText);
		}
	}
}
