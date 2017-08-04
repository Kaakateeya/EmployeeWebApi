using System;
using System.Collections;
using System.Web.Http;
using WebapiApplication.ML;
using WebapiApplication.Implement;
using WebapiApplication.Interfaces;
using System.Collections.Generic;
using WebapiApplication.UserDefinedTable;
using WebapiApplication.DAL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using WebapiApplication.ServiceReference1;
namespace WebapiApplication.Api
{
    public class PaymentController : ApiController
    {
        private readonly IPayment IPayment;
        public PaymentController() : base() { this.IPayment = new ImpPayment(); }
        public List<Paymentselect> GetPaymentDetails(long? CustID) { return this.IPayment.GetPaymentDetails(CustID); }
        public string getCustomerPaymentStatus(long? CustomerCustID) { return this.IPayment.CustomerPaymentStatus(CustomerCustID); }
        public int InsertPaymentDetails([FromBody]PaymentMasterMl Mobj) { return this.IPayment.InsertPaymentDetails(Mobj); }
        public ArrayList getProfilePaymentDetails(long? intProfileID, int? Isonline, int? flag, int? intMembershipID, string taxpaid) { return this.IPayment.ProfilePaymentDetails(intProfileID, Isonline, flag, intMembershipID, taxpaid); }

        public int CustomerInsertPaymentDetilsInfo([FromBody]CustomerPaymentML Mobj)
        {
            List<CustomerPaymentML> lstPayment = new List<CustomerPaymentML>();
            lstPayment.Add(Mobj);
            Mobj.dtPaymentDetails = Commonclass.returnListDatatable(PersonaldetailsUDTables.createDataTablePaymentDetails(), lstPayment);
            return this.IPayment.CustomerInsertPaymentDetilsInfo(Mobj);
        }

        public int CustomerInsertPaymentDetilsInfo_NewDesign([FromBody]PaymentInsertML Mobj)
        {
           
            List<PaymentInsertML> lstPayment = new List<PaymentInsertML>();
            lstPayment.Add(Mobj);
            Mobj.dtPaymentDetails = Commonclass.returnListDatatable(PersonaldetailsUDTables.createDataTablePayment_New(), lstPayment);
            return this.IPayment.CustomerInsertPaymentDetilsInfo_NewDesign(Mobj);

        }

        //new  Payment Page

        public ArrayList getProfilePaymentDetailsGridview(string intProfileID) { return this.IPayment.ProfilePaymentDetails_Gridview(intProfileID); }
        public ArrayList getProfilePaymentDetails_NewDesigns(string intProfileID, int intPaymentHistID) { return this.IPayment.DgetProfilePaymentDetails_NewDesigns(intProfileID, intPaymentHistID); }

        public int setPaymentAuthorization([FromBody]paymentAuthorization mobj)
        {
            List<paymentAuthorization> lstpaymentAuth = new List<paymentAuthorization>();
            lstpaymentAuth.Add(mobj);
            DataTable dtinput = new DataTable();
            dtinput = Commonclass.returnListDatatable(PersonaldetailsUDTables.getAuthorizationDetailsUpdate(), lstpaymentAuth);
            return this.IPayment.setPaymentAuthorization(dtinput);
        }


    }
}
