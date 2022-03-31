using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Media.Animation;
using Animals.Core.Business.Bases;
using Animals.WPF.Commands;
using Animals.WPF.Services;
using Animals.WPF.Views;

namespace Animals.WPF.ViewModels
{
    //Реализовать добавление, удаление и редактирование животных в зоопарке
    class MainWindowViewModel : BaseViewModel
    {
        private readonly IDialogService _dialogService;
        private ObservableCollection<IAnimal> _animals;
        public ObservableCollection<IAnimal> Animals
        {
            get => _animals;
            set
            {
                _animals = value;
                OnPropertyChanged();
            }
        }
        public MainWindowViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            Animals = new ObservableCollection<IAnimal>()
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
                OnPropertyChanged();
            }
        }
        public Command AddCommand => new Command(Add);
        public void Add()
        {
            AddAnimalView view = new AddAnimalView()
            {
                DataContext = new AddAnimalViewModel()
            };
            
            if ((bool) view.ShowDialog())
            {
            }
        }
        public Command EditCommand => new Command(Edit);
        public void Edit()
        {
            var a = SelectedAnimal.Clone();
            //Нужно использовать сервис навигации
            EditAnimalView view = new EditAnimalView()
            {
                DataContext = new EditAnimalViewModel()
                {
                    SelectedAnimal = (IAnimal)a
                }
            };
            if ((bool)view.ShowDialog())
            {
                var i = Animals.IndexOf(SelectedAnimal);
                Animals.RemoveAt(i);
                Animals.Insert(i, (IAnimal)((EditAnimalViewModel)view.DataContext).SelectedAnimal.Clone());
            }
            else
                SelectedAnimal = null;
            
        }

        public Command RemoveCommand => new Command(Remove);
        public void Remove()
        {
            if (!_dialogService.ShowYesNoDialog("Вы действительно хотите удалить это животное?", "Удаление"))
                return;
            Animals.Remove(SelectedAnimal);
            SelectedAnimal = null;
        }
        public Command PlaySoundCommand => new Command(PlaySound);
        private void PlaySound()
        {
            SelectedAnimal.MakeASound();
        }
    }
}
