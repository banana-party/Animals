using Animals.Core.Business.Bases;
using Animals.Core.Interfaces;
using System;
//Хорошо всё
namespace Animals.Core.Business.Instances
{
	public class Tiger : WildAnimalBase
	{
		public Tiger(float height, float weight, string eyeColor, string habitat, DateTime dateOfFind, IMakeASoundable aSound) 
			: base(height, weight, eyeColor, habitat, dateOfFind, aSound)
		{
		}
		public override void MakeASound()
		{
			ASound.MakeASound();
		}
	}
}
