using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using BusinessObject;

namespace LinkCloud.Areas.Admin.Controllers
{

    [Authorize (Roles ="A")]
    public class CategoryController : BaseAdminController
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TCategory category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objAdminBL.categoryBL.Insert(category);
                    TempData["Msg"] = "New category added successfully!";
                    return RedirectToAction("Index");
                }

                else
                {
                    return View("Index");
                }
            }
            catch (Exception e)
            {

                TempData["Msg"] = "Error!" + e.Message;
                return RedirectToAction("Index");
            }
        }
    }
}