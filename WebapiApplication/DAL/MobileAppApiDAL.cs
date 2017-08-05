using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using WebapiApplication.ML;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using KaakateeyaDAL;

namespace WebapiApplication.DAL
{
    public class MobileAppDal
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CustID"></param>
        /// <param name="PaidStatus"></param>
        /// <param name="Startindex"></param>
        /// <param name="EndIndex"></param>
        /// <param name="spName"></param>
        /// <returns></returns>
        /// 

        public ArrayList getMobileAppLandingDisplay(int? CustID, int? PaidStatus, int? Startindex, int? EndIndex, string spName)
        {
            ArrayList arrayList = new ArrayList();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            DataSet dtAppLanding = new DataSet();
            SqlDataAdapter daMobileLanding = new SqlDataAdapter();

            try
            {
                SqlCommand cmd = new SqlCommand(spName, connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_CustID", CustID);
                cmd.Parameters.AddWithValue("@PaidStatus", PaidStatus);
                cmd.Parameters.AddWithValue("@iStartindex", Startindex);
                cmd.Parameters.AddWithValue("@iEndIndex", EndIndex);

                daMobileLanding.SelectCommand = cmd;
                daMobileLanding.Fill(dtAppLanding);

            }
            catch (Exception Ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(Ex.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }

            return Commonclass.convertdataTableToArrayListTable(dtAppLanding);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Mobj"></param>
        /// <param name="spName">[dbo].[usp_EmailmobileUpdate_MobileApp]</param>
        /// <returns></returns>

        public ArrayList UpdateCustomerEmailMobileNumber_Verification(MobileEmailVerf Mobj, string spName)
        {
            ArrayList arrayList = new ArrayList();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet dtAssignSettings = new DataSet();
            SqlDataAdapter daParentDetails = new SqlDataAdapter();

            try
            {

                SqlCommand cmd = new SqlCommand(spName, connection);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_CustID", Mobj.CustID);
                cmd.Parameters.AddWithValue("@v_Email", Mobj.Email);
                cmd.Parameters.AddWithValue("@v_MobileNumber", Mobj.MobileNumber);
                cmd.Parameters.AddWithValue("@i_CountryCode", Mobj.CountryCode);
                cmd.Parameters.AddWithValue("@v_VerificationCode", Mobj.VerificationCode);
                cmd.Parameters.AddWithValue("@isVerified", Mobj.isVerified);

                daParentDetails.SelectCommand = cmd;
                daParentDetails.Fill(dtAssignSettings);

            }
            catch (Exception Ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(Ex.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }

            return Commonclass.convertdataTableToArrayListTable(dtAssignSettings);
        }
    }
}