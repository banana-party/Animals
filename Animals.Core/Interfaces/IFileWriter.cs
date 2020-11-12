//Метод WiriteToFile должен принимать либо IAnimal либо IEnumerable<IAnimal> либо Zoo
using System.Collections.Generic;

namespace Animals.Core.Interfaces
{
    public interface IFileWriter
	{
		void WriteToFile(IEnumerable<string> animals);
	}
}
