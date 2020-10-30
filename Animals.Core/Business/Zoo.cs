using Animals.Core.Exceptions;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals.Core.Business
{
	public class Zoo
	{
		private List<IAnimal> _animals;
		private IFileReader _fileReader;
		private IFileWriter _fileWriter;
		public int Count
		{
			get => _animals.Count;
		}
		public Zoo(IFileReader fileReader, IFileWriter fileWriter)
		{
			_animals = new List<IAnimal>();
			_fileReader = fileReader;
			_fileWriter = fileWriter;
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
			_animals = _fileReader.Read().ToList();
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
