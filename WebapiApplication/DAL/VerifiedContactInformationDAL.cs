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
    public class VerifiedContactInformationDAL
    {
        public VerifiedContactInformationML DgetMobileEmailVerification(long? CustID)
        {
            VerifiedContactInformationML verification = null;
            SqlDataReader reader;
            bool? bnull = null;
            int? iNull = null;
            Int64? iNull64 = null;
            SqlConnection con = null;
            try
            {
                SqlParameter[] parm = new SqlParameter[6];

                parm[0] = new SqlParameter("@CustID", SqlDbType.BigInt);
                parm[0].Value = CustID;
                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;

                using ( con = new SqlConnection(ConfigurationManager.ConnectionStrings["KakConnection"].ToString()))
                {
                    con.Open();
                    reader = SQLHelper.ExecuteReader(con, CommandType.StoredProcedure, "[dbo].[Usp_GetContactVerificationForCustomer]", parm);
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            verification = new VerifiedContactInformationML();
                            {
                                verification.Number = reader["Number"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Number")) : null;
                                verification.Email = reader["Email"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Email")) : null;
                                verification.ismobileverf = reader["ismobileverf"] != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("ismobileverf")) : bnull;
                                verification.isEmailverf = reader["isEmailverf"] != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("isEmailverf")) : bnull;
                                verification.CountryCodeID = reader["CountryCodeID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CountryCodeID")) : iNull;
                                verification.CountryCodes = reader["CountryCodes"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("CountryCodes")) : null;
                                verification.Cust_ContactNumbers_ID = reader["Cust_ContactNumbers_ID"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_ContactNumbers_ID")) : iNull64;
                                verification.NumberVerificationcode = reader["NumberVerificationcode"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("NumberVerificationcode")) : null;
                            }
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog("[dbo].[Usp_GetContactVerificationForCustomer]", Convert.ToString(ex.Message), Convert.ToInt32(CustID), null, null);
            }
            finally
            {
               
                con.Close();
               
              
            }
            return verification;
        }
    }
}