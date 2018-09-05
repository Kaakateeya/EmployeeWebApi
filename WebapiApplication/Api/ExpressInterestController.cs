using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using WebapiApplication.DAL;
using WebapiApplication.Implement;
using WebapiApplication.Interfaces;
using WebapiApplication.ML;
using WebapiApplication.UserDefinedTable;

namespace WebapiApplication.Api
{
    public class ExpressInterestController : ApiController
    {
        private readonly IExpressInterest IExpressInterest;

        public ExpressInterestController()
            : base()
        {
            this.IExpressInterest = new ImpExpressInterest();
        }

        public ArrayList getExpressInterest_linq(string flag, string ID, string RelationShipID)
        {
            return this.IExpressInterest.ExpressInterest_linq(flag, ID, RelationShipID);
        }

        public ArrayList getMatchFollowup_linq(string flag, string ID, string RelationShipID)
        {
            return this.IExpressInterest.MatchFollowup_linq(flag, ID, RelationShipID);
        }

        public Tuple<List<Smtpemailsending>, int?> ExpressInterest([FromBody]JObject CgetDetails)
        {
            List<TExpressInterest> lstExpress = new List<TExpressInterest>();
            object obj = (object)CgetDetails["GetDetails"];
            var objs = JsonConvert.DeserializeObject<List<TExpressInterest>>(obj.ToString());
            DataSet dsResult = new DataSet();
            DataTable dtExpress = new DataTable();
            DataTable dtResultSet = new DataTable();
            string strfromprofileID = string.Empty;
            string strtoPRofileID = string.Empty;
            bool IsRvrSend =false ;
            ExpressInterestInsert EXI = CgetDetails["customerpersonaldetails"].ToObject<ExpressInterestInsert>();
            lstExpress = objs;
            dtExpress = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtExpressInterestTable(), lstExpress);

            if (dtExpress != null && dtExpress.Rows.Count > 0)
            {

                strfromprofileID = dtExpress.Rows[0]["FromProfileID"].ToString();
                strtoPRofileID = dtExpress.Rows[0]["ToProfileID"].ToString();
                IsRvrSend = Convert.ToBoolean(dtExpress.Rows[0]["IsRvrSend"].ToString());
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
            dsResult = this.IExpressInterest.ExpressInterest_sendmultimails(EXI);
          
            #region

            //if (IsRvrSend == true)
            //{

            //    DataTable tblFilteredTo = dsResult.Tables[0].AsEnumerable().Where(row => row.Field<String>("FromProfileID") == strfromprofileID).CopyToDataTable();

            //    EXI.dtExpInt = tblFilteredTo;

            //    if (EXI.dtExpInt != null && EXI.dtExpInt.Rows.Count > 0)
            //    {


            //        foreach (DataRow dr in EXI.dtExpInt.Rows)
            //        {
            //            string FromProfileID = dr["FromProfileID"].ToString();
            //            string ToProfileID = dr["ToProfileID"].ToString();

            //            if (strfromprofileID == FromProfileID)
            //            {
            //                dr["Acceptlink"] = Commonclass.getEncryptedExpressIntrestString("FromProfileID=" + FromProfileID + "&" + "ToProfileID=" + ToProfileID + "&" + "Flag=" + 1);
            //                dr["Rejectlink"] = Commonclass.getEncryptedExpressIntrestString("FromProfileID=" + FromProfileID + "&" + "ToProfileID=" + ToProfileID + "&" + "Flag=" + 0);
            //                dr["RvrAcceptlink"] = Commonclass.getEncryptedExpressIntrestString("FromProfileID=" + ToProfileID + "&" + "ToProfileID=" + FromProfileID + "&" + "Flag=" + 1);
            //                dr["RvrRejectlink"] = Commonclass.getEncryptedExpressIntrestString("FromProfileID=" + ToProfileID + "&" + "ToProfileID=" + FromProfileID + "&" + "Flag=" + 0);
            //                dr["Sendsms"] = (!string.IsNullOrEmpty(dr["Sendsms"].ToString()) && dr["Sendsms"].ToString() == "True") ? true : false;
            //                dr["IsRvrSend"] = (!string.IsNullOrEmpty(dr["IsRvrSend"].ToString()) && dr["IsRvrSend"].ToString() == "True") ? true : false;
            //            }
            //        }
            //        this.IExpressInterest.ExpressInterest(EXI);
            //    }
            //}


            //EXI.dtExpInt.Rows.Clear();
            //DataTable tblFiltered = dsResult.Tables[0].AsEnumerable().Where(row => row.Field<String>("FromProfileID") == strtoPRofileID).CopyToDataTable();

            #endregion

            EXI.dtExpInt = dsResult.Tables[0];

            if (EXI.dtExpInt != null && EXI.dtExpInt.Rows.Count > 0)
            {
              
                foreach (DataRow dr in EXI.dtExpInt.Rows)
                {
                    string FromProfileID = dr["FromProfileID"].ToString();
                    string ToProfileID = dr["ToProfileID"].ToString();

                    //if (strfromprofileID == ToProfileID)
                    //{
                        dr["Acceptlink"] = Commonclass.getEncryptedExpressIntrestString("FromProfileID=" + FromProfileID + "&" + "ToProfileID=" + ToProfileID + "&" + "Flag=" + 1);
                        dr["Rejectlink"] = Commonclass.getEncryptedExpressIntrestString("FromProfileID=" + FromProfileID + "&" + "ToProfileID=" + ToProfileID + "&" + "Flag=" + 0);
                        dr["RvrAcceptlink"] = Commonclass.getEncryptedExpressIntrestString("FromProfileID=" + ToProfileID + "&" + "ToProfileID=" + FromProfileID + "&" + "Flag=" + 1);
                        dr["RvrRejectlink"] = Commonclass.getEncryptedExpressIntrestString("FromProfileID=" + ToProfileID + "&" + "ToProfileID=" + FromProfileID + "&" + "Flag=" + 0);
                        dr["Sendsms"] = (!string.IsNullOrEmpty(dr["Sendsms"].ToString()) && dr["Sendsms"].ToString() == "True") ? true : false;
                        dr["IsRvrSend"] = (!string.IsNullOrEmpty(dr["IsRvrSend"].ToString()) && dr["IsRvrSend"].ToString() == "True") ? true : false;
                    //}
                }
               
            }


            return this.IExpressInterest.ExpressInterest(EXI);
        }


        public ArrayList getExpressInterest_SendSms(string FromProfileID, string ToProfileIDs)
        {
            return this.IExpressInterest.ExpressInterest_SendSms(FromProfileID, ToProfileIDs);
        }

        public Servicedates getServiceInfo(string FromProfileID, string ToProfileID)
        {
            return this.IExpressInterest.getServiceInfo(FromProfileID, ToProfileID);
        }
    }
}