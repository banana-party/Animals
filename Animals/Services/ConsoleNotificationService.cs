using Animals.Core.Interfaces;
using System;

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
