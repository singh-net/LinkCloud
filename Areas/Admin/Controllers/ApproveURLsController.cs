using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using BusinessObject;

namespace LinkCloud.Areas.Admin.Controllers
{

    [Authorize(Roles = "A")]
    public class ApproveURLsController : BaseAdminController
    {

        public ActionResult Index(string status)
        {
            ViewBag.Status = (status == null ? "P" : status);
            if (status == null)
            {
                var list = objAdminBL.urlBL.GetAll().Where(x => x.isApproved.Trim() == "P").ToList();
                return View(list);
            }
            else
            {
                var list = objAdminBL.urlBL.GetAll().Where(x => x.isApproved.Trim() == status).ToList();
                return View(list);
            }
            
        }

        public ActionResult Approve(int id)
        {
            try
            {
                ModelState.Remove("UrlLink");
                var url = objAdminBL.urlBL.GetByID(id);
                url.isApproved = "A";
                objAdminBL.urlBL.Update(url);
                TempData["Msg"] = "Successfull Updated";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                TempData["Msg"] = "Error !" + e.Message;
                return RedirectToAction("Index");
            }
           
        }

        public ActionResult Reject(int id)
        {
            try
            {
                var url = objAdminBL.urlBL.GetByID(id);
                url.isApproved = "R";
                objAdminBL.urlBL.Update(url);
                TempData["Msg"] = "Successfull Updated";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                TempData["Msg"] = "Error !" + e.Message;
                return RedirectToAction("Index");
            }

        }


        [HttpPost]
        public ActionResult  ApproveOrRejectAll(List<int> Ids, string Status, string CurrentStatus)
        {
            //return View();

            try
            {
                objAdminBL.ApproveOrReject(Ids, Status);
                TempData["Msg"] = "Operation Successful";
                var urls = objAdminBL.urlBL.GetAll().Where(x => x.isApproved.Trim() == CurrentStatus).ToList();
                return PartialView("_ApproveURLs", urls);
               
            }
            catch(Exception e)
            {
                TempData["Msg"] = "Operation Failed" + e.Message;
                var urls = objAdminBL.urlBL.GetAll().Where(x => x.isApproved.Trim() == CurrentStatus).ToList();
                return PartialView("_ApproveURLs", urls);
                
            }
        }
    }
}