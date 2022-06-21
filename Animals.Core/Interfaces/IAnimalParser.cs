using System.Collections.Generic;

namespace Animals.Core.Interfaces
{
	public interface IAnimalParser
	{
		IAnimal Parse(IEnumerable<string> animals);
	}
}
