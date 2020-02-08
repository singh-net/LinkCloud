using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessObject;

namespace LinkCloud.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class QuickURLController : BaseCommonController
    {
       
        public ActionResult Index()
        {
            ViewBag.CategoryId = new SelectList(objCommonBL.categoryBL.GetAll().ToList(), "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(QuickSubmitViewModel quickSubmit)
        {

            try
            {
                //objCommonBL.InsertQuickURL(quickSubmit);
                //return RedirectToAction("Index");
                ModelState.Remove("quickUser.Password");
                ModelState.Remove("quickUser.ConfirmPassword");
                //ModelState.Remove("TUser.Password");

                if (ModelState.IsValid)
                {

                    objCommonBL.InsertQuickURL(quickSubmit);
                    return RedirectToAction("Index");
                }
                else
                {

                    ViewBag.CategoryId = new SelectList(objCommonBL.categoryBL.GetAll().ToList(), "CategoryId", "CategoryName");
                    return View("Index");
                }
            }
            catch (Exception e) 
            {

                ViewBag.CategoryId = new SelectList(objCommonBL.categoryBL.GetAll().ToList(), "CategoryId", "CategoryName");
                return View("Index");
            }


        }
    }
}