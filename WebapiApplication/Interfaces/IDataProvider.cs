using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebapiApplication.ML;
using System.Collections;
using System.Data;

namespace WebapiApplication.Interfaces
{
    public interface IActivePatientCondition { List<ActivePatientConditionReport> DisplayMovieList();    }
    public interface IIActivePatientCondition { List<ActivePatientReport> GetCodeSetPrograms();    }
    public interface IuserLogin
    {
        List<userLoginML> DGetLogininformationdetails(CustLoginMl Mobj);
        Tuple<EmpDetailsMl, List<MenuItem>, List<ScrollText>, List<StarRating>, int> ValidateLoginNew(string p1, string p2, string sMAC);
    }

    public interface IDashboardRequest
    {
        DashboardClass GetLandingCountsBal(int? CustID, string TypeOfReport, int pagefrom, int pageto, string DashboardType);
        DashboardClass GetPartnerProfilesBal(int? CustID, string TypeOfReport, int pagefrom, int pageto, string DashboardType);
        List<PartnerProfilesLatest> ExpressInterestSelectBal(DashboardRequest dreq);
        List<DashboardRequestChats> CustometExpressIntrestDashBoardchats(long? CustID, int? Status, int iStartIndex, int iEndIndex);
        List<TicketHistoryinfoResponse> GetTicketinformationDal(long? Ticketid, char Type);
        List<CommunicationHistry> GetCustometMessagesCount(CommunicationHistoryReq Mobj);
        int InsertExpressViewTicket(long? FromCustID, long? ToCustID, string EncriptedText, string strtypeOfReport);
        int InsertCustomerExpressinterest(int? fromcustid, int? tocustid, long? logID, string interstTYpe, int? empid);
    }

    public interface IEmailMobileVerf { VerifiedContactInformationML DgetMobileEmailVerification(long? CustID); }
    public interface ICustSearchService { int CustomerServiceDal(CustSearchMl MobjViewprofile);  }
    public interface IPayment
    {
        List<Paymentselect> GetPaymentDetails(long? CustID);
        string CustomerPaymentStatus(long? CustomerCustID);
        int InsertPaymentDetails(PaymentMasterMl Mobj);
        ArrayList ProfilePaymentDetails(long? intProfileID, int? Isonline, int? flag, int? intMembershipID, string taxpaid);
        int CustomerInsertPaymentDetilsInfo(CustomerPaymentML Mobj);
        int CustomerInsertPaymentDetilsInfo_NewDesign(PaymentInsertML Mobj);
        ArrayList ProfilePaymentDetails_Gridview(string intProfileID);
        ArrayList DgetProfilePaymentDetails_NewDesigns(string intProfileID, int intPaymentHistID);

        int setPaymentAuthorization(DataTable mobj);
    }

    public interface ICustomerSearch
    {
        PrimaryInformationMl Partnerpreferencedetails_CustomerSearch(int? CustID, int? EmpID, Int64? searchresultID);
        List<QuicksearchResultML> ProfileIdsearch(ProfileIDSearch ProfileIDSearch);
        List<QuicksearchResultML> GeneralandAdvancedSearch(PrimaryInformationMl search);
        List<QuicksearchResultML> CustomerAdvanceGeneralandSavedSearch(PrimaryInformationMl primaryInfo, DataTable dtTableValues);
        List<QuicksearchResultML> CustomerProfileIDSavedSearch(ProfileIDSearch primaryInfo, DataTable dtTableValues);
        List<SearchResultSaveEditML> SearchResultSaveEdit(long? Cust_ID, string SaveSearchName, int? iEditDelete);
        List<QuicksearchResultML> CustomerHomePageSearch(CustomerHomePageSearch search);
        GetPrimaryDataCustomerResponse PrimaryCustomerDataResponse(int? CustID, int? EmpID, int? SearchType);
        List<slideshowNew> ShowDataForEmployeeGeneral(EmployeeSearch employeesearch);
        List<slideshowNew> ShowDataForEmployeeAdvanceSearch(EmployeeSearch employeesearch);


        List<slideshowNew> ShowDataForEmployeeGeneral_Nocastebar(EmployeeSearch employeesearch);

