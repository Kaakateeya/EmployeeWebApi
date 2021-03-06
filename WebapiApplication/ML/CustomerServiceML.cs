﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WebapiApplication.ML
{
    public class CustSearchMl
    {
        public Int64? OwnerCustID { get; set; }
        public Int64? OppositCustID { get; set; }
        public Int32? PageID { get; set; }
        public string SpName { get; set; }
        public string SavedSearchName { get; set; }
        public string SavedSearchData { get; set; }
        public int SavedSearchID { get; set; }
        public string EditSavedSearch { get; set; }
        public Int64? CustID { get; set; }
        public string StrVerficationCode { get; set; }
        public int SearchFlag { get; set; }
        public int? SearchID { get; set; }
        public DataTable dtAdvanceData { get; set; }
        public DataTable dtGeneralData { get; set; }
        public DataTable dtQuickData { get; set; }
        public string StrKeywordData { get; set; }
        public string StrProfileIDData { get; set; }
        public DataTable dtIamLookingFor { get; set; }
        public Int64? BookmaredByCustID { get; set; }
        public Int64? BookmaredCustID { get; set; }
        public int BookmaredFlag { get; set; }
        public int intlowerBound { get; set; }
        public int intUpperBound { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public Int64? RequestedToCustID { get; set; }
        public Int64? RequestedByCustID { get; set; }
        public int? PhotoRequestedID { get; set; }
        public int PhotoRequestedCount { get; set; }
        public int Category { get; set; }
        public string StrHtmlText { get; set; }

        public Int64? ExpresedCustID { get; set; }
        public Int64? ExpressInterestedCustID { get; set; }

        public Int64? FromCustID { get; set; }
        public Int64? ToCustID { get; set; }
        public string strToCustID { get; set; }
        public Int32? MessageStatusId { get; set; }
        public Int32 SendAnyway { get; set; }
        public Int64? EmpId { get; set; }
        public Int32 ReadFlag { get; set; }
        public Int64? MessageHistoryId { get; set; }
        public Int32 Accepted { get; set; }
        public Int64? MessageLinkId { get; set; }
        public int PaidFlag { get; set; }
        public int Flag { get; set; }

        public string RecName { get; set; }
        public string RecEmail { get; set; }
        public string RecMessage { get; set; }
        public string RecMessageContent { get; set; }

        public string EncriptedText { get; set; }
        public string EncryptedFlagText { get; set; }
        public string EncryptedRejectFlagText { get; set; }

        public string EncriptedTextrvr { get; set; }

        public string EncryptedFlagTextrvr { get; set; }

        public string EncryptedRejectFlagTextrvr { get; set; }

        public string StrHtmlTextrvr { get; set; }

        public long CustIDrvr { get; set; }

        public string Totalcount { get; set; }

        public int month { get; set; }

        public DataTable dtExpressInterest { get; set; }

        public long? TargetProfileID { get; set; }

        public string strFromCustID { get; set; }

        public string strMessageComments { get; set; }

        public string strRecipientEmailIDs { get; set; }

        public string strRecipientName { get; set; }

        public int AcceptStatus { get; set; }

        public int MatchFollwupStatus { get; set; }
        public long ExpressInrestID { get; set; }
        public int? noofDays { get; set; }
        public string strtypeOfReport { get; set; }
        public string Methodname { get; set; }
        public string StrTocustIDs { get; set; }
        public int? IFromCustID { get; set; }
        public int? IToCustID { get; set; }
        public string TypeofInsert { get; set; }

        public long? Logid { get; set; }

        public string FromProfileID { get; set; }

        public string ToProfileID { get; set; }
    }
    public class ProfileStatus
    {
        public string OwnerName { get; set; }
        public long? CustID { get; set; }
        public int? statuss { get; set; }
        public string PrimaryEmail { get; set; }
    }
    public class InsertUnpaid
    {
        public string fromCustID { get; set; }
        public string ToCustID { get; set; }
        public int? Empid { get; set; }
        public string typeofAction { get; set; }
    }

    public class ViewfullProfileML
    {

        public string FromProfileID { get; set; }
        public string ToProfileID { get; set; }
        public int status { get; set; }
        public string ToCustID { get; set; }
        public string FromCustID { get; set; }
        public string PrimaryEmail { get; set; }

        public string AccRejFlag { get; set; }
    }
    public class UpdateExpressIntrestStatus
    {
        public long? ExpressInrestID { get; set; }
        public int? MatchFollwupStatus { get; set; }
        public int? AcceptStatus { get; set; }
        public long? CustID { get; set; }
        public int? noofDays { get; set; }
        public string spName { get; set; }

        public int? intEmpId { get; set; }

        public string strFromStatus { get; set; }
    }

    public class BothsideInterest
    {
        public long? fromcust_id { get; set; }
        public long? tocustid { get; set; }
        public int PhotoCount { get; set; }
        public int PhotoCountnew { get; set; }
        public string fromemp { get; set; }
        public string toemp { get; set; }
        public string FromProfileid { get; set; }
        public string Toprofileid { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }
        public string fromticketid { get; set; }
        public string Toticketid { get; set; }
        public string fromempname { get; set; }
        public string toempname { get; set; }
        public int TotalRows { get; set; }
        public int TotalPages { get; set; }
        public long? FromTicket { get; set; }
        public string FromTicketMatchmeetingStatus { get; set; }
        public string FromTicketAssignedEmpID { get; set; }
        public string FromTicketCreated { get; set; }
        public long? ToTicket { get; set; }
        public string ToTicketAssignedEmpID { get; set; }
        public string ToTicketCreated { get; set; }
        public string FromTicketHisoryType { get; set; }
        public string FromTicketHisoryNAME { get; set; }
        public string FromTicketHisoryDatenew { get; set; }
        public string ToTicketMatchmeetingStatus { get; set; }
        public string FromTicketHisoryReplyDesc { get; set; }
        public string FromTicketHisoryCallStatus { get; set; }
        public string FromTicketHisoryCallReceivedBy { get; set; }
        public string ToTicketHisoryType { get; set; }
        public string ToonlineExpiryDate { get; set; }
        public string ToOfflineExpiryDate { get; set; }
        public string FromOnlineMembershipExpiryDate { get; set; }
        public string FromOfflineExpiryDate { get; set; }
        public string ToonlineDetails { get; set; }
        public string TofflineDetails { get; set; }
        public string FromonlineDetails { get; set; }
        public string FromofflineDetails { get; set; }
        public int? TONEW { get; set; }
        public int? FROMNEW { get; set; }
        public string ToTicketHisoryDatenew { get; set; }
        public string ToTicketHisoryNAME { get; set; }
        public string ToTicketHisoryReplyDesc { get; set; }
        public string ToTicketHisoryCallStatus { get; set; }
        public string ToTicketHisoryCallReceivedBy { get; set; }
        public string ServiceDate { get; set; }
        public string FromEmail { get; set; }
        public string FromMobileNumber { get; set; }
        public string TOEmail { get; set; }
        public string ToMobileNumber { get; set; }
        public int? ToExpressCount { get; set; }
        public int? FromExpressCount { get; set; }
        public string FromSaPath { get; set; }
        public string FromBranchCode { get; set; }
        public string ToBranchCode { get; set; }
        public string FromticketStatusIDb { get; set; }
        public string FromTicketInfo { get; set; }
        public int? ISRvrSend { get; set; }
        public int? ToSerivceCount { get; set; }
        public int? FRomSerivceCount { get; set; }
        public string ToMobileCountryCode { get; set; }
        public string FromTicketHisoryRelationShip { get; set; }
        public string ToTicketHisoryRelationShip { get; set; }
        public string ToticketStatusIDb { get; set; }
        public string ToSaPath { get; set; }
        public string FromMobileCountryCode { get; set; }
        public string ToTicketInfo { get; set; }
        public string FromApplicationPhoto { set; get; }
        public string ToApplicationPhoto { set; get; }
        public int? FromPaidStatus { get; set; }
        public int? ToPaidStatus { get; set; }
        public DateTime? FromExpiryDate { get; set; }
        public DateTime? ToExpiryDate { get; set; }

        public long? Expressinterestlogid { get; set; }

        public int? fromgenderid { get; set; }

        public int? togenderid { get; set; }

        public int? fromIsconfidential { get; set; }

        public int? fromHighconfidential { get; set; }

        public int? toIsconfidential { get; set; }

        public int? toHighconfidential { get; set; }

        public long? ToEmpownerid { get; set; }

        public long? FromEmpownerid { get; set; }

        public string fromEmpmobilenumber { get; set; }

        public string toEmpmobilenumber { get; set; }

        public string Tosurname { get; set; }

        public string Fromsurname { get; set; }

        public string fromonlyempname { get; set; }

        public string toonlyempname { get; set; }
        public long? ExpressinterestTologid { get; set; }

        public string MFPFromEntered { get; set; }

        public string MFPToEntered { get; set; }

        public string ToRemDate { get; set; }

        public string FromRemDate { get; set; }

        public int? RowID { get; set; }

        public string EmpName { get; set; }

        public int? ExpressInterestID { get; set; }

        public int? ServicePending_EmpID { get; set; }

        public string ServicePending_EmpName { get; set; }

        public string FromlastService { set; get; }

        public string TolastService { set; get; }


        public long? MatchfollwupStatus { get; set; }
    }

    public class SearchML
    {
        public string empid { get; set; }
        public int? pagefrom { get; set; }
        public int? pageto { get; set; }
        public DateTime? Fromdate { get; set; }
        public DateTime? Todate { get; set; }
        public DataTable ProfileOwner { set; get; }
        public DataTable ProfileOwnerBranch { set; get; }
        public int? CustID { get; set; }
        public int? oppclose { get; set; }
        public DataTable region { get; set; }
        public int? Viewedcontacts { get; set; }
        public bool? Empwaiting { get; set; }
        public int? Spflag { get; set; }
        public string strProfileOwner { get; set; }
        public string strProfileOwnerBranch { get; set; }
        public string strregion { get; set; }


        public int? intViewPoint { get; set; }
        public int? intBackSear { get; set; }
        public int? intFowardSear { get; set; }



        public int? intMyInterest { get; set; }
    }

    public class EmployeeMarketingTicketResponse
    {

        public List<EmployeeMarketingslideticket> Marketingslideticket { get; set; }
        public List<EmployeeMarketingslideHistory> MarketingslideHistory { get; set; }

    }
    public class EmployeeUnassignedPages
    {
        public int pageid { get; set; }
    }

    public class EmployeeMarketingslideticket
    {
        public string TicketID { get; set; }
        public string Emp_Ticket_ID { get; set; }
        public string CustomerName { get; set; }
        public string Prirority { get; set; }
        public string RegistrationDate { get; set; }
        public string HighPriority { get; set; }
        public string Category { get; set; }
        public string TicketStatus { get; set; }
        public string ProfileID { get; set; }
        public string TicketIDSuffix { get; set; }
        public string CustLandingContID { get; set; }
        public string MybookMarkedProfCount { get; set; }
        public string WhobookmarkedCount { get; set; }
        public string RectViewedProfCount { get; set; }
        public string RectWhoViewedCout { get; set; }
        public string IgnoreProfileCount { get; set; }
        public string SentPhotoRequestCount { get; set; }
        public string EmpPhoto { set; get; }
        public string EmpName { set; get; }
        public string PhotoCount { get; set; }
        public string registeredBranch { get; set; }
        public string ReminderDate { get; set; }
        public string Lastlogin { get; set; }
        public string LoginCount { get; set; }
        public string TotalRows { get; set; }
        public string CustID { set; get; }
        public string Photo { get; set; }
        public string TicketOpenedOn { get; set; }
        public string AssignedtoEmp { get; set; }

        public Int64? ReminderID { get; set; }
        public string ReminderDatepopup { get; set; }
        public string EmpMobilenumber { get; set; }
        public string PrimaryEmail { get; set; }
        public string PrimaryContactNumber { get; set; }

        public Int64? AssignedToEmpID { get; set; }

        public string isEmailVerified { get; set; }

        public string IsMobileVerified { get; set; }

        public string ReminderTime { get; set; }

        public string PrimaryContactNumberCountyCode { get; set; }

        public string Reminderbody { get; set; }

        public int? NoofDays { get; set; }

        public string Feedetails { get; set; }

        public string onlinePayment { get; set; }

        public string offlinePayment { get; set; }

        public int? settleddeleted { get; set; }

        public int? ProfileStatusID { get; set; }

        public string SettlementValue { get; set; }

        public int? PD { get; set; }

        public int? DPD { get; set; }

        public int? ViewCount { get; set; }

        public int? NView { get; set; }

        public int? BI { get; set; }

        public int? OppI { get; set; }

        public string ServiceDate { get; set; }

        public long? isCustEmailID { get; set; }

        public long? IsCustContactNumbersID { get; set; }

        public string NodataFound { get; set; }

        public string TicketTypeID { get; set; }
        public Int64? ReminderRelationID { get; set; }
        public string ReminderRelationName { get; set; }
        public string SAPath { get; set; }

        public int? primaryCountryID { get; set; }

        public string FatherName { get; set; }
        public int? paidStatus { get; set; }
    }


    public class EmployeeMarketingslideHistory
    {

        public string TicketID { get; set; }
        public string Emp_Ticket_ID { get; set; }
        public string TicketType { get; set; }

        public string ReplyDatenew { get; set; }
        public string MatchmeetingStatus { get; set; }
        public string MatchMeetingReason { get; set; }
        public string NoOfDays { get; set; }
        public string ExpressintrestID { get; set; }
        public string NAME { get; set; }
        public string ReplyDesc { get; set; }
        public string CallStatus { get; set; }
        public string CallReceivedBy { get; set; }
        public string CallDiscussion { get; set; }
        public string EmpRed { get; set; }
        public string RelationShip { get; set; }
        public string Number { get; set; }
        public string ReplyDate { get; set; }
        public string Photo { set; get; }
        public string CustID { set; get; }

        public string TicketingCallHistoryID { get; set; }

        public string RelationShipID { get; set; }

        public string TicketTypeID { get; set; }
        public Int64? ReminderRelationID { get; set; }

        public string ReminderRelation { get; set; }

        public string ReminderRelationName { get; set; }

    }
    public class EmployeeMarketingTicketRequest
    {

        public string strBranch { set; get; }
        public string strEmpName { set; get; }
        public int? i_isAdmin { set; get; }
        public int? i_EmpID { set; get; }
        public int? i_PageFrom { set; get; }
        public int? i_PageTo { set; get; }
        public DateTime? dtFromProceedDate { get; set; }
        public DateTime? dtToProceedDate { get; set; }
        public int? i_days { set; get; }
        public int? i_RegionID { get; set; }
        public int? v_MarketremindeFlag { get; set; }
        public int? v_siblingflag { get; set; }
        public int? v_guestticketflag { get; set; }
        public int? v_OnlineExprd { get; set; }
        public int? v_OfflineExprd { get; set; }
        public string i_TicketId { get; set; }
        public string i_EmailId { get; set; }
        public string i_PhoneNumber { get; set; }
        public string i_Name { get; set; }
        public DateTime? dt_Opendate { get; set; }
        public string i_ProfileId { get; set; }
        public string i_Category { get; set; }
        public string i_Ticketstatus { get; set; }
        public DateTime? dt_FromRemainderdate { get; set; }
        public DateTime? dt_ToReminderdate { get; set; }
        public int? i_Excelflag { get; set; }
        public string V_Notpay { get; set; }

    }

    public class EmployeeMarketslidesendmail
    {
        public string strbody { get; set; }
        public string strMobileNumber { get; set; }
        public string strcountrycode { get; set; }
        public string strName { get; set; }
        public string strEmpname { get; set; }
        public int? strEmpid { get; set; }
        public string strEmpmobileNumber { get; set; }
        public Int64? Emp_TicketingCallHistoryID { get; set; }
        public string strMobileCountryCode { get; set; }
        public Int64? LTicketID { get; set; }
        public string marketbothflag { get; set; }
        public int? i_TicketID { get; set; }
        public Int64? Empid { get; set; }

    }

    public class TicketHistoryinfoRequest
    {
        public Int64 Ticketid { get; set; }
        public char Type { get; set; }
    }

    public class CreateEmployeeMl
    {
        public DataTable getEmployeeData()
        {
            DataTable dtCreateEmployee = new DataTable();
            dtCreateEmployee.Columns.Add("FirstName");
            dtCreateEmployee.Columns.Add("LastName");
            dtCreateEmployee.Columns.Add("OfficialEmailID");
            dtCreateEmployee.Columns.Add("HomeBranchID");
            dtCreateEmployee.Columns.Add("WorkPhone");
            dtCreateEmployee.Columns.Add("OfficialCellPhone");
            dtCreateEmployee.Columns.Add("HomePhone");
            dtCreateEmployee.Columns.Add("PersonalEmailID");
            dtCreateEmployee.Columns.Add("LoginName");
            dtCreateEmployee.Columns.Add("Password");
            dtCreateEmployee.Columns.Add("Designation");
            dtCreateEmployee.Columns.Add("LoginLocation");
            dtCreateEmployee.Columns.Add("OfficeFromHrs");
            dtCreateEmployee.Columns.Add("OfficeToHrs");
            dtCreateEmployee.Columns.Add("DayOff");
            dtCreateEmployee.Columns.Add("DateofJoining");
            dtCreateEmployee.Columns.Add("DateofReleaving");
            dtCreateEmployee.Columns.Add("ReportingMngrID");
            dtCreateEmployee.Columns.Add("AnnualIncome");
            dtCreateEmployee.Columns.Add("Country");
            dtCreateEmployee.Columns.Add("State");
            dtCreateEmployee.Columns.Add("District");
            dtCreateEmployee.Columns.Add("City");
            dtCreateEmployee.Columns.Add("CityOther");
            dtCreateEmployee.Columns.Add("Address");
            dtCreateEmployee.Columns.Add("EducationCategory");
            dtCreateEmployee.Columns.Add("EducationGroup");
            dtCreateEmployee.Columns.Add("EducationSpecialization");
            dtCreateEmployee.Columns.Add("EmployeeImgPath");
            //dtCreateEmployee.Columns.Add("TypeOfEmployee");
            //dtCreateEmployee.Columns.Add("EmployeeStatus");
            return dtCreateEmployee;
        }

        public DataTable getEmployeeDatanew()
        {
            DataTable dtCreateEmployee = new DataTable();
            dtCreateEmployee.Columns.Add("FirstName");
            dtCreateEmployee.Columns.Add("LastName");
            dtCreateEmployee.Columns.Add("OfficialEmailID");
            dtCreateEmployee.Columns.Add("HomeBranchID");
            dtCreateEmployee.Columns.Add("WorkPhone");
            dtCreateEmployee.Columns.Add("OfficialCellPhone");
            dtCreateEmployee.Columns.Add("HomePhone");
            dtCreateEmployee.Columns.Add("PersonalEmailID");
            dtCreateEmployee.Columns.Add("LoginName");
            dtCreateEmployee.Columns.Add("Password");
            dtCreateEmployee.Columns.Add("Designation");
            dtCreateEmployee.Columns.Add("LoginLocation");
            dtCreateEmployee.Columns.Add("OfficeFromHrs");
            dtCreateEmployee.Columns.Add("OfficeToHrs");
            dtCreateEmployee.Columns.Add("DayOff");
            dtCreateEmployee.Columns.Add("DateofJoining");
            dtCreateEmployee.Columns.Add("DateofReleaving");
            dtCreateEmployee.Columns.Add("ReportingMngrID");
            dtCreateEmployee.Columns.Add("AnnualIncome");
            dtCreateEmployee.Columns.Add("Country");
            dtCreateEmployee.Columns.Add("State");
            dtCreateEmployee.Columns.Add("District");
            dtCreateEmployee.Columns.Add("City");
            dtCreateEmployee.Columns.Add("CityOther");
            dtCreateEmployee.Columns.Add("Address");
            dtCreateEmployee.Columns.Add("EducationCategory");
            dtCreateEmployee.Columns.Add("EducationGroup");
            dtCreateEmployee.Columns.Add("EducationSpecialization");
            dtCreateEmployee.Columns.Add("EmployeeImgPath");
            dtCreateEmployee.Columns.Add("TypeOfEmployee");
            dtCreateEmployee.Columns.Add("EmployeeStatus");
            dtCreateEmployee.Columns.Add("isLoginAnywhere");

            return dtCreateEmployee;
        }

        public string StrQuery { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OfficialEmailID { get; set; }
        public int HomeBranchID { get; set; }
        public string WorkPhone { get; set; }
        public string OfficialCellPhone { get; set; }
        public string HomePhone { get; set; }
        public string PersonalEmailID { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public int Designation { get; set; }
        public string LoginLocation { get; set; }
        public string OfficeFromHrs { get; set; }
        public string OfficeToHrs { get; set; }
        public int DayOff { get; set; }
        public DateTime? DateofJoining { get; set; }
        public DateTime? DateofReleaving { get; set; }
        public Int64 ReportingMngrID { get; set; }
        public string AnnualIncome { get; set; }
        public int? Country { get; set; }
        public int? State { get; set; }
        public int? District { get; set; }
        public int? City { get; set; }
        public string CityOther { get; set; }
        public string Address { get; set; }
        public int? EducationCategory { get; set; }
        public int? EducationGroup { get; set; }
        public int? EducationSpecialization { get; set; }
        public int PageID { get; set; }
        public int isAdmin { get; set; }
        public string profileid { get; set; }
        public int flag { get; set; }
        public string TicketID { get; set; }
        public Int64? LTicketID { get; set; }
        public string TypeOfCall { get; set; }
        public string Category { get; set; }
        public string Notes { get; set; }
        public string StartDate { get; set; }
        public Int64? ReferenceID { get; set; }
        public string Name { get; set; }

        public Int64 CreatedEMPID { get; set; }
        public Int64 EMPID { get; set; }
        public Int64? ticketIDs { get; set; }

        public int EmpStatus { get; set; }

        public int? ContentStatus { get; set; }
        public string ContStatus { get; set; }
        public DataTable Branchs { get; set; }
        public DataTable EmplopyeNames { get; set; }
        public DataTable ReportingMags { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public int intlowerBound { get; set; }
        public int intUpperBound { get; set; }
        public string SortingName { get; set; }
        public int SortingOrder { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public int issenior { get; set; }
        public string userid { get; set; }
        public int isreview { get; set; }
        public long? EMPloyeedId { get; set; }
        public int ismarketing { get; set; }
        public int servicegivencount { get; set; }
        public int matchfollowupcount { get; set; }
        public int marketingticketscount { get; set; }
        public int PhotoCount { get; set; }
        public int HoroCount { get; set; }
        public string EmpName { get; set; }
        public int? HistoryUpdate { get; set; }
        public int? FromCustID { get; set; }
        public int? TocustID { get; set; }
        public string TicketStatusID { get; set; }
        public string AcceptLink { get; set; }
        public string RejectLink { get; set; }
        public string Subject { get; set; }
        public Int64? LToCustID { get; set; }
        public Int64? LFromCustID { get; set; }
        public string FromProfileID { get; set; }
        public string ToProfileID { get; set; }

    }

    public class MatchFollowupMailSend
    {

        public string profileid { get; set; }
        public string Notes { get; set; }
        public Int64 EMPID { get; set; }
        public Int64? LTicketID { get; set; }
        public int? HistoryUpdate { get; set; }
        public string AcceptLink { get; set; }
        public string RejectLink { get; set; }
        public int? FromCustID { get; set; }
        public int? TocustID { get; set; }
        public string TicketStatusID { get; set; }

        public string FromProfileID { get; set; }
        public string ToProfileID { get; set; }
    }

    public class MatchFollowupResendMail
    {
        public string AcceptLink { get; set; }
        public string Subject { get; set; }
        public Int64? LToCustID { get; set; }
        public Int64? LFromCustID { get; set; }
        public string RejectLink { get; set; }
        public Int64 EMPID { get; set; }
        public string TicketStatusID { get; set; }
        public string Notes { get; set; }
        public string FromProfileID { get; set; }
        public string ToProfileID { get; set; }
    }


    public class TicketCallHistory
    {

        public string CallType { get; set; }
        public string RelationName { get; set; }
        public int? CallResult { get; set; }
        public string PhoneNum { get; set; }
        public string CallDiscussion { get; set; }
        public bool? DisplayStatus { get; set; }
        public Int64? TicketID { get; set; }
        public Int64? EmpID { get; set; }
        public Int64? AssignedEmpID { get; set; }
        public Int32? Replaytypeid { get; set; }
        public int? RelationID { get; set; }


        public bool? FollowupStatus { get; set; }

        public int intExpressIntID { get; set; }

        public int intPendingEmpID { get; set; }

        public int? intFromTicketStatus { get; set; }
        public int? VoiceCallType { get; set; }
    }

    public class IncomingOutgoing
    {
        public int? CallType { get; set; }
        public string Calledon { get; set; }
        public int? RelationID { get; set; }
        public string RelationName { get; set; }
        public int? CallResult { get; set; }
        public long? StaffCalled { get; set; }
        public string PhoneNum { get; set; }
        public string CallDiscussion { get; set; }
        public int? DisplayStatus { get; set; }
        public long? TicketID { get; set; }
        public long? EmpID { get; set; }
        public int? VoiceCallType { get; set; }
    }


    public class uploadFormMl
    {
        public Int64? CreatedByEmpID { get; set; }
        public string CreatedDate { get; set; }
        public Int64? ModifiedByEmpID { get; set; }
        public string ModifiedEmpDate { get; set; }
        public int SettlementAgreedAmount { get; set; }
        public string Notes { get; set; }
        public int? isActive { get; set; }
        public string Settlementfrompath { get; set; }
        public int? isassigned { get; set; }
        public int? ReferenceID { get; set; }
        public string Profileidnew { get; set; }
    }
    public class BothsideInterestObjs
    {

        public List<BothsideInterestserveice> BothsideInterest { get; set; }


    }
    public class BothsideInterestserveice
    {
        public Int64? RowID { get; set; }

        public Int64? fromcust_id { get; set; }
        public Int64? tocustid { get; set; }
        public int PhotoCount { get; set; }
        public int PhotoCountnew { get; set; }
        public string FromProfileid { get; set; }
        public string Toprofileid { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }
        public string fromticketid { get; set; }
        public string Toticketid { get; set; }
        public int? fromMatchFollowUpStatus { get; set; }
        public int? toMatchFollowUpStatus { get; set; }
        public string fromempname { get; set; }
        public string toempname { get; set; }
        public string Viewedcustid { get; set; }
        public string Fromtickethistory { get; set; }
        public string totickethistory { get; set; }
        public int TotalRows { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }

        public string Photo { get; set; }
        public string Photonew { get; set; }

        public string fromemp { get; set; }
        public string toemp { get; set; }

        public Int64? ToTicket { get; set; }
        public string ToTicketStatus { get; set; }
        public string ToTicketOpenedOn { get; set; }
        public string ToTicketCategory { get; set; }
        public string ToTicketAssignedEmpID { get; set; }
        public string ToTicketPendingWith { get; set; }
        public string ToTicketSubject { get; set; }
        public int? ToticketStatusID { get; set; }
        public string ToTicketCreated { get; set; }
        public Int64? FromTicket { get; set; }
        public string FromTicketStatus { get; set; }
        public string FromTicketOpenedOn { get; set; }
        public string FromTicketCategory { get; set; }
        public string FromTicketAssignedEmpID { get; set; }
        public string FromTicketPendingWith { get; set; }
        public string FromTicketSubject { get; set; }
        public int? FromticketStatusID { get; set; }
        public string FromTicketCreated { get; set; }
        public string FromTicketHisoryType { get; set; }
        public string FromTicketHisoryDatenew { get; set; }
        public string FromTicketHisoryNAME { get; set; }
        public string FromTicketHisoryReplyDesc { get; set; }
        public string FromTicketHisoryCallStatus { get; set; }
        public string FromTicketHisoryCallReceivedBy { get; set; }
        public string FromTicketHisoryCallDiscussion { get; set; }
        public string FromTicketHisoryCreatedBy { get; set; }
        public string ToTicketHisoryType { get; set; }
        public string ToTicketHisoryDatenew { get; set; }
        public string ToTicketHisoryNAME { get; set; }
        public string ToTicketHisoryReplyDesc { get; set; }
        public string ToTicketHisoryCallStatus { get; set; }
        public string ToTicketHisoryCallReceivedBy { get; set; }
        public string ToTicketHisoryCallDiscussion { get; set; }
        public string ToTicketHisoryCreatedBy { get; set; }
        public string ServiceDate { get; set; }



        public string FromTicketHisoryRelationShip { get; set; }

        public string ToTicketHisoryRelationShip { get; set; }

        public string FromTicketNoofdays { get; set; }

        public string ToTicketNoofdays { get; set; }

        public string FromTicketMatchmeetingStatus { get; set; }

        public string ToTicketMatchmeetingStatus { get; set; }

        public string FromTicketMatchMeetingReason { get; set; }

        public string ToTicketMatchMeetingReason { get; set; }
        public string BranchCode { get; set; }
        public string fromcustidNumber { get; set; }
        public string tocustidNumber { get; set; }
        public string fromcustidEmail { get; set; }
        public string tocustidEmail { get; set; }
        public string FromonlinePayment { get; set; }
        public string FromofflinePayment { get; set; }
        public string ToonlinePayment { get; set; }
        public string ToofflinePayment { get; set; }

        public int? FromExpressCount { get; set; }

        public int? ToExpressCount { get; set; }

        public string FromBranchCode { get; set; }

        public string ToBranchCode { get; set; }

        public string FromMobileNumber { get; set; }

        public string FromMobileCountryCode { get; set; }

        public string ToMobileCountryCode { get; set; }

        public string FromEmail { get; set; }

        public string ToMobileNumber { get; set; }

        public string TOEmail { get; set; }

        public string ToSaPath { get; set; }

        public string FromSaPath { get; set; }

        public string FromticketStatusIDb { get; set; }
        public string ToticketStatusIDb { get; set; }

        public string FromTicketInfo { get; set; }
        public string ToTicketInfo { get; set; }


        public int? FRomSerivceCount { get; set; }

        public int? ToSerivceCount { get; set; }

        public int? ExpressInterestID { get; set; }

        public string FromApplicationPhoto { get; set; }

        public string ToApplicationPhoto { get; set; }

        public int? FROMNEW { get; set; }

        public int? TONEW { get; set; }

        public string DOB { get; set; }

        public string ToB { get; set; }

        public string CustPhoto { get; set; }

        public string mothercaste { get; set; }

        public string fathercaste { get; set; }

        public Boolean? Intercaste { get; set; }

        public double? Property { get; set; }

        public string FFNative { get; set; }

        public string Income { get; set; }

        public string PlaceOfBirth { get; set; }

        public string Caste { get; set; }

        public string MFNative { get; set; }

        public string JobLocation { get; set; }

        public string Gothram { get; set; }
        public string maritalstatus { get; set; }
        public string Color { get; set; }
        public string Star { get; set; }
        public string Height { get; set; }
        public string EducationGroup { get; set; }
        public string EduGroupnamenew { get; set; }
        public string Profession { get; set; }

        public string paid { get; set; }

        public Boolean? IsConfidential { get; set; }

        public int? HoroscopeStatus { get; set; }

        public int? SuperConfidentila { get; set; }

        public string KMPLID { get; set; }

        public string ApplicationPhoto { get; set; }

        public Int64? Logid { get; set; }

        public int? genderid { get; set; }

        public string FromCust_InterestStatus { get; set; }

        public string ToCust_InterestStatus { get; set; }

        public int? ISRvrSend { get; set; }

        public string PaidStatus { get; set; }

        public string FromofflineDetails { get; set; }
        public string FromonlineDetails { get; set; }
        public string TofflineDetails { get; set; }
        public string ToonlineDetails { get; set; }


        public string FromOfflineExpiryDate { get; set; }

        public string FromOnlineMembershipExpiryDate { get; set; }

        public string ToOfflineExpiryDate { get; set; }

        public string ToonlineExpiryDate { get; set; }

        public int? ProfileStatusID { get; set; }
    }

    public class Servicesslideslideshowbasedonprofile
    {
        public string v_profileid { get; set; }
        public int i_empid { get; set; }
        public string c_intersttype { get; set; }
        public string c_oppintersttype { get; set; }
        public int pagefrom { get; set; }
        public int pageto { get; set; }

        public string intApplicationStatus { get; set; }

        public string strProfileFNameLName { get; set; }
    }

    public class SettledDeletedML
    {
        public Int64? BrideCustID { get; set; }
        public Int64? BrideEmpID { get; set; }
        public Int64? GroomCustID { get; set; }
        public Int64? GroomEmpID { get; set; }
        public DateTime? Engagementdate { get; set; }
        public string EngagementVenue { get; set; }
        public DateTime? Marriagedate { get; set; }
        public string MarriageVenue { get; set; }
        public int? InformedBySide { get; set; }
        public int? InformedBy { get; set; }
        public string Narriation { get; set; }
        public Int64? EmpID { get; set; }
        public int? AuthorizeStatus { get; set; }
        public string SendMailfornew { get; set; }
        public DateTime? Settleddate { get; set; }
        //delete
        public Int64? Int64ProfileID { get; set; }
        public int? SendMail { get; set; }
        public string DelSurname { get; set; }
        public string DelName1 { get; set; }
        public string DelFatherName { get; set; }
        public string DelNative { get; set; }
        public string DelEducation { get; set; }
        public string DelProfession { get; set; }
        public int? DelReasonForDelete { get; set; }
        public int? DelRelationship { get; set; }
        public string DelRelationshipName { get; set; }
        public List<empSms> smslist { get; set; }
    }

    public class empSms
    {
        public string empname { get; set; }
        public string number { get; set; }
        public string ticketId { get; set; }
    }
    public class CustomerPaymentOffers
    {
        public string ProfileID { set; get; }
        public int? MembershipID { set; get; }
        public int? CasteID { set; get; }
        public decimal? MembershipAmt { set; get; }
        public decimal? ServiceTaxAmt { set; get; }
        public int? AllocatedPts { set; get; }
        public int? MemberShipDuration { set; get; }
        public DateTime? StartTime { set; get; }
        public DateTime? EndDate { set; get; }

    }

    public class ViewProfileInputInbit
    {

        public string MobileNumber { get; set; }
        public string MobileCode { get; set; }
        public string VerificationCode { get; set; }
        public string CustContactNumbersID { get; set; }
        public string MIsVerified { get; set; }
        public string Email { get; set; }
        public string EIsVerified { get; set; }
        public string BitInfo { set; get; }
        public string CustID { get; set; }
    }

    public class PersonalinteractionMatchFollowup
    {
        public Int64? CustId { set; get; }
        public string CreatedDate { set; get; }
        public Int64? EnteredbyEmpID { set; get; }
        public string Empdetails { set; get; }
        public string relationName { set; get; }

    }



    public class assignprofiles
    {
        public string ProfileID { set; get; }
        public Int64? CustID { set; get; }
        public Int64? ModifiedEMPID { set; get; }
        public Int64? ProfileOwner { set; get; }
        public Int64? MarketingOwner { set; get; }
        public Int64? ReviewOwner { set; get; }

        public DataTable dtTableValues { get; set; }
    }
    public class assignprofilessubmit
    {
        public string ProfileID { set; get; }
        public Int64? CustID { set; get; }
        public Int64? ModifiedEMPID { set; get; }
        public Int64? ProfileOwner { set; get; }
        public Int64? MarketingOwner { set; get; }
        public Int64? ReviewOwner { set; get; }

    }
    public class Reviewpending
    {
        public Int64? CustID { set; get; }
        public Int64? EmpID { set; get; }
        public int? i_Reviewpending { set; get; }
    }
    public class insertmonthlybills
    {
        public DateTime? paymentdate { set; get; }
        public int? paymenttype { set; get; }
        public string paymentnarration { set; get; }
        public int? Empid { set; get; }
    }
    public class employeeEditpartnerInfo
    {
        public string strprofileID { set; get; }
        public DateTime? dtFromdate { set; get; }
        public DateTime? dtTodate { set; get; }
        public string intSessionValues { set; get; }
        public int? startindex { set; get; }
        public int? endindex { set; get; }
    }
    public class employeemodifiedpartner
    {
        public int Entryid { set; get; }
        public int Empid { set; get; }
        public int flag { set; get; }
        public Int64? custid { set; get; }
    }

    public class employeRegistrationInfo
    {
        public string strprofileID { set; get; }
        public DateTime? dtFromdate { set; get; }
        public DateTime? dtTodate { set; get; }
        public string intSessionValues { set; get; }

        public int? intRegion { set; get; }
        public string strBranchID { set; get; }
        public string strProfileOwn { set; get; }

        public int? startindex { set; get; }
        public int? endindex { set; get; }

        public string intchkNotdata { get; set; }

    }
    public class compareprofiles
    {
        public string strprofileIDs { set; get; }

    }

    public class unpaidnotupdated
    {
        public int? i_EmpID { set; get; }
        public int? i_PageFrom { set; get; }
        public int? i_PageTo { set; get; }
        public string strRegional { set; get; }
        public string strBranch { set; get; }
        public string strProfileowner { set; get; }
        public int? intGender { set; get; }
    }

    // schdulepageinfo
    public class schdulepageinfo
    {
        public string Schdulename { set; get; }
        public string Purposepoint { set; get; }
        public string Timeperiod { set; get; }
        public string Spname { set; get; }
        // public string Runstatus { set; get; }
        public int? iflag { set; get; }
        public long? scdularId { set; get; }
    }

    // teamheadinfo
    public class Teamheadinfo
    {
        public int? EmpType { set; get; }
        public int? Regions { set; get; }
        public string Branchs { set; get; }
        public string ProfileOwner { set; get; }
        public string Generalprocess { set; get; }
        public string Marketingprocess { set; get; }
        public string MatchFollowupprocess { set; get; }
        public string Teamhead { set; get; }
        public int? istartIndex { set; get; }
        public int? iEndIndex { set; get; }
    }

    // strickers page
    public class strickerspageinfo
    {
        public int? BranchId { set; get; }
        public int? Region { set; get; }
        public int? ApplicationStatus { set; get; }
    }

    // EmpMatchFollowupandMarketingHistory
    public class employeematchfollowupinfo
    {
        public int? intFollowupStatus { set; get; }
        public int? intCallStatus { set; get; }
        public int? intNoOfDays { set; get; }
        public int? intEmpID { set; get; }
        public int? intVoiceCallType { set; get; }
        public int? istartindex { set; get; }
        public int? iendIndex { set; get; }
        public DateTime? dtfromDate { set; get; }
        public DateTime? dtTodate { set; get; }
        public string iapplicationStatus { set; get; }
        public int? iCalltype { set; get; }
    }

    // Accountsdetailspage 
    public class accountspageinfo
    {
        public int? idate { set; get; }
        public string iTypeofPayment { set; get; }
        public string ibankName { set; get; }
        public int? iAmount { set; get; }
        public string v_Beneficiaryname { set; get; }
        public string ibranchName { set; get; }
        public string v_Description { set; get; }
        public int? iflag { set; get; }
    }

    // viewdetailspage 
    public class viewpageinfo
    {
        public int? datefrom { set; get; }
        public int? dateTo { set; get; }
        public string typeofPayment { set; get; }
        public string bankName { set; get; }
        public string Branchname { set; get; }
        public int? iflag { set; get; }
        public int? Paidstatus { set; get; }
        public string TobePaid { set; get; }
        public string Region { set; get; }
    }

    public class ystryPending
    {
        public int? strRegional { set; get; }
        public string strBranch { set; get; }
        public string strProfileowner { set; get; }
    }
    public class kakagentCall
    {
        public long? AgentNumber { get; set; }
        public long? CustomerNumber { get; set; }
        public string callid { set; get; }
        public string StatusMessages { set; get; }
        public int? StatusId { get; set; }
    }
    public class exceldata
    {

        public string SalesExecutive { set; get; }
        public string CallerName { set; get; }
        public string CallerNumber { set; get; }
        public string CallStatus { set; get; }
        public int Duration { set; get; }
        public string CallType { set; get; }
        public string note { set; get; }
        public string Status { set; get; }
        public DateTime? CreatedDate { set; get; }

    }


    public class fileuploadexcel
    {
        public DateTime? exceluploaddate { get; set; }
        public List<exceldata> exceluploaddatelist { get; set; }

    }

}

