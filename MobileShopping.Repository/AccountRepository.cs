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
        public DbSet<Mobile> mobileDB { get; set; }

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
        public Account Login(Account account)
        {
            AccountContext accountContext = new AccountContext();
            var result = accountContext.AccountDB.Where(user => user.MailId == account.MailId && user.Password == account.Password).FirstOrDefault();
            return result;
        }
        //public static List<Account> accounts = new List<Account>();
        //static AccountRepository()
        //{
        //    accounts.Add(new Account { UserName = "Sivaselvi", UserId = 1, MailId = "siva@gmail.com", Password = "12345", CreateDate = DateTime.Now, UpdatedDate = DateTime.Now, LastLoginTime = DateTime.Now, Age = 21, Gender = "Female", MobileNo = 9564534231, City = "Chennai" });
        //}
    //    public IEnumerable<Account> GetUserDetails()
    //    {
    //        return accounts;
    //    }
    //    public void AddUser(Account user)
    //    {
    //        accounts.Add(user);
    //    }
    //    public Account GetUserId(string mailId)
    //    {
    //        return accounts.Find(id => id.MailId == mailId);
    //    }
    //    public void DeleteUser(string mailId)
    //    {
    //        Account user = GetUserId(mailId);
    //        if (mailId != null)
    //            accounts.Remove(user);
    //    }
    //    public void UpdateUser(Account user)
    //    {
    //        Account updateUser = GetUserId(user.MailId);
    //        updateUser.UserName = user.UserName;
    //        updateUser.MailId = user.MailId;
    //        updateUser.Password = user.Password;
    //        updateUser.UpdatedDate = user.UpdatedDate;
    //        updateUser.MobileNo = user.MobileNo;
    //        updateUser.LastLoginTime = user.LastLoginTime;
    //        updateUser.Gender = user.Gender;
    //        updateUser.City = user.City;
    //        updateUser.Age = user.Age;
    //    }
    }
}
