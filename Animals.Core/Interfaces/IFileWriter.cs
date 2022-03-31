using System.Collections.Generic;

namespace Animals.Core.Interfaces
{
    public interface IFileWriter
	{
		void WriteToFile(IEnumerable<IAnimal> animals);
	}
}
