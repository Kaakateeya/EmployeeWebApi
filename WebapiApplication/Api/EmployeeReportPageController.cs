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

        public List<EmpCommunication> getEmployeeCommunicationLog(string ProfileID, int? intEmpId) { return this.IEmployeeReport.EmployeeCommunicationLog(ProfileID, intEmpId); }
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

    }
}

