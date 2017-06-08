using System;
using System.Linq;
using System.Web;
using WebapiApplication.ML;
using WebapiApplication.Interfaces;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Web.Http;
using WebapiApplication.DAL;
using System.Collections.Generic;

namespace WebapiApplication.Implement
{
    public class ImpEmployeeReportPage : IEmployeeReportPage
    {

        public ArrayList MarketingSldeshowshortlistprofiles(string CustID) { return new EmployeeReportPageDAL().MarketingSldeshowshortlistprofiles(CustID, "[dbo].[usp_GetSearchDataForShortlistProfiles_NewDesign]"); }
        public ArrayList MyProfileBindings(string flag, string ID) { return new EmployeeReportPageDAL().MyProfileBindings(flag, ID, "[dbo].[usp_MyProfile_Bindings]"); }
        public ArrayList MyProfileBindingsBranch(string flag, string ID) { return new EmployeeReportPageDAL().MyProfileBindingsBranch(flag, ID, "[dbo].[usp_MyProfile_Bindings]"); }

        public ArrayList MyprofileAllslides(myprofileRequest Mobj) { return new EmployeeReportPageDAL().MyprofileAllslides(Mobj, "[dbo].[usp_get_MyProfile_NewDesign]"); }
        public int SaveViewedBookmark_Customer(CustSearchMl Mobj) { return new EmployeeReportPageDAL().SaveViewedBookmark_Customer(Mobj, "[dbo].[usp_Cust_ProfileMarked_Insert]"); }
        public ArrayList SendServiceProfileIDs(string ProfileIDs) { return new EmployeeReportPageDAL().SendServiceProfileIDs(ProfileIDs, "[dbo].[usp_SendServiceProfileIDs]"); }
        public ArrayList MatchfollowupSlideShowResult(SearchML Mobj) { return new EmployeeReportPageDAL().MatchfollowupSlideShowResult(Mobj, "[dbo].[Usp_Select_BothSideOneSideInterst_New_NewDesign]"); }
        public EmployeeMarketingTicketResponse GetmarketingTicketHistoryInfo(EmployeeMarketingTicketRequest Mobj) { return new EmployeeReportPageDAL().GetmarketingTicketHistoryInfo(Mobj, "[dbo].[usp_GetmarketingTicketHistoryInfo_slide]"); }

        public int MatchFollowupSendSms(EmployeeMarketslidesendmail Mobj) { return new EmployeeReportPageDAL().MatchFollowupSendSms(Mobj, "[dbo].[usp_insert_customerDashboard_SMS]"); }
        public int MatchFollowupMailSend(MatchFollowupMailSend Mobj) { return new EmployeeReportPageDAL().MatchFollowupMailSend(Mobj, "[dbo].[sp_Email_TicketHistoryInfo_slide_New]"); }
        public List<TicketHistoryinfoResponse> MatchFollowupTicketinformation(long? Ticketid, char Type) { return new EmployeeReportPageDAL().MatchFollowupTicketinformation(Ticketid, Type, "[dbo].[Usp_select_MatchFollowupTicketHistory]"); }
        public List<MarketingTicketResponse> MarketingTicketinformation(long? Ticketid, char Type) { return new EmployeeReportPageDAL().MarketingTicketinformation(Ticketid, Type, "[dbo].[usp_GetMarketingTicketHistry_IdBased]"); }

        public int MatchFollowupResendMail(MatchFollowupResendMail Mobj) { return new EmployeeReportPageDAL().MatchFollowupResendMail(Mobj, "[dbo].[sp_Email_singleBothsideinterest]"); }
        public int Insertout_incomingcallCommunicationlogData(TicketCallHistory Mobj) { return new EmployeeReportPageDAL().Insertout_incomingcallCommunicationlogData(Mobj, "[dbo].[Usp_Insert_MatchFollowupTickethistory]"); }
        public int Insertout_incomingcallData(IncomingOutgoing Mobj) { return new EmployeeReportPageDAL().Insertout_incomingcallData(Mobj, "[dbo].[Usp_InsertOut_incomongCall]"); }
        public int ReaasignEmployee(long? TicketID, long? AssignedEmpID, long? EmpID, int? StatusID) { return new EmployeeReportPageDAL().ReaasignEmployee(TicketID, AssignedEmpID, EmpID, StatusID, "[dbo].[usp_ReAssignTicket]"); }
        public int InsertInternalMemo(string Message, long? TicketID, long? EmpID, long? AssignedEmpID) { return new EmployeeReportPageDAL().InsertInternalMemo(Message, TicketID, EmpID, AssignedEmpID, "[dbo].[USP_InsertInternalMemo]"); }
        public int ClosedTickets(string ReasonforClose, long? TicketID, long? EmpID) { return new EmployeeReportPageDAL().ClosedTickets(ReasonforClose, TicketID, EmpID, "[dbo].[Usp_CloseTicketForAssignTickets]"); }
        public int SendNumbersMatchfollowup(long? LFromCustID, long? LToCustID, int? empid, string mailTxt) { return new EmployeeReportPageDAL().SendNumbersMatchfollowup(LFromCustID, LToCustID, empid, mailTxt, "[dbo].[sp_Email_ViewPhoneNumbers]"); }

