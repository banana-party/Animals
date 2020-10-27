using Animals.Core.Interfaces;
using Animals.Exceptions;
using System;
using System.Collections.Generic;

namespace Animals.Buisness
{
	public class Zoo
	{
		private List<IAnimal> _animals;
		public int Count 
		{
			get => _animals.Count;
		}
		public Zoo()
		{
			_animals = new List<IAnimal>();
		}
		public void Add(IAnimal animal)
		{
			if (animal == null)
				throw new NullReferenceException("Reference was null.");
			_animals.Add(animal);
		}
		public void RemoveAt(int index)
		{
			if (index < 0 || index >= _animals.Count)
				throw new IndexOutOfRangeException("Index Out of range");
			_animals.RemoveAt(index);
		}
		public void MakeASound(int index)
		{
			if (index < 0 || index >= _animals.Count)
				throw new IndexOutOfRangeException("Index Out of range");
			_animals[index].MakeASound();
		}
		public void MakeASound()
		{
			if (Count == 0)
				throw new IncorrectActionException("В зоопарке нет животных");
			foreach (var el in _animals)
				el.MakeASound();
		}
		public void PrintInfo(int index)
		{
			if (index < 0 || index >= _animals.Count)
				throw new IndexOutOfRangeException("Index Out of range");
			_animals[index].PrintInfo();
		}
		public void PrintInfo()
		{
			if (Count == 0)
				throw new IncorrectActionException("В зоопарке нет животных");
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
		public string GetTypeOfAnimal(int index)
		{
			return _animals[index].Type();
		}
	}
}
