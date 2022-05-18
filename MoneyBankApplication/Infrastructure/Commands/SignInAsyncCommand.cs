using System;
using System.Windows;
using MoneyBankApplication.Infrastructure.Commands.Base;

namespace MoneyBankApplication.Infrastructure.Commands
{
    public class SignInAsyncCommand
    {
        private readonly AsyncCommand _asyncCommand;

        public AsyncCommand AsyncCommand => _asyncCommand;

        public SignInAsyncCommand(Action<string> resultMessage)
        {
            _asyncCommand = new AsyncCommand(
                () =>
                {
                    for (var c = 'A'; c <= 'Z'; c++)
                    {
                        _asyncCommand?.ReportProgress(() => { resultMessage(c.ToString()); });

                        System.Threading.Thread.Sleep(100);
                    }
                });
        }
    }
}