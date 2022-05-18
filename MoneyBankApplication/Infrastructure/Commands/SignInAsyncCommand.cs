using System;
using System.Windows;
using MoneyBankApplication.Data;
using MoneyBankApplication.Infrastructure.Commands.Base;
using MoneyBankApplication.Services;

namespace MoneyBankApplication.Infrastructure.Commands
{
    public class SignInAsyncCommand
    {
        private readonly AsyncCommand _asyncCommand;

        public AsyncCommand AsyncCommand => _asyncCommand;

        public SignInAsyncCommand(Action<string> resultMessage)
        {
            _asyncCommand = new AsyncCommand(
                login =>
                {
                    new SignInService().Invoke(
                        result => _asyncCommand?.ReportProgress(() => { resultMessage(result); }), (string) login);
                    // for (var c = 'A'; c <= 'Z'; c++)
                    // {
                    //     _asyncCommand?.ReportProgress(() => { resultMessage(c.ToString()); });
                    //
                    //     System.Threading.Thread.Sleep(100);
                    // }
                });
        }
    }
}