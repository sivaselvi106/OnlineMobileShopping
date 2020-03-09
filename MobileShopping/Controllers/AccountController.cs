using System.Web.Mvc;
using MobileShopping.Entity;
using MobileShopping.DAL;
using MobileShopping.Models;
using System;
using MobileShopping.BL;

namespace MobileShopping.Controllers
{
    public class AccountController : Controller
    {
        AccountBL accountBL = new AccountBL();
       public ActionResult UserDetails()
        {
            //     AccountContext accountContext = new AccountContext();

           //  List<SignUpModel> user = accountContext.AccountDB.ToList();
            return View();
        }
        public ActionResult DisplayUsers(int userId)
        {
            AccountContext accountContext = new AccountContext();
            Account user = accountContext.AccountDB.Find(userId);
            return View(user);
        }
        [HttpGet]
       public ActionResult SignUp() 
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult SignUp(SignUpModel signUpModel)
        {
            if (ModelState.IsValid)
            {
                Account account = new Account();
                account.UserName = signUpModel.UserName;
                account.UserId = signUpModel.UserId;
                account.MailId = signUpModel.MailId;
                account.Password = signUpModel.Password;
                account.MobileNo = signUpModel.MobileNo;
                account.CreateDate = DateTime.Now;
                account.UpdatedDate = signUpModel.UpdatedDate;
                account.LastLoginTime = signUpModel.LastLoginTime;
                account.Gender = signUpModel.Gender;
                account.Age = signUpModel.Age;
                account.City = signUpModel.City;
                accountBL.SignUp(account);
                //AccountContext accountContext = new AccountContext();
                //accountContext.AccountDB.Add(account);
                //accountContext.SaveChanges();
                ViewBag.Message = "Successfully registered";
                ModelState.Clear();
                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError("", "Some error occurred");
            return View(signUpModel);
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
                Account user = new Account();
                user.MailId = loginModel.MailId;
                user.Password = loginModel.Password;
                var result = accountBL.Login(user);
                if (result != null)
                {
                    Session["MailId"] = result.MailId.ToString();
                    Session["Password"] = result.Password.ToString();
                    return View("DisplayUsers");
                }
                ViewBag.Message = string.Format("Mail Id and password is incorrect");
                return View(user);
        }
        [HttpGet]
        public ActionResult EditUser(int userId) //Edit
        {
            //user.UserId = AccountContext..Find(name => name.UserName == user.UserName).UserId;
            //user.MailId = AccountRepository.accounts.Find(name => name.UserName == user.UserName).MailId;
            //user.CreateDate = AccountRepository.accounts.Find(name => name.UserName == user.UserName).CreateDate;
            AccountContext accountContext = new AccountContext();
            Account user = accountContext.AccountDB.Find(userId);
            return View(user);
        }
        public ActionResult UpdateUser(SignUpModel signUpModel)
        {
            Account user = new Account();
            if (ModelState.IsValid)
            {
                AccountContext accountContext = new AccountContext();
                user = accountContext.AccountDB.Find(signUpModel.UserId);
                if(user != null)
                {
                    user.UserName = signUpModel.UserName;
                 // user.UserId = signUpModel.UserId;
                 //   user.MailId = signUpModel.MailId;
                   // user.MobileNo = signUpModel.MobileNo;
                    user.Gender = signUpModel.Gender;
                    user.Age = signUpModel.Age;
                    user.MobileNo = signUpModel.MobileNo;
                    user.City = signUpModel.City;
                    accountContext.SaveChanges();
                    TempData["Message"] = "User details updated successfully";
                    return RedirectToAction("UserDetails");
                }
            }
            return View(user);
        }
        public ActionResult DeleteUser(int userId) //Delete
        {
            AccountContext accountContext = new AccountContext();
            Account user = accountContext.AccountDB.Find(userId);
            accountContext.AccountDB.Remove(user);
            accountContext.SaveChanges();
            TempData["Message"] = "User updated successfully";
            return RedirectToAction("Display");
        }
    }
}