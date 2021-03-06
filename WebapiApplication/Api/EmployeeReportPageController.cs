﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Http;
using WebapiApplication.DAL;
using WebapiApplication.Implement;
using WebapiApplication.Interfaces;
using WebapiApplication.ML;
using WebapiApplication.UserDefinedTable;
using WebapiApplication.ServiceReference1;
using Newtonsoft.Json.Linq;
namespace WebapiApplication.Api
{
    public class EmployeeReportPageController : ApiController
    {
        private readonly IEmployeeReportPage IEmployeeReport;

        public EmployeeReportPageController()
            : base()
        {
            this.IEmployeeReport = new ImpEmployeeReportPage();
        }

        public ArrayList getMarketingSldeshowshortlistprofiles(string CustID)
        {
            return this.IEmployeeReport.MarketingSldeshowshortlistprofiles(CustID);
        }

        public ArrayList getMyProfileBindings(string flag, string ID)
        {
            return this.IEmployeeReport.MyProfileBindings(flag, ID);
        }

        public ArrayList MyprofileAllslides([FromBody]myprofileRequest Mobj)
        {
            return this.IEmployeeReport.MyprofileAllslides(Mobj);
        }

        public int SaveViewedBookmark_Customer([FromBody]CustSearchMl Mobj)
        {
            return this.IEmployeeReport.SaveViewedBookmark_Customer(Mobj);
        }

        public ArrayList getSendServiceProfileIDs(string ProfileIDs)
        {
            return this.IEmployeeReport.SendServiceProfileIDs(ProfileIDs);
        }

        public ArrayList MatchfollowupSlideShowResult([FromBody]SearchML Mobj)
        {
            Mobj.ProfileOwner = Commonclass.getTableData(Mobj.strProfileOwner, "owner");
            Mobj.ProfileOwnerBranch = Commonclass.getTableData(Mobj.strProfileOwnerBranch, "branch");
            Mobj.region = Commonclass.getTableData(Mobj.strregion, "region");
            return this.IEmployeeReport.MatchfollowupSlideShowResult(Mobj);
        }

        public ArrayList getMyProfileBindingsBranch(string flag, string ID)
        {
            return this.IEmployeeReport.MyProfileBindingsBranch(flag, ID);
        }

        public EmployeeMarketingTicketResponse MarketingTicketHistoryInfo([FromBody]EmployeeMarketingTicketRequest Mobj)
        {
            return this.IEmployeeReport.GetmarketingTicketHistoryInfo(Mobj);
        }

        public int MatchFollowupSendSms([FromBody]EmployeeMarketslidesendmail SendSms)
        {
            int? inull = null; if (SendSms.i_TicketID != inull && SendSms.i_TicketID != 0) { Commonclass.SendSms_new(SendSms); return this.IEmployeeReport.MatchFollowupSendSms(SendSms); } else { return 1; }
        }

        public int MatchFollowupMailSend([FromBody] MatchFollowupMailSend SendMail)
        {
            SendMail.AcceptLink = Commonclass.ReturnEncryptLink("Accept", (!string.IsNullOrEmpty(SendMail.FromProfileID) ? SendMail.FromProfileID : null), (!string.IsNullOrEmpty(SendMail.ToProfileID) ? SendMail.ToProfileID : null));
            SendMail.RejectLink = Commonclass.ReturnEncryptLink("Reject", !string.IsNullOrEmpty(SendMail.FromProfileID) ? SendMail.FromProfileID : null, !string.IsNullOrEmpty(SendMail.ToProfileID) ? SendMail.ToProfileID : null);
            return this.IEmployeeReport.MatchFollowupMailSend(SendMail);
        }

        public List<TicketHistoryinfoResponse> getMatchFollowupTicketinformation(long? Ticketid, char Type)
        {
            return this.IEmployeeReport.MatchFollowupTicketinformation(Ticketid, Type);
        }

        public List<MarketingTicketResponseinfo> getMarketingTicketinformation(long? Ticketid, char Type)
        {
            return this.IEmployeeReport.MarketingTicketinformation(Ticketid, Type);
        }

        public List<MarketingTicketResponseHistory> getMarketingTickethistory(long? Ticketid, char Type)
        {
            return this.IEmployeeReport.MarketingTickethistory(Ticketid, Type);
        }

        public int MatchFollowupResendMail([FromBody]MatchFollowupResendMail ResendMail)
        {
            ResendMail.AcceptLink = Commonclass.ReturnEncryptLink("Accept", (!string.IsNullOrEmpty(ResendMail.FromProfileID) ? ResendMail.FromProfileID : null), (!string.IsNullOrEmpty(ResendMail.ToProfileID) ? ResendMail.ToProfileID : null));
            ResendMail.RejectLink = Commonclass.ReturnEncryptLink("Reject", !string.IsNullOrEmpty(ResendMail.FromProfileID) ? ResendMail.FromProfileID : null, !string.IsNullOrEmpty(ResendMail.ToProfileID) ? ResendMail.ToProfileID : null);
            return this.IEmployeeReport.MatchFollowupResendMail(ResendMail);
        }

