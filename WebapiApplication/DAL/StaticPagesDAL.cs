using System;
using System.Web;
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
    public class StaticPagesDAL
    {
        public List<Sucessstories> GetSuccessStoriesDal(SuccessStoryML Mobj, string spName)
        {
            List<Sucessstories> Sucessstories = new List<Sucessstories>();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KakConnection"].ToString());
            connection.Open();
            try
            {

                SqlCommand command = new SqlCommand(spName, connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@successid", Mobj.successid);
                command.Parameters.AddWithValue("@vc_ProfileID", Mobj.vc_ProfileID);
                command.Parameters.AddWithValue("@i_RegionID", Mobj.i_RegionID);
                command.Parameters.AddWithValue("@casteid", Mobj.casteid);
                command.Parameters.AddWithValue("@branchid", Mobj.branchid);
                command.Parameters.AddWithValue("@pagefrom", Mobj.pagefrom);
                command.Parameters.AddWithValue("@pageto", Mobj.pageto);
                SqlDataReader reader;
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Sucessstories ss = new Sucessstories
                       {
                           GroomName = (reader["GroomName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("GroomName")) : null,
                           BrideName = (reader["BrideName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("BrideName")) : null,
                           GroomProfileID = (reader["GroomProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("GroomProfileID")) : null,
                           BrideProfileID = (reader["BrideProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("BrideProfileID")) : null,
                           MarriageDate = (reader["MarriageDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MarriageDate")) : null,
                           PhotoPath = (reader["PhotoPath"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoPath")) : null,
                       };

                        Sucessstories.Add(ss);
                    }
                }
                reader.Close();

            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Mobj.successid, null, null);
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
            return Sucessstories;
        }

        public List<KaakateeyaBranchesML> getKaakateeyaBranchesDetails(string dependencyName, string dependencyValue, string dependencyflagID, string Spname)
        {
            List<KaakateeyaBranchesML> kakBranchnames = new List<KaakateeyaBranchesML>();
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
                        KaakateeyaBranchesML branchesName = new KaakateeyaBranchesML
                        {
                            BranchAddress = (reader["BranchAddress"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("BranchAddress")) : null,
                            PhoneNumbers = (reader["PhoneNumbers"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhoneNumbers")) : null,
                            Mobilenumber = (reader["Mobilenumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Mobilenumber")) : null,
                            BranchemailID = (reader["BranchemailID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("BranchemailID")) : null,
                            WorkingEndTime = (reader["WorkingEndTime"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("WorkingEndTime")) : null,
                            Branch_ID = (reader["Branch_ID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Branch_ID")) : 0,
                            Address = (reader["Address"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Address")) : null,
                            WorkingStartTime = (reader["WorkingStartTime"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("WorkingStartTime")) : null,
                            Landlineareacode = (reader["Landlineareacode"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Landlineareacode")) : null,
                            Landlinenumber = (reader["Landlinenumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Landlinenumber")) : null,
                            BranchesName = (reader["BranchesName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("BranchesName")) : null,
                        };

                        kakBranchnames.Add(branchesName);
                    }
                }

                reader.Close();

            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(Spname, Convert.ToString(EX.Message), Convert.ToInt32(dependencyValue), null, null);
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
            return kakBranchnames;
        }
        public int DCustomerRating_sendMail(CustFeebBackML Mobj, string spName)
        {
            int status = 0;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KakConnection"].ToString());
            connection.Open();
            try
            {
                List<Smtpemailsending> li = new List<Smtpemailsending>();
                SqlCommand cmd = new SqlCommand(spName, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustID", Mobj.Cust_ID);
                cmd.Parameters.AddWithValue("@Hearabout", Mobj.HearAbout);
                cmd.Parameters.AddWithValue("@Improvewebsite", Mobj.ImproveWebsite);
                cmd.Parameters.AddWithValue("@Kaaprices", Mobj.Kaaprices);
                cmd.Parameters.AddWithValue("@Downloadtime", Mobj.DownLoadTime);
                cmd.Parameters.AddWithValue("@CompareWebsite", Mobj.CompareSite);
                cmd.Parameters.AddWithValue("@FavWebsite", Mobj.FavSite);
                cmd.Parameters.AddWithValue("@PatnrRating", Mobj.SearchRate);
                cmd.Parameters.AddWithValue("@Recommand", Mobj.Recommend);
                cmd.Parameters.AddWithValue("@Comments", Mobj.Comments);
                SqlParameter outputParamStatus = cmd.Parameters.Add("@Status", SqlDbType.Int);
                outputParamStatus.Direction = ParameterDirection.Output;
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        Smtpemailsending smtp = new Smtpemailsending
                        {
                            profile_name = (reader["profile_name"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("profile_name")) : null,
                            recipients = (reader["recipients"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("recipients")) : null,
                            body = (reader["body"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("body")) : null,
                            subject = (reader["subject"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("subject")) : null,
                            body_format = (reader["body_format"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("body_format")) : null,

                        };

                        li.Add(smtp);
                        status = (reader["Status"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Status")) : 0;
                        Commonclass.SendMailSmtpMethod(li, "info");
                    }
                }

                reader.Close();

            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt32(Mobj.Cust_ID), null, null);
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
            return status;
        }
        public int SendTicketMailDal(HelpMail Mobj, string spName)
        {
            int intStatus = 0;
            SqlParameter[] parm = new SqlParameter[8];
            Smtpemailsending smtp = new Smtpemailsending();
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            SqlDataReader reader;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {

                parm[0] = new SqlParameter("@Email", SqlDbType.VarChar, 100);
                parm[0].Value = Mobj.strEmail;
                parm[1] = new SqlParameter("@Name", SqlDbType.VarChar, 250);
                parm[1].Value = Mobj.Name;
                parm[2] = new SqlParameter("@TicketID", SqlDbType.VarChar, 250);
                parm[2].Value = Mobj.TicketID;
                parm[3] = new SqlParameter("@Category", SqlDbType.VarChar, 250);
                parm[3].Value = Mobj.CategoryName;
                parm[4] = new SqlParameter("@EmpID", SqlDbType.BigInt);
                parm[4].Value = Mobj.EmpID;
                parm[5] = new SqlParameter("@TicketEmpID", SqlDbType.BigInt);
                parm[5].Value = Mobj.EmpTicketID;
                parm[6] = new SqlParameter("@Status", SqlDbType.Int);
                parm[6].Direction = ParameterDirection.Output;
                parm[7] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
                parm[7].Direction = ParameterDirection.Output;

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
                        smtp.Statusint = (reader["Status"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Status")) : 0;
                        li.Add(smtp);
                    }
                }
                Commonclass.SendMailSmtpMethod(li, "info");
                intStatus = smtp.Statusint;
                reader.Close();
            }
            catch (Exception Ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(Ex.Message), Convert.ToInt32(Mobj.Cust_ID), null, null);
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
        public HelpMail DalInsertTicketInfo(TicketCreationMl Mobj, string spName)
        {
            SqlParameter[] parm = new SqlParameter[16];
            SqlDataReader reader;
            HelpMail helpmail = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@profile", SqlDbType.BigInt);
                parm[0].Value = Mobj.profile;
                parm[1] = new SqlParameter("@AssignedEmpID", SqlDbType.BigInt);
                parm[1].Value = Mobj.AssignedEmpID;
                parm[2] = new SqlParameter("@Name", SqlDbType.VarChar, 100);
                parm[2].Value = Mobj.Name;
                parm[3] = new SqlParameter("@Email", SqlDbType.VarChar, 100);
                parm[3].Value = Mobj.Email;
                parm[4] = new SqlParameter("@subject", SqlDbType.VarChar, 500);
                parm[4].Value = Mobj.subject;
                parm[5] = new SqlParameter("@Category", SqlDbType.Int);
                parm[5].Value = Mobj.Category;
                parm[6] = new SqlParameter("@Message", SqlDbType.VarChar, 500);
                parm[6].Value = Mobj.Message;
                parm[7] = new SqlParameter("@Priority", SqlDbType.Int);
                parm[7].Value = Mobj.Priority;
                parm[8] = new SqlParameter("@Image", SqlDbType.VarChar, 1000);
                parm[8].Value = Mobj.Image;
                parm[9] = new SqlParameter("@CountryCode", SqlDbType.Int);
                parm[9].Value = Mobj.CountryCode;
                parm[10] = new SqlParameter("@AreaCode", SqlDbType.VarChar, 20);
                parm[10].Value = Mobj.AreaCode;
                parm[11] = new SqlParameter("@PhoneNum", SqlDbType.VarChar, 20);
                parm[11].Value = Mobj.PhoneNum;
                parm[12] = new SqlParameter("@BranchID", SqlDbType.BigInt);
                parm[12].Value = Mobj.BranchID;
                parm[13] = new SqlParameter("@EmpID", SqlDbType.BigInt);
                parm[13].Value = Mobj.EmpID;
                parm[14] = new SqlParameter("@Status", SqlDbType.Int);
                parm[14].Direction = ParameterDirection.Output;
                parm[15] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
                parm[15].Direction = ParameterDirection.Output;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        helpmail = new HelpMail
                       {
                           Ticket = (reader["TicketID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("TicketID")) : null,
                           iTicketID = (reader["NewTicket"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("NewTicket")) : 0,
                           Cust_ID = (reader["Cust_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_ID")) : 0,
                           Status = (reader["Status"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Status")) : 0,
                       };
                    }
                }

            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt32(Mobj.profile), null, null);
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
            return helpmail;

        }
        public ArrayList CustomerViewfullProfileDetails(long? ProfileID, int? CustID, string strSpname)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dataset = new DataSet();

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            SqlCommand cmd = new SqlCommand(strSpname, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@intCust_id", ProfileID);
                cmd.Parameters.AddWithValue("@intFromCustId", CustID);
                da.SelectCommand = cmd;
                da.Fill(dataset);

            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(EX.Message), Convert.ToInt32(ProfileID), null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayList(dataset);
        }
        public ArrayList GetExpressinterst_bookmark_ignore_Data(long? loggedcustid, long? ToCustID, string strSpname)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dataset = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            SqlCommand cmd = new SqlCommand(strSpname, connection);

            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@loggedcustid", loggedcustid);
                cmd.Parameters.AddWithValue("@tocust_id", ToCustID);
                da.SelectCommand = cmd;
                da.Fill(dataset);
                SQLHelper.GetSQLConnection().Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(EX.Message), Convert.ToInt32(loggedcustid), null, null);
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
            DalCustomerExpressinterestBookMarkflag(loggedcustid, ToCustID, strSpname);
            return Commonclass.convertdataTableToArrayList(dataset);
        }
        public List<ExpressinterestbookmarkGetting> DalCustomerExpressinterestBookMarkflag(long? loggedcustid, long? ToCustID, string strSpname)
        {
            SqlParameter[] parm = new SqlParameter[3];
            SqlDataReader reader;
            int? inull = null;
            Int64? Lnull = null;
            string snull = string.Empty;
            List<ExpressinterestbookmarkGetting> Expbook = new List<ExpressinterestbookmarkGetting>();
            ExpressinterestbookmarkGetting Bookexp = new ExpressinterestbookmarkGetting();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@loggedcustid", SqlDbType.BigInt);
                parm[0].Value = loggedcustid;
                parm[1] = new SqlParameter("@tocust_id", SqlDbType.BigInt);
                parm[1].Value = ToCustID;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, strSpname, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Bookexp.BookmarkFlag = reader["BookmarkFlag"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("BookmarkFlag")) : inull;
                    }
                }
                reader.NextResult();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Bookexp.IgnoreFlag = reader["IgnoreFlag"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IgnoreFlag")) : inull;
                    }
                }
                reader.NextResult();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Bookexp.Viewedflag = reader["Viewedflag"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Viewedflag")) : inull;
                    }
                }
                reader.NextResult();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Bookexp.ExpressFlag = reader["ExpressFlag"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ExpressFlag")) : inull;
                        Bookexp.Acceptflag = reader["Acceptflag"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Acceptflag")) : inull;
                        Bookexp.TimeFlag = reader["TimeFlag"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TimeFlag")) : inull;
                        Bookexp.MatchFollowUpStatus = reader["MatchFollowUpStatus"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("MatchFollowUpStatus")) : inull;
                        Bookexp.ExpressInterstId = reader["ExpressInterstId"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ExpressInterstId")) : Lnull;
                        Bookexp.TicketID = reader["TicketID"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("TicketID")) : Lnull;
                        Bookexp.SeenStatus = reader["SeenStatus"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("SeenStatus")) : snull;
                        Bookexp.ViewTicket = reader["ViewTicket"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ViewTicket")) : snull;
                    }
                }
                reader.NextResult();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Bookexp.Paidstatus = reader["Paidstatus"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Paidstatus")) : snull;
                    }
                }
                Expbook.Add(Bookexp);
                reader.Close();
                SQLHelper.GetSQLConnection().Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(EX.Message), Convert.ToInt32(loggedcustid), null, null);
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
            return Expbook;

        }
        public int SendMail_PhotoRequest_Customer(string FromCustID, string ToCustID, int? Category, string spName)
        {
            int intStatus = 0;
            Smtpemailsending smtp = new Smtpemailsending();
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            SqlDataReader reader;
            SqlParameter[] parm = new SqlParameter[5];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@i_FromCustID", SqlDbType.VarChar, 500);
                parm[0].Value = FromCustID;
                parm[1] = new SqlParameter("@i_ToCustId", SqlDbType.VarChar, 500);
                parm[1].Value = ToCustID;
                parm[2] = new SqlParameter("@Category", SqlDbType.Int);
                parm[2].Value = Category;
                parm[3] = new SqlParameter("@Status", SqlDbType.Int);
                parm[3].Direction = ParameterDirection.Output;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        smtp.profile_name = (reader["profile_name"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("profile_name")) : string.Empty;
                        smtp.recipients = (reader["recipients"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("recipients")) : string.Empty;
                        smtp.body = (reader["body"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("body")) : string.Empty;
                        smtp.subject = (reader["subject"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("subject")) : string.Empty;
                        smtp.body_format = (reader["body_format"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("body_format")) : string.Empty;
                        smtp.Statusint = (reader["Status"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Status")) : 0;
                        li.Add(smtp);

                        Commonclass.SendMailSmtpMethod(li, "info");
                    }
                }
                intStatus = smtp.Statusint;
                reader.Close();
                SQLHelper.GetSQLConnection().Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt32(FromCustID), null, null);
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
        public int DprofileGrade(string CustID, string spName)
        {
            SqlParameter[] parm = new SqlParameter[4];
            SqlDataReader reader;
            int iGrade = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@CustID", SqlDbType.VarChar);
                parm[0].Value = CustID;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        iGrade = (reader["ProfileGrade"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProfileGrade")) : 0;
                    }
                }
                reader.Close();
                SQLHelper.GetSQLConnection().Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt32(CustID), null, null);
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
            return iGrade;
        }
        public List<PhotoPathDisplay> GetPhotoSlideImages(string CustID, string spName)
        {
            List<PhotoPathDisplay> photoSlide = new List<PhotoPathDisplay>();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {

                SqlCommand command = new SqlCommand(spName, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CustID", CustID);

                SqlDataReader reader = null;
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PhotoPathDisplay ss = new PhotoPathDisplay
                        {
                            ThumbNailPath = (reader["ThumbNailPath"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ThumbNailPath")) : null,
                            FullPhotoPath = (reader["FullPhotoPath"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FullPhotoPath")) : null,
                            ApplicationPhotoPath = (reader["ApplicationPhotoPath"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ApplicationPhotoPath")) : null,
                        };
                        photoSlide.Add(ss);
                    }

                }

                reader.Close();

            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt32(CustID), null, null);
            }
            finally
            {
                //SQLHelper.GetSQLConnection().Close();
                //SqlConnection.ClearPool(connection);
                //  SqlConnection.ClearPool(connection);
                //Dont clear all pools..
                //just clear the single pool ---->clearPool()
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return photoSlide;
        }
        public int PhotopasswordAcceptReject(Int64? FromcustID, Int64? TocustID, Int64? Accept_Reject, string spName)
        {
            int iStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] parm = new SqlParameter[5];

                parm[0] = new SqlParameter("@FromcustID", SqlDbType.BigInt);
                parm[0].Value = FromcustID;
                parm[1] = new SqlParameter("@TocustID", SqlDbType.BigInt);
                parm[1].Value = TocustID;
                parm[2] = new SqlParameter("@Accept_Reject", SqlDbType.Int);
                parm[2].Value = Accept_Reject;
                parm[3] = new SqlParameter("@Status", SqlDbType.Int);
                parm[3].Direction = ParameterDirection.Output;

                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
                if (string.Compare(parm[3].Value.ToString(), System.DBNull.Value.ToString()) == 0) { iStatus = 0; } else { iStatus = Convert.ToInt32(parm[3].Value); }
                SQLHelper.GetSQLConnection().Close();
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(ex.Message), Convert.ToInt32(TocustID), null, null);
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

            return iStatus;
        }

        public List<ProfileSettings> customerProfilesettings(Int64? CustID, string spName)
        {
            SqlParameter[] param = new SqlParameter[3];
            List<ProfileSettings> lstprofilesetting = new List<ProfileSettings>();
            ProfileSettings profilesettings = new ProfileSettings();
            SqlDataReader reader = null;
            Int64? intnull = null;
            Int64? int32 = null;
            bool? iboolean = null;
            DateTime? iDateTime = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                param[0] = new SqlParameter("@CustID", SqlDbType.BigInt);
                param[0].Value = CustID;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, param);
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        profilesettings.Email = reader["Email"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Email")) : null;
                        profilesettings.EmailCust_Family_ID = reader["EmailCust_Family_ID"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("EmailCust_Family_ID")) : intnull;
                    }

                }
                reader.NextResult();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        profilesettings.Mobilenumber = reader["Mobilenumber"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Mobilenumber")) : null;
                        profilesettings.MobileCustFamily_ID = reader["MobileCustFamily_ID"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("MobileCustFamily_ID")) : intnull;
                    }

                }
                reader.NextResult();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        profilesettings.ProfileStatusID = reader["ProfileStatusID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProfileStatusID")) : int32;
                        profilesettings.InActiveFromDate = reader["InActiveFromDate"] != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("InActiveFromDate")) : iDateTime;
                        profilesettings.InActiveToDate = reader["InActiveToDate"] != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("InActiveToDate")) : iDateTime;
                        profilesettings.AllowEmail = reader["AllowEmail"] != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("AllowEmail")) : iboolean;
                        profilesettings.AllowSMS = reader["AllowSMS"] != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("AllowSMS")) : iboolean;
                        profilesettings.Password = reader["Password"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Password")) : null;
                    }
                }
                lstprofilesetting.Add(profilesettings);
                reader.Close();
                SQLHelper.GetSQLConnection().Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt32(CustID), null, null);
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

            return lstprofilesetting;

        }
        public int InsertcustomerProfilesettings(DateTime? Expirydate, int? CustID, int? iflag, string spName)
        {
            int iStatus = 1;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] parm = new SqlParameter[5];
                parm[0] = new SqlParameter("@Expirydate", SqlDbType.BigInt);
                parm[0].Value = Expirydate;
                parm[1] = new SqlParameter("@custid", SqlDbType.BigInt);
                parm[1].Value = CustID;
                parm[2] = new SqlParameter("@iflag", SqlDbType.Int);
                parm[2].Value = iflag;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);

            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(ex.Message), Convert.ToInt32(CustID), null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();

            }
            return iStatus;
        }
        public int DeletecustomerProfilesettings(Int64? ProfileID, string Narrtion, string spName)
        {
            SqlDataReader reader;
            Smtpemailsending smtp = new Smtpemailsending();
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            int status = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@ProfileID", SqlDbType.BigInt);
                parm[0].Value = ProfileID;
                parm[1] = new SqlParameter("@narrtion", SqlDbType.VarChar);
                parm[1].Value = Narrtion;
                parm[2] = new SqlParameter("@Status", SqlDbType.Int);
                parm[2].Direction = ParameterDirection.Output;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        smtp.profile_name = (reader["profile_name"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("profile_name")) : string.Empty;
                        smtp.recipients = (reader["recipients"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("recipients")) : string.Empty;
                        smtp.body = (reader["body"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("body")) : string.Empty;
                        smtp.subject = (reader["subject"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("subject")) : string.Empty;
                        smtp.body_format = (reader["body_format"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("body_format")) : string.Empty;
                        smtp.Statusint = (reader["Status"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Status")) : 0;
                        li.Add(smtp);
                    }
                }
                Commonclass.SendMailSmtpMethod(li, "info");
                status = smtp.Statusint;
                reader.Close();

                if (string.Compare(parm[2].Value.ToString(), System.DBNull.Value.ToString()) == 0)
                {
                    status = 0;
                }
                else
                {
                    status = Convert.ToInt32(parm[2].Value);
                }

            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(ex.Message), Convert.ToInt32(ProfileID), null, null);
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
        public int UpdatePasswordDal(string OldPassword, string NewPassword, string ConfirmPassword, string custId, string spName)
        {
            int pwdStatus = 1;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[5];
                parm[0] = new SqlParameter("@Oldpassword", SqlDbType.VarChar, 500);
                parm[0].Value = OldPassword;
                parm[1] = new SqlParameter("@Newpassword", SqlDbType.VarChar, 500);
                parm[1].Value = NewPassword;
                parm[2] = new SqlParameter("@Confirmpassword", SqlDbType.VarChar, 500);
                parm[2].Value = ConfirmPassword;
                parm[3] = new SqlParameter("@custId", SqlDbType.Int);
                parm[3].Value = custId;
                SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);

            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(ex.Message), Convert.ToInt32(custId), null, null);
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
            return pwdStatus;
        }
        public int ProfilesettingAllowEmailAllowSMS(long? CustID, int? AllowEmail, int? AllowSMS, string spName)
        {
            int iStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] parm = new SqlParameter[5];
                parm[0] = new SqlParameter("@CustID", SqlDbType.BigInt);
                parm[0].Value = CustID;
                parm[1] = new SqlParameter("@AllowEmail", SqlDbType.Int);
                parm[1].Value = AllowEmail;
                parm[2] = new SqlParameter("@AllowSMS", SqlDbType.Int);
                parm[2].Value = AllowSMS;
                parm[3] = new SqlParameter("@Status", SqlDbType.Int);
                parm[3].Direction = ParameterDirection.Output;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
                if (string.Compare(parm[3].Value.ToString(), System.DBNull.Value.ToString()) == 0) { iStatus = 0; } else { iStatus = Convert.ToInt32(parm[3].Value); }
                SQLHelper.GetSQLConnection().Close();
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(ex.Message), CustID, null, null);
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
            return iStatus;
        }
        public int ProfilesettingEmailMobileChange(long? FamilyID, string MobileEmail, int? CountryID, int? imobileEmailflag, string spName)
        {
            int iStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] parm = new SqlParameter[5];
                parm[0] = new SqlParameter("@FamilyID", SqlDbType.BigInt);
                parm[0].Value = FamilyID;
                parm[1] = new SqlParameter("@MobileEmail", SqlDbType.VarChar);
                parm[1].Value = MobileEmail;
                parm[2] = new SqlParameter("@CountryID", SqlDbType.Int);
                parm[2].Value = CountryID;
                parm[3] = new SqlParameter("@imobileEmailflag", SqlDbType.Int);
                parm[3].Value = imobileEmailflag;
                parm[4] = new SqlParameter("@Status", SqlDbType.Int);
                parm[4].Direction = ParameterDirection.Output;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
                if (string.Compare(parm[4].Value.ToString(), System.DBNull.Value.ToString()) == 0) { iStatus = 0; } else { iStatus = Convert.ToInt32(parm[4].Value); }

            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(ex.Message), Convert.ToInt32(FamilyID), null, null);

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
            return iStatus;
        }
        public void DApplicationErrorLog(string ErrorSpName, string ErrorMessage, long? CustID, string PageName, string Type, string spName)
        {
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[6];
                parm[0] = new SqlParameter("@ErrorSpName", SqlDbType.VarChar);
                parm[0].Value = ErrorSpName;
                parm[1] = new SqlParameter("@ErrorMessage", SqlDbType.VarChar);
                parm[1].Value = ErrorMessage;
                parm[2] = new SqlParameter("@CustID", SqlDbType.BigInt);
                parm[2].Value = CustID;
                parm[3] = new SqlParameter("@PageName", SqlDbType.VarChar);
                parm[3].Value = PageName;
                parm[4] = new SqlParameter("@Type", SqlDbType.VarChar);
                parm[4].Value = Type;
                SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);

            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(ex.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }

        }
        public int EmailMobilenumberexists(int? iflagEmailmobile, string EmailMobile, string spName)
        {
            int iStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] parm = new SqlParameter[5];
                parm[0] = new SqlParameter("@i_flag", SqlDbType.Int);
                parm[0].Value = iflagEmailmobile;
                parm[1] = new SqlParameter("@v_EmailMobile", SqlDbType.VarChar);
                parm[1].Value = EmailMobile;
                parm[2] = new SqlParameter("@i_Status", SqlDbType.Int);
                parm[2].Direction = ParameterDirection.Output;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
                if (string.Compare(parm[2].Value.ToString(), System.DBNull.Value.ToString()) == 0) { iStatus = 0; } else { iStatus = Convert.ToInt32(parm[2].Value); }
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(ex.Message), null, null, null);
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
            return iStatus;
        }
        public string EmailMobilenumberexists_String(int? iflagEmailmobile, string EmailMobile, string spName)
        {
            string iStatus = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] parm = new SqlParameter[5];
                parm[0] = new SqlParameter("@i_flag", SqlDbType.Int);
                parm[0].Value = iflagEmailmobile;
                parm[1] = new SqlParameter("@v_EmailMobile", SqlDbType.VarChar);
                parm[1].Value = EmailMobile;
                parm[2] = new SqlParameter("@i_Status", SqlDbType.VarChar, 8000);
                parm[2].Direction = ParameterDirection.Output;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "[dbo].[usp_EmailMobilenumberexists_String]", parm);
                if (string.Compare(parm[2].Value.ToString(), System.DBNull.Value.ToString()) == 0) { iStatus = null; } else { iStatus = Convert.ToString(parm[2].Value); }
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(ex.Message), null, null, null);
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
            return iStatus;
        }
        public ArrayList paymentdetailsmethoddal(Int64? CustID, string spName)
        {

            DataSet dsAdvertisementserach = new DataSet();
            SqlDataAdapter daAdversearch = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(spName, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@custid", CustID);
                SqlParameter outputParamStatus = cmd.Parameters.Add("@Status", SqlDbType.Int);
                outputParamStatus.Direction = ParameterDirection.Output;
                daAdversearch.SelectCommand = cmd;
                daAdversearch.Fill(dsAdvertisementserach);
                //  if (Convert.ToInt32(cmd.Parameters[1].Value) == 1) { intstatus = 1; } else { intstatus = 0; }

            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt32(CustID), null, null);
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
            return Commonclass.convertdataTableToArrayList(dsAdvertisementserach);
        }
        public ArrayList GetTicketDetailsDal(TicketDetails ticketdetails, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            SqlParameter[] param = new SqlParameter[7];
            try
            {
                param[0] = new SqlParameter("@ipageID", SqlDbType.Int);
                param[0].Value = ticketdetails.PageID;
                param[1] = new SqlParameter("@i_CustID", SqlDbType.BigInt);
                param[1].Value = ticketdetails.CustID;
                param[2] = new SqlParameter("@i_TicketID", SqlDbType.Int);
                param[2].Value = ticketdetails.TicketID;
                param[3] = new SqlParameter("@i_Staus", SqlDbType.Int);
                param[3].Direction = ParameterDirection.Output;
                param[4] = new SqlParameter("@iprofileID", SqlDbType.VarChar);
                param[4].Value = ticketdetails.ProfileID;
                param[5] = new SqlParameter("@v_Complaint", SqlDbType.VarChar);
                param[5].Value = ticketdetails.Complaint;
                param[6] = new SqlParameter("@i_FeedBack", SqlDbType.Int);
                param[6].Value = ticketdetails.FeedBackStatus;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, param);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt32(ticketdetails.CustID), null, null);
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
            return Commonclass.convertdataTableToArrayList(ds);
        }
        public int CustomerReopenTicketStatus(int? PageID, int? ProfileID, int? TicketID, string spName)
        {
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            SqlParameter[] param = new SqlParameter[4];
            try
            {
                param[0] = new SqlParameter("@ipageID", SqlDbType.Int);
                param[0].Value = PageID;
                param[1] = new SqlParameter("@iprofileID", SqlDbType.VarChar, 20);
                param[1].Value = ProfileID;
                param[2] = new SqlParameter("@i_TicketID", SqlDbType.Int);
                param[2].Value = TicketID;
                param[3] = new SqlParameter("@i_Staus", SqlDbType.Int);
                param[3].Direction = ParameterDirection.Output;
                intStatus = SQLHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, param);
                if (string.Compare(System.DBNull.Value.ToString(), param[3].Value.ToString()).Equals(0))
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(param[3].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt32(ProfileID), null, null);
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
        public int ForgotPassword(string Username, string spName)
        {
            int Status = 0;
            SqlDataReader reader = null;
            SqlParameter[] parm = new SqlParameter[2];
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            Smtpemailsending smtp = new Smtpemailsending();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@Username", SqlDbType.VarChar);
                parm[0].Value = Username;
                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;
                DataSet dsAstroInfo = new DataSet();
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        smtp.profile_name = (reader["profile_name"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("profile_name")) : string.Empty;
                        smtp.recipients = (reader["recipients"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("recipients")) : string.Empty;
                        smtp.body = (reader["body"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("body")) : string.Empty;
                        smtp.subject = (reader["subject"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("subject")) : string.Empty;
                        smtp.body_format = (reader["body_format"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("body_format")) : string.Empty;
                        Status = smtp.Statusint = (reader["Status"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Status")) : 0;
                        li.Add(smtp);
                    }
                }
                Commonclass.SendMailSmtpMethod(li, "info");
                reader.Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
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
            return Status;
        }
        public DataTable UnpaidMembersOwner_Notification(int? CategoryID, int? Cust_ID, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@CategoryID", SqlDbType.Int);
                parm[0].Value = CategoryID;
                parm[1] = new SqlParameter("@Cust_ID", SqlDbType.BigInt);
                parm[1].Value = Cust_ID;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(ex.Message), Convert.ToInt32(Cust_ID), null, null);
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
            if (ds != null) { if (ds.Tables.Count > 0) { dt = ds.Tables[0]; } }
            return dt;
        }
        public int ConfirmUserEmail(string VerificationCode, string spName)
        {
            int intStatus = 0;
            SqlParameter[] parm = new SqlParameter[2];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@VerificationCode", SqlDbType.VarChar);
                parm[0].Value = VerificationCode;
                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;
                SQLHelper.ExecuteScalar(connection, CommandType.StoredProcedure, spName, parm);
                if (string.Compare(parm[1].Value.ToString(), System.DBNull.Value.ToString()) == 0)
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
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
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
        public int CreateNewPassword(Int64? intCusID, string strPassword, string spName)
        {
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            SqlParameter[] parm = new SqlParameter[3];
            try
            {
                parm[0] = new SqlParameter("@Custid", SqlDbType.BigInt);
                parm[0].Value = intCusID;
                parm[1] = new SqlParameter("@Password", SqlDbType.VarChar);
                parm[1].Value = strPassword;
                parm[2] = new SqlParameter("@Status", SqlDbType.Int);
                parm[2].Direction = ParameterDirection.Output;
                SQLHelper.ExecuteScalar(connection, CommandType.StoredProcedure, spName, parm);
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
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt32(intCusID), null, null);
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
        public string EmilVerificationCode(string VerificationCode, string spName, int? i_EmilMobileVerification, int? CustContactNumbersID, int? IsVerified)
        {
            string Status = null;
            SqlParameter[] parm = new SqlParameter[6];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@VerificationCode", SqlDbType.VarChar, 8000);
                parm[0].Value = VerificationCode;
                parm[1] = new SqlParameter("@i_EmilMobileVerification", SqlDbType.Int);
                parm[1].Value = i_EmilMobileVerification;
                parm[2] = new SqlParameter("@CustContactNumbersID", SqlDbType.BigInt);
                parm[2].Value = CustContactNumbersID;
                parm[3] = new SqlParameter("@IsVerified", SqlDbType.BigInt);
                parm[3].Value = IsVerified;
                parm[4] = new SqlParameter("@Status", SqlDbType.VarChar, 8000);
                parm[4].Direction = ParameterDirection.Output;
                SQLHelper.ExecuteScalar(connection, CommandType.StoredProcedure, spName, parm);
                Status = Convert.ToString(parm[4].Value);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);

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
            return Status;
        }
        public int ResendEmailVerficationLink(long? CustID, string spName)
        {
            Smtpemailsending smtp = new Smtpemailsending();
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            SqlDataReader reader;
            int Status = 0;
            SqlParameter[] param = new SqlParameter[2];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                param[0] = new SqlParameter("@CustID", SqlDbType.BigInt);
                param[0].Value = CustID;
                param[1] = new SqlParameter("@Status", SqlDbType.Int);
                param[1].Direction = ParameterDirection.Output;
                //  SqlDataReader Dr = null;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, param);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        smtp.profile_name = (reader["profile_name"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("profile_name")) : string.Empty;
                        smtp.recipients = (reader["recipients"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("recipients")) : string.Empty;
                        smtp.body = (reader["body"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("body")) : string.Empty;
                        smtp.subject = (reader["subject"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("subject")) : string.Empty;
                        smtp.body_format = (reader["body_format"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("body_format")) : string.Empty;
                        smtp.Statusint = (reader["Status"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Status")) : 0;
                        li.Add(smtp);
                        Commonclass.SendMailSmtpMethod(li, "info");
                        Status = smtp.Statusint;
                    }
                }
                reader.Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt32(CustID), null, null);
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
            return Status;
        }
        public int MissingFieldsupdate_Customerdetails(MissingFieldsUpdateRequest Mobj, string spName)
        {

            DataSet ds = new DataSet();
            int intstatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            SqlParameter[] parm = new SqlParameter[25];
            try
            {
                parm[0] = new SqlParameter("@CustID", SqlDbType.VarChar);
                parm[0].Value = Mobj.CustID;
                parm[1] = new SqlParameter("@i_updateflag", SqlDbType.Int);
                parm[1].Value = Mobj.i_updateflag;
                parm[2] = new SqlParameter("@Height", SqlDbType.VarChar);
                parm[2].Value = Mobj.Height;
                parm[3] = new SqlParameter("@Maritalstatus", SqlDbType.VarChar);
                parm[3].Value = Mobj.Maritalstatus;
                parm[4] = new SqlParameter("@Complexion", SqlDbType.VarChar);
                parm[4].Value = Mobj.Complexion;
                parm[5] = new SqlParameter("@JobLocationCountry", SqlDbType.Int);
                parm[5].Value = Mobj.iJoblocationCountry;
                parm[6] = new SqlParameter("@JobLocationState", SqlDbType.Int);
                parm[6].Value = Mobj.iJoblocationState;
                parm[7] = new SqlParameter("@JobLocationDistrict", SqlDbType.Int);
                parm[7].Value = Mobj.iJoblocationDistrict;
                parm[8] = new SqlParameter("@JobLocation", SqlDbType.Int);
                parm[8].Value = Mobj.iJobLocation;
                parm[9] = new SqlParameter("@FFCustFamilyID", SqlDbType.BigInt);
                parm[9].Value = (Mobj.FFCustFamilyID);
                parm[10] = new SqlParameter("@FatherNative", SqlDbType.VarChar);
                parm[10].Value = !string.IsNullOrEmpty(Mobj.FatherNative) ? Mobj.FatherNative : null;
                parm[11] = new SqlParameter("@MFCustFamilyID", SqlDbType.BigInt);
                parm[11].Value = Mobj.MFCustFamilyID;
                parm[12] = new SqlParameter("@MotherNative", SqlDbType.VarChar);
                parm[12].Value = Mobj.MotherNative;
                parm[13] = new SqlParameter("@Salarycurrency", SqlDbType.VarChar);
                parm[13].Value = Mobj.Salarycurrency;
                parm[14] = new SqlParameter("@Salary", SqlDbType.VarChar);
                parm[14].Value = Mobj.Salary;
                parm[15] = new SqlParameter("@Propertylakhs", SqlDbType.VarChar);
                parm[15].Value = Mobj.Propertylakhs;
                parm[16] = new SqlParameter("@Starlanguage", SqlDbType.VarChar);
                parm[16].Value = Mobj.Starlanguage;
                parm[17] = new SqlParameter("@Star", SqlDbType.VarChar);
                parm[17].Value = Mobj.Star;
                parm[18] = new SqlParameter("@Gothram", SqlDbType.VarChar);
                parm[18].Value = Mobj.Gothram;
                parm[19] = new SqlParameter("@ParentsFlag", SqlDbType.Int);
                parm[19].Value = Mobj.ParentsFlag;
                parm[20] = new SqlParameter("@AstroFlag", SqlDbType.Int);
                parm[20].Value = Mobj.AstroFlag;
                parm[21] = new SqlParameter("@IsSharedProperty", SqlDbType.Int);
                parm[21].Value = Mobj.IsSharedProperty;
                parm[22] = new SqlParameter("@Status", SqlDbType.Int);
                parm[22].Direction = ParameterDirection.Output;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[22].Value.ToString()).Equals(0))
                {
                    intstatus = 0;
                }
                else
                {
                    intstatus = Convert.ToInt32(parm[22].Value);
                }
            }
            catch (Exception Ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(Ex.Message), Convert.ToInt32(Mobj.CustID), null, null);
            }
            finally
            {
                //SQLHelper.GetSQLConnection().Close();
                //SqlConnection.ClearAllPools();

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();

            }
            return intstatus;
        }
        public ArrayList displayMissingFieldsupdate_Customerdetails(string CustID, int? i_updateflag, string spName)
        {

            DataSet ds = new DataSet();
            SqlParameter[] parm = new SqlParameter[5];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@CustID", SqlDbType.VarChar);
                parm[0].Value = CustID;
                parm[1] = new SqlParameter("@i_updateflag", SqlDbType.Int);
                parm[1].Value = i_updateflag;
                parm[2] = new SqlParameter("@Status", SqlDbType.Int);
                parm[2].Direction = ParameterDirection.Output;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception Ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(Ex.Message), Convert.ToInt32(CustID), null, null);
            }
            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayList(ds);
        }
        public string Customerfilldata(long? CustomerCustID, string spName)
        {
            DataSet ds = new DataSet();
            string status = null;
            SqlParameter[] parm = new SqlParameter[5];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@CustomerCustID", SqlDbType.VarChar);
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

        public DataSet CustomerData(int? iflag, string CustID)
        {
            DataSet ds = new DataSet();
            string status = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            SqlParameter[] parm = new SqlParameter[5];
            try
            {
                parm[0] = new SqlParameter("@i_flag", SqlDbType.Int);
                parm[0].Value = iflag;
                parm[1] = new SqlParameter("@v_EmailMobile", SqlDbType.VarChar, 8000);
                parm[1].Value = CustID;
                parm[2] = new SqlParameter("@i_Status", SqlDbType.VarChar, 8000);
                parm[2].Direction = ParameterDirection.Output;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "[dbo].[usp_EmailMobilenumberexists_NewDesign]", parm);
                status = parm[2].Value.ToString();
            }
            catch (Exception Ex)
            {
                Commonclass.ApplicationErrorLog("[dbo].[usp_EmailMobilenumberexists_NewDesign]", Convert.ToString(Ex.Message), Convert.ToInt32(CustID), null, null);
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
            return ds;
        }

        public int InsertUnpaidStatus(string fromCustID, string ToCustID, int? Empid, string typeofAction, string spName)
        {
            int status = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            SqlParameter[] parm = new SqlParameter[5];
            try
            {
                parm[0] = new SqlParameter("@fromCustID", SqlDbType.VarChar);
                parm[0].Value = fromCustID;

                parm[1] = new SqlParameter("@ToCustID", SqlDbType.VarChar);
                parm[1].Value = ToCustID;

                parm[2] = new SqlParameter("@Empid", SqlDbType.Int);
                parm[2].Value = Empid;

                parm[3] = new SqlParameter("@typeofAction", SqlDbType.VarChar);
                parm[3].Value = typeofAction;

                parm[4] = new SqlParameter("@Status", SqlDbType.Int);
                parm[4].Direction = ParameterDirection.Output;

                DataSet dsMessages = new DataSet();
                dsMessages = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[4].Value.ToString()) == 0)
                {
                    status = 0;
                }
                else
                {
                    status = Convert.ToInt32(parm[4].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt32(fromCustID), null, null);
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
        public int InsertExpressViewTicket(long? FromCustID, long? ToCustID, string EncriptedText, string strtypeOfReport, string spName)
        {
            int? Istatus = null;
            int? inull = null;
            SqlDataReader reader = null;
            int status = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            SqlParameter[] parm = new SqlParameter[6];
            try
            {
                parm[0] = new SqlParameter("@fromcust_id", SqlDbType.BigInt);
                parm[0].Value = FromCustID;
                parm[1] = new SqlParameter("@tocust_id", SqlDbType.BigInt);
                parm[1].Value = ToCustID;
                parm[2] = new SqlParameter("@EncriptedTextAccept", SqlDbType.VarChar);
                parm[2].Value = EncriptedText;
                parm[3] = new SqlParameter("@Typeofaction", SqlDbType.VarChar);
                parm[3].Value = strtypeOfReport;

                parm[4] = new SqlParameter("@Status", SqlDbType.Int);
                parm[4].Direction = ParameterDirection.Output;
                DataSet dsMessages = new DataSet();

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        Smtpemailsending smtp = new Smtpemailsending();
                        {
                            smtp.profile_name = (reader["profile_name"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("profile_name")) : string.Empty;
                            smtp.recipients = (reader["recipients"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("recipients")) : string.Empty;
                            smtp.body = (reader["body"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("body")) : string.Empty;
                            smtp.subject = (reader["subject"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("subject")) : string.Empty;
                            smtp.body_format = (reader["body_format"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("body_format")) : string.Empty;
                            Istatus = smtp.Status = (reader["Status"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Status")) : inull;
                        }
                        li.Add(smtp);

                    }
                    status = Istatus != null ? Convert.ToInt32(Istatus) : 0;
                    Commonclass.SendMailSmtpMethod(li, "info");
                }
                else
                {
                    if (string.Compare(System.DBNull.Value.ToString(), parm[4].Value.ToString()) == 0)
                    {
                        status = 0;
                    }
                    else
                    {
                        status = Convert.ToInt32(parm[4].Value);
                    }
                }
                reader.Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt32(FromCustID), null, null);
            }
            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return status;
        }

        public ViewfullProfileML ViewFullProfileMail(string OriginalString)
        {
            string strReplace = OriginalString.Replace(' ', '+');
            string s = strReplace;
            string[] urlString = s.Split('?');
            string[] spltMain;
            string strFromCustID = null;
            string strToCustID = null;
            const string strAccepted = "Accepted";
            const string strRejected = "Skipped";
            string spUnpaidStatus = "[dbo].[usp_insert_MarketingTicketHistory]";
            string FromProfileID = null, ToProfileID = null;
            ViewfullProfileML mobj = new ViewfullProfileML();
            try
            {
                string[] strAr = { s.Contains("MyProfileQSAccept") ? "?MyProfileQSAccept=" : "?MyProfileQSReject=" };
                string AccRejFlag = s.Contains("MyProfileQSAccept") ? "MailAccept" : "MailReject";
                spltMain = s.Split(strAr, StringSplitOptions.None);
                int status = 0;

                if (s.Contains("MyProfileQSAccept") || s.Contains("MyProfileQSReject"))
                {
                    CustSearchMl Mobj = new CustSearchMl();

                    if (spltMain.Length > 1)
                    {
                        string strencryptedTxt = spltMain[1];

                        string strProfileAccept = Commonclass.ViewProfileDecrypt(spltMain[1]);
                        string[] strprofileIDs = strProfileAccept.Split('&');
                        for (int i = 0; i < strprofileIDs.Length; i++)
                        {
                            string[] strsubval = strprofileIDs[i].Split('=');
                            switch (strsubval[0])
                            {
                                case "FromProfileID":
                                    strFromCustID = Convert.ToString(EmailMobilenumberexists_String(4, strsubval[1].ToString(), "[dbo].[usp_EmailMobilenumberexists_NewDesign]"));
                                    FromProfileID = Convert.ToString(EmailMobilenumberexists_String(10, strsubval[1].ToString(), "[dbo].[usp_EmailMobilenumberexists_NewDesign]"));
                                    break;
                                case "ToProfileID":
                                    strToCustID = Convert.ToString(EmailMobilenumberexists_String(4, strsubval[1].ToString(), "[dbo].[usp_EmailMobilenumberexists_NewDesign]"));
                                    ToProfileID = Convert.ToString(EmailMobilenumberexists_String(10, strsubval[1].ToString(), "[dbo].[usp_EmailMobilenumberexists_NewDesign]"));
                                    break;
                            }
                        }

                        Mobj.ToCustID = !string.IsNullOrEmpty(ToProfileID) ? Convert.ToInt64(ToProfileID) : 0;
                        Mobj.FromCustID = !string.IsNullOrEmpty(FromProfileID) ? Convert.ToInt64(FromProfileID) : 0;
                        int Profilestatus = 0;

                        ProfileStatus tupleu = CheckProfileStatus(Mobj, out Profilestatus);

                        if (tupleu.statuss == 1)
                        {

                            Mobj.EncriptedText = Commonclass.getEncryptedExpressIntrestString("FromProfileID=" + FromProfileID + "&" + "ToProfileID=" + strFromCustID + "&" + "Flag=" + 1);
                            Mobj.strtypeOfReport = AccRejFlag;

                            status = InsertExpressViewTicket(Mobj.FromCustID, Mobj.ToCustID, Mobj.EncriptedText, Mobj.strtypeOfReport, "[dbo].[Usp_InsertExpressViewTicket_new_NewDesign]");
                            string strtyofAction = status == 431 ? strAccepted : (status == 432 ? strRejected : string.Empty);

                            if ((AccRejFlag == "MailReject" && status == 432))
                            {
                                status = 6;
                            }
                            else if (AccRejFlag == "MailReject" && status != 432)
                            {
                                if (AccRejFlag == "MailReject" && status == 431)
                                {
                                    status = 7;
                                }
                                else
                                {
                                    status = 8;
                                }
                            }

                            if ((status == 1 && AccRejFlag != "MailReject") || (AccRejFlag == "MailAccept" && status == 431))
                            {
                                status = 9;
                            }

                            if (AccRejFlag == "MailAccept" && status == 432)
                            {
                                status = 10;
                            }
                            else if (status == 4)
                            {
                                InsertUnpaid Mobja = new InsertUnpaid();
                                Mobja.fromCustID = !string.IsNullOrEmpty(FromProfileID) ? FromProfileID : "0";
                                Mobja.ToCustID = !string.IsNullOrEmpty(ToProfileID) ? ToProfileID : "0";
                                Mobja.typeofAction = "viewed ";
                                int? intNULL = null;
                                int statuss = 0;
                                statuss = InsertUnpaidStatus(Mobja.fromCustID, Mobja.ToCustID, intNULL, Mobja.typeofAction, spUnpaidStatus);

                                status = 4;
                            }
                            else if (status == 5)
                            {
                                InsertUnpaid Mobja = new InsertUnpaid();
                                Mobja.fromCustID = !string.IsNullOrEmpty(FromProfileID) ? FromProfileID : "0";
                                Mobja.ToCustID = !string.IsNullOrEmpty(ToProfileID) ? ToProfileID : "0";
                                Mobja.typeofAction = "viewed ";
                                int? intNULL = null;
                                int statuss = 0;
                                statuss = InsertUnpaidStatus(Mobja.fromCustID, Mobja.ToCustID, intNULL, Mobja.typeofAction, spUnpaidStatus);
                                status = 5;
                            }
                            else if (status == 3 || status == 0)
                            {
                                status = 3;
                            }
                        }
                        else
                        {
                            if (tupleu.statuss == 2)
                            {

                                status = 11;
                            }
                            else if (tupleu.statuss == 3)
                            {

                                status = 12;
                            }
                            else if (tupleu.statuss == 4)
                            {
                                status = 13;

                            }
                            else
                            {
                                status = 14;
                            }
                        }
                    }
                    else
                    {
                        status = 15;
                    }
                }

                mobj.FromProfileID = strFromCustID;
                mobj.ToProfileID = strToCustID;
                mobj.FromCustID = FromProfileID;
                mobj.ToCustID = ToProfileID;
                mobj.status = status;
                mobj.AccRejFlag = AccRejFlag;
                DataSet ds = CustomerData(5, FromProfileID);

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        mobj.PrimaryEmail = !string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Email"].ToString()) ? ds.Tables[0].Rows[0]["Email"].ToString() : null;
                    }
                }
            }
            catch (Exception EX)
            {

                Commonclass.ApplicationErrorLog("[dbo].[usp_EmailMobilenumberexists_NewDesign]", Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                //SQLHelper.GetSQLConnection().Close();
                SqlConnection.ClearAllPools();
                //SQLHelper.GetSQLConnection().Dispose();
            }

            return mobj;
        }

        public ProfileStatus CheckProfileStatus(CustSearchMl Mobj, out int Profilestatus)
        {
            SqlParameter[] parm = new SqlParameter[6];
            SqlDataReader reader = null;
            ProfileStatus CP = new ProfileStatus();
            Profilestatus = 0;
            long? Lnull = null;
            int? Inull = null;
            Smtpemailsending smtp = new Smtpemailsending();
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@fromcust_id", SqlDbType.Int);
                parm[0].Value = Convert.ToInt32(Mobj.FromCustID);
                parm[1] = new SqlParameter("@tocust_id", SqlDbType.Int);
                parm[1].Value = Convert.ToInt32(Mobj.ToCustID);
                parm[2] = new SqlParameter("@status", SqlDbType.Int);
                parm[2].Direction = ParameterDirection.Output;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, "[dbo].[usp_select_checkProfileIdStatus]", parm);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.GetName(0) == "PrimaryEmail")
                        {
                            CP.PrimaryEmail = (reader["PrimaryEmail"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PrimaryEmail")) : null;
                            CP.statuss = (reader["statuss"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("statuss")) : 0;
                            Profilestatus = CP.statuss == 4 ? 4 : 0;
                        }
                        else
                        {
                            CP.OwnerName = (reader["OwnerName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("OwnerName")) : null;
                            CP.CustID = (reader["CustID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("CustID")) : Lnull;
                            CP.statuss = (reader["statuss"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("statuss")) : Inull;
                        }
                    }
                }

                if (Profilestatus == 4)
                {
                    reader.NextResult();
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            smtp.profile_name = (reader["profile_name"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("profile_name")) : string.Empty;
                            smtp.recipients = (reader["recipients"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("recipients")) : string.Empty;
                            smtp.body = (reader["body"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("body")) : string.Empty;
                            smtp.subject = (reader["subject"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("subject")) : string.Empty;
                            smtp.body_format = (reader["body_format"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("body_format")) : string.Empty;
                            li.Add(smtp);
                            Commonclass.SendMailSmtpMethod(li, "info");
                        }
                    }
                }

                reader.Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog("[dbo].[usp_select_checkProfileIdStatus]", Convert.ToString(EX.Message), Convert.ToInt32(Mobj.FromCustID), null, null);
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
            return CP;
        }

        public ArrayList ExpressIntrstfullprofile(string FromProfileID, int? EmpID, string spName)
        {
            DataSet dset = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[5];
                parm[0] = new SqlParameter("@strProfileID", SqlDbType.VarChar);
                parm[0].Value = FromProfileID;
                parm[1] = new SqlParameter("@intAdminId", SqlDbType.Int);
                parm[1].Value = EmpID;
                dset = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(ex.Message), Convert.ToInt32(FromProfileID), null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayList(dset);
        }

        public ArrayList Expressinterst_bookmark_ignore_data(long? Loggedcustid, long? ToCustID, string spName)
        {
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            DataSet dset = new DataSet();
            SqlCommand cmd = new SqlCommand(spName, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@loggedcustid", Loggedcustid);
                cmd.Parameters.AddWithValue("@tocust_id", ToCustID);
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(dset);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt32(Loggedcustid), null, null);
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
            return Commonclass.convertdataTableToArrayList(dset);
        }

        public int UpdateExpressIntrestViewfullprofile(UpdateExpressIntrestStatus Mobj, string spName)
        {
            SqlParameter[] parm = new SqlParameter[6];
            int intStatus = 0;

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@expressIntrestID", SqlDbType.BigInt);
                parm[0].Value = Mobj.ExpressInrestID;
                parm[1] = new SqlParameter("@MatchFollowupStatus", SqlDbType.BigInt);
                parm[1].Value = Mobj.MatchFollwupStatus;
                parm[2] = new SqlParameter("@ISAccepted", SqlDbType.Int);
                parm[2].Value = Mobj.AcceptStatus;
                parm[3] = new SqlParameter("@CustID", SqlDbType.BigInt);
                parm[3].Value = Mobj.CustID;
                parm[4] = new SqlParameter("@NoofDays", SqlDbType.Int);
                parm[4].Value = Mobj.noofDays;
                parm[5] = new SqlParameter("@Status", SqlDbType.Int);
                parm[5].Direction = ParameterDirection.Output;
                DataSet dsMessages = new DataSet();
                dsMessages = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);

                if (string.Compare(System.DBNull.Value.ToString(), parm[5].Value.ToString()) == 0) { intStatus = 0; }
                else { intStatus = Convert.ToInt32(parm[5].Value); }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(Mobj.spName, Convert.ToString(EX.Message), Convert.ToInt32(Mobj.CustID), null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return intStatus;
        }

        public ArrayList Cust_NotificationDetails(int? Cust_NotificationID, long? CustID, int? Startindex, int? EndIndex, string spName)
        {
            DataSet ds = new DataSet();
            SqlParameter[] parm = new SqlParameter[5];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@Cust_NotificationID", SqlDbType.Int);
                parm[0].Value = Cust_NotificationID;
                parm[1] = new SqlParameter("@CustID", SqlDbType.BigInt);
                parm[1].Value = CustID;
                parm[2] = new SqlParameter("@i_Startindex", SqlDbType.Int);
                parm[2].Value = Startindex;
                parm[3] = new SqlParameter("@i_EndIndex", SqlDbType.Int);
                parm[3].Value = EndIndex;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception Ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(Ex.Message), Convert.ToInt32(CustID), null, null);
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
            return Commonclass.convertdataTableToArrayList(ds);
        }

        public ArrayList Cust_NotificationDetails_Employee(int? EmpID, int? idisplay, int? NotificationID, int? CategoryID, int? CustID, string spName)
        {
            DataSet ds = new DataSet();
            SqlParameter[] parm = new SqlParameter[5];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parm[0].Value = EmpID;
                parm[1] = new SqlParameter("@i_display", SqlDbType.BigInt);
                parm[1].Value = idisplay;
                parm[2] = new SqlParameter("@i_NotificationID", SqlDbType.Int);
                parm[2].Value = NotificationID;
                parm[3] = new SqlParameter("@i_CategoryID", SqlDbType.Int);
                parm[3].Value = CategoryID;
                parm[4] = new SqlParameter("@CustID", SqlDbType.Int);
                parm[4].Value = CustID;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception Ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(Ex.Message), Convert.ToInt32(CustID), null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayList(ds);
        }

        public ArrayList CheckForgotPasswordStatus(string StrCustID, string spName)
        {
            DataSet ds = new DataSet();
            SqlParameter[] parm = new SqlParameter[2];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@CustID", SqlDbType.NVarChar);
                parm[0].Value = StrCustID;
                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;
                DataSet dsAstroInfo = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
                int intStatus = 0;
                intStatus = Convert.ToInt32(parm[1].Value);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt32(StrCustID), null, null);
            }
            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayList(ds);
        }

        public int ChangePassword(string StrCustID, string Password, string spName)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            int Status = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(spName, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustID", StrCustID);
                cmd.Parameters.AddWithValue("@Password", Password);
                SqlParameter outputParamStatus = cmd.Parameters.Add("@Status", SqlDbType.Int);
                outputParamStatus.Direction = ParameterDirection.Output;
                da.SelectCommand = cmd;
                da.Fill(ds);
                if (Convert.ToInt32(cmd.Parameters[2].Value) == 0)
                {
                    Status = 0;
                }
                else
                {
                    Status = Convert.ToInt32(cmd.Parameters[2].Value);
                }
                SQLHelper.GetSQLConnection().Close();
            }
            catch (Exception Ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(Ex.Message), Convert.ToInt32(StrCustID), null, null);
            }
            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return Status;
        }

        public ArrayList GetCustShortlistProfilesDal(string CustID)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            int iStatus = 0;

            try
            {

                SqlParameter[] parm = new SqlParameter[3];
                parm[0] = new SqlParameter("@custid", SqlDbType.VarChar);
                parm[0].Value = CustID;

                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;

                ds = SQLHelper.ExecuteDataset(SQLHelper.GetSQLConnection(), CommandType.StoredProcedure, "[dbo].[usp_GetSearchDataForShortlistProfiles_NewDesign]", parm);

                if (string.Compare(parm[1].Value.ToString(), System.DBNull.Value.ToString()) == 0)
                {
                    iStatus = 0;
                }
                else
                {
                    iStatus = Convert.ToInt32(parm[1].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog("usp_GetSearchDataForShortlistProfiles_NewDesign", Convert.ToString(EX.Message), Convert.ToInt32(CustID), "GetCustShortlistProfilesDal", null);
            }
            finally
            {

                SqlConnection.ClearAllPools();
            }
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }
            return Commonclass.convertdataTableToArrayList(ds);
        }

        public ArrayList CustomerViewAdminFullDetails(string ProfileID, int? EmpID, string spName)
        {
            DataSet dset = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[5];
                parm[0] = new SqlParameter("@strProfileID", SqlDbType.VarChar);
                parm[0].Value = ProfileID;
                parm[1] = new SqlParameter("@intAdminId", SqlDbType.Int);
                parm[1].Value = EmpID;
                dset = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(ex.Message), Convert.ToInt32(ProfileID), null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayList(dset);
        }

        public ArrayList EmployeeLoginCoutDetails(string spName)
        {
            DataSet dset = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[5];
                dset = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(ex.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayList(dset);
        }

        public string ipAddressReturn()
        {

            string strGatewayip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            string strBrowser = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];
            HttpRequest currentRequest = HttpContext.Current.Request;
            string ipAddress = currentRequest.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (ipAddress == null || ipAddress.ToLower() == "unknown")
                ipAddress = currentRequest.ServerVariables["REMOTE_ADDR"];

            string ip = null;

            ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(ip))
            {
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            return ip;
        }

        public int Update_EmailBounce(long? CustID, int? EmailBounceEntryId, string BounceMailid, string spName)
        {
            SqlParameter[] parm = new SqlParameter[6];
            int intStatus = 0;

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@intCust_id", SqlDbType.BigInt);
                parm[0].Value = CustID;
                parm[1] = new SqlParameter("@intEmailBounceEntryId", SqlDbType.Int);
                parm[1].Value = EmailBounceEntryId;
                parm[2] = new SqlParameter("@strBounceMailid", SqlDbType.VarChar, 8000);
                parm[2].Value = BounceMailid;
                parm[3] = new SqlParameter("@Status", SqlDbType.Int);
                parm[3].Direction = ParameterDirection.Output;
                DataSet dsMessages = new DataSet();
                dsMessages = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[3].Value.ToString()) == 0) { intStatus = 0; }
                else { intStatus = Convert.ToInt32(parm[3].Value); }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt32(CustID), null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return intStatus;
        }


        public int ChangeApplicationStatus(long? ProfileID, string spName)
        {
            SqlDataReader reader;
            Smtpemailsending smtp = new Smtpemailsending();
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            int status = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@ProfileID", SqlDbType.BigInt);
                parm[0].Value = ProfileID;
                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (string.Compare(parm[1].Value.ToString(), System.DBNull.Value.ToString()) == 0)
                {
                    status = 0;
                }
                else
                {
                    status = Convert.ToInt32(parm[1].Value);
                }

            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(ex.Message), Convert.ToInt32(ProfileID), null, null);
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

        public ArrayList CustomerHomePageDesignDataDal(string flag, int? casteID, long? CustID, int? intStartIndex, int? intEndIndex, int? GenderID, int? isActive, string Spname)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dataset = new DataSet();

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            SqlCommand cmd = new SqlCommand(Spname, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@v_dflag", flag);
                cmd.Parameters.AddWithValue("@CasteID", casteID);
                cmd.Parameters.AddWithValue("@CustID", CustID);

                cmd.Parameters.AddWithValue("@intStartIndex", intStartIndex);
                cmd.Parameters.AddWithValue("@intEndIndex", intEndIndex);
                cmd.Parameters.AddWithValue("@GenderID", GenderID);
                cmd.Parameters.AddWithValue("@isActive", isActive);

                da.SelectCommand = cmd;
                da.Fill(dataset);

            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(Spname, Convert.ToString(EX.Message), CustID, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayListTable(dataset);
        }

        public Tuple<string, int> ViewSettlementform(string Profileid, string Spname)
        {
            DataSet dset = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            int intStatus = 0;
            string imageUrl = "";
            try
            {
                SqlParameter[] parm = new SqlParameter[3];
                parm[0] = new SqlParameter("@Profileid", SqlDbType.VarChar, 5000);
                parm[0].Value = Profileid;
                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;
                SqlDataReader reader = null;

                dset = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, Spname, parm);


                if (dset.Tables.Count > 0 && dset.Tables[0].Rows.Count > 0)
                {
                    imageUrl = dset.Tables[0].Rows[0][0].ToString();
                }

                if (string.Compare(System.DBNull.Value.ToString(), Convert.ToString(parm[1].Value)) == 0)
                {
                    intStatus = 0;

                }
                else
                {
                    intStatus = Convert.ToInt32(parm[1].Value);

                }
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(Spname, Convert.ToString(ex.Message), Convert.ToInt32(Profileid), null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return new Tuple<string, int>(imageUrl, intStatus);
        }

        public int CheckprofileIDSelect(string Profileid, string spname)
        {
            DataSet dset = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            int intStatus = 0;

            try
            {
                SqlParameter[] Parm = new SqlParameter[3];
                Parm[0] = new SqlParameter("@ProfileID", SqlDbType.VarChar, 5000);
                Parm[0].Value = Profileid;
                Parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                Parm[1].Direction = ParameterDirection.Output;
                dset = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, Parm);
                if (dset.Tables.Count > 0)
                {
                    intStatus = 1;
                }
                else
                {
                    intStatus = 0;
                }
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(ex.Message), Convert.ToInt32(Profileid), null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return intStatus;
        }


        public int CustomerPaymentOffersAssign(CustomerPaymentOffers Customerpayoffers, string spName)
        {
            SqlParameter[] parm = new SqlParameter[15];
            int intStatus = 0;


            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();


            try
            {
                parm[0] = new SqlParameter("@i_ProfileID", SqlDbType.VarChar, 8000);
                parm[0].Value = Customerpayoffers.ProfileID;
                parm[1] = new SqlParameter("@i_MembershipID", SqlDbType.Int);
                parm[1].Value = Customerpayoffers.MembershipID;
                parm[2] = new SqlParameter("@i_CasteID", SqlDbType.Int);
                parm[2].Value = Customerpayoffers.CasteID;

                parm[3] = new SqlParameter("@f_MembershipAmt", SqlDbType.Decimal);
                parm[3].Value = Customerpayoffers.MembershipAmt;

                parm[4] = new SqlParameter("@f_ServiceTaxAmt", SqlDbType.Decimal);
                parm[4].Value = Customerpayoffers.ServiceTaxAmt;

                parm[5] = new SqlParameter("@i_AllocatedPts", SqlDbType.Int);
                parm[5].Value = Customerpayoffers.AllocatedPts;

                parm[6] = new SqlParameter("@i_MemberShipDuration", SqlDbType.DateTime);
                parm[6].Value = Customerpayoffers.MemberShipDuration;

                parm[7] = new SqlParameter("@dt_StartTime", SqlDbType.DateTime);
                parm[7].Value = Customerpayoffers.StartTime;

                parm[8] = new SqlParameter("@dt_EndDate", SqlDbType.DateTime);
                parm[8].Value = Customerpayoffers.EndDate;

                parm[9] = new SqlParameter("@i_BranchID", SqlDbType.Int);
                parm[9].Value = Customerpayoffers.BranchID;

                parm[10] = new SqlParameter("@Status", SqlDbType.Int);
                parm[10].Direction = ParameterDirection.Output;

                DataSet dsMessages = new DataSet();
                dsMessages = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[10].Value.ToString()) == 0) { intStatus = 0; }
                else { intStatus = Convert.ToInt32(parm[10].Value); }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt32(Customerpayoffers.ProfileID), null, null);

            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return intStatus;
        }



        public int CustomerProfileIDstatus(string ProfileID, string spName)
        {
            SqlParameter[] parm = new SqlParameter[15];
            int intStatus = 0;

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@ProfileID", SqlDbType.VarChar, 8000);
                parm[0].Value = ProfileID;

                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;

                DataSet dsMessages = new DataSet();
                dsMessages = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[1].Value.ToString()) == 0) { intStatus = 0; }
                else { intStatus = Convert.ToInt32(parm[1].Value); }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt32(ProfileID), null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return intStatus;
        }

        public ArrayList CustomerParofileIDbasePayment(string ProfileID, int? BranchID, string spName)
        {
            DataSet dsProfileSearch = new DataSet();
            SqlParameter[] parm = new SqlParameter[10];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            int intStatus = 0;
            string strErrorMsg = null;
            try
            {
                parm[0] = new SqlParameter("@ProfileID", SqlDbType.VarChar, 20);
                parm[0].Value = ProfileID;
                parm[1] = new SqlParameter("@BranchID", SqlDbType.Int);
                parm[1].Value = BranchID;
                parm[2] = new SqlParameter("@Status", SqlDbType.Int);
                parm[2].Direction = ParameterDirection.Output;
                parm[3] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
                parm[3].Direction = ParameterDirection.Output;
                dsProfileSearch = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);

                if (string.Compare(System.DBNull.Value.ToString(), parm[2].Value.ToString()) == 0)
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[2].Value);
                }
                if (string.Compare(System.DBNull.Value.ToString(), parm[3].Value.ToString()) == 0)
                {
                    strErrorMsg = "System.DBNull returned from database";
                }
                else
                {
                    strErrorMsg = parm[3].Value.ToString();
                }
            }

            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt32(ProfileID), null, null);
            }
            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayListTable(dsProfileSearch);
        }

        public ArrayList CustomerUnauthorizedPayments(string BranchID, string StartDate, string EndDate, string Region, string spName)
        {
            DataSet dsGetUnauthorizedPayments = new DataSet();
            SqlParameter[] parm = new SqlParameter[6];

            int intStatus = 0;
            string strErrorMsg = null;

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@BranchID", SqlDbType.VarChar);
                parm[0].Value = BranchID;
                parm[1] = new SqlParameter("@StartDate", SqlDbType.VarChar);
                parm[1].Value = StartDate;
                parm[2] = new SqlParameter("@EndDate", SqlDbType.VarChar);
                parm[2].Value = EndDate;
                parm[3] = new SqlParameter("@Region", SqlDbType.VarChar);
                parm[3].Value = Region;
                parm[4] = new SqlParameter("@Status", SqlDbType.Int);
                parm[4].Direction = ParameterDirection.Output;
                parm[5] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
                parm[5].Direction = ParameterDirection.Output;
                dsGetUnauthorizedPayments = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[4].Value.ToString()) == 0)
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[4].Value);
                }
                if (string.Compare(System.DBNull.Value.ToString(), parm[5].Value.ToString()) == 0)
                {
                    strErrorMsg = "System.DBNull returned from database";
                }
                else
                {
                    strErrorMsg = parm[5].Value.ToString();
                }
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

            if (dsGetUnauthorizedPayments.Tables.Count == 0)
                dsGetUnauthorizedPayments = null;
            return Commonclass.convertdataTableToArrayListTable(dsGetUnauthorizedPayments); ;
        }




    }
}

