using System;
using System.Globalization;
using System.Windows.Data;
using Amimals.WPF.Exceptions;
using Animals.Core.Business.Bases;
using Animals.Core.Exctensions;
//Всё отлично
namespace Amimals.WPF.Converters
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
			throw new NotImplementedException();
		}
	}
}
