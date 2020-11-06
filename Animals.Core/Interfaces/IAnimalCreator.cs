/*
 Вот вообще очень плохая вещь, я бы ещё понял такую реализацию в каком-то из классов но не интерфейсе. Если мы в будущем захотим реализовать этот
интерфейс, то придётся реализовывать это всё, к тому же каждое добавление нового животного приведёт к добавлению нового метода в интерфейс?
 */
namespace Animals.Core.Interfaces
{
    public interface IAnimalCreator
	{
		IAnimal CreateCat();
		IAnimal CreateDog();
		IAnimal CreateChicken();
		IAnimal CreateStork();
		IAnimal CreateTiger();
		IAnimal CreateWolf();
	}
}
