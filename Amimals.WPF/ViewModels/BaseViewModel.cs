using System.ComponentModel;

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
