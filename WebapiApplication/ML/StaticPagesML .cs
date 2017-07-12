using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebapiApplication.ML
{

    public class SuccessStoryML
    {
        public Int64? successid { get; set; }
        public string vc_ProfileID { get; set; }
        public int? i_RegionID { get; set; }
        public int? casteid { get; set; }
        public int? branchid { get; set; }
        public int? pagefrom { get; set; }
        public int? pageto { get; set; }

    }

    public class Sucessstories
    {
        public string GroomName { set; get; }
        public string BrideName { set; get; }
        public string GroomProfileID { set; get; }
        public string BrideProfileID { set; get; }
        public string MarriageDate { set; get; }
        public string PhotoPath { set; get; }
    }

    public class PhotoPathDisplay
    {
        public string ThumbNailPath { set; get; }
        public string FullPhotoPath { set; get; }
        public string ApplicationPhotoPath { set; get; }
    }

    public class ProfileSettings
    {
        public string Email { set; get; }
        public Int64? EmailCust_Family_ID { set; get; }
        public string Mobilenumber { set; get; }
        public Int64? MobileCustFamily_ID { set; get; }
        public Int64? ProfileStatusID { set; get; }
        public DateTime? InActiveFromDate { set; get; }
        public DateTime? InActiveToDate { set; get; }
        public bool? AllowEmail { set; get; }
        public bool? AllowSMS { set; get; }
        public string Password { set; get; }
    }

    public class Supporttickets
    {
        public int? Sno { get; set; }
        public string TicketID { get; set; }
        public Int64? TicketNO { get; set; }
        public string OpenedDate { get; set; }
        public string TicketStatus { get; set; }
        public string StatusDate { get; set; }
        public string Category { get; set; }
        public string Subject { get; set; }
        public string Reportedby { get; set; }
        public string Email { get; set; }
        public string AssignedToEmp { get; set; }
        public string PendingWith { get; set; }
        public int? pageid { get; set; }
    }

    public class Myorders
    {
        public string RegistrationDate { get; set; }
        public string LastModifiedDate { get; set; }
        public string LoginCount { get; set; }
        public string LastLoginDate { get; set; }
        public string ProfileVistitedCount { get; set; }
        public string PaymentStatus { get; set; }
        public string ExpiryDate { get; set; }
        public string OnlineMembership { get; set; }
        public string MaxPoints { get; set; }
        public string Balancepoints { get; set; }
        public string offPaymentStatus { get; set; }
        public string offExpiryDate { get; set; }
        public string OfflineMembership { get; set; }
        public string offMaxPoints { get; set; }
        public string offBalancepoints { get; set; }
        public string paidondate { get; set; }
        public string paidoffdate { get; set; }
        public string FutureDate { get; set; }
        public string FutureExpiry { get; set; }
        public string ProfileDay { get; set; }
        public string Max_Booster_Allowed { get; set; }
        public string Booster_Used_Count { get; set; }
        public string Total_Count { get; set; }
        public string Max_AstroMatchMatch_Allowed { get; set; }
        public string AstroMatch_Used_Count { get; set; }
        public string AstroMatch_Balance { get; set; }
        public string Add_on { get; set; }
    }


    public class UpgradeMembership
    {
        public string MembershipName { get; set; }
        public int? Emp_Membership_ID { get; set; }
        public int? MemberShipDuration { get; set; }
        public Int64? Cust_MemberShip_Discount_ID { get; set; }
        public float? DiscountAmount { get; set; }
        public int? AllottedServicePoints { get; set; }
        public float? MembershipAmount { get; set; }
        public string onlineaccess { get; set; }
        public string offlineaccess { get; set; }
        public string Ppluspath { get; set; }
        public string Ppath { get; set; }

    }

    public class CustFeebBackML
    {
        private string cust_id;

        public string Cust_id { get { return cust_id; } set { cust_id = value; } }
        private string herabout;

        public string Herabout { get { return herabout; } set { herabout = value; } }
        private string improvewebsite;

        public string Improvewebsite
        {
            get { return improvewebsite; }
            set { improvewebsite = value; }
        }
        private string kaaprices;
        public string Kaaprices
        {
            get { return kaaprices; }
            set { kaaprices = value; }
        }
        private string downloadTime;

        public string DownloadTime
        {
            get { return downloadTime; }
            set { downloadTime = value; }
        }
        public string CompareSite;

        public string CompareSite1
        {
            get { return CompareSite; }
            set { CompareSite = value; }
        }
        public string FavSite;

        public string FavSite1
        {
            get { return FavSite; }
            set { FavSite = value; }
        }
        private string Searchrate;

        public string Searchrate1
        {
            get { return Searchrate; }
            set { Searchrate = value; }
        }
        private string Recommned;
        public string Recommned1
        {
            get { return Recommned; }
            set { Recommned = value; }
        }
        private string Commments;

        public string Commments1 { get { return Commments; } set { Commments = value; } }

        public string Cust_ID { get; set; }

        public string HearAbout { get; set; }

        public string ImproveWebsite { get; set; }

        public string kaaPrices { get; set; }

        public string DownLoadTime { get; set; }

        public string Comments { get; set; }

        public string Recommend { get; set; }

        public string SearchRate { get; set; }

    }
    public class Smtpemailsending
    {
        public string profile_name { get; set; }
        public string recipients { get; set; }
        public string body { get; set; }
        public string subject { get; set; }
        public string body_format { get; set; }
        public int? Status { get; set; }
        public int Statusint { get; set; }
        public int CustID { get; set; }
        public string ProfileID { set; get; }
    }

    public class KaakateeyaBranchesML
    {
        public string BranchAddress { set; get; }
        public string PhoneNumbers { set; get; }
        public string Mobilenumber { set; get; }
        public string BranchemailID { set; get; }
        public string WorkingEndTime { set; get; }
        public int? Branch_ID { set; get; }
        public string Address { set; get; }
        public string WorkingStartTime { set; get; }
        public string Landlineareacode { set; get; }
        public string Landlinenumber { set; get; }
        public string BranchesName { set; get; }
    }

    public class TicketCreationMl
    {
        public Int64? profile { get; set; }
        public Int64? AssignedEmpID { get; set; }
        public Int64? BranchID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string subject { get; set; }
        public int? Category { get; set; }
        public string Message { get; set; }
        public int? Priority { get; set; }
        public string Image { get; set; }
        public int? CountryCode { get; set; }
        public string AreaCode { get; set; }
        public string PhoneNum { get; set; }
        public Int64? EmpID { get; set; }

    }



    public class TicketDetails
    {
        public int? PageID { get; set; }
        public Int64? CustID { get; set; }
        public int? TicketID { get; set; }
        public string ProfileID { get; set; }
        public string Complaint { get; set; }
        public int? FeedBackStatus { get; set; }
    }
    public class HelpMail
    {
        public long? iTicketID { get; set; }
        public string Ticket { get; set; }
        public Int64? Cust_ID { get; set; }
        public string TicketID { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string strEmail { get; set; }
        public Int64? EmpID { get; set; }
        public Int64? EmpTicketID { get; set; }

        public int Status { get; set; }

    }


    public class ExpressinterestbookmarkGetting
    {

        public int? BookmarkFlag { get; set; }
        public int? IgnoreFlag { get; set; }
        public int? Viewedflag { get; set; }

        public int? ExpressFlag { get; set; }
        public int? Acceptflag { get; set; }
        public int? TimeFlag { get; set; }
        public int? MatchFollowUpStatus { get; set; }
        public Int64? ExpressInterstId { get; set; }
        public Int64? TicketID { get; set; }
        public string SeenStatus { get; set; }
        public string ViewTicket { get; set; }
        public string Paidstatus { get; set; }


    }
    public class EmpCommunication
    {
        public List<CommunicationLogResult> log { get; set; }
        // public string CustomerName { get; set; }
        // public string CustID { get; set; }

    }
    public class CommunicationLogRequest
    {
        public string ProfileID { get; set; }
        public int? FirstTSatus { get; set; }
        public int? intEmpId { get; set; }
    }
    public class CommunicationLogResult
    {
        public int? Sno { get; set; }
        public string ProfileStatus { get; set; }
        public string ProfileID { get; set; }
        public string Name { get; set; }
        public string ServiceDate { get; set; }
        public string LastName { get; set; }
        public string ProfileOwner { get; set; }
        public string TypeOfService { get; set; }
        public string EmpName { get; set; }
        public string Branch { get; set; }
        public string MFPStatus { get; set; }
        public string MFPStatusDate { get; set; }
        public string TicketID { get; set; }
        public string ResendDate { get; set; }
        public Int64? Emp_FollowupTicket_ID { get; set; }
        public string Options { get; set; }
        public int? ProfileStatusID { get; set; }
        public int? TicketStatusID { get; set; }
        public int? TotalRows { get; set; }
        public int? ExpressInterestID { get; set; }
        public object LogID { get; set; }
        public object ISRvrSend { get; set; }
        public object PhotoCount { get; set; }
        public string numbermail1 { get; set; }
        public string numbermail2 { get; set; }
        public string FromCustID { get; set; }
        public string ToCustID { get; set; }
        public string MeetingDate { get; set; }
        public int? PD { get; set; }
        public int? DPD { get; set; }
        public int? Viewed { get; set; }
        public int? NViewed { get; set; }
        public int? paid { get; set; }
        public string ServiceExpiryDate { get; set; }
        public string ServicePoints { get; set; }
        public int? iFromCustID { get; set; }
        public string FromName { get; set; }
        public int? iToCustID { get; set; }
        public string FromEmail { set; get; }
    }


    public class Regprofilevalidation
    {

        public string strMFFName { get; set; }
        public string strFFName { get; set; }
        public string strMFName { get; set; }
        public string strMFSurName { get; set; }
        public string strCustSurName { get; set; }
        public string strCustName { get; set; }
        public string strCaste { get; set; }
        public string strAllPhones { get; set; }
        public string strAllEmailIds { get; set; }
        public int? intEmpID { get; set; }
        public int? i_Startindex { get; set; }
        public int? i_EndIndex { get; set; }
        public string strMFFNativePlace { get; set; }
        public string strFatherName { get; set; }
        public string strMotherName { get; set; }
        public int? intAppicationStatusID { get; set; }
        public int? intGenderID { set; get; }
    }

    public class RegprofilevalidationPlaybutton
    {
        public string Profileid { get; set; }
        public string Branch_Dor { get; set; }
        public string paidamount { get; set; }
        public string paiddate { get; set; }
        public string sentreceivecount { get; set; }
        public int? PC { get; set; }
        public int? PD { get; set; }
        public int? DPD { get; set; }
        public int? View { get; set; }
        public int? Nview { get; set; }
        public int? BI { get; set; }
        public int? OppI { get; set; }
        public string ViewContact { get; set; }
        public string SA { get; set; }
        public int? Horo { get; set; }
        public string Tickets { get; set; }
        public string ProfileOwner { get; set; }
        public int? custid { get; set; }
        public int? empid { get; set; }
        public int? branchid { get; set; }

    }



    public class GetRegprofilevalidation
    {
        public string ProfileID { get; set; }
        public string ViewfullProfileID { get; set; }
        public string playbutton { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Caste { get; set; }
        public string DOR { get; set; }
        public string BranchCode { get; set; }
        public string ProfileOwner { get; set; }
        public int? TotalRows { get; set; }
        public int? TotalPages { get; set; }
        public string ProfileStatusID { get; set; }
        public int? ActiveCount { get; set; }
        public int? DeletedCount { get; set; }
        public int? SettledCount { get; set; }
        public int? InActiveCount { get; set; }
        public int? WaitingforSetldAuth { get; set; }
        public int? WaitingforDeltdAuth { get; set; }
        public int? MMSerious { get; set; }
        public long? TicketID { get; set; }
        public string TicketHistoryID { get; set; }
        public Int64? Cust_ID { get; set; }
        public int? paid { get; set; }
        public int? NoOfBrothers { get; set; }
        public int? NoOfSisters { get; set; }
        public int? Age { get; set; }
        public string DOB { get; set; }
        public string TOB { get; set; }
        public string Gothram { get; set; }
        public string fathercaste { get; set; }
        public string mothercaste { get; set; }
        public string maritalstatus { get; set; }
        public string Star { get; set; }
        public string Height { get; set; }
        public string EducationGroup { get; set; }
        public string EduGroupnamenew { get; set; }
        public string Profession { get; set; }
        public string JobLocation { get; set; }
        public string Color { get; set; }
        public string Income { get; set; }
        public string FFNative { get; set; }
        public string MFNative { get; set; }
        public string Property { get; set; }
        public int? PhotoCount { get; set; }
        public string CustomerFullPhoto { get; set; }
        public object KMPL { get; set; }
        public object IsConfidential { get; set; }
        public object SuperConfidentila { get; set; }
        public object HoroscopeStatus { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Intercaste { get; set; }

        public string SRCount { get; set; }

        public int? PaidAmount { get; set; }

        public string ExpiryDate { get; set; }

        public string Points { get; set; }

        public long? Emp_Ticket_ID { get; set; }

        public int? MatchMeetingCount { get; set; }

        public string ProfileOwnername { get; set; }

        public string EmpUserName { get; set; }

        public string EmpName { get; set; }

        public string SAForm { get; set; }

        public bool CNumberVerStatus { get; set; }

        public bool CEmailVerStatus { get; set; }

        public string Reason4InActive { get; set; }

        public long? Cust_Family_ID { get; set; }

        public int? CountryCodeID { get; set; }

        public string CreatedDate { get; set; }

        public string Primarynumber { get; set; }

        public string Primaryemail { get; set; }

        public string ContactNumber { get; set; }

        public string UserName { get; set; }
        public int? ProfileGrade { get; set; }
        public string mothertongue { get; set; }
        public string CustomerApplicationPhoto { get; set; }
    }


    //Resend or rvrsend

    public class RvrRequest
    {
        public int? FromcustID { get; set; }
        public int? TocustID { get; set; }
        public string AcceptLink { get; set; }
        public string RejectLink { get; set; }
        public Int32? ExpressInterestId { get; set; }
        public Int32? LogID { get; set; }
        public string isRvrflag { get; set; }
        public int empid { get; set; }
        public string strFromProfileID { get; set; }
        public string strToProfileID { get; set; }
    }
    public class Servicedates
    {
        public string Servicedate { get; set; }
        public int Status { get; set; }
    }


}