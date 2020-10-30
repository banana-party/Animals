using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Animals.Core.FileParsers
{
	public class StorkParser : IParser
	{
		private readonly IMakeASoundable _aSound;
		private readonly INotificationService _notificationService;
		public StorkParser(IMakeASoundable aSound, INotificationService notificationService)
		{
			_aSound = aSound;
			_notificationService = notificationService;
		}
		public IAnimal Parse(List<string> lst)
		{
			return new Stork(_aSound, _notificationService, 
				float.Parse(lst[1], CultureInfo.InvariantCulture), 
				float.Parse(lst[2], CultureInfo.InvariantCulture), 
				lst[3], 
				int.Parse(lst[4]));
		}

		List<string> IParser.Parse(IAnimal animal)
		{
			throw new NotImplementedException();
		}
	}
}
