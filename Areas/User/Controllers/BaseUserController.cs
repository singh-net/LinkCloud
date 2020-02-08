using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;

namespace LinkCloud.Areas.User.Controllers
{
   
    public class BaseUserController : Controller
    {
        protected AdminBL objAdminBL;
        public BaseUserController()
        {
            objAdminBL = new AdminBL();
        }
        
    }
}