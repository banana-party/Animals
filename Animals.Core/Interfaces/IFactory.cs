namespace Animals.Core.Interfaces
{
    public interface IFactory
    {
        IAnimal CreateAnimal(string type);
    }
}
