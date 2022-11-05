 
using ModelPortal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Vzah.Controllers
{
    [Authorize]
    public class SqlExecController : Controller
    {
        // GET: SqlExec
        LoginSessionDetails SessLogObj = new LoginSessionDetails();
        [ValidateInput(false)]
        public ActionResult Index()
        {
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            return View();
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult execsql(FormCollection frm)
        {
            string data = frm["data"];

            //data = ModelPortal.LZString.decompressFromBase64(data);

            //****************Added For DataSource By Prajakta********************************
            string SpName = "";
            int flag = Convert.ToInt16(frm["Flag"]);
            int flagForConfig = Convert.ToInt16(frm["FlagForConfig"]);
            if (flag == 1)
            {
                SpName = ModelPortal.LZString.decompressFromBase64(data);
                data = "";
            }
            if (flag == 2)
            {
                data = ModelPortal.LZString.decompressFromBase64(data);
                SpName = "";
            }
            if (flag == 0)
                data = ModelPortal.LZString.decompressFromBase64(data);
            //***************************************************************************

            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            //if (SessLogObj.USERTYPE != 100)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            DataSet Ds;
            //  DataAccessXmlPortal.AdminSetup.RulesXML ObjXML = new DataAccessXmlPortal.AdminSetup.RulesXML();
            //   data = data + "\n select 1";
            XDocument Xdoc = new XDocument(
               new XDeclaration("1.0", "utf-8", ""),
               new XElement("Vzah",
               new XElement("XsdName", ""),
               new XElement("ProcName", "sp_execution_clientside"),
               new XElement("pFLAG", flag),
               //new XElement("pSPNAME", ""), ---------- Change by Prajakta
               new XElement("pSPNAME", SpName),
              new XElement("pDESCRIPTION", data)
            ));

            DataAccessBusinessPortal.VzahBusiness ObjData = new DataAccessBusinessPortal.VzahBusiness();
            ViewBag.typ = "dt";
            try
            {
                Ds = ObjData.GetCloud9BusinessDS(Xdoc);
                ViewBag.typ = "dt";
                ViewBag.ds = Ds;
                //--------- Added to get Column Name Of result for Data Source ------------
                if (flagForConfig == 1)
                {
                    Session["SqlExec"] = Xdoc;
                }
                //--------------------------------------------------------------------------
            }
            catch (Exception ex)
            {
                ViewBag.typ = "err";
                ViewBag.err = ex.Message;
            }

            return View();
        }
       
    }
}