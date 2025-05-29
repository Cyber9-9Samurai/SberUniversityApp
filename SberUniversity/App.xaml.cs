using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using SberUniversity.Model;

namespace SberUniversity
{
    public partial class App : Application
    {
        public static IHost host;

        public App()
        {
            host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<MainWindow>();
                    services.AddTransient<IMail,MailService>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await host.StartAsync();

            var mainWindow = host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
            
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await host.StopAsync(TimeSpan.FromSeconds(5));
            host.Dispose();

            base.OnExit(e);
        }
    }
}
