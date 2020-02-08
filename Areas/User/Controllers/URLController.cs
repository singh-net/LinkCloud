using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessObject;
using BusinessLogic;

namespace LinkCloud.Areas.User.Controllers
{
    [Authorize(Roles = "A, U")]
    public class URLController : BaseUserController
    {

        public ActionResult Index()
        {
            //LinkCloudDBEntities linkCloudDBEntities = new LinkCloudDBEntities();
            ViewBag.CategoryId = new SelectList(objAdminBL.categoryBL.GetAll().ToList(), "CategoryId", "CategoryName");
            //ViewBag.UserId = new SelectList(objAdminBL.usersBL.GetAll().ToList(), "UserId", "FirstName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(TUrl url)
        {
            url.UserId = objAdminBL.usersBL.GetAll().Where(x => x.Email == User.Identity.Name).FirstOrDefault().UserId;

            if(ModelState.IsValid)
            {
                url.isApproved = "P";
                objAdminBL.urlBL.Insert(url);
                TempData["Msg"] = "Record Created";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Msg"] = "Failed";
                ViewBag.CategoryId = new SelectList(objAdminBL.categoryBL.GetAll().ToList(), "CategoryId", "CategoryName");
                //ViewBag.UserId = new SelectList(objAdminBL.usersBL.GetAll().ToList(), "UserId", "FirstName");
                return View("Index");
            }
           
        }



    }
}