        // Communication Log  

        public List<EmpCommunication> EmployeeCommunicationLog(string ProfileID, int? intEmpId) { return new EmployeeReportPageDAL().EmployeeCommunicationLog(ProfileID, intEmpId, "[dbo].[Usp_Select_Communicationlog]"); }
        public int EmployeeCommunicationLogSentphotosemail(string Email, string CustID) { return new EmployeeReportPageDAL().EmployeeCommunicationLogSentphotosemail(Email, CustID, "[dbo].[usp_sentemailwithimages_New]"); }
        public Tuple<int, List<CommunicationLogResult>> EmployeeCommunicationLogRvrAndResend(RvrRequest Mobj) { return new EmployeeReportPageDAL().EmployeeCommunicationLogRvrAndResend(Mobj, "[dbo].[Usp_insert_Rvr_Resend_Log]"); }
        public int EmployeeCommunicationLogSendMarketingMail(CreateEmployeeMl Mobj) { return new EmployeeReportPageDAL().EmployeeCommunicationLogSendMarketingMail(Mobj, "[dbo].[sp_Email_TicketHistoryInfo_slide_New]"); }


        // RegistrationValidation

        public List<GetRegprofilevalidation> RegistrationValidation([FromBody]Regprofilevalidation RegValidation) { return new EmployeeReportPageDAL().RegistrationValidation(RegValidation, "[dbo].[Usp_Search_RegistrationBefore]"); }
        public List<RegprofilevalidationPlaybutton> RegistrationValidation_Playbutton(string Profileid) { return new EmployeeReportPageDAL().RegistrationValidation_Playbutton(Profileid, "[dbo].[Usp_GetFullInfoofCustomer]"); }
        public int FeeUpdate(FeeUpdateML mobj) { return new EmployeeReportPageDAL().FeeUpdateDalWithInternalMemoUpdate(mobj, "USP_InsertInternalMemo_Marketingslide"); }

        public int createReminder(CreateReminderMI mobj) { return new EmployeeReportPageDAL().createReminderDal(mobj, "[dbo].[usp_insertCreateReminder_Marketslide]"); }

        public int marketingSendSms(EmployeeMarketslidesendmail Mobj) { return new EmployeeReportPageDAL().marketingSendSmsdal(Mobj, "[dbo].[usp_Marketing_sendSms]"); }

        public int marketingMailSend(MatchFollowupMailSend Mobj) { return new EmployeeReportPageDAL().MatchFollowupMailSend(Mobj, "[dbo].[sp_Email_TicketHistoryInfo_slide]"); }

        public int uploadSettlementForm(uploadFormMl Mobj) { return new EmployeeReportPageDAL().uploadSettlementFormDal(Mobj, "usp_InsertUplaodsettlement"); }


        public Tuple<int?, int?> checkProfileBasedOnsp(string profileID, string sp1, string sp2)
        {
            EmployeeReportPageDAL obj = new EmployeeReportPageDAL();
            int intStatus = 0;
            int profileExistence = obj.checkSettlementProfileID(profileID, sp1, out intStatus);
            int settlementProfileIDExistence = obj.checkSettlementProfileID(profileID, sp2, out intStatus);
            return new Tuple<int?, int?>(profileExistence, settlementProfileIDExistence);
        }


        public Tuple<int?, int?> checkSettlementProfileID(string profileID)
        {
            return checkProfileBasedOnsp(profileID, "usp_SelectProfileID", "usp_existence_profile_Settlement");
        }


        //public Tuple<int?,int?> checkSettlementProfileID(string profileID) {
        //    EmployeeReportPageDAL obj = new EmployeeReportPageDAL();
        //    int intStatus = 0;
        //    int profileExistence = new EmployeeReportPageDAL().checkSettlementProfileID(profileID, "usp_SelectProfileID", out intStatus);
        //    int settlementProfileIDExistence = new EmployeeReportPageDAL().checkSettlementProfileID(profileID, "usp_existence_profile_Settlement", out intStatus);
        //    return new Tuple<int?, int?>(profileExistence, settlementProfileIDExistence);
        //}

        public List<BothsideInterestObjs> ServiceSlideshowdata(Servicesslideslideshowbasedonprofile Mobj)
        {
            return new EmployeeReportPageDAL().ServiceSlideshowdata(Mobj, "usp_select_ServiceSlideshowBasedOnProfileID");
        }


        public Tuple<int?, int?> checkSettlementProfileIDandEmail(string profileID)
        {
            return checkProfileBasedOnsp(profileID, "usp_CheckProfileIDandgetOwnerWhilInsert", "usp_checkprimaryemail");
        }
        public int settledprofilesInsertion(SettledDeletedML mobj)
        {
            return new EmployeeReportPageDAL().settledprofilesInsertionDal(mobj, "usp_InsertSettledMatchesProfiles");
        }
        public int deletedprofilesInsertion(SettledDeletedML mobj)
        {
            return new EmployeeReportPageDAL().deletedprofilesInsertionDal(mobj, "usp_InsertDeletedMatchesProfiles");
        }


    }



}
