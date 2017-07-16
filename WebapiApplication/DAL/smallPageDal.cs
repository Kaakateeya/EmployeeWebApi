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
    }
}