using Amimals.WPF.Services;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Amimals.WPF.Converters
{
	class AnimalToSoundPathConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var i = value as SoundService;
			if (i == null)
			{
				return null;
			}
			return i.SoundPath;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
