using Animals.Core.Interfaces;
using System;
//Всё отлично
namespace Animals.Console.Services
{
	class ConsoleAnimalMakeASondService : IMakeASoundable
	{
		public void MakeASound(string str)
		{
			System.Console.Write(str);
		}
	}
}
