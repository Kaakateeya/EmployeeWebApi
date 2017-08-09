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

namespace WebapiApplication.Api
{
    public class MobileAppLandingController : ApiController
    {

        private readonly IMobileAppDev IMobileAppDev; public MobileAppLandingController() : base() { this.IMobileAppDev = new ImpMobileApp(); }

        public ArrayList getMobileAppLandingDisplay(int? CustID, int? PaidStatus, int? Startindex, int? EndIndex) { return this.IMobileAppDev.getMobileAppLandingDisplay(CustID, PaidStatus, Startindex, EndIndex); }

        public ArrayList UpdateCustomerEmailMobileNumber_Verification([FromBody]MobileEmailVerf Mobj)
        {
            if (Mobj.isVerified == 0) { Mobj.VerificationCode = Convert.ToString((new Random()).Next(10000, 99999).ToString()); }
            return this.IMobileAppDev.UpdateCustomerEmailMobileNumber_Verification(Mobj);
        }

        public ArrayList getMobileLandingOrderDisplay(long? CustID, int? Startindex, int? EndIndex) { return this.IMobileAppDev.MobileLandingOrderDisplay(CustID, Startindex, EndIndex); }

    }
}