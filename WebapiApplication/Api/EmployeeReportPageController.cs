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

        public int getInsertout_incomingcallCommunicationlogData([FromBody]TicketCallHistory Mobj) { return this.IEmployeeReport.Insertout_incomingcallCommunicationlogData(Mobj); }
        public int Insertout_incomingcallData([FromBody]IncomingOutgoing Mobj) { return this.IEmployeeReport.Insertout_incomingcallData(Mobj); }
        public int getReaasignEmployee(long? TicketID, long? AssignedEmpID, long? EmpID, int? StatusID) { return this.IEmployeeReport.ReaasignEmployee(TicketID, AssignedEmpID, EmpID, StatusID); }
        public int getInsertInternalMemo(string Message, long? TicketID, long? EmpID, long? AssignedEmpID) { return this.IEmployeeReport.InsertInternalMemo(Message, TicketID, EmpID, AssignedEmpID); }
        public int getClosedTickets(string ReasonforClose, long? TicketID, long? EmpID) { return this.IEmployeeReport.ClosedTickets(ReasonforClose, TicketID, EmpID); }
        public int getSendNumbersMatchfollowup(long? LFromCustID, long? LToCustID, int? empid, string mailTxt) { return this.IEmployeeReport.SendNumbersMatchfollowup(LFromCustID, LToCustID, empid, mailTxt); }

    }
}