        public int Insertout_incomingcallCommunicationlogData([FromBody]TicketCallHistory Mobj)
        {
            return this.IEmployeeReport.Insertout_incomingcallCommunicationlogData(Mobj);
        }

        public int Insertout_incomingcallData([FromBody]IncomingOutgoing Mobj)
        {
            return this.IEmployeeReport.Insertout_incomingcallData(Mobj);
        }

        public int getReaasignEmployee(long? TicketID, long? AssignedEmpID, long? EmpID, int? StatusID)
        {
            return this.IEmployeeReport.ReaasignEmployee(TicketID, AssignedEmpID, EmpID, StatusID);
        }

        public int getInsertInternalMemo(string Message, long? TicketID, long? EmpID, long? AssignedEmpID)
        {
            return this.IEmployeeReport.InsertInternalMemo(Message, TicketID, EmpID, AssignedEmpID);
        }

        public int getClosedTickets(string ReasonforClose, long? TicketID, long? EmpID)
        {
            return this.IEmployeeReport.ClosedTickets(ReasonforClose, TicketID, EmpID);
        }

        public int getSendNumbersMatchfollowup(long? LFromCustID, long? LToCustID, int? empid, string mailTxt)
        {
            return this.IEmployeeReport.SendNumbersMatchfollowup(LFromCustID, LToCustID, empid, mailTxt);
        }

        //Communication Log  Page

        //public List<EmpCommunication> getEmployeeCommunicationLog(string ProfileID, int? intEmpId) { return this.IEmployeeReport.EmployeeCommunicationLog(ProfileID, intEmpId); }
        public ArrayList getEmployeeCommunicationLog(string ProfileID, int? intEmpId) { return this.IEmployeeReport.EmployeeCommunicationLog(ProfileID, intEmpId); }

        public Tuple<int, List<CommunicationLogResult>> EmployeeCommunicationLogRvrAndResend([FromBody]RvrRequest Mobj)
        {
            if (Mobj.isRvrflag == "RVR")
            {
                Mobj.AcceptLink = Commonclass.ReturnEncryptLink("Accept", (Mobj.TocustID != null && Mobj.TocustID != 0) ? Mobj.TocustID.ToString() : null, (Mobj.FromcustID != null && Mobj.FromcustID != 0) ? (Mobj.FromcustID).ToString() : null);
                Mobj.RejectLink = Commonclass.ReturnEncryptLink("Reject", (Mobj.TocustID != null && Mobj.TocustID != 0) ? Mobj.TocustID.ToString() : null, (Mobj.FromcustID != null && Mobj.FromcustID != 0) ? (Mobj.FromcustID).ToString() : null);
            }
            else
            {
                Mobj.AcceptLink = Commonclass.ReturnEncryptLink("Accept", (Mobj.FromcustID != null && Mobj.FromcustID != 0) ? Mobj.FromcustID.ToString() : null, (Mobj.TocustID != null && Mobj.TocustID != 0) ? (Mobj.TocustID).ToString() : null);
                Mobj.RejectLink = Commonclass.ReturnEncryptLink("Reject", (Mobj.FromcustID != null && Mobj.FromcustID != 0) ? Mobj.FromcustID.ToString() : null, (Mobj.TocustID != null && Mobj.TocustID != 0) ? (Mobj.TocustID).ToString() : null);
            }

            return this.IEmployeeReport.EmployeeCommunicationLogRvrAndResend(Mobj);
        }

        public int getEmployeeCommunicationLogSentphotosemail(string Email, string CustID)
        {
            return this.IEmployeeReport.EmployeeCommunicationLogSentphotosemail(Email, CustID);
        }

        public int EmployeeCommunicationLogSendMarketingMail([FromBody]CreateEmployeeMl Mobj)
        {
            Mobj.AcceptLink = Commonclass.ReturnEncryptLink("Accept", (!string.IsNullOrEmpty(Mobj.FromProfileID) ? Mobj.FromProfileID : null), (!string.IsNullOrEmpty(Mobj.ToProfileID) ? Mobj.ToProfileID : null));
            Mobj.RejectLink = Commonclass.ReturnEncryptLink("Reject", !string.IsNullOrEmpty(Mobj.FromProfileID) ? Mobj.FromProfileID : null, !string.IsNullOrEmpty(Mobj.ToProfileID) ? Mobj.ToProfileID : null);
            return this.IEmployeeReport.EmployeeCommunicationLogSendMarketingMail(Mobj);
        }

        // RegistrationValidation

        public List<GetRegprofilevalidation> RegistrationValidation([FromBody]Regprofilevalidation RegValidation)
        {
            return this.IEmployeeReport.RegistrationValidation(RegValidation);
        }

        public List<GetRegprofilevalidationtable> RegistrationValidationtable([FromBody]Regprofilevalidation RegValidation)
        {
            return this.IEmployeeReport.RegistrationValidation_Table(RegValidation);
        }

        public List<GetRegprofilevalidation> RegistrationValidation_Counts([FromBody]Regprofilevalidation RegValidation)
        {
            return this.IEmployeeReport.RegistrationValidation_Counts(RegValidation);
        }

