using Animals.Core.Interfaces;

namespace Animals.Core.FileParsers
{
    public class BaseParser
    {
        protected readonly IMakeASoundable ASound;
        protected readonly IDialogService DialogService;
        public BaseParser(IMakeASoundable aSound, IDialogService dialog)
        {
            ASound = aSound;
            DialogService = dialog;
        }
    }
}
