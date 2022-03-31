using Animals.Core.Interfaces;

namespace Animals.WPF.ViewModels
{
    class AddAnimalViewModel : BaseViewModel
    {
        private IAnimal _animal;

        public IAnimal Animal
        {
            get => _animal;
            set
            {
                _animal = value;
                OnPropertyChanged();
            }
        }
    }
}
