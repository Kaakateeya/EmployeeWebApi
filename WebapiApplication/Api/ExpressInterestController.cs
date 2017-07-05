using System;
using System.Collections;
using System.Data;
using Newtonsoft.Json;
using System.Web.Http;
using WebapiApplication.ML;
using WebapiApplication.Implement;
using WebapiApplication.Interfaces;
using System.Collections.Generic;
using WebapiApplication.DAL;
using WebapiApplication.UserDefinedTable;
using Newtonsoft.Json.Linq;

namespace WebapiApplication.Api
{
    public class ExpressInterestController : ApiController
    {
        private readonly IExpressInterest IExpressInterest;
        public ExpressInterestController() : base() { this.IExpressInterest = new ImpExpressInterest(); }
        public ArrayList getExpressInterest_linq(string flag, string ID, string RelationShipID) { return this.IExpressInterest.ExpressInterest_linq(flag, ID, RelationShipID); }
        public ArrayList getMatchFollowup_linq(string flag, string ID, string RelationShipID) { return this.IExpressInterest.MatchFollowup_linq(flag, ID, RelationShipID); }
      
        public Tuple<List<Smtpemailsending>, int?> ExpressInterest([FromBody]JObject CgetDetails)
        {
            List<TExpressInterest> lstExpress = new List<TExpressInterest>();
            object obj = (object)CgetDetails["GetDetails"];
            var objs = JsonConvert.DeserializeObject<List<TExpressInterest>>(obj.ToString());
            DataTable dtExpress = new DataTable();
            ExpressInterestInsert EXI = CgetDetails["customerpersonaldetails"].ToObject<ExpressInterestInsert>();
            lstExpress = objs;
            dtExpress = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtExpressInterestTable(), lstExpress);
            if (dtExpress != null && dtExpress.Rows.Count > 0)
            {
                foreach (DataRow dr in dtExpress.Rows)
                {
                    string FromProfileID = dr["FromProfileID"].ToString();
                    string ToProfileID = dr["ToProfileID"].ToString();

                    dr["Acceptlink"] = Commonclass.getEncryptedExpressIntrestString("FromProfileID=" + FromProfileID + "&" + "ToProfileID=" + ToProfileID + "&" + "Flag=" + 1);
                    dr["Rejectlink"] = Commonclass.getEncryptedExpressIntrestString("FromProfileID=" + FromProfileID + "&" + "ToProfileID=" + ToProfileID + "&" + "Flag=" + 0);
                    dr["RvrAcceptlink"] = Commonclass.getEncryptedExpressIntrestString("FromProfileID=" + ToProfileID + "&" + "ToProfileID=" + FromProfileID + "&" + "Flag=" + 1);
                    dr["RvrRejectlink"] = Commonclass.getEncryptedExpressIntrestString("FromProfileID=" + ToProfileID + "&" + "ToProfileID=" + FromProfileID + "&" + "Flag=" + 0);
                    dr["Sendsms"] = (!string.IsNullOrEmpty(dr["Sendsms"].ToString()) && dr["Sendsms"].ToString() == "True") ? true : false;
                    dr["IsRvrSend"] = (!string.IsNullOrEmpty(dr["IsRvrSend"].ToString()) && dr["IsRvrSend"].ToString() == "True") ? true : false;
                }
            }

            EXI.dtExpInt = dtExpress;
            return this.IExpressInterest.ExpressInterest(EXI);

        }
        public ArrayList getExpressInterest_SendSms(string FromProfileID, string ToProfileIDs) { return this.IExpressInterest.ExpressInterest_SendSms(FromProfileID, ToProfileIDs); }
        public int getServiceInfo(string FromProfileID, string ToProfileID) { return this.IExpressInterest.getServiceInfo(FromProfileID, ToProfileID); }
    }
}
