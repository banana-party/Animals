using Animals.Core.Interfaces;
//Всё отлично
namespace Animals.Console.Services
{
	public class ConsoleNotificationService : INotificationService
	{
		public void Write(string text)
		{
			System.Console.Write(text);
		}
	}
}
