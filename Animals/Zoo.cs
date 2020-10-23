using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
	class Zoo
	{
		private List<IAnimal> _animals;
		public void Add(IAnimal animal)
		{
			_animals.Add(animal);
		}
		public void RemoveAt(int index)
		{
			_animals.RemoveAt(index);
		}
		public void PrintInfo(int index)
		{
			_animals[index].PrintInfo();
		}
		public void PrintInfo()
		{
			foreach (var el in _animals)
				el.PrintInfo();		
		}
		public void ReadFromFile()
		{
			//TODO реализация
		}
		public void SaveToFile()
		{
			//TODO реализация
		}

	}
}
