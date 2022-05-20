using System;
using MoneyBankApplication.Data;

namespace MoneyBankApplication.Services.SignIn
{
    public class SignInService : ISignInService
    {
        private readonly MoneyBankDbContext _moneyBankDbContext;
        public SignInService(MoneyBankDbContext moneyBankDbContext)
        {
            _moneyBankDbContext = moneyBankDbContext;
        }
        public void SignIn(Action<string> resultMessage, string login)
        {
            resultMessage(login + _moneyBankDbContext.Key);
        }
    }
}