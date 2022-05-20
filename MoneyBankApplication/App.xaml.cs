using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoneyBankApplication.Data;
using MoneyBankApplication.Infrastructure.Commands;
using MoneyBankApplication.Services;
using MoneyBankApplication.Services.SignIn;
using MoneyBankApplication.ViewModels;
using MoneyBankApplication.Views.Windows;

namespace MoneyBankApplication
{
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider { get; set; }

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<MoneyBankDbContext>(options =>
            {
                options.UseNpgsql(
                    @"Host=localhost;Port=5432;Database=MoneyBankDB;Username=postgres;Password=westa");
            });
            services.AddTransient<SignInAsyncCommand>();
            services.AddTransient(provider =>
                new SignInService(provider.GetService<MoneyBankDbContext>()!));
            services.AddSingleton(provider => new AuthFormViewModel(provider.GetService<SignInService>()!));
            services.AddTransient<AuthorizationWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var authorizationWindow = ServiceProvider.GetService<AuthorizationWindow>();
            authorizationWindow.Show();
        }
    }
}