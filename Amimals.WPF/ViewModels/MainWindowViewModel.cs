using Amimals.WPF.Commands;
using Amimals.WPF.Services;
using Amimals.WPF.Views;
using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using System.Collections.Generic;

namespace Amimals.WPF.ViewModels
{
	//Реализовать добавление, удаление и редактирование животных в зоопарке
	class MainWindowViewModel : BaseViewModel
	{
		private readonly IDialogService _dialogService;
		private List<IAnimal> _animals;
		public List<IAnimal> Animals
		{
			get => _animals;
			set
			{
				_animals = value;
				NotifyOfPropertyChanged("Animals");
			}
		}
		public MainWindowViewModel(IDialogService dialogService)
		{
			_dialogService = dialogService;
			Animals = new List<IAnimal>()
			{
				new Chicken(12.2f, 13.3f, "Red", 0, new SoundService(@"Sounds\chicken.wav")),
				new Cat
				(
					 12f, 44f,
					"Green", "Vasya", "Tasmanian", true,
					"Black", new System.DateTime(1332, 11, 3),
					true, new SoundService(@"Sounds\meow.wav")
				),
				new Dog
				(
					12.2f,33f,
					"Yellow", "Boobick", "Street", false,
					"Brown", new System.DateTime(2015,3,24), 
					false, new SoundService(@"Sounds\bark.wav")
				),
				new Stork(11.1f,22,"Black", 200, new SoundService(@"Sounds\stork.wav"))
			};
		}
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
		public Command AddCommand => new Command(Add);
		public void Add()
		{ 
		}
		public Command EditCommand => new Command(Edit);
		public void Edit()
		{
			EditAnimalView view = new EditAnimalView()
			{
				DataContext = new EditAnimalViewModel()
				{
					SelectedAnimal = SelectedAnimal
				}
			};
			view.ShowDialog();
		}
		
		public Command RemoveCommand => new Command(Remove);
		public void Remove()
		{
			if (!_dialogService.ShowYesNoDialog("Вы действительно хотите удалить это животное?", "Удаление"))
				return;
			Animals.Remove(SelectedAnimal);
			SelectedAnimal = null;
			Animals = new List<IAnimal>(Animals);
		}
		public Command PlaySoundCommand => new Command(PlaySound);
		private void PlaySound()
		{
			SelectedAnimal.MakeASound();
		}
	}
}
