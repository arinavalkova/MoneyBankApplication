using System;
using System.Linq;
using System.Text;
using MoneyBankApplication.Data;

namespace MoneyBankApplication.Services.SignIn
{
    public class MoneyBankDbSignInService : ISignInService
    {
        private readonly MoneyBankDbContext _moneyBankDbContext;

        public MoneyBankDbSignInService(MoneyBankDbContext moneyBankDbContext)
        {
            _moneyBankDbContext = moneyBankDbContext;
        }

        public void SignIn(Action<string> resultMessage, string login)
        {
            var user = _moneyBankDbContext.Users.FirstOrDefault(x => x.Login == login);
            if (user != null)
            {
                resultMessage(new StringBuilder("Hello " + user.Name + "!").ToString());
            }
            else
            {
                resultMessage("Bad login!");
            }
        }
    }
}