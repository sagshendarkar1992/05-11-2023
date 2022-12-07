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
    public class InitialLoad
    {
        public bool Empty
        {
            get
            {
                return (Trn_Id == 0 &&
                        string.IsNullOrWhiteSpace(TravellingFromName) &&
                        string.IsNullOrWhiteSpace(TravellingToName) &&
                        string.IsNullOrWhiteSpace(PassportHoldingCountryName));
            }
        }
        public string UserEmail { get; set; }
        public int PAGENO { get; set; }
        public int FLAG { get; set; }
        public int PAGESIZE { get; set; }
        public int TOTALROWS { get; set; }
        public int TOTALPAGES { get; set; }
        public int PAGECOUNT { get; set; }
        public int Trn_Id { get; set; }
        public int UserId { get; set; }
        public string VZNumber { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public bool Is_Active { get; set; }
        public int TravellingFrom { get; set; }
        public string TravellingFromName { get; set; }
        public int TravellingTo { get; set; }
        public string TravellingToName { get; set; }
        public int PassportHoldingCountry { get; set; }
        public string PassportHoldingCountryName { get; set; }
        public int PurposeOfTravelId { get; set; }
        public string PurposeOfTravel { get; set; }
        public int NumberOfDays { get; set; }
        public string DateOfTravel { get; set; }
        public int EntryId { get; set; }
        public string EntryName { get; set; }
    }
    public class DocumentDetails
    {
        public int Doc_MasterCount { get; set; }
        public int Doc_TransactionCount { get; set; }
        public int Doc_PendingCount { get; set; }
        public int Doc_CompletedCount { get; set; }
        public int Doc_RejectedCount { get; set; }
        public string FileExtension { get; set; }
        public string Doc_Status { get; set; }
        public string UserName { get; set; }
        public string Approved_Status { get; set; }
        public string ApprovedDate { get; set; }
        public string Approved_By { get; set; }
        public string Rejectionremark { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public bool Is_Active { get; set; }
        public string Path { get; set; }
        public int Trn_IdDoc { get; set; }
        public int Doc_Id { get; set; }
        public string Document_Name { get; set; }
        public string Document_Alt { get; set; }
        public string Max_Size { get; set; }
        public string Min_Size { get; set; }
        public int Sequence { get; set; }
    }
    public class TravelDetails
    {
        public string VZNumber { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string Occupation { get; set; }
        public string Purpose_of_Travel { get; set; }
        public string EntryName { get; set; }
        public string VisaValidity { get; set; }
        public string VisaType { get; set; }
        public int Trn_IdTravel { get; set; }
        public int Travel_Id { get; set; }
        public int PAGENO { get; set; }
        public int FLAG { get; set; }
        public int PAGESIZE { get; set; }
        public int TOTALROWS { get; set; }
        public int TOTALPAGES { get; set; }
        public int PAGECOUNT { get; set; }
        public int Trn_Id { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public decimal Age { get; set; }
        public int OccupationId { get; set; }
        public int PurposeOfTravelId { get; set; }
        public int EntryId { get; set; }
        public int VisaValidityId { get; set; }
        public string ProcessingTime { get; set; }
        public decimal VisaFees { get; set; }
        public int VisaTypeId { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public bool Is_Active { get; set; }
    }
    public class Transaction
    {
        public int Doc_MasterCount { get; set; }
        public int Doc_TransactionCount { get; set; }
        public int Doc_PendingCount { get; set; }
        public int Doc_CompletedCount { get; set; }
        public int Doc_RejectedCount { get; set; }
        public bool IsApplicantDetails { get; set; }
        public bool IsTravelDetails { get; set; }
        public bool IsUploadDocuments { get; set; }
        public bool IsUploadVerified { get; set; }
        public bool IsUploadConfirmed { get; set; }
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
        public BIErrors SaveImageDetails(
         XElement Imgxml,
         string Flag,
         int UserId)
        {
            return new BIErrors(this.objbui.StatusCheck(new XDocument(new XDeclaration("1.0", "utf-8", ""), new object[1]
            {
        (object) new XElement((XName) "Vzah", new object[5]
        {
          (object) new XElement((XName) "XsdName", (object) ""),
          (object) new XElement((XName) "ProcName", (object) "IMAGE_c"),
          (object) new XElement((XName) "pImgXML", (object) Imgxml.ToString()),
          (object) new XElement((XName) "pFlag", (object) Flag),
          (object) new XElement((XName) "pUSERID", (object) UserId)
        })
            })), Flag);
        }
        public List<DocumentDetails> GetUploadMastDetails(int Page, int flag, int Trn_Id, int UserId, string SEARCH)
        {
            XDocument xdoc = new XDocument(
           new XDeclaration("1.0", "utf-8", ""),
           new XElement("Vzah",
           new XElement("XsdName", ""),
           new XElement("ProcName", "DocumentMaster_g"),
           new XElement("pFLAG", flag),
           new XElement("pTrn_Id", Trn_Id),
           new XElement("pSEARCH", SEARCH), new XElement("pPAGENO", Page),
           new XElement("pUSERID", UserId)));
            DocumentDetails obj = new DocumentDetails();
            DataTable dt = objbui.GetCloud9BusinessList(xdoc);
            var dbResult = (from s in dt.AsEnumerable()
                            select new DocumentDetails
                            {
                                Path = s.Field<string>("Path"),
                                Doc_Status = s.Field<string>("Doc_Status"),
                                Trn_IdDoc = Trn_Id,
                                Doc_Id = s.Field<int>("Doc_Id"),
                                Document_Name = s.Field<string>("Document_Name"),
                                Document_Alt = s.Field<string>("Document_Alt"),
                                Sequence = s.Field<int>("Sequence"),
                                Max_Size = s.Field<string>("Max_Size"),
                                Min_Size = s.Field<string>("Min_Size"),
                            }).ToList();
            return dbResult;
        }
        public List<DocumentDetails> GetUploadedDetails(int Page, int flag, int Trn_Id, int UserId, string SEARCH)
        {
            XDocument xdoc = new XDocument(
           new XDeclaration("1.0", "utf-8", ""),
           new XElement("Vzah",
           new XElement("XsdName", ""),
           new XElement("ProcName", "UploadedDocuments_g"),
           new XElement("pFLAG", flag),
           new XElement("pTrn_Id", Trn_Id),
           new XElement("pSEARCH", SEARCH), new XElement("pPAGENO", Page),
           new XElement("pUSERID", UserId)));
            DocumentDetails obj = new DocumentDetails();
            DataTable dt = objbui.GetCloud9BusinessList(xdoc);
            var dbResult = (from s in dt.AsEnumerable()
                            select new DocumentDetails
                            {
                                Doc_MasterCount = s.Field<int>("Doc_MasterCount"),
                                Doc_TransactionCount = s.Field<int>("Doc_TransactionCount"),
                                Doc_PendingCount = s.Field<int>("Doc_PendingCount"),
                                Doc_CompletedCount = s.Field<int>("Doc_CompletedCount"),
                                Doc_RejectedCount = s.Field<int>("Doc_RejectedCount"),
                                FileExtension = s.Field<string>("FileExtension"),
                                UserName = s.Field<string>("UserName"),
                                Path = s.Field<string>("Path"),
                                Approved_Status = s.Field<string>("Approved_Status"),
                                Approved_By = s.Field<string>("Approved_By"),
                                Rejectionremark = s.Field<string>("Rejectionremark"),
                                CreatedDate = s.Field<string>("CreatedDate"),
                                UpdatedDate = s.Field<string>("UpdatedDate"),

                                ApprovedDate = s.Field<string>("ApprovedDate"),
                                Trn_IdDoc = Trn_Id,
                                Doc_Id = s.Field<int>("Doc_Id"),
                                Document_Name = s.Field<string>("Document_Name"),
                                Document_Alt = s.Field<string>("Document_Alt"),
                                Sequence = s.Field<int>("Sequence"),
                                Max_Size = s.Field<string>("Max_Size"),
                                Min_Size = s.Field<string>("Min_Size"),
                            }).ToList();
            return dbResult;
        }
        public List<InitialLoad> GetInitialLoadDetails(int Page, int flag, int Trn_Id, int UserId, string SEARCH)
        {
            XDocument xdoc = new XDocument(
           new XDeclaration("1.0", "utf-8", ""),
           new XElement("Vzah",
           new XElement("XsdName", ""),
           new XElement("ProcName", "InitialLoad_g"),
           new XElement("pFLAG", flag),
           new XElement("pTrn_Id", Trn_Id),
           new XElement("pSEARCH", SEARCH), new XElement("pPAGENO", Page),
           new XElement("pUSERID", UserId)));
            InitialLoad obj = new InitialLoad();
            DataTable dt = objbui.GetCloud9BusinessList(xdoc);
            var dbResult = (from s in dt.AsEnumerable()
                            select new InitialLoad
                            {
                                UserEmail = s.Field<string>("UserEmail"),
                                Trn_Id = s.Field<int>("Trn_Id"),
                                VZNumber = s.Field<string>("VZNumber"),
                                TravellingFrom = s.Field<int>("TravellingFrom"),
                                TravellingFromName = s.Field<string>("TravellingFromName"),
                                TravellingTo = s.Field<int>("TravellingTo"),
                                TravellingToName = s.Field<string>("TravellingToName"),

                                PassportHoldingCountry = s.Field<int>("PassportHoldingCountry"),
                                PassportHoldingCountryName = s.Field<string>("PassportHoldingCountryName"),
                                PurposeOfTravelId = s.Field<int>("PurposeOfTravelId"),
                                PurposeOfTravel = s.Field<string>("Purpose_Of_Travel"),
                                NumberOfDays = s.Field<int>("NumberOfDays"),
                                DateOfTravel = s.Field<string>("DateOfTravel"),
                                EntryId = s.Field<int>("EntryId"),
                                EntryName = s.Field<string>("EntryName"),
                                CreatedDate = s.Field<string>("CreatedDate"),
                                UpdatedDate = s.Field<string>("UpdatedDate"),
                                PAGECOUNT = s.Field<int>("PAGECOUNT"),
                                PAGESIZE = s.Field<int>("PAGESIZE"),
                                TOTALPAGES = s.Field<int>("TOTALPAGES"),
                                TOTALROWS = s.Field<int>("TOTALROWS")
                            }).ToList();
            return dbResult;
        }

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
                                Doc_MasterCount = s.Field<int>("Doc_MasterCount"),
                                Doc_TransactionCount = s.Field<int>("Doc_TransactionCount"),
                                Doc_PendingCount = s.Field<int>("Doc_PendingCount"),
                                Doc_CompletedCount = s.Field<int>("Doc_CompletedCount"),
                                Doc_RejectedCount = s.Field<int>("Doc_RejectedCount"),
                                IsApplicantDetails = s.Field<bool>("IsApplicantDetails"),
                                IsTravelDetails = s.Field<bool>("IsTravelDetails"),
                                IsUploadDocuments = s.Field<bool>("IsUploadDocuments"),
                                IsUploadVerified = s.Field<bool>("IsUploadVerified"),
                                IsUploadConfirmed = s.Field<bool>("IsUploadConfirmed"),
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
        public List<TravelDetails> GetApplicantTravelDetails(int Page, int flag, int Trn_Id, int UserId, string SEARCH)
        {
            XDocument xdoc = new XDocument(
           new XDeclaration("1.0", "utf-8", ""),
           new XElement("Vzah",
           new XElement("XsdName", ""),
           new XElement("ProcName", "ApplicantTravelDetails_g"),
           new XElement("pFLAG", flag),
           new XElement("pTrn_Id", Trn_Id),
           new XElement("pSEARCH", SEARCH), new XElement("pPAGENO", Page),
           new XElement("pUSERID", UserId)));
            TravelDetails obj = new TravelDetails();
            DataTable dt = objbui.GetCloud9BusinessList(xdoc);
            var dbResult = (from s in dt.AsEnumerable()
                            select new TravelDetails
                            {
                                Travel_Id = s.Field<int>("Travel_Id"),
                                Trn_Id = s.Field<int>("Trn_Id"),
                                VZNumber = s.Field<string>("VZNumber"),
                                CountryId = s.Field<int>("CountryId"),
                                CountryName = s.Field<string>("CountryName"),
                                StateId = s.Field<int>("StateId"),
                                StateName = s.Field<string>("StateName"),
                                CityId = s.Field<int>("CityId"),
                                CityName = s.Field<string>("CityName"),
                                Age = s.Field<decimal>("Age"),
                                OccupationId = s.Field<int>("OccupationId"),
                                Occupation = s.Field<string>("Occupation"),
                                PurposeOfTravelId = s.Field<int>("PurposeOfTravelId"),
                                Purpose_of_Travel = s.Field<string>("Purpose_of_Travel"),
                                EntryId = s.Field<int>("EntryId"),
                                EntryName = s.Field<string>("EntryName"),
                                VisaValidityId = s.Field<int>("VisaValidityId"),
                                VisaValidity = s.Field<string>("VisaValidity"),
                                ProcessingTime = s.Field<string>("ProcessingTime"),
                                VisaFees = s.Field<decimal>("VisaFees"),
                                VisaTypeId = s.Field<int>("VisaTypeId"),
                                VisaType = s.Field<string>("VisaType"),
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
                                ApplicantName = s.Field<string>("ApplicantName"),
                                ApplicantAge = s.Field<decimal>("ApplicantAge"),
                                ApplicantMobileNumber = s.Field<string>("ApplicantMobileNumber"),
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
        public BIErrors SaveInitialLoad(string Flag, InitialLoad model, int UserId)
        {
            XDocument xdoc = new XDocument(
            new XDeclaration("1.0", "utf-8", ""),
            new XElement("Vzah",
            new XElement("XsdName", ""),
            new XElement("ProcName", "IntitialLoad_c"),
            new XElement("pTrn_Id", model.Trn_Id),
            new XElement("pTravellingFrom", model.TravellingFrom),
            new XElement("pTravellingTo", model.TravellingTo),
            new XElement("pPassportHoldingCountry", model.PassportHoldingCountry),
            new XElement("pPurposeOfTravelId", model.PurposeOfTravelId),
            new XElement("pNumberOfDays", model.NumberOfDays),
            new XElement("pDateOfTravel", model.DateOfTravel),
            new XElement("pEntryId", model.EntryId),
            new XElement("pFLAG", Flag),
            new XElement("pUSERID", UserId)));
            int statuscheck = objbui.StatusCheck(xdoc);
            BIErrors err = new BIErrors(statuscheck, Flag);
            return err;
        }
        public BIErrors SavePaymentDetails(int Trn_Id, string Flag, int UserId)
        {
            XDocument xdoc = new XDocument(
            new XDeclaration("1.0", "utf-8", ""),
            new XElement("Vzah",
            new XElement("XsdName", ""),
            new XElement("ProcName", "Payment_c"),
            new XElement("pTrn_Id", Trn_Id),
            new XElement("pFLAG", Flag),
            new XElement("pUSERID", UserId)));
            int statuscheck = objbui.StatusCheck(xdoc);
            BIErrors err = new BIErrors(statuscheck, Flag);
            return err;
        }
        public BIErrors SaveApplicantDetails(string Flag, Transaction model, int UserId)
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
        public BIErrors SaveTravelDetails(string Flag, TravelDetails model, int UserId)
        {
            XDocument xdoc = new XDocument(
            new XDeclaration("1.0", "utf-8", ""),
            new XElement("Vzah",
            new XElement("XsdName", ""),
            new XElement("ProcName", "ApplicantTravelDetails_c"),
            new XElement("pTravel_Id", model.Travel_Id),
            new XElement("pTrn_Id", model.Trn_IdTravel),
            new XElement("pCountryId", model.CountryName),
            new XElement("pStateId", model.StateName),
            new XElement("pCityId", model.CityName),
            new XElement("pAge", model.Age),
            new XElement("pOccupationId", model.Occupation),
            new XElement("pPurposeOfTravelId", model.Purpose_of_Travel),
            new XElement("pEntryId", model.EntryName),
            new XElement("pVisaValidityId", model.VisaValidity),
            new XElement("pProcessingTime", model.ProcessingTime),
            new XElement("pVisaFees", model.VisaFees),
            new XElement("pVisaTypeId", model.VisaType),
            new XElement("pFLAG", Flag),
            new XElement("pUSERID", UserId)));
            int statuscheck = objbui.StatusCheck(xdoc);
            BIErrors err = new BIErrors(statuscheck, Flag);
            return err;
        }
    }
}
