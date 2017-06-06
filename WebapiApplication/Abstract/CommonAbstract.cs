using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using KaakateeyaDAL;
using WebapiApplication.DAL;

namespace WebapiApplication.Abstract
{
    public abstract class CommonAbstract
    {
        SqlConnection connection = new SqlConnection();

        public void openCon()
        {
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
        }

        public void closeCon()
        {
            connection.Close();
            SqlConnection.ClearPool(connection);
            SqlConnection.ClearAllPools();
        }

        public SqlDataReader getReader(string spname, SqlParameter[]  parm)
        {
            return SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spname, parm);
        }
        public virtual Tuple<int?, int?> checkProfileBasedOnsp(string profileID, string sp1, string sp2)
        {
            EmployeeReportPageDAL obj = new EmployeeReportPageDAL();
            int intStatus = 0;
            int profileExistence = obj.checkSettlementProfileID(profileID, sp1, out intStatus);
            int settlementProfileIDExistence = obj.checkSettlementProfileID(profileID, sp2, out intStatus);
            return new Tuple<int?, int?>(profileExistence, settlementProfileIDExistence);
        }

    }
}