        List<slideshowNew> ShowDataForEmployeeAdvanceSearch_Nocastebar(EmployeeSearch employeesearch);
    }
    public interface ICustomerPersonaldetails
    {
        CustomerPersonalDetails getpersonalMenuDetails(string CustID);
        ArrayList getCustomerEducationdetails(long? CustID);
        ArrayList getUpdateProfessionDetails(long? CustID);
        ArrayList getParentDetailsDisplay(long? CustID);
        ArrayList getCustomerpartnerpreferencesDetailsDisplay(long? CustID);
        ArrayList getsiblingsDetailsDisplay(long? CustID);
        ArrayList getAstroDetailsDisplay(long? CustID);
        ArrayList getPropertyDetailsDisplay(long? CustID);
        ArrayList getRelativeDetailsDisplay(long? CustID);
        ArrayList getReferenceViewDetailsDisplay(long? CustID);
        ArrayList GetphotosofCustomer(string Custid, int? EmpID);
        ArrayList getCustomerPersonalMenu(long? CustID, int? iReview, string SectionID);
        ArrayList getCustomerPersonalSpouse_Details(long? CustID);
        ArrayList getCustomerPersonalContact_Details(long? CustID);
        ArrayList getCustomerPersonaloffice_purpose(string flag, string ID, string AboutProfile, int? IsConfidential, int? HighConfendential);
        ArrayList CustomerprofilesettingDetails(long? CustID);
        string getDiscribeYour(string CustID, string AboutYourself, int? flag, string spName);
        ArrayList personaldetails_Customer(long? CustID);
        ArrayList ViewAllCustomersSearch(int? intEmpID, string SearchData, string profileStatus, int? StartIndex, int? EndIndex);

        ArrayList ViewAllCustomersKMPLProfileID(int? EmpID, string SearchData);
        int CustomerphotoRequestDisplay(string profileid, int? EMPID, long? ticketIDs);
        ArrayList CandidateContactdetailsRelationName(long? CustID, int? PrimaryMobileRel, int? PrimaryEmailRel, int? iflage);
        int CandidateContactsendmailtoemailverify(long? CustID);
        ArrayList ProfileIDPlaybutton(string ProfileID);
        ArrayList ViewAllCustomersSettledeleteinfo(string CustID, string typeofdata);
        ArrayList Search_ViewEditProfile(ViewEditProfileSearch Mobj);

        ArrayList getNoPhotoStatus(long custid);
    }
    public interface ICustomerPersonaldetailsUpdate
    {
        int getEducationdetails_Updatecustomer(UpdatePersonaldetails MobjEdudetails);
        int getProfessionDetails_Customer(UpdatePersonaldetails MobjProf);
        int CustomerParentUpdatedetails(UpdatePersonaldetails MobjProf);
        int CustomerContactAddressUpdatedetails(UpdatePersonaldetails MobjProf);
        int CustomerPhysicalAttributesUpdatedetails(UpdatePersonaldetails MobjProf);
        int CustomerPartnerPreferencesUpdatedetails(UpdatePersonaldetails MobjProf);
        int CustomerSibBrotherUpdatedetails(UpdatePersonaldetails MobjProf);
        int CustomerSibSisterUpdatedetails(UpdatePersonaldetails MobjProf);
        int CustomerAstrodetailsUpdatedetails(UpdatePersonaldetails MobjProf);
        int CustomerPropertyUpdatedetails(UpdatePersonaldetails MobjProf);
        int CustomerFathersBrotherUpdatedetails(UpdatePersonaldetails MobjProf);
        int CustomerFathersSisterUpdatedetails(UpdatePersonaldetails MobjProf);
        int CustomerMotherBrotherUpdatedetails(UpdatePersonaldetails MobjProf);
        int CustomerMotherSisterUpdatedetails(UpdatePersonaldetails MobjProf);
        int CustomerReferencedetailsUpdatedetails(UpdatePersonaldetails MobjProf);
        int UpdateSibblingCounts(SibblingCounts sibcount);
        ArrayList Savephotosofcustomer(UpdatePersonaldetails updatePic);
        int PhotoPassword(long? CustID, int? ipassword);
        int AstroDetailsUpdateDelete(AstroUploadDelete astroupdate);
        int UpdateSpoucedetails_Customersetails(UpdatePersonaldetails customerpersonaldetails);
        int UpdateSpouseChildDetails(UpdatePersonaldetails customerpersonaldetails);
        HoroGeneration GenerateHoroscorpe(int? customerid, string EmpIDQueryString, int? intDay, int? intMonth, int? intYear, int? CityID);
        ArrayList Emplanding_counts_Admin(EmployeeLandingCount ecount);
        int CustomerContactDetails_Update(ContactDetals Mobj);

