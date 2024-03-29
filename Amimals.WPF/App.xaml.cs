﻿using System;
using System.Windows;
using Animals.Core.Annotations;
using Animals.Core.Interfaces;
using Animals.WPF.Services;
using Animals.WPF.ViewModels;
using Animals.WPF.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Animals.WPF
{
    public partial class App : Application
    {
        private readonly IHost _host;
        public static IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            _host = CreateHostBuilder().Build();
            ServiceProvider = _host.Services;
            _host.Start();
        }

        public static IHostBuilder CreateHostBuilder([CanBeNull] string[] args = null)
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices(ConfigureServices);
        }

        private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            services.AddSingleton<IDialogService, DialogService>()
                .AddSingleton<MainWindowView>()
                .AddSingleton<MainWindowViewModel>()
                .AddTransient<AnimalViewModel>()
                .AddTransient(x => new AddAnimalView { Owner = x.GetRequiredService<MainWindowView>() })
                .AddTransient(x => new EditAnimalView { Owner = x.GetRequiredService<MainWindowView>() });
        }
        protected void OnStartup(object sender, StartupEventArgs e)
        {
            _host.Start();
            var mainWindow = ServiceProvider.GetService<MainWindowView>() ?? throw new NullReferenceException("MainWindow does not exist at service container.");
            mainWindow.Show();
        }
    }
}
