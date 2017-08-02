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
    public class UserLoginDAL
    {
        public List<userLoginML> DGetLogininformationdetails(CustLoginMl Mobj)
        {
            int status = 0;
            List<userLoginML> userLogin = null;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KakConnection"].ToString());
            connection.Open();
            try
            {

                SqlCommand command = new SqlCommand("Usp_CheckCustLogin", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Username", Mobj.Username);
                command.Parameters.AddWithValue("@Password", Commonclass.Encrypt(Mobj.Password));
                SqlParameter outputParamStatus = command.Parameters.Add("@Status", SqlDbType.Int);
                outputParamStatus.Direction = ParameterDirection.Output;

                SqlDataReader reader;

                reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        userLogin = new List<userLoginML>
                    {
                        new userLoginML
                        {

                            CustID = (reader["CustID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("CustID")) : 0,

                            FirstName = (reader["FirstName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FirstName")) : null,
                           
                            LastName = (reader["LastName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("LastName")) : null,
                            
                            ReligionName = (reader["ReligionName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ReligionName")) : null,
                            
                            CasteName = (reader["CasteName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CasteName")) : null,

                            CasteID = (reader["CasteID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CasteID")) : 0,

                            MotherTongueName = (reader["MotherTongueName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MotherTongueName")) : null,

                            GenderID = (reader["GenderID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("GenderID")) : 0,

                            Email = (reader["Email"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Email")) : null,

                            MotherTongueID = (reader["MotherTongueID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("MotherTongueID")) : 0,

                            ReligionID = (reader["ReligionID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ReligionID")) : 0,

                            ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : null,

                            VerificationCode = (reader["VerificationCode"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("VerificationCode")) : null,

                            FamilyID = (reader["FamilyID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("FamilyID")) : 0,

                            PaidStatus = (reader["PaidStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PaidStatus")) : 0,

                            PartnerCastedata = (reader["PartnerCastedata"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PartnerCastedata")) : null,

                            PhotoStatus = (reader["PhotoStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoStatus")) : 0,

                            PhotoCount = (reader["PhotoCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoCount")) : 0,

                            ViewProfileFlag = (reader["ViewProfileFlag"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("ViewProfileFlag")) : false,

                            ResigNophotoFlgPaid = (reader["ResigNophotoFlgPaid"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ResigNophotoFlgPaid")) : 0,

                            SuccessStoryFlag = (reader["SuccessStoryFlag"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("SuccessStoryFlag")) : 0,

                            Emailverified = (reader["Emailverified"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Emailverified")) : 0,

                            strProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : null,

                            Flag = (reader["Flag"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Flag")) : 0,

                            cust_emailid = (reader["cust_emailid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("cust_emailid")) : 0,
                            
                            email = (reader["email"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("email")) : null,
                            
                            isemailverified = (reader["isemailverified"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("isemailverified")) : false,

                            cust_contant_id = (reader["cust_contant_id"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("cust_contant_id")) : 0,
                            
                            number = (reader["number"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("number")) : null,
                            
                            isnumberverifed = (reader["isnumberverifed"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("isnumberverifed")) : false,
                            
                            MObileverficationcode = (reader["MObileverficationcode"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MObileverficationcode")) : null,

                            ProfilePic=(reader["ProfilePic"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfilePic")) : null
                        },
                    };
                    }
                }

                reader.Close();
                status = (int)command.Parameters["@Status"].Value;

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
            return userLogin;
        }
        public Tuple<EmpDetailsMl, List<MenuItem>, List<ScrollText>, List<StarRating>, int> ValidateLoginNew(string LoginName, string Password, string sMAC, string spName)
        {

            int intstatus = 0;
            SqlParameter[] param = new SqlParameter[5];

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            EmpDetailsMl empDetails = new EmpDetailsMl();

            List<MenuItem> lstPagePermissions = new List<MenuItem>();
            List<ScrollText> lscroll = new List<ScrollText>();
            List<StarRating> lstarrating = new List<StarRating>();

            try
            {
                param[0] = new SqlParameter("@LoginName", System.Data.SqlDbType.VarChar);
                param[0].Value = LoginName;
                param[1] = new SqlParameter("@Password", System.Data.SqlDbType.VarChar);
                param[1].Value = Password;
                param[2] = new SqlParameter("@Mac", System.Data.SqlDbType.VarChar);
                param[2].Value = sMAC;
                param[3] = new SqlParameter("@ErrorMsg", System.Data.SqlDbType.VarChar, 10000);
                param[3].Direction = ParameterDirection.Output;
                param[4] = new SqlParameter("@Status", System.Data.SqlDbType.Int);
                param[4].Direction = ParameterDirection.Output;

                DataSet dsLogin = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, param);
                if (string.Compare(System.DBNull.Value.ToString(), param[4].Value.ToString()) == 0) { intstatus = 0; }
                else
                {
                    intstatus = Convert.ToInt32(param[4].Value);
                }

                if (string.Compare(System.DBNull.Value.ToString(), param[4].Value.ToString()) == 0)
                {
                    intstatus = 0;
                }
                else
                {
                    if (param[4].Value.ToString() == "1")
                    {
                        int? intNull = null;
                        DateTime datetimeNull = Convert.ToDateTime(null);

                        DataTable dtLogin = dsLogin.Tables[0];
                        empDetails.EmpID = Int64.Parse(dtLogin.Rows[0]["EmpID"].ToString());
                        empDetails.FirstName = dtLogin.Rows[0]["FirstName"].ToString();
                        empDetails.LastName = dtLogin.Rows[0]["LastName"].ToString();
                        empDetails.WorkingStartTIme = DateTime.Parse(dtLogin.Rows[0]["WorkingStartTime"].ToString());
                        empDetails.WorkingEndTIme = DateTime.Parse(dtLogin.Rows[0]["WorkingEndTIme"].ToString());
                        empDetails.DesignationID = int.Parse(dtLogin.Rows[0]["DesignationID"].ToString());
                        empDetails.ReportingMngrID = (dtLogin.Rows[0]["ReportingMngrID"] != DBNull.Value) ? int.Parse(dtLogin.Rows[0]["ReportingMngrID"].ToString()) : 0;
                        empDetails.BranchID = int.Parse(dtLogin.Rows[0]["BranchID"].ToString());
                        empDetails.LastLoginDate = !string.IsNullOrEmpty(dtLogin.Rows[0]["LastLoginDate"].ToString()) ? DateTime.Parse(dtLogin.Rows[0]["LastLoginDate"].ToString()) : datetimeNull;
                        empDetails.Email = dtLogin.Rows[0]["Email"].ToString();
                        empDetails.isAdmin = !string.IsNullOrEmpty(dtLogin.Rows[0]["isAdmin"].ToString()) ? Convert.ToInt32(dtLogin.Rows[0]["isAdmin"].ToString()) : -1;
                        empDetails.RegionID = !string.IsNullOrEmpty(dtLogin.Rows[0]["Region"].ToString()) ? Convert.ToInt32(dtLogin.Rows[0]["Region"].ToString()) : intNull;
                        empDetails.isManagement = !string.IsNullOrEmpty(dtLogin.Rows[0]["isManagement"].ToString()) ? Convert.ToBoolean(dtLogin.Rows[0]["isManagement"].ToString()) : false;
                        empDetails.EmpPhotoPath = !string.IsNullOrEmpty(dtLogin.Rows[0]["EmpPhotoPath"].ToString()) ? dtLogin.Rows[0]["EmpPhotoPath"].ToString() : null;

                        //  MenuItem MenuItemlist = new MenuItem();
                        //ScrollText scrolltext = new ScrollText();
                        // StarRating starRating = new StarRating();

                        //if (dsLogin.Tables.Count > 0 && dsLogin.Tables[1].Rows.Count > 0)
                        //{
                        //    for (int i = 0; i < dsLogin.Tables[1].Rows.Count; i++)
                        //    {
                        //        lstPagePermissions.Add(new MenuItem
                        //        {
                        //            MenuID = !string.IsNullOrEmpty(Convert.ToString(dsLogin.Tables[1].Rows[i]["menuid"])) ? Convert.ToInt32(Convert.ToString(dsLogin.Tables[1].Rows[i]["menuid"])) : intNull,
                        //            ParentMenuID = !string.IsNullOrEmpty(Convert.ToString(dsLogin.Tables[1].Rows[i]["parentmenuid"])) ? (Convert.ToInt32(Convert.ToString(dsLogin.Tables[1].Rows[i]["ParentMenuID"]))) : intNull,
                        //            View = Convert.ToBoolean(Convert.ToString(dsLogin.Tables[1].Rows[i]["view"])),
                        //            Add = Convert.ToBoolean(Convert.ToString(dsLogin.Tables[1].Rows[i]["Add"])),
                        //            Edit = Convert.ToBoolean(Convert.ToString(dsLogin.Tables[1].Rows[i]["Edit"])),
                        //            Delete = Convert.ToBoolean(Convert.ToString(dsLogin.Tables[1].Rows[i]["Delete"])),
                        //            URL = Convert.ToString(dsLogin.Tables[1].Rows[i]["PageURL"]),
                        //            ToolTip = Convert.ToString(dsLogin.Tables[1].Rows[i]["ToolTip"]),
                        //            Title = Convert.ToString(dsLogin.Tables[1].Rows[i]["MenuName"])
                        //        });
                        //    }
                        //}

                        //if (dsLogin.Tables.Count > 2)
                        //{
                        //    if (dsLogin.Tables[2].Rows.Count > 0)
                        //    {
                        //        for (int j = 0; j < dsLogin.Tables[2].Rows.Count; j++)
                        //        {
                        //            lscroll.Add(new ScrollText
                        //            {
                        //                str_scrollText = !string.IsNullOrEmpty(Convert.ToString(dsLogin.Tables[2].Rows[0]["scrolltext"])) ? Convert.ToString(dsLogin.Tables[2].Rows[0]["scrolltext"]) : string.Empty,
                        //            }
                        //            );
                        //        }
                        //    }
                        //}

                        //if (dsLogin.Tables.Count >= 3)
                        //{
                        //    if (dsLogin.Tables[3].Rows.Count > 0)
                        //    {
                        //        for (int j = 0; j < dsLogin.Tables[3].Rows.Count; j++)
                        //        {
                        //            lstarrating.Add(new StarRating
                        //            {
                        //                str_StarRating = !string.IsNullOrEmpty(Convert.ToString(dsLogin.Tables[3].Rows[0]["presentstar"])) ? Convert.ToString(dsLogin.Tables[3].Rows[0]["presentstar"]) : string.Empty,
                        //                str_daystar = !string.IsNullOrEmpty(Convert.ToString(dsLogin.Tables[3].Rows[0]["daystar"])) ? Convert.ToString(dsLogin.Tables[3].Rows[0]["daystar"]) : string.Empty,
                        //            }
                        //            );
                        //        }
                        //    }
                        //}
                    }
                    else
                    {
                        // intstatus = 0;
                    }
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

            return new Tuple<EmpDetailsMl, List<MenuItem>, List<ScrollText>, List<StarRating>, int>(empDetails, lstPagePermissions, lscroll, lstarrating, intstatus);
        }
    }
}