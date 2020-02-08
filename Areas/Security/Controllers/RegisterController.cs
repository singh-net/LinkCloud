using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using BusinessObject;

namespace LinkCloud.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class RegisterController : BaseSecurityController
    {
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TUser user)
        {
            if (ModelState.IsValid)
            {
                user.DateJoined = System.DateTime.Today;
                user.Role = "U";
                objAdminBL.usersBL.Insert(user);

                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }
    }
}