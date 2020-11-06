//Метод WiriteToFile должен принимать либо IAnimal либо IEnumerable<IAnimal> либо Zoo
namespace Animals.Core.Interfaces
{
    public interface IFileWriter
	{
		bool WriteToFile();
	}
}
