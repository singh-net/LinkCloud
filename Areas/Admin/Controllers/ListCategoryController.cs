using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;

namespace LinkCloud.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class ListCategoryController : BaseAdminController
    {
       
        public ActionResult Index()
        {
            var list = objAdminBL.categoryBL.GetAll().ToList();
            return View(list);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                objAdminBL.categoryBL.Delete(id);
                TempData["Msg"] = "Deleted Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                TempData["Msg"] = "Delete Failed" + e.Message;
                return RedirectToAction("Index");
            }
        }
    }
}