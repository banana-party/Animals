namespace Animals.Core.Interfaces
{
    public interface IDialogService
	{
		bool ShowYesNoDialog(string text, string caption = null);
        bool ShowErrorDialog(string text, string caption = null);
		void ShowMessage(string text, string caption = null);
    }
}