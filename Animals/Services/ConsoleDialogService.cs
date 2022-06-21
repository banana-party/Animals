using Animals.Core.Interfaces;

namespace Animals.Console.Services
{
	public class ConsoleDialogService : IDialogService
	{
        public bool ShowYesNoDialog(string text, string caption = null)
        {
            throw new System.NotImplementedException();
        }

        public bool ShowErrorDialog(string text, string caption = null)
        {
            throw new System.NotImplementedException();
        }

        public void ShowMessage(string text, string caption = null)
        {
            System.Console.Write(text);
        }
    }
}
