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
using MoneyBankApplication.Views.Windows;

namespace MoneyBankApplication
{
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;
        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }
        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<MoneyBankDbContext>(options =>
            {
                options.UseNpgsql(@"Host=localhost;Port=5432;Database=MoneyBankDB;Username=postgres;Password=westa");
            });
            services.AddSingleton<AuthorizationWindow>();
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var authorizationWindow = _serviceProvider.GetService<AuthorizationWindow>();
            authorizationWindow.Show();
        }
    }
}