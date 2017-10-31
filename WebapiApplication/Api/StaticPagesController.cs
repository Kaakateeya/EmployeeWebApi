using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebapiApplication.ML;
using WebapiApplication.Implement;
using WebapiApplication.Interfaces;
using System.Collections;
using WebapiApplication.DAL;
using System.Data;
using WebapiApplication.ServiceReference1;

namespace WebapiApplication.Api
{

    public class StaticPagesController : ApiController
    {

        private readonly IStaticPages ISuccessStories; public StaticPagesController() : base() { this.ISuccessStories = new ImpStaticPages(); }
        public HelpMail InsertTicketInfo([FromBody]TicketCreationMl Mobj) { return this.ISuccessStories.ImpInsertTicketInfo(Mobj); }
        public ViewfullProfileML getViewFullProfileMail(string OriginalString) { return this.ISuccessStories.ViewFullProfileMail(OriginalString); }
        public List<Sucessstories> SuccessStoriesdetails([FromBody]SuccessStoryML SML) { return this.ISuccessStories.getSucessstoriesdetails(SML); }
        public List<KaakateeyaBranchesML> getKaakateeyaBranchesDetails(string dependencyName, string dependencyValue, string dependencyflagID) { return this.ISuccessStories.ImpgetKaakateeyaBranchesDetails(dependencyName, dependencyValue, dependencyflagID); }
        public List<ProfileSettings> getcustomerProfilesettings(Int64? CustID) { return this.ISuccessStories.customerProfilesettings(CustID); }
        public List<PhotoPathDisplay> GetPhotoSlideImages(string CustID) { return this.ISuccessStories.GetPhotoSlideImages(CustID); }
        public ArrayList getCustomerViewfullProfileDetails([FromUri]long? ProfileID, [FromUri]int? CustID, [FromUri]int? RelationshipID) { return this.ISuccessStories.CustomerViewfullProfileDetails(ProfileID, CustID, RelationshipID); }
        public ArrayList getExpressinterstBookmarkIgnore([FromUri]long? loggedcustid, [FromUri]long? ToCustID) { return this.ISuccessStories.GetExpressinterstBookmarkIgnore(loggedcustid, ToCustID); }
        public ArrayList getpaymentdetailsmethoddal(Int64? CustID) { return this.ISuccessStories.paymentdetailsmethoddal(CustID); }
        public ArrayList TicketDetails([FromBody]TicketDetails ticketdetails) { return this.ISuccessStories.GetTicketDetails(ticketdetails); }
        public ArrayList getExpressIntrstfullprofile(string FromProfileID, int? EmpID) { return this.ISuccessStories.ExpressIntrstfullprofile(FromProfileID, EmpID); }
        public ArrayList getExpressinterst_bookmark_ignore_data(long? Loggedcustid, long? ToCustID) { return this.ISuccessStories.Expressinterst_bookmark_ignore_data(Loggedcustid, ToCustID); }
        public ArrayList getdisplayMissingFieldsupdate_Customerdetails(string CustID, int? i_updateflag) { return this.ISuccessStories.displayMissingFieldsupdate_Customerdetails(CustID, i_updateflag); }
        public ArrayList getCust_NotificationDetails(int? Cust_NotificationID, long? CustID, int? Startindex, int? EndIndex) { return this.ISuccessStories.Cust_NotificationDetails(Cust_NotificationID, CustID, Startindex, EndIndex); }
        public ArrayList getCust_NotificationDetails_Employee(int? EmpID, int? idisplay, int? NotificationID, int? CategoryID, int? CustID) { return this.ISuccessStories.Cust_NotificationDetails_Employee(EmpID, idisplay, NotificationID, CategoryID, CustID); }
        public ArrayList getCheckForgotPasswordStatus(string StrCustID) { return this.ISuccessStories.CheckForgotPasswordStatus(StrCustID); }
        public int UpdateExpressIntrestViewfullprofile([FromBody]UpdateExpressIntrestStatus Mobj) { return this.ISuccessStories.UpdateExpressIntrestViewfullprofile(Mobj); }
        public int getPhotopasswordAcceptReject(Int64? FromcustID, Int64? TocustID, Int64? Accept_Reject) { return this.ISuccessStories.PhotopasswordAcceptReject(FromcustID, TocustID, Accept_Reject); }
        public int getInsertcustomerProfilesettings(DateTime? Expirydate, int? CustID, int? iflag) { return this.ISuccessStories.InsertcustomerProfilesettings(Expirydate, CustID, iflag); }
        public int getDeletecustomerProfilesettings(Int64? ProfileID, string Narrtion) { return this.ISuccessStories.DeletecustomerProfilesettings(ProfileID, Narrtion); }
        public int getUpdatePassword(string OldPassword, string NewPassword, string ConfirmPassword, string custId) { return this.ISuccessStories.UpdatePassword(Commonclass.Encrypt(OldPassword), Commonclass.Encrypt(NewPassword), Commonclass.Encrypt(ConfirmPassword), custId); }
        public int CustomerRating_sendMail([FromBody]CustFeebBackML feedback) { return this.ISuccessStories.CustomerRating_sendMail(feedback); }
        public int getSendMail_PhotoRequest_Customer(string FromCustID, string ToCustID, int? Category) { if (Category == 467 && !string.IsNullOrEmpty(ToCustID)) { } return this.ISuccessStories.SendMail_PhotoRequest_Customer(FromCustID, ToCustID, Category); }
        public int getprofileGrade(string CustID) { return this.ISuccessStories.getprofileGrade(CustID); }
        public int SendTicketMail([FromBody]HelpMail Helpmail) { return this.ISuccessStories.ImpSendTicketMail(Helpmail); }
        public int getProfilesettingEmailMobileChange(Int64? FamilyID, string MobileEmail, int? CountryCodeID, int? imobileEmailflag) { return this.ISuccessStories.ProfilesettingEmailMobileChange(FamilyID, MobileEmail, CountryCodeID, imobileEmailflag); }
        public int getProfilesettingAllowEmailAllowSMS(Int64? CustID, int? AllowEmail, int? AllowSMS) { return this.ISuccessStories.ProfilesettingAllowEmailAllowSMS(CustID, AllowEmail, AllowSMS); }
        public int getEmailMobilenumberexists(int? iflagEmailmobile, string EmailMobile) { return this.ISuccessStories.EmailMobilenumberexists(iflagEmailmobile, EmailMobile); }
        public int getCustomerReopenTicketStatus(int? PageID, int? ProfileID, int? TicketID) { return this.ISuccessStories.CustomerReopenTicketStatus(PageID, ProfileID, TicketID); }
        public int getForgotPassword(string Username) { return this.ISuccessStories.ForgotPassword(Username); }
        public int getConfirmUserEmail(string VerificationCode) { return this.ISuccessStories.ConfirmUserEmail(VerificationCode); }
        public int getCreateNewPassword(Int64? intCusID, string strPassword) { return this.ISuccessStories.CreateNewPassword(intCusID, Commonclass.Encrypt(strPassword)); }
        public int getResendEmailVerficationLink(long? CustID) { return this.ISuccessStories.ResendEmailVerficationLink(CustID); }
        public int MissingFieldsupdate_Customerdetails([FromBody]MissingFieldsUpdateRequest Mobj) { return this.ISuccessStories.MissingFieldsupdate_Customerdetails(Mobj); }
        public int getInsertUnpaidStatus(string fromCustID, string ToCustID, int? Empid, string typeofAction) { return this.ISuccessStories.InsertUnpaidStatus(fromCustID, ToCustID, Empid, typeofAction); }
        public int getInsertExpressViewTicket(long? FromCustID, long? ToCustID, string DecriptedText, string strtypeOfReport) { return this.ISuccessStories.InsertExpressViewTicket(FromCustID, ToCustID, Commonclass.Encrypt(DecriptedText), strtypeOfReport); }
        public int getChangePassword(string StrCustID, string Password) { return this.ISuccessStories.ChangePassword(StrCustID, Commonclass.Encrypt(Password)); }
        public void getCustomerApplicationErroLog(string ErrorMessage, long? CustID, string PageName, string Type) { Commonclass.ApplicationErrorLog(null, ErrorMessage, CustID, PageName, Type); }
        public void getUnpaidMembersOwnerNotification(int? CategoryID, int? Cust_ID, string SendPhonenumber) { DataTable dt = this.ISuccessStories.UnpaidMembersOwner_Notification(CategoryID, Cust_ID); Commonclass.PaymentSMS(dt, SendPhonenumber); }
        public void getApplicationErrorLog(string ErrorSpName, string ErrorMessage, long? CustID, string PageName, string Type) { this.ISuccessStories.ApplicationErrorLog(ErrorSpName, ErrorMessage, CustID, PageName, Type); }
        public string getResendmobile(int? iCountryID, int? iCCode, string MobileNumber, int? CustContactNumbersID) { string VerfCode = Convert.ToString((new Random()).Next(10000, 99999).ToString()); Commonclass.ResendMobileSMS(iCountryID, iCCode, MobileNumber, VerfCode); this.ISuccessStories.EmilVerificationCode(VerfCode, 2, CustContactNumbersID, 0); return VerfCode; }
        public string getEmilVerificationCode(string VerificationCode, int? i_EmilMobileVerification, int? CustContactNumbersID) { return this.ISuccessStories.EmilVerificationCode(VerificationCode, i_EmilMobileVerification, CustContactNumbersID, 1); }
        public string getCustomerfilldata(long? CustomerCustID) { return this.ISuccessStories.Customerfilldata(CustomerCustID); }
        public ArrayList getCustShortlistProfile(string CustID) { return this.ISuccessStories.CustShortlistProfile(CustID); }
        public string getCustomerdmobileVerfCodesend(int? iCountryID, int? iCCode, string MobileNumber, int? CustFamilyID) { string VerfCode = Convert.ToString((new Random()).Next(10000, 99999).ToString()); Commonclass.ResendMobileSMS(iCountryID, iCCode, MobileNumber, VerfCode); return this.ISuccessStories.EmilVerificationCode(VerfCode, 3, CustFamilyID, 0); }
        public string getCustomerEmilVerificationCodeUpdate(string VerificationCode, int? CustFamilyID) { return this.ISuccessStories.EmilVerificationCode(VerificationCode, 3, CustFamilyID, 1); }
        public ArrayList getCustomerViewAdminFullDetails(string ProfileID, int? EmpID) { return this.ISuccessStories.CustomerViewAdminFullDetails(ProfileID, EmpID); }
        public ArrayList getEmployeeLoginCoutDetails() { return this.ISuccessStories.EmployeeLoginCoutDetails(); }
        public string getipAddressReturn() { return this.ISuccessStories.ipAddressReturn(); }
        public int getUpdateEmailBounce(Int64? CustID, int? EmailBounceEntryId, string BounceMailid) { return this.ISuccessStories.Update_EmailBounce(CustID, EmailBounceEntryId, BounceMailid); }
        public int getChangeApplicationStaus(long? ProfileID) { return this.ISuccessStories.getChangeApplicationStaus(ProfileID); }
        public ArrayList getCustomerHomePageDesignData(string flag, int? casteID, long? CustID, int? intStartIndex, int? intEndIndex, int? GenderID, int? isActive) { return this.ISuccessStories.CustomerHomePageDesignData(flag, casteID, CustID, intStartIndex, intEndIndex, GenderID, isActive); }
        public Tuple<string, int> getViewSettlementform(string Profileid) { return this.ISuccessStories.ViewSettlementform(Profileid); }
        public int getCheckprofileIDSelect(string Profileid) { return this.ISuccessStories.CheckprofileIDSelect(Profileid); }


