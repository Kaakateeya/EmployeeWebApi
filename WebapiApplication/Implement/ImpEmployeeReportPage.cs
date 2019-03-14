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
        public EmployeeMarketingTicketResponse GetmarketingTicketHistoryInfo(EmployeeMarketingTicketRequest Mobj) { return new EmployeeReportPageDAL().GetmarketingTicketHistoryInfo(Mobj, "[dbo].[usp_GetmarketingTicketHistoryInfo_slide_NewDesign]"); }

        public int MatchFollowupSendSms(EmployeeMarketslidesendmail Mobj) { return new EmployeeReportPageDAL().MatchFollowupSendSms(Mobj, "[dbo].[usp_insert_customerDashboard_SMS]"); }
        public int MatchFollowupMailSend(MatchFollowupMailSend Mobj) { return new EmployeeReportPageDAL().MatchFollowupMailSend(Mobj, "[dbo].[sp_Email_TicketHistoryInfo_slide_New]"); }
        public List<TicketHistoryinfoResponse> MatchFollowupTicketinformation(long? Ticketid, char Type) { return new EmployeeReportPageDAL().MatchFollowupTicketinformation(Ticketid, Type, "[dbo].[Usp_select_MatchFollowupTicketHistory]"); }
        public List<MarketingTicketResponseinfo> MarketingTicketinformation(long? Ticketid, char Type) { return new EmployeeReportPageDAL().MarketingTicketinformation(Ticketid, Type, "[dbo].[usp_GetMarketingTicketHistry_IdBased]"); }

        public List<MarketingTicketResponseHistory> MarketingTickethistory(long? Ticketid, char Type) { return new EmployeeReportPageDAL().MarketingTickethistory(Ticketid, Type, "[dbo].[usp_GetMarketingTicketHistry_IdBased]"); }


        public int MatchFollowupResendMail(MatchFollowupResendMail Mobj) { return new EmployeeReportPageDAL().MatchFollowupResendMail(Mobj, "[dbo].[sp_Email_singleBothsideinterest]"); }
        public int Insertout_incomingcallCommunicationlogData(TicketCallHistory Mobj) { return new EmployeeReportPageDAL().Insertout_incomingcallCommunicationlogData(Mobj, "[dbo].[Usp_Insert_MatchFollowupTickethistory]"); }
        public int Insertout_incomingcallData(IncomingOutgoing Mobj) { return new EmployeeReportPageDAL().Insertout_incomingcallData(Mobj, "[dbo].[Usp_InsertOut_incomongCall]"); }
        public int ReaasignEmployee(long? TicketID, long? AssignedEmpID, long? EmpID, int? StatusID) { return new EmployeeReportPageDAL().ReaasignEmployee(TicketID, AssignedEmpID, EmpID, StatusID, "[dbo].[usp_ReAssignTicket]"); }
        public int InsertInternalMemo(string Message, long? TicketID, long? EmpID, long? AssignedEmpID) { return new EmployeeReportPageDAL().InsertInternalMemo(Message, TicketID, EmpID, AssignedEmpID, "[dbo].[USP_InsertInternalMemo]"); }
        public int ClosedTickets(string ReasonforClose, long? TicketID, long? EmpID) { return new EmployeeReportPageDAL().ClosedTickets(ReasonforClose, TicketID, EmpID, "[dbo].[Usp_CloseTicketForAssignTickets]"); }
        public int SendNumbersMatchfollowup(long? LFromCustID, long? LToCustID, int? empid, string mailTxt) { return new EmployeeReportPageDAL().SendNumbersMatchfollowup(LFromCustID, LToCustID, empid, mailTxt, "[dbo].[sp_Email_ViewPhoneNumbers]"); }

        // Communication Log  

        // public List<EmpCommunication> EmployeeCommunicationLog(string ProfileID, int? intEmpId) { return new EmployeeReportPageDAL().EmployeeCommunicationLog(ProfileID, intEmpId, "[dbo].[Usp_Select_Communicationlog]"); }
        public ArrayList EmployeeCommunicationLog(string ProfileID, int? intEmpId) { return new EmployeeReportPageDAL().EmployeeCommunicationLog(ProfileID, intEmpId, "[dbo].[Usp_Select_Communicationlog]"); }

        public int EmployeeCommunicationLogSentphotosemail(string Email, string CustID) { return new EmployeeReportPageDAL().EmployeeCommunicationLogSentphotosemail(Email, CustID, "[dbo].[usp_sentemailwithimages_New]"); }
        public Tuple<int, List<CommunicationLogResult>> EmployeeCommunicationLogRvrAndResend(RvrRequest Mobj) { return new EmployeeReportPageDAL().EmployeeCommunicationLogRvrAndResend(Mobj, "[dbo].[Usp_insert_Rvr_Resend_Log]"); }
        public int EmployeeCommunicationLogSendMarketingMail(CreateEmployeeMl Mobj) { return new EmployeeReportPageDAL().EmployeeCommunicationLogSendMarketingMail(Mobj, "[dbo].[sp_Email_TicketHistoryInfo_slide_New]"); }


        // RegistrationValidation
        //old sp:[Usp_Search_RegistrationBefore]

        public List<GetRegprofilevalidation> RegistrationValidation([FromBody]Regprofilevalidation RegValidation) { return new EmployeeReportPageDAL().RegistrationValidation(RegValidation, "[dbo].[Usp_Search_RegistrationBefore_Slide]"); }

        public List<GetRegprofilevalidationtable> RegistrationValidation_Table([FromBody]Regprofilevalidation RegValidation) { return new EmployeeReportPageDAL().RegistrationValidation_Table(RegValidation, "[dbo].[Usp_Search_RegistrationBefore_Table]"); }


        public List<GetRegprofilevalidation> RegistrationValidation_Counts([FromBody]Regprofilevalidation RegValidation) { return new EmployeeReportPageDAL().RegistrationValidation_Counts(RegValidation, "[dbo].[Usp_Search_RegistrationBefore_Count]"); }


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
        public ArrayList AssignSettings(NoServiceML Mobj) { return new EmployeeReportPageDAL().AssignSettings(Mobj, "[dbo].[usp_Profile_AssignSettings_NewDesign]"); }

        public ArrayList ReviewpendingReports(AssigningProfileML Mobj) { return new EmployeeReportPageDAL().ReviewpendingReports(Mobj, "[dbo].[uspKakReviewPendingProfiles_NewDesign]"); }

        public int? assignprofiles(assignprofiles assign) { return new EmployeeReportPageDAL().assignprofiles(assign, "[dbo].[usp_Profile_setAssignOwners]"); }


        public int? ReviewpendingReassign(Reviewpending mobj) { return new EmployeeReportPageDAL().ReviewpendingReassign(mobj, "[dbo].[usp_ReviewpendingReassing_Profiles]"); }

        public ArrayList getDuplicateProfiles(string profileID) { return new EmployeeReportPageDAL().getDuplicateProfilesDal(profileID, "[dbo].[Usp_AssignProfile_Similar_Count]"); }
        public ArrayList getmmSeriesData(string profileID, int empid) { return new EmployeeReportPageDAL().getmmSeriesDataDal(profileID, empid, "[dbo].[Usp_EditViewProfileMatchMeeting_Narration]"); }

        public ArrayList Guestticketcreation(guestticketcreation Mobj) { return new EmployeeReportPageDAL().Guestticketcreation(Mobj, "[dbo].[usp_GuestTicketProfileValidation]"); }

        public int ChangeEmployeePassword(int? EmpID, string EmpoldPassword, string EmpNewPassword) { return new EmployeeReportPageDAL().ChangeEmployeePassword(EmpID, Commonclass.Encrypt(EmpoldPassword), Commonclass.Encrypt(EmpNewPassword), "[dbo].[usp_EmployeePasswordChange]"); }


        public int CheckemployeePassord(int? EmpID, string Emppassword) { return new EmployeeReportPageDAL().CheckemployeePassord(EmpID, Commonclass.Encrypt(Emppassword), "[dbo].[usp_checkEmpPassword]"); }

        public int profileidexistornot(string profileid) { return new EmployeeReportPageDAL().profileidexistornot(profileid, "[dbo].[usp_checkprofileidnotexist]"); }

        public ArrayList presentunpaidmember(int? EmpID) { return new EmployeeReportPageDAL().presentunpaidmember(EmpID, "[dbo].[usp_emp_LoginLogoutUnpaidMembers]"); }

        public int UpadteMacAddess(string strProfileID, string ipaddresss2, int? BranchID) { return new EmployeeReportPageDAL().UpadteMacAddess(strProfileID, ipaddresss2, BranchID, "[dbo].[usp_Macipaddressupdate]"); }

        public ArrayList customermeassgeverification([FromBody]messagesverification Mobj) { return new EmployeeReportPageDAL().customermeassgeverification(Mobj, "[dbo].[usp_GetUnAcceptedMessages]"); }

        public int updatecustomermessages([FromBody]updatemessagesverification Mobj) { return new EmployeeReportPageDAL().updatecustomermessages(Mobj, "[dbo].[usp_CustMessageSend]"); }

        public int Editpaymentpointexpdate([FromBody]EditpaymentpointS Mobj) { return new EmployeeReportPageDAL().Editpaymentpointexpdate(Mobj, "[dbo].[Usp_UpdateCheckOutLimits_Manual]"); }


        public ArrayList Paymentexentionpointsdays(string Profileid) { return new EmployeeReportPageDAL().Paymentexentionpointsdays(Profileid, "[dbo].[usp_PaymentManualHistory_Details]"); }

        public ArrayList authorizationpaymentamoutReport([FromBody]authorizationpayment Mobj) { return new EmployeeReportPageDAL().authorizationpaymentamoutReport(Mobj, "[dbo].[usp_Emp_Commission_TicketBased]"); }

        public int Editpayment([FromBody]employeepaymentedit Mobj) { return new EmployeeReportPageDAL().Editpayment(Mobj, "[dbo].[usp_UpdatePaymentDetails]"); }

        public int InsertEmailBouceEntry([FromBody]insertemailsbounce Mobj) { return new EmployeeReportPageDAL().InsertEmailBouceEntry(Mobj, "[dbo].[usp_EmaibounceEntry_Insert]"); }
        public int existanceprofileornot(string profileid) { return new EmployeeReportPageDAL().existanceprofileornot(profileid, "[dbo].[usp_existence_profile_id]"); }

        public ArrayList EmplyeepaymentReportspayment([FromBody]paymentreports Mobj) { return new EmployeeReportPageDAL().EmplyeepaymentReportspayment(Mobj, "[dbo].[usp_Reports_RegistrationFeeDetails_NewDesign]"); }

        public int SendMailRegidtrationFeeDetails(Int64? CustID) { return new EmployeeReportPageDAL().SendMailRegidtrationFeeDetails(CustID, "[dbo].[usp_SendMailToRegidtrationFeeDetailsProfiles]"); }

        public int EmployeepaymentreportsSendsms([FromBody]paymentreportsms Mobj) { return new EmployeeReportPageDAL().EmployeepaymentreportsSendsms(Mobj, "[dbo].[usp_NoServiceSendMessage]"); }

        public ArrayList Paymentoffersbasedonselect(string Profileid, int? casteid) { return new EmployeeReportPageDAL().Paymentoffersbasedonselect(Profileid, casteid, "[dbo].[usp_GetPayment_Offers]"); }

        public int Editanddeleteupdateoffers([FromBody]paymenteditdelete Mobj) { return new EmployeeReportPageDAL().Editanddeleteupdateoffers(Mobj, "[dbo].[usp_GetSet_PaymentMemberships]"); }

        public int VerifyProfileid(string profileid) { return new EmployeeReportPageDAL().VerifyProfileid(profileid, "[dbo].[usp_VerifyCustID]"); }


        public ArrayList CustomerFactsheetDetails(string Profileid) { return new EmployeeReportPageDAL().CustomerFactsheetDetails(Profileid, "[dbo].[usp_CustomerFactSheetDetails_NewDesign]"); }

        public int custmorfactsheetsendMail(string profileid) { return new EmployeeReportPageDAL().custmorfactsheetsendMail(profileid, "[dbo].[Chk_FactsheetsendMail]"); }
        public int? sendEmail_factResetPassword(string profileid, string Encryptedtext) { return new EmployeeReportPageDAL().sendEmail_factResetPassword(profileid, Encryptedtext, "[dbo].[Usp_SENDMAILFORFACTSHEET]"); }
        public int? sendEmail_ResetPassword(string profileid) { return new EmployeeReportPageDAL().sendEmail_ResetPassword(profileid, "[dbo].[Usp_CustResetPasswordFactsheet]"); }

        public int Successstoriesupload([FromBody]emplyeeSuccessStoryML Mobj) { return new EmployeeReportPageDAL().Successstoriesupload(Mobj, "[dbo].[Usp_Successstories]"); }

        public int? Marketingticketstatus(Int64? ticketid, string EmpID) { return new EmployeeReportPageDAL().Marketingticketstatus(ticketid, EmpID, "[dbo].[usp_UpdateTicketStatus]"); }

        public ArrayList AdminReportsAllProfiles(int? i_EmpID, string i_BranchID, int? i_Region, string v_MacAddress, int? flag, string v_ProfileOwnerEmpID) { return new EmployeeReportPageDAL().AdminReportsAllProfiles(i_EmpID, i_BranchID, i_Region, v_MacAddress, flag, v_ProfileOwnerEmpID, "[dbo].[usp_Emp_SchedulerWorkPending]"); }


        public ArrayList CheckSurNameNamedob(string strSurName, string StrName, DateTime? dtDOB) { return new EmployeeReportPageDAL().CheckSurNameNamedob(strSurName, StrName, dtDOB, "[dbo].[usp_CheckSurNameName]"); }

        public int? InsertResonForNoService([FromBody]insetnoserice Mobj) { return new EmployeeReportPageDAL().InsertResonForNoService(Mobj, "[dbo].[usp_Insert_ResonForNoService]"); }

        public ArrayList Nomatchesreasons([FromBody]nomatchesreason Mobj) { return new EmployeeReportPageDAL().Nomatchesreasons(Mobj, "[dbo].[usp_NoMatchmettingreason]"); }


        public ArrayList Oldkmplkeywordlikesearch([FromBody]CreateKeywordLlikesearchReqoldkmpl oldkmpl) { return new EmployeeReportPageDAL().Oldkmplkeywordlikesearch(oldkmpl, "[dbo].[Usp_Search_KeyWord_oldkmpl]"); }

        public List<EmpNotifications> employeenotications([FromBody]EmpNotifications empnotification) { return new EmployeeReportPageDAL().employeenotications(empnotification, "[dbo].[usp_GetNotificationdetails_Emp]"); }

        public int? noserviceemailsfromcustomer(string profileid, int? empid) { return new EmployeeReportPageDAL().noserviceemailsfromcustomer(profileid, empid, "[dbo].[usp_GetUnviewedServiceProfiles]"); }


        public ArrayList keywordlikesearch([FromBody]keywordlikesearch keyword)
        {
            return new EmployeeReportPageDAL().keywordlikesearch(keyword, "[dbo].[Usp_Search_KeyWord_All]");
        }
        public int InsertMatchfollowupExpressinterest([FromUri]int? fromcustid, [FromUri]int? tocustid, [FromUri] long? logID, [FromUri] string interstTYpe, [FromUri] int? empid) { return new EmployeeReportPageDAL().InsertMatchfollowupExpressinterest(fromcustid, tocustid, logID, interstTYpe, empid, "[dbo].[usp_insert_MatchFollupStatusUpdate]"); }

        public ArrayList Marketingtickethistory(int? custid) { return new EmployeeReportPageDAL().Marketingtickethistory(custid, "[dbo].[usp_GetMarketingTicketHistry_CustomerWise]"); }


        public int? CloseReminderStatus([FromBody]closereminder Mobj) { return new EmployeeReportPageDAL().CloseReminderStatus(Mobj, "[dbo].[usp_UpdateReminderStatus]"); }

        public int? ChangeEmppassword(string UserID) { return new EmployeeReportPageDAL().ChangeEmppassword(UserID, "[dbo].[usp_ResetEmployeePASSWORD]"); }

        public ArrayList MatchfollowupTicketStatus(long? Ticketid) { return new EmployeeReportPageDAL().MatchfollowupTicketStatus(Ticketid, "[dbo].[usp_GetMatchFollowupTicketStatus]"); }


        public int? RestoredProfileidupdate([FromBody]RestoredProfileid Mobj) { return new EmployeeReportPageDAL().RestoredProfileidupdate(Mobj, "[dbo].[Usp_InsertRestoreRecord]"); }


        public ArrayList KeywordlikeSearchnewpage([FromBody]newkeywordlikesrch Mobj) { return new EmployeeReportPageDAL().KeywordlikeSearchnewpage(Mobj, "[dbo].[Usp_Search_KeyWord_Single]"); }


        public ArrayList MasterDataselect([FromBody]MasterData Mobj) { return new EmployeeReportPageDAL().MasterDataselect(Mobj, "[dbo].[usp_MasterData_Select]"); }


        public int MasterdataInsertUpdate([FromBody]MasterInsertUpdate Mobj) { return new EmployeeReportPageDAL().MasterdataInsertUpdate(Mobj, "[dbo].[usp_MasterData_InsertUpdate]"); }


        public ArrayList Customerinfobasedoncustid(string custids, int Empid) { return new EmployeeReportPageDAL().Customerinfobasedoncustid(custids, Empid, "[dbo].[usp_GetEmpDetails_Commession]"); }


        public int? updatemarketingvrfycation([FromBody]ticketverification Mobj) { return new EmployeeReportPageDAL().updatemarketingvrfycation(Mobj, "[dbo].[usp_updatemarketingcommission]"); }

        public ArrayList EmployeeMenulist(long? Empid) { return new EmployeeReportPageDAL().EmployeeMenulist(Empid, "[dbo].[usp_Employeemenulist]"); }

        public int? Updatedeletecustomerdetails([FromBody]updatedeletecustomer Mobj) { return new EmployeeReportPageDAL().Updatedeletecustomerdetails(Mobj, "[dbo].[usp_UpdateDeletedMatchesProfiles]"); }


        public int? Updatedeletecustomerdetails_new([FromBody]updatedeletecustomer Mobj) { return new EmployeeReportPageDAL().Updatedeletecustomerdetails_new(Mobj, "[dbo].[usp_UpdateDeletedMatchesProfiles_new]"); }

        public ArrayList EmployeePermissions(int? Empuserid, string Pageid, int? flag) { return new EmployeeReportPageDAL().EmployeePermissions(Empuserid, Pageid, flag, "[dbo].[usp_getPagesForRoles_New]"); }

        public int? Updateinsertemployeepermission([FromBody]Employeepermission Mobj) { return new EmployeeReportPageDAL().Updateinsertemployeepermission(Mobj, "[dbo].[usp_CreatePagePermissionsforEmployee_newpage]"); }

        public ArrayList EmployeeReportsCounts([FromBody]EmpCountsreport Mobj) { return new EmployeeReportPageDAL().EmployeeReportsCounts(Mobj, "[dbo].[usp_Report_Employee_Counts]"); }

        public int? updateprofilebranchid(string Profileid) { return new EmployeeReportPageDAL().updateprofilebranchid(Profileid, "[dbo].[usp_updateprofilebranchid]"); }

        public int? inserttorestoretable(long? Profileid) { return new EmployeeReportPageDAL().inserttorestoretable(Profileid, "[dbo].[usp_emp_InsertintoAllfields_AJS]"); }

        public int? InsertamountintoBank([FromBody]bankamount Mobj) { return new EmployeeReportPageDAL().InsertamountintoBank(Mobj, "[dbo].[USP_EMP_BANKDEPOSIT_AJS]"); }

        public EmployeeMarketingTicketResponse GetMarketingTicketHistoryInfo_New([FromBody]EmployeeMarketingTketRequestNew Mobj) { return new EmployeeReportPageDAL().GetMarketingTicketHistoryInfo_New(Mobj, "[dbo].[usp_GetmarketingTicketHistoryInfo_refactory]"); }

        public List<EmployeeUnassignedPages> deselectPagePermissions(int? Empid, string Pageid, int? flag)
        {
            return new EmployeeReportPageDAL().deselectPagePermissions(Empid, Pageid, flag, "[dbo].[USP_EMP_UNASSIGNEDPAGES_AJS]");
        }

        public ArrayList deselectPagePermissionsupdate(int? Empid, string Pageid, int? flag)
        {
            return new EmployeeReportPageDAL().deselectPagePermissionsupdate(Empid, Pageid, flag, "[dbo].[USP_EMP_UNASSIGNEDPAGES_AJS]");
        }

        public ArrayList bankdepositedreport([FromBody]bankamountreport Mobj)
        {
            return new EmployeeReportPageDAL().bankdepositedreport(Mobj, "[dbo].[USP_EMP_BANKDEPOSITSrpt_AJS]");
        }
        public ArrayList bankNamesreport(int? RegionId)
        {
            return new EmployeeReportPageDAL().bankNamesreport(RegionId, "[dbo].[USP_EMP_GETBANKNAMES_AJS]");
        }
        public ArrayList employeeDailyworkreport([FromBody]employeeworkreport Mobj)
        {
            return new EmployeeReportPageDAL().employeeDailyworkreport(Mobj, "[dbo].[USP_EMP_DAILYREPORTOFWORK_AJS]");
        }
        public ArrayList Employeecustomerprint(string strProfileID, int? intAdminId)
        {
            return new EmployeeReportPageDAL().Employeecustomerprint(strProfileID, intAdminId, "[dbo].[usp_Emp_CustomerPrint_PartialPaid_AJS]");
        }
        public ArrayList EmployeeWorkgrade(string EMPID, string dtFromDate, string dtToDate)
        {
            return new EmployeeReportPageDAL().EmployeeWorkgrade(EMPID, dtFromDate, dtToDate, "[dbo].[USP_EMP_DAILYREPORTOFWORK_DayWise_AJS]");
        }
        public ArrayList EmployeeWorkperformance(string intRegionID)
        {
            return new EmployeeReportPageDAL().EmployeeWorkperformance(intRegionID, "[dbo].[USP_EMP_DAILYREPORTOFWORK_Performance_AJS]");
        }
        public int? OpenMatchfollowupticket(Int64? ticketid, string EmpID)
        {
            return new EmployeeReportPageDAL().OpenMatchfollowupticket(ticketid, EmpID, "[dbo].[usp_Emp_UpdateTicketStatus_Ajs]");
        }

        public ArrayList SettlementReasonbasedonEmp(string empid)
        {
            return new EmployeeReportPageDAL().SettlementReasonbasedonEmp(empid, "[dbo].[usp_emp_getempdetails_ajs]");
        }

        public ArrayList Dontshowservice(long cust_id, string toprofileid, int empid, string Relation_type, int flag)
        {
            return new EmployeeReportPageDAL().Dontshowservice(cust_id, toprofileid, empid, Relation_type, flag, "[dbo].[Usp_Emp_insert_Cust_Dontshowslideshow_Ajs]");
        }

        public ArrayList NewmatchfollowupticketCreation(long fromcust_id, long tocust_id)
        {
            return new EmployeeReportPageDAL().NewmatchfollowupticketCreation(fromcust_id, tocust_id, "[dbo].[Usp_InsertExpressOppMatchFollowup]");
        }
        public int? Remindercreation(long fromcust_id, long tocust_id, int? empid, long intTicketID, DateTime? dtRemainderDate)
        {
            return new EmployeeReportPageDAL().Remindercreation(fromcust_id, tocust_id, empid, intTicketID, dtRemainderDate, "[dbo].[Usp_InsertTicketRemainderCall]");
        }

        public int? Partnerpreference_Indetailedata(long? CustID, string indetaileddesc)
        {
            return new EmployeeReportPageDAL().Partnerpreference_Indetailedata(CustID, indetaileddesc, "[dbo].[Usp_InsertPartnerPrefferIndetaildReq]");
        }
        public getCustomerinfoKeyword InfoCustomer(string Profileid)
        {
            return new EmployeeReportPageDAL().InfoCustomer(Profileid, "[dbo].[usp_Emp_GetProfileInfo]");
        }
        public int? sendkeywordsearchemal([FromBody]keywordsearchemail Mobj)
        {
            return new EmployeeReportPageDAL().sendkeywordsearchemal(Mobj, "[dbo].[sp_email_UnPaidCustService]");
        }

        public List<getCustomerinfoKeyword> PhotosOfCustomers(string Profileids)
        {
            return new EmployeeReportPageDAL().PhotosOfCustomers(Profileids, "[dbo].[usp_Emp_SendProfileInfo_Keyword]");
        }

        public ArrayList UnMatchfollowupSlideShowResult(SearchML Mobj) { return new EmployeeReportPageDAL().UnMatchfollowupSlideShowResult(Mobj, "[dbo].[Usp_Select_BothSideOneSideInterst_New_NewDesign_UnPaid]"); }

        public int? InsertMonthlyBills([FromBody]insertmonthlybills Mobj)
        {
            return new EmployeeReportPageDAL().InsertMonthlyBills(Mobj, "[dbo].[usp_MonthlyPayments]");
        }
        public ArrayList PartnerPreferenceEditData([FromBody]employeeEditpartnerInfo Mobj)
        {
            return new EmployeeReportPageDAL().PartnerPreferenceEditData(Mobj, "[dbo].[usp_cust_GetPartialEditInfor]");
        }
        public int? PartnerPreferenceModifileddata([FromBody]employeemodifiedpartner Mobj)
        {
            return new EmployeeReportPageDAL().PartnerPreferenceModifileddata(Mobj, "[dbo].[usp_cust_UpdatePartialEditInfor]");
        }

        public ArrayList RegistrationprofilesInformation([FromBody]employeRegistrationInfo Mobj)
        {
            return new EmployeeReportPageDAL().RegistrationprofilesInformation(Mobj, "[dbo].[usp_cust_TypesofProfilesReg_AJS]");
        }
        public ArrayList CompareSearchResultsInfo(int? empId)
        {
            return new EmployeeReportPageDAL().CompareSearchResultsInfo(empId, "[dbo].[usp_Emp_CompareSearchInfo_AJS]");
        }
        public List<slideshowNew> CompareSearchProfiles(string strCustIds)
        {
            return new EmployeeReportPageDAL().CompareSearchProfiles(strCustIds, "[dbo].[usp_Emp_CompareSearchProfiles_AJS]");
        }
        public ArrayList KeywordSearchProfileidInfo(string Profileid)
        {
            return new EmployeeReportPageDAL().KeywordSearchProfileidInfo(Profileid, "[dbo].[Usp_Emp_GetFullInfoofCustomer_AJS]");
        }


        public ArrayList MatchfollowupSelectCounts(int? fromEmpid, int? toEmpid)
        {
            return new EmployeeReportPageDAL().MatchfollowupSelectCounts(fromEmpid, toEmpid, "[dbo].[Usp_Select_BothSideOneSideInterst_Count]");
        }
        public ArrayList MatchfollowupSelectBasedOnEmp(int? fromEmpid, int? toEmpid, int? Pagefrom, int? pageto)
        {
            return new EmployeeReportPageDAL().MatchfollowupSelectBasedOnEmp(fromEmpid, toEmpid, Pagefrom, pageto, "[dbo].[Usp_Select_BothSideOneSideInterst_EmpBase]");
        }
        public ArrayList MatchfollowupSlideShowResultForwardBackward(SearchML Mobj) { return new EmployeeReportPageDAL().MatchfollowupSlideShowResultForwardBackward(Mobj, "[dbo].[Usp_Select_BothSideOneSideInterst_ForwardBackward]"); }


        public ArrayList fromExpressToExpressStatusEmail(long? Fromcustid, long? ToCustIds)
        {

            return new EmployeeReportPageDAL().fromExpressToExpressStatusEmail(Fromcustid, ToCustIds, "[dbo].[usp_Cust_GetExpressInterestStatus_AJS]");
        }

        public ArrayList ViewFullProfilePaidUnpaidEmail(long? fromCustId, long? toCustId)
        {
            return new EmployeeReportPageDAL().ViewFullProfilePaidUnpaidEmail(fromCustId, toCustId, "[dbo].[Usp_Cust_GetViewProfile_FullDetails_RoleWise_PaidUnPaid_AJS]");


        }
        public ArrayList ViewFullProfilePartialInfoEmail(long? fromCustId, long? toCustId)
        {
            return new EmployeeReportPageDAL().ViewFullProfilePartialInfoEmail(toCustId, fromCustId, "[dbo].[usp_Cust_GetViewProfile_FullDetails_Partial_AJS]");
        }

        public ArrayList YesterdayMatchfollowups(int? Empid, int? pagefrom, int? pageto)
        {
            return new EmployeeReportPageDAL().YesterdayMatchfollowups(Empid, pagefrom, pageto, "[dbo].[Usp_Emp_YesterDayMatchFollowUpInfo]");

        }
        public ArrayList EmpdailyReportPendingService(string intRegionID)
        {
            return new EmployeeReportPageDAL().EmployeeWorkperformance(intRegionID, "[dbo].[USP_EMP_DAILYREPORTOFWORK_PendingServices_AJS]");
        }

        public ArrayList YesterdayLSTSerive(int? Empid, int? pagefrom, int? pageto)
        {
            return new EmployeeReportPageDAL().YesterdayMatchfollowups(Empid, pagefrom, pageto, "[dbo].[Usp_Emp_YesterDayProcedings_LST]");
        }
        public ArrayList YesterdaySettledDeletedInActivePhotosUpload(int? Empid)
        {
            return new EmployeeReportPageDAL().YesterdaySettledDeletedInActivePhotosUpload(Empid, "[dbo].[Usp_Emp_YesterDayActiviyStatus_AJS]");
        }
        public EmployeeMarketingTicketResponse UnpaidServiceNotUpdatedTickets(unpaidnotupdated Mobj)
        {
            return new EmployeeReportPageDAL().UnpaidServiceNotUpdatedTickets(Mobj, "[dbo].[usp_Emp_UnpaidViewedProfiles_NewDesign]");
        }

        public ArrayList ArrivalDeparturedates()
        {
            return new EmployeeReportPageDAL().ArrivalDeparturedates("[dbo].[usp_emp_ArrivalDepature]");

        }
        public int? InsertSAAmount(int? custid, decimal? saAmount)
        {
            return new EmployeeReportPageDAL().InsertSAAmount(custid, saAmount, "[dbo].[usp_Emp_UpdateSettleAmt]");
        }

        public ArrayList EmployeeYesterdayWorkPendingReport([FromBody]ystryPending mobj)
        {
            return new EmployeeReportPageDAL().EmployeeYesterdayWorkPendingReport(mobj, "[dbo].[usp_Emp_YesterdayPendingworkbyEmp_AJS]");

        }

        // schdulepageinfo

        public ArrayList SchdulepageReport([FromBody]schdulepageinfo mobj)
        {
            return new EmployeeReportPageDAL().SchdulepageReport(mobj, "[dbo].[usp_UpdateDisplayScdularReport_AJS]");

        }
        // teamheadinfo

        public ArrayList TeamheadReport(Teamheadinfo mobj)
        {
            return new EmployeeReportPageDAL().TeamheadReport(mobj,"[dbo].[usp_Emp_TeamLeadAllDetails_NewDesign]");

        }
        // teamheadinfoend
        // strickerspage start
        public ArrayList StrickersReport(strickerspageinfo mobj)
        {
            return new EmployeeReportPageDAL().StrickersReport(mobj, "[dbo].[Usp_Stickers_Print_AJS]");
        }
        // strickerspage end

        public ArrayList Yesterday48hoursSerives(int? Empid, int? pagefrom, int? pageto)
        {
            return new EmployeeReportPageDAL().Yesterday48hoursSerives(Empid, pagefrom, pageto, "[dbo].[Usp_Emp_YesterDay48HoursNoUpdateInfo]");
        }

        public ArrayList EmployeeYesterdayWorkPendingReportNew([FromBody]ystryPending mobj)
        {
            return new EmployeeReportPageDAL().EmployeeYesterdayWorkPendingReport(mobj, "[dbo].[usp_Emp_YesterdayPendingworkbyEmp_Analysis_AJS]");

        }
        public ArrayList ThreeDaysPendingReport(int? Empid, int? pagefrom, int? pageto)
        {
            return new EmployeeReportPageDAL().Yesterday48hoursSerives(Empid, pagefrom, pageto, "[dbo].[Usp_Emp_YesterDayMatchFollowUpInfo_3Days]");
        }
        //EmpMatchFollowupandMarketingHistory
     
        public ArrayList EmpMatchFollowupandMarketingHistory([FromBody]employeematchfollowupinfo mobj)
        {
            return new EmployeeReportPageDAL().EmpMatchFollowupandMarketingHistory(mobj, "[dbo].[usp_Emp_MatchFollowupandMarketingHistory_AJS]");

        }
        
        // Accountsdetailspage  
        public ArrayList Accountsdetailspage([FromBody]accountspageinfo mobj)
        {
            return new EmployeeReportPageDAL().Accountsdetailspage(mobj, "[dbo].[usp_InsertAccountDetails_Report_AJS]");

        }

        // viewdetailspage  
        public ArrayList Viewdetailspage([FromBody]viewpageinfo mobj)
        {
            return new EmployeeReportPageDAL().Viewdetailspage(mobj, "[dbo].[usp_InsertAccountDetails_Report_AJS]");

        }

        public ArrayList MatchfollowupSlideShowResult_New([FromBody]SearchML Mobj)
        {
            return new EmployeeReportPageDAL().MatchfollowupSlideShowResult_New(Mobj, "[dbo].[Usp_Select_OneSideInterst_MySide_NewDesign]");
        }


        public ArrayList MatchfollowupCounts(int? intEmpID)
        {
            return new EmployeeReportPageDAL().MatchfollowupCounts(intEmpID, "[dbo].[Usp_Select_EmpMatchFollowup_Count]");
        }
        //
        public ArrayList Keywordsearchaddress(string CustIDs)
        {
            return new EmployeeReportPageDAL().Keywordsearchaddress(CustIDs, "[dbo].[Usp_KeywordsearchAddress]");
        }
        //
        public int UserProfileForgotPassword(string userName)
        {
            return new EmployeeReportPageDAL().UserProfileForgotPassword(userName, "[dbo].[Usp_Cust_ResetForgotPassword_AJS]");
        }
        public ArrayList TeamleadBranches(string strvalename, int? strflg)
        {
            return new EmployeeReportPageDAL().TeamleadBranches(strvalename, strflg, "[dbo].[Dropdown_filling_TeamHeadsandBranches]");
        }
        public int? KaakateeyaAgentCalling([FromBody]kakagentCall Mobj)
        {
            return new EmployeeReportPageDAL().KaakateeyaAgentCalling(Mobj, "[dbo].[usp_insert_kakAgentCallingHistory]");
        }
        public int? ProfileStatustoActive(string BrideProfileId, string GroomProfileId)
        {
            return new EmployeeReportPageDAL().ProfileStatustoActive(BrideProfileId, GroomProfileId, "[dbo].[usp_update_ProfileidStatustoActive_AJS]");
        }
        public int? MarketingMatchfollowupCompare([FromBody]fileuploadexcel obj)
        {
            return new EmployeeReportPageDAL().MarketingMatchfollowupCompare(obj, "[dbo].[Usp_Emp_InsertVoiceRecordinginfo]");
        }
        public ArrayList MarketingTicketHistoryCompareSelect(int? intBranchID, DateTime? dtDateofRecording)
        {
            return new EmployeeReportPageDAL().MarketingTicketHistoryCompareSelect(intBranchID, dtDateofRecording, "[dbo].[usp_Emp_TicketsandMatchFollowupswithRecoring]");
        }
    }

}
