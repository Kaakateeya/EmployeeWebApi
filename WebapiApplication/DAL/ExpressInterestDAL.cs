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
    public class ExpressInterestDAL
    {

        public ArrayList ExpressInterest_linq(string iflag, string ID, string RelationShipID, string spName)
        {
            DataSet dset = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[5];
                parm[0] = new SqlParameter("@v_dflag", SqlDbType.VarChar);
                parm[0].Value = iflag;
                parm[1] = new SqlParameter("@ID", SqlDbType.VarChar);
                parm[1].Value = ID;
                parm[2] = new SqlParameter("@RelationShipID", SqlDbType.VarChar);
                parm[2].Value = RelationShipID;
                dset = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(ex.Message), Convert.ToInt32(ID), null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayListTable(dset);
        }


        public ArrayList MatchFollowup_linq(string iflag, string ID, string RelationShipID, string spName)
        {
            DataSet dset = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[5];
                parm[0] = new SqlParameter("@v_dflag", SqlDbType.VarChar);
                parm[0].Value = iflag;
                parm[1] = new SqlParameter("@ID", SqlDbType.VarChar);
                parm[1].Value = ID;
                parm[2] = new SqlParameter("@RelationShipID", SqlDbType.VarChar);
                parm[2].Value = RelationShipID;
                dset = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(ex.Message), Convert.ToInt32(ID), null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayListTable(dset);
        }


        public Tuple<List<Smtpemailsending>, int?> ExpressInterest(ExpressInterestInsert ExpML, string spName)
        {
            int? status = null;

            SqlDataReader reader;
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {

                SqlParameter[] parm = new SqlParameter[5];
                parm[0] = new SqlParameter("@cust_Id", SqlDbType.Int);
                parm[0].Value = ExpML.FromCustID;
                parm[1] = new SqlParameter("@empid", SqlDbType.BigInt);
                parm[1].Value = ExpML.EmpID;
                parm[2] = new SqlParameter("@TblDetails", SqlDbType.Structured);
                parm[2].Value = ExpML.dtExpInt;
                parm[3] = new SqlParameter("@emailaddress", SqlDbType.VarChar);
                parm[3].Value = ExpML.emailaddress;
                parm[4] = new SqlParameter("@Status", SqlDbType.Int);
                parm[4].Direction = ParameterDirection.Output;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        li.Clear();
                        Smtpemailsending smtp = new Smtpemailsending();
                        {
                            smtp.profile_name = (reader["profile_name"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("profile_name")) : string.Empty;
                            smtp.recipients = (reader["recipients"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("recipients")) : string.Empty;
                            smtp.body = (reader["body"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("body")) : string.Empty;
                            smtp.subject = (reader["subject"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("subject")) : string.Empty;
                            smtp.body_format = (reader["body_format"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("body_format")) : string.Empty;
                            smtp.Status = (reader["Status"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Status")) : status;
                        }
                        li.Add(smtp);
                        Commonclass.SendMailSmtpMethod(li, "exp");
                    }
                }

                Commonclass.ExpressInterestSMS(ExpML.dtExpInt, " ");

                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }

            return new Tuple<List<Smtpemailsending>, int?>(li, status);
        }
        public DataSet ExpressInterest_SendSms(string FromProfileID, string ToProfileIDs, string spName)
        {

            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@v_FromProfileID", SqlDbType.VarChar, 8000);
                parm[0].Value = FromProfileID;
                parm[1] = new SqlParameter("@v_ToProfileIDs", SqlDbType.VarChar, 8000);
                parm[1].Value = ToProfileIDs;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(ex.Message), Convert.ToInt32(FromProfileID), null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }

            return ds;

        }


        public Servicedates getServiceInfoDal(string FromProfileID, string ToProfileID, string spName)
        {
            DataSet ds = new DataSet();
            SqlDataReader reader;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            Servicedates servicedate = new Servicedates();
            connection.Open();
            int status = 0;

            try
            {
                SqlParameter[] parm = new SqlParameter[3];
                parm[0] = new SqlParameter("@FromProfileID", SqlDbType.VarChar, 8000);
                parm[0].Value = FromProfileID;
                parm[1] = new SqlParameter("@ToProfileID", SqlDbType.VarChar, 8000);
                parm[1].Value = ToProfileID;
                parm[2] = new SqlParameter("@Status", SqlDbType.Int);
                parm[2].Direction = ParameterDirection.Output;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        servicedate.Servicedate = (reader["ServiceDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ServiceDate")) : string.Empty;
                        servicedate.Status = (reader["Status"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Status")) : status;
                    }
                }
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(ex.Message), Convert.ToInt32(FromProfileID), null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }

            return servicedate;
        }
    }
}