        public int CustomerPaymentOffersAssign([FromBody]CustomerPaymentOffers Customerpayoffers) { return this.ISuccessStories.CustomerPaymentOffersAssign(Customerpayoffers); }
        public int getCustomerProfileIDstatus(string ProfileID) { return this.ISuccessStories.CustomerProfileIDstatus(ProfileID); }
        public ArrayList getCustomerParofileIDbasePayment(string ProfileID, int? BranchID) { return this.ISuccessStories.CustomerParofileIDbasePayment( ProfileID,  BranchID); }
        public ArrayList getCustomerUnauthorizedPayments(string BranchID, string StartDate, string EndDate, string Region) { return this.ISuccessStories.CustomerUnauthorizedPayments( BranchID,  StartDate,  EndDate,  Region); }

        public ViewProfileInputInbit getInbitdataInfo(string ProfileID, int? empid) { return this.ISuccessStories.InbitdataInfo(ProfileID, empid); }

        public NoDataFoundDisplay getNoDataFoundDisplay(string ProfileID) { return this.ISuccessStories.NoDataFoundDisplay(ProfileID); }
        public int getbrokerEmailMobilenumberexists(int? iflagEmailmobile, string EmailMobile) { return this.ISuccessStories.brokerEmailMobilenumberexists(iflagEmailmobile, EmailMobile); }

        public string getdecryptedProfileID(string ProfileID) { return Commonclass.Decrypt_new(ProfileID); }

    }
}

