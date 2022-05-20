using Microsoft.Extensions.DependencyInjection;

namespace MoneyBankApplication.ViewModels.Locators
{
    public class AuthFormViewModelLocator
    {
        public AuthFormViewModel AuthFormViewModel 
            => App.ServiceProvider.GetRequiredService<AuthFormViewModel>();
    }
}