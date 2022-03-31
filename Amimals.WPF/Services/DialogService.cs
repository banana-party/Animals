using System.Windows;
using Animals.Core.Interfaces;
//Всё отлично
namespace Animals.WPF.Services
{
	class DialogService : IDialogService
    {
        public bool ShowYesNoDialog(string text, string caption)
        {
            return MessageBox.Show(text, caption, MessageBoxButton.YesNo, MessageBoxImage.Question,
                MessageBoxResult.No, MessageBoxOptions.None) == MessageBoxResult.Yes;
        }
    }
}
