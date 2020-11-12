using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amimals.WPF.ViewModels
{
	class AnimalEditViewModel : BaseViewModel
	{
		private IAnimal _animal;
		public IAnimal Animal
		{
			get => _animal;
			set
			{
				_animal = value;
				NotifyOfPropertyChanged("Animal");
			}
		}
	}
}
