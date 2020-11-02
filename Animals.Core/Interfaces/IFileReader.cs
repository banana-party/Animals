using System.Collections.Generic;

namespace Animals.Core.Interfaces
{
    /*
     не очень понимаю смысл метода Open это можно делать например в корнонструкторе или в отдельной реализации или внутри метода Read, это нарушает
    принцип разделения интерфейсов
     */
    public interface IFileReader
	{
        bool Open(string path);
		IEnumerable<IAnimal> Read();
	}
}