        public List<RegprofilevalidationPlaybutton> getRegistrationValidation_Playbutton(string Profileid)
        {
            return this.IEmployeeReport.RegistrationValidation_Playbutton(Profileid);
        }

        public int FeeUpdate(FeeUpdateML mobj)
        {
            return this.IEmployeeReport.FeeUpdate(mobj);
        }

        public int createReminderInsert(CreateReminderMI mobj)
        {
            return this.IEmployeeReport.createReminder(mobj);
        }

        public int marketingSendSms([FromBody]EmployeeMarketslidesendmail SendSms)
        {
            int? inull = null;
            if (SendSms.Emp_TicketingCallHistoryID != inull && SendSms.Emp_TicketingCallHistoryID != 0)
            {
                Commonclass.SendSms_new(SendSms);
                return this.IEmployeeReport.marketingSendSms(SendSms);
            }
            else { return 1; }
        }

        public int marketingMailSend([FromBody] MatchFollowupMailSend SendMail)
        {
            SendMail.AcceptLink = Commonclass.ReturnEncryptLink("Accept", (!string.IsNullOrEmpty(SendMail.FromProfileID) ? SendMail.FromProfileID : null), (!string.IsNullOrEmpty(SendMail.ToProfileID) ? SendMail.ToProfileID : null));
            SendMail.RejectLink = Commonclass.ReturnEncryptLink("Reject", !string.IsNullOrEmpty(SendMail.FromProfileID) ? SendMail.FromProfileID : null, !string.IsNullOrEmpty(SendMail.ToProfileID) ? SendMail.ToProfileID : null);
            return this.IEmployeeReport.marketingMailSend(SendMail);
        }

        public int uploadSettlementForm(uploadFormMl mobj)
        {
            return this.IEmployeeReport.uploadSettlementForm(mobj);
        }

        public Tuple<int?, int?> getcheckSettlementProfileID(string profileID)
        {
            return this.IEmployeeReport.checkSettlementProfileID(profileID);
        }

        public List<BothsideInterestObjs> ServiceSlideshowdata([FromBody]Servicesslideslideshowbasedonprofile Mobj)
        {
            return this.IEmployeeReport.ServiceSlideshowdata(Mobj);
        }

        public Tuple<int?, int?> getcheckSettlementProfileIDandEmail(string profileID)
        {
            return this.IEmployeeReport.checkSettlementProfileIDandEmail(profileID);
        }

        public int Submitsettledprfiles(SettledDeletedML mobj)
        {
            return this.IEmployeeReport.settledprofilesInsertion(mobj);
        }

        public int Submitdeletedprfiles(SettledDeletedML mobj)
        {
            return this.IEmployeeReport.deletedprofilesInsertion(mobj);
        }

        public ArrayList AssignSettings([FromBody]NoServiceML Mobj)
        {
            return this.IEmployeeReport.AssignSettings(Mobj);
        }

        public ArrayList ReviewpendingReports([FromBody]AssigningProfileML Mobj)
        {
            return this.IEmployeeReport.ReviewpendingReports(Mobj);
        }

        public int? Assignprofiles([FromBody]assignprofiles assign)
        {
            List<assignprofiles> lstPayment = new List<assignprofiles>();
            lstPayment.Add(assign);
            assign.dtTableValues = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtassignsettings(), lstPayment);
            return this.IEmployeeReport.assignprofiles(assign);
        }

        public int? ReviewpendingReassign(Reviewpending mobj)
        {
            return this.IEmployeeReport.ReviewpendingReassign(mobj);
        }

        public ArrayList getDuplicateProfiles(string profileID)
        {
            return this.IEmployeeReport.getDuplicateProfiles(profileID);
        }

        public ArrayList getmmSeriesData(string profileID, int empid)
        {
            return this.IEmployeeReport.getmmSeriesData(profileID, empid);
        }

        public ArrayList Guestticketcreation([FromBody]guestticketcreation Mobj)
        {
            return this.IEmployeeReport.Guestticketcreation(Mobj);
        }

        public int getChangeEmployeePassword(int? EmpID, string EmpoldPassword, string EmpNewPassword)
        {
            return this.IEmployeeReport.ChangeEmployeePassword(EmpID, EmpoldPassword, EmpNewPassword);
        }

        public int getCheckemployeePassord(int? EmpID, string Emppassword)
        {
            return this.IEmployeeReport.CheckemployeePassord(EmpID, Emppassword);
        }

        public int getprofileidexistornot(string profileid)
        {
            return this.IEmployeeReport.profileidexistornot(profileid);
        }

        public ArrayList getpresentunpaidmembers(int? EmpID)
        {
            return this.IEmployeeReport.presentunpaidmember(EmpID);
        }

        public int getUpadteMacAddess(string strProfileID, string ipaddresss2, int? BranchID)
        {
            return this.IEmployeeReport.UpadteMacAddess(strProfileID, ipaddresss2, BranchID);
        }

        public ArrayList customermeassgeverification([FromBody]messagesverification Mobj)
        {
            return this.IEmployeeReport.customermeassgeverification(Mobj);
        }

