using ModelPortal;
using DataAccessBusinessPortal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Vzah.Controllers
{
    public class HelpController : Controller
    {
        VzahBusiness objbui = new VzahBusiness();
        LoginSessionDetails SessLogObj = new LoginSessionDetails();
        public JsonResult GetCountry(int Flag, int BUID, string DESC)
        {
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            XDocument CreateXml = new XDocument(
               new XDeclaration("1.0", "utf-8", ""),
               new XElement("Vzah",
               new XElement("XsdName", ""),
               new XElement("ProcName", "Country_MAST_h"),
               new XElement("pFlag", Flag),
               new XElement("pDESC", DESC),
               new XElement("pUSERID", SessLogObj.UserId),
               new XElement("pBUID", BUID)));
            DataTable Dt = objbui.GetCloud9BusinessList(CreateXml);
            var data = Dt.AsEnumerable().Select(row =>
                  new
                  {
                      text = row.Field<string>("CountryName").ToString(),
                      id = row.Field<int>("CountryId").ToString(),
                  }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetState(int Flag, int BUID, string DESC, int CountryId=0)
        {
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            XDocument CreateXml = new XDocument(
               new XDeclaration("1.0", "utf-8", ""),
               new XElement("Vzah",
               new XElement("XsdName", ""),
               new XElement("ProcName", "State_MAST_h"),
               new XElement("pFlag", Flag),
               new XElement("pCountryId", CountryId),
               new XElement("pDESC", DESC),
               new XElement("pUSERID", SessLogObj.UserId),
               new XElement("pBUID", BUID)));
            DataTable Dt = objbui.GetCloud9BusinessList(CreateXml);
            var data = Dt.AsEnumerable().Select(row =>
                  new
                  {
                      text = row.Field<string>("StateName").ToString(),
                      id = row.Field<int>("StateId").ToString(),
                  }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCity(int Flag, int BUID, string DESC, int StateId=0)
        {
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            XDocument CreateXml = new XDocument(
               new XDeclaration("1.0", "utf-8", ""),
               new XElement("Vzah",
               new XElement("XsdName", ""),
               new XElement("ProcName", "City_MAST_h"),
               new XElement("pFlag", Flag),
               new XElement("pStateId", StateId),
               new XElement("pDESC", DESC),
               new XElement("pUSERID", SessLogObj.UserId),
               new XElement("pBUID", BUID)));
            DataTable Dt = objbui.GetCloud9BusinessList(CreateXml);
            var data = Dt.AsEnumerable().Select(row =>
                  new
                  {
                      text = row.Field<string>("CityName").ToString(),
                      id = row.Field<int>("CityId").ToString(),
                  }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetOccupation(int Flag, int BUID, string DESC)
        {
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            XDocument CreateXml = new XDocument(
               new XDeclaration("1.0", "utf-8", ""),
               new XElement("Vzah",
               new XElement("XsdName", ""),
               new XElement("ProcName", "Occupation_MAST_h"),
               new XElement("pFlag", Flag),  
               new XElement("pDESC", DESC),
               new XElement("pUSERID", SessLogObj.UserId),
               new XElement("pBUID", BUID)));
            DataTable Dt = objbui.GetCloud9BusinessList(CreateXml);
            var data = Dt.AsEnumerable().Select(row =>
                  new
                  {
                      text = row.Field<string>("Occupation").ToString(),
                      id = row.Field<int>("OccupationId").ToString(),
                  }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPurposeOfTravel(int Flag, int BUID, string DESC)
        {
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            XDocument CreateXml = new XDocument(
               new XDeclaration("1.0", "utf-8", ""),
               new XElement("Vzah",
               new XElement("XsdName", ""),
               new XElement("ProcName", "PurposeOfTravel_MAST_h"),
               new XElement("pFlag", Flag),
               new XElement("pDESC", DESC),
               new XElement("pUSERID", SessLogObj.UserId),
               new XElement("pBUID", BUID)));
            DataTable Dt = objbui.GetCloud9BusinessList(CreateXml);
            var data = Dt.AsEnumerable().Select(row =>
                  new
                  {
                      text = row.Field<string>("Purpose_of_Travel").ToString(),
                      id = row.Field<int>("PurposeOfTravelId").ToString(),
                  }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetEntry(int Flag, int BUID, string DESC)
        {
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            XDocument CreateXml = new XDocument(
               new XDeclaration("1.0", "utf-8", ""),
               new XElement("Vzah",
               new XElement("XsdName", ""),
               new XElement("ProcName", "Entry_MAST_h"),
               new XElement("pFlag", Flag),
               new XElement("pDESC", DESC),
               new XElement("pUSERID", SessLogObj.UserId),
               new XElement("pBUID", BUID)));
            DataTable Dt = objbui.GetCloud9BusinessList(CreateXml);
            var data = Dt.AsEnumerable().Select(row =>
                  new
                  {
                      text = row.Field<string>("EntryName").ToString(),
                      id = row.Field<int>("EntryId").ToString(),
                  }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetVisaValidity(int Flag, int BUID, string DESC)
        {
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            XDocument CreateXml = new XDocument(
               new XDeclaration("1.0", "utf-8", ""),
               new XElement("Vzah",
               new XElement("XsdName", ""),
               new XElement("ProcName", "VisaValidity_MAST_h"),
               new XElement("pFlag", Flag),
               new XElement("pDESC", DESC),
               new XElement("pUSERID", SessLogObj.UserId),
               new XElement("pBUID", BUID)));
            DataTable Dt = objbui.GetCloud9BusinessList(CreateXml);
            var data = Dt.AsEnumerable().Select(row =>
                  new
                  {
                      text = row.Field<string>("VisaValidity").ToString(),
                      id = row.Field<int>("VisaValidityId").ToString(),
                  }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetVisaType(int Flag, int BUID, string DESC)
        {
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            XDocument CreateXml = new XDocument(
               new XDeclaration("1.0", "utf-8", ""),
               new XElement("Vzah",
               new XElement("XsdName", ""),
               new XElement("ProcName", "VisaType_MAST_h"),
               new XElement("pFlag", Flag),
               new XElement("pDESC", DESC),
               new XElement("pUSERID", SessLogObj.UserId),
               new XElement("pBUID", BUID)));
            DataTable Dt = objbui.GetCloud9BusinessList(CreateXml);
            var data = Dt.AsEnumerable().Select(row =>
                  new
                  {
                      text = row.Field<string>("VisaType").ToString(),
                      id = row.Field<int>("VisaTypeId").ToString(),
                  }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}