using System.Text;
using System.Windows;
using System.Windows.Controls;
using MoneyBankApplication.Data;
using MoneyBankApplication.Infrastructure.Commands;
using MoneyBankApplication.Infrastructure.Commands.Base;
using MoneyBankApplication.Services;
using MoneyBankApplication.Services.SignIn;

namespace MoneyBankApplication.ViewModels
{
    public class AuthFormViewModel : DependencyObject
    {
        private const string SignInStateString = "Signing in...";

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

        #region Password

        private readonly DependencyProperty _passwordProperty = DependencyProperty.Register(
            name: "Password",
            propertyType: typeof(string),
            ownerType: typeof(AuthFormViewModel),
            typeMetadata: new FrameworkPropertyMetadata(defaultValue: ""));

        public string Password
        {
            get => (string) GetValue(_passwordProperty);
            set => SetValue(_passwordProperty, value);
        }

        #endregion

        #region ResultMessage

        private readonly DependencyProperty _resultMessage = DependencyProperty.Register(
            name: "ResultMessage",
            propertyType: typeof(string),
            ownerType: typeof(AuthFormViewModel),
            typeMetadata: new FrameworkPropertyMetadata(defaultValue: ""));

        public string ResultMessage
        {
            get => (string) GetValue(_resultMessage);
            set => SetValue(_resultMessage, value);
        }

        #endregion

        private readonly SignInAsyncCommand _signInAsyncCommand;

        public AsyncCommand SignInCommand => _signInAsyncCommand.AsyncCommand;

        public AuthFormViewModel(SignInService signInService)
        {
            _signInAsyncCommand = new SignInAsyncCommand( result => ResultMessage += result, signInService);
        }
    }
}