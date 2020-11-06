namespace Animals.Core.Interfaces
{
	/*
	 В этом задании у интерфейса животное имеется множество полей, к тому же я не очень понимаю смысл метода Type
	Скорее всего вы уже на этом этапе нарушаете принцип разделения интерфейсов
	 */
	public interface IAnimal
	{
		void MakeASound();
		void PrintInfo();
		string Type();
	}

}
