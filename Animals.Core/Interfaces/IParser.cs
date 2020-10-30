using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Core.Interfaces
{
	public interface IParser
	{
		List<string> Parse(IAnimal animal);
		IAnimal Parse(List<string> lst);
	}
}
