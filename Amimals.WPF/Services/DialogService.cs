using System.Windows;
using Animals.Core.Interfaces;

namespace Animals.WPF.Services
{
	public class DialogService : IDialogService
    {
        public bool ShowYesNoDialog(string text, string caption)
        {
            return MessageBox.Show(text, caption, MessageBoxButton.YesNo, MessageBoxImage.Question,
                MessageBoxResult.No, MessageBoxOptions.None) == MessageBoxResult.Yes;
        }

        public bool ShowErrorDialog(string text, string caption)
        {
            return MessageBox.Show(text, caption, MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK) ==
                   MessageBoxResult.OK;
        }

        public void ShowMessage(string text, string caption)
        {
            MessageBox.Show(text, caption, MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
