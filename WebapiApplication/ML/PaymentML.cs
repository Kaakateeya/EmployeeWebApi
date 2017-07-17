using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;

namespace WebapiApplication.ML
{

    public class Paymentselect
    {

        public string MembershipName { get; set; }
        public int? Emp_Membership_ID { get; set; }
        public int? MemberShipDuration { get; set; }
        public Int64? Cust_MemberShip_Discount_ID { get; set; }
        public int? DiscountAmount { get; set; }
        public int? AllottedServicePoints { get; set; }
        public double? MembershipAmount { get; set; }
        public string onlineaccess { get; set; }
        public string offlineaccess { get; set; }
        public string Ppluspath { get; set; }
        public string Ppath { get; set; }
        public int? AccessFeature { set; get; }

    }

    public class PaymentMasterMl
    {
        public long? intCustID { get; set; }
        public long? intMembershipID { get; set; }
        public long? DiscountID { get; set; }
        public int? Points { get; set; }
        public string MembershipName { get; set; }
        public int? Duration { get; set; }
        public string MembershipAmount { get; set; }
        public int? PaysmsID { get; set; }
        public int? Isonline { get; set; }
        public DataTable dtPaymentDetails { get; set; }
    }

    public class CustomerPaymentML
    {
        public int? ProfileID { get; set; }
        public int? Genderid { get; set; }
        public int? NoofPoints { get; set; }
        public string MemberShipName { get; set; }
        public float? AgreedAmount { get; set; }
        public int? Casteid { get; set; }
        public int? MemberShipTypeID { get; set; }
        public string SettlementAmount { get; set; }
        public int? DateDuration { get; set; }
        public float ServiceTax { get; set; }
        public string Branch { get; set; }
        public string AmountPaid { get; set; }
        public DateTime? EndDate { get; set; }
        public string ReceiptNumber { get; set; }
        public string TransactionID { get; set; }
        public string ChequeNoOrDDNo { get; set; }
        public string BranchName { get; set; }
        public string BankName { get; set; }
        public string Place { get; set; }
        public string Paydescription { get; set; }
        public int? ModeOfPayment { get; set; }
        public int? EmpID { get; set; }
        public int? MembershipID { get; set; }
        public int? Cust_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? StartDate { get; set; }
        public string MemberShipDescription { get; set; }
        public string ApplicationName { get; set; }
        public string MemberShipType { get; set; }
        public string CasteName { get; set; }
        public string Gender { get; set; }
        public int? Flag { get; set; }
        public DataTable dtPaymentDetails { get; set; }
        public int? Isonline { get; set; }
        public int PaysmsID { get; set; }
    }

    public class PaymentInsertML
    {
        public string ProfileID { get; set; }
        public int? Cust_id { get; set; }
        public int? Payment_Id { get; set; }
        public int? Renual_Type { get; set; }
        public int NoofPoints { get; set; }
        public float? AgreedAmount { get; set; }
        public string SettlementAmount { get; set; }
        public DateTime? DateDuration { get; set; }
        public float? ServiceTax { get; set; }
        public float? ServiceTaxAmt { get; set; }
        public string AmountPaid { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ReceiptNumber { get; set; }
        public string TransactionID { get; set; }
        public string ChequeNoOrDDNo { get; set; }
        public string BranchName { get; set; }
        public string BankName { get; set; }
        public string Place { get; set; }
        public string Paydescription { get; set; }
        public int? ModeOfPayment { get; set; }
        public int? EmpID { get; set; }
        public int? AccessFeatureID { get; set; }
        public DataTable dtPaymentDetails { get; set; }
        public int? Isonline { get; set; }
        public int PaysmsID { get; set; }
        public int MembershipDuration { set; get; }
        public int? PaymentHist_ID { set; get; }

    }


   



    public class paymentAuthorization
    {
        public long? PaymentID { set; get; }
        public int? PaymentHisID { set; get; }//added
        public string ProfileID { set; get; }
        public int? CustID { set; get; }
        public string AutherizationDesc { set; get; }
        public string ExpiryDate { set; get; }
        public int? PaymentStatus { set; get; }
        public int? EmployeeID { set; get; }


        //public string TicketID { set; get; }
        //public string MarketedByID { set; get; }
        //public string CustomerID { set; get; }
        //public string MembershipID { set; get; }
        //public string AgreedAmount { set; get; }
        //public string PaidAmount { set; get; }
        //public string SettlementAmount { set; get; }
        //public string ServiceTax { set; get; }
        //public string OnlinePoints { set; get; }
        //public string OfflinePoints { set; get; }
        //public string MembershipDuration { set; get; }
        //public string CustMembershipID { set; get; }
    }












}
