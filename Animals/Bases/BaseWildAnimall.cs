using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Bases
{
	public abstract class BaseWildAnimall : BaseAnimal
	{
		//2.1 Место обитания
		//2.2 Дата нахождения
		public string Habitat { get; set; }
		public DateTime DateOfFind { get; set; }
	}
}
