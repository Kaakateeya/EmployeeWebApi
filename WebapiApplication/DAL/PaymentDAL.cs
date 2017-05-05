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
    public class PaymentDAL
    {
        public List<Paymentselect> GetPaymentDetails(long? CustID, string spName)
        {
            SqlParameter[] parm = new SqlParameter[3];
            SqlDataReader reader = null;
            List<Paymentselect> arrayList = new List<Paymentselect>();
            int? intnull = null;
            double? floatnull = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@i_FromCustID", SqlDbType.BigInt);
                parm[0].Value = CustID;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Paymentselect payment = new Paymentselect();
                        {

                            payment.MembershipName = reader["MembershipName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("MembershipName")) : null;
                            payment.Emp_Membership_ID = reader["Emp_Membership_ID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Emp_Membership_ID")) : intnull;
                            payment.MemberShipDuration = reader["MemberShipDuration"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("MemberShipDuration")) : intnull;
                            payment.Cust_MemberShip_Discount_ID = reader["Cust_MemberShip_Discount_ID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Cust_MemberShip_Discount_ID")) : intnull;
                            payment.DiscountAmount = reader["DiscountAmount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("DiscountAmount")) : intnull;
                            payment.AllottedServicePoints = reader["AllottedServicePoints"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("AllottedServicePoints")) : intnull;
                            payment.MembershipAmount = reader["MembershipAmount"] != DBNull.Value ? reader.GetDouble(reader.GetOrdinal("MembershipAmount")) : floatnull;
                            payment.onlineaccess = reader["onlineaccess"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("onlineaccess")) : null;
                            payment.offlineaccess = reader["offlineaccess"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("offlineaccess")) : null;
                            payment.Ppluspath = reader["Ppluspath"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Ppluspath")) : null;
                            payment.Ppath = reader["Ppath"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Ppath")) : null;

                        }
                        arrayList.Add(payment);
                    }
                }
                reader.NextResult();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Paymentselect payment = new Paymentselect();
                        {
                            payment.MembershipName = reader["MembershipName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("MembershipName")) : null;
                            payment.Emp_Membership_ID = reader["Emp_Membership_ID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Emp_Membership_ID")) : intnull;
                            payment.MemberShipDuration = reader["MemberShipDuration"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("MemberShipDuration")) : intnull;
                            payment.Cust_MemberShip_Discount_ID = reader["Cust_MemberShip_Discount_ID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Cust_MemberShip_Discount_ID")) : intnull;
                            payment.DiscountAmount = reader["DiscountAmount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("DiscountAmount")) : intnull;
                            payment.AllottedServicePoints = reader["AllottedServicePoints"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("AllottedServicePoints")) : intnull;
                            payment.AccessFeature = reader["AccessFeature"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("AccessFeature")) : intnull;
                            payment.MembershipAmount = reader["MembershipAmount"] != DBNull.Value ? reader.GetDouble(reader.GetOrdinal("MembershipAmount")) : floatnull;
                        }

                        arrayList.Add(payment);
                    }
                }
                reader.Close();

            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), CustID, null, null);
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
            return arrayList;
        }

        public string CustomerPaymentStatus(long? CustomerCustID, string spName)
        {
            DataSet ds = new DataSet();
            string status = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            SqlParameter[] parm = new SqlParameter[5];
            try
            {
                parm[0] = new SqlParameter("@CustID", SqlDbType.BigInt);
                parm[0].Value = CustomerCustID;
                parm[1] = new SqlParameter("@Status", SqlDbType.VarChar, 8000);
                parm[1].Direction = ParameterDirection.Output;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
                status = parm[1].Value.ToString();
            }
            catch (Exception Ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(Ex.Message), Convert.ToInt32(CustomerCustID), null, null);
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
            return status;
        }

        public int InsertPaymentDetails(PaymentMasterMl Mobj, string spName)
        {
            int intStatus = 0;
            DataSet dset = new DataSet();
            SqlParameter[] parm = new SqlParameter[8];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@custID", SqlDbType.BigInt);
                parm[0].Value = Mobj.intCustID;
                parm[1] = new SqlParameter("@MembershipID", SqlDbType.BigInt);
                parm[1].Value = Mobj.intMembershipID;
                parm[2] = new SqlParameter("@MembershipDiscountID", SqlDbType.BigInt);
                parm[2].Value = Mobj.DiscountID;
                parm[3] = new SqlParameter("@Points", SqlDbType.Int);
                parm[3].Value = Mobj.Points;
                parm[4] = new SqlParameter("@MembershipName", SqlDbType.VarChar, 100);
                parm[4].Value = Mobj.MembershipName;
                parm[5] = new SqlParameter("@Duration", SqlDbType.Int);
                parm[5].Value = Mobj.Duration;
                parm[6] = new SqlParameter("@Amount", SqlDbType.VarChar, 100);
                parm[6].Value = Mobj.MembershipAmount;
                parm[7] = new SqlParameter("@Status", SqlDbType.Int);
                parm[7].Direction = ParameterDirection.Output;
                dset = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);

                if (string.Compare(System.DBNull.Value.ToString(), parm[7].Value.ToString()) == 0)
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[7].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt32(Mobj.intCustID), null, null);
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
            return intStatus;
        }

        public ArrayList DgetProfilePaymentDetails(long? intProfileID, int? Isonline, int? flag, int? intMembershipID, string taxpaid)
        {
            int? intStatus = 0;
            DataSet dsPayment = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            SqlParameter[] parm = new SqlParameter[7];

            try
            {
                parm[0] = new SqlParameter("@ProfileID", SqlDbType.BigInt);
                parm[0].Value = intProfileID;
                parm[1] = new SqlParameter("@flag", SqlDbType.Int);
                parm[1].Value = flag;
                parm[2] = new SqlParameter("@MemberShipID", SqlDbType.Int);
                parm[2].Value = intMembershipID;
                parm[3] = new SqlParameter("@Isonline", SqlDbType.Int);
                parm[3].Value = Isonline;
                parm[4] = new SqlParameter("@Status", SqlDbType.Int);
                parm[4].Direction = ParameterDirection.Output;
                parm[5] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
                parm[5].Direction = ParameterDirection.Output;
                parm[6] = new SqlParameter("@taxpaid", SqlDbType.VarChar, 1000);
                parm[6].Value = taxpaid;
                dsPayment = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "usp_Payment_getProfilePaymentDetails", parm);

                if (string.Compare(System.DBNull.Value.ToString(), parm[4].Value.ToString()) == 0) { intStatus = 0; }
                else { intStatus = Convert.ToInt32(parm[4].Value); }

            }
            catch (Exception EX) { Commonclass.ApplicationErrorLog("usp_Payment_getProfilePaymentDetails", Convert.ToString(EX.Message), Convert.ToInt32(intProfileID), null, null); }
            finally
            {
                //SQLHelper.GetSQLConnection().Close();
                //SqlConnection.ClearAllPools();
                //SQLHelper.GetSQLConnection().Dispose();
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }

            if (dsPayment.Tables.Count == 0)
                dsPayment = null;
            return Commonclass.convertdataTableToArrayList(dsPayment);
        }

        public int CustomerInsertPaymentDetilsInfo(CustomerPaymentML Mobj, string spName)
        {
            int IntStatus = 0;
            DataSet dsPaymentDetails = new DataSet();
            int? Istatus = null;
            int? inull = null;
            List<Smtpemailsending> li = new List<Smtpemailsending>();

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            SqlDataAdapter daPaymentDetails = new SqlDataAdapter();
            try
            {
                SqlCommand cmd = new SqlCommand(spName, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dtPaymentDetails", Mobj.dtPaymentDetails);
                cmd.Parameters.AddWithValue("@Isonline", Mobj.Isonline);
                cmd.Parameters.AddWithValue("@PaysmsID", Mobj.PaysmsID);
                SqlParameter outputParamStatus = cmd.Parameters.Add("@Status", SqlDbType.Int);
                outputParamStatus.Direction = ParameterDirection.Output;
                SqlParameter outputParamErrorLog = cmd.Parameters.Add("@ErrorMsg", SqlDbType.VarChar, 1000);
                outputParamErrorLog.Direction = ParameterDirection.Output;
                daPaymentDetails.SelectCommand = cmd;
                daPaymentDetails.Fill(dsPaymentDetails);

                if (dsPaymentDetails != null && dsPaymentDetails.Tables.Count > 3 && dsPaymentDetails.Tables[3] != null)
                {
                    for (int i = 0; i < dsPaymentDetails.Tables[3].Rows.Count; i++)
                    {
                        Smtpemailsending smtp = new Smtpemailsending();
                        {
                            smtp.profile_name = dsPaymentDetails.Tables[3].Columns.Contains("profile_name") && !string.IsNullOrEmpty(dsPaymentDetails.Tables[3].Rows[i]["profile_name"].ToString()) ? dsPaymentDetails.Tables[3].Rows[i]["profile_name"].ToString() : string.Empty;
                            smtp.recipients = dsPaymentDetails.Tables[3].Columns.Contains("recipients") && !string.IsNullOrEmpty(dsPaymentDetails.Tables[3].Rows[i]["recipients"].ToString()) ? dsPaymentDetails.Tables[3].Rows[i]["recipients"].ToString() : string.Empty;
                            smtp.body = dsPaymentDetails.Tables[3].Columns.Contains("body") && !string.IsNullOrEmpty(dsPaymentDetails.Tables[3].Rows[i]["body"].ToString()) ? dsPaymentDetails.Tables[3].Rows[i]["body"].ToString() : string.Empty;
                            smtp.subject = dsPaymentDetails.Tables[3].Columns.Contains("subject") && !string.IsNullOrEmpty(dsPaymentDetails.Tables[3].Rows[i]["subject"].ToString()) ? dsPaymentDetails.Tables[3].Rows[i]["subject"].ToString() : string.Empty;
                            smtp.body_format = dsPaymentDetails.Tables[3].Columns.Contains("body_format") && !string.IsNullOrEmpty(dsPaymentDetails.Tables[3].Rows[i]["body_format"].ToString()) ? dsPaymentDetails.Tables[3].Rows[i]["body_format"].ToString() : string.Empty;
                            Istatus = smtp.Status = dsPaymentDetails.Tables[3].Columns.Contains("Status") && !string.IsNullOrEmpty(dsPaymentDetails.Tables[3].Rows[i]["Status"].ToString()) ? Convert.ToInt32(dsPaymentDetails.Tables[3].Rows[i]["Status"]) : inull;
                        }
                        li.Add(smtp);
                    }
                    IntStatus = (Istatus != null && Istatus != 0) ? 1 : 0;
                    if (Mobj.PaysmsID == 1)
                    {
                        Commonclass.SendMailSmtpMethod(li, "info");
                    }
                }
                else
                {
                    if (Convert.ToInt32(cmd.Parameters[3].Value) == 1) { IntStatus = 1; }
                    else { IntStatus = 0; }
                }

            }
            catch (Exception EX) { Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null); }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            if (dsPaymentDetails.Tables.Count == 0) { dsPaymentDetails = null; }
            return IntStatus;

        }


        //New Payment Table Design  Test API

        public int CustomerInsertPaymentDetilsInfo_New(PaymentInsertML Mobj, string spName)
        {
            int IntStatus = 0;
            DataSet dsPaymentDetails = new DataSet();
            int? Istatus = null;
            int? inull = null;
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            SqlDataAdapter daPaymentDetails = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(spName, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dtPaymentDetails", Mobj.dtPaymentDetails);
                cmd.Parameters.AddWithValue("@PaysmsID", Mobj.PaysmsID);
                SqlParameter outputParamStatus = cmd.Parameters.Add("@Status", SqlDbType.Int);
                outputParamStatus.Direction = ParameterDirection.Output;
                SqlParameter outputParamErrorLog = cmd.Parameters.Add("@ErrorMsg", SqlDbType.VarChar, 1000);
                outputParamErrorLog.Direction = ParameterDirection.Output;
                daPaymentDetails.SelectCommand = cmd;
                daPaymentDetails.Fill(dsPaymentDetails);

                if (dsPaymentDetails != null && dsPaymentDetails.Tables.Count > 0 && dsPaymentDetails != null)
                {
                    for (int i = 0; i < dsPaymentDetails.Tables[0].Rows.Count; i++)
                    {
                        Smtpemailsending smtp = new Smtpemailsending();
                        {
                            smtp.profile_name = dsPaymentDetails.Tables[0].Columns.Contains("profile_name") && !string.IsNullOrEmpty(dsPaymentDetails.Tables[0].Rows[i]["profile_name"].ToString()) ? dsPaymentDetails.Tables[0].Rows[i]["profile_name"].ToString() : string.Empty;
                            smtp.recipients = dsPaymentDetails.Tables[0].Columns.Contains("recipients") && !string.IsNullOrEmpty(dsPaymentDetails.Tables[0].Rows[i]["recipients"].ToString()) ? dsPaymentDetails.Tables[0].Rows[i]["recipients"].ToString() : string.Empty;
                            smtp.body = dsPaymentDetails.Tables[0].Columns.Contains("body") && !string.IsNullOrEmpty(dsPaymentDetails.Tables[0].Rows[i]["body"].ToString()) ? dsPaymentDetails.Tables[0].Rows[i]["body"].ToString() : string.Empty;
                            smtp.subject = dsPaymentDetails.Tables[0].Columns.Contains("subject") && !string.IsNullOrEmpty(dsPaymentDetails.Tables[0].Rows[i]["subject"].ToString()) ? dsPaymentDetails.Tables[0].Rows[i]["subject"].ToString() : string.Empty;
                            smtp.body_format = dsPaymentDetails.Tables[0].Columns.Contains("body_format") && !string.IsNullOrEmpty(dsPaymentDetails.Tables[0].Rows[i]["body_format"].ToString()) ? dsPaymentDetails.Tables[0].Rows[i]["body_format"].ToString() : string.Empty;
                            Istatus = smtp.Status = dsPaymentDetails.Tables[0].Columns.Contains("Status") && !string.IsNullOrEmpty(dsPaymentDetails.Tables[0].Rows[i]["Status"].ToString()) ? Convert.ToInt32(dsPaymentDetails.Tables[0].Rows[i]["Status"]) : inull;
                        }
                        li.Add(smtp);
                    }
                    IntStatus = (Istatus != null && Istatus != 0) ? 1 : 0;
                    if (Mobj.PaysmsID == 1)
                    {
                        Commonclass.SendMailSmtpMethod(li, "info");
                    }
                }
                else
                {
                    if (Convert.ToInt32(cmd.Parameters[0].Value) == 1) { IntStatus = 1; }
                    else { IntStatus = 0; }
                }

            }
            catch (Exception EX) { Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null); }
            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            if (dsPaymentDetails.Tables.Count == 0) { dsPaymentDetails = null; }
            return IntStatus;
        }

        public ArrayList ProfilePaymentDetails_Gridview(string intProfileID, string spName)
        {
            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[10];
            SqlDataReader reader;

            int? iNull = null;
            decimal? idecimal = null;

            ProfilePaymentGridView MobjpaymentGridview = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@ProfileID", SqlDbType.VarChar);
                parm[0].Value = intProfileID;
                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;
                parm[2] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
                parm[2].Direction = ParameterDirection.Output;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        MobjpaymentGridview = new ProfilePaymentGridView();
                        MobjpaymentGridview.ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : null;
                        MobjpaymentGridview.Type = (reader["Type"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Type")) : null;
                        MobjpaymentGridview.membershiptype = (reader["membershiptype"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("membershiptype")) : null;
                        MobjpaymentGridview.AgreedAmount = (reader["AgreedAmount"]) != DBNull.Value ? reader.GetDecimal(reader.GetOrdinal("AgreedAmount")) : idecimal;
                        MobjpaymentGridview.PaidAmount = (reader["PaidAmount"]) != DBNull.Value ? reader.GetDecimal(reader.GetOrdinal("PaidAmount")) : idecimal;
                        MobjpaymentGridview.PaymentDate = (reader["PaymentDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PaymentDate")) : null;
                        MobjpaymentGridview.ExpiryDate = (reader["ExpiryDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ExpiryDate")) : null;
                        MobjpaymentGridview.Allowed = (reader["Allowed"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Allowed")) : iNull;
                        MobjpaymentGridview.Used = (reader["Used"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Used")) : iNull;
                        MobjpaymentGridview.CreatedByEmpID = (reader["CreatedByEmpID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CreatedByEmpID")) : null;
                        MobjpaymentGridview.Description = (reader["Description"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Description")) : null;
                        MobjpaymentGridview.Status = (reader["Status"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Status")) : null;
                        MobjpaymentGridview.StatusBy = (reader["StatusBy"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("StatusBy")) : null;
                        MobjpaymentGridview.PaymentID = (reader["Payment_ID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Payment_ID")) : iNull;
                        MobjpaymentGridview.CustName = (reader["CustName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CustName")) : null;
                        MobjpaymentGridview.ProfileOwner = (reader["ProfileOwner"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileOwner")) : null;
                        MobjpaymentGridview.TaxPaid_Status = (reader["TaxPaid_Status"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("TaxPaid_Status")) : null;
                        arrayList.Add(MobjpaymentGridview);

                    }

                }
                reader.Close();

            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return arrayList;


        }

        public ArrayList DgetProfilePaymentDetails_NewDesigns(long? intProfileID, string spName)
        {
            int? intStatus = 0;
            DataSet dsPayment = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            SqlParameter[] parm = new SqlParameter[7];
            try
            {
                parm[0] = new SqlParameter("@ProfileID", SqlDbType.BigInt);
                parm[0].Value = intProfileID;
                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;
                parm[2] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
                parm[2].Direction = ParameterDirection.Output;

                dsPayment = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);

                if (string.Compare(System.DBNull.Value.ToString(), parm[1].Value.ToString()) == 0) { intStatus = 0; }
                else { intStatus = Convert.ToInt32(parm[1].Value); }

            }
            catch (Exception EX) { Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt32(intProfileID), null, null); }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }

            if (dsPayment.Tables.Count == 0)
                dsPayment = null;
            return Commonclass.convertdataTableToArrayList(dsPayment);
        }

    }
}