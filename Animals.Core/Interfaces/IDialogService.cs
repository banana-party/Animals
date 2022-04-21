namespace Animals.Core.Interfaces
{
	//Хорошая реализация, но caption можно сделать необязательным параметром под Console
	public interface IDialogService
	{
		bool ShowYesNoDialog(string text, string caption);
        bool ShowErrorDialog(string text, string caption);
    }
}