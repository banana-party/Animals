using Animals.Core.Interfaces;
using System;
//Всё отлично
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
