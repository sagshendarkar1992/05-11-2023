using ModelPortal;
using ModelPortal.BI;
using ModelPortal.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vzah.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        Transaction daccess = new Transaction();
        LoginSessionDetails SessLogObj = new LoginSessionDetails();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ApplicantDetails(int Trn_Id = 0)
        {
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            var dbResult = daccess.GetApplicantDetails(0, 0, Trn_Id, SessLogObj.UserId, "").FirstOrDefault();
            return View(dbResult);
        }
        [HttpPost]

        public ActionResult ApplicantDetails(Transaction obj)
        {
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            BIErrors err = new BIErrors();
            try
            {
                err = daccess.SAVE("I", obj, SessLogObj.UserId);
            }
            catch (Exception ex)
            {
                err.errorID = 0;
                err.errorMsg = "Error ocuured during update.";
            }
            return Json(err, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult DeleteApplicantDetails(int SubApplicantDetails_Id = 0)
        {
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            BIErrors err = new BIErrors();
            try
            {
                Transaction obj = new Transaction();
                obj.Trn_Id = SubApplicantDetails_Id;
                err = daccess.SAVE("D", obj, SessLogObj.UserId);
            }
            catch (Exception ex)
            {
                err.errorID = 0;
                err.errorMsg = "Error ocuured during update.";
            }
            return Json(err, JsonRequestBehavior.AllowGet);
        }
        [ValidateInput(false)]
        public JsonResult ViewSubApplicantDetails(int Page = 1, int Flag = 0, int Trn_Id = 0)
        {
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            var dbResult = daccess.GetSubApplicantDetails(Page, Flag, Trn_Id, SessLogObj.UserId, "");
            return Json(new { aaData = dbResult }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ApplicationForm()
        {
            return View();
        }
        public ActionResult DocumentPDF()
        {
            return View();
        }
        public ActionResult UploadDocument()
        {
            return View();
        }
        public ActionResult DocumentVerification()
        {
            return View();
        }
        public ActionResult DocumentConfirmation()
        {
            return View();
        }
    }
}