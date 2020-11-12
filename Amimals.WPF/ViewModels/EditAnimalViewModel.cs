using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amimals.WPF.ViewModels
{
	class EditAnimalViewModel : BaseViewModel
	{
		private IAnimal _selectedAnimal;
		public IAnimal SelectedAnimal
		{
			get => _selectedAnimal;
			set
			{
				_selectedAnimal = value;
				NotifyOfPropertyChanged("SelectedAnimal");
			}
		}
		public EditAnimalViewModel()
		{
		}
	}
}
