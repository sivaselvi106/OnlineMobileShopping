using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileShopping.Entity;
using MobileShopping.DAL;

namespace MobileShopping.BL
{
    public class AccountBL
    {
        AccountRepository accountRepository = new AccountRepository();
        public void SignUp(Account user)
        {
            accountRepository.SignUp(user);
        }
        public Account Login(Account user)
        {
            return accountRepository.Login(user);
        }

    }
}
