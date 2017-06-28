using System;
using System.Collections.Generic;
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

namespace WebapiApplication.Implement
{
    public class ImpUserlogin : IuserLogin
    {
        public List<userLoginML> DGetLogininformationdetails(CustLoginMl Mobj) { return new UserLoginDAL().DGetLogininformationdetails(Mobj); }
        public Tuple<EmpDetailsMl, List<MenuItem>, List<ScrollText>, List<StarRating>, int> ValidateLoginNew(string LoginName, string Password, string sMAC)  {            string spName = null;
            if (!string.IsNullOrEmpty(sMAC)) { spName = "[dbo].[usp_Emp_Validate_Mac_NewDesign]"; } else { spName = "[dbo].[usp_Emp_Validate_NewDesign]"; }
            return new UserLoginDAL().ValidateLoginNew(LoginName, Password, sMAC, spName);
        }
    }

    public class ImpDashboard : IDashboardRequest
    {

        Dashboard dashboard = new Dashboard();
        public List<PartnerProfilesLatest> ExpressInterestSelectBal(DashboardRequest dreq) { return dashboard.ExpressInterestSelectDal(dreq); }
        public DashboardClass GetLandingCountsBal(int? CustID, string TypeOfReport, int pagefrom, int pageto, string DashboardType)
        {
            if (DashboardType == "UnPaid") { return dashboard.LandingCountsDal(CustID, TypeOfReport, pagefrom, pageto, "[dbo].[usp_select_CustomerDashBoard]"); }
            else { return dashboard.LandingCountsDal(CustID, TypeOfReport, pagefrom, pageto, "[dbo].[usp_select_CustomerDashBoard_Exact]"); }
        }
        public DashboardClass GetPartnerProfilesBal(int? CustID, string TypeOfReport, int pagefrom, int pageto, string DashboardType)
        {
            if (DashboardType == "UnPaid") { return dashboard.GetPartnerProfilesDal(CustID, TypeOfReport, pagefrom, pageto, "[dbo].[usp_select_CustomerDashBoard]"); }
            else { return dashboard.GetPartnerProfilesDal(CustID, TypeOfReport, pagefrom, pageto, "[dbo].[usp_select_CustomerDashBoard_Exact]"); }
        }
        public List<DashboardRequestChats> CustometExpressIntrestDashBoardchats(long? CustID, int? Status, int iStartIndex, int iEndIndex) { return dashboard.DgetCustometExpressIntrestDashBoardchats(CustID, Status, iStartIndex, iEndIndex, "[dbo].[usp_CustomerDashBoard_messages]"); }
        public List<TicketHistoryinfoResponse> GetTicketinformationDal(long? Ticketid, char Type) { return dashboard.GetTicketinformationDal(Ticketid, Type, "[dbo].[Usp_select_MatchFollowupTicketHistory]"); }
        public List<CommunicationHistry> GetCustometMessagesCount(CommunicationHistoryReq Mobj) { return dashboard.GetCustometMessagesCount(Mobj, "[dbo].[usp_GetCustMessageHistory]"); }
        public int InsertExpressViewTicket(long? FromCustID, long? ToCustID, string EncriptedText, string strtypeOfReport) { return dashboard.InsertExpressViewTicket(FromCustID, ToCustID, EncriptedText, strtypeOfReport, "[dbo].[Usp_InsertExpressViewTicket_new_NewDesign]"); }
        public int InsertCustomerExpressinterest(int? fromcustid, int? tocustid, long? logID, string interstTYpe, int? empid) { return dashboard.InsertCustomerExpressinterest(fromcustid, tocustid, logID, interstTYpe, empid, "[dbo].[usp_insert_customerDashboard_expressinterest]"); }

    }
    public class ImpEmailMobileVerf : IEmailMobileVerf { public VerifiedContactInformationML DgetMobileEmailVerification(long? CustID) { return new VerifiedContactInformationDAL().DgetMobileEmailVerification(CustID); } }
    public class ImpCustSearchService : ICustSearchService { public int CustomerServiceDal(CustSearchMl MobjViewprofile) { if (MobjViewprofile.TypeofInsert == "E") { MobjViewprofile = Commonclass.CustomerViewProfileEncriptedText(MobjViewprofile); } return new CustomerServiceDAL().getCustomerServiceDal(MobjViewprofile, "[dbo].[usp_insert_customerDashboard]"); } }
    public class ImpPayment : IPayment
    {
        public List<Paymentselect> GetPaymentDetails(long? CustID) { return new PaymentDAL().GetPaymentDetails(CustID, "[dbo].[usp_CustomerPayments_New]"); }
        public string CustomerPaymentStatus(long? CustomerCustID) { return new PaymentDAL().CustomerPaymentStatus(CustomerCustID, "[dbo].[usp_PaymentStatus]"); }
        public int InsertPaymentDetails(PaymentMasterMl Mobj) { return new PaymentDAL().InsertPaymentDetails(Mobj, "[dbo].[Usp_InsertCustomerPayment]"); }
        public ArrayList ProfilePaymentDetails(long? intProfileID, int? Isonline, int? flag, int? intMembershipID, string taxpaid) { return new PaymentDAL().DgetProfilePaymentDetails(intProfileID, Isonline, flag, intMembershipID, taxpaid); }
        public int CustomerInsertPaymentDetilsInfo(CustomerPaymentML Mobj) { return new PaymentDAL().CustomerInsertPaymentDetilsInfo(Mobj, "[dbo].[Usp_InsertPaymentDetailsInfo]"); }
        public int CustomerInsertPaymentDetilsInfo_NewDesign(PaymentInsertML Mobj) { return new PaymentDAL().CustomerInsertPaymentDetilsInfo_New(Mobj, "[dbo].[Usp_InsertPaymentDetailsInfo_NewDesign_NewDesign]"); }
        //Payment New  Table  design 
        public ArrayList ProfilePaymentDetails_Gridview(string intProfileID) { return new PaymentDAL().ProfilePaymentDetails_Gridview(intProfileID, "[dbo].[usp_getSearchMemberShipPackege_NewDesign]"); }
        public ArrayList DgetProfilePaymentDetails_NewDesigns(string intProfileID) { return new PaymentDAL().DgetProfilePaymentDetails_NewDesigns(intProfileID, "[dbo].[usp_Payment_getProfilePaymentDetails_NewDesigns]"); }
        public int setPaymentAuthorization(DataTable dt) { return new PaymentDAL().setPaymentAuthorizationDal(dt, "[dbo].[usp_set_CustPaymentAuthorization_NewDesign]"); }
    }
}