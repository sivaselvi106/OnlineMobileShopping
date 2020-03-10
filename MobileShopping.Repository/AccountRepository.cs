using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileShopping.Entity;

namespace MobileShopping.DAL
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> AccountDB { get; set; }
        public DbSet<Mobile> MobileDB { get; set; }
        
    }
    public class AccountRepository
    {
        public void SignUp(Account user)
        {
            using(AccountContext accountContext = new AccountContext())
            {
                accountContext.AccountDB.Add(user);
                accountContext.SaveChanges();
            }
        }
        public Account GetUserId(string mailId)
        {
            using (AccountContext accountContext = new AccountContext())
            {
            var result = accountContext.AccountDB.Find(mailId);
            return result;
            }
        }
        public Account Login(Account account)
        {
            AccountContext accountContext = new AccountContext();
            var result = accountContext.AccountDB.Where(user => user.MailId == account.MailId && user.Password == account.Password).FirstOrDefault();
            return result;
        }

        public void UpdateUser(Account user)
        { 
            using(AccountContext accountContext = new AccountContext())
            {
            Account updateUser = GetUserId(user.MailId);
            updateUser.UserName = user.UserName;
            updateUser.MailId = user.MailId;
            updateUser.Password = user.Password;
           // updateUser.UpdatedDate = user.UpdatedDate;
            updateUser.MobileNo = user.MobileNo;
            updateUser.LastLoginTime = user.LastLoginTime;
            updateUser.Gender = user.Gender;
            updateUser.City = user.City;
            updateUser.Age = user.Age;
            accountContext.SaveChanges();
            }
        }
        public void DeleteUser(Account user)
        {
            using (AccountContext accountContext = new AccountContext())
            {
            accountContext.AccountDB.Remove(user);
                accountContext.SaveChanges();
            }
        }
    }
}
