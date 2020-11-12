using Animals.Core.Interfaces;

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
