using Animals.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Bases
{
	public abstract class BaseHomeAnimal : BaseAnimal, ICareable
	{
		/*
		* 1.1 Кличка
		* 1.2 Порода
		* 1.3 Наличие прививок
		* 1.4 Цвет шерсти
		* 1.5 Дата рождения
		*/
		public string Name { get; set; }
		public string Breed { get; set; }
		public bool IsITVaccinated { get; set; }
		public string CoatColor { get; set; }
		public DateTime BirthDate { get; set; }
		public abstract void Care();
	}
}