        int CustomerProfileSetting_ProfileSetting(UpdateprofileeMl Mobj);
        int CustomerProfileSetting_Gradeselection(NoProfileGradingMl Mobj);
        int UpdatePersonalDetails_Customersetails(UpdatePersonaldetails customerpersonaldetails);
        int CustomerSectionsDeletions(string sectioname, long? CustID, long? identityid);
        NoDataFoundDisplay NoDataInformationLinkDisplay(string ProfileID);
        int UpdateContactdetails_Reference(ContactdetailsRef Mobj);
        int UploadsettlementForm(SettlementPaidBalanceDetailsMl settlementForm);

        int AstroGenerationS3Update(string Path, string KeyName);

        ArrayList Emplanding_counts_TablesDisplay(EmployeeLandingCount ecount);
    }
    public interface IStaticPages
    {

        List<Sucessstories> getSucessstoriesdetails(SuccessStoryML SML);
        int CustomerRating_sendMail(CustFeebBackML Mobj);
        List<KaakateeyaBranchesML> ImpgetKaakateeyaBranchesDetails(string dependencyName, string dependencyValue, string dependencyflagID);
        int ImpSendTicketMail(HelpMail Mobj);
        HelpMail ImpInsertTicketInfo(TicketCreationMl Mobj);
        ArrayList CustomerViewfullProfileDetails(long? ProfileID, int? CustID, int? RelationshipID);
        ArrayList GetExpressinterstBookmarkIgnore(long? loggedcustid, long? ToCustID);
        int SendMail_PhotoRequest_Customer(string FromCustID, string ToCustID, int? Category);
        int getprofileGrade(string CustID);
        List<PhotoPathDisplay> GetPhotoSlideImages(string CustID);
        int PhotopasswordAcceptReject(Int64? FromcustID, Int64? TocustID, Int64? Accept_Reject);
        List<ProfileSettings> customerProfilesettings(Int64? CustID);
        int InsertcustomerProfilesettings(DateTime? Expirydate, int? CustID, int? iflag);
        int DeletecustomerProfilesettings(Int64? ProfileID, string Narrtion);
        int UpdatePassword(string OldPassword, string NewPassword, string ConfirmPassword, string custId);
        int ProfilesettingEmailMobileChange(Int64? FamilyID, string MobileEmail, int? CountryCodeID, int? imobileEmailflag);
        int ProfilesettingAllowEmailAllowSMS(long? CustID, int? AllowEmail, int? AllowSMS);
        int EmailMobilenumberexists(int? iflagEmailmobile, string EmailMobile);
        void ApplicationErrorLog(string ErrorSpName, string ErrorMessage, long? CustID, string PageName, string Type);
        ArrayList paymentdetailsmethoddal(Int64? CustID);
        ArrayList GetTicketDetails(TicketDetails ticketdetails);
        int CustomerReopenTicketStatus(int? PageID, int? ProfileID, int? TicketID);
        int ForgotPassword(string Username);
        int ConfirmUserEmail(string VerificationCode);
        int CreateNewPassword(Int64? intCusID, string strPassword);
        string EmilVerificationCode(string VerificationCode, int? i_EmilMobileVerification, int? CustContactNumbersID, int? IsVerified);
        DataTable UnpaidMembersOwner_Notification(int? CategoryID, int? Cust_ID);
        int ResendEmailVerficationLink(long? CustID);
        int MissingFieldsupdate_Customerdetails(MissingFieldsUpdateRequest Mobj);
        ArrayList displayMissingFieldsupdate_Customerdetails(string CustID, int? i_updateflag);
        string Customerfilldata(long? CustomerCustID);
        int InsertUnpaidStatus(string fromCustID, string ToCustID, int? Empid, string typeofAction);
        int InsertExpressViewTicket(long? FromCustID, long? ToCustID, string p, string strtypeOfReport);
        ViewfullProfileML ViewFullProfileMail(string OriginalString);
        ArrayList ExpressIntrstfullprofile(string FromProfileID, int? EmpID);
        ArrayList Expressinterst_bookmark_ignore_data(long? Loggedcustid, long? ToCustID);
        int UpdateExpressIntrestViewfullprofile(UpdateExpressIntrestStatus Mobj);
        ArrayList Cust_NotificationDetails(int? Cust_NotificationID, long? CustID, int? Startindex, int? EndIndex);
        ArrayList CheckForgotPasswordStatus(string StrCustID);
        int ChangePassword(string StrCustID, string Password);
        ArrayList CustShortlistProfile(string CustID);
        ArrayList CustomerViewAdminFullDetails(string ProfileID, int? EmpID);
        ArrayList EmployeeLoginCoutDetails();
        string ipAddressReturn();
        ArrayList Cust_NotificationDetails_Employee(int? EmpID, int? idisplay, int? NotificationID, int? CategoryID, int? CustID);
        int Update_EmailBounce(long? CustID, int? EmailBounceEntryId, string BounceMailid);


