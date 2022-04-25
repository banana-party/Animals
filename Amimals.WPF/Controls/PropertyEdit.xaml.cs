using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using Animals.Core.Interfaces;

namespace Animals.WPF.Controls
{
    public partial class PropertyEdit : UserControl
    {
        public PropertyEdit()
        {
            InitializeComponent();
        }

        public IAnimal Animal { get; set; }

        public void SetGrid(IAnimal animal, bool isReadOnly = false)
        {
            if (animal is null)
                return;
            Animal = animal;
            var i = 0;
            var grid = AnimalGrid;
            grid.Children.Clear();
            grid.RowDefinitions.Clear();
            foreach (var property in animal.GetType().GetProperties().OrderBy(p => p.Name))
            {
                grid.RowDefinitions.Add(new RowDefinition
                {
                    Height = GridLength.Auto
                });
                var textBlock = new TextBlock
                {
                    Text = property.Name
                };
                Grid.SetRow(textBlock, i);
                Grid.SetColumn(textBlock, 0);
                grid.Children.Add(textBlock);

                Binding binding;
                DependencyProperty dp;
                if (isReadOnly)
                {
                    var tb = new TextBlock();
                    dp = TextBlock.TextProperty;

                    tb.HorizontalAlignment = HorizontalAlignment.Right;
                    tb.TextWrapping = TextWrapping.Wrap;

                    binding = SetBinding(property, tb);
                    Grid.SetRow(tb, i);
                    Grid.SetColumn(tb, 1);
                    grid.Children.Add(tb);
                    BindingOperations.SetBinding(tb, dp, binding);
                }
                else
                {
                    Control userControl;
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
                    binding = SetBinding(property, userControl);
                    Grid.SetRow(userControl, i);
                    Grid.SetColumn(userControl, 1);
                    grid.Children.Add(userControl);

                    BindingOperations.SetBinding(userControl, dp, binding);
                }
                i++;
            }
        }

        private Binding SetBinding(PropertyInfo property, UIElement userControl)
        {
            var binding = new Binding
            {
                Path = new PropertyPath(property.Name),
                Mode = property.CanWrite ? BindingMode.TwoWay : BindingMode.OneWay,
                UpdateSourceTrigger = UpdateSourceTrigger.LostFocus
            };
            if (property.SetMethod != null)
            {
                var isPrivate = property.SetMethod.IsPrivate;
                binding.Mode = isPrivate ? BindingMode.OneWay : BindingMode.TwoWay;
                if (isPrivate)
                    userControl.IsEnabled = false;
            }

            return binding;
        }

        public bool CheckFields(out IEnumerable<string> fieldNames)
        {
            var fields = new List<string>();
            var tmp = string.Empty;
            foreach (var field in AnimalGrid.Children)
            {
                if (field is TextBlock t)
                    tmp = t.Text;

                if (field is Control c)
                    if (Validation.GetHasError(c))
                        fields.Add(tmp);
            }

            if (fields.Any())
            {
                fieldNames = fields;
                return true;
            }

            fieldNames = null;
            return false;
        }

    }
}
