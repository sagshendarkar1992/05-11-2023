using ModelPortal;
using ModelPortal.BI;
using ModelPortal.Db_Connection;
using ModelPortal.Transaction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Xml.Linq;
using Vzah.Models;

namespace Vzah.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {

        SendEmail objmailsending = new SendEmail();
        Transaction daccess = new Transaction();
        LoginSessionDetails SessLogObj = new LoginSessionDetails();
        public string SendEmailInitialTransaction(InitialLoad objloaddetails)
        {
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            EmailSendingMaster sendingdetails = new EmailSendingMaster();
            EmailCredentials cred;
            objmailsending.EmailSending("Intitial SetUp", out cred, out sendingdetails);
            StreamReader DocumentUpload = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/InitialLoad.html"));
            string Content = "";
            sendingdetails.TO = SessLogObj.EMAIL_ADDRESS;
            Content = DocumentUpload.ReadToEnd();
            Content = Content.Replace("#TravellingFrom", objloaddetails.TravellingFromName);
            Content = Content.Replace("#TravellingTo", objloaddetails.TravellingToName);
            Content = Content.Replace("#PassportHoldingCountry", objloaddetails.PassportHoldingCountryName);
            Content = Content.Replace("#PurposeOfTravel", objloaddetails.PurposeOfTravel);
            Content = Content.Replace("#NumberOfDays", objloaddetails.NumberOfDays.ToString());
            Content = Content.Replace("#DateOfTravel", objloaddetails.DateOfTravel);
            Content = Content.Replace("#EntryRequirements", objloaddetails.EntryName);
            objmailsending.SendEmailTemplate(sendingdetails, Content, cred.HOST, cred.FROM, Convert.ToInt32(cred.Port), cred.DeliveryMethod, cred.EnableSsl);
            return "Success";
        }
        public string SendApplicantDetails(List<Transaction> objloaddetails)
        {
            string SubApplicantTable = "";
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            EmailSendingMaster sendingdetails = new EmailSendingMaster();
            EmailCredentials cred;
            objmailsending.EmailSending("Applicant Details", out cred, out sendingdetails);
            StreamReader DocumentUpload = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/ApplicantDetails.html"));
            string Content = "";
            sendingdetails.TO = SessLogObj.EMAIL_ADDRESS;
            Content = DocumentUpload.ReadToEnd();
            Content = Content.Replace("#ApplicantName", objloaddetails[0].ApplicantName);
            Content = Content.Replace("#Ageofapplicant", objloaddetails[0].ApplicantAge.ToString());
            Content = Content.Replace("#ApplicantMobileNumber", objloaddetails[0].ApplicantMobileNumber);
            SubApplicantTable += "<table border='1'><tr><th>Sub Applicant Name</th><th>Age of Sub applicant</th><th>Sub Applicant Mobile</th><th>Relation</th></tr>";
            foreach (var item in objloaddetails)
            {
                SubApplicantTable += "<tr><td>" + item.SubApplicantName + "</td> <td>" + item.SubApplicantAge + "</td> <td>" + item.SubApplicantMobileNumber + "</td> <td>" + item.Relation + "</td></tr>";
            }
            Content = Content.Replace("#SubApplicantTable", SubApplicantTable);
            objmailsending.SendEmailTemplate(sendingdetails, Content, cred.HOST, cred.FROM, Convert.ToInt32(cred.Port), cred.DeliveryMethod, cred.EnableSsl);
            return "Success";
        }
        public string SendApplicantForm(TravelDetails objloaddetails)
        {
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            EmailSendingMaster sendingdetails = new EmailSendingMaster();
            EmailCredentials cred;
            objmailsending.EmailSending("Applicant Details", out cred, out sendingdetails);
            StreamReader DocumentUpload = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/TravelDetails.html"));
            string Content = "";
            sendingdetails.TO = SessLogObj.EMAIL_ADDRESS;
            Content = DocumentUpload.ReadToEnd();
            Content = Content.Replace("#Country", objloaddetails.CountryName);
            Content = Content.Replace("#State", objloaddetails.StateName.ToString());
            Content = Content.Replace("#City", objloaddetails.CityName);
            Content = Content.Replace("#Age", objloaddetails.Age.ToString());
            Content = Content.Replace("#Occupation", objloaddetails.Occupation.ToString());
            Content = Content.Replace("#PurposeOfTravel", objloaddetails.Purpose_of_Travel);
            Content = Content.Replace("#EntryRequirements", objloaddetails.EntryName);

            Content = Content.Replace("#VisaValidity", objloaddetails.VisaValidity);
            Content = Content.Replace("#ProcessionTime", objloaddetails.ProcessingTime);
            Content = Content.Replace("#VisaFees", objloaddetails.VisaFees.ToString());
            Content = Content.Replace("#VisaType", objloaddetails.VisaType);
            objmailsending.SendEmailTemplate(sendingdetails, Content, cred.HOST, cred.FROM, Convert.ToInt32(cred.Port), cred.DeliveryMethod, cred.EnableSsl);
            return "Success";
        }
        public string SendDocumentDetails(List<DocumentDetails> objloaddetails)
        {
            string SubApplicantTable = "";
            if (objloaddetails[0].Doc_MasterCount == objloaddetails[0].Doc_TransactionCount)
            {
                string docurl = "https://google.com"; //System.Configuration.ConfigurationManager.AppSettings["docurl"];

                SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
                EmailSendingMaster sendingdetails = new EmailSendingMaster();
                EmailCredentials cred;
                objmailsending.EmailSending("Document Verification", out cred, out sendingdetails);
                StreamReader DocumentUpload = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/DocumentUpload.html"));
                string Content = "";
                sendingdetails.TO = SessLogObj.EMAIL_ADDRESS;
                Content = DocumentUpload.ReadToEnd();
                SubApplicantTable += "<table border='1'><tr><th>Document Name</th><th>Doc Extension</th><th>Document</th></tr>";
                foreach (var item in objloaddetails)
                {
                    SubApplicantTable += "<tr><td>" + item.Document_Name + "</td> <td>" + item.FileExtension + "</td> <td><img src='" + docurl + "/UploadedImages/DocumentUpload/" + item.Path + "' style='width: 89px; height: 49px;'></td></tr>";
                }
                Content = Content.Replace("#ImageDetails", SubApplicantTable);
                objmailsending.SendEmailTemplate(sendingdetails, Content, cred.HOST, cred.FROM, Convert.ToInt32(cred.Port), cred.DeliveryMethod, cred.EnableSsl);
            }
            return "Success";
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SideBar(int Trn_Id = 0)
        {
            return View();
        }

        public JsonResult GetSideBarStatus(int Trn_Id = 0)
        {
            Transaction obj = new Transaction();
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            var dbResult = daccess.GetApplicantDetails(0, 0, Trn_Id, SessLogObj.UserId, "").FirstOrDefault();
            return Json(new { aaData = dbResult == null ? obj : dbResult }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]

        public ActionResult InitialLoad(InitialLoad obj)
        {
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            BIErrors err = new BIErrors();
            try
            {
                err = daccess.SaveInitialLoad("I", obj, SessLogObj.UserId);
                InitialLoad objloaddetails = EmailInitialLoadDetails();
                var emailsent = err.errorID == -1 ? "" : SendEmailInitialTransaction(objloaddetails);
            }
            catch (Exception ex)
            {
                err.errorID = 0;
                err.errorMsg = "Error ocuured during update.";
            }
            return Json(err, JsonRequestBehavior.AllowGet);
        }
        public InitialLoad EmailInitialLoadDetails()
        {
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            var dbResult = daccess.GetInitialLoadDetails(0, 0, 0, SessLogObj.UserId, "").FirstOrDefault();
            return dbResult;
        }

        public TravelDetails EmailApplicationForm(int Trn_Id = 0)
        {
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            var dbResult = daccess.GetApplicantTravelDetails(1, 0, Trn_Id, SessLogObj.UserId, "").FirstOrDefault();
            return dbResult;
        }
        [HttpGet]
        public List<Transaction> EmailApplicantDetails(int Trn_Id = 0)
        {
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            var dbResult = daccess.GetSubApplicantDetails(1, 0, Trn_Id, SessLogObj.UserId, "");
            return dbResult;
        }
        public ActionResult InitialLoad()
        {
            InitialLoad obj = new InitialLoad();
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            var dbResult = daccess.GetInitialLoadDetails(0, 0, 0, SessLogObj.UserId, "").FirstOrDefault();
            return View(dbResult == null ? obj : dbResult);
        }
        [HttpGet]
        public ActionResult ApplicantDetails(int Trn_Id = 0)
        {
            Transaction obj = new Transaction();
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            var dbResult = daccess.GetApplicantDetails(0, 0, Trn_Id, SessLogObj.UserId, "").FirstOrDefault();
            return View(dbResult == null ? obj : dbResult);
        }
        [HttpPost]
        public ActionResult ApplicantDetails(Transaction obj)
        {
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            BIErrors err = new BIErrors();
            try
            {
                err = daccess.SaveApplicantDetails("I", obj, SessLogObj.UserId);
                List<Transaction> objloaddetails = EmailApplicantDetails(err.errorID);
                var emailsent = err.errorID == -1 ? "" : SendApplicantDetails(objloaddetails);
            }
            catch (Exception ex)
            {
                err.errorID = 0;
                err.errorMsg = "Error ocuured during update.";
            }
            return Json(err, JsonRequestBehavior.AllowGet);
        }
        [ValidateInput(false)]
        public ActionResult CHECKIFDATAEXIST(string SubApplicantName, int Trn_Id)
        {
            BIErrors err = new BIErrors();
            Transaction obj = new Transaction();
            obj.Trn_Id = Trn_Id; obj.SubApplicantName = SubApplicantName;
            obj.SubApplicantAge = 0; obj.ApplicantAge = 0;
            err = daccess.SaveApplicantDetails("C", obj, 0);
            if (err.errorID > 0)
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
        }
        public ActionResult DeleteApplicantDetails(int SubApplicantDetails_Id = 0)
        {
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            BIErrors err = new BIErrors();
            try
            {
                Transaction obj = new Transaction();
                obj.Trn_Id = SubApplicantDetails_Id;
                obj.SubApplicantAge = 0; obj.ApplicantAge = 0;
                err = daccess.SaveApplicantDetails("D", obj, SessLogObj.UserId);
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
        public ActionResult ApplicationForm(int Trn_Id = 0)
        {
            TravelDetails obj = new TravelDetails();
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            var dbResult = daccess.GetApplicantTravelDetails(0, 0, Trn_Id, SessLogObj.UserId, "").FirstOrDefault();
            return View(dbResult == null ? obj : dbResult);
        }
        [HttpPost]

        public ActionResult ApplicationForm(TravelDetails obj)
        {
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            BIErrors err = new BIErrors();
            try
            {
                err = daccess.SaveTravelDetails(obj.Travel_Id > 0 ? "E" : "I", obj, SessLogObj.UserId);
                TravelDetails objloaddetails = EmailApplicationForm(obj.Trn_IdTravel);
                var emailsent = err.errorID == -1 ? "" : SendApplicantForm(objloaddetails);
            }
            catch (Exception ex)
            {
                err.errorID = 0;
                err.errorMsg = "Error ocuured during update.";
            }
            return Json(err, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DocumentPDF()
        {
            return View();
        }
        public ActionResult UploadDocument(int Trn_Id = 0)
        {
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            var dbResult = daccess.GetUploadMastDetails(0, 0, Trn_Id, SessLogObj.UserId, "").ToList();
            return View(dbResult);
        }
        public ActionResult Verification(int Trn_Id = 0)
        {
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            var dbResult = daccess.GetUploadedDetails(0, 1, Trn_Id, SessLogObj.UserId, "").ToList();
            return View(dbResult);
        }
        public ActionResult Confirmation(int Trn_Id = 0)
        {
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            var dbResult = daccess.GetUploadMastDetails(0, 0, Trn_Id, SessLogObj.UserId, "").ToList();
            return View(dbResult);
        }
        [HttpPost]
        public ActionResult UploadFiles()
        {
            BIErrors err = new BIErrors();
            if (Request.Files.Count > 0)
            {
                try
                {
                    string folderpath = Path.Combine(this.Server.MapPath(WebConfigurationManager.AppSettings["DocumentUpload"]));

                    SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
                    List<DocumentDetails> Imgobj = new List<DocumentDetails>();
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        DocumentDetails imgrowtoadd = new DocumentDetails();
                        string strtick = DateTime.Now.Ticks.ToString();
                        var InputFileName = Path.GetFileName(Request.Files[i].FileName);
                        if (!System.IO.Directory.Exists(folderpath))
                        {
                            System.IO.Directory.CreateDirectory(folderpath);
                        }
                        string filename = Path.Combine(folderpath, strtick + InputFileName);
                        var fileimagetosave = strtick + InputFileName;
                        file.SaveAs(filename);
                        Stream strm = file.InputStream;
                        var extension = Path.GetExtension(file.FileName);
                        //Compressimage(strm, filename, file.FileName);
                        imgrowtoadd.Path = fileimagetosave;
                        imgrowtoadd.Doc_Id = Convert.ToInt32(Request.Form["Doc_Id"]);
                        imgrowtoadd.Trn_IdDoc = Convert.ToInt32(Request.Form["Trn_IdDoc"]);
                        imgrowtoadd.FileExtension = extension;
                        Imgobj.Add(imgrowtoadd);
                    }
                    //------------------------------------------------------------
                    XElement xmlImgElements = new XElement("IMAGEDATA",
                    Imgobj.Select(m => new XElement("IMAGEDATAOBJ",
                                               new XAttribute("Path", m.Path),
                                               new XAttribute("Doc_Id", m.Doc_Id),
                                               new XAttribute("Trn_IdDoc", m.Trn_IdDoc),
                                               new XAttribute("FileExtension", m.FileExtension)
                                               )));
                    err = daccess.SaveImageDetails(xmlImgElements, "I", SessLogObj.UserId);
                    List<DocumentDetails> objloaddetails = EmailDocumentVerification(Convert.ToInt32(Request.Form["Trn_IdDoc"]));
                    var emailsent = err.errorID == -1 ? "" : SendDocumentDetails(objloaddetails);
                    //----------------------------------------
                    return Json(err, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    err.flag = "D";
                    err.errorID = 0; err.errorMsg = ex.Message;
                    return Json(err, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                err.flag = "D";
                err.errorID = 0; err.errorMsg = "No File Selected";
                return Json(err, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult UploadDocument(DocumentDetails obj, FormCollection fm, HttpPostedFileBase[] files)
        {
            BIErrors err = new BIErrors();
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            string folderpath = Path.Combine(this.Server.MapPath(WebConfigurationManager.AppSettings["DocumentUpload"]));
            List<DocumentDetails> Imgobj = new List<DocumentDetails>();
            try
            {
                if (files != null)
                {
                    int i = 0;
                    foreach (HttpPostedFileBase file in files)
                    {
                        if (file != null)
                        {
                            DocumentDetails imgrowtoadd = new DocumentDetails();
                            string strtick = DateTime.Now.Ticks.ToString();
                            var InputFileName = Path.GetFileName(file.FileName);
                            if (!System.IO.Directory.Exists(folderpath))
                            {
                                System.IO.Directory.CreateDirectory(folderpath);
                            }
                            string filename = Path.Combine(folderpath, strtick + InputFileName);
                            var fileimagetosave = strtick + InputFileName;
                            file.SaveAs(filename);
                            Stream strm = file.InputStream;
                            var extension = Path.GetExtension(file.FileName);
                            Compressimage(strm, filename, file.FileName);
                            imgrowtoadd.Path = fileimagetosave;
                            imgrowtoadd.Doc_Id = Convert.ToInt32(Request.Form["Doc[" + i + "].Doc_Id"]);
                            imgrowtoadd.Trn_IdDoc = Convert.ToInt32(Request.Form["Doc[" + i + "].Trn_IdDoc"]);

                            Imgobj.Add(imgrowtoadd);
                        }
                        i++;
                    }
                    //------------------------------------------------------------
                    XElement xmlImgElements = new XElement("IMAGEDATA",
                    Imgobj.Select(m => new XElement("IMAGEDATAOBJ",
                                               new XAttribute("Path", m.Path),
                                               new XAttribute("Doc_Id", m.Doc_Id),
                                               new XAttribute("Trn_IdDoc", m.Trn_IdDoc)
                                               )));
                    TempData["Success"] = "Added Successfully!";
                    //----------------------------------------
                    err = daccess.SaveImageDetails(xmlImgElements, "I", SessLogObj.UserId);
                }
                return Json(err, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                err.errorID = 0;
                err.errorMsg = "Error ocuured during update.";
                return Json(err, JsonRequestBehavior.AllowGet);
            }
            return View();
        }
        public static void Compressimage(Stream sourcePath, string targetPath, String filename)
        {
            try
            {
                using (var image = Image.FromStream(sourcePath))
                {
                    float maxHeight = 900.0f;
                    float maxWidth = 900.0f;
                    int newWidth;
                    int newHeight;
                    string extension;
                    Bitmap originalBMP = new Bitmap(sourcePath);
                    int originalWidth = originalBMP.Width;
                    int originalHeight = originalBMP.Height;

                    if (originalWidth > maxWidth || originalHeight > maxHeight)
                    {

                        // To preserve the aspect ratio  
                        float ratioX = (float)maxWidth / (float)originalWidth;
                        float ratioY = (float)maxHeight / (float)originalHeight;
                        float ratio = Math.Min(ratioX, ratioY);
                        newWidth = (int)(originalWidth * ratio);
                        newHeight = (int)(originalHeight * ratio);
                    }
                    else
                    {
                        newWidth = (int)originalWidth;
                        newHeight = (int)originalHeight;

                    }
                    Bitmap bitMAP1 = new Bitmap(originalBMP, newWidth, newHeight);
                    Graphics imgGraph = Graphics.FromImage(bitMAP1);
                    extension = Path.GetExtension(targetPath);
                    if (extension == ".png" || extension == ".gif")
                    {
                        imgGraph.SmoothingMode = SmoothingMode.AntiAlias;
                        imgGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        imgGraph.DrawImage(originalBMP, 0, 0, newWidth, newHeight);


                        bitMAP1.Save(targetPath, image.RawFormat);

                        bitMAP1.Dispose();
                        imgGraph.Dispose();
                        originalBMP.Dispose();
                    }
                    else if (extension == ".jpg")
                    {

                        imgGraph.SmoothingMode = SmoothingMode.AntiAlias;
                        imgGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        imgGraph.DrawImage(originalBMP, 0, 0, newWidth, newHeight);
                        ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                        Encoder myEncoder = Encoder.Quality;
                        EncoderParameters myEncoderParameters = new EncoderParameters(1);
                        EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 60L);
                        myEncoderParameters.Param[0] = myEncoderParameter;
                        bitMAP1.Save(targetPath, jpgEncoder, myEncoderParameters);

                        bitMAP1.Dispose();
                        imgGraph.Dispose();
                        originalBMP.Dispose();

                    }
                }

            }
            catch (Exception)
            {
                throw;

            }
        }
        public static ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
        public ActionResult DocumentVerification(int Trn_Id = 0)
        {
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            var dbResult = daccess.GetUploadedDetails(0, 0, Trn_Id, SessLogObj.UserId, "").ToList();
            return View(dbResult);
        }
        public List<DocumentDetails> EmailDocumentVerification(int Trn_Id = 0)
        {
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            var dbResult = daccess.GetUploadedDetails(0, 0, Trn_Id, SessLogObj.UserId, "").ToList();
            return dbResult;
        }
        public ActionResult DocumentConfirmation(int Trn_Id = 0)
        {
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            var dbResult = daccess.GetUploadedDetails(0, 1, Trn_Id, SessLogObj.UserId, "").ToList();
            return View(dbResult);
        }
        public ActionResult Payment(int Trn_Id = 0)
        {
            BIErrors err = new BIErrors();
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            err = daccess.SavePaymentDetails(Trn_Id, "I", SessLogObj.UserId);
            return Json(err, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TopApplicantDetails(int Trn_Id = 0)
        {
            SessLogObj = (LoginSessionDetails)HttpContext.Session["SessionInformation"];
            var dbResult = daccess.GetInitialLoadDetails(0, 1, Trn_Id, SessLogObj.UserId, "").FirstOrDefault();
            return View(dbResult);
        }

    }
}