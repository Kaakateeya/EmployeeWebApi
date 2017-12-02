using System;
using System.Collections.Generic;
using System.Web.Http;
using WebapiApplication.Implement;
using WebapiApplication.Interfaces;
using WebapiApplication.ML;

namespace WebapiApplication.Api
{
    public class DashboardRequestController : ApiController
    {
        private readonly IDashboardRequest IDashboardRequest;
        public DashboardRequestController()
            : base()
        {
            this.IDashboardRequest = new ImpDashboard();
        }

        [HttpGet]
        public DashboardClass DashboardRequestget([FromUri]int id, [FromUri]string TypeOfReport, [FromUri]int pagefrom, [FromUri]int pageto, string DashboardType) { return this.IDashboardRequest.GetLandingCountsBal(id, TypeOfReport, pagefrom, pageto, DashboardType); }

        [HttpGet]
        public DashboardClass DashboardGetPartnerProfilesRequestget([FromUri]int id, [FromUri]string TypeOfReport, [FromUri]int pagefrom, [FromUri]int pageto, string DashboardType) { return this.IDashboardRequest.GetPartnerProfilesBal(id, TypeOfReport, pagefrom, pageto, DashboardType); }

        public List<PartnerProfilesLatest> ExpressInterestSelectrequest([FromBody]DashboardRequest Dashboard)
        {
            return this.IDashboardRequest.ExpressInterestSelectBal(Dashboard);
        }

        public List<DashboardRequestChats> getCustometExpressIntrestDashBoardchats([FromUri]long? CustID, [FromUri]int? Status, [FromUri]int iStartIndex, [FromUri]int iEndIndex)
        {
            return this.IDashboardRequest.CustometExpressIntrestDashBoardchats(CustID, Status, iStartIndex, iEndIndex);
        }

        public List<TicketHistoryinfoResponse> GetTicketinformation([FromUri]long? Ticketid, [FromUri]char Type)
        {
            return this.IDashboardRequest.GetTicketinformationDal(Ticketid, Type);
        }

        public List<CommunicationHistry> DashboardCustometMessagesCount(CommunicationHistoryReq Mobj)
        {
            return this.IDashboardRequest.GetCustometMessagesCount(Mobj);
        }

        public int getInsertExpressViewTicket([FromUri]long? FromCustID, [FromUri]long? ToCustID, [FromUri] string EncriptedText, [FromUri] string strtypeOfReport)
        {
            return IDashboardRequest.InsertExpressViewTicket(FromCustID, ToCustID, EncriptedText = WebapiApplication.DAL.Commonclass.createTicketEncriptedText(Convert.ToString(FromCustID), Convert.ToString(ToCustID)), strtypeOfReport);
        }

        public int getInsertCustomerExpressinterest([FromUri]int? fromcustid, [FromUri]int? tocustid, [FromUri] long? logID, [FromUri] string interstTYpe, [FromUri] int? empid)
        {
            return IDashboardRequest.InsertCustomerExpressinterest(fromcustid, tocustid, logID, interstTYpe, empid);
        }
    }
}