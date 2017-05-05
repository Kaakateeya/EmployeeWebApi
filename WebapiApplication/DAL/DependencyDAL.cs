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
    public class DependencyDAL
    {
        public List<CountryDependency> getCountryDependencyDAL(string dependencyName, string dependencyValue, string Spname)
        {
            List<CountryDependency> Dependency = new List<CountryDependency>();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KakConnection"].ToString());
            connection.Open();
            try
            {

                SqlCommand command = new SqlCommand(Spname, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@v_dflag", dependencyName);
                command.Parameters.AddWithValue("@dependencyID", dependencyValue);

                SqlDataReader reader;
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CountryDependency CD = new CountryDependency
                        {
                            ID = (reader["ID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ID")) : 0,
                            Name = (reader["Name"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Name")) : null,
                        };

                        Dependency.Add(CD);
                    }
                }
                reader.Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(Spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                //SQLHelper.GetSQLConnection().Close();
                //SqlConnection.ClearPool(connection);
                //SQLHelper.GetSQLConnection().Dispose();
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return Dependency;
        }

        public List<CountryDependency> getCountryDependencyCode(string dependencyName, string dependencyValue, string Spname)
        {
            List<CountryDependency> Dependency = new List<CountryDependency>();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KakConnection"].ToString());
            connection.Open();
            try
            {

                SqlCommand command = new SqlCommand(Spname, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@v_dflag", dependencyName);
                command.Parameters.AddWithValue("@dependencyID", dependencyValue);

                SqlDataReader reader;
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CountryDependency CD = new CountryDependency
                        {
                            ID = (reader["ID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ID")) : 0,
                            Name = (reader["Name"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Name")) : null,
                            CountryCode = (reader["CountryCode"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CountryCode")) : null
                        };

                        Dependency.Add(CD);
                    }
                }
                reader.Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(Spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                //SQLHelper.GetSQLConnection().Close();
                //SqlConnection.ClearPool(connection);
                //SQLHelper.GetSQLConnection().Dispose();
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();

            }
            return Dependency;
        }

        public List<CountryDependency> getDropdownValues_dependency_injection(string dependencyName, string dependencyValue, string dependencyflagID, string Spname)
        {
            List<CountryDependency> Dependency = new List<CountryDependency>();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KakConnection"].ToString());
            connection.Open();
            try
            {

                SqlCommand command = new SqlCommand(Spname, connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@v_dflag", dependencyName);
                command.Parameters.AddWithValue("@dependencyID", dependencyValue);
                command.Parameters.AddWithValue("@dependencyflagID", dependencyflagID);

                SqlDataReader reader;
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CountryDependency CD = new CountryDependency
                        {
                            ID = (reader["ID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ID")) : 0,
                            Name = (reader["Name"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Name")) : null,
                        };

                        Dependency.Add(CD);
                    }
                }

                reader.Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(Spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
              
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return Dependency;
        }

        public List<CountryDependency> getDropdown_filling_values(string strDropdownname, string Spname)
        {
            List<CountryDependency> dropdownfilling = new List<CountryDependency>();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KakConnection"].ToString());
            connection.Open();
            try
            {
                
                SqlCommand command = new SqlCommand(Spname, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@v_dflag", strDropdownname);
                SqlDataReader reader;
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CountryDependency CD = new CountryDependency
                        {
                            ID = (reader["ID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ID")) : 0,
                            Name = (reader["Name"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Name")) : null,
                        };

                        dropdownfilling.Add(CD);
                    }
                }
                reader.Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(Spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                //SQLHelper.GetSQLConnection().Close();
                //SqlConnection.ClearPool(connection);
                //SQLHelper.GetSQLConnection().Dispose();
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return dropdownfilling;
        }
    }
}