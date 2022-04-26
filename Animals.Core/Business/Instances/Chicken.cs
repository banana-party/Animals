using Animals.Core.Business.Bases;
using Animals.Core.Interfaces;

namespace Animals.Core.Business.Instances
{
	public class Chicken : BirdBase
	{
        public Chicken(IMakeASoundable sound, IDialogService dialog) : base(sound, dialog)
        {
        }
    }
}
