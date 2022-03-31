using System;

namespace Animals.Core.Interfaces
{
    public interface IAnimal : ICloneable
	{
        float Height { get; set; }
        float Weight { get; set; }
        string EyeColor { get; set; }
		void MakeASound();
	}
}
