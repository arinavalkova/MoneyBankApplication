using System.Windows;
using MoneyBankApplication.Infrastructure.Commands.Base;

namespace MoneyBankApplication.ViewModels
{
    internal class AuthFormViewModel : DependencyObject
    {
        #region Login

        private readonly DependencyProperty _loginProperty = DependencyProperty.Register(
            name: "Login",
            propertyType: typeof(string),
            ownerType: typeof(AuthFormViewModel),
            typeMetadata: new FrameworkPropertyMetadata(defaultValue: ""));

        public string Login
        {
            get => (string) GetValue(_loginProperty);
            set => SetValue(_loginProperty, value);
        }

        #endregion

        #region SignInCommand

        public Command SignInCommand { get; }

        private void DoSignInCommand(object obj)
        {
            Login += "Hello";
        }

        #endregion

        public AuthFormViewModel()
        {
            SignInCommand = new Command(DoSignInCommand);
        }
    }
}