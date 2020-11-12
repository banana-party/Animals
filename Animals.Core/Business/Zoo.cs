using Animals.Core.Exceptions;
using Animals.Core.Interfaces;
using Animals.Core.Business.Bases;
using System;
using System.Collections.Generic;
using Animals.Core.Exctensions;

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
		public void Add(IEnumerable<IAnimal> animals)
		{
			if (animals == null)
				throw new NullReferenceException("Reference was null.");
			foreach (var el in animals)
				_animals.Add(el);
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
		public string Info(int index)
		{
			if (index < 0 || index >= _animals.Count)
				throw new IndexOutOfRangeException("Index Out of range");
			return _animals[index].ToString();
		}
		public IEnumerable<string> Info()
		{
			if (Count == 0)
				throw new IncorrectActionException("В зоопарке нет животных");
			List<string> res = new List<string>();
			foreach (var el in _animals)
				res.Add(el.ToString());
			return res;
		}
		public string GetTypeOfAnimal(int index)
		{
			if (_animals[index] is AnimalBase animal) // TODO: Костыль?
				return animal.Type();
			return "";
		}
	}
}
