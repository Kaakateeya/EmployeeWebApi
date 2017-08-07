using System;
using System.Collections;
using System.Web.Http;
using WebapiApplication.ML;
using WebapiApplication.Implement;
using WebapiApplication.Interfaces;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using WebapiApplication.DAL;
using WebapiApplication.UserDefinedTable;
using System.Data;

namespace WebapiApplication.Api
{
    public class EmployeeReportPageController : ApiController
    {
        private readonly IEmployeeReportPage IEmployeeReport;

        public EmployeeReportPageController() : base() { this.IEmployeeReport = new ImpEmployeeReportPage(); }

        public ArrayList getMarketingSldeshowshortlistprofiles(string CustID) { return this.IEmployeeReport.MarketingSldeshowshortlistprofiles(CustID); }
        public ArrayList getMyProfileBindings(string flag, string ID) { return this.IEmployeeReport.MyProfileBindings(flag, ID); }
        public ArrayList MyprofileAllslides([FromBody]myprofileRequest Mobj) { return this.IEmployeeReport.MyprofileAllslides(Mobj); }
        public int SaveViewedBookmark_Customer([FromBody]CustSearchMl Mobj) { return this.IEmployeeReport.SaveViewedBookmark_Customer(Mobj); }
        public ArrayList getSendServiceProfileIDs(string ProfileIDs) { return this.IEmployeeReport.SendServiceProfileIDs(ProfileIDs); }
        public ArrayList MatchfollowupSlideShowResult([FromBody]SearchML Mobj)
        {
            Mobj.ProfileOwner = Commonclass.getTableData(Mobj.strProfileOwner, "owner");
            Mobj.ProfileOwnerBranch = Commonclass.getTableData(Mobj.strProfileOwnerBranch, "branch");
            Mobj.region = Commonclass.getTableData(Mobj.strregion, "region");
            return this.IEmployeeReport.MatchfollowupSlideShowResult(Mobj);
        }

        public ArrayList getMyProfileBindingsBranch(string flag, string ID) { return this.IEmployeeReport.MyProfileBindingsBranch(flag, ID); }

        public EmployeeMarketingTicketResponse MarketingTicketHistoryInfo([FromBody]EmployeeMarketingTicketRequest Mobj) { return this.IEmployeeReport.GetmarketingTicketHistoryInfo(Mobj); }
        public int MatchFollowupSendSms([FromBody]EmployeeMarketslidesendmail SendSms) { int? inull = null; if (SendSms.i_TicketID != inull && SendSms.i_TicketID != 0) { Commonclass.SendSms_new(SendSms); return this.IEmployeeReport.MatchFollowupSendSms(SendSms); } else { return 1; } }

        public int MatchFollowupMailSend([FromBody] MatchFollowupMailSend SendMail)
        {
            SendMail.AcceptLink = Commonclass.ReturnEncryptLink("Accept", (!string.IsNullOrEmpty(SendMail.FromProfileID) ? SendMail.FromProfileID : null), (!string.IsNullOrEmpty(SendMail.ToProfileID) ? SendMail.ToProfileID : null));
            SendMail.RejectLink = Commonclass.ReturnEncryptLink("Reject", !string.IsNullOrEmpty(SendMail.FromProfileID) ? SendMail.FromProfileID : null, !string.IsNullOrEmpty(SendMail.ToProfileID) ? SendMail.ToProfileID : null);
            return this.IEmployeeReport.MatchFollowupMailSend(SendMail);
        }

        public List<TicketHistoryinfoResponse> getMatchFollowupTicketinformation(long? Ticketid, char Type) { return this.IEmployeeReport.MatchFollowupTicketinformation(Ticketid, Type); }

        public List<MarketingTicketResponse> getMarketingTicketinformation(long? Ticketid, char Type) { return this.IEmployeeReport.MarketingTicketinformation(Ticketid, Type); }

        public int MatchFollowupResendMail([FromBody]MatchFollowupResendMail ResendMail)
        {
            ResendMail.AcceptLink = Commonclass.ReturnEncryptLink("Accept", (!string.IsNullOrEmpty(ResendMail.FromProfileID) ? ResendMail.FromProfileID : null), (!string.IsNullOrEmpty(ResendMail.ToProfileID) ? ResendMail.ToProfileID : null));
            ResendMail.RejectLink = Commonclass.ReturnEncryptLink("Reject", !string.IsNullOrEmpty(ResendMail.FromProfileID) ? ResendMail.FromProfileID : null, !string.IsNullOrEmpty(ResendMail.ToProfileID) ? ResendMail.ToProfileID : null);
            return this.IEmployeeReport.MatchFollowupResendMail(ResendMail);
        }

