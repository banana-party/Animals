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
            public Type Animal { get; set; }
        }


        public AnimalAdd()
        {
            InitializeComponent();

            var l = new List<Item>();
            foreach (var item in AnimalTypesHelper.GetAnimalTypes().ToList())
            {
                l.Add(new Item {DisplayName = item.Name, Animal = item});
            }
            ChooseAnimalComboBox.ItemsSource = l;
            ChooseAnimalComboBox.SelectedItem = ChooseAnimalComboBox.Items.CurrentItem;
            ChooseAnimalComboBox.DisplayMemberPath = "DisplayName";
            ChooseAnimalComboBox.SelectedValuePath = "Animal";
            ChooseAnimalComboBox.SelectionChanged += OnSelectionChanged;
            //ChooseAnimalComboBox.SelectedValue = l.First();
            ChooseAnimalComboBox.SelectedItem = l.First();
        }

        public IAnimal Animal { get; set; }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox c)
            {
                var type = ((Item) c.SelectedItem).Animal;

                var grid = AnimalGrid;
                grid.Children.Clear();
                grid.RowDefinitions.Clear();
                int i = 0;
                if (type == typeof(Cat))
                {
                    var ctor = type.GetConstructor(new[]
                        {typeof(float), typeof(float), typeof(string), typeof(IMakeASoundable)});
                    var instance = ctor.Invoke(new object[] {0, 0, "", null});
                }

                foreach (var property in type.GetProperties().OrderBy(x => x.Name))
                {
                    grid.RowDefinitions.Add(new RowDefinition
                    {
                        Height = GridLength.Auto
                    });
                    TextBlock textBlock = new TextBlock
                    {
                        Text = property.Name
                    };
                    Grid.SetRow(textBlock, i);
                    Grid.SetColumn(textBlock, 0);
                    grid.Children.Add(textBlock);

                    Control userControl;
                    DependencyProperty dp;
                    var typeCode = Type.GetTypeCode(property.PropertyType);
                    switch (typeCode)
                    {
                        case TypeCode.DateTime:
                            userControl = new DatePicker();
                            dp = DatePicker.SelectedDateProperty;
                            break;
                        case TypeCode.Boolean:
                            userControl = new CheckBox();
                            dp = ToggleButton.IsCheckedProperty;
                            break;
                        default:
                            userControl = new TextBox();
                            dp = TextBox.TextProperty;
                            break;
                    }
                    var binding = new Binding()
                    {
                        Path = new PropertyPath(property.Name),
                        Mode = property.CanWrite ? BindingMode.TwoWay : BindingMode.OneWay,
                        UpdateSourceTrigger = UpdateSourceTrigger.LostFocus
                    };
                    if (property.SetMethod != null)
                    {
                        var isPrivate = property.SetMethod.IsPrivate;
                        ((Binding)binding).Mode = isPrivate ? BindingMode.OneWay : BindingMode.TwoWay;
                        if (isPrivate)
                            userControl.IsEnabled = false;
                    }


                    Grid.SetRow(userControl, i);
                    Grid.SetColumn(userControl, 1);
                    grid.Children.Add(userControl);

                    BindingOperations.SetBinding(userControl, dp, binding);

                    i++;
                }

            }
        }

    }

  
}
