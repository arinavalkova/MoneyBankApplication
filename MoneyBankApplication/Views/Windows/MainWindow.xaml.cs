using System.Windows;

namespace MoneyBankApplication.Views.Windows
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignUp_OnClick(object sender, RoutedEventArgs e)
        {
            var authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            Hide();
        }
    }
}