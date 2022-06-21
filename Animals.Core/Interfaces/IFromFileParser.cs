using System.Collections.Generic;
//Метод Parse в интерфейсе - абсолютно лишний, что нарушает принцип разделения интерфейсов
namespace Animals.Core.Interfaces
{
    public interface IFromFileParser
	{
		IAnimal Parse(IEnumerable<string> lst);
	}
}
