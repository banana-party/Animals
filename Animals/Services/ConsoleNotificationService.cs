using Animals.Core.Interfaces;

namespace Animals.Console.Services
{
	class ConsoleNotificationService : INotificationService
	{
		public void Write(string text)
		{
			System.Console.Write(text);
		}
	}
}
