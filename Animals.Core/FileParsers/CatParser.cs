using Animals.Core.Business.Bases;
using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Animals.Core.FileParsers
{
	public class CatParser : IParser
	{
		private readonly IMakeASoundable _aSound;
		private readonly INotificationService _notificationService;
		public CatParser(IMakeASoundable aSound, INotificationService notificationService)
		{
			_aSound = aSound;
			_notificationService = notificationService;
		}
		public IAnimal Parse(List<string> lst)
		{
			return new Cat(_aSound, _notificationService, 
				bool.Parse(lst[1]), 
				float.Parse(lst[2], CultureInfo.InvariantCulture), 
				float.Parse(lst[3], CultureInfo.InvariantCulture), 
				lst[4], lst[5], lst[6], 
				bool.Parse(lst[7]), 
				lst[8], 
				DateTime.Parse(lst[9])
				);
		}

		public List<string> Parse(IAnimal animal)
		{
			throw new NotImplementedException();
		}
	}
}