        int getChangeApplicationStaus(long? ProfileID);


        ArrayList CustomerHomePageDesignData(string flag, int? casteID, long? CustID, int? intStartIndex, int? intEndIndex, int? GenderID, int? isActive);

        Tuple<string, int> ViewSettlementform(string Profileid);

        int CheckprofileIDSelect(string Profileid);


        int CustomerPaymentOffersAssign(CustomerPaymentOffers Customerpayoffers);

        int CustomerProfileIDstatus(string ProfileID);

        ArrayList CustomerParofileIDbasePayment(string ProfileID, int? BranchID);

        ArrayList CustomerUnauthorizedPayments(string BranchID, string StartDate, string EndDate, string Region, string strProfileID);


        ViewProfileInputInbit InbitdataInfo(string ProfileID, int? empid);

        NoDataFoundDisplay NoDataFoundDisplay(string ProfileID);

        int brokerEmailMobilenumberexists(int? iflagEmailmobile, string EmailMobile);
    }
    public interface IDependency
    {
        List<CountryDependency> getCountryDependency(string dependencyName, string dependencyValue, string spname);
        List<CountryDependency> getCountryDependencyCountryCode(string dependencyName, string dependencyValue, string spname);

        List<CountryDependency> getDropdown_filling_values(string strDropdownname);
        List<CountryDependency> ImpgetDropdownValues_dependency_injection(string dependencyName, string dependencyValue, string dependencyflagID);
    }
    public interface IRegistration
    {
        int? RegisterCustomerHomepages(PrimaryInformationMl Mobj);
        int CustomerRegProfileDetails_Myprofile(UpdatePersonaldetails Mobj);
        ArrayList CustomermissindDatagetting(long? CustomerCustID);
        string BgetPassword(string Username);
        ArrayList DGetloginCustinformation(string Username, string Password, int? iflag);
        int CheckUserPwd(string Username, string Password);
        ArrayList EmployeeRegisterCustomerHomepages(PrimaryInformationMl CustomerHome);
        int UpdateEmplogintoCustomersite(int empid, string ProfileID, string Narration);

        ArrayList EmployeeRegisterCustomerHomepagesBrokerProfiles(PrimaryInformationMl CustomerHome);
    }

    public interface IExpressInterest
    {
        ArrayList ExpressInterest_linq(string flag, string ID, string RelationShipID);
        ArrayList MatchFollowup_linq(string flag, string ID, string RelationShipID);
        Tuple<List<Smtpemailsending>, int?> ExpressInterest(ExpressInterestInsert EXI);
    
        
        ArrayList ExpressInterest_SendSms(string FromProfileID, string ToProfileIDs);

