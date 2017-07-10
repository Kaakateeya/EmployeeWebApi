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

    public class Dashboard
    {
        public DashboardClass LandingCountsDal(int? CustID, string TypeOfReport, int pagefrom, int pageto, string spName)
        {
            DashboardClass land = new DashboardClass();
            List<PartnerProfilesLatest> PartnerLi = new List<PartnerProfilesLatest>();

            SqlDataReader reader;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            int? inull = null;
            bool? bnull = null;
            SqlConnection con = null;
            Int64? Lnull = null;
            List<PersonalInfo> liPerson = new List<PersonalInfo>();

            try
            {
                SqlParameter[] parm = new SqlParameter[6];

                parm[0] = new SqlParameter("@custID", SqlDbType.Int);
                parm[0].Value = CustID;

                parm[1] = new SqlParameter("@TypeOfReport", SqlDbType.VarChar);
                parm[1].Value = TypeOfReport;
                parm[2] = new SqlParameter("@pagefrom", SqlDbType.Int);
                parm[2].Value = pagefrom;
                parm[3] = new SqlParameter("@pageto", SqlDbType.Int);
                parm[3].Value = pageto;

                using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["KakConnection"].ToString()))
                {
                    con.Open();
                    reader = SQLHelper.ExecuteReader(con, CommandType.StoredProcedure, spName, parm);

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            LandingPartnerMenu liCount = new LandingPartnerMenu();
                            {

                                liCount.SaveSearchCount = reader["SavesSearchCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("SavesSearchCount")) : inull;
                                liCount.WhobookmarkedCount = reader["WhoBookmarkedCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("WhoBookmarkedCount")) : inull;
                                liCount.MybookMarkedProfCount = reader["BookmarkCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("BookmarkCount")) : inull;
                                liCount.RectViewedProfCount = reader["ViewedCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ViewedCount")) : inull;
                                liCount.RectWhoViewedCout = reader["WhoViewedCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("WhoViewedCount")) : inull;
                                liCount.IgnoreProfileCount = reader["IgnoreCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IgnoreCount")) : inull;
                                //express and Counts Bind

                                liCount.ExpressIntSent = reader["ExpressSentCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ExpressSentCount")) : inull;
                                liCount.ExpressIntReceived = reader["ExpressReceiveCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ExpressReceiveCount")) : inull;
                                liCount.ExpressAllcount = reader["ExpressAllcount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ExpressAllcount")) : inull;

                                liCount.NewMsgs = reader["NewMessageCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("NewMessageCount")) : inull;
                                liCount.TotalMsgs = reader["TotalMessageCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TotalMessageCount")) : inull;

                                liCount.SentPhotoRequestCount = reader["PhotoRequestSentCount"] != DBNull.Value ? Convert.ToInt32(reader.GetString(reader.GetOrdinal("PhotoRequestSentCount"))) : inull;
                                liCount.SentHoroRequestCount = reader["HoroRequestSentCount"] != DBNull.Value ? Convert.ToInt32(reader.GetString(reader.GetOrdinal("HoroRequestSentCount"))) : inull;
                                liCount.ReceivedPhotoRequestCount = reader["PhotoRequestReceivedCount"] != DBNull.Value ? Convert.ToInt32(reader.GetString(reader.GetOrdinal("PhotoRequestReceivedCount"))) : inull;
                                liCount.ReceivedHoroRequestCount = reader["HoroRequestReceivedCount"] != DBNull.Value ? Convert.ToInt32(reader.GetString(reader.GetOrdinal("HoroRequestReceivedCount"))) : inull;

                                liCount.SentProtectedReply = reader["SentProtectedNewCount"] != DBNull.Value ? Convert.ToInt32(reader.GetString(reader.GetOrdinal("SentProtectedNewCount"))) : inull;
                                liCount.SentProtectedAccept = reader["SentProtectedAcceptCount"] != DBNull.Value ? Convert.ToInt32(reader.GetString(reader.GetOrdinal("SentProtectedAcceptCount"))) : inull;
                                liCount.SentProtectedReject = reader["SentProtectedRejectCount"] != DBNull.Value ? Convert.ToInt32(reader.GetString(reader.GetOrdinal("SentProtectedRejectCount"))) : inull;
                                liCount.ReceivedProtectedNew = reader["ReceivedProtectedNewCount"] != DBNull.Value ? Convert.ToInt32(reader.GetString(reader.GetOrdinal("ReceivedProtectedNewCount"))) : inull;
                                liCount.ReceivedProtectedAccept = reader["ReceivedProtectedAcceptCount"] != DBNull.Value ? Convert.ToInt32(reader.GetString(reader.GetOrdinal("ReceivedProtectedAcceptCount"))) : inull;
                                liCount.ReceivedProtectedReject = reader["ReceivedProtectedRejectCount"] != DBNull.Value ? Convert.ToInt32(reader.GetString(reader.GetOrdinal("ReceivedProtectedRejectCount"))) : inull;
                                land.DashBoardCounts = liCount;
                            }

                        }
                    }
                    reader.NextResult();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            PersonalInfo Pcls = new PersonalInfo();
                            Pcls.TableName = reader["TableName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("TableName")) : null;
                            Pcls.ProfileID = reader["ProfileID"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : null;
                            Pcls.GenderID = reader["GenderID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("GenderID")) : inull;
                            Pcls.NAME = reader["NAME"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("NAME")) : null;
                            Pcls.PaidMember = reader["PaidMember"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PaidMember")) : inull;
                            Pcls.ProfileLastModifieddate = reader["ProfileLastModifieddate"] != DBNull.Value ? (reader.GetDateTime(reader.GetOrdinal("ProfileLastModifieddate"))).ToString() : null;
                            Pcls.PhotoName = reader["PhotoName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoName")) : null;
                            Pcls.PhotoName_Cust = reader["PhotoName_Cust"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoName_Cust")) : inull;
                            Pcls.MsgReceivedFrom = reader["MsgReceivedFrom"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("MsgReceivedFrom")) : null;
                            Pcls.MsgReceivedDate = reader["MsgReceivedDate"] != DBNull.Value ? (reader.GetDateTime(reader.GetOrdinal("MsgReceivedDate"))).ToString() : null;
                            Pcls.ProfilePhotoName = reader["ProfilePhotoName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfilePhotoName")) : null;
                            Pcls.IsReviewed = reader["IsReviewed"] != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("IsReviewed")) : bnull;
                            Pcls.IsActive = reader["IsActive"] != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("IsActive")) : bnull;
                            Pcls.ProfileBattery = reader["ProfileBattery"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProfileBattery")) : inull;
                            Pcls.EmpID = reader["EmpID"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("EmpID")) : Lnull;
                            Pcls.EmpPhone = reader["EmpPhone"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("EmpPhone")) : null;
                            Pcls.OfficialContactNumber = reader["OfficialContactNumber"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("OfficialContactNumber")) : null;
                            Pcls.EmployeeName = reader["EmployeeName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("EmployeeName")) : null;
                            Pcls.EmailID = reader["EmailID"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("EmailID")) : null;
                            Pcls.PhotoViewCount = reader["PhotoViewCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoViewCount")) : inull;
                            Pcls.PartnetPrefernceLastOnemonth = reader["PartnetPrefernceLastOnemonth"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PartnetPrefernceLastOnemonth")) : inull;
                            Pcls.Photo = reader["Photo"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Photo")) : null;
                            Pcls.MaskDiv = (!string.IsNullOrEmpty(Pcls.ProfilePhotoName) && (Pcls.IsReviewed == true && Pcls.IsActive == true)) ? " " : ((!string.IsNullOrEmpty(Pcls.ProfilePhotoName) && (Pcls.IsReviewed == true || Pcls.IsActive == true)) ? "divCSSclass clearfix" : "cssMaskupload clearfix");
                            land.PersonalInfo = Pcls;
                        }

                    }
                    reader.NextResult();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            PartnerProfilesLatest Partnercls = ReturnPartnerProfilesClass(reader, "Partner");
                            PartnerLi.Add(Partnercls);
                        }

                        land.PartnerProfilesnew = PartnerLi;
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(ex.Message), CustID, null, null);
            }
            finally
            {

                con.Close();
                SqlConnection.ClearPool(con);
                SqlConnection.ClearAllPools();
            }
            return land;
        }
        public DashboardClass GetPartnerProfilesDal(int? CustID, string TypeOfReport, int pagefrom, int pageto, string spName)
        {
            DashboardClass land = new DashboardClass();
            List<PartnerProfilesLatest> PartnerLi = new List<PartnerProfilesLatest>();
            SqlDataReader reader;
            SqlConnection con = null;
            try
            {
                SqlParameter[] parm = new SqlParameter[6];

                parm[0] = new SqlParameter("@custID", SqlDbType.Int);
                parm[0].Value = CustID;

                parm[1] = new SqlParameter("@TypeOfReport", SqlDbType.VarChar);
                parm[1].Value = TypeOfReport;
                parm[2] = new SqlParameter("@pagefrom", SqlDbType.Int);
                parm[2].Value = pagefrom;
                parm[3] = new SqlParameter("@pageto", SqlDbType.Int);
                parm[3].Value = pageto;
                using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["KakConnection"].ToString()))
                {
                    con.Open();
                    reader = SQLHelper.ExecuteReader(con, CommandType.StoredProcedure, spName, parm);

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            PartnerProfilesLatest Partnercls = ReturnPartnerProfilesClass(reader, "Partner");
                            PartnerLi.Add(Partnercls);
                        }
                        land.PartnerProfilesnew = PartnerLi;
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(ex.Message), CustID, null, null);
            }
            finally
            {

                con.Close();
                SqlConnection.ClearPool(con);
                SqlConnection.ClearAllPools();
            }

            return land;
        }

        public List<PartnerProfilesLatest> ExpressInterestSelectDal(DashboardRequest Dreq)
        {
            List<PartnerProfilesLatest> PartnerLi = new List<PartnerProfilesLatest>();
            SqlDataReader reader;
            SqlConnection connection = null;
            try
            {
                SqlParameter[] parm = new SqlParameter[6];

                parm[0] = new SqlParameter("@custId", SqlDbType.Int);
                parm[0].Value = Dreq.IntCustID;
                parm[1] = new SqlParameter("@typeofData", SqlDbType.VarChar);
                parm[1].Value = Dreq.TypeOfReport;
                parm[2] = new SqlParameter("@yourFilter", SqlDbType.VarChar);
                parm[2].Value = Dreq.yourFilter;
                parm[3] = new SqlParameter("@oppfilter", SqlDbType.VarChar);
                parm[3].Value = Dreq.oppfilter;
                parm[4] = new SqlParameter("@pagefrom", SqlDbType.Int);
                parm[4].Value = Dreq.pagefrom;
                parm[5] = new SqlParameter("@pageto", SqlDbType.Int);
                parm[5].Value = Dreq.pageto;

                using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KakConnection"].ToString()))
                {
                    connection.Open();
                    reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, "[dbo].[usp_select_customerDashboard_ExpressInterest]", parm);

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            PartnerProfilesLatest Partnercls = ReturnPartnerProfilesClass(reader, "ExpressInterest");
                            PartnerLi.Add(Partnercls);
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog("[dbo].[usp_select_customerDashboard_ExpressInterest]", Convert.ToString(ex.Message), Dreq.IntCustID, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }

            return PartnerLi;
        }
        public PartnerProfilesLatest ReturnPartnerProfilesClass(SqlDataReader reader, string Type)
        {

            int? inull = null;
            bool? bnull = null;
            DateTime? dnull = null;
            Int64? Lnull = null;
            PartnerProfilesLatest Partnercls = new PartnerProfilesLatest();
            Partnercls.Row = reader["Row"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Row")) : inull;
            Partnercls.TableName = reader["TableName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("TableName")) : null;
            Partnercls.ProfileID = reader["ProfileID"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : null;
            Partnercls.Cust_ID = reader["Cust_ID"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_ID")) : Lnull;
            Partnercls.intCusID = reader["Cust_ID"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_ID")) : Lnull;
            Partnercls.NAME = reader["NAME"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("NAME")) : null;
            Partnercls.LastName = reader["LastName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("LastName")) : null;
            Partnercls.DateOfBirth = reader["DateOfBirth"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("DateOfBirth"))) : null;
            Partnercls.Age = reader["Age"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Age")) : inull;
            Partnercls.Height = reader["Height"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Height")) : null;
            Partnercls.ReligionName = reader["ReligionName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ReligionName")) : null;
            Partnercls.Caste = reader["Caste"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Caste")) : null;
            Partnercls.Education = reader["Education"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Education")) : null;
            Partnercls.EducationGroup = reader["EducationGroup"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationGroup")) : null;
            Partnercls.profession = reader["profession"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("profession")) : null;
            Partnercls.Profession = reader["profession"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("profession")) : null;
            Partnercls.PhoneNumber = reader["PhoneNumber"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhoneNumber")) : null;
            Partnercls.Email = reader["Email"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Email")) : null;
            Partnercls.Star = reader["Star"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Star")) : null;
            Partnercls.placeofbirth = reader["placeofbirth"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("placeofbirth")) : null;
            Partnercls.Location = reader["Location"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Location")) : null;
            Partnercls.HoroscopeImage = reader["HoroscopeImage"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("HoroscopeImage")) : null;
            Partnercls.PhotosCount = reader["PhotosCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotosCount")) : inull;
            Partnercls.PhotoCount = reader["PhotosCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotosCount")) : inull;
            Partnercls.Photoname = reader["Photoname"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Photoname")) : null;
            Partnercls.mybookmarked = reader["mybookmarked"] != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("mybookmarked")) : bnull;
            Partnercls.recentlyviewes = reader["recentlyviewes"] != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("recentlyviewes")) : bnull;
            Partnercls.ignode = reader["ignode"] != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("ignode")) : bnull;
            Partnercls.TotalRows = reader["TotalRows"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TotalRows")) : inull;
            Partnercls.ExpressFlag = reader["ExpressFlag"] != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("ExpressFlag")) : bnull;
            Partnercls.IsPaidMember = reader["IsPaidMember"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsPaidMember")) : inull;
            Partnercls.iGenderID = reader["iGenderID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iGenderID")) : inull;
            Partnercls.iCasteID = reader["iCasteID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iCasteID")) : inull;
            Partnercls.iStarID = reader["iStarID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iStarID")) : inull;
            Partnercls.iCountryID = reader["iCountryID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iCountryID")) : inull;
            Partnercls.iReligionID = reader["iReligionID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iReligionID")) : inull;
            Partnercls.iProfessionGroupID = reader["iProfessionGroupID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iProfessionGroupID")) : inull;
            Partnercls.ProfessionID = reader["ProfessionID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProfessionID")) : inull;
            Partnercls.iEducationGroupID = reader["iEducationGroupID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iEducationGroupID")) : inull;
            Partnercls.iHeightInCentimeters = reader["iHeightInCentimeters"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iHeightInCentimeters")) : inull;
            Partnercls.iStarLanguageID = reader["iStarLanguageID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iStarLanguageID")) : inull;
            Partnercls.iCityID = reader["iCityID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iCityID")) : inull;
            Partnercls.iStateID = reader["iStateID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iStateID")) : inull;
            Partnercls.MaritalStatusID = reader["MaritalStatusID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("MaritalStatusID")) : inull;
            Partnercls.MaritualStatus = reader["MaritualStatus"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("MaritualStatus")) : null;
            Partnercls.Photo = reader["Photo"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Photo")) : null;
            Partnercls.DescribeYourSelf = reader["DescribeYourSelf"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("DescribeYourSelf")) : null;
            Partnercls.DistName = reader["DistName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("DistName")) : null;

            if (Type == "ExpressInterest")
            {
                Partnercls.ServiceGivenBanch = reader["ServiceGivenBanch"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ServiceGivenBanch")) : null;
                Partnercls.SuggestEmpName = reader["SuggestEmpName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("SuggestEmpName")) : null;
                Partnercls.SuggestedEmpNumber = reader["SuggestedEmpNumber"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("SuggestedEmpNumber")) : null;
                Partnercls.SuggestionFlag = reader["SuggestionFlag"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("SuggestionFlag")) : inull;
                Partnercls.NewCount = reader["NewCount"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("NewCount")) : Lnull;
                Partnercls.AcceptCount = reader["AcceptCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("AcceptCount")) : inull;
                Partnercls.RejectCount = reader["RejectCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("RejectCount")) : inull;
                Partnercls.RelationShipManagerName = reader["RelationShipManagerName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("RelationShipManagerName")) : null;
                Partnercls.RelationShipManagerNumber = reader["RelationShipManagerNumber"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("RelationShipManagerNumber")) : null;
                Partnercls.LogID = reader["LogID"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("LogID")) : Lnull;
                Partnercls.LogId = reader["LogID"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("LogID")) : Lnull;
                Partnercls.RelationShipManagerEmail = reader["RelationShipManagerEmail"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("RelationShipManagerEmail")) : null;
                Partnercls.Mystatus = reader["Mystatus"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Mystatus")) : null;
                Partnercls.OppStatus = reader["OppStatus"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("OppStatus")) : null;
                Partnercls.TicketID = reader["TicketID"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("TicketID")) : Lnull;
                Partnercls.CreatedDate = reader["CreatedDate"] != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("CreatedDate")) : dnull;
                Partnercls.CommunicationHistoryFlag = reader["CommunicationHistoryFlag"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CommunicationHistoryFlag")) : inull;
                Partnercls.YouProceed = reader["YouProceed"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("YouProceed")) : inull;
                Partnercls.Youskipped = reader["Youskipped"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Youskipped")) : inull;
                Partnercls.YouPending = reader["YouPending"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("YouPending")) : inull;
                Partnercls.OppProceed = reader["OppProceed"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("OppProceed")) : inull;
                Partnercls.Oppskipped = reader["Oppskipped"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Oppskipped")) : inull;
                Partnercls.Opppending = reader["Opppending"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Opppending")) : inull;
            }
            else
            {
                Partnercls.RequestDate = reader["RequestDate"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("RequestDate")) : null;
            }

            SqlConnection.ClearAllPools();
            return Partnercls;
        }
        public List<DashboardRequestChats> DgetCustometExpressIntrestDashBoardchats(long? CustID, int? Status, int iStartIndex, int iEndIndex, string spName)
        {
            List<DashboardRequestChats> dropdownfilling = new List<DashboardRequestChats>();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["KakConnection"].ToString());
            connection.Open();
            try
            {
                int? iNULL = null;
                Int64? iNULL64 = null;
                DateTime? datetimenull = null;

                SqlCommand command = new SqlCommand(spName, connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CustID", CustID);
                command.Parameters.AddWithValue("@Status", Status);
                command.Parameters.AddWithValue("@i_StartIndex", iStartIndex);
                command.Parameters.AddWithValue("@i_EndIndex", iEndIndex);
                SqlDataReader reader;
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DashboardRequestChats dashboardchats = new DashboardRequestChats
                        {

                            ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ProfileID")) : iNULL64,
                            Cust_MessageLink_Id = (reader["Cust_MessageLink_Id"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_MessageLink_Id")) : iNULL64,
                            Cust_MessageHistory_Id = (reader["Cust_MessageHistory_Id"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_MessageHistory_Id")) : iNULL64,
                            NAME = (reader["NAME"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("NAME")) : null,
                            CustID = (reader["CustID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CustID")) : iNULL,
                            DateOfBirth = (reader["DateOfBirth"]) != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("DateOfBirth")) : datetimenull,
                            Age = (reader["Age"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Age")) : iNULL,
                            CasteID = (reader["CasteID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CasteID")) : iNULL,
                            Caste = (reader["Caste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Caste")) : null,
                            HeightInCentimeters = (reader["HeightInCentimeters"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("HeightInCentimeters")) : null,
                            Education = (reader["Education"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Education")) : null,
                            Profession = (reader["Profession"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Profession")) : null,
                            IsAccepted = (reader["IsAccepted"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsAccepted")) : iNULL,
                            Body = (reader["Body"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Body")) : null,
                            RequestDate = (reader["RequestDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RequestDate")) : null,
                            IsReviewd = (reader["IsReviewd"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsReviewd")) : iNULL,
                            ReceiverId = (reader["ReceiverId"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ReceiverId")) : iNULL,
                            GenderID = (reader["GenderID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("GenderID")) : iNULL,
                            MessageStatusID = (reader["MessageStatusID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("MessageStatusID")) : iNULL,
                            COUNT = (reader["COUNT"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("COUNT")) : iNULL,
                            ViewedFlag = (reader["ViewedFlag"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ViewedFlag")) : iNULL,
                            LastRepliedBy = (reader["LastRepliedBy"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("LastRepliedBy")) : iNULL64,
                            loginCustid = (reader["loginCustid"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("loginCustid")) : iNULL,
                            Photo = (reader["Photo"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Photo")) : null,
                            TotalRows = (reader["TotalRows"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TotalRows")) : iNULL,
                            Totalpages = (reader["Totalpages"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Totalpages")) : iNULL

                        };

                        dropdownfilling.Add(dashboardchats);
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

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return dropdownfilling;
        }
        public List<TicketHistoryinfoResponse> GetTicketinformationDal(long? Ticketid, char Type, string spName)
        {
            List<TicketHistoryinfoResponse> details = new List<TicketHistoryinfoResponse>();
            SqlDataReader reader;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string Snull = "--";
            Int64? Lnull = null;
            int? inull = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            try
            {
                SqlParameter[] parm = new SqlParameter[6];
                parm[0] = new SqlParameter("@TicketID ", SqlDbType.BigInt);
                parm[0].Value = Ticketid;
                parm[1] = new SqlParameter("@Type", SqlDbType.Char);
                parm[1].Value = Type;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TicketHistoryinfoResponse sh = new TicketHistoryinfoResponse();
                        {
                            if (Type == 'I')
                            {
                                sh.Ticket = reader["Ticket"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Ticket")) : Snull;
                                sh.CustomerName = reader["CustomerName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("CustomerName")) : Snull;
                                sh.HistoryLastUpdated = reader["HistoryLastUpdated"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("HistoryLastUpdated")) : Snull;
                                sh.TicketOwner = reader["TicketOwner"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("TicketOwner")) : Snull;
                                sh.TicketOwnerBranch = reader["TicketOwnerBranch"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("TicketOwnerBranch")) : Snull;
                                sh.TicketCreatedDate = reader["TicketCreatedDate"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("TicketCreatedDate")) : Snull;
                                sh.TicketStatus = reader["TicketStatus"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("TicketStatus")) : Snull;
                                sh.Email = reader["Email"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Email")) : Snull;
                                sh.Number = reader["Number"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Number")) : Snull;
                                sh.FromCustID = reader["CustID"] != DBNull.Value ? Convert.ToInt64(reader["CustID"]) : Lnull;
                                sh.FromProfileID = reader["ProfileID"] != DBNull.Value ? Convert.ToInt64(reader["ProfileID"]) : Lnull;
                                sh.TocustID = reader["OppCustID"] != DBNull.Value ? Convert.ToInt64(reader["OppCustID"]) : Lnull;
                                sh.ToProfileID = reader["OppProfileID"] != DBNull.Value ? Convert.ToInt64(reader["OppProfileID"]) : Lnull;
                                sh.FromName = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : null;
                                sh.Toname = reader["OppName"] != DBNull.Value ? reader["OppName"].ToString() : null;
                                sh.TicketStatusID = reader["TicketStatusID"] != DBNull.Value ? Convert.ToInt32(reader["TicketStatusID"]) : inull;

                            }
                            else
                            {
                                sh.Body = reader["Body"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Body")) : Snull;
                                sh.TicketType = reader["TicketType"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("TicketType")) : Snull;
                                sh.EmployeeName = reader["EmployeeName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("EmployeeName")) : Snull;
                                sh.HistoryDate = reader["HistoryDate"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("HistoryDate")) : Snull;
                                sh.ContactNumber = reader["ContactNumber"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ContactNumber")) : Snull;
                                sh.Relation = reader["Relation"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Relation")) : Snull;
                                sh.RelationName = reader["RelationName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("RelationName")) : Snull;
                                sh.CallResult = reader["CallResult"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("CallResult")) : Snull;
                                sh.TicketInfo = reader["TicketInfo"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("TicketInfo")) : Snull;
                                sh.TicketCreatedDatehistry = reader["TicketCreated"] != DBNull.Value ? (reader.GetDateTime(reader.GetOrdinal("TicketCreated"))).ToString() : Snull;
                            }
                        }

                        details.Add(sh);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(ex.Message), Ticketid, null, null);
            }
            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return details;
        }
        public List<CommunicationHistry> GetCustometMessagesCount(CommunicationHistoryReq Mobj, string spName)
        {
            SqlParameter[] parm = new SqlParameter[7];
            SqlDataReader reader;
            List<CommunicationHistry> arrayList = new List<CommunicationHistry>();
            Int64? intNUll = null;
            int? intnull = null;
            bool? iboolean = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@CustID", SqlDbType.BigInt);
                parm[0].Value = Mobj.CustID;
                parm[1] = new SqlParameter("@i_MessageStatusId", SqlDbType.Int);
                parm[1].Value = Mobj.MessageStatusID;
                parm[2] = new SqlParameter("@i_MessageLinkId", SqlDbType.BigInt);
                parm[2].Value = Mobj.MessageLinkId;
                parm[3] = new SqlParameter("@i_PageSize", SqlDbType.Int);
                parm[3].Value = Mobj.i_PageSize;
                parm[4] = new SqlParameter("@i_PageNumber", SqlDbType.Int);
                parm[4].Value = Mobj.i_PageNumber;
                parm[5] = new SqlParameter("@i_StartIndex", SqlDbType.Int);
                parm[5].Value = Mobj.i_StartIndex;
                parm[6] = new SqlParameter("@i_EndIndex", SqlDbType.Int);
                parm[6].Value = Mobj.i_EndIndex;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CommunicationHistry communicationHistory = new CommunicationHistry();
                        {
                            communicationHistory.Sender = reader["Sender"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Sender")) : intNUll;
                            communicationHistory.Receiver = reader["Receiver"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Receiver")) : intNUll;
                            communicationHistory.SenderName = reader["SenderName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("SenderName")) : null;
                            communicationHistory.ReceiverName = reader["ReceiverName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ReceiverName")) : null;
                            communicationHistory.Body = reader["Body"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Body")) : null;
                            communicationHistory.RequestDate = reader["RequestDate"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("RequestDate")) : null;
                            communicationHistory.IsReviewd = reader["IsReviewd"] != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("IsReviewd")) : iboolean;
                            communicationHistory.Cust_MessageLink_Id = reader["Cust_MessageLink_Id"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_MessageLink_Id")) : intNUll;
                            communicationHistory.MessageStatusID = reader["MessageStatusID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("MessageStatusID")) : intnull;
                            communicationHistory.loginCustid = reader["loginCustid"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("loginCustid")) : intNUll;
                        }
                        arrayList.Add(communicationHistory);
                    }
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Mobj.CustID, null, null);
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
        public int InsertExpressViewTicket(long? FromCustID, long? ToCustID, string EncriptedText, string strtypeOfReport, string spName)
        {
            int? Istatus = null;
            int? inull = null;
            SqlDataReader reader = null;
            int status = 0;
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
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
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), FromCustID, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return status;
        }
        public int InsertCustomerExpressinterest(int? fromcustid, int? tocustid, long? logID, string interstTYpe, int? empid, string spName)
        {
            SqlParameter[] parm = new SqlParameter[12];
            Smtpemailsending smtp = new Smtpemailsending();
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            SqlDataReader reader;
            int status = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@fromcustid", SqlDbType.Int);
                parm[0].Value = fromcustid;
                parm[1] = new SqlParameter("@tocustid", SqlDbType.Int);
                parm[1].Value = tocustid;
                parm[2] = new SqlParameter("@logID", SqlDbType.BigInt);
                parm[2].Value = logID;
                parm[3] = new SqlParameter("@interstTYpe", SqlDbType.VarChar);
                parm[3].Value = interstTYpe;
                parm[4] = new SqlParameter("@status", SqlDbType.Int);
                parm[4].Direction = ParameterDirection.Output;
                parm[5] = new SqlParameter("@empid", SqlDbType.Int);
                parm[5].Value = empid;
                DataSet dsMessages = new DataSet();
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

                status = reader.HasRows == true ? smtp.Statusint : 1;
                Commonclass.SendMailSmtpMethod(li, "exp");

                reader.Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), fromcustid, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return status;
        }
    }
}