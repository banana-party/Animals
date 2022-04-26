using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Animals.Core.Annotations;
using Animals.Core.Business.Bases;
using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using Animals.WPF.Commands;
using Microsoft.Extensions.DependencyInjection;
using Command = Animals.WPF.Commands.Command;

namespace Animals.WPF.Controls
{
    /// <summary>
    /// Interaction logic for AnimalCard.xaml
    /// </summary>
    public partial class AnimalCard : UserControl, INotifyPropertyChanged
    {

        private IDialogService _dialogService = App.ServiceProvider.GetRequiredService<IDialogService>();

        public AnimalCard()
        {
            InitializeComponent();
        }

        public IAnimal Animal
        {
            get => (IAnimal)GetValue(AnimalProperty);
            set => SetValue(AnimalProperty, value);
        }

        private string _animalName;

        public string AnimalName
        {
            get => _animalName;
            set
            {
                _animalName = value;
                OnPropertyChanged();
            }
        }

        public static readonly DependencyProperty AnimalProperty =
            DependencyProperty.Register("Animal", typeof(IAnimal), typeof(AnimalCard), new PropertyMetadata(null, SetGrid));

        private static void SetGrid(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var type = e.NewValue?.GetType();
            if (d is not AnimalCard control)
                return;
            control.Animal = e.NewValue as IAnimal;
            control.PropertyEditor.SetGrid(control.Animal, true);

            control.SetButtons(type);
        }

        private static readonly MethodInfo[] BaseMethods = typeof(AnimalBase).GetMethods();

        private void SetButtons(Type type)
        {
            var methods = type.GetMethods();

            var uniqueMethods = methods.Except(BaseMethods, new AnimalMethodsEqualityComaprer())
                .Where(x => !x.Name.StartsWith("get_") && !x.Name.StartsWith("set_"));
            int i = 0;

            foreach (var method in uniqueMethods)
            {
                ButtonsGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

                var button = new Button
                {
                    Content = method.Name,
                };

                if (method.ReturnType == typeof(void))
                {
                    var d = (Action) method.CreateDelegate(typeof(Action), Animal);
                   // d += DoAnimalThing;
                    button.Command = new Command(d);
                }

                if (method.ReturnType == typeof(string))
                {
                    var d = (Func<string>) method.CreateDelegate(typeof(Func<string>), Animal);
                   // d += DoAnimalThing;
                }
                

                
                Grid.SetColumn(button, i++);
                Grid.SetRow(button, 0);

                ButtonsGrid.Children.Add(button);
            }


        }

        private void DoAnimalThing()
        {
            if (Animal is Dog d)
            {
                _dialogService.ShowErrorDialog("123", "123");
                d.Train();
            }
         
        }

        private void AnimalCard_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Animal = (IAnimal)DataContext;
            AnimalName = Animal.GetType().Name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private class AnimalMethodsEqualityComaprer : IEqualityComparer<MethodInfo>
        {
            public bool Equals(MethodInfo x, MethodInfo y)
            {
                return x?.Name == y?.Name;
            }

            public int GetHashCode(MethodInfo obj)
            {
                return obj.Name.GetHashCode();
            }
        }
    }

}
