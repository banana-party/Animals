using Animals.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Animals.WPF.Services
{
    public class ViewModelLocatorService
    {
        public MainWindowViewModel MainWindowViewModel
            => App.ServiceProvider.GetRequiredService<MainWindowViewModel>();
        public AddAnimalViewModel AddAnimalViewModel
            => App.ServiceProvider.GetRequiredService<AddAnimalViewModel>();
        public EditAnimalViewModel EditAnimalViewModel
            => App.ServiceProvider.GetRequiredService<EditAnimalViewModel>();
    }
}