        public int updatecustomermessages([FromBody]updatemessagesverification Mobj)
        {
            return this.IEmployeeReport.updatecustomermessages(Mobj);
        }

        public int Editpaymentpointexpdate([FromBody]EditpaymentpointS Mobj)
        {
            return this.IEmployeeReport.Editpaymentpointexpdate(Mobj);
        }

        public ArrayList getPaymentexentionpointsdays(string Profileid)
        {
            return this.IEmployeeReport.Paymentexentionpointsdays(Profileid);
        }

        public ArrayList authorizationpaymentamoutReport([FromBody]authorizationpayment Mobj)
        {
            return this.IEmployeeReport.authorizationpaymentamoutReport(Mobj);
        }

        public int Editpayment([FromBody]employeepaymentedit Mobj)
        {
            return this.IEmployeeReport.Editpayment(Mobj);
        }

        public int InsertEmailBouceEntry([FromBody]insertemailsbounce Mobj)
        {
            return this.IEmployeeReport.InsertEmailBouceEntry(Mobj);
        }

        public int getexistanceprofileornot(string profileid)
        {
            return this.IEmployeeReport.existanceprofileornot(profileid);
        }

        public ArrayList EmplyeepaymentReportspayment([FromBody]paymentreports Mobj)
        {
            return this.IEmployeeReport.EmplyeepaymentReportspayment(Mobj);
        }

        public int getSendMailRegidtrationFeeDetails(Int64? CustID)
        {
            return this.IEmployeeReport.SendMailRegidtrationFeeDetails(CustID);
        }

        public int EmployeepaymentreportsSendsms([FromBody]paymentreportsms Mobj)
        {
            return this.IEmployeeReport.EmployeepaymentreportsSendsms(Mobj);
        }

        public ArrayList getPaymentoffersbasedonselect(string Profileid, int? casteid)
        {
            return this.IEmployeeReport.Paymentoffersbasedonselect(Profileid, casteid);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="Mobj"></param>
        /// <returns></returns>
        ///

        public int Editanddeleteupdateoffers([FromBody]paymenteditdelete Mobj)
        {
            return this.IEmployeeReport.Editanddeleteupdateoffers(Mobj);
        }

        public int getVerifyProfileid(string profileid)
        {
            return this.IEmployeeReport.VerifyProfileid(profileid);
        }

        public ArrayList getCustomerFactsheetDetails(string Profileid)
        {
            return this.IEmployeeReport.CustomerFactsheetDetails(Profileid);
        }

        public int getcustmorfactsheetsendMail(string profileid)
        {
            return this.IEmployeeReport.custmorfactsheetsendMail(profileid);
        }

        public int? getsendEmail_factResetPassword(string profileid)
        {
            return this.IEmployeeReport.sendEmail_factResetPassword(profileid, Commonclass.profileidEncrypt(profileid));
        }

        public int? getsendEmail_ResetPassword(string profileid)
        {
            return this.IEmployeeReport.sendEmail_ResetPassword(profileid);
        }

        public int Successstoriesupload([FromBody]emplyeeSuccessStoryML Mobj)
        {
            return this.IEmployeeReport.Successstoriesupload(Mobj);
        }

        public int? getMarketingticketstatus(Int64? ticketid, string EmpID)
        {
            return this.IEmployeeReport.Marketingticketstatus(ticketid, EmpID);
        }

        public ArrayList getAdminReportsAllProfiles(int? i_EmpID, string i_BranchID, int? i_Region, string v_MacAddress, int? flag, string v_ProfileOwnerEmpID)
        {
            return this.IEmployeeReport.AdminReportsAllProfiles(i_EmpID, i_BranchID, i_Region, v_MacAddress, flag, v_ProfileOwnerEmpID);
        }

        public ArrayList getCheckSurNameNamedob(string strSurName, string StrName, DateTime? dtDOB)
        {
            return this.IEmployeeReport.CheckSurNameNamedob(strSurName, StrName, dtDOB);
        }

        public int? InsertResonForNoService([FromBody]insetnoserice Mobj)
        {
            return this.IEmployeeReport.InsertResonForNoService(Mobj);
        }

        //string v_EmpID, int? i_Region, string v_Branch, int? i_flag, int? i_Cust_ID, string v_Reason, int? i_Authorized
        public ArrayList Nomatchesreasons([FromBody]nomatchesreason Mobj) { return this.IEmployeeReport.Nomatchesreasons(Mobj); }

        public ArrayList Oldkmplkeywordlikesearch([FromBody]CreateKeywordLlikesearchReqoldkmpl oldkmpl)
        {
            List<CreateKeywordLlikesearchReqoldkmpl> lstkmpl = new List<CreateKeywordLlikesearchReqoldkmpl>();
            lstkmpl.Add(oldkmpl);
            oldkmpl.dtPartnerPreference = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtkeywordsearch(), lstkmpl);
            return this.IEmployeeReport.Oldkmplkeywordlikesearch(oldkmpl);
        }

