using System.Collections.Generic;

namespace Animals.Core.Interfaces
{
	//Всё отлично
    public interface IFileReader
	{
		IEnumerable<IAnimal> Read(string path); 
	}
}
