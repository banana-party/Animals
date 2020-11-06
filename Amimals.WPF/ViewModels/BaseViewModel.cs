using System.ComponentModel;
//Всё отлично
namespace Amimals.WPF.ViewModels
{
	public abstract class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public void NotifyOfPropertyChanged(string text)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(text));
		}
	}
}
