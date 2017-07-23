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
                parm[4].Direction=ParameterDirection.Output;
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

        public ArrayList EmpDetailsNew(string profileID, int BridegroomFlag, string spname)
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

            int status = intStatus;
            ArrayList arrr = Commonclass.convertdataTableToArrayListTable(ds);
            return arrr;
        }
    }
}