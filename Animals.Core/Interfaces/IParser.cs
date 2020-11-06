using System.Collections.Generic;
//Метод Parse в интерфейсе - абсолютно лишний, что нарушает принцип разделения интерфейсов
namespace Animals.Core.Interfaces
{
    public interface IParser
	{
		List<string> Parse(IAnimal animal);
		IAnimal Parse(List<string> lst);
	}
}
