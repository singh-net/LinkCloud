using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;

namespace LinkCloud.Areas.Common.Controllers
{
    public class BaseCommonController : Controller
    {
        protected CommonBL objCommonBL;
        public BaseCommonController()
        {
            objCommonBL = new CommonBL();
        }
  
    }
}