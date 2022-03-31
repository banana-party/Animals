using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Animals.Core.Interfaces;
using Animals.WPF.Helpers;

namespace Animals.WPF.Controls
{
    public partial class AnimalAdd : UserControl
    {
        public AnimalAdd()
        {
            InitializeComponent();
            ChooseAnimalComboBox.ItemsSource = AnimalTypesHelper.GetAnimalTypes().Select(x => x.Name).ToList();
            ChooseAnimalComboBox.Text = ChooseAnimalComboBox.Items[0].ToString();
            ChooseAnimalComboBox.SelectionChanged += OnSelectionChanged;
        }

        public string SelectedAnimal { get; set; }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox c)
            {
                var t = c.Items.CurrentItem.GetType();
            }
        }
    }
}
