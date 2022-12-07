using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vzah.Models
{
    public class EmailSendingMaster
    {
        public string Str_Edit { get; set; }
        public int Email_Id { get; set; }
        public string Email_For { get; set; }
        public string TO { get; set; }
        public string CC { get; set; }
        public string BCC { get; set; }
        public string SUBJECT { get; set; }
        public string DESCRIPTION { get; set; }
        public string EMAIL_TO { get; set; }
        public string EMAIL_FROM { get; set; }
        public string REGARDS { get; set; }
        public string FOOTER { get; set; }
        public string Field_05 { get; set; }
        public bool Is_Active { get; set; }
    }
    public class EmailCredentials
    {
        public string Str_Edit { get; set; }
        public int Cred_Id { get; set; }
        public string FROM { get; set; }
        public string HOST { get; set; }
        public string Port { get; set; }
        public bool EnableSsl { get; set; }
        public string DeliveryMethod { get; set; }
        public bool Is_Active { get; set; }
    }
}