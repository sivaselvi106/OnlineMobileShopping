﻿using System.Web.Mvc;
using MobileShopping.Entity;
using MobileShopping.Repository;
using MobileShopping.Models;

namespace MobileShopping.Controllers
{
    public class AccountController : Controller
    {
        AccountRepository accountRepository;
        public AccountController()
        {
            accountRepository = new AccountRepository();
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
       public ActionResult EditUser([Bind(Exclude = "UserId,MailId,CreateDate")] Account user)
        {
            return RedirectToAction("Display");
        }
    }
}