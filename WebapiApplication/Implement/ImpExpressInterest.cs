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
    public class ImpExpressInterest : IExpressInterest
    {

        public ArrayList ExpressInterest_linq(string iflag, string ID, string RelationShipID) { return new ExpressInterestDAL().ExpressInterest_linq(iflag, ID, RelationShipID, "[dbo].[usp_ExpressInterest_linq]"); }
        public ArrayList MatchFollowup_linq(string iflag, string ID, string RelationShipID) { return new ExpressInterestDAL().MatchFollowup_linq(iflag, ID, RelationShipID, "[dbo].[usp_MatchFollowup_linq]"); }
        public Tuple<List<Smtpemailsending>, int?> ExpressInterest(ExpressInterestInsert ExpML) { return new ExpressInterestDAL().ExpressInterest(ExpML, "[dbo].[usp_ExpressInterst_Insert_New]"); }

        //  public Tuple<List<Smtpemailsending>, int?> ExpressInterest(ExpressInterestInsert ExpML) { return new ExpressInterestDAL().ExpressInterest(ExpML, "[dbo].[usp_Emp_ExpressInterst_SendMaile]"); }
        //public DataSet ExpressInterest_sendmultimails(ExpressInterestInsert ExpML) { return new ExpressInterestDAL().ExpressInterest_sendmultimails(ExpML, "[dbo].[usp_Emp_ExpressInterst_Insert_New]"); }

        public ArrayList ExpressInterest_SendSms(string FromProfileID, string ToProfileIDs) { return Commonclass.convertdataTableToArrayList(new ExpressInterestDAL().ExpressInterest_SendSms(FromProfileID, ToProfileIDs, "[dbo].[usp_ExpressInterest_SendSms]")); }

        public Servicedates getServiceInfo(string FromProfileID, string ToProfileID) { return new ExpressInterestDAL().getServiceInfoDal(FromProfileID, ToProfileID, "[dbo].[Usp_GetServiceInfo_NewDesign]"); }

    }
}