using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;

namespace LinkCloud.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class ListUserController : BaseAdminController
    {
      
        public ActionResult Index()
        {
            var list = objAdminBL.usersBL.GetAll().ToList();
            return View(list);
        }
    }
}