        public int Insertout_incomingcallCommunicationlogData([FromBody]TicketCallHistory Mobj) { return this.IEmployeeReport.Insertout_incomingcallCommunicationlogData(Mobj); }
        public int Insertout_incomingcallData([FromBody]IncomingOutgoing Mobj) { return this.IEmployeeReport.Insertout_incomingcallData(Mobj); }
        public int getReaasignEmployee(long? TicketID, long? AssignedEmpID, long? EmpID, int? StatusID) { return this.IEmployeeReport.ReaasignEmployee(TicketID, AssignedEmpID, EmpID, StatusID); }
        public int getInsertInternalMemo(string Message, long? TicketID, long? EmpID, long? AssignedEmpID) { return this.IEmployeeReport.InsertInternalMemo(Message, TicketID, EmpID, AssignedEmpID); }
        public int getClosedTickets(string ReasonforClose, long? TicketID, long? EmpID) { return this.IEmployeeReport.ClosedTickets(ReasonforClose, TicketID, EmpID); }
        public int getSendNumbersMatchfollowup(long? LFromCustID, long? LToCustID, int? empid, string mailTxt) { return this.IEmployeeReport.SendNumbersMatchfollowup(LFromCustID, LToCustID, empid, mailTxt); }

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

        public int getEmployeeCommunicationLogSentphotosemail(string Email, string CustID) { return this.IEmployeeReport.EmployeeCommunicationLogSentphotosemail(Email, CustID); }

        public int EmployeeCommunicationLogSendMarketingMail([FromBody]CreateEmployeeMl Mobj)
        {
            Mobj.AcceptLink = Commonclass.ReturnEncryptLink("Accept", (!string.IsNullOrEmpty(Mobj.FromProfileID) ? Mobj.FromProfileID : null), (!string.IsNullOrEmpty(Mobj.ToProfileID) ? Mobj.ToProfileID : null));
            Mobj.RejectLink = Commonclass.ReturnEncryptLink("Reject", !string.IsNullOrEmpty(Mobj.FromProfileID) ? Mobj.FromProfileID : null, !string.IsNullOrEmpty(Mobj.ToProfileID) ? Mobj.ToProfileID : null);
            return this.IEmployeeReport.EmployeeCommunicationLogSendMarketingMail(Mobj);
        }

        // RegistrationValidation

        public List<GetRegprofilevalidation> RegistrationValidation([FromBody]Regprofilevalidation RegValidation) { return this.IEmployeeReport.RegistrationValidation(RegValidation); }
        public List<RegprofilevalidationPlaybutton> getRegistrationValidation_Playbutton(string Profileid) { return this.IEmployeeReport.RegistrationValidation_Playbutton(Profileid); }

        public int FeeUpdate(FeeUpdateML mobj) { return this.IEmployeeReport.FeeUpdate(mobj); }
        public int createReminderInsert(CreateReminderMI mobj) { return this.IEmployeeReport.createReminder(mobj); }

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

        public int uploadSettlementForm(uploadFormMl mobj) { return this.IEmployeeReport.uploadSettlementForm(mobj); }

        public Tuple<int?, int?> getcheckSettlementProfileID(string profileID) { return this.IEmployeeReport.checkSettlementProfileID(profileID); }

        public List<BothsideInterestObjs> ServiceSlideshowdata([FromBody]Servicesslideslideshowbasedonprofile Mobj) { return this.IEmployeeReport.ServiceSlideshowdata(Mobj); }

        public Tuple<int?, int?> getcheckSettlementProfileIDandEmail(string profileID) { return this.IEmployeeReport.checkSettlementProfileIDandEmail(profileID); }

        public int Submitsettledprfiles(SettledDeletedML mobj) { return this.IEmployeeReport.settledprofilesInsertion(mobj); }

        public int Submitdeletedprfiles(SettledDeletedML mobj) { return this.IEmployeeReport.deletedprofilesInsertion(mobj); }
        public ArrayList AssignSettings([FromBody]NoServiceML Mobj) { return this.IEmployeeReport.AssignSettings(Mobj); }

