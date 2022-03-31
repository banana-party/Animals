using Animals.Core.Interfaces;

namespace Animals.Core.FileParsers
{
    public class BaseParser
    {
        protected readonly IMakeASoundable _aSound;
        public BaseParser(IMakeASoundable aSound)
        {
            _aSound = aSound;
        }
    }
}
