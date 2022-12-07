
using ModelPortal.Db_Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Vzah.Models
{
    public class SendEmail
    {
        SqlConnection conn = new SqlConnection(DBConnection.GetConnectionString);

        SqlCommand cmd = new SqlCommand();
        MailMessage smtpobject = new MailMessage();
        SmtpClient smtp = new SmtpClient();
        public string SendEmailTemplate(EmailSendingMaster model, string html, string Host, string from, int Port, string DeliveryMethod, bool EnableSsl)
        {
            try
            {
                MailMessage mail = EmailSendingMtd(model.CC, model.BCC, model.TO, html, model.SUBJECT, from);
                SmtpClient kcplsmtpclient = EmailCredentials(Host, Port, EnableSsl);
                kcplsmtpclient.Send(mail);
                return "success";
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDBWEB(ex, "Hello Admin email sending has failed for -" + model.SUBJECT + " To email ids are-" + model.TO + " CC email ids are-" + model.CC + ", Subject was-" + model.SUBJECT);
                throw ex;
            }
            finally
            {
                smtpobject.Dispose();
                smtp.Dispose();
            }
        }
        public string SendEmailWithattachment(MemoryStream mm, EmailSendingMaster model, string html, string Host, string from, int Port, string DeliveryMethod, bool EnableSsl)
        {
            try
            {
                MailMessage mail = EmailSendingMtdWithAttachment(mm, model.CC, model.BCC, model.TO, html, model.SUBJECT, from);
                SmtpClient kcplsmtpclient = EmailCredentials(Host, Port, EnableSsl);
                kcplsmtpclient.Send(mail);
                return "success";
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDBWEB(ex, "Hello Admin email sending has failed for -" + model.SUBJECT + " To email ids are-" + model.TO + " CC email ids are-" + model.CC + ", Subject was-" + model.SUBJECT);
                throw ex;
            }
            finally
            {
                smtpobject.Dispose();
                smtp.Dispose();
            }
        }

        private static MailMessage EmailSendingMtdWithAttachment(MemoryStream mm, string CC, string BCC, string To, string html, string Subject, string from)
        {
            MailMessage mail = new MailMessage();
            MailAddress fromAddress = new MailAddress(from, "XYZ");
            mail.To.Add(To);
            mail.CC.Add(CC); //mail.Bcc.Add(BCC);
            mail.Attachments.Add(new Attachment(mm, "Inspection.pdf"));
            mail.Subject = Subject;
            mail.IsBodyHtml = true;
            mail.Body = html;
            mail.From = fromAddress;
            return mail;
        }
        private static MailMessage EmailSendingMtd(string CC, string BCC, string To, string html, string Subject, string from)
        {
            MailMessage mail = new MailMessage();
            MailAddress fromAddress = new MailAddress(from, "Vzah");
            mail.To.Add(To);
            mail.CC.Add(CC); //mail.Bcc.Add(BCC);
            mail.Subject = Subject;
            mail.IsBodyHtml = true;
            mail.Body = html;
            mail.From = fromAddress;
            return mail;
        }
        public void EmailSending(string filter, out EmailCredentials cred, out EmailSendingMaster sendingdetails)
        {
            conn.Open();
            cred = new EmailCredentials();
            sendingdetails = new EmailSendingMaster();
            DataTable dtable = new DataTable();
            SqlCommand cmmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SP_PullEmailCredentials";
            cmd.Parameters.AddWithValue("@filter", filter);
            cmd.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                while (sdr.Read())
                {
                    cred.HOST = sdr["HOST"].ToString();
                    cred.FROM = sdr["FROM"].ToString();
                    cred.HOST = sdr["HOST"].ToString();
                    cred.Port = sdr["Port"].ToString();
                    cred.EnableSsl = Convert.ToBoolean(sdr["EnableSsl"].ToString());
                }
                sdr.NextResult();
                while (sdr.Read())
                {
                    {
                        sendingdetails.CC = sdr["CC"].ToString();
                        sendingdetails.TO = sdr["TO"].ToString();
                        sendingdetails.BCC = sdr["BCC"].ToString();
                        sendingdetails.DESCRIPTION = sdr["DESCRIPTION"].ToString();
                        sendingdetails.SUBJECT = sdr["SUBJECT"].ToString();
                        //Updated on 17-08-2020
                        sendingdetails.EMAIL_TO = sdr["EMAIL_TO"].ToString();
                        sendingdetails.REGARDS = sdr["REGARDS"].ToString();
                        sendingdetails.EMAIL_FROM = sdr["EMAIL_FROM"].ToString();
                        sendingdetails.FOOTER = sdr["FOOTER"].ToString();
                    }
                }
            }
        }
        private static SmtpClient EmailCredentials(string Host, int Port, bool EnableSsl)
        {
            string userName = System.Configuration.ConfigurationManager.AppSettings["EmailIDVzah"];
            string password = System.Configuration.ConfigurationManager.AppSettings["PasswordVzah"];
            SmtpClient kcplsmtpclient = new SmtpClient(Host);
            kcplsmtpclient.Credentials = new NetworkCredential(userName, password);
            //kcplsmtpclient.Host = Host;
            kcplsmtpclient.Port = Port;
            kcplsmtpclient.EnableSsl = EnableSsl;
            kcplsmtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
            return kcplsmtpclient;
        }
    }
}