using System.Web.Mvc;
using MobileShopping.Entity;
using MobileShopping.Repository;
using MobileShopping.Models;
using System;

namespace MobileShopping.Controllers
{
    public class AccountController : Controller
    {
        //MobileDBContext accountRepository;
        public AccountController()
        {
            //accountRepository = new MobileDBContext();
        }
        [HttpGet]
        [ActionName("SignUp")]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [ActionName("SignUp")]
        public ActionResult SignUp_Post(SignUpModel signUpModel)
        {
            //TryUpdateModel(user);
            if (ModelState.IsValid)
            {
                Account user = new Account();
                user.UserName = signUpModel.UserName;
                user.UserId = signUpModel.UserId;
                user.MailId = signUpModel.MailId;
                user.Password = signUpModel.Password;
                user.MobileNo = signUpModel.MobileNo;
                user.CreateDate = signUpModel.CreateDate;
                user.UpdatedDate = signUpModel.UpdatedDate;
                user.LastLoginTime = signUpModel.LastLoginTime;
                user.Gender = signUpModel.Gender;
                user.Age = signUpModel.Age;
                user.City = signUpModel.City;
                // accountRepository.AddUser(user);
                TempData["Message"] = "User added successfully!!!";
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            //TryUpdateModel(user);
            if (ModelState.IsValid)
            {
                Account user = new Account();
                user.MailId = loginModel.MailId;
                user.Password = loginModel.Password;
            }
            return View();
        }
        //public ActionResult EditUser([Bind(Exclude = "UserId,MailId,CreateDate")] Account user)
        //{
        //    user.UserId = AccountRepository.accounts.Find(name => name.UserName == user.UserName).UserId;
        //    user.MailId = AccountRepository.accounts.Find(name => name.UserName == user.UserName).MailId;
        //    user.CreateDate = AccountRepository.accounts.Find(name => name.UserName == user.UserName).CreateDate;
        //    user.UpdatedDate = DateTime.Now;
        //    if (ModelState.IsValid)
        //    {
        //        accountRepository.UpdateUser(user);
        //        TempData["Message"] = "User details edited successfully";
        //        return RedirectToAction("Display");
        //    }
        //    return View(user);
        //}
    }
}