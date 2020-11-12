using System.Collections.Generic;

namespace Animals.Core.Interfaces
{
    public interface IFileReader
	{
		IEnumerable<IAnimal> Read(string path); 
	}
}
