using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Animals.Core.FileParsers
{
	public class WolfParser : IParser
	{
		private readonly IMakeASoundable _aSound;
		private readonly INotificationService _notificationService;
		public WolfParser(IMakeASoundable aSound, INotificationService notificationService)
		{
			_aSound = aSound;
			_notificationService = notificationService;
		}
		public IAnimal Parse(List<string> lst)
		{
			return new Wolf(_aSound, _notificationService, bool.Parse(lst[1]), float.Parse(lst[2], CultureInfo.InvariantCulture), float.Parse(lst[3], CultureInfo.InvariantCulture), lst[4], lst[5], DateTime.Parse(lst[6]));
		}


		List<string> IParser.Parse(IAnimal animal)
		{
			throw new NotImplementedException();
		}
	}
}
