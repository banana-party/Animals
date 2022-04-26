using Animals.Core.Business.Bases;
using Animals.Core.Interfaces;
using System;

namespace Animals.Core.Business.Instances
{
	public class Tiger : WildAnimalBase
	{
        public Tiger(IMakeASoundable sound, IDialogService dialog) : base(sound, dialog)
        {
        }
    }
}
