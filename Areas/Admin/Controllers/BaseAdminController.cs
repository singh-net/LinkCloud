﻿using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkCloud.Areas.Admin.Controllers
{
    public class BaseAdminController : Controller
    {
        protected AdminBL objAdminBL;

        public BaseAdminController()
        {
            objAdminBL = new AdminBL();
        }

       
    }
}