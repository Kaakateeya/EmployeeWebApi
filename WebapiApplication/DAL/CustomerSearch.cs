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
    public class CustomerSearch
    {
        public PrimaryInformationMl DgetPartnerpreferencedetails(int? CustID, int? EmpID, Int64? searchresultID, string spName)
        {
            List<PrimaryInformationMl> ds = new List<PrimaryInformationMl>();
            PrimaryInformationMl Mobjresult = new PrimaryInformationMl();
            SqlDataReader reader = null;
            SqlParameter[] parm = new SqlParameter[5];
            Int64? intNull = null;
            int? iNull = null;
            SqlConnection con = null;
            try
            {
                parm[0] = new SqlParameter("@cust_Id", SqlDbType.Int);
                parm[0].Value = CustID;
                parm[1] = new SqlParameter("@empid ", SqlDbType.Int);
                parm[1].Value = EmpID;
                parm[2] = new SqlParameter("@searchresultID", SqlDbType.BigInt);
                parm[2].Value = searchresultID;

                using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["KakConnection"].ToString()))
                {
                    con.Open();
                    reader = SQLHelper.ExecuteReader(con, CommandType.StoredProcedure, spName, parm);
                    if (reader.HasRows)
                    {
                        if (searchresultID == null)
                        {
                            while (reader.Read())
                            {
                                Mobjresult.intCusID = (reader["Cust_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_ID")) : intNull;
                                Mobjresult.intGender = (reader["GenderID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("GenderID")) : iNull;
                                Mobjresult.Agefrom = (reader["AgeMax"]) != DBNull.Value ? (reader.GetDouble(reader.GetOrdinal("AgeMax"))).ToString() : null;
                                Mobjresult.Ageto = (reader["AgeMin"]) != DBNull.Value ? (reader.GetDouble(reader.GetOrdinal("AgeMin"))).ToString() : null;
                                Mobjresult.Heightfrom = (reader["MaxHeight"]) != DBNull.Value ? (reader.GetDouble(reader.GetOrdinal("MaxHeight"))).ToString() : null;
                                Mobjresult.Heightto = (reader["MinHeight"]) != DBNull.Value ? (reader.GetDouble(reader.GetOrdinal("MinHeight"))).ToString() : null;
                                Mobjresult.Maritalstatus = (reader["maritalstatusid"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("maritalstatusid")) : null;
                                Mobjresult.Religion = (reader["religionid"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("religionid")) : string.Empty;
                                Mobjresult.MotherTongue = (reader["MotherTongueID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MotherTongueID")) : string.Empty;
                                Mobjresult.Caste = (reader["casteid"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("casteid")) : string.Empty;
                                Mobjresult.Complexion = (reader["complexionid"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("complexionid")) : string.Empty;
                                Mobjresult.bodytype = (reader["BodyTypeID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("BodyTypeID")) : string.Empty;
                                Mobjresult.PhysicalStatusstring = (reader["physicalstatusid"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("physicalstatusid")) : string.Empty;
                                Mobjresult.Educationcategory = (reader["EducationCategoryID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationCategoryID")) : string.Empty;
                                Mobjresult.Education = (reader["EducationGroupID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationGroupID")) : string.Empty;
                                Mobjresult.Professiongroup = (reader["ProfessionGroup"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfessionGroup")) : string.Empty;
                                Mobjresult.Country = (reader["CountryID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CountryID")) : string.Empty;
                                Mobjresult.State = (reader["StateID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("StateID")) : string.Empty;
                                Mobjresult.Stars = (reader["StarLanguageID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("StarLanguageID")) : string.Empty;
                                Mobjresult.Stars = (reader["PreferredStars"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PreferredStars")) : string.Empty;
                                Mobjresult.iManglinkKujaDosham = (reader["KujaDosham"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("KujaDosham")) : iNull;
                                Mobjresult.CasteText = (reader["Caste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Caste")) : string.Empty;
                            }
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                Mobjresult.intCusID = (reader["CustID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("CustID")) : intNull;
                                Mobjresult.intGender = (reader["LookingforID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("LookingforID")) : iNull;
                                Mobjresult.Agefrom = (reader["ToAgeID"]) != DBNull.Value ? (reader.GetString(reader.GetOrdinal("ToAgeID"))) : string.Empty;
                                Mobjresult.Ageto = (reader["FromAgeID"]) != DBNull.Value ? (reader.GetString(reader.GetOrdinal("FromAgeID"))) : string.Empty;
                                Mobjresult.Heightfrom = (reader["ToHeightID"]) != DBNull.Value ? (reader.GetString(reader.GetOrdinal("ToHeightID"))) : string.Empty;
                                Mobjresult.Heightto = (reader["FromHeightID"]) != DBNull.Value ? (reader.GetString(reader.GetOrdinal("FromHeightID"))) : string.Empty;
                                Mobjresult.Maritalstatus = (reader["MaritalstatusID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MaritalstatusID")) : null;
                                Mobjresult.Religion = (reader["ReligionID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ReligionID")) : string.Empty;
                                Mobjresult.MotherTongue = (reader["MothertongueID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MothertongueID")) : string.Empty;
                                Mobjresult.Caste = (reader["CasteID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CasteID")) : string.Empty;
                                Mobjresult.Complexion = (reader["ComplexionId"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ComplexionId")) : string.Empty;
                                Mobjresult.PhysicalStatusstring = (reader["PhysicalstatusID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhysicalstatusID")) : string.Empty;
                                Mobjresult.Educationcategory = (reader["EducationcategoryID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationcategoryID")) : string.Empty;
                                Mobjresult.Education = (reader["EducationGroupID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationGroupID")) : string.Empty;
                                Mobjresult.Professiongroup = (reader["ProfessiongroupId"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfessiongroupId")) : string.Empty;
                                Mobjresult.Country = (reader["CountyWorkingInID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CountyWorkingInID")) : string.Empty;
                                Mobjresult.State = (reader["StateWorkingInID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("StateWorkingInID")) : string.Empty;
                                Mobjresult.iStarID = (reader["StarId"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("StarId")) : iNull;
                                Mobjresult.iStarLanguage = (reader["StarlanguageID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("StarlanguageID")) : iNull;
                                Mobjresult.iManglinkKujaDosham = (reader["ManglikKujaDoshamID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ManglikKujaDoshamID")) : iNull;
                                Mobjresult.CasteText = (reader["Caste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Caste")) : string.Empty;
                                Mobjresult.Visastatus = (reader["VisastatusID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("VisastatusID")) : string.Empty;
                                Mobjresult.iAnnualincome = (reader["Annualincome"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Annualincome")) : iNull;
                                Mobjresult.iFromSal = (reader["FromSal"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("FromSal")) : intNull;
                                Mobjresult.iToSal = (reader["Tosal"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Tosal")) : intNull;
                                Mobjresult.iDiet = (reader["DietID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("DietID")) : iNull;
                                Mobjresult.i_Registrationdays = (reader["Registrationdays"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Registrationdays")) : iNull;
                            }
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt64(CustID), null, null);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
                SqlConnection.ClearAllPools();
            }
            return Mobjresult;
        }
        public List<QuicksearchResultML> GeneralandAdvancedSearch(PrimaryInformationMl search, string spName)
        {
            List<QuicksearchResultML> listSearch = new List<QuicksearchResultML>();
            SqlDataReader reader;
            SqlParameter[] parm = new SqlParameter[30];
            Int64? intNull = null;
            int? iNull = null;
            string strNP = "Not specified";
            SqlConnection con = null;
            try
            {
                parm[0] = new SqlParameter("@i_CustId", SqlDbType.Int);
                parm[0].Value = search.intCusID;
                parm[1] = new SqlParameter("@i_GenderId", SqlDbType.Int);
                parm[1].Value = search.intGender;
                parm[2] = new SqlParameter("@i_FromAge", SqlDbType.Int);
                parm[2].Value = search.FromAge;
                parm[3] = new SqlParameter("@i_ToAge", SqlDbType.Int);
                parm[3].Value = search.ToAge;
                parm[4] = new SqlParameter("@i_FromHeight", SqlDbType.Int);
                parm[4].Value = search.iFromHeight;
                parm[5] = new SqlParameter("@i_ToHeight", SqlDbType.Int);
                parm[5].Value = search.iToHeight;
                parm[6] = new SqlParameter("@i_ReligionId", SqlDbType.Int);
                parm[6].Value = search.intReligionID;
                parm[7] = new SqlParameter("@tbl_Caste", SqlDbType.Structured);
                parm[7].Value = Commonclass.returndt(search.Caste, search.dtCateIDs, "Caste", "CastIDs2");
                parm[8] = new SqlParameter("@tbl_Country", SqlDbType.Structured);
                parm[8].Value = Commonclass.returndt(search.Country, search.dtCountrylivingin, "Countrylivingin", "CountrylivinginIDs4");
                parm[9] = new SqlParameter("@tbl_Education", SqlDbType.Structured);
                parm[9].Value = Commonclass.returndt(search.Education, search.dtEducationGroup, "EducationGroup", "EducationGroupIDs8");
                parm[10] = new SqlParameter("@tbl_ProfessionGroup", SqlDbType.Structured);
                parm[10].Value = Commonclass.returndt(search.Professiongroup, search.dtProfessionGroup, "ProfessionGroup", "ProfessionGroupIDs09");
                parm[11] = new SqlParameter("@tbl_MotherTongue", SqlDbType.Structured);
                parm[11].Value = Commonclass.returndt(search.MotherTongue, search.dtMothertongue, "Mothertongue", "MothertongueIDs1");
                parm[12] = new SqlParameter("@i_Photoflag", SqlDbType.Int);
                parm[12].Value = search.intPhotoCount;
                parm[13] = new SqlParameter("@i_StartIndex", SqlDbType.Int);
                parm[13].Value = search.StartIndex;
                parm[14] = new SqlParameter("@i_EndIndex", SqlDbType.Int);
                parm[14].Value = search.EndIndex;
                parm[15] = new SqlParameter("@i_Registrationdays", SqlDbType.Int);
                parm[15].Value = search.i_Registrationdays;
                parm[16] = new SqlParameter("@tbl_MaritalStatus", SqlDbType.Structured);
                parm[16].Value = Commonclass.returndt(search.Maritalstatus, search.dtMaritalstatus, "Maritalstatus", "MaritalstatusIDs0");
                parm[17] = new SqlParameter("@i_PhysicalStatus", SqlDbType.Int);
                parm[17].Value = search.iPhysicalstatus;
                parm[18] = new SqlParameter("@tbl_Complexion", SqlDbType.Structured);
                parm[18].Value = Commonclass.returndt(search.Complexion, search.dtComplexion, "Complexion", "ComplexionIDs3");
                parm[19] = new SqlParameter("@tbl_EducationCategory", SqlDbType.Structured);
                parm[19].Value = Commonclass.returndt(search.Educationcategory, search.dtEduactionCat, "Educationcategory", "EducationcategoryIDs7");
                parm[20] = new SqlParameter("@tbl_LivingState", SqlDbType.Structured);
                parm[20].Value = Commonclass.returndt(search.State, search.dtStateLivingIn, "Statelivingin", "StatelivinginIDs5");
                parm[21] = new SqlParameter("@tbl_VisaStatus", SqlDbType.Structured);
                parm[21].Value = Commonclass.returndt(search.Visastatus, search.dtVisaStatus, "VisaStatus", "VisaStatusIDs6");
                parm[22] = new SqlParameter("@i_FromAnualIncome", SqlDbType.BigInt);
                parm[22].Value = search.iFromSal;
                parm[23] = new SqlParameter("@i_ToAnualIncome", SqlDbType.BigInt);
                parm[23].Value = search.iToSal;
                parm[24] = new SqlParameter("@tbl_StarLanguage", SqlDbType.Structured);
                parm[24].Value = Commonclass.returndatatable(search.iStarLanguage, search.dtStarLang, "StarLanguageIDs", "StarLanguageIDs11");
                parm[25] = new SqlParameter("@tbl_Star", SqlDbType.Structured);
                parm[25].Value = Commonclass.returndt(search.Stars, search.dtStar, "Star", "Stars");
                parm[26] = new SqlParameter("@b_isManglik", SqlDbType.Bit);
                parm[26].Value = search.iManglinkKujaDosham;
                parm[27] = new SqlParameter("@i_IsDiet", SqlDbType.Int);
                parm[27].Value = search.iDiet;
                parm[28] = new SqlParameter("@i_SalaryIncurrency", SqlDbType.Int);
                parm[28].Value = search.iAnnualincome;

                using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["KakConnection"].ToString()))
                {
                    con.Open();
                    reader = SQLHelper.ExecuteReader(con, CommandType.StoredProcedure, spName, parm);
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            QuicksearchResultML Mobjresult = new QuicksearchResultML();
                            {
                                Mobjresult.intCusID = (reader["Cust_Id"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_Id")) : intNull;
                                Mobjresult.NAME = (reader["NAME"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("NAME")) : strNP;
                                Mobjresult.ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : null;
                                Mobjresult.Age = (reader["Age"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Age")) : strNP;
                                Mobjresult.Height = (reader["Height"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Height")) : strNP;
                                Mobjresult.ReligionName = (reader["ReligionName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ReligionName")) : strNP;
                                Mobjresult.Caste = (reader["Caste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Caste")) : strNP;
                                Mobjresult.Star = (reader["Star"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Star")) : strNP;
                                Mobjresult.Location = (reader["Location"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Location")) : strNP;
                                Mobjresult.Education = (reader["Education"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Education")) : strNP;
                                Mobjresult.Profession = (reader["Profession"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Profession")) : strNP;
                                Mobjresult.TotalRows = (reader["TotalRows"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TotalRows")) : 0;
                                Mobjresult.TotalPages = (reader["Totalpages"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Totalpages")) : 0;
                                Mobjresult.Photo = (reader["Photo"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Photo")) : null;
                                Mobjresult.PhotoCount = (reader["PhotoCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoCount")) : 0;
                                Mobjresult.placeofbirth = (reader["placeofbirth"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("placeofbirth")) : null;
                                Mobjresult.GenderID = (reader["GenderID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("GenderID")) : 0;
                                Mobjresult.PhotoPassword = (reader["PhotoPassword"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoPassword")) : null;
                                Mobjresult.MaritualStatus = (reader["MaritualStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MaritualStatus")) : strNP;
                                Mobjresult.MaritalStatusId = (reader["MaritalStatusId"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MaritalStatusId")) : null;
                                Mobjresult.IsPaidMember = (reader["IsPaidMember"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsPaidMember")) : iNull;
                                Mobjresult.mybookmarked = (reader["mybookmarked"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("mybookmarked")) : iNull;
                                Mobjresult.ExpressFlag = (reader["ExpressFlag"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ExpressFlag")) : iNull;
                                Mobjresult.ignode = (reader["ignode"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ignode")) : iNull;
                                Mobjresult.LogId = (reader["LogId"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("LogId")) : intNull;
                                Mobjresult.LogID = (reader["LogId"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("LogId")) : intNull;
                                Mobjresult.Photo = (reader["PhotoPath"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoPath")) : string.Empty;
                                Mobjresult.Photofullpath = (reader["FullPhotoPath"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FullPhotoPath")) : string.Empty;
                                Mobjresult.DistName = (reader["DistName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("DistName")) : string.Empty;

                            }

                            listSearch.Add(Mobjresult);
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), search.intCusID, null, null);
            }
            finally
            {
                con.Close();
                SqlConnection.ClearPool(con);
                SqlConnection.ClearAllPools();
                //SQLHelper.GetSQLConnection().Dispose();
            }
            return listSearch;
        }

        public List<QuicksearchResultML> ProfileIdsearch(ProfileIDSearch ProfileIDSearch, string spName)
        {
            List<QuicksearchResultML> listSearch = new List<QuicksearchResultML>();
            SqlDataReader reader = null;
            SqlParameter[] parm = new SqlParameter[10];
            Int64? intNull = null;
            int? iNull = null;
            string strNP = "Not specified";
            SqlConnection con = null;
            try
            {
                parm[0] = new SqlParameter("@i_PCustId", SqlDbType.Int);
                parm[0].Value = ProfileIDSearch.intCusID;
                parm[1] = new SqlParameter("@i_GenderId", SqlDbType.Int);
                parm[1].Value = ProfileIDSearch.intGender;
                parm[2] = new SqlParameter("@vc_LastName", SqlDbType.VarChar);
                parm[2].Value = ProfileIDSearch.strLastName;
                parm[3] = new SqlParameter("@vc_FirstName ", SqlDbType.VarChar);
                parm[3].Value = ProfileIDSearch.strFirstName;
                parm[4] = new SqlParameter("@vc_ProfileId", SqlDbType.VarChar);
                parm[4].Value = ProfileIDSearch.strProfileID;
                parm[5] = new SqlParameter("@i_CasteId", SqlDbType.VarChar);
                parm[5].Value = ProfileIDSearch.intCasteID;
                parm[6] = new SqlParameter("@i_StartIndex", SqlDbType.Int);
                parm[6].Value = ProfileIDSearch.StartIndex;
                parm[7] = new SqlParameter("@i_EndIndex", SqlDbType.Int);
                parm[7].Value = ProfileIDSearch.EndIndex;

                using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["KakConnection"].ToString()))
                {
                    con.Open();
                    reader = SQLHelper.ExecuteReader(con, CommandType.StoredProcedure, spName, parm);
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            QuicksearchResultML Mobjresult = new QuicksearchResultML();
                            {
                                Mobjresult.intCusID = (reader["Cust_Id"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_Id")) : intNull;
                                Mobjresult.NAME = (reader["NAME"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("NAME")) : strNP;
                                Mobjresult.ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : null;
                                Mobjresult.Age = (reader["Age"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Age")) : strNP;
                                Mobjresult.Height = (reader["Height"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Height")) : strNP;
                                Mobjresult.ReligionName = (reader["ReligionName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ReligionName")) : strNP;
                                Mobjresult.Caste = (reader["Caste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Caste")) : strNP;
                                Mobjresult.Star = (reader["Star"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Star")) : strNP;
                                Mobjresult.Location = (reader["Location"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Location")) : strNP;
                                Mobjresult.Education = (reader["Education"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Education")) : strNP;
                                Mobjresult.Profession = (reader["Profession"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Profession")) : strNP;
                                Mobjresult.PhoneNumber = (reader["PhoneNumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhoneNumber")) : strNP;
                                Mobjresult.Email = (reader["Email"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Email")) : strNP;
                                Mobjresult.IsprofileMarked = (reader["IsprofileMarked"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsprofileMarked")) : 0;
                                Mobjresult.HoroscopeImage = (reader["HoroscopeImage"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("HoroscopeImage")) : strNP;
                                Mobjresult.IsExpressIntrestMarked = (reader["IsExpressIntrestMarked"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsExpressIntrestMarked")) : 0;
                                Mobjresult.IsIntrested = (reader["IsIntrested"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsIntrested")) : 0;
                                Mobjresult.IsMessage = (reader["IsMessage"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsMessage")) : 0;
                                Mobjresult.TotalRows = (reader["TotalRows"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TotalRows")) : 0;
                                Mobjresult.TotalPages = (reader["Totalpages"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Totalpages")) : 0;
                                Mobjresult.Photo = (reader["Photo"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Photo")) : null;
                                Mobjresult.PhotoCount = (reader["PhotoCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoCount")) : 0;
                                Mobjresult.placeofbirth = (reader["placeofbirth"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("placeofbirth")) : null;
                                Mobjresult.GenderID = (reader["GenderID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("GenderID")) : 0;
                                Mobjresult.iCasteID = (reader["iCasteID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iCasteID")) : iNull;
                                Mobjresult.iStarID = (reader["iStarID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iStarID")) : iNull;
                                Mobjresult.iCountryID = (reader["iCountryID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iCountryID")) : iNull;
                                Mobjresult.iReligionID = (reader["iReligionID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iReligionID")) : iNull;
                                Mobjresult.iProfessionID = (reader["iProfessionID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iProfessionID")) : iNull;
                                Mobjresult.iProfessionGroupID = (reader["iProfessionGroupID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iProfessionGroupID")) : iNull;
                                Mobjresult.iEducationGroupID = (reader["iEducationGroupID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iEducationGroupID")) : iNull;
                                Mobjresult.iHeightInCentimeters = (reader["iHeightInCentimeters"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iHeightInCentimeters")) : iNull;
                                Mobjresult.iStarLanguageID = (reader["iStarLanguageID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iStarLanguageID")) : iNull;
                                Mobjresult.iCityID = (reader["iCityID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iCityID")) : iNull;
                                Mobjresult.iStateID = (reader["iStateID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("iStateID")) : iNull;
                                Mobjresult.PhotoPassword = (reader["PhotoPassword"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoPassword")) : null;
                                Mobjresult.MaritualStatus = (reader["MaritualStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MaritualStatus")) : strNP;
                                Mobjresult.MaritalStatusId = (reader["MaritalStatusId"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MaritalStatusId")) : null;
                                Mobjresult.IsPaidMember = (reader["IsPaidMember"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsPaidMember")) : iNull;
                                Mobjresult.NoOfProfiles = (reader["NoOfProfiles"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("NoOfProfiles")) : iNull;
                                Mobjresult.mybookmarked = (reader["mybookmarked"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("mybookmarked")) : iNull;
                                Mobjresult.ExpressFlag = (reader["ExpressFlag"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ExpressFlag")) : iNull;
                                Mobjresult.ignode = (reader["ignode"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ignode")) : iNull;
                                Mobjresult.LogId = (reader["LogId"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("LogId")) : intNull;
                                Mobjresult.LogID = (reader["LogId"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("LogId")) : intNull;
                                Mobjresult.Photo = (reader["PhotoPath"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoPath")) : string.Empty;
                                Mobjresult.Photofullpath = (reader["FullPhotoPath"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FullPhotoPath")) : string.Empty;
                                Mobjresult.DistName = (reader["DistName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("DistName")) : string.Empty;
                            }

                            listSearch.Add(Mobjresult);
                        }
                    }

                    reader.Close();
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
               
                con.Close();
                SqlConnection.ClearPool(con);
                SqlConnection.ClearAllPools();
            }
            return listSearch;
        }

        public int CustomerAdvanceGeneralProfileIDsearchSave(DataTable dataTable, long? intCusID, int? iupdateFlag, string spName, string strParam)
        {
            int intStatus = 0;
            DataSet ds = new DataSet();
            SqlParameter[] parm = new SqlParameter[5];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {

                parm[0] = new SqlParameter(strParam, SqlDbType.Structured);
                parm[0].Value = dataTable;
                parm[1] = new SqlParameter("@CustID", SqlDbType.Int);
                parm[1].Value = intCusID;
                parm[2] = new SqlParameter("@flage", SqlDbType.Int);
                parm[2].Value = iupdateFlag;
                parm[3] = new SqlParameter("@Status", SqlDbType.Int);
                parm[3].Direction = ParameterDirection.Output;

                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
                if (string.Compare(parm[3].Value.ToString(), System.DBNull.Value.ToString()) == 0)
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[3].Value);
                }
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
            return intStatus;
        }
        public List<QuicksearchResultML> CustomerGeneralandAdvancedSavedSearch(PrimaryInformationMl primaryInfo, DataTable dtTableValues, string SavedSearchSp, string saveParam, string searchSp)
        {
            int iResult = CustomerAdvanceGeneralProfileIDsearchSave(dtTableValues, primaryInfo.intCusID, primaryInfo.iupdateFlag, SavedSearchSp, saveParam);
            return GeneralandAdvancedSearch(primaryInfo, searchSp);
        }
        public List<QuicksearchResultML> CustomerProfileIDSavedSearch(ProfileIDSearch profileIDsearch, DataTable dtTableValues, string SavedSearchSp, string saveParam, string searchSp)
        {
            int iResult = CustomerAdvanceGeneralProfileIDsearchSave(dtTableValues, profileIDsearch.intCusID, profileIDsearch.iupdateFlag, SavedSearchSp, saveParam);
            return ProfileIdsearch(profileIDsearch, searchSp);
        }
        public List<SearchResultSaveEditML> SearchResultSaveEdit(long? Cust_ID, string SaveSearchName, int? iEditDelete, string spName)
        {
            List<SearchResultSaveEditML> listSaveEdit = new List<SearchResultSaveEditML>();
            SqlDataReader reader = null;
            SqlParameter[] parm = new SqlParameter[5];
            Int64? intNull = null;
            SqlConnection con = null;
            string strNP = "Not specified";
            try
            {
                parm[0] = new SqlParameter("@Cust_ID", SqlDbType.Int);
                parm[0].Value = Cust_ID;
                parm[1] = new SqlParameter("@SaveSearchName", SqlDbType.VarChar);
                parm[1].Value = SaveSearchName;
                parm[2] = new SqlParameter("@i_flag", SqlDbType.Int);
                parm[2].Value = iEditDelete;

                using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["KakConnection"].ToString()))
                {
                    con.Open();
                    reader = SQLHelper.ExecuteReader(con, CommandType.StoredProcedure, spName, parm);
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            SearchResultSaveEditML Mobjresult = new SearchResultSaveEditML();
                            {
                                Mobjresult.SearchResult_ID = (reader["SearchResult_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("SearchResult_ID")) : intNull;
                                Mobjresult.CustID = (reader["CustID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CustID")) : strNP;
                                Mobjresult.SearchpageID = (reader["SearchpageID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("SearchpageID")) : null;
                                Mobjresult.CustSavedSearchName = (reader["CustSavedSearchName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CustSavedSearchName")) : strNP;
                                Mobjresult.SaveSearchPageName = (reader["SaveSearchPageName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("SaveSearchPageName")) : strNP;
                            }

                            listSaveEdit.Add(Mobjresult);
                        }
                    }

                    reader.Close();
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
             
                con.Close();
                SqlConnection.ClearPool(con);
                SqlConnection.ClearAllPools();
            }
            return listSaveEdit;
        }

        public List<QuicksearchResultML> CustomerHomePageSearch(CustomerHomePageSearch search, string spName)
        {
            List<QuicksearchResultML> listSearch = new List<QuicksearchResultML>();
            SqlDataReader reader;
            SqlParameter[] parm = new SqlParameter[30];
            Int64? intNull = null;
            int? iNull = null;
            string strNP = "Not specified";
            SqlConnection con = null;
            try
            {
                parm[0] = new SqlParameter("@i_CustId", SqlDbType.Int);
                parm[0].Value = search.CustId;
                parm[1] = new SqlParameter("@i_GenderId", SqlDbType.Int);
                parm[1].Value = search.GenderId;
                parm[2] = new SqlParameter("@i_FromAge", SqlDbType.Int);
                parm[2].Value = search.FromAge;
                parm[3] = new SqlParameter("@i_ToAge", SqlDbType.Int);
                parm[3].Value = search.ToAge;
                parm[4] = new SqlParameter("@i_FromHeight", SqlDbType.Int);
                parm[4].Value = search.FromHeight;
                parm[5] = new SqlParameter("@i_ToHeight", SqlDbType.Int);
                parm[5].Value = search.ToHeight;
                parm[6] = new SqlParameter("@tbl_Caste", SqlDbType.VarChar, 8000);
                parm[6].Value = search.Caste;
                parm[7] = new SqlParameter("@tbl_Country", SqlDbType.Int);
                parm[7].Value = search.Country;
                parm[8] = new SqlParameter("@i_StartIndex", SqlDbType.Int);
                parm[8].Value = search.StartIndex;
                parm[9] = new SqlParameter("@i_EndIndex", SqlDbType.Int);
                parm[9].Value = search.EndIndex;
                using (con = new SqlConnection(ConfigurationManager.ConnectionStrings["KakConnection"].ToString()))
                {
                    con.Open();
                    reader = SQLHelper.ExecuteReader(con, CommandType.StoredProcedure, spName, parm);
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            QuicksearchResultML Mobjresult = new QuicksearchResultML();
                            {
                                Mobjresult.intCusID = (reader["Cust_Id"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_Id")) : intNull;
                                Mobjresult.NAME = (reader["NAME"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("NAME")) : strNP;
                                Mobjresult.ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : null;
                                Mobjresult.Age = (reader["Age"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Age")) : strNP;
                                Mobjresult.Height = (reader["Height"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Height")) : strNP;
                                Mobjresult.ReligionName = (reader["ReligionName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ReligionName")) : strNP;
                                Mobjresult.Caste = (reader["Caste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Caste")) : strNP;
                                Mobjresult.Star = (reader["Star"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Star")) : strNP;
                                Mobjresult.Location = (reader["Location"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Location")) : strNP;
                                Mobjresult.Education = (reader["Education"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Education")) : strNP;
                                Mobjresult.Profession = (reader["Profession"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Profession")) : strNP;
                                Mobjresult.TotalRows = (reader["TotalRows"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TotalRows")) : 0;
                                Mobjresult.TotalPages = (reader["Totalpages"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Totalpages")) : 0;
                                Mobjresult.Photo = (reader["Photo"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Photo")) : null;
                                Mobjresult.PhotoCount = (reader["PhotoCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoCount")) : 0;
                                Mobjresult.placeofbirth = (reader["placeofbirth"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("placeofbirth")) : null;
                                Mobjresult.GenderID = (reader["GenderID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("GenderID")) : 0;
                                Mobjresult.PhotoPassword = (reader["PhotoPassword"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoPassword")) : null;
                                Mobjresult.MaritualStatus = (reader["MaritualStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MaritualStatus")) : strNP;
                                Mobjresult.MaritalStatusId = (reader["MaritalStatusId"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MaritalStatusId")) : null;
                                Mobjresult.IsPaidMember = (reader["IsPaidMember"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsPaidMember")) : iNull;
                                Mobjresult.mybookmarked = (reader["mybookmarked"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("mybookmarked")) : iNull;
                                Mobjresult.ExpressFlag = (reader["ExpressFlag"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ExpressFlag")) : iNull;
                                Mobjresult.ignode = (reader["ignode"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ignode")) : iNull;
                                Mobjresult.LogId = (reader["LogId"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("LogId")) : intNull;
                                Mobjresult.LogID = (reader["LogId"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("LogId")) : intNull;
                                Mobjresult.Photo = (reader["PhotoPath"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoPath")) : string.Empty;
                                Mobjresult.Photofullpath = (reader["FullPhotoPath"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FullPhotoPath")) : string.Empty;
                            }

                            listSearch.Add(Mobjresult);
                        }
                    }
                    reader.Close();
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), search.CustId, null, null);
            }
            finally
            {
               
                con.Close();
                SqlConnection.ClearPool(con);
                SqlConnection.ClearAllPools();
            }
            return listSearch;
        }

        // Employee Searches 


        public GetPrimaryDataCustomerResponse GetPrimaryInformationDal(int? CustID, int? EmpID, string spName)
        {
            GetPrimaryDataCustomerResponse sh = new GetPrimaryDataCustomerResponse();
            SqlDataReader reader;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DateTime? dnull=null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[5];
                parm[0] = new SqlParameter("@cust_Id", SqlDbType.Int);
                parm[0].Value = CustID;

                parm[1] = new SqlParameter("@empid", SqlDbType.Int);
                parm[1].Value = EmpID;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {

                        sh.GenderID = reader["GenderID"] != DBNull.Value ? reader["GenderID"].ToString() : "0";
                        sh.AgeMin = reader["AgeMin"] != DBNull.Value ? reader["AgeMin"].ToString() : "0";
                        sh.AgeMax = reader["AgeMax"] != DBNull.Value ? reader["AgeMax"].ToString() : "0";
                        sh.MinHeight = reader["MinHeight"] != DBNull.Value ? reader["MinHeight"].ToString() : "0";
                        sh.MaxHeight = reader["MaxHeight"] != DBNull.Value ? reader["MaxHeight"].ToString() : "0";
                        sh.maritalstatusid = reader["maritalstatusid"] != DBNull.Value ? reader["maritalstatusid"].ToString() : "";
                        sh.religionid = reader["religionid"] != DBNull.Value ? reader["religionid"].ToString() : "";
                        sh.MotherTongueID = reader["MotherTongueID"] != DBNull.Value ? reader["MotherTongueID"].ToString() : "";
                        sh.casteid = reader["casteid"] != DBNull.Value ? reader["casteid"].ToString() : "0";
                        sh.complexionid = reader["complexionid"] != DBNull.Value ? reader["complexionid"].ToString() : "";
                        sh.BodyTypeID = reader["BodyTypeID"] != DBNull.Value ? reader["BodyTypeID"].ToString() : "";
                        sh.physicalstatusid = reader["physicalstatusid"] != DBNull.Value ? reader["physicalstatusid"].ToString() : "";
                        sh.EducationCategoryID = reader["EducationCategoryID"] != DBNull.Value ? reader["EducationCategoryID"].ToString() : "";
                        sh.EducationGroupID = reader["EducationGroupID"] != DBNull.Value ? reader["EducationGroupID"].ToString() : "";
                        sh.ProfessionCategoryID = reader["ProfessionCategoryID"] != DBNull.Value ? reader["ProfessionCategoryID"].ToString() : "";
                        sh.ProfessionGroup = reader["ProfessionGroup"] != DBNull.Value ? reader["ProfessionGroup"].ToString() : "";
                        sh.CountryID = reader["CountryID"] != DBNull.Value ? reader["CountryID"].ToString() : "";
                        sh.StateID = reader["StateID"] != DBNull.Value ? reader["StateID"].ToString() : "";
                        sh.DistrictID = reader["DistrictID"] != DBNull.Value ? reader["DistrictID"].ToString() : "";
                        sh.StarLanguageID = reader["StarLanguageID"] != DBNull.Value ? reader["StarLanguageID"].ToString() : "";
                        sh.PreferredStars = reader["PreferredStars"] != DBNull.Value ? reader["PreferredStars"].ToString() : "";
                        sh.KujaDosham = reader["KujaDosham"] != DBNull.Value ? reader["KujaDosham"].ToString() : "";
                        sh.Drink = reader["Drink"] != DBNull.Value ? reader["Drink"].ToString() : "";
                        sh.Smoke = reader["Smoke"] != DBNull.Value ? reader["Smoke"].ToString() : "";
                        sh.Diet = (reader["Diet"] != DBNull.Value ? reader["Diet"].ToString() : "");
                        sh.ProfileID = reader["ProfileID"] != DBNull.Value ? reader["ProfileID"].ToString() : "";
                        sh.PaidFlag = reader["PaidFlag"] != DBNull.Value ? reader["PaidFlag"].ToString() : "";
                        sh.Regions = reader["Regions"] != DBNull.Value ? reader["Regions"].ToString() : "";
                        sh.Branches = reader["Branches"] != DBNull.Value ? reader["Branches"].ToString() : "";
                        sh.Cust_ID = reader["Cust_ID"] != DBNull.Value ? reader["Cust_ID"].ToString() : "";
                        sh.SelfAge = reader["SelfAge"] != DBNull.Value ? reader["SelfAge"].ToString() : "";
                        sh.SelfName = reader["SelfName"] != DBNull.Value ? reader["SelfName"].ToString() : "";
                        sh.Selfheight = reader["Selfheight"] != DBNull.Value ? reader["Selfheight"].ToString() : "";
                        sh.SelfEducation = reader["SelfEducation"] != DBNull.Value ? reader["SelfEducation"].ToString() : "";
                        sh.ApplicationProfilePic = reader["ApplicationProfilePic"] != DBNull.Value ? reader["ApplicationProfilePic"].ToString() : "";
                        sh.ThumbNailProfilePic = reader["ThumbNailProfilePic"] != DBNull.Value ? reader["ThumbNailProfilePic"].ToString() : "";
                        //sh.MaxDob = reader["MaxDob"] != DBNull.Value ? reader.GetDateTime["MaxDob"].to : dnull;
                        //sh.MinDob = reader["MinDob"] != DBNull.Value ? reader["MinDob"] : dnull;

                        sh.MaxDob = (reader["MaxDob"]) != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("MaxDob")) : dnull;
                        sh.MinDob = (reader["MinDob"]) != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("MinDob")) : dnull;

                        sh.Gotram = reader["Gotram"] != DBNull.Value ? reader["Gotram"].ToString() : "";
                        sh.Surname = reader["Surname"] != DBNull.Value ? reader["Surname"].ToString() : "";

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
            return sh;
        }

        public List<slideshowNew> GetShowDataForGeneral(EmployeeSearch Mobjpartner, string spName)
        {
            List<slideshowNew> details = new List<slideshowNew>();
            SqlDataReader reader;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            int status = 0;
            string Snull = "--";
            int? inull = null;
            bool? bnull = null;
            Int64? Lnull = null;

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {

                SqlParameter[] parm = new SqlParameter[6];

                parm[0] = new SqlParameter("@TblDetails", SqlDbType.Structured);
                parm[0].Value = Mobjpartner.dtTableValues;
                parm[1] = new SqlParameter("@intCust_id", SqlDbType.Int);
                parm[1].Value = Mobjpartner.CustID;
                parm[2] = new SqlParameter("@intEmpID", SqlDbType.Int);
                parm[2].Value = Mobjpartner.EmpID;
                parm[3] = new SqlParameter("@i_Startindex", SqlDbType.Int);
                parm[3].Value = Mobjpartner.startindex;
                parm[4] = new SqlParameter("@i_EndIndex", SqlDbType.Int);
                parm[4].Value = Mobjpartner.EndIndex;
                parm[5] = new SqlParameter("@Status", SqlDbType.Int);
                parm[5].Direction = ParameterDirection.Output;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        slideshowNew sh = new slideshowNew();
                        {

                            sh.Cust_ID = reader["Cust_ID"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Cust_ID")) : Snull;
                            sh.paid = reader["paid"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("paid")) : inull;
                            sh.ProfileID = reader["ProfileID"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : Snull;
                            sh.KMPLID = reader["KMPLID"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("KMPLID")) : Snull;
                            sh.IsConfidential = reader["IsConfidential"] != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("IsConfidential")) : bnull;
                            sh.SuperConfidentila = reader["SuperConfidentila"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("SuperConfidentila")) : inull;
                            sh.FirstName = reader["FirstName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("FirstName")) : Snull;
                            sh.LastName = reader["LastName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("LastName")) : Snull;
                            sh.PhotoNames = reader["PhotoNames"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoNames")) : Snull;
                            sh.Photo = reader["Photo"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Photo")) : Snull;
                            sh.ApplicationPhotoPath = reader["ApplicationPhotoPath"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ApplicationPhotoPath")) : Snull;
                            sh.HoroscopeStatus = reader["HoroscopeStatus"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("HoroscopeStatus")) : inull;
                            sh.HoroscopePath = reader["HoroscopePath"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("HoroscopePath")) : Snull;
                            sh.email = reader["email"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("email")) : Snull;
                            sh.NoOfBrothers = reader["NoOfBrothers"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("NoOfBrothers")) : inull;
                            sh.NoOfSisters = reader["NoOfSisters"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("NoOfSisters")) : inull;
                            sh.CasteID = reader["CasteID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CasteID")) : inull;
                            sh.HeightInCentimeters = reader["HeightInCentimeters"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("HeightInCentimeters")) : inull;
                            sh.MaritalStatusID = reader["MaritalStatusID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("MaritalStatusID")) : inull;
                            sh.DOB = reader["DOB"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("DOB")) : Snull;
                            sh.Age = reader["Age"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Age")) : inull;
                            sh.TOB = reader["TOB"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("TOB")) : Snull;
                            sh.PlaceOfBirth = reader["PlaceOfBirth"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("PlaceOfBirth")) : Snull;
                            sh.Gothram = reader["Gothram"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Gothram")) : Snull;
                            sh.Caste = (reader["MotherTongue"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("MotherTongue")) + "-") : "") + (reader["Caste"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("Caste")).ToString()) : Snull) + (reader["SubCaste"] != DBNull.Value ? ("(" + (reader.GetString(reader.GetOrdinal("SubCaste"))) + ")") : "");
                            sh.maritalstatus = reader["MaritalStatus"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("MaritalStatus")) : Snull;
                            sh.Star = reader["Star"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Star")) : Snull;
                            sh.Color = reader["Color"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Color")) : Snull;
                            sh.Height = reader["Height"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Height")) : Snull;
                            sh.EducationGroup = reader["EducationGroup"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationGroup")) : Snull;
                            sh.EduGroupnamenew = reader["EduGroupnamenew"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("EduGroupnamenew")) : Snull;
                            sh.Profession = reader["Profession"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Profession")) : Snull;
                            sh.JobLocation = reader["JobLocation"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("JobLocation")) : Snull;
                            sh.Income = reader["Income"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Income")) : Snull;
                            sh.currency = reader["currency"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("currency")) : Snull;
                            sh.FFNative = reader["FF Native"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("FF Native")) : Snull;
                            sh.MFNative = reader["MF Native"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("MF Native")) : Snull;
                            sh.Property = reader["Property"] != DBNull.Value ? reader.GetDouble(reader.GetOrdinal("Property")).ToString() : Snull;
                            sh.Intercaste = reader["Intercaste"] != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("Intercaste")) : bnull;
                            sh.fathercaste = reader["fathercaste"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("fathercaste")) : Snull;
                            sh.mothercaste = reader["mothercaste"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("mothercaste")) : Snull;
                            sh.PhotoCount = reader["PhotoCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoCount")) : inull;
                            //   sh.imageurl = Masterdropdown.getProfilepicFullphotowithoutaccess(reader["Cust_ID")) ? reader["Cust_ID") ): "0");
                            sh.serviceDate = reader["CreatedDate"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("CreatedDate")) : string.Empty;
                            sh.TotalRows = reader["TotalRows"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("TotalRows")) : Lnull;
                            sh.Gender = reader["Gender"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Gender")) : Snull;
                            sh.countrylivingin = reader["CountryLivingin"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("CountryLivingin")) : Snull;
                            sh.CustomerFullPhoto = reader["CustomerFullPhoto"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("CustomerFullPhoto")) : Snull;

                            sh.Mystatus = reader["Mystatus"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Mystatus")) : Snull;
                            sh.OppStatus = reader["OppStatus"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("OppStatus")) : Snull;
                            sh.FromTicketIdSuf = reader["FromTicketIdSuf"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromTicketIdSuf")) : Snull;
                            sh.ToTicketIDSuf = reader["ToTicketIDSuf"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToTicketIDSuf")) : Snull;
                            sh.FromTicketID = reader["FromTicketID"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("FromTicketID")) : Lnull;
                            sh.ToTicketID = reader["ToTicketID"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ToTicketID")) : Lnull;
                            sh.Cust_ProfileInterestsLog_ID = reader["Cust_ProfileInterestsLog_ID"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_ProfileInterestsLog_ID")) : Lnull;
                            sh.FTicketStatus = reader["FTicketStatus"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("FTicketStatus")) : Snull;
                            sh.TTicketStatus = reader["TTicketStatus"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("TTicketStatus")) : Snull;
                        }
                        details.Add(sh);
                    }
                }

                reader.Close();

            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Mobjpartner.CustID, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }

            status = 1;
            return details;
        }

        public List<slideshowNew> GetShowDataForAdvanced(EmployeeSearch Mobjpartner, string spName)
        {
            List<slideshowNew> details = new List<slideshowNew>();
            SqlDataReader reader;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string Snull = "--";
            int? inull = null;
            bool? bnull = null;
            Int64? Lnull = null;
            int status = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {

                SqlParameter[] parm = new SqlParameter[6];

                parm[0] = new SqlParameter("@TblDetails", SqlDbType.Structured);
                parm[0].Value = Mobjpartner.dtTableValues;
                parm[1] = new SqlParameter("@intCust_id", SqlDbType.Int);
                parm[1].Value = Mobjpartner.CustID;
                parm[2] = new SqlParameter("@intEmpID", SqlDbType.Int);
                parm[2].Value = Mobjpartner.EmpID;
                parm[3] = new SqlParameter("@i_Startindex", SqlDbType.Int);
                parm[3].Value = Mobjpartner.startindex;
                parm[4] = new SqlParameter("@i_EndIndex", SqlDbType.Int);
                parm[4].Value = Mobjpartner.EndIndex;
                parm[5] = new SqlParameter("@Status", SqlDbType.Int);
                parm[5].Direction = ParameterDirection.Output;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        slideshowNew sh = new slideshowNew();
                        {

                            sh.Cust_ID = reader["Cust_ID"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Cust_ID")) : Snull;
                            sh.paid = reader["paid"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("paid")) : inull;
                            sh.ProfileID = reader["ProfileID"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : Snull;
                            sh.KMPLID = reader["KMPLID"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("KMPLID")) : Snull;
                            sh.IsConfidential = reader["IsConfidential"] != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("IsConfidential")) : bnull;
                            sh.SuperConfidentila = reader["SuperConfidentila"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("SuperConfidentila")) : inull;
                            sh.FirstName = reader["FirstName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("FirstName")) : Snull;
                            sh.LastName = reader["LastName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("LastName")) : Snull;
                            sh.PhotoNames = reader["PhotoNames"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoNames")) : Snull;
                            sh.Photo = reader["Photo"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Photo")) : Snull;
                            sh.ApplicationPhotoPath = reader["ApplicationPhotoPath"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ApplicationPhotoPath")) : Snull;
                            sh.HoroscopeStatus = reader["HoroscopeStatus"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("HoroscopeStatus")) : inull;
                            sh.HoroscopePath = reader["HoroscopePath"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("HoroscopePath")) : Snull;
                            sh.email = reader["email"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("email")) : Snull;
                            sh.NoOfBrothers = reader["NoOfBrothers"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("NoOfBrothers")) : inull;
                            sh.NoOfSisters = reader["NoOfSisters"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("NoOfSisters")) : inull;
                            sh.CasteID = reader["CasteID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CasteID")) : inull;
                            sh.HeightInCentimeters = reader["HeightInCentimeters"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("HeightInCentimeters")) : inull;
                            sh.MaritalStatusID = reader["MaritalStatusID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("MaritalStatusID")) : inull;
                            sh.DOB = reader["DOB"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("DOB")) : Snull;
                            sh.Age = reader["Age"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Age")) : inull;
                            sh.TOB = reader["TOB"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("TOB")) : Snull;
                            sh.PlaceOfBirth = reader["PlaceOfBirth"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("PlaceOfBirth")) : Snull;
                            sh.Gothram = reader["Gothram"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Gothram")) : Snull;
                            sh.Caste = (reader["MotherTongue"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("MotherTongue")) + "-") : "") + (reader["Caste"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("Caste")).ToString()) : Snull) + (reader["SubCaste"] != DBNull.Value ? ("(" + (reader.GetString(reader.GetOrdinal("SubCaste"))) + ")") : "");
                            sh.maritalstatus = reader["MaritalStatus"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("MaritalStatus")) : Snull;
                            sh.Star = reader["Star"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Star")) : Snull;
                            sh.Color = reader["Color"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Color")) : Snull;
                            sh.Height = reader["Height"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Height")) : Snull;
                            sh.EducationGroup = reader["EducationGroup"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationGroup")) : Snull;
                            sh.EduGroupnamenew = reader["EduGroupnamenew"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("EduGroupnamenew")) : Snull;
                            sh.Profession = reader["Profession"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Profession")) : Snull;
                            sh.JobLocation = reader["JobLocation"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("JobLocation")) : Snull;
                            sh.Income = reader["Income"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Income")) : Snull;
                            sh.currency = reader["currency"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("currency")) : Snull;
                            sh.FFNative = reader["FF Native"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("FF Native")) : Snull;
                            sh.MFNative = reader["MF Native"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("MF Native")) : Snull;
                            sh.Property = reader["Property"] != DBNull.Value ? reader.GetDouble(reader.GetOrdinal("Property")).ToString() : Snull;
                            sh.Intercaste = reader["Intercaste"] != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("Intercaste")) : bnull;
                            sh.fathercaste = reader["fathercaste"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("fathercaste")) : Snull;
                            sh.mothercaste = reader["mothercaste"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("mothercaste")) : Snull;
                            sh.PhotoCount = reader["PhotoCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoCount")) : inull;
                            //   sh.imageurl = Masterdropdown.getProfilepicFullphotowithoutaccess(reader["Cust_ID")) ? reader["Cust_ID") ): "0");
                            sh.serviceDate = reader["CreatedDate"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("CreatedDate")) : string.Empty;
                            sh.TotalRows = reader["TotalRows"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("TotalRows")) : Lnull;
                            sh.Gender = reader["Gender"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Gender")) : Snull;
                            sh.countrylivingin = reader["CountryLivingin"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("CountryLivingin")) : Snull;
                            sh.CustomerFullPhoto = reader["CustomerFullPhoto"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("CustomerFullPhoto")) : Snull;


                            sh.Mystatus = reader["Mystatus"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Mystatus")) : Snull;
                            sh.OppStatus = reader["OppStatus"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("OppStatus")) : Snull;
                            sh.FromTicketIdSuf = reader["FromTicketIdSuf"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromTicketIdSuf")) : Snull;
                            sh.ToTicketIDSuf = reader["ToTicketIDSuf"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToTicketIDSuf")) : Snull;
                            sh.FromTicketID = reader["FromTicketID"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("FromTicketID")) : Lnull;
                            sh.ToTicketID = reader["ToTicketID"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ToTicketID")) : Lnull;
                            sh.Cust_ProfileInterestsLog_ID = reader["Cust_ProfileInterestsLog_ID"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_ProfileInterestsLog_ID")) : Lnull;
                            sh.FTicketStatus = reader["FTicketStatus"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("FTicketStatus")) : Snull;
                            sh.TTicketStatus = reader["TTicketStatus"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("TTicketStatus")) : Snull;

                        }
                        details.Add(sh);
                    }
                }

                reader.Close();

            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Mobjpartner.CustID, null, null);
            }
            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }

            status = 1;
            return details;

        }




    }
}