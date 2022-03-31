using Animals.Core.Business.Bases;
using Animals.Core.Interfaces;
using System;

namespace Animals.Core.Business.Instances
{
	public class Cat : HomeAnimalBase
	{
        public Cat(float height, float weight, string eyeColor, string name, string breed, bool isItVaccinated, string coatColor, DateTime birthDate, bool isItWooled, IMakeASoundable aSound) 
			: base(height, weight, eyeColor, name, breed, isItVaccinated, coatColor, birthDate, aSound)
		{
			IsItWooled = isItWooled;
		}

        #region Properties

        private bool _isItWooled;
        public bool IsItWooled
        {
            get => _isItWooled;
            set
            {
                _isItWooled = value;
                OnPropertyChanged();
            }
        }

        #endregion

		//метод можно было реализовать лучше
		public override string ToString()
		{
			return $"{base.ToString()},{IsItWooled}";
		}

	}
}
