using Animals.Core.Interfaces;
using System;

namespace Animals.Services
{
	class ConsoleAnimalMakeASondService : IMakeASoundable
	{
		public void MakeASound(string str)
		{
			Console.WriteLine(str);
		}
	}
}
