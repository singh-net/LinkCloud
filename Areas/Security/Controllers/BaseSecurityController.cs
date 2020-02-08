using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkCloud.Areas.Security.Controllers
{
    public class BaseSecurityController : Controller
    {
        protected AdminBL objAdminBL;

        public BaseSecurityController()
        {
            objAdminBL = new AdminBL();
        }
    }
}