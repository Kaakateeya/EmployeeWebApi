using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using KaakateeyaDAL;

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


    }
}