        Servicedates getServiceInfo(string FromProfileID, string ToProfileID);

        DataSet ExpressInterest_sendmultimails(ExpressInterestInsert EXI);
    }
    public interface IEmployeeReportPage
    {

        ArrayList MarketingSldeshowshortlistprofiles(string CustID);
        ArrayList MyProfileBindings(string flag, string ID);
        ArrayList MyprofileAllslides(myprofileRequest Mobj);
        int SaveViewedBookmark_Customer(CustSearchMl Mobj);
        ArrayList SendServiceProfileIDs(string ProfileIDs);
        ArrayList MatchfollowupSlideShowResult(SearchML Mobj);
        EmployeeMarketingTicketResponse GetmarketingTicketHistoryInfo(EmployeeMarketingTicketRequest Mobj);

        int MatchFollowupSendSms(EmployeeMarketslidesendmail Mobj);
        int MatchFollowupMailSend(MatchFollowupMailSend Mobj);
        List<TicketHistoryinfoResponse> MatchFollowupTicketinformation(long? Ticketid, char Type);
        List<MarketingTicketResponseinfo> MarketingTicketinformation(long? Ticketid, char Type);
        int MatchFollowupResendMail(MatchFollowupResendMail Mobj);
        int Insertout_incomingcallCommunicationlogData(TicketCallHistory Mobj);

        int Insertout_incomingcallData(IncomingOutgoing Mobj);
        int ReaasignEmployee(long? TicketID, long? AssignedEmpID, long? EmpID, int? StatusID);
        int InsertInternalMemo(string Message, long? TicketID, long? EmpID, long? AssignedEmpID);
        int ClosedTickets(string ReasonforClose, long? TicketID, long? EmpID);
        int SendNumbersMatchfollowup(long? LFromCustID, long? LToCustID, int? empid, string mailTxt);
        ArrayList MyProfileBindingsBranch(string flag, string ID);

        //  List<EmpCommunication> EmployeeCommunicationLog(string ProfileID, int? intEmpId);
        ArrayList EmployeeCommunicationLog(string ProfileID, int? intEmpId);
        List<GetRegprofilevalidation> RegistrationValidation(Regprofilevalidation RegValidation);

        int EmployeeCommunicationLogSentphotosemail(string Email, string CustID);
        Tuple<int, List<CommunicationLogResult>> EmployeeCommunicationLogRvrAndResend(RvrRequest Mobj);
        List<RegprofilevalidationPlaybutton> RegistrationValidation_Playbutton(string Profileid);
        int EmployeeCommunicationLogSendMarketingMail(CreateEmployeeMl Mobj);

        int FeeUpdate(FeeUpdateML Mobj);
        int createReminder(CreateReminderMI Mobj);

        int marketingSendSms(EmployeeMarketslidesendmail SendSms);

        int marketingMailSend(MatchFollowupMailSend SendMail);



        int uploadSettlementForm(uploadFormMl mobj);

        Tuple<int?, int?> checkSettlementProfileID(string profileID);

        List<BothsideInterestObjs> ServiceSlideshowdata(Servicesslideslideshowbasedonprofile Mobj);

        Tuple<int?, int?> checkSettlementProfileIDandEmail(string profileID);

        int settledprofilesInsertion(SettledDeletedML mobj);

        int deletedprofilesInsertion(SettledDeletedML mobj);

        ArrayList AssignSettings(NoServiceML Mobj);

        ArrayList ReviewpendingReports(AssigningProfileML Mobj);

        int? assignprofiles(assignprofiles employeesearch);

        int? ReviewpendingReassign(Reviewpending mobj);

        ArrayList getDuplicateProfiles(string profileID);

        ArrayList getmmSeriesData(string profileID, int empid);
        ArrayList Guestticketcreation(guestticketcreation Mobj);

        int ChangeEmployeePassword(int? EmpID, string EmpoldPassword, string EmpNewPassword);

        int CheckemployeePassord(int? EmpID, string Emppassword);

        int profileidexistornot(string profileid);

        ArrayList presentunpaidmember(int? EmpID);

