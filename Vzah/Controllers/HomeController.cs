using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Vzah.Models;

namespace Vzah.Controllers
{
    [SkipMyGlobalActionFilterAttribute]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = "Vzah-Home";
            return View();
        }
        public ActionResult AboutUs()
        {
            ViewBag.Title = "Vzah-About Us";
            return View();
        }
        public ActionResult FAQ()
        {
            ViewBag.Title = "Vzah-FAQ's";
            return View();
        }
        public ActionResult Blogs()
        {
            ViewBag.Title = "Vzah-Blogs";
            return View();
        }
        public ActionResult News()
        {
            ViewBag.Title = "Vzah-News";
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Title = "Vzah-Contact Us";
            return View();
        }
        public ActionResult Register()
        {
            ViewBag.Title = "Vzah-Login/Register";
            return View();
        }
        public ActionResult SendTestEmail()
        {
            StreamReader DocumentUpload = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/Registration.html"));
            string Content = "";
            Content = DocumentUpload.ReadToEnd();
            MailMessage mail = new MailMessage();
            MailAddress fromAddress = new MailAddress("Notification@kirloskar.com", "Registration Email");
            mail.To.Add("Sagar.Shendarkar@kloudq.com");
            mail.Subject = "TEST EMAIL CHECK-K_PAD";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            mail.IsBodyHtml = true;
            sb.Append("<font face=Tahoma size=2>");
            sb.Append("Hello,THIS IS TEST EMAIL");
            sb.Append("<a href=http://k-pad.kcpl.net.in:8086/" + ">Click Here</a>" + " to login K-PAD intranet portal.");
            sb.Append("<br><hr>Thanks<br>");
            sb.Append("</font>");
            mail.IsBodyHtml = true;
            mail.Body = Content.ToString();
            mail.BodyEncoding = System.Text.Encoding.Unicode;
            mail.SubjectEncoding = System.Text.Encoding.Unicode;
            mail.From = fromAddress;
            SmtpClient a = new SmtpClient("relay-hosting.secureserver.net");
            a.Credentials = new NetworkCredential("shendarkarsagar1992@gmail.com", "OpCmBt1C@66");
            a.Port = 25;
            a.EnableSsl = false;
            a.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            a.Send(mail);
            return View();
        }
    }
}
