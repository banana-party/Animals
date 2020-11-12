using Animals.Core.Interfaces;
using System;
using System.Globalization;
using System.Windows.Data;
using Animals.Core.Business.Bases;

namespace Amimals.WPF.Converters
{
	class AnimalToStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			/*Необходимо проводить проверки на принимаемое значение и его тип, так же не надо вызывать ToString у принимаемого типа,
                Это бесполезно и непонятно для пользователя			 
			 */
			if (value == null)
				throw new NullReferenceException("Reference was null"); // TODO: кинуть эксепшн
			if (value is AnimalBase animal)
			{
				return animal.Type(); //вызывать экстеншн на энимал
			}
			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