        public List<EmpNotifications> employeenotications([FromBody]EmpNotifications empnotification)
        {
            return this.IEmployeeReport.employeenotications(empnotification);
        }

        public int? getnoserviceemailsfromcustomer(string profileid, int? empid)
        {
            return this.IEmployeeReport.noserviceemailsfromcustomer(profileid, empid);
        }

        ////
        public ArrayList keywordlikesearch([FromBody]keywordlikesearch keyword)
        {
            List<keywordlikesearch> lstkeyword = new List<keywordlikesearch>();
            lstkeyword.Add(keyword);
            keyword.dtPartnerPreference = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtlikekeywordsearch(), lstkeyword);
            return this.IEmployeeReport.keywordlikesearch(keyword);
        }

        //06_10_2017

        public int getInsertMatchfollowupExpressinterest([FromUri]int? fromcustid, [FromUri]int? tocustid, [FromUri] long? logID, [FromUri] string interstTYpe, [FromUri] int? empid)
        {
            return this.IEmployeeReport.InsertMatchfollowupExpressinterest(fromcustid, tocustid, logID, interstTYpe, empid);
        }

        //11_10_2017_marketingtcket
        public ArrayList getMarketingtickethistory(int? custid) { return this.IEmployeeReport.Marketingtickethistory(custid); }

        //20_11_2017_Close Reminde Status
        public int? CloseReminderStatus([FromBody]closereminder Mobj) { return this.IEmployeeReport.CloseReminderStatus(Mobj); }

        //21_10_2017_ChangeempPassword
        public int? getChangeEmppassword(string UserID) { return this.IEmployeeReport.ChangeEmppassword(UserID); }

        //23_10_2017_getmatchfolowupticketSp

        public ArrayList getMatchfollowupTicketStatus(long? Ticketid)
        {
            return this.IEmployeeReport.MatchfollowupTicketStatus(Ticketid);
        }

        //27_10_2017_RestoredProfileid in Customer Profile Settings

        public int? RestoredProfileidupdate([FromBody]RestoredProfileid Mobj)
        {
            return this.IEmployeeReport.RestoredProfileidupdate(Mobj);
        }

        public ArrayList KeywordlikeSearchnewpage([FromBody]newkeywordlikesrch Mobj)
        {
            List<newkeywordlikesrch> lstkeyword = new List<newkeywordlikesrch>();
            lstkeyword.Add(Mobj);
            Mobj.dtPartnerPreference = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtlikekeywordsearchnew(), lstkeyword);
            return this.IEmployeeReport.KeywordlikeSearchnewpage(Mobj);
        }

        public ArrayList MasterDataselect([FromBody]MasterData Mobj)
        {
            return this.IEmployeeReport.MasterDataselect(Mobj);
        }

        public int MasterdataInsertUpdate([FromBody]MasterInsertUpdate Mobj)
        {
            return this.IEmployeeReport.MasterdataInsertUpdate(Mobj);
        }

        //04-11-2017 custidbased select for makrting
        public ArrayList getCustomerinfobasedoncustid(string custids, int Empid) { return this.IEmployeeReport.Customerinfobasedoncustid(custids, Empid); }

        //06_11_2017_ update maketing ticket verification
        public int? updatemarketingvrfycation([FromBody]ticketverification Mobj) { return this.IEmployeeReport.updatemarketingvrfycation(Mobj); }

        //10-11-2017 Get Menulist dyanamically
        public ArrayList getEmployeeMenulist(long? Empid) { return this.IEmployeeReport.EmployeeMenulist(Empid); }

        //11_11_2017_UpdateDeleteCustomerdetails

        public int? Updatedeletecustomerdetails([FromBody]updatedeletecustomer Mobj)
        {
            return this.IEmployeeReport.Updatedeletecustomerdetails(Mobj);
        }

        //13_11_2017_New UpdateDeleteCustomerdetails
        public int? Updatedeletecustomerdetails_new([FromBody]updatedeletecustomer Mobj) { return this.IEmployeeReport.Updatedeletecustomerdetails_new(Mobj); }

        //14_11_2017_Employee Permissions

        public ArrayList getEmployeePermissions(int? Empuserid, string Pageid, int? flag)
        {
            return this.IEmployeeReport.EmployeePermissions(Empuserid, Pageid, flag);
        }

        //15_11_2017_Employee Permission insert update
        public int? Updateinsertemployeepermission([FromBody]Employeepermission Mobj)
        {
            List<Employeepermission> permission = new List<Employeepermission>();
            permission.Add(Mobj);
            Mobj.dtPagePermissions = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtemppermission(), permission);
            return this.IEmployeeReport.Updateinsertemployeepermission(Mobj);
        }

        //15_11_2017_Counts Sp

        public ArrayList EmployeeReportsCounts([FromBody]EmpCountsreport Mobj)
        {
            return this.IEmployeeReport.EmployeeReportsCounts(Mobj);
        }

        //16_11_2017_employee bracnchid
        public int? getupdateprofilebranchid(string Profileid) { return this.IEmployeeReport.updateprofilebranchid(Profileid); }

        public int? getinserttorestoretable(long? Profileid)
        {
            return this.IEmployeeReport.inserttorestoretable(Profileid);
        }

        //01_12_2017_Amount deposited in Bank

        public int? InsertamountintoBank([FromBody]bankamount Mobj)
        {
            return this.IEmployeeReport.InsertamountintoBank(Mobj);
        }

        //02_12_2017_New Markting Sp Modification

        public EmployeeMarketingTicketResponse MarketingTicketHistoryInfo_New([FromBody]EmployeeMarketingTketRequestNew Mobj)
        {
            return this.IEmployeeReport.GetMarketingTicketHistoryInfo_New(Mobj);
        }
        //04_12_2017_Employeemenu permissions

        public List<EmployeeUnassignedPages> getdeselectPagePermissions(int? Empid, string Pageid, int? flag)
        {
            return this.IEmployeeReport.deselectPagePermissions(Empid, Pageid, flag);
        }
        //04_12_2017_Employeemenu permissions update

        public ArrayList getdeselectPagePermissionsupdate(int? Empid, string Pageid, int? flag)
        {
            return this.IEmployeeReport.deselectPagePermissionsupdate(Empid, Pageid, flag);
        }
        //05_12_2017_Bankdeposit  Report 
        public ArrayList bankdepositedreport([FromBody]bankamountreport Mobj)
        {
            return this.IEmployeeReport.bankdepositedreport(Mobj);
        }
        //05_12_2017_Banknames
        public ArrayList getbankNamesreport(int? RegionId)
        {
            return this.IEmployeeReport.bankNamesreport(RegionId);
        }
        //07_12_2017_EmployeeDaily Work Report
        public ArrayList employeeDailyworkreport([FromBody]employeeworkreport Mobj)
        {
            return this.IEmployeeReport.employeeDailyworkreport(Mobj);
        }
        //11_12_2017_EmployeeViewfull profile
        public ArrayList getEmployeecustomerprint(string strProfileID, int? intAdminId)
        {
            return this.IEmployeeReport.Employeecustomerprint(strProfileID, intAdminId);
        }

        //20_01_2018 Employee Work grade

        public ArrayList getEmployeeWorkgrade(string EMPID, string dtFromDate, string dtToDate)
        {
            return this.IEmployeeReport.EmployeeWorkgrade(EMPID, dtFromDate, dtToDate);
        }

        //20_01_2018 Employee Work Poor perfarmance

        public ArrayList getEmployeeWorkperformance(string intRegionID)
        {
            return this.IEmployeeReport.EmployeeWorkperformance(intRegionID);
        }

        //29_01_2018 open ticket
        public int? getOpenMatchfollowupticket(Int64? ticketid, string EmpID)
        {
            return this.IEmployeeReport.OpenMatchfollowupticket(ticketid, EmpID);
        }

        //05_02_2017_empsettlement reason
        public ArrayList getSettlementReasonbasedonEmp(string empid)
        {
            return this.IEmployeeReport.SettlementReasonbasedonEmp(empid);
        }
        //13-02_2018_Customer dont show sevice
        public ArrayList getDontshowservice(long cust_id, string toProfileid, int empid, string Relation_type, int flag)
        {
            return this.IEmployeeReport.Dontshowservice(cust_id, toProfileid, empid, Relation_type, flag);
        }

        // 22_02_2017 Employee match followup Newticket Creation

        public ArrayList getNewmatchfollowupticketCreation(long fromcust_id, long tocust_id)
        {
            return this.IEmployeeReport.NewmatchfollowupticketCreation(fromcust_id, tocust_id);
        }

        // 22_02_2017 Employee match followup create reminder  Creation

        public int? getRemindercreation(long fromcust_id, long tocust_id, int? empid, long intTicketID, DateTime? dtRemainderDate)
        {
            return this.IEmployeeReport.Remindercreation(fromcust_id, tocust_id, empid, intTicketID, dtRemainderDate);
        }

        // 23_02_2018 customer partner preference indetailed details
        public int? getPartnerpreference_Indetailedata(long? CustID, string indetaileddesc)
        {
            return this.IEmployeeReport.Partnerpreference_Indetailedata(CustID, indetaileddesc);
        }

        // 07_03_2018 Employee sms 

        public int? Employeesmsformatchfollowup([FromBody]employeesmsmatchfollowup Mobj)
        {
            ServiceSoapClient cc = new ServiceSoapClient();
            string result1 = cc.SendTextSMS("ykrishna", "summary$1", Mobj.Mobilenumber, Mobj.Matchfollouptext, "smscntry");
            return 1;
        }

        public getCustomerinfoKeyword getInfoCustomer(string Profileid)
        {
            return this.IEmployeeReport.InfoCustomer(Profileid);
        }
        public int? sendkeywordsearchemal([FromBody]keywordsearchemail Mobj)
        {
            return this.IEmployeeReport.sendkeywordsearchemal(Mobj);
        }
        public List<getCustomerinfoKeyword> getPhotosOfCustomers(string Profileids)
        {
            return this.IEmployeeReport.PhotosOfCustomers(Profileids);
        }

         // 22_05_2018 UnPaid Matchfollowup slide show

        public ArrayList UnMatchfollowupSlideShowResult([FromBody]SearchML Mobj)
        {
            Mobj.ProfileOwner = Commonclass.getTableData(Mobj.strProfileOwner, "owner");
            Mobj.ProfileOwnerBranch = Commonclass.getTableData(Mobj.strProfileOwnerBranch, "branch");
            Mobj.region = Commonclass.getTableData(Mobj.strregion, "region");
            return this.IEmployeeReport.UnMatchfollowupSlideShowResult(Mobj);
        }

        public int? InsertMonthlyBills([FromBody]insertmonthlybills Mobj)
        {
            return this.IEmployeeReport.InsertMonthlyBills(Mobj);
        }
        public ArrayList PartnerPreferenceEditData([FromBody]employeeEditpartnerInfo Mobj)
        {
            return this.IEmployeeReport.PartnerPreferenceEditData(Mobj);
        }

        public int? PartnerPreferenceModifileddata([FromBody]employeemodifiedpartner Mobj)
        {
            return this.IEmployeeReport.PartnerPreferenceModifileddata(Mobj);
        }

        public ArrayList RegistrationprofilesInformation([FromBody]employeRegistrationInfo Mobj)
        {
            return this.IEmployeeReport.RegistrationprofilesInformation(Mobj);
        }

        public ArrayList getCompareSearchResultsInfo(int? empId)
        {
            return this.IEmployeeReport.CompareSearchResultsInfo(empId);
        }
        public List<slideshowNew> CompareSearchProfiles([FromBody]compareprofiles Mobj)
        {
            return this.IEmployeeReport.CompareSearchProfiles(Mobj.strprofileIDs);
        }


        public ArrayList getKeywordSearchProfileidInfo(string Profileid)
        {
            return this.IEmployeeReport.KeywordSearchProfileidInfo(Profileid);
        }


        public ArrayList getMatchfollowupSelectCounts(int? fromEmpid, int? toEmpid)
        {
            return this.IEmployeeReport.MatchfollowupSelectCounts(fromEmpid, toEmpid);
        }

        public ArrayList getMatchfollowupSelectBasedOnEmp(int? fromEmpid, int? toEmpid,int? Pagefrom,int? pageto)
        {
            return this.IEmployeeReport.MatchfollowupSelectBasedOnEmp(fromEmpid, toEmpid, Pagefrom, pageto);
        }


        public ArrayList MatchfollowupSlideShowResultForwardBackward([FromBody]SearchML Mobj)
        {
            Mobj.ProfileOwner = Commonclass.getTableData(Mobj.strProfileOwner, "owner");
            Mobj.ProfileOwnerBranch = Commonclass.getTableData(Mobj.strProfileOwnerBranch, "branch");
            Mobj.region = Commonclass.getTableData(Mobj.strregion, "region");
            return this.IEmployeeReport.MatchfollowupSlideShowResultForwardBackward(Mobj);
        }




        public ArrayList getfromExpressToExpressStatusEmail(long? Fromcustid, long? ToCustIds)
        {

            return this.IEmployeeReport.fromExpressToExpressStatusEmail(Fromcustid, ToCustIds);
         
        }

        public ArrayList getViewFullProfilePaidUnpaidEmail(long? fromCustId, long? toCustId)
        {
            return this.IEmployeeReport.ViewFullProfilePaidUnpaidEmail(fromCustId, toCustId);
         
        }
        public ArrayList getViewFullProfilePartialInfoEmail(long? fromCustId, long? toCustId)
        {
            return this.IEmployeeReport.ViewFullProfilePartialInfoEmail(fromCustId, toCustId);
        }

        public ArrayList getYesterdayMatchfollowups(int? Empid, int? pagefrom, int? pageto)
        {
            return this.IEmployeeReport.YesterdayMatchfollowups(Empid, pagefrom, pageto);
        }
        // 15_08_2018 
        public ArrayList getEmpdailyReportPendingService(string intRegionID)
        {
            return this.IEmployeeReport.EmpdailyReportPendingService(intRegionID);
        }
        //
        public ArrayList getYesterdayLSTSerives(int? Empid, int? pagefrom, int? pageto)
        {
            return this.IEmployeeReport.YesterdayLSTSerive(Empid, pagefrom, pageto);
        }
        // 16_08_2018 Deleted/settled/Inactive/MMserious/photos upload
        public ArrayList getYesterdaySettledDeletedInActivePhotosUpload(int? Empid)
        {
            return this.IEmployeeReport.YesterdaySettledDeletedInActivePhotosUpload(Empid);
        }

        // 04_09_2018 Unpaid Service Not Updated Tickets
        public EmployeeMarketingTicketResponse UnpaidServiceNotUpdatedTickets([FromBody]unpaidnotupdated Mobj)
        {
            return this.IEmployeeReport.UnpaidServiceNotUpdatedTickets(Mobj);
        }

        // 25_09_2018_emp lst arrival/ departure

        public ArrayList getArrivalDeparturedates()
        {
            return this.IEmployeeReport.ArrivalDeparturedates();
        }


        // 28_09_2018_emp lst arrival/ departure
       
        public int? getInsertSAAmount(int? custid, decimal? saAmount)
        {
            return this.IEmployeeReport.InsertSAAmount(custid, saAmount);
        }

        // 02_10_2018_emp Work pending Report team heads

        public ArrayList EmployeeYesterdayWorkPendingReport([FromBody]ystryPending mobj)
        {
            return this.IEmployeeReport.EmployeeYesterdayWorkPendingReport(mobj);
        }

        // schdulepageinfo

        public ArrayList SchdulepageReport([FromBody]schdulepageinfo mobj)
        {
            return this.IEmployeeReport.SchdulepageReport(mobj);
        }

        // teamheads report

       public ArrayList TeamheadReport([FromBody]Teamheadinfo mobj)
       {
            return this.IEmployeeReport.TeamheadReport(mobj);
       }
       // strickers page report

       public ArrayList StrickersReport([FromBody]strickerspageinfo mobj)
       {
           return this.IEmployeeReport.StrickersReport(mobj);
       }

        //// 

        public ArrayList getYesterday48hoursSerives(int? Empid, int? pagefrom, int? pageto)
        {
            return this.IEmployeeReport.Yesterday48hoursSerives(Empid, pagefrom, pageto);
        }
        // 15_10_2018_new team heads Report
        public ArrayList EmployeeYesterdayWorkPendingReportNew([FromBody]ystryPending mobj)
        {
            return this.IEmployeeReport.EmployeeYesterdayWorkPendingReportNew(mobj);
        }

        // 

        // 19_10_2018_new team heads Report
        public ArrayList getThreeDaysPendingReport(int? Empid, int? pagefrom, int? pageto)
        {
            return this.IEmployeeReport.ThreeDaysPendingReport(Empid, pagefrom, pageto);
        }
        // 20_10_2018_new EmpMatchFollowupandMarketingHistory
      
               public ArrayList EmpMatchFollowupandMarketingHistory([FromBody]employeematchfollowupinfo mobj)
        {
            return this.IEmployeeReport.EmpMatchFollowupandMarketingHistory(mobj);
        }
         // Accountsdetailspage     
               public ArrayList Accountsdetailspage([FromBody]accountspageinfo mobj)
               {
                   return this.IEmployeeReport.Accountsdetailspage(mobj);
               }
         
        // viewdetailspage     
               public ArrayList Viewdetailspage([FromBody]viewpageinfo mobj)
        {
            return this.IEmployeeReport.Viewdetailspage(mobj);
        }

        // 22_10_2018 Matchfollowup New Page
        public ArrayList MatchfollowupSlideShowResult_New([FromBody]SearchML Mobj)
        {
            Mobj.ProfileOwner = Commonclass.getTableData(Mobj.strProfileOwner, "owner");
            Mobj.ProfileOwnerBranch = Commonclass.getTableData(Mobj.strProfileOwnerBranch, "branch");
            Mobj.region = Commonclass.getTableData(Mobj.strregion, "region");
            return this.IEmployeeReport.MatchfollowupSlideShowResult_New(Mobj);
        }
        //22_10_2018_matchfollowupNew Page Counts

        public ArrayList getMatchfollowupCounts(int? intEmpID)
        {
            return this.IEmployeeReport.MatchfollowupCounts(intEmpID);
        }
        //keywordsearch address

       
        // forgat Password New Design


        public int getUserProfileForgotPassword(string userName)
        {
            return this.IEmployeeReport.UserProfileForgotPassword(userName);
        }

        // team lead branch


        public ArrayList getTeamleadBranches(string strvalename,int? strflg)
        {
            return this.IEmployeeReport.TeamleadBranches(strvalename,strflg);
        }

        //  07_12_2018_ kaakateeya agent calling

        public int? KaakateeyaAgentCalling([FromBody]kakagentCall Mobj)
        {
            return this.IEmployeeReport.KaakateeyaAgentCalling(Mobj);
        }
        public int? getProfileStatustoActive(string BrideProfileId, string GroomProfileId)
        {
            return this.IEmployeeReport.ProfileStatustoActive(BrideProfileId, GroomProfileId);
        }

        //////////////29-12-2018

        public int? MarketingMatchfollowupCompare([FromBody]fileuploadexcel obj)
        {
            return this.IEmployeeReport.MarketingMatchfollowupCompare(obj);
        }


        /// <summary>
        /// ////////      05_01_2019 

        /// </summary>
        /// <param name="obj"></param>

        public ArrayList getMarketingTicketHistoryCompareSelect(int? intBranchID, DateTime? dtDateofRecording)
        {
            return this.IEmployeeReport.MarketingTicketHistoryCompareSelect(intBranchID, dtDateofRecording);
        }

        /// <summary>
        /// add address Add keywordsearch.........
        /// </summary>
        /// <param name="CustIDs"></param>
        /// <returns></returns>
        public ArrayList getKeywordSearchAddressPrint(string CustIDs)
        {
            return this.IEmployeeReport.KeywordSearchAddressPrint(CustIDs);
        }
       

    }
}