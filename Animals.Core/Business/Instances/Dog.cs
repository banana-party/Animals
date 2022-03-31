using Animals.Core.Business.Bases;
using Animals.Core.Interfaces;
using System;

namespace Animals.Core.Business.Instances
{
	public class Dog : HomeAnimalBase
    {
        #region Properties

        private bool _isItTrained;
        public bool IsItTrained
        {
            get => _isItTrained;
            private set
            {
                _isItTrained = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public Dog(float height, float weight, string eyeColor, string name, string breed, bool isItVaccinated, string coatColor, DateTime birthDate, bool isItTrained, IMakeASoundable aSound) 
			: base(height, weight, eyeColor, name, breed, isItVaccinated, coatColor, birthDate, aSound)
		{
			IsItTrained = isItTrained;
		}
		public void Train()
		{
			if (IsItTrained)
				return;
			IsItTrained = true;
		}
        //метод можно было реализовать лучше
		public override string ToString()
		{
			return $"{base.ToString()},{IsItTrained}";
		}
	}
}