        int UpadteMacAddess(string strProfileID, string ipaddresss2, int? BranchID);

        ArrayList customermeassgeverification(messagesverification Mobj);

        int updatecustomermessages(updatemessagesverification Mobj);

        int Editpaymentpointexpdate(EditpaymentpointS Mobj);

        ArrayList Paymentexentionpointsdays(string Profileid);

        ArrayList authorizationpaymentamoutReport(authorizationpayment Mobj);

        int Editpayment(employeepaymentedit Mobj);

        int InsertEmailBouceEntry(insertemailsbounce Mobj);

        int existanceprofileornot(string profileid);

        ArrayList EmplyeepaymentReportspayment(paymentreports Mobj);



        int SendMailRegidtrationFeeDetails(long? CustID);

        int EmployeepaymentreportsSendsms(paymentreportsms Mobj);

        ArrayList Paymentoffersbasedonselect(string Profileid, int? casteid);

        int Editanddeleteupdateoffers(paymenteditdelete Mobj);

        int VerifyProfileid(string profileid);

        ArrayList CustomerFactsheetDetails(string Profileid);

        int custmorfactsheetsendMail(string profileid);


        int? sendEmail_factResetPassword(string profileid, string p);

        int? sendEmail_ResetPassword(string profileid);

        int Successstoriesupload(emplyeeSuccessStoryML Mobj);

        int? Marketingticketstatus(long? ticketid, string EmpID);

        ArrayList AdminReportsAllProfiles(int? i_EmpID, string i_BranchID, int? i_Region, string v_MacAddress, int? flag, string v_ProfileOwnerEmpID);

        ArrayList CheckSurNameNamedob(string strSurName, string StrName, DateTime? dtDOB);

        int? InsertResonForNoService(insetnoserice Mobj);

        ArrayList Oldkmplkeywordlikesearch(CreateKeywordLlikesearchReqoldkmpl oldkmpl);

        ArrayList Nomatchesreasons(nomatchesreason Mobj);

        List<GetRegprofilevalidationtable> RegistrationValidation_Table(Regprofilevalidation RegValidation);

        List<MarketingTicketResponseHistory> MarketingTickethistory(long? Ticketid, char Type);


        List<EmpNotifications> employeenotications(EmpNotifications empnotification);

        int? noserviceemailsfromcustomer(string profileid, int? empid);

        ArrayList keywordlikesearch(keywordlikesearch keyword);

        List<GetRegprofilevalidation> RegistrationValidation_Counts(Regprofilevalidation RegValidation);

        int InsertMatchfollowupExpressinterest(int? fromcustid, int? tocustid, long? logID, string interstTYpe, int? empid);

        ArrayList Marketingtickethistory(int? custid);

        int? CloseReminderStatus(closereminder Mobj);

        int? ChangeEmppassword(string UserID);

        ArrayList MatchfollowupTicketStatus(long? Ticketid);

        int? RestoredProfileidupdate(RestoredProfileid Mobj);

        ArrayList KeywordlikeSearchnewpage(newkeywordlikesrch Mobj);

        ArrayList MasterDataselect(MasterData Mobj);

        int MasterdataInsertUpdate(MasterInsertUpdate Mobj);

        ArrayList Customerinfobasedoncustid(string custids, int Empid);

        int? updatemarketingvrfycation(ticketverification Mobj);

        ArrayList EmployeeMenulist(long? Empid);

        int? Updatedeletecustomerdetails(updatedeletecustomer Mobj);

        int? Updatedeletecustomerdetails_new(updatedeletecustomer Mobj);

        ArrayList EmployeePermissions(int? Empuserid, string Pageid, int? flag);

        int? Updateinsertemployeepermission(Employeepermission Mobj);

        ArrayList EmployeeReportsCounts(EmpCountsreport Mobj);

        int? updateprofilebranchid(string Profileid);

        int? inserttorestoretable(long? Profileid);

        int? InsertamountintoBank(bankamount Mobj);

        EmployeeMarketingTicketResponse GetMarketingTicketHistoryInfo_New(EmployeeMarketingTketRequestNew Mobj);

        List<EmployeeUnassignedPages> deselectPagePermissions(int? Empid, string Pageid, int? flag);

