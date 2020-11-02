using Animals.Core.Interfaces;
using System;
//Всё отлично
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
