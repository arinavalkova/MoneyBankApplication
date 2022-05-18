using System;
using MoneyBankApplication.Data;

namespace MoneyBankApplication.Services
{
    public class SignInService
    {
        public SignInService()
        {
            
        }

        public void Invoke(Action<string> resultMessage, string login)
        {
            resultMessage(login);
        }
    }
}