        ArrayList bankdepositedreport(bankamountreport Mobj);

        ArrayList bankNamesreport(int? RegionId);

        ArrayList employeeDailyworkreport(employeeworkreport Mobj);

        ArrayList Employeecustomerprint(string strProfileID, int? intAdminId);

        ArrayList deselectPagePermissionsupdate(int? Empid, string Pageid, int? flag);

        ArrayList EmployeeWorkgrade(string EMPID, string dtFromDate, string dtToDate);

        ArrayList EmployeeWorkperformance(string intRegionID);

        int? OpenMatchfollowupticket(long? ticketid, string EmpID);

        ArrayList SettlementReasonbasedonEmp(string empid);

        ArrayList Dontshowservice(long cust_id, string toprofileid, int empid, string Relation_type, int flag);

        ArrayList NewmatchfollowupticketCreation(long fromcust_id, long tocust_id);

        int? Remindercreation(long fromcust_id, long tocust_id, int? empid, long intTicketID, DateTime? dtRemainderDate);

        int? Partnerpreference_Indetailedata(long? CustID, string indetaileddesc);

        getCustomerinfoKeyword InfoCustomer(string Profileid);

        int? sendkeywordsearchemal(keywordsearchemail Mobj);

        List<getCustomerinfoKeyword> PhotosOfCustomers(string Profileids);

        ArrayList UnMatchfollowupSlideShowResult(SearchML Mobj);

        int? InsertMonthlyBills(insertmonthlybills Mobj);

        ArrayList PartnerPreferenceEditData(employeeEditpartnerInfo Mobj);

        int? PartnerPreferenceModifileddata(employeemodifiedpartner Mobj);

        ArrayList RegistrationprofilesInformation(employeRegistrationInfo Mobj);

        ArrayList CompareSearchResultsInfo(int? empId);

        List<slideshowNew> CompareSearchProfiles(string strCustIds);



        ArrayList KeywordSearchProfileidInfo(string Profileid);

        ArrayList MatchfollowupSelectCounts(int? fromEmpid, int? toEmpid);

        ArrayList MatchfollowupSelectBasedOnEmp(int? fromEmpid, int? toEmpid, int? Pagefrom, int? pageto);

        ArrayList MatchfollowupSlideShowResultForwardBackward(SearchML Mobj);

        ArrayList fromExpressToExpressStatusEmail(long? Fromcustid, long? ToCustIds);

        ArrayList ViewFullProfilePaidUnpaidEmail(long? fromCustId, long? toCustId);

        ArrayList ViewFullProfilePartialInfoEmail(long? fromCustId, long? toCustId);

        ArrayList YesterdayMatchfollowups(int? Empid, int? pagefrom, int? pageto);

        ArrayList EmpdailyReportPendingService(string intRegionID);



        ArrayList YesterdayLSTSerive(int? Empid, int? pagefrom, int? pageto);

        ArrayList YesterdaySettledDeletedInActivePhotosUpload(int? Empid);

        EmployeeMarketingTicketResponse UnpaidServiceNotUpdatedTickets(unpaidnotupdated Mobj);

        ArrayList ArrivalDeparturedates();

        int? InsertSAAmount(int? custid, decimal? saAmount);

        ArrayList EmployeeYesterdayWorkPendingReport(ystryPending mobj);

        ArrayList SchdulepageReport(schdulepageinfo mobj);

        ArrayList Yesterday48hoursSerives(int? Empid, int? pagefrom, int? pageto);

        ArrayList EmployeeYesterdayWorkPendingReportNew(ystryPending mobj);


        ArrayList ThreeDaysPendingReport(int? Empid, int? pagefrom, int? pageto);

    
        ArrayList EmpMatchFollowupandMarketingHistory(employeematchfollowupinfo mobj);

        ArrayList Accountsdetailspage(accountspageinfo mobj);

        ArrayList Viewdetailspage(viewpageinfo mobj);

        ArrayList MatchfollowupSlideShowResult_New(SearchML Mobj);

        ArrayList MatchfollowupCounts(int? intEmpID);


