using Animals.Core.Interfaces;

namespace Animals.WPF.ViewModels
{
	public class EditAnimalViewModel : BaseViewModel
	{
		private IAnimal _selectedAnimal;
		public IAnimal SelectedAnimal
		{
			get => _selectedAnimal;
			set
			{
				_selectedAnimal = value;
                OnPropertyChanged();
			}
		}
    }
}
