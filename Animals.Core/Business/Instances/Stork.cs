using Animals.Core.Business.Bases;
using Animals.Core.Interfaces;

namespace Animals.Core.Business.Instances
{
	public class Stork : BirdBase
	{
        public Stork(IMakeASoundable sound, IDialogService dialog) : base(sound, dialog)
        {
        }
    }
}
