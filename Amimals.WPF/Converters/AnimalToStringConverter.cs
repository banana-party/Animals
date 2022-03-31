using System;
using System.Globalization;
using System.Windows.Data;
using Animals.Core.Business.Bases;
using Animals.Core.Exctensions;
using Animals.WPF.Exceptions;

namespace Animals.WPF.Converters
{
	class AnimalToStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
            switch (value)
            {
                case null:
                    throw new NullReferenceException("Reference was null");
                case AnimalBase animal:
                    return animal.Type();
                default:
                    throw new IncorrectTypeException("Type was incorrect");
            }
        }

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
	}
}
