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

    public class ImpMobileApp : IMobileAppDev
    {
        public ArrayList getMobileAppLandingDisplay(int? CustID, int? PaidStatus, int? Startindex, int? EndIndex) { return new MobileAppDal().getMobileAppLandingDisplay( CustID,  PaidStatus,  Startindex,  EndIndex, "[dbo].[usp_LandingPage_MobileApp]"); }

        public ArrayList UpdateCustomerEmailMobileNumber_Verification(MobileEmailVerf Mobj) { return new MobileAppDal().UpdateCustomerEmailMobileNumber_Verification(Mobj, "[dbo].[usp_EmailmobileUpdate_MobileApp]"); }
    
   
    }

}