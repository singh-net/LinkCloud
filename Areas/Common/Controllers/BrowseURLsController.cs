using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;

namespace LinkCloud.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class BrowseURLsController : Controller
    {
        private UrlBL objBL;
        public BrowseURLsController()
        {
            objBL = new UrlBL();
        }
        public ActionResult Index(string SortOrder, string SortBy)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var list = objBL.GetAll().Where(x => x.isApproved.Trim() == "A").ToList();


            switch (SortBy)
            {
                case "Title":
                    switch (SortOrder)
                    {
                        case "Asc":
                            list = list.OrderBy(x => x.UrlTitle).ToList();
                            break;
                        case "Desc":
                            list = list.OrderByDescending(x => x.UrlTitle).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "Category":
                    switch (SortOrder)
                    {
                        case "Asc":
                            list = list.OrderBy(x => x.TCategory.CategoryName).ToList();
                            break;
                        case "Desc":
                            list = list.OrderByDescending(x => x.TCategory.CategoryName).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    list = list.OrderBy(x => x.UrlTitle).ToList();
                    break;

            }

            //ViewBag.TotalPages = Math.Ceiling(objBL.GetAll().Where(x => x.isApproved.Trim() == "A").Count() / 10.0);

            return View(list);
        }
    }
}