using Animals.Core.Exctensions;
using Animals.Core.Interfaces;
using System;

//Отличный базовый класс
namespace Animals.Core.Business.Bases
{
    public abstract class HomeAnimalBase : AnimalBase
    {
        protected HomeAnimalBase(IMakeASoundable sound, IDialogService dialog) : base(sound, dialog)
        {
        }

        #region Properties

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        private string _breed;
        public string Breed
        {
            get => _breed;
            set
            {
                _breed = value;
                OnPropertyChanged();
            }
        }
        private bool _isItVaccinated;
        public bool IsItVaccinated
        {
            get => _isItVaccinated;
            set
            {
                _isItVaccinated = value;
                OnPropertyChanged();
            }
        }

        private string _coatColor;
        public string CoatColor
        {
            get => _coatColor;
            set
            {
                _coatColor = value;
                OnPropertyChanged();
            }
        }
        private DateTime _birthDate;
        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                OnPropertyChanged();
            }
        }

        #endregion


        public void Pet()
        {
            DialogService.ShowMessage($"Вы гладите {this.RusType()}, оно довольное...");
        }
        //метод можно было неаписать лучше
        public override string ToString()
        {
            return $"{base.ToString()},{Name},{Breed},{IsItVaccinated},{CoatColor},{BirthDate.Day}.{BirthDate.Month}.{BirthDate.Year}";
        }

    }
}
