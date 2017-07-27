using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using WebapiApplication.ML;
using System.Data.SqlClient;
using System.Data;
using KaakateeyaDAL;

namespace WebapiApplication.DAL
{
    public class smallPageDal
    {
        internal ArrayList getMacIpValuesDal(macIPInput mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[5];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet ds = new DataSet();
            try
            {
                parm[0] = new SqlParameter("@Religion", SqlDbType.Int);
                parm[0].Value = mobj.Religion;
                parm[1] = new SqlParameter("@BranchID", SqlDbType.Int);
                parm[1].Value = mobj.BranchID;
                parm[2] = new SqlParameter("@Ipaddress", SqlDbType.VarChar);
                parm[2].Value = mobj.Ipaddress;
                parm[3] = new SqlParameter("@flag", SqlDbType.Int);
                parm[3].Value = mobj.flag;
                parm[4] = new SqlParameter("@Status", SqlDbType.Int);
                parm[4].Direction = ParameterDirection.Output;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        internal Tuple<int, ArrayList> matchMeetingEntryFormDal(matchMeetingEntryForm Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[16];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet ds = new DataSet();
            int intStatus = 0;
            try
            {
                parm[0] = new SqlParameter("@BrideCustID", SqlDbType.BigInt);
                parm[0].Value = Mobj.BrideprofileID;
                parm[1] = new SqlParameter("@GroomCustID", SqlDbType.BigInt);
                parm[1].Value = Mobj.GroomprofileID;
                parm[2] = new SqlParameter("@MatchMeeting", SqlDbType.DateTime);
                parm[2].Value = Mobj.MeetingDate;
                parm[3] = new SqlParameter("@Place", SqlDbType.VarChar);
                parm[3].Value = Mobj.MeetingPlace;
                parm[4] = new SqlParameter("@MembersJoiningfromBride", SqlDbType.VarChar);
                parm[4].Value = Mobj.BrideRelationName;
                parm[5] = new SqlParameter("@MembersjoiningfromGroom", SqlDbType.VarChar);
                parm[5].Value = Mobj.GroomRelaionName;
                parm[6] = new SqlParameter("@MatchMeetingArrangedBy", SqlDbType.BigInt);
                parm[6].Value = Mobj.EmpID;
                parm[7] = new SqlParameter("@Notes", SqlDbType.VarChar, 8000);
                parm[7].Value = Mobj.Notes;
                parm[8] = new SqlParameter("@EmpID", SqlDbType.BigInt);
                parm[8].Value = Mobj.CreatedEMPID;
                parm[9] = new SqlParameter("@BCode", SqlDbType.Int);
                parm[9].Value = Mobj.BCode;
                parm[10] = new SqlParameter("@BLand", SqlDbType.VarChar, 100);
                parm[10].Value = Mobj.BLand;
                parm[11] = new SqlParameter("@BMobile", SqlDbType.VarChar, 100);
                parm[11].Value = Mobj.BMobile;
                parm[12] = new SqlParameter("@GCode", SqlDbType.Int);
                parm[12].Value = Mobj.GCode;
                parm[13] = new SqlParameter("@GLand", SqlDbType.VarChar, 100);
                parm[13].Value = Mobj.GLand;
                parm[14] = new SqlParameter("@GMobile", SqlDbType.VarChar, 100);
                parm[14].Value = Mobj.GMobile;
                parm[15] = new SqlParameter("@Status", SqlDbType.Int);
                parm[15].Direction = ParameterDirection.Output;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(parm[15].Value.ToString(), System.DBNull.Value.ToString()) == 0)
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[15].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return new Tuple<int, ArrayList>(intStatus, Commonclass.convertdataTableToArrayListTable(ds));
        }

        public Tuple<int, ArrayList> EmpDetailsNew(string profileID, int BridegroomFlag, string spname)
        {
            SqlParameter[] parm = new SqlParameter[4];
            int intStatus = 0;
            string strErrorMsg = "";
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet ds = new DataSet();
            try
            {
                parm[0] = new SqlParameter("@ProfileID", SqlDbType.VarChar, 20);
                parm[0].Value = profileID;
                parm[1] = new SqlParameter("@Value", SqlDbType.Int);
                parm[1].Value = BridegroomFlag;
                parm[2] = new SqlParameter("@Status", SqlDbType.Int);
                parm[2].Direction = ParameterDirection.Output;
                parm[3] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
                parm[3].Direction = ParameterDirection.Output;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), Convert.ToString(parm[2].Value)).Equals(0))
                {
                    intStatus = 0;
                    strErrorMsg = "";
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[2].Value);
                    strErrorMsg = "";
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }

            return new Tuple<int, ArrayList>(intStatus, Commonclass.convertdataTableToArrayListTable(ds));
        }

