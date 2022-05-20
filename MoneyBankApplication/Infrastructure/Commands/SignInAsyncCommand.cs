using System;
using System.Windows;
using MoneyBankApplication.Data;
using MoneyBankApplication.Infrastructure.Commands.Base;
using MoneyBankApplication.Services;
using MoneyBankApplication.Services.SignIn;

namespace MoneyBankApplication.Infrastructure.Commands
{
    public class SignInAsyncCommand
    {
        private readonly AsyncCommand _asyncCommand;

        public AsyncCommand AsyncCommand => _asyncCommand;

        public SignInAsyncCommand(Action<string> resultMessage, SignInService signInService)
        {
            _asyncCommand = new AsyncCommand(
                login =>
                {
                    signInService.SignIn(
                        result => _asyncCommand?.ReportProgress(() => { resultMessage(result); }), (string) login);
                });
        }
    }
}