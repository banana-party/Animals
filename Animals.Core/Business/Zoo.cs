using Animals.Core.Exceptions;
using Animals.Core.Interfaces;
using Animals.Core.Business.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using Animals.Core.Exctensions;

namespace Animals.Core.Business
{
	public class Zoo
	{
		private readonly List<IAnimal> _animals;
        public int Count => _animals.Count;

		public Zoo()
		{
			_animals = new List<IAnimal>();
		}
		public void Add(IAnimal animal)
		{
            if (animal == null)
				throw new ArgumentNullException("Reference is null.");
			_animals.Add(animal);
		}
        public void AddRange(IEnumerable<IAnimal> animals)
		{
            if (animals == null || !animals.Any())
				throw new NullReferenceException("Collection is null or empty.");
            _animals.AddRange(animals);
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
		public IEnumerable<IAnimal> Info()
		{
			if (Count == 0)
				throw new IncorrectActionException("В зоопарке нет животных");

            return _animals;
        }
        //Метод не используется, не понимаю его смысл
        public string GetTypeOfAnimal(int index)
		{
            if (index < 0 || index >= _animals.Count)
                throw new IndexOutOfRangeException("Index Out of range");
			if (_animals[index] is AnimalBase animal) // TODO: Костыль?
				return animal.Type();
			return "";
		}
		public string GetRusTypeOfAnimal(int index)
		{
            if (index < 0 || index >= _animals.Count)
                throw new IndexOutOfRangeException("Index Out of range");
            if (_animals[index] is AnimalBase animal) 
				return animal.RusType();
			return "";
		}
	}
}
