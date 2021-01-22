using Animals.Core.Interfaces;
//Всё отлично
namespace Animals.Console.Services
{
	class ConsoleReaderService : IReaderService
	{
		public string ReadLine()
		{
			return System.Console.ReadLine();
		}
	}
}
