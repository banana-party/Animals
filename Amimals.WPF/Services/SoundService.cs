using Animals.Core.Interfaces;
using System.Media;
//Сделать реализацию этого сервиса
namespace Amimals.WPF.Services
{
	class SoundService : IMakeASoundable
	{
		private SoundPlayer soundPlayer;
		public SoundService()
		{
			soundPlayer = new SoundPlayer();
		}
		public void MakeASound(string str)
		{
			soundPlayer.SoundLocation = str;
			soundPlayer.Play();
		}
		// TODO: класс должен выглядеть примерно так, создать в мввм команду выведения звука, создать кнопку, забиндиться на команду.
	}
}
