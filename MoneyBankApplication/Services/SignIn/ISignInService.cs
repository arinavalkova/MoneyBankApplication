using System;

namespace MoneyBankApplication.Services.SignIn
{
    public interface ISignInService
    {
        public void SignIn(Action<string> resultMessage, string login);
    }
}