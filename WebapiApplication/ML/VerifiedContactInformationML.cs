using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebapiApplication.ML
{
    public class VerifiedContactInformationML
    {
        public string Number { get; set; }
        public string Email { get; set; }
        public bool? ismobileverf { get; set; }
        public bool? isEmailverf { get; set; }
        public int? CountryCodeID { get; set; }
        public string CountryCodes { get; set; }
        public Int64? Cust_ContactNumbers_ID { get; set; }
        public string NumberVerificationcode { set; get; }
    }
}