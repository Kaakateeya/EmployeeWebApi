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
        public ArrayList getMacIpValuesDal(macIPInput mobj, string spname)
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

        public Tuple<int, ArrayList> matchMeetingEntryFormDal(matchMeetingEntryForm Mobj, string spname)
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

        public int checkMarketingTicketDal(string ticketID, string spname)
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

        public int brokerFormInsertDal(brokerEntryForm mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[9];
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
                parm[6] = new SqlParameter("@BranchID", SqlDbType.Int);
                parm[6].Value = mobj.BranchID;
                parm[7] = new SqlParameter("@whatsappNumber", SqlDbType.VarChar, 20);
                parm[7].Value = mobj.whatsappNumber;
                parm[8] = new SqlParameter("@status", SqlDbType.Int);
                parm[8].Direction = ParameterDirection.Output;

                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), Convert.ToString(parm[8].Value)).Equals(0))
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[8].Value);
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

        public List<MyassignedPhotosOutPut> myAssignedPhotosDal(myassignedPhotoInputMl Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[6];
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

        public int myAssignedPhotosSubmitDal(myassignPhotoSubmit Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[6];
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet ds = new DataSet();
            try
            {
                parm[0] = new SqlParameter("@i_EmpID", SqlDbType.BigInt);
                parm[0].Value = Mobj.EmpID;
                parm[1] = new SqlParameter("@Vc_ThumbNail", SqlDbType.VarChar);
                parm[1].Value = Mobj.StrThumbNail;
                parm[2] = new SqlParameter("@Vc_FullPhoto", SqlDbType.VarChar);
                parm[2].Value = Mobj.StrFullPhoto;
                parm[3] = new SqlParameter("@Vc_ApplicationPhoto", SqlDbType.VarChar);
                parm[3].Value = Mobj.StrApplicationPhoto;
                parm[4] = new SqlParameter("@i_PhotoID", SqlDbType.BigInt);
                parm[4].Value = Mobj.PhotoID;
                parm[5] = new SqlParameter("@Status", SqlDbType.Int);
                parm[5].Direction = ParameterDirection.Output;

                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(parm[5].Value.ToString(), System.DBNull.Value.ToString()) == 0)
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[5].Value);
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

        public List<UnassignedPhotoSelect> unassignPhotoSelectDal(UnassignPhotoSelect Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[12];
            Int64? intNull = null;
            int? iNull = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            List<UnassignedPhotoSelect> li = new List<UnassignedPhotoSelect>();
            try
            {
                parm[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parm[0].Value = Mobj.iEmpID;
                parm[1] = new SqlParameter("@vc_ProfileId", SqlDbType.VarChar);
                parm[1].Value = Mobj.StrProfileID;
                parm[2] = new SqlParameter("@i_PhotoAssigned", SqlDbType.Int);
                parm[2].Value = Mobj.PhotoAssigned;
                parm[3] = new SqlParameter("@i_Gender ", SqlDbType.Int);
                parm[3].Value = Mobj.GenderID;
                parm[4] = new SqlParameter("@i_PhotoStatus", SqlDbType.Int);
                parm[4].Value = Mobj.PhotoStatus;
                parm[5] = new SqlParameter("@V_BranchID", SqlDbType.VarChar);
                parm[5].Value = Mobj.strBranch;
                parm[6] = new SqlParameter("@V_regionId", SqlDbType.VarChar);
                parm[6].Value = Mobj.strRegion;
                parm[7] = new SqlParameter("@V_casteID", SqlDbType.VarChar);
                parm[7].Value = Mobj.strCaste;
                parm[8] = new SqlParameter("@dt_StartDate", SqlDbType.DateTime);
                parm[8].Value = Mobj.StartDate;
                parm[9] = new SqlParameter("@dt_EndDate", SqlDbType.DateTime);
                parm[9].Value = Mobj.EnDate;
                parm[10] = new SqlParameter("@i_PageFrom", SqlDbType.Int);
                parm[10].Value = Mobj.intlowerBound;
                parm[11] = new SqlParameter("@i_PageTo", SqlDbType.Int);
                parm[11].Value = Mobj.intUpperBound;

                SqlDataReader reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spname, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UnassignedPhotoSelect Mobjresult = new UnassignedPhotoSelect();
                        {
                            Mobjresult.Row = (reader["Row"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Row")) : intNull;
                            Mobjresult.TotalRows = (reader["TotalRows"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TotalRows")) : iNull;
                            Mobjresult.Totalpages = (reader["Totalpages"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Totalpages")) : iNull;
                            Mobjresult.cust_id = (reader["cust_id"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("cust_id")) : intNull;
                            Mobjresult.ProfileID = (reader["profileid"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("profileid")) : string.Empty;
                            Mobjresult.CustomerName = (reader["CustomerName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CustomerName")) : string.Empty;
                            Mobjresult.OwnerName = (reader["OwnerName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("OwnerName")) : string.Empty;
                            Mobjresult.PhotosCount = (reader["OriginalPhotosCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("OriginalPhotosCount")) : iNull;
                            Mobjresult.AccepCount = (reader["AccepCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("AccepCount")) : iNull;
                            Mobjresult.RejectCount = (reader["RejectCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("RejectCount")) : iNull;
                            Mobjresult.IdS = (reader["IdS"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("IdS")) : string.Empty;
                            Mobjresult.paid = (reader["IsPaidMember"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsPaidMember")) : iNull;
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

        public int assignPhotosDal(long? Empid, string PhotoIDs, string spname)
        {
            SqlParameter[] parm = new SqlParameter[3];
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet ds = new DataSet();
            try
            {
                parm[0] = new SqlParameter("@i_EmpID", SqlDbType.BigInt);
                parm[0].Value = Empid;
                parm[1] = new SqlParameter("@Vc_PhotoIDs", SqlDbType.VarChar);
                parm[1].Value = PhotoIDs;
                parm[2] = new SqlParameter("@status", SqlDbType.Int);
                parm[2].Direction = ParameterDirection.Output;

                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(parm[2].Value.ToString(), System.DBNull.Value.ToString()) == 0)
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[2].Value);
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
        /// <summary>
        /// to get employee details
        /// </summary>
        /// <param name="uma"></param>
        /// <param date="07-08-2017"></param>
        /// <returns></returns>
        public List<GetEmployeeList> employeeListDal(GetEmployeeListRequest mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[6];
            int? inull = null;
            Int64? Lnull = null;
            double? fnull = null;
            string snull = string.Empty;
            bool? bnull = null;
            List<GetEmployeeList> liEmp = new List<GetEmployeeList>();

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            SqlDataReader reader;
            try
            {
                parm[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parm[0].Value = mobj.Empid;
                parm[1] = new SqlParameter("@V_branchID", SqlDbType.VarChar);
                parm[1].Value = mobj.BranchIDs;
                parm[2] = new SqlParameter("@i_empstatus", SqlDbType.Int);
                parm[2].Value = mobj.EmpStatus;
                parm[3] = new SqlParameter("@v_emptype", SqlDbType.VarChar);
                parm[3].Value = mobj.EmpTypeIDs;
                parm[4] = new SqlParameter("@region", SqlDbType.VarChar);
                parm[4].Value = mobj.region;
                parm[5] = new SqlParameter("@V_isLoginanywhere", SqlDbType.Bit);
                parm[5].Value = mobj.isLoginanywhere;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spname, parm);
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        GetEmployeeList Gemp = new GetEmployeeList();
                        Gemp.EmpPhoto = reader["ImgPath"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ImgPath")) : null;
                        Gemp.CreatedByEmployeeName = reader["CreatedByEmployeeName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("CreatedByEmployeeName")) : null;
                        Gemp.CreatedByID = reader["CreatedByID"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("CreatedByID")) : Lnull;
                        Gemp.Created_Date = reader["Created_Date"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Created_Date")) : null;
                        Gemp.FirstName = reader["FirstName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("FirstName")) : null;
                        Gemp.LastName = reader["LastName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("LastName")) : null;
                        Gemp.OfficialEmailID = reader["OfficialEmailID"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("OfficialEmailID")) : null;
                        Gemp.BranchID = reader["BranchID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("BranchID")) : inull;
                        Gemp.BranchesName = reader["BranchesName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("BranchesName")) : null;
                        Gemp.BranchCode = reader["BranchCode"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("BranchCode")) : null;
                        Gemp.WorkPhone = reader["WorkPhone"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("WorkPhone")) : null;
                        Gemp.OfficialContactNumber = reader["OfficialContactNumber"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("OfficialContactNumber")) : null;
                        Gemp.HomePhone = reader["HomePhone"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("HomePhone")) : null;
                        Gemp.DesignationID = reader["DesignationID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("DesignationID")) : inull;
                        Gemp.LoginLocation = reader["LoginLocation"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("LoginLocation")) : null;
                        Gemp.WorkingStartTIme = reader["WorkingStartTIme"] != DBNull.Value ? (reader.GetDateTime(reader.GetOrdinal("WorkingStartTIme"))).ToString() : null;
                        Gemp.WorkingEndTIme = reader["WorkingEndTIme"] != DBNull.Value ? (reader.GetDateTime(reader.GetOrdinal("WorkingEndTIme"))).ToString() : null;
                        Gemp.DayOff = reader["DayOff"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("DayOff")) : inull;
                        Gemp.DateOfJoining = reader["DateOfJoining"] != DBNull.Value ? (reader.GetDateTime(reader.GetOrdinal("DateOfJoining"))).ToString() : null;
                        Gemp.DateOfReleaving = reader["DateOfReleaving"] != DBNull.Value ? (reader.GetDateTime(reader.GetOrdinal("DateOfReleaving"))).ToString() : null;
                        Gemp.ReportingMngrID = reader["ReportingMngrID"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ReportingMngrID")) : Lnull;
                        Gemp.ReportingMngrName = reader["ReportingMngrName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ReportingMngrName")) : null;
                        Gemp.AnnualIncome = reader["AnnualIncome"] != DBNull.Value ? reader.GetDouble(reader.GetOrdinal("AnnualIncome")) : fnull;
                        Gemp.CountryID = reader["CountryID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CountryID")) : inull;
                        Gemp.CountryName = reader["CountryName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("CountryName")) : null;
                        Gemp.StateID = reader["StateID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("StateID")) : inull;
                        Gemp.StateName = reader["StateName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("StateName")) : null;
                        Gemp.DistrictID = reader["DistrictID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("DistrictID")) : inull;
                        Gemp.DistrictName = reader["DistrictName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("DistrictName")) : null;
                        Gemp.CityID = reader["CityID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CityID")) : inull;
                        Gemp.CityName = reader["CityName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("CityName")) : null;
                        Gemp.CityOther = reader["CityOther"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("CityOther")) : null;
                        Gemp.Address = reader["Address"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Address")) : null;
                        Gemp.EducationCategoryID = reader["EducationCategoryID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("EducationCategoryID")) : inull;
                        Gemp.EducationCategoryName = reader["EducationCategoryName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationCategoryName")) : null;
                        Gemp.EducationGroupID = reader["EducationGroupID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("EducationGroupID")) : inull;
                        Gemp.EducationGroupName = reader["EducationGroupName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationGroupName")) : null;
                        Gemp.EducationSpecializaionID = reader["EducationSpecializaionID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("EducationSpecializaionID")) : inull;
                        Gemp.EducationSpecializaionName = reader["EducationSpecializaionName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationSpecializaionName")) : null;
                        Gemp.isAdmin = reader["isAdmin"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("isAdmin")) : inull;
                        Gemp.EmpID = reader["EmpID"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("EmpID")) : Lnull;
                        Gemp.CreatedDate = reader["CreatedDate"] != DBNull.Value ? (reader.GetDateTime(reader.GetOrdinal("CreatedDate"))).ToString() : null;
                        Gemp.UserID = reader["UserID"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("UserID")) : null;
                        Gemp.Password = reader["Password"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Password")) : null;
                        Gemp.Email = reader["Email"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Email")) : null;
                        Gemp.IsActive = reader["IsActive"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsActive")) : inull;
                        Gemp.IsActiveStatus = reader["IsActiveStatus"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("IsActiveStatus")) : null;
                        Gemp.LoginStatusID = reader["LoginStatusID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("LoginStatusID")) : inull;
                        Gemp.LoginStatus = reader["LoginStatus"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("LoginStatus")) : null;
                        Gemp.isLoginanywhere = reader["isLoginanywhere"] != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("isLoginanywhere")) : bnull;

                        liEmp.Add(Gemp);
                    }
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

            return liEmp;
        }

        /// <summary>
        /// submitting employee creation form
        /// </summary>
        /// <param name="uma"></param>
        /// <param date="07-08-2017"></param>
        /// <returns></returns>


        public int employeeCreation(EmployeeCreationInput Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[4];
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet ds = new DataSet();
            try
            {
                parm[0] = new SqlParameter("@dtEmployeeData", SqlDbType.Structured);
                parm[0].Value = Mobj.dtEmployeecreation;
                parm[1] = new SqlParameter("@loggedEmpID", SqlDbType.BigInt);
                parm[1].Value = Mobj.CreatedEMPID;
                parm[2] = new SqlParameter("@EMPID", SqlDbType.BigInt);
                parm[2].Value = Mobj.EMPID;
                parm[3] = new SqlParameter("@Status", SqlDbType.Int);
                parm[3].Direction = ParameterDirection.Output;

                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[3].Value.ToString()) == 0)
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[3].Value);
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


        /// <summary>
        /// creating new userid for new employee
        /// </summary>
        /// <param name="uma"></param>
        /// <param date="08-08-2017"></param>
        /// <returns></returns>

        public string getLoginNameDal(int intHomeBrchID, string spname)
        {
            SqlParameter[] parm = new SqlParameter[1];
            string strUserID = "";
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            SqlDataReader reader = null;
            try
            {
                parm[0] = new SqlParameter("@i_BranchID", SqlDbType.Int);
                parm[0].Value = intHomeBrchID;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spname, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        strUserID = reader["LoginName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("LoginName")) : string.Empty;
                    }
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

            return strUserID;
        }

        /// <summary>
        /// to get emppassign count
        /// </summary>
        /// <param name="uma"></param>
        /// <param date="09-08-2017"></param>
        /// <returns></returns>

        public EmpAssignCounts getEmpWorkAssignCountsDal(int EmpID, string spname)
        {
            SqlParameter[] parm = new SqlParameter[1];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            SqlDataReader reader = null;
            int? inull = null;
            EmpAssignCounts mobj = new EmpAssignCounts();
            try
            {
                parm[0] = new SqlParameter("@i_empid", SqlDbType.Int);
                parm[0].Value = EmpID;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spname, parm);
                if (reader.HasRows)
                {
                  
                    while (reader.Read())
                    {
                        mobj.EMployeeID = reader["EMployeeID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("EMployeeID")) : inull;
                        mobj.servicegivencount = reader["servicegivencount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("servicegivencount")) : inull;
                        mobj.matchfollowupcount = reader["matchfollowupcount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("matchfollowupcount")) : inull;
                        mobj.marketingticketscount = reader["marketingticketscount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("marketingticketscount")) : inull;
                        mobj.PhotoCount = reader["PhotoCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoCount")) : inull;
                        mobj.HoroCount = reader["HoroCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("HoroCount")) : inull;
                        mobj.EMpname = reader["EMpname"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("EMpname")) : inull;
                    }
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

            return mobj;
        }
        /// <summary>
        /// to submit emp assign counts
        /// </summary>
        /// <param name="uma"></param>
        /// <param date="009-08-2017"></param>
        /// <returns></returns>
        public int setEmpAssignCountsDal(EmpAssignCounts Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[8];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            SqlDataReader reader = null;
            int Status = 0;
           
            try
            {
                parm[0] = new SqlParameter("@CreatedEMPID", SqlDbType.Int);
                parm[0].Value = Mobj.EMployeeID;

                parm[1] = new SqlParameter("@servicegivencount", SqlDbType.VarChar);
                parm[1].Value = Mobj.servicegivencount;

                parm[2] = new SqlParameter("@matchfollowupcount", SqlDbType.VarChar);
                parm[2].Value = Mobj.matchfollowupcount;

                parm[3] = new SqlParameter("@marketingticketscount", SqlDbType.VarChar);
                parm[3].Value = Mobj.marketingticketscount;

                parm[4] = new SqlParameter("@PhotoCount", SqlDbType.VarChar);
                parm[4].Value = Mobj.PhotoCount;

                parm[5] = new SqlParameter("@HoroCount", SqlDbType.VarChar);
                parm[5].Value = Mobj.HoroCount;

                parm[6] = new SqlParameter("@EmpName", SqlDbType.VarChar);
                parm[6].Value = Mobj.EMpname;

                parm[7] = new SqlParameter("@Status", SqlDbType.Int);
                parm[7].Direction = ParameterDirection.Output;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(parm[7].Value.ToString(), System.DBNull.Value.ToString()) == 0)
                {
                    Status = 0;
                }
                else
                {
                    Status = Convert.ToInt32(parm[7].Value);
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

            return Status;
        }
        /// <summary>
        /// emp login logout report
        /// </summary>
        /// <param name="uma"></param>
        /// <param date="11-08-2017"></param>
        /// <returns></returns>
        /// 
        public ArrayList loginLogOutReportDal(EmpLoginLogoutReportML mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[11];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet ds = new DataSet();
            try
            {
                parm[0] = new SqlParameter("@i_EmployeeID", SqlDbType.Int);
                parm[0].Value = mobj.EmpUserID;
                parm[1] = new SqlParameter("@t_BranchIds", SqlDbType.Structured);
                parm[1].Value = Commonclass.returndt(mobj.Branch, mobj.dtBranch, "branch", "branchtable");
                parm[2] = new SqlParameter("@t_EmployeeIds", SqlDbType.Structured);
                parm[2].Value = Commonclass.returndt(mobj.EmployeeName, mobj.dtEmployeeName, "empnames", "empIDsTable");
                parm[3] = new SqlParameter("@vc_WorkingHours", SqlDbType.Int);
                parm[3].Value = mobj.WorkingHours;
                parm[4] = new SqlParameter("@dt_StartDate", SqlDbType.DateTime);
                parm[4].Value = mobj.StartDate;
                parm[5] = new SqlParameter("@dt_EndDate", SqlDbType.DateTime);
                parm[5].Value = mobj.EndDate;
                parm[6] = new SqlParameter("@i_Startindex", SqlDbType.Int);
                parm[6].Value = mobj.FromRange;
                parm[7] = new SqlParameter("@i_Endindex", SqlDbType.Int);
                parm[7].Value = mobj.ToRange;
                parm[8] = new SqlParameter("@i_PageNumber", SqlDbType.Int);
                parm[8].Value = mobj.PageNumber;
                parm[9] = new SqlParameter("@i_PageSize", SqlDbType.Int);
                parm[9].Value = mobj.PageSize;
                parm[10] = new SqlParameter("@_Excel", SqlDbType.Int);
                parm[10].Value = mobj.flag;
              
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

       

        public int getinsertImagepathDal(long whereId, string strvalue,string flag, string spname)
        {
            SqlParameter[] parm = new SqlParameter[4];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            SqlDataReader reader = null;
            int Status = 0;
            try
            {
                parm[0] = new SqlParameter("@where_ID", SqlDbType.BigInt);
                parm[0].Value = whereId;
                parm[1] = new SqlParameter("@strvalue", SqlDbType.VarChar);
                parm[1].Value = strvalue;
                parm[2] = new SqlParameter("@flag", SqlDbType.VarChar);
                parm[2].Value = flag;
                parm[3] = new SqlParameter("@status", SqlDbType.Int);
                parm[3].Direction = ParameterDirection.Output;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(parm[3].Value.ToString(), System.DBNull.Value.ToString()) == 0)
                {
                    Status = 0;
                }
                else
                {
                    Status = Convert.ToInt32(parm[3].Value);
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

            return Status;
        }



        public ArrayList empWorksheetDal(EmpWorkSheetMl mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[11];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet ds = new DataSet();
            try
            {
                parm[0] = new SqlParameter("@dt_StartDate", SqlDbType.DateTime);
                parm[0].Value = mobj.FromDate;
                parm[1] = new SqlParameter("@dt_EndDate", SqlDbType.DateTime);
                parm[1].Value = mobj.toDate;
                parm[2] = new SqlParameter("@t_ProfileOwner", SqlDbType.Structured);
                parm[2].Value = Commonclass.returndt(mobj.Employeename, mobj.dtEmployeename, "empnames", "empIDsTable");
                parm[3] = new SqlParameter("@t_Branch", SqlDbType.Structured);
                parm[3].Value = Commonclass.returndt(mobj.Branch, mobj.dtBranch, "branch", "branchtable");
                parm[4] = new SqlParameter("@i_PageSize", SqlDbType.Int);
                parm[4].Value = mobj.PageSize;
                parm[5] = new SqlParameter("@i_PageNumber", SqlDbType.Int);
                parm[5].Value = mobj.PageNumber;
                parm[6] = new SqlParameter("@i_From", SqlDbType.Int);
                parm[6].Value = mobj.SerialnoFrom;
                parm[7] = new SqlParameter("@i_To", SqlDbType.Int);
                parm[7].Value = mobj.SerialnoFrom;
                parm[8] = new SqlParameter("@_Excel", SqlDbType.Bit);
                parm[8].Value = mobj.flag;
                parm[9] = new SqlParameter("@pagename", SqlDbType.VarChar);
                parm[9].Value = mobj.Pagename;
                parm[10] = new SqlParameter("@time", SqlDbType.VarChar);
                parm[10].Value = mobj.timings;

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

        public int empLogoutDal(int empid, string spname)
        {
            SqlParameter[] param = new SqlParameter[3];
            int intstatus =0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            SqlDataReader reader = null;
            try
            {
                param[0] = new SqlParameter("@EmployeeID", System.Data.SqlDbType.BigInt);
                param[0].Value = empid;
                param[1] = new SqlParameter("@ErrorMsg", System.Data.SqlDbType.VarChar, 10000);
                param[1].Direction = ParameterDirection.Output;
                param[2] = new SqlParameter("@Status", System.Data.SqlDbType.Int);
                param[2].Direction = ParameterDirection.Output;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spname, param);
                if (string.Compare(System.DBNull.Value.ToString(), param[2].Value.ToString()) == 0)
                    intstatus= 0;
                else
                    intstatus= 1;
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

            return intstatus;
        }

        public ArrayList mediaterRegValidationDal(mediaterRegFormValidation mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[6];          
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet ds = new DataSet();
            try
            {
                parm[0] = new SqlParameter("@i_MediaterID", SqlDbType.Int);
                parm[0].Value = mobj.i_MediaterID;
                parm[1] = new SqlParameter("@v_FirstName", SqlDbType.VarChar);
                parm[1].Value = mobj.v_FirstName;
                parm[2] = new SqlParameter("@v_Surname", SqlDbType.VarChar);
                parm[2].Value = mobj.v_Surname;
                parm[3] = new SqlParameter("@v_Email", SqlDbType.VarChar);
                parm[3].Value = mobj.v_Email;
                parm[4] = new SqlParameter("@v_Mobilenumber", SqlDbType.VarChar);
                parm[4].Value = mobj.v_Mobilenumber;
                parm[5] = new SqlParameter("@v_CounttyCode", SqlDbType.VarChar);
                parm[5].Value = mobj.v_CounttyCode;
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

       



        public ArrayList EmployeeCommunicationLogDal(CommunicationRequest mobj, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                SqlParameter[] parm = new SqlParameter[6];

                parm[0] = new SqlParameter("@ProfielD", SqlDbType.VarChar);
                parm[0].Value = mobj.profileID;
                parm[1] = new SqlParameter("@intEmpId", SqlDbType.Int);
                parm[1].Value = mobj.intEmpId;
                parm[2] = new SqlParameter("@i_Startindex", SqlDbType.Int);
                parm[2].Value = mobj.startIndex;
                parm[3] = new SqlParameter("@i_EndIndex", SqlDbType.Int);
                parm[3].Value = mobj.endIndex;
                parm[4] = new SqlParameter("@v_Grid", SqlDbType.VarChar);
                parm[4].Value = mobj.v_Grid;
                parm[5] = new SqlParameter("@i_Gridvalue", SqlDbType.Int);
                parm[5].Value = mobj.Gridvalue;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
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

            return Commonclass.convertdataTableToArrayListTable(ds);
        }
    }
}






