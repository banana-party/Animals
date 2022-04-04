using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
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
using Animals.WPF.ViewModels;
using Animals.WPF.Views;


namespace Animals.WPF.Controls
{
    public partial class AnimalEditor : UserControl
    {
        public IAnimal Animal
        {
            get { return (IAnimal)GetValue(AnimalProperty); }
            set { SetValue(AnimalProperty, value); }
        }

        public static readonly DependencyProperty AnimalProperty =
            DependencyProperty.Register("Animal", typeof(IAnimal), typeof(AnimalEditor), new PropertyMetadata(null, AnimalChanged));

        private static void AnimalChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var type = e.NewValue.GetType();
            if (d is not AnimalEditor control)
                return;
            control.Animal = e.NewValue as IAnimal;
            var grid = control.PropertyGrid;
            grid.Children.Clear();
            grid.RowDefinitions.Clear();
            var i = 0;

            foreach (var property in type.GetProperties().OrderBy(p => p.Name))
            {
                grid.RowDefinitions.Add(new RowDefinition()
                {
                    Height = GridLength.Auto
                });
                TextBlock textBlock = new TextBlock()
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
                //TODO: Проблемы при выводе собаки из за приватного сета
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

        public AnimalEditor()
        {
            InitializeComponent();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            var t = Window.GetWindow(this);
            if (t is not null)
            {
                t.DialogResult = true;
                ((EditAnimalViewModel)DataContext).SelectedAnimal = Animal;
                t.Close();
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            var t = Window.GetWindow(this);
            if (t is not null)
            {
                t.DialogResult = false;
                t.Close();
            }
        }
    }
}