        public Tuple<ArrayList, int, int, int, int> EmpDetailsNew(int? brideCustID, int? groomCustID, string spname)
        {
            SqlParameter[] param = new SqlParameter[3];
            int intStatus = 0;
            int CasteStatus = 0;
            int FromStatus = 0;
            int ToStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet ds = new DataSet();
            try
            {
                param[0] = new SqlParameter("@BideCustID", SqlDbType.BigInt);
                param[0].Value = brideCustID;
                param[1] = new SqlParameter("@GroomCustID", SqlDbType.BigInt);
                param[1].Value = groomCustID;
                param[2] = new SqlParameter("@Status", SqlDbType.Int);
                param[2].Direction = ParameterDirection.Output;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, param);
                if (string.Compare(param[2].Value.ToString(), System.DBNull.Value.ToString()) == 0)
                {
                    intStatus = 0;
                    CasteStatus = 0;
                    FromStatus = 0;
                    ToStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(param[2].Value);
                    CasteStatus = Convert.ToInt32(ds.Tables[3].Rows[0]["caste"]);
                    FromStatus = Convert.ToInt32(ds.Tables[3].Rows[0]["BrideStatus"]);
                    ToStatus = Convert.ToInt32(ds.Tables[3].Rows[0]["GroomStatus"]);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return new Tuple<ArrayList, int, int, int, int>(Commonclass.convertdataTableToArrayListTable(ds), intStatus, CasteStatus, FromStatus, ToStatus);
        }

        internal int checkMarketingTicketDal(string ticketID, string spname)
        {
            SqlParameter[] parm = new SqlParameter[2];
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet ds = new DataSet();
            try
            {
                parm[0] = new SqlParameter("@ticketid", SqlDbType.VarChar, 20);
                parm[0].Value = ticketID;
                parm[1] = new SqlParameter("@status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;
             
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), Convert.ToString(parm[1].Value)).Equals(0))
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[1].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }

            return intStatus;
        }

        internal int brokerFormInsertDal(brokerEntryForm mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[7];
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet ds = new DataSet();
            try
            {
                parm[0] = new SqlParameter("@v_Name", SqlDbType.VarChar, 20);
                parm[0].Value = mobj.name;
                parm[1] = new SqlParameter("@v_Place", SqlDbType.VarChar, 20);
                parm[1].Value = mobj.place;
                parm[2] = new SqlParameter("@v_Email", SqlDbType.VarChar, 20);
                parm[2].Value = mobj.email;
                parm[3] = new SqlParameter("@v_Mobilenumber", SqlDbType.VarChar, 20);
                parm[3].Value = mobj.mobileNumber;
                parm[4] = new SqlParameter("@i_Flag", SqlDbType.Int);
                parm[4].Value = mobj.flag;
                parm[5] = new SqlParameter("@i_Brokerid", SqlDbType.Int);
                parm[5].Value = mobj.brokerId;
                parm[6] = new SqlParameter("@status", SqlDbType.Int);
                parm[6].Direction = ParameterDirection.Output;

                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), Convert.ToString(parm[6].Value)).Equals(0))
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[6].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }

            return intStatus;
        }

        internal List<MyassignedPhotosOutPut> myAssignedPhotosDal(myassignedPhotoInputMl Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[5];
            long? lnull = null;
            int? inull = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            List<MyassignedPhotosOutPut> li = new List<MyassignedPhotosOutPut>();
            try
            {
                parm[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parm[0].Value = Mobj.I_EmpID;
                parm[1] = new SqlParameter("@vc_ProfileId", SqlDbType.VarChar);
                parm[1].Value = Mobj.StrProfileID;
                parm[2] = new SqlParameter("@dt_StartDate", SqlDbType.DateTime);
                parm[2].Value = Mobj.StartDate;
                parm[3] = new SqlParameter("@dt_EndDate", SqlDbType.DateTime);
                parm[3].Value = Mobj.EnDate;
                parm[4] = new SqlParameter("@i_PageFrom", SqlDbType.Int);
                parm[4].Value = Mobj.PageFrom;
                parm[5] = new SqlParameter("@i_PageTo", SqlDbType.Int);
                parm[5].Value = Mobj.PageTo;
                SqlDataReader reader;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spname, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MyassignedPhotosOutPut Mobjresult = new MyassignedPhotosOutPut();
                        {
                            Mobjresult.Row = (reader["Row"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Row")) : lnull;
                            Mobjresult.TotalRows = (reader["TotalRows"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TotalRows")) : inull;
                            Mobjresult.Totalpages = (reader["Totalpages"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Totalpages")) : inull;
                            Mobjresult.Cust_ID = (reader["Cust_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_ID")) : lnull;
                            Mobjresult.ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : string.Empty;
                            Mobjresult.FirstName = (reader["FirstName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FirstName")) : string.Empty;
                            Mobjresult.LastName = (reader["LastName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("LastName")) : string.Empty;
                            Mobjresult.UploadedDate = (reader["UploadedDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("UploadedDate")) : string.Empty;
                            Mobjresult.AssignedDate = (reader["AssignedDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("AssignedDate")) : string.Empty;
                            Mobjresult.PhotoName = (reader["PhotoName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoName")) : string.Empty;
                            Mobjresult.Cust_Photos_ID = (reader["Cust_Photos_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_Photos_ID")) : lnull;
                            Mobjresult.AssignEmpName = (reader["AssignEmpName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("AssignEmpName")) : string.Empty;
                            Mobjresult.paid = (reader["IsPaidMember"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsPaidMember")) : inull;
                            Mobjresult.Uploaded_by = (reader["Uploadedby"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Uploadedby")) : string.Empty;
                            Mobjresult.Uploaded_branch = (reader["UploadedBranch"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("UploadedBranch")) : string.Empty;
                        }
                        li.Add(Mobjresult);
                    }
                }
                reader.Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }

            return li;
        }
    }
}






