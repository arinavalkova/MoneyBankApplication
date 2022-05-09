using System;
using MoneyBankApplication.ViewModels.Base;

namespace MoneyBankApplication.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string? _login;

        public string? Login
        {
            get => _login;
            set => Set(ref _login, value);
        }
        
    }
}