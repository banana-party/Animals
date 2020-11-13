using Animals.Core.Interfaces;
using System.Media;

namespace Amimals.WPF.Services
{
	class SoundService : IMakeASoundable
	{
		private SoundPlayer soundPlayer;
		public SoundService(string text)
		{
			soundPlayer = new SoundPlayer();
			soundPlayer.SoundLocation = text;
			soundPlayer.Load();
		}
		public void MakeASound()
		{
			soundPlayer.Play();
		}
	}
}
