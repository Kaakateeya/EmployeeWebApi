using System;
using System.Collections;
using System.Web.Http;
using WebapiApplication.Implement;
using WebapiApplication.Interfaces;
using WebapiApplication.ML;

namespace WebapiApplication.Api
{
    public class MobileAppLandingController : ApiController
    {
        private readonly IMobileAppDev IMobileAppDev;
        public MobileAppLandingController()
            : base()
        {
            this.IMobileAppDev = new ImpMobileApp();
        }

        public ArrayList getMobileAppLandingDisplay(int? CustID, int? PaidStatus, int? Startindex, int? EndIndex)
        {
            return this.IMobileAppDev.getMobileAppLandingDisplay(CustID, PaidStatus, Startindex, EndIndex);
        }

        public ArrayList UpdateCustomerEmailMobileNumber_Verification([FromBody]MobileEmailVerf Mobj)
        {
            if (Mobj.isVerified == 0) { Mobj.VerificationCode = Convert.ToString((new Random()).Next(10000, 99999).ToString()); }
            return this.IMobileAppDev.UpdateCustomerEmailMobileNumber_Verification(Mobj);
        }

        public ArrayList getMobileLandingOrderDisplay(long? CustID, int? Startindex, int? EndIndex)
        {
            return this.IMobileAppDev.MobileLandingOrderDisplay(CustID, Startindex, EndIndex);
        }
    }
}