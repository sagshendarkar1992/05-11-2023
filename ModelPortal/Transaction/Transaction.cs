using DataAccessBusinessPortal;
using ModelPortal.BI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ModelPortal.Transaction
{
    public class Transaction
    {
        public string Str_Action { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public bool Is_Active { get; set; }
        public int PAGENO { get; set; }
        public int FLAG { get; set; }
        public int PAGESIZE { get; set; }
        public int TOTALROWS { get; set; }
        public int TOTALPAGES { get; set; }
        public int PAGECOUNT { get; set; }
        public int Trn_Id { get; set; }
        public string ApplicantName { get; set; }
        public decimal? ApplicantAge { get; set; }
        public string ApplicantMobileNumber { get; set; }
        public string SubApplicantName { get; set; }
        public decimal? SubApplicantAge { get; set; }
        public string SubApplicantMobileNumber { get; set; }
        public string Relation { get; set; }
        public int SubApplicantCount { get; set; }
        VzahBusiness objbui = new VzahBusiness();
        public List<Transaction> GetApplicantDetails(int Page, int flag, int Trn_Id, int UserId, string SEARCH)
        {
            XDocument xdoc = new XDocument(
           new XDeclaration("1.0", "utf-8", ""),
           new XElement("Vzah",
           new XElement("XsdName", ""),
           new XElement("ProcName", "ApplicantDetails_g"),
           new XElement("pFLAG", flag),
           new XElement("pTrn_Id", Trn_Id),
           new XElement("pSEARCH", SEARCH), new XElement("pPAGENO", Page),
           new XElement("pUSERID", UserId)));
            Transaction obj = new Transaction();
            DataTable dt = objbui.GetCloud9BusinessList(xdoc);
            var dbResult = (from s in dt.AsEnumerable()
                            select new Transaction
                            {
                                SubApplicantCount = s.Field<int>("SubApplicantCount"),
                                Trn_Id = s.Field<int>("Trn_Id"),
                                ApplicantName = s.Field<string>("ApplicantName"),
                                ApplicantAge = s.Field<decimal>("ApplicantAge"),
                                ApplicantMobileNumber = s.Field<string>("ApplicantMobileNumber"),
                                CreatedDate = s.Field<string>("CreatedDate"),
                                UpdatedDate = s.Field<string>("UpdatedDate"),
                                PAGECOUNT = s.Field<int>("PAGECOUNT"),
                                PAGESIZE = s.Field<int>("PAGESIZE"),
                                TOTALPAGES = s.Field<int>("TOTALPAGES"),
                                TOTALROWS = s.Field<int>("TOTALROWS")
                            }).ToList();
            return dbResult;
        }

        public List<Transaction> GetSubApplicantDetails(int Page, int flag, int Trn_Id, int UserId, string SEARCH)
        {
            XDocument xdoc = new XDocument(
           new XDeclaration("1.0", "utf-8", ""),
           new XElement("Vzah",
           new XElement("XsdName", ""),
           new XElement("ProcName", "SubApplicantDetails_g"),
           new XElement("pFLAG", flag),
           new XElement("pTrn_Id", Trn_Id),
           new XElement("pSEARCH", SEARCH), new XElement("pPAGENO", Page),
           new XElement("pUSERID", UserId)));
            Transaction obj = new Transaction();
            DataTable dt = objbui.GetCloud9BusinessList(xdoc);
            var dbResult = (from s in dt.AsEnumerable()
                            select new Transaction
                            {
                                Relation = s.Field<string>("Relation"),
                                Str_Action = s.Field<string>("Str_Action"),
                                Trn_Id = s.Field<int>("Trn_Id"),
                                SubApplicantName = s.Field<string>("SubApplicantName"),
                                SubApplicantAge = s.Field<decimal>("SubApplicantAge"),
                                SubApplicantMobileNumber = s.Field<string>("SubApplicantMobileNumber"),
                                CreatedDate = s.Field<string>("CreatedDate"),
                                UpdatedDate = s.Field<string>("UpdatedDate"),
                                PAGECOUNT = s.Field<int>("PAGECOUNT"),
                                PAGESIZE = s.Field<int>("PAGESIZE"),
                                TOTALPAGES = s.Field<int>("TOTALPAGES"),
                                TOTALROWS = s.Field<int>("TOTALROWS")
                            }).ToList();
            return dbResult;
        }
        public BIErrors SAVE(string Flag, Transaction model, int UserId)
        {
            XDocument xdoc = new XDocument(
            new XDeclaration("1.0", "utf-8", ""),
            new XElement("Vzah",
            new XElement("XsdName", ""),
            new XElement("ProcName", "Applicant_c"),
            new XElement("pTrn_Id", model.Trn_Id),
            new XElement("pApplicantName", model.ApplicantName),
            new XElement("pApplicantAge", model.ApplicantAge),
            new XElement("pApplicantMobileNumber", model.ApplicantMobileNumber),
            new XElement("pSubApplicantName", model.SubApplicantName),
            new XElement("pSubApplicantAge", model.SubApplicantAge),
            new XElement("pSubApplicantMobileNumber", model.SubApplicantMobileNumber),
            new XElement("pRelation", model.Relation),
            new XElement("pFLAG", Flag),
            new XElement("pUSERID", UserId)));
            int statuscheck = objbui.StatusCheck(xdoc);
            BIErrors err = new BIErrors(statuscheck, Flag);
            return err;
        }
    }
}
