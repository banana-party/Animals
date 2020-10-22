using Animals.Bases;
using Animals.Core.Interfaces;
using Animals.Sound;
using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Instances
{
	class Wolf : BaseWildAnimal
	{
		public bool IsItAlpha { get; }

		public Wolf(bool isItAlpha, ISoundable soundable) : base(soundable)
		{
			IsItAlpha = isItAlpha;
		}
	}

}
