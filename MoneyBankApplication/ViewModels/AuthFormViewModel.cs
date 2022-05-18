using System.Text;
using System.Windows;
using System.Windows.Controls;
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

        #region SignInCommand

        public Command SignInCommand { get; }

        private void DoSignInCommand(object parameter)
        {
            // if (parameter is PasswordBox passwordBox)
            // {
            //     var password = passwordBox.Password;
            //     ResultMessage = new StringBuilder("Welcome " + Login + " with " + password).ToString();
            // }
            // else
            // {
            //     ResultMessage = "Error: bad password";
            // }
        }

        #endregion
        
        private AsyncCommand asyncCommand2;

        /// <summary>
        /// Gets the command.
        /// </summary>
        public AsyncCommand AsyncCommand2
        {
            get { return asyncCommand2; }
        }

        public AuthFormViewModel()
        {
            SignInCommand = new Command(DoSignInCommand);
            asyncCommand2 = new AsyncCommand(
                () =>
                {
                    for (char c = 'A'; c <= 'Z'; c++)
                    {
                        //  Сообщать о прогрессе
                        asyncCommand2.ReportProgress(() => { ResultMessage += (c.ToString()); });

                        System.Threading.Thread.Sleep(100);
                    }
                });
        }
    }
}