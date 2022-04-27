using Animals.Core.Interfaces;

namespace Animals.WPF.ViewModels
{
    public class AnimalViewModel : BaseViewModel
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
