using Animals.Core.Interfaces;
using System;
//Всё отлично, но, возможно, какой-то из этих методов лишний
namespace Animals.Services
{
	class ConsoleNotificationService : INotificationService
	{
		public void Write(string text)
		{
			Console.Write(text);
		}

		public void WriteLine(string text)
		{
			Console.WriteLine(text);
		}
	}
}
