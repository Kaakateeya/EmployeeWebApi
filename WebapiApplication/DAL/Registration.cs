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
using WebapiApplication.ServiceReference1;
namespace WebapiApplication.DAL
{
    public class RegistrationDAL
    {
        public int? DRegisterCustomerHomepages(PrimaryInformationMl Mobj, string spName)
        {
            SqlParameter[] parm = new SqlParameter[25];

            int status = 0;
            ArrayList arrayList = new ArrayList();
            SqlDataReader reader;
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            Smtpemailsending smtp = new Smtpemailsending();
            int? intStatus = 0;
            DateTime dtTime = DateTime.ParseExact(Mobj.dtDOB, "dd-MM-yyyy", null);
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            string strMobileVerificationCode = (new Random()).Next(10000, 99999).ToString();
            try
            {

                parm[0] = new SqlParameter("@CasteID", SqlDbType.Int);
                parm[0].Value = Mobj.intCasteID;
                parm[1] = new SqlParameter("@CountryID", SqlDbType.Int);
                parm[1].Value = Mobj.intCountryLivingID;
                parm[2] = new SqlParameter("@GenderID", SqlDbType.Int);
                parm[2].Value = Mobj.intGenderID;
                parm[3] = new SqlParameter("@MobileCode", SqlDbType.Int);
                parm[3].Value = Mobj.intMobileCode;
                parm[4] = new SqlParameter("@LandCode", SqlDbType.Int);
                parm[4].Value = Mobj.intLandCode;
                parm[5] = new SqlParameter("@MotherTongueID", SqlDbType.Int);
                parm[5].Value = Mobj.intMotherTongueID;
                parm[6] = new SqlParameter("@ReligionID", SqlDbType.Int);
                parm[6].Value = Mobj.intReligionID;
                parm[7] = new SqlParameter("@AreaCode", SqlDbType.VarChar);
                parm[7].Value = Mobj.strAreaCode;
                parm[8] = new SqlParameter("@Email", SqlDbType.VarChar);
                parm[8].Value = Mobj.strEmail;
                parm[9] = new SqlParameter("@FirstName", SqlDbType.VarChar);
                parm[9].Value = Mobj.strFirstName;
                parm[10] = new SqlParameter("@LandNo", SqlDbType.VarChar);
                parm[10].Value = Mobj.strLandNo;
                parm[11] = new SqlParameter("@LastName", SqlDbType.VarChar);
                parm[11].Value = Mobj.strLastName;
                parm[12] = new SqlParameter("@MobileNo", SqlDbType.VarChar);
                parm[12].Value = Mobj.strMobileNo;
                parm[13] = new SqlParameter("@Password", SqlDbType.VarChar);
                parm[13].Value = Commonclass.Encrypt(Mobj.strPassword);
                parm[14] = new SqlParameter("@DateOfBirth", SqlDbType.DateTime);
                // parm[14].Value = Mobj.dtDOB;
                parm[14].Value = dtTime;
                parm[15] = new SqlParameter("@Status", SqlDbType.Int);
                parm[15].Direction = ParameterDirection.Output;
                parm[16] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
                parm[16].Direction = ParameterDirection.Output;
                parm[17] = new SqlParameter("@Rowcount", SqlDbType.Int);
                parm[17].Direction = ParameterDirection.Output;
                parm[18] = new SqlParameter("@ProfileRegisteredBy", SqlDbType.Int);
                parm[18].Value = Mobj.intProfileRegisteredBy;
                parm[19] = new SqlParameter("@KMPLID", SqlDbType.VarChar);
                parm[19].Value = Mobj.strKMPLID;
                parm[20] = new SqlParameter("@MobileVerificationCode", SqlDbType.VarChar);
                parm[20].Value = strMobileVerificationCode;
                parm[21] = new SqlParameter("@EmpID", SqlDbType.BigInt);
                parm[21].Value = Mobj.intEmpID;
                parm[22] = new SqlParameter("@ID", SqlDbType.Int);
                parm[22].Value = Mobj.ID;
                parm[23] = new SqlParameter("@IsCustomer", SqlDbType.Int);
                parm[23].Value = Mobj.IsCustomer;
                parm[24] = new SqlParameter("@IsCustomerPostedBY", SqlDbType.Int);
                parm[24].Value = Mobj.intCustPostedBY;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        smtp.profile_name = (reader["profile_name"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("profile_name")) : string.Empty;
                        smtp.recipients = (reader["recipients"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("recipients")) : string.Empty;
                        smtp.body = (reader["body"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("body")) : string.Empty;
                        smtp.subject = (reader["subject"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("subject")) : string.Empty;
                        smtp.body_format = (reader["body_format"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("body_format")) : string.Empty;
                        smtp.Status = (reader["Status"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Status")) : status;
                        smtp.CustID = (reader["Cust"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Cust")) : 0;
                        li.Add(smtp);
                    }
                }
                if (Mobj.intEmpID == null)
                {
                    Commonclass.SendMailSmtpMethod(li, "info");
                }
                intStatus = smtp.Status;
                reader.Close();
                if (intStatus.Equals(1))
                {
                    ServiceSoapClient cc = new ServiceSoapClient();
                    try
                    {
                        string result = cc.SendTextSMS("ykrishna", "summary$1", Mobj.strMobileNo.ToString().Trim(), "Hi " + Mobj.strFirstName + ", Your verification code with www.kaakateeya.com is " + strMobileVerificationCode + " Please enter this code to confirm your Registration.", "smscntry");
                    }
                    catch (Exception EX)
                    {
                        Commonclass.ApplicationErrorLog(spName, (Convert.ToString(EX.Message) + "send Sms Error"), Mobj.intCusID, null, null);
                    }
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Mobj.intCusID, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return intStatus;
        }

        public ArrayList EmployeeRegisterCustomerHomepages(PrimaryInformationMl Mobj, string spName)
        {
            SqlParameter[] parm = new SqlParameter[30];

            int status = 0;
            ArrayList arrayList = new ArrayList();
            SqlDataReader reader;
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            Smtpemailsending smtp = new Smtpemailsending();
            int? intStatus = 0;
            DateTime dtTime = DateTime.ParseExact(Mobj.dtDOB, "dd-MM-yyyy", null);
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            string strMobileVerificationCode = (new Random()).Next(10000, 99999).ToString();
            try
            {

                parm[0] = new SqlParameter("@CasteID", SqlDbType.Int);
                parm[0].Value = Mobj.intCasteID;
                parm[1] = new SqlParameter("@CountryID", SqlDbType.Int);
                parm[1].Value = Mobj.intCountryLivingID;
                parm[2] = new SqlParameter("@GenderID", SqlDbType.Int);
                parm[2].Value = Mobj.intGenderID;
                parm[3] = new SqlParameter("@MobileCode", SqlDbType.Int);
                parm[3].Value = Mobj.intMobileCode;
                parm[4] = new SqlParameter("@LandCode", SqlDbType.Int);
                parm[4].Value = Mobj.intLandCode;
                parm[5] = new SqlParameter("@MotherTongueID", SqlDbType.Int);
                parm[5].Value = Mobj.intMotherTongueID;
                parm[6] = new SqlParameter("@ReligionID", SqlDbType.Int);
                parm[6].Value = Mobj.intReligionID;
                parm[7] = new SqlParameter("@AreaCode", SqlDbType.VarChar);
                parm[7].Value = Mobj.strAreaCode;
                parm[8] = new SqlParameter("@Email", SqlDbType.VarChar);
                parm[8].Value = Mobj.strEmail;
                parm[9] = new SqlParameter("@FirstName", SqlDbType.VarChar);
                parm[9].Value = Mobj.strFirstName;
                parm[10] = new SqlParameter("@LandNo", SqlDbType.VarChar);
                parm[10].Value = Mobj.strLandNo;
                parm[11] = new SqlParameter("@LastName", SqlDbType.VarChar);
                parm[11].Value = Mobj.strLastName;
                parm[12] = new SqlParameter("@MobileNo", SqlDbType.VarChar);
                parm[12].Value = Mobj.strMobileNo;
                parm[13] = new SqlParameter("@Password", SqlDbType.VarChar);
                parm[13].Value = Commonclass.Encrypt(Mobj.strPassword);
                parm[14] = new SqlParameter("@DateOfBirth", SqlDbType.DateTime);
                // parm[14].Value = Mobj.dtDOB;
                parm[14].Value = dtTime;
                parm[15] = new SqlParameter("@Status", SqlDbType.Int);
                parm[15].Direction = ParameterDirection.Output;
                parm[16] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
                parm[16].Direction = ParameterDirection.Output;
                parm[17] = new SqlParameter("@Rowcount", SqlDbType.Int);
                parm[17].Direction = ParameterDirection.Output;
                parm[18] = new SqlParameter("@ProfileRegisteredBy", SqlDbType.Int);
                parm[18].Value = Mobj.intProfileRegisteredBy;
                parm[19] = new SqlParameter("@KMPLID", SqlDbType.VarChar);
                parm[19].Value = Mobj.strKMPLID;
                parm[20] = new SqlParameter("@MobileVerificationCode", SqlDbType.VarChar);
                parm[20].Value = strMobileVerificationCode;
                parm[21] = new SqlParameter("@EmpID", SqlDbType.BigInt);
                parm[21].Value = Mobj.intEmpID;
                parm[22] = new SqlParameter("@ID", SqlDbType.Int);
                parm[22].Value = Mobj.ID;
                parm[23] = new SqlParameter("@IsCustomer", SqlDbType.Int);
                parm[23].Value = Mobj.IsCustomer;
                parm[24] = new SqlParameter("@IsCustomerPostedBY", SqlDbType.Int);
                parm[24].Value = Mobj.intCustPostedBY;
                parm[25] = new SqlParameter("@intSubCasteID", SqlDbType.Int);
                parm[25].Value = Mobj.intSubCasteID;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        smtp.profile_name = (reader["profile_name"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("profile_name")) : string.Empty;
                        smtp.recipients = (reader["recipients"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("recipients")) : string.Empty;
                        smtp.body = (reader["body"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("body")) : string.Empty;
                        smtp.subject = (reader["subject"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("subject")) : string.Empty;
                        smtp.body_format = (reader["body_format"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("body_format")) : string.Empty;
                        smtp.Status = (reader["Status"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Status")) : status;
                        smtp.CustID = (reader["Cust"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Cust")) : 0;
                        smtp.ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : string.Empty;

                        li.Add(smtp);
                        arrayList.Add(smtp);
                    }
                }
                if (Mobj.intEmpID == null)
                {
                    Commonclass.SendMailSmtpMethod(li, "info");
                }
                intStatus = smtp.Status;
                reader.Close();
                if (intStatus.Equals(1))
                {
                    ServiceSoapClient cc = new ServiceSoapClient();
                    try
                    {
                        string result = cc.SendTextSMS("ykrishna", "summary$1", Mobj.strMobileNo.ToString().Trim(), "Hi " + Mobj.strFirstName + ", Your verification code with www.kaakateeya.com is " + strMobileVerificationCode + " Please enter this code to confirm your Registration.", "smscntry");
                    }
                    catch (Exception EX)
                    {
                        Commonclass.ApplicationErrorLog(spName, (Convert.ToString(EX.Message) + "send Sms Error"), Mobj.intCusID, null, null);
                    }
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Mobj.intCusID, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return arrayList;
        }


        public ArrayList EmployeeRegisterCustomerHomepages_Brokerentry(PrimaryInformationMl Mobj, string spName)
        {
            SqlParameter[] parm = new SqlParameter[30];

            int status = 0;
            ArrayList arrayList = new ArrayList();
            SqlDataReader reader;
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            Smtpemailsending smtp = new Smtpemailsending();
            int? intStatus = 0;
            DateTime dtTime = DateTime.ParseExact(Mobj.dtDOB, "dd-MM-yyyy", null);
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            string strMobileVerificationCode = (new Random()).Next(10000, 99999).ToString();
            try
            {

                parm[0] = new SqlParameter("@CasteID", SqlDbType.Int);
                parm[0].Value = Mobj.intCasteID;
                parm[1] = new SqlParameter("@CountryID", SqlDbType.Int);
                parm[1].Value = Mobj.intCountryLivingID;
                parm[2] = new SqlParameter("@GenderID", SqlDbType.Int);
                parm[2].Value = Mobj.intGenderID;
                parm[3] = new SqlParameter("@MobileCode", SqlDbType.Int);
                parm[3].Value = Mobj.intMobileCode;
                parm[4] = new SqlParameter("@LandCode", SqlDbType.Int);
                parm[4].Value = Mobj.intLandCode;
                parm[5] = new SqlParameter("@MotherTongueID", SqlDbType.Int);
                parm[5].Value = Mobj.intMotherTongueID;
                parm[6] = new SqlParameter("@ReligionID", SqlDbType.Int);
                parm[6].Value = Mobj.intReligionID;
                parm[7] = new SqlParameter("@AreaCode", SqlDbType.VarChar);
                parm[7].Value = Mobj.strAreaCode;
                parm[8] = new SqlParameter("@Email", SqlDbType.VarChar);
                parm[8].Value = Mobj.strEmail;
                parm[9] = new SqlParameter("@FirstName", SqlDbType.VarChar);
                parm[9].Value = Mobj.strFirstName;
                parm[10] = new SqlParameter("@LandNo", SqlDbType.VarChar);
                parm[10].Value = Mobj.strLandNo;
                parm[11] = new SqlParameter("@LastName", SqlDbType.VarChar);
                parm[11].Value = Mobj.strLastName;
                parm[12] = new SqlParameter("@MobileNo", SqlDbType.VarChar);
                parm[12].Value = Mobj.strMobileNo;
                parm[13] = new SqlParameter("@Password", SqlDbType.VarChar);
                parm[13].Value = Commonclass.Encrypt(Mobj.strPassword);
                parm[14] = new SqlParameter("@DateOfBirth", SqlDbType.DateTime);
                // parm[14].Value = Mobj.dtDOB;
                parm[14].Value = dtTime;
                parm[15] = new SqlParameter("@Status", SqlDbType.Int);
                parm[15].Direction = ParameterDirection.Output;
                parm[16] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
                parm[16].Direction = ParameterDirection.Output;
                parm[17] = new SqlParameter("@Rowcount", SqlDbType.Int);
                parm[17].Direction = ParameterDirection.Output;
                parm[18] = new SqlParameter("@ProfileRegisteredBy", SqlDbType.Int);
                parm[18].Value = Mobj.intProfileRegisteredBy;
                parm[19] = new SqlParameter("@KMPLID", SqlDbType.VarChar);
                parm[19].Value = Mobj.strKMPLID;
                parm[20] = new SqlParameter("@MobileVerificationCode", SqlDbType.VarChar);
                parm[20].Value = strMobileVerificationCode;
                parm[21] = new SqlParameter("@EmpID", SqlDbType.BigInt);
                parm[21].Value = Mobj.intEmpID;
                parm[22] = new SqlParameter("@ID", SqlDbType.Int);
                parm[22].Value = Mobj.ID;
                parm[23] = new SqlParameter("@IsCustomer", SqlDbType.Int);
                parm[23].Value = Mobj.IsCustomer;
                parm[24] = new SqlParameter("@IsCustomerPostedBY", SqlDbType.Int);
                parm[24].Value = Mobj.intCustPostedBY;

                parm[25] = new SqlParameter("@intSubCasteID", SqlDbType.Int);
                parm[25].Value = Mobj.intSubCasteID;
                parm[26] = new SqlParameter("@BrokerNameID", SqlDbType.Int);
                parm[26].Value = Mobj.BrokerNameID;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        smtp.profile_name = (reader["profile_name"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("profile_name")) : string.Empty;
                        smtp.recipients = (reader["recipients"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("recipients")) : string.Empty;
                        smtp.body = (reader["body"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("body")) : string.Empty;
                        smtp.subject = (reader["subject"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("subject")) : string.Empty;
                        smtp.body_format = (reader["body_format"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("body_format")) : string.Empty;
                        smtp.Status = (reader["Status"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Status")) : status;
                        smtp.CustID = (reader["Cust"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Cust")) : 0;
                        smtp.ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : string.Empty;

                        li.Add(smtp);
                        arrayList.Add(smtp);
                    }
                }
                if (Mobj.intEmpID == null)
                {
                    Commonclass.SendMailSmtpMethod(li, "info");
                }
                intStatus = smtp.Status;
                reader.Close();
                if (intStatus.Equals(1))
                {
                    ServiceSoapClient cc = new ServiceSoapClient();
                    try
                    {
                        string result = cc.SendTextSMS("ykrishna", "summary$1", Mobj.strMobileNo.ToString().Trim(), "Hi " + Mobj.strFirstName + ", Your verification code with www.kaakateeya.com is " + strMobileVerificationCode + " Please enter this code to confirm your Registration.", "smscntry");
                    }
                    catch (Exception EX)
                    {
                        Commonclass.ApplicationErrorLog(spName, (Convert.ToString(EX.Message) + "send Sms Error"), Mobj.intCusID, null, null);
                    }
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Mobj.intCusID, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return arrayList;
        }



        public int DgetCustomerRegProfileDetails_Myprofile(UpdatePersonaldetails Mobj, string spName)
        {
            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[5];
            SqlDataReader reader = null;
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@CustomerID", SqlDbType.Int);
                parm[0].Value = Mobj.intCusID;
                parm[1] = new SqlParameter("@t_CustProfileDetails", SqlDbType.Structured);
                parm[1].Value = Mobj.dtTableValues;
                parm[2] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
                parm[2].Direction = ParameterDirection.Output;
                parm[3] = new SqlParameter("@i_Status", SqlDbType.Int);
                parm[3].Direction = ParameterDirection.Output;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                reader.Close();
                if (string.Compare(parm[3].Value.ToString(), System.DBNull.Value.ToString()) != 0)
                {
                    intStatus = Convert.ToInt32(parm[3].Value);
                }
                else
                {
                    intStatus = 0;
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Mobj.intCusID, null, null);
            }
            finally
            {
              
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return intStatus;
        }

        public ArrayList CustomermissindDatagetting(long? CustomerCustID, string strSpname)
        {
            DataSet dsMissingfields = new DataSet();
            SqlDataAdapter daParentDetails = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(strSpname, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerCustID", CustomerCustID);
                daParentDetails.SelectCommand = cmd;
                daParentDetails.Fill(dsMissingfields);
            }
            catch (Exception Ex)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(Ex.Message), @CustomerCustID, null, null);
            }
            finally
            {
               
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayList(dsMissingfields);
        }

        //Logged as  Customers

        public string BgetPassword(string Username)
        {
            DataSet dsSet = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            string strResult = null;
            string strPassword = null;
            string DecPassword = null;
            int status = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Usp_GetPasswordforlogged]", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@profileid", Username);
                SqlParameter outputParamStatus = cmd.Parameters.Add("@status", SqlDbType.Int);
                outputParamStatus.Direction = ParameterDirection.Output;
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(dsSet);
                if (Convert.ToInt32(cmd.Parameters[1].Value) == 0)
                {
                    status = 0;
                }
                else
                {
                    status = Convert.ToInt32(cmd.Parameters[1].Value);
                }
                if (dsSet != null && dsSet.Tables.Count > 0)
                {
                    strPassword = !string.IsNullOrEmpty(dsSet.Tables[0].Rows[0]["Password"].ToString()) ? dsSet.Tables[0].Rows[0]["Password"].ToString() : null;
                    DecPassword = !string.IsNullOrEmpty(strPassword) ? Commonclass.Decrypt(strPassword) : null;
                }
            }
            catch (Exception Ex)
            {
                Commonclass.ApplicationErrorLog("Usp_GetPasswordforlogged", Convert.ToString(Ex.Message), null, null, null);
            }
            finally
            {
               
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            //  return Commonclass.convertdataTableToArrayList(dsSet);
            strResult = "Password :" + strPassword + ";" + "DecPassword :" + DecPassword;
            SqlConnection.ClearAllPools();
            return strResult;
        }

        public ArrayList DGetloginCustinformation(string Username, string Password, int? iflag)
        {
            DataSet dataSet = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            int status = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[Usp_CheckCustLogin]", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@Password", Password);
                cmd.Parameters.AddWithValue("@iflag", iflag);
                SqlParameter outputParamStatus = cmd.Parameters.Add("@Status", SqlDbType.Int);
                outputParamStatus.Direction = ParameterDirection.Output;
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(dataSet);
                if (Convert.ToInt32(cmd.Parameters[2].Value) == 1)
                {
                    status = 1;
                }
                else
                {
                    status = 0;
                }

            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog("Usp_CheckCustLogin", Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayList(dataSet);
        }

        public int CheckUserPwd(string Username, string Password)
        {
            DataSet ds = new DataSet();
            int intstatus = 0;
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[usp_checkuserpwd]", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", Username);
                cmd.Parameters.AddWithValue("@Password", Commonclass.Encrypt(Password));
                SqlParameter outputParamStatus = cmd.Parameters.Add("@Status", SqlDbType.Int);
                outputParamStatus.Direction = ParameterDirection.Output;

                da.SelectCommand = cmd;
                da.Fill(ds);
                if (Convert.ToInt32(cmd.Parameters[2].Value) == 1)
                {
                    intstatus = 1;
                }
                else
                {
                    intstatus = 0;
                }

            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog("[dbo].[usp_checkuserpwd]", Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return intstatus;
        }


        public int UpdateEmplogintoCustomersiteDal(int empid, string ProfileID, string Narration, string spname)
        {
            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[4];
            SqlDataReader reader = null;
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parm[0].Value = empid;
                parm[1] = new SqlParameter("@ProfileID", SqlDbType.VarChar);
                parm[1].Value = ProfileID;
                parm[2] = new SqlParameter("@Narration", SqlDbType.VarChar);
                parm[2].Value = Narration;
                parm[3] = new SqlParameter("@Status", SqlDbType.Int);
                parm[3].Direction = ParameterDirection.Output;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spname, parm);
                reader.Close();
                if (string.Compare(parm[3].Value.ToString(), System.DBNull.Value.ToString()) != 0)
                {
                    intStatus = Convert.ToInt32(parm[3].Value);
                }
                else
                {
                    intStatus = 0;
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), Convert.ToInt64(ProfileID), null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return intStatus;
        }
    }
}

