using Animals.Core.Business.Bases;
using Animals.Core.Interfaces;
using System;
//Хорошо всё
namespace Animals.Core.Business.Instances
{
	public class Wolf : WildAnimalBase
	{
		public bool IsItAlpha { get; }
		public Wolf(float height, float weight, string eyeColor, string habitat, DateTime dateOfFind, bool isItAlpha, IMakeASoundable aSound) 
			: base(height, weight, eyeColor, habitat, dateOfFind, aSound)
		{
			IsItAlpha = isItAlpha;
		}
		public override void MakeASound()
		{
			ASound.MakeASound();
		}
		public override string ToString()
		{
			return $"{base.ToString()},{IsItAlpha}";
		}
	}

}
