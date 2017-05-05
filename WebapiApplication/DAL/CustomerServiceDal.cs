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
    public class CustomerServiceDAL
    {
        public int getCustomerServiceDal(CustSearchMl MobjViewprofile, string spName)
        {
            SqlParameter[] parm = new SqlParameter[14];
            int istatus = 0;
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            SqlDataReader reader;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@fromcustid", SqlDbType.Int);
                parm[0].Value = MobjViewprofile.IFromCustID;
                parm[1] = new SqlParameter("@toCustID", SqlDbType.Int);
                parm[1].Value = MobjViewprofile.IToCustID;
                parm[2] = new SqlParameter("@TypeofInsert", SqlDbType.VarChar);
                parm[2].Value = MobjViewprofile.TypeofInsert;

                parm[3] = new SqlParameter("@i_Acceptlink", SqlDbType.VarChar);
                parm[3].Value = MobjViewprofile.EncriptedText;

                parm[4] = new SqlParameter("@i_Rejectlink", SqlDbType.VarChar);
                parm[4].Value = MobjViewprofile.EncryptedRejectFlagText;

                parm[5] = new SqlParameter("@i_RVRAcceptlink", SqlDbType.VarChar);
                parm[5].Value = MobjViewprofile.EncriptedTextrvr;

                parm[6] = new SqlParameter("@i_RVRRejectlink", SqlDbType.VarChar);
                parm[6].Value = MobjViewprofile.EncryptedRejectFlagTextrvr;
                parm[7] = new SqlParameter("@vc_Message", SqlDbType.VarChar);
                parm[7].Value = MobjViewprofile.StrHtmlText;

                parm[8] = new SqlParameter("@i_MessagelinkID", SqlDbType.BigInt);
                parm[8].Value = MobjViewprofile.MessageLinkId;

                parm[9] = new SqlParameter("@i_Cust_MessageHistory_Id", SqlDbType.BigInt);
                parm[9].Value = MobjViewprofile.MessageHistoryId;
                parm[10] = new SqlParameter("@i_LogId", SqlDbType.BigInt);
                parm[10].Value = MobjViewprofile.Logid;

                parm[11] = new SqlParameter("@i_status", SqlDbType.Int);
                parm[11].Direction = ParameterDirection.Output;
                DataSet dsMessages = new DataSet();

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        Smtpemailsending smtp = new Smtpemailsending();
                        {
                            smtp.profile_name = (reader["profile_name"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("profile_name")) : string.Empty;
                            smtp.recipients = (reader["recipients"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("recipients")) : string.Empty;
                            smtp.body = (reader["body"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("body")) : string.Empty;
                            smtp.subject = (reader["subject"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("subject")) : string.Empty;
                            smtp.body_format = (reader["body_format"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("body_format")) : string.Empty;
                            istatus = smtp.Statusint = (reader["Status"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Status")) : 0;
                        }

                        li.Add(smtp);
                    }
                }
                reader.Close();
               
                if (MobjViewprofile.TypeofInsert == "I" || MobjViewprofile.TypeofInsert == "RP" || MobjViewprofile.TypeofInsert == "TH")
                {
                    if (string.Compare(parm[11].Value.ToString(), System.DBNull.Value.ToString()) == 0) { istatus = 0; } else { istatus = Convert.ToInt32(parm[11].Value); }
                }

                if (MobjViewprofile.TypeofInsert == "M" || MobjViewprofile.TypeofInsert == "B")
                {
                    Commonclass.SendMailSmtpMethod(li, "info");
                }
                else
                {
                    Commonclass.SendMailSmtpMethod(li, "exp");
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), MobjViewprofile.IFromCustID, null, null);
            }
            finally
            {
                //SQLHelper.GetSQLConnection().Close();
                //SqlConnection.ClearAllPools();
                //SQLHelper.GetSQLConnection().Dispose();
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return istatus;
        }

    }
}