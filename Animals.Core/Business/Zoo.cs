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
		private readonly List<IAnimal> _animals;
        public int Count => _animals.Count;

		public Zoo()
		{
			_animals = new List<IAnimal>();
		}
		public void Add(IAnimal animal)
		{
            //Лучше в подобных ситуациях кидать ArgumentNullException
			if (animal == null)
				throw new NullReferenceException("Reference was null.");
			_animals.Add(animal);
		}
		//Метод можно было назвать AddRange
		public void Add(IEnumerable<IAnimal> animals)
		{
			//Необходимо проверить, что коллекция ещё и не пуста
			if (animals == null)
				throw new NullReferenceException("Reference was null.");
            //Лучше использовать метод AddRange у списка
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
			//можно было использовать Linq
			List<string> res = new List<string>();
			foreach (var el in _animals)
				res.Add(el.ToString());
			return res;
		}
        //Метод не используется, не понимаю его смысл
        public string GetTypeOfAnimal(int index)
		{
			if (_animals[index] is AnimalBase animal) // TODO: Костыль?
				return animal.Type();
			return "";
		}
		public string GetRusTypeOfAnimal(int index)
		{
			//Необходима проверка на index в этом методе.
			if (_animals[index] is AnimalBase animal) 
				return animal.RusType();
			return "";
		}
	}
}