        ArrayList TeamheadReport(Teamheadinfo mobj);

        ArrayList StrickersReport(strickerspageinfo mobj);

        int UserProfileForgotPassword(string userName);

        ArrayList TeamleadBranches(string strvalename, int? strflg);

        int? KaakateeyaAgentCalling(kakagentCall Mobj);

        int? ProfileStatustoActive(string BrideProfileId, string GroomProfileId);


        int? MarketingMatchfollowupCompare(fileuploadexcel obj);

        ArrayList MarketingTicketHistoryCompareSelect(int? intBranchID, DateTime? dtDateofRecording);
    }

    public interface ISmallPages
    {
        ArrayList getMacIpValues(macIPInput mobj);

        Tuple<int, ArrayList> matchMeetingEntryForm(matchMeetingEntryForm mobj);

        Tuple<int, ArrayList> EmpDetailsNew(string profileID, int BridegroomFlag);

        Tuple<ArrayList, int, int, int, int> GetmatchMeetingData(int? brideCustID, int? groomCustID);

        int checkMarketingTicket(string ticketID);

        int brokerFormInsert(brokerEntryForm mobj);

        List<MyassignedPhotosOutPut> myAssignedPhotos(myassignedPhotoInputMl mobj);

        int myAssignedPhotosSubmit(myassignPhotoSubmit mobj);

        List<UnassignedPhotoSelect> unassignPhotoSelect(UnassignPhotoSelect mobj);

        int assignPhotos(long? Empid, string PhotoIDs);

        List<GetEmployeeList> employeeList(GetEmployeeListRequest mobj);

        int employeeCreation(EmployeeCreationInput mobj);

        string getLoginName(int intHomeBrchID);

        EmpAssignCounts getEmpWorkAssignCounts(int EmpID);

        int setEmpAssignCounts(EmpAssignCounts mobj);
        ArrayList loginLogOutReport(EmpLoginLogoutReportML mobj);

        ArrayList empWorksheet(EmpWorkSheetMl mobj);

        int getinsertImagepath(long whereId, string strvalue, string flag);

        int empLogout(int empid);

        ArrayList mediaterRegValidation(mediaterRegFormValidation mobj);

        ArrayList EmployeeCommunicationLogNew(CommunicationRequest mobj);

        int deleteSettleForm(int settleID);

        ArrayList ViewSuccessStories(viewSuccessStoriesRequest sObj);

        Tuple<int, ArrayList> GetbrideGroomData(string profileID, int iFlag);
        Tuple<int, ArrayList> GetbrideGroomDataNew(string profileID, int iFlag);

        int createSuccessStories(createSuccessStoryRequest mobj);

        int deleteSucessStories(string sucessStoryID, string brideProfileID, string groomProfileID);

        ArrayList matchMeetingCountReport(matchMeetingCountMl mobj);

        ArrayList matchMeetingCountInfo(matchMeetingCountInfoMl mobj);

        ArrayList ProfileDeleteProfilesReport(settleDeleteProfilesReport mobj);

        //int restoreProfile(restoreProfile mobj);

        int checkStatus(string whereID, string secondwhereID, string flag);

        ArrayList SettledPrfofilesInfo(settledProfilesRequest mobj);

        ArrayList noProfileGrade(noProfileGradeRequest mobj);

        int insertsettleAmountInfo(insertSettlAmountRequest mobj);

        List<settleInfo> getSettleInfo(string profileid);

        ArrayList GetDataStaging(string CustID);

        int UpdateGrading(NoProfileGradingMl mobj);

        ArrayList listOFServiceGiven(ListOfServicesTakenM1 mobj);

        ArrayList emailBouncelist(EmailBounceReports mobj);

        int EmpStatusformConfidential(string intProfileID, int empId);
    }

    public interface IMobileAppDev
    {
        ArrayList getMobileAppLandingDisplay(int? CustID, int? PaidStatus, int? Startindex, int? EndIndex);
        ArrayList UpdateCustomerEmailMobileNumber_Verification(MobileEmailVerf Mobj);
        ArrayList MobileLandingOrderDisplay(long? CustID, int? Startindex, int? EndIndex);
    }

}

