using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebapiApplication.ML
{
    public class MobileAppDevML
    {

    }

    public class MobileEmailVerf
    {
        public long? CustID { set; get; }
        public string Email { set; get; }
        public string MobileNumber { set; get; }
        public int? CountryCode { set; get; }
        public string VerificationCode { set; get; }
        public int? isVerified { set; get; }
    }

}