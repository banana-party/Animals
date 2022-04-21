using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Animals.WPF.Controls
{
    public partial class AnimalAdd : UserControl
    {
        private class Item
        {
            public string DisplayName { get; set; }
            public IAnimal Animal { get; set; }
        }


        public AnimalAdd()
        {
            InitializeComponent();

            var l = new List<Item>();
            foreach (var item in AnimalTypesHelper.GetAnimalTypes().ToList())
            {
                l.Add(new Item { DisplayName = item.Name, Animal = AnimalTypesHelper.GetAnimal(item) });
            }
            ChooseAnimalComboBox.ItemsSource = l;
            ChooseAnimalComboBox.SelectedItem = l.First();
        }


        public IAnimal Animal
        {
            get { return (IAnimal)GetValue(AnimalProperty); }
            set { SetValue(AnimalProperty, value); }
        }

        public static readonly DependencyProperty AnimalProperty =
            DependencyProperty.Register("Animal", typeof(IAnimal), typeof(AnimalAdd), new PropertyMetadata(null, new PropertyChangedCallback(OnAnimalChanged)));

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
    }
}