        public ArrayList ReviewpendingReports([FromBody]AssigningProfileML Mobj) { return this.IEmployeeReport.ReviewpendingReports(Mobj); }


        public int? Assignprofiles([FromBody]assignprofiles assign)
        {

            List<assignprofiles> lstPayment = new List<assignprofiles>();
            lstPayment.Add(assign);
            assign.dtTableValues = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtassignsettings(), lstPayment);
            return this.IEmployeeReport.assignprofiles(assign);
        }

        public int? ReviewpendingReassign(Reviewpending mobj) { return this.IEmployeeReport.ReviewpendingReassign(mobj); }

        public ArrayList getDuplicateProfiles(string profileID) { return this.IEmployeeReport.getDuplicateProfiles(profileID); }

        public ArrayList getmmSeriesData(string profileID, int empid) { return this.IEmployeeReport.getmmSeriesData(profileID,empid); }
        public ArrayList Guestticketcreation([FromBody]guestticketcreation Mobj) { return this.IEmployeeReport.Guestticketcreation(Mobj); }


        public int getChangeEmployeePassword(int? EmpID, string EmpoldPassword, string EmpNewPassword) { return this.IEmployeeReport.ChangeEmployeePassword(EmpID, EmpoldPassword, EmpNewPassword); }

        public int getCheckemployeePassord(int? EmpID, string Emppassword) { return this.IEmployeeReport.CheckemployeePassord(EmpID, Emppassword); }

        public int getprofileidexistornot(string profileid) { return this.IEmployeeReport.profileidexistornot(profileid); }
        public ArrayList getpresentunpaidmembers(int? EmpID) { return this.IEmployeeReport.presentunpaidmember(EmpID); }

        public int getUpadteMacAddess(string strProfileID, int? BranchID) { return this.IEmployeeReport.UpadteMacAddess(strProfileID, BranchID); }

        public ArrayList customermeassgeverification([FromBody]messagesverification Mobj) { return this.IEmployeeReport.customermeassgeverification(Mobj); }

        public int updatecustomermessages([FromBody]updatemessagesverification Mobj) { return this.IEmployeeReport.updatecustomermessages(Mobj); }

        public int Editpaymentpointexpdate([FromBody]EditpaymentpointS Mobj) { return this.IEmployeeReport.Editpaymentpointexpdate(Mobj); }

        public ArrayList getPaymentexentionpointsdays(string Profileid) { return this.IEmployeeReport.Paymentexentionpointsdays(Profileid); }


        public ArrayList authorizationpaymentamoutReport([FromBody]authorizationpayment Mobj) { return this.IEmployeeReport.authorizationpaymentamoutReport(Mobj); }

        public int Editpayment([FromBody]employeepaymentedit Mobj) { return this.IEmployeeReport.Editpayment(Mobj); }

        public int InsertEmailBouceEntry([FromBody]insertemailsbounce Mobj) { return this.IEmployeeReport.InsertEmailBouceEntry(Mobj); }

        public int getexistanceprofileornot(string profileid) { return this.IEmployeeReport.existanceprofileornot(profileid); }

        public ArrayList EmplyeepaymentReportspayment([FromBody]paymentreports Mobj) { return this.IEmployeeReport.EmplyeepaymentReportspayment(Mobj); }

        public int getSendMailRegidtrationFeeDetails(Int64? CustID) { return this.IEmployeeReport.SendMailRegidtrationFeeDetails(CustID); }

        public int EmployeepaymentreportsSendsms([FromBody]paymentreportsms Mobj) { return this.IEmployeeReport.EmployeepaymentreportsSendsms(Mobj); }

        public ArrayList getPaymentoffersbasedonselect(string Profileid, int? casteid) { return this.IEmployeeReport.Paymentoffersbasedonselect(Profileid, casteid); }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="Mobj"></param>
       /// <returns></returns>
        public int Editanddeleteupdateoffers([FromBody]paymenteditdelete Mobj) { return this.IEmployeeReport.Editanddeleteupdateoffers(Mobj); }

      
        public int getVerifyProfileid(string profileid) { return this.IEmployeeReport.VerifyProfileid(profileid); }


        public ArrayList CustomerFactsheetDetails(string Profileid) { return this.IEmployeeReport.CustomerFactsheetDetails(Profileid); }
    }
}

