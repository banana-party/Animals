using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Animals.Factory
{
	class AnimalsControlFactory
	{
		public Control Create(PropertyInfo property)
		{
			Control userControl = new TextBox();
			DependencyProperty dp = TextBox.TextProperty;
			if (property.PropertyType == typeof(DateTime))
			{
				userControl = new DatePicker();
				dp = DatePicker.SelectedDateProperty;
			}


			Binding binding = new Binding();
			binding.Path = new PropertyPath(property.Name);
			binding.Mode = property.CanWrite ? BindingMode.TwoWay : BindingMode.OneWay;
			BindingOperations.SetBinding(userControl, dp, binding);
			return userControl;
		}
	}
}
