using System;
using System.Linq;
using System.Text;
using MoneyBankApplication.Data;

namespace MoneyBankApplication.Services.SignIn
{
    public class MoneyBankDbSignInService : ISignInService
    {
        private const string SignInStateString = "Signing in...";
        private readonly MoneyBankDbContext _moneyBankDbContext;

        public MoneyBankDbSignInService(MoneyBankDbContext moneyBankDbContext)
        {
            _moneyBankDbContext = moneyBankDbContext;
        }

        public void SignIn(Action<string> resultMessage, string login)
        {
            resultMessage(SignInStateString);
            var user = _moneyBankDbContext.Users.FirstOrDefault(x => x.Login == login);
            resultMessage(user != null ? new StringBuilder("Hello " + user.Name + "!").ToString() : "Bad login!");
        }
    }
}