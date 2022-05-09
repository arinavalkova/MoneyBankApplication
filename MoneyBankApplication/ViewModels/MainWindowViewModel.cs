using MoneyBankApplication.ViewModels.Base;

namespace MoneyBankApplication.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string? _title = "MoneyBank";

        public string? Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
    }
}