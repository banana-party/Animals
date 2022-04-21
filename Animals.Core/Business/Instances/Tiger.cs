using Animals.Core.Business.Bases;
using Animals.Core.Interfaces;
using System;

namespace Animals.Core.Business.Instances
{
	public class Tiger : WildAnimalBase
	{
        public Tiger(IMakeASoundable sound)
        {
            ASound = sound;
        }
		public Tiger(float height, float weight, string eyeColor, string habitat, DateTime dateOfFind, IMakeASoundable aSound) 
			: base(height, weight, eyeColor, habitat, dateOfFind, aSound)
		{
		}
    }
}
