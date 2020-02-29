using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileShopping.Repository;
using MobileShopping.Entity;

namespace MobileShopping.Controllers
{
    public class MobileController : Controller
    {
        MobileRepository mobileRepository;
        public MobileController()
        {
            mobileRepository = new MobileRepository();
        }
        public ActionResult Display()
        {
            IEnumerable<Mobile> mobile = mobileRepository.GetMobileDetails();
            return View(mobile);
        }
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create()
        {
            return View();
        }
        //public ActionResult Create(Mobile mobile)
        //{
        //    mobileRepository.AddMobile(mobile);
        //    TempData["Message"] = "Mobile added successfully!!!";
        //    return RedirectToAction("Display");
        //}
        //public ActionResult Create_Post()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Mobile mobile = new Mobile();
        //        UpdateModel(mobile);
        //        mobileRepository.AddMobile(mobile);
        //        TempData["Message"] = "Mobile added successfully!!!";
        //        return RedirectToAction("Display");
        //    }
        //    return View();
        //}
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            Mobile mobile = new Mobile();
            TryUpdateModel(mobile);
            if (ModelState.IsValid)
            {
                mobileRepository.AddMobile(mobile);
                TempData["Message"] = "Mobile added successfully!!!";
                return RedirectToAction("Display");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            mobileRepository.DeleteMobile(id);
            TempData["Message"] = "Mobile deleted successfully";
            return RedirectToAction("Display");
        }

        public ActionResult Edit(int id)
        {
            Mobile mobile = mobileRepository.GetMobileId(id);
            return View(mobile);
        }
        [HttpPost]
        public ActionResult Update(Mobile mobile)
        {
            mobileRepository.UpdateMobile(mobile);
            TempData["Message"] = "Updated successfully";
            return RedirectToAction("Display");
        }

    }
}