using Animals.Interfaces;
using System;

namespace Animals.Bases
{
	public abstract class BaseWildAnimall : BaseAnimal
	{
		protected BaseWildAnimall(ISoundable soundable) : base(soundable)
		{
		}
		public string Habitat { get; set; }
		public DateTime DateOfFind { get; set; }
	}
}
