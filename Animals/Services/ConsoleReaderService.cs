using Animals.Core.Interfaces;
using System;

namespace Animals.Services
{
	class ConsoleReaderService : IReaderService
	{
		public string ReadLine()
		{
			return Console.ReadLine();
		}
	}
}
