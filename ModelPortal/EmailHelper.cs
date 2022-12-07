using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace ModelPortal
{
    public class EmailHelper
    {
        #region Send OTP Mail

        public string OTPAgentMailSend(string ToEmailId, string FormalSubject, string BodyContent)
        { 
            //MailAddress fromAddress = new MailAddress("Notification@kirloskar.com", "Registration Email");
            //mail.To.Add("Sagar.Shendarkar@kloudq.com");
            //mail.Subject = "TEST EMAIL CHECK-K_PAD";
            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //mail.IsBodyHtml = true;
            //sb.Append("<font face=Tahoma size=2>");
            //sb.Append("Hello,THIS IS TEST EMAIL");
            //sb.Append("<a href=http://k-pad.kcpl.net.in:8086/" + ">Click Here</a>" + " to login K-PAD intranet portal.");
            //sb.Append("<br><hr>Thanks<br>");
            //sb.Append("</font>");
            //mail.IsBodyHtml = true;
            //mail.Body = Content.ToString();
            //mail.BodyEncoding = System.Text.Encoding.Unicode;
            //mail.SubjectEncoding = System.Text.Encoding.Unicode;
            //mail.From = fromAddress;
            //SmtpClient a = new SmtpClient("relay-hosting.secureserver.net");
            //a.Credentials = new NetworkCredential("shendarkarsagar1992@gmail.com", "OpCmBt1C@66");
            //a.Port = 25;
            //a.EnableSsl = false;
            //a.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            //a.Send(mail);

            MailMessage msgVzah = new MailMessage();
            SmtpClient smtpClient = new System.Net.Mail.SmtpClient(System.Configuration.ConfigurationManager.AppSettings["EmailHost"].ToString());
            string UserID = string.Empty;
            string Password = string.Empty;
            try
            {
                string To = ToEmailId;
                string From = System.Configuration.ConfigurationManager.AppSettings["FromEmailIDVzah"].ToString();
                msgVzah.From = new System.Net.Mail.MailAddress(From, "Vzah");
                UserID = System.Configuration.ConfigurationManager.AppSettings["EmailIDVzah"].ToString();
                Password = System.Configuration.ConfigurationManager.AppSettings["PasswordVzah"].ToString();
                msgVzah.To.Add(To);
                msgVzah.Subject = FormalSubject;
                msgVzah.Body = BodyContent;
                msgVzah.IsBodyHtml = true; 
                smtpClient.Port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Port"].ToString());
               smtpClient.EnableSsl = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(UserID, Password);
                smtpClient.Send(msgVzah); 
                msgVzah.Dispose();
                smtpClient.Dispose();

                return "success";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                msgVzah.Dispose();
                smtpClient.Dispose();
            }
        }
        #endregion Send OTP Mail
    }
}
