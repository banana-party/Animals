﻿using Animals.Core.Business.Instances;
using Animals.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Animals.Core.FileParsers
{
    public class CatParser : IParser
	{
		private readonly IMakeASoundable _aSound;
		private readonly INotificationService _notificationService;
		//Надо подумать как избавиться от этих параметрах в парсере, они тут нелогичны абсолютно
		//но никакого разумного решения этого я тут предложить не смогу.
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
			//Не вижу смысл этого метода вообще и не понимаю зачем его включать в Интерфейс
			throw new NotImplementedException();
		}
	}
}
