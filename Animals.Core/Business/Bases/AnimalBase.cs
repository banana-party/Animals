using Animals.Core.Interfaces;
using System.Text;

namespace Animals.Core.Business.Bases
{
	public abstract class AnimalBase : IAnimal
	{
		protected INotificationService NotificationService;
		protected IMakeASoundable ASound;
		protected AnimalBase(IMakeASoundable aSound, INotificationService notificationService, float height, float weight, string eyeColor)
		{
			Height = height;
			Weight = weight;
			EyeColor = eyeColor;
			NotificationService = notificationService;
			ASound = aSound;
		}
        //у этих свойств private set можно было не писать
		public float Height { get; private set; }
		public float Weight { get; private set; }
		public string EyeColor { get; private set; }
		public abstract void MakeASound();
		public virtual void PrintInfo()
		{
			NotificationService.WriteLine($"{Type()}:\n\tРост: {Height}\n\tВес: {Weight}\n\tЦвет глаз: {EyeColor}");
		}
        //не вижу никакого смысла этого метода
		public string Type()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(GetType());
			stringBuilder.Remove(0, 32);
			return TypeFromEngToRus(stringBuilder.ToString());
		}
        //не вижу смысла этого метода вообще
		private string TypeFromEngToRus(string type)
		{
			switch (type)
			{
				case "Chicken":
					return "Курица";
				case "Cat":
					return "Кошка";
				case "Dog":
					return "Собака";
				case "Stork":
					return "Аист";
				case "Tiger":
					return "Тигр";
				case "Wolf":
					return "Волк";
				default:
					return type;
			}
		}

	}
}
