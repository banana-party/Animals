using Animals.Core.Interfaces;
using System.Media;

namespace Animals.WPF.Services
{
    class SoundService : IMakeASoundable
    {
        private readonly SoundPlayer _soundPlayer;
        public SoundService(string text)
        {
            _soundPlayer = new SoundPlayer
            {
                SoundLocation = text
            };
            _soundPlayer.Load();
        }
        public void MakeASound()
        {
            _soundPlayer.Play();
        }
    }
}
