using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using Animals.WPF.Helpers;
using Animals.WPF.Services;
using Animals.WPF.Services.Creators;
using Animals.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Animals.WPF.Controls
{
    public partial class AnimalAdd : UserControl
    {
        private readonly WpfFactory _factory;
        private readonly IDialogService _dialogService = App.ServiceProvider.GetRequiredService<IDialogService>() ?? throw new NullReferenceException();
        private class Item
        {
            public string DisplayName { get; set; }
            public IAnimal Animal { get; set; }
        }

        public IAnimal Animal
        {
            get => (IAnimal)GetValue(AnimalProperty);
            set => SetValue(AnimalProperty, value);
        }

        public static readonly DependencyProperty AnimalProperty =
            DependencyProperty.Register("Animal", typeof(IAnimal), typeof(AnimalAdd), new PropertyMetadata(null, OnAnimalChanged));

        public AnimalAdd()
        {
            InitializeComponent();
            _factory = WpfFactory.CreateFactory(_dialogService);

            var l = new List<Item>();
            foreach (var item in AnimalTypesHelper.GetAnimalTypes().ToList())
                l.Add(new Item { DisplayName = item.Name, Animal = _factory.CreateAnimal(item.Name) });
            
            ChooseAnimalComboBox.ItemsSource = l;
        }
        private static void OnAnimalChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not AnimalAdd control)
                return;
            control.PropertyEditor.SetGrid(control.Animal);
        }
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox c)
            {
                Animal = ((Item)c.SelectedItem).Animal;
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            if (window is not null)
            {
                if (PropertyEditor.CheckFields(out var errorFieldNames))
                {
                    _dialogService.ShowErrorDialog($"{string.Join(", ", errorFieldNames)} has not proper values.", "Error");
                    return;
                }
                window.DialogResult = true;
                ((AddAnimalViewModel)DataContext).Animal = Animal;
                window.Close();
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            if (window is not null)
            {
                window.DialogResult = false;
                window.Close();
            }
        }
    }
}
