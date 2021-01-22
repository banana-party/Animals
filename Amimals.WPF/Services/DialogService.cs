using System.Windows;
using Animals.Core.Interfaces;
//Всё отлично
namespace Amimals.WPF.Services
{
	class DialogService : IDialogService
    {
        public bool ShowYesNoDialog(string text, string caption)
        {
            var res = MessageBox.Show(text, caption, MessageBoxButton.YesNo, MessageBoxImage.Question,
                MessageBoxResult.No, MessageBoxOptions.None);
            return res == MessageBoxResult.Yes;
        }
    }
}
