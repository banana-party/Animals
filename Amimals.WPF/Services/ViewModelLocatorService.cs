using Animals.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Animals.WPF.Services
{
    public class ViewModelLocatorService
    {
        public MainWindowViewModel MainWindowViewModel
            => App.ServiceProvider.GetRequiredService<MainWindowViewModel>();
        public AnimalViewModel AnimalViewModel
            => App.ServiceProvider.GetRequiredService<AnimalViewModel>();
    }
}
