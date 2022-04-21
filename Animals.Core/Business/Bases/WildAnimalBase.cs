using Animals.Core.Interfaces;
using System;

namespace Animals.Core.Business.Bases
{
    public abstract class WildAnimalBase : AnimalBase
    {
        protected WildAnimalBase()
        {
        }
        protected WildAnimalBase(float height, float weight, string eyeColor, string habitat, DateTime dateOfFind, IMakeASoundable aSound) : base(height, weight, eyeColor, aSound)
        {
            Habitat = habitat;
            DateOfFind = dateOfFind;
        }

        #region Properties

        private string _habitat;

        public string Habitat
        {
            get => _habitat;
            set
            {
                _habitat = value;
                OnPropertyChanged();
            }
        }
        private DateTime _dateOfFind;
        public DateTime DateOfFind
        {
            get => _dateOfFind;
            set
            {
                _dateOfFind = value;
                OnPropertyChanged();
            }
        }

        #endregion

        //Метод можно было написать лучше
        public override string ToString()
        {
            return $"{base.ToString()},{Habitat},{DateOfFind.Day}.{DateOfFind.Month}.{DateOfFind.Year}";
        }
    }
}
