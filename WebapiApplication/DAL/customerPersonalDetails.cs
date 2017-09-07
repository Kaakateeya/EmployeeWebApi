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
using System.IO;
using System.Web;

namespace WebapiApplication.DAL
{
    public class customerPersonalDetails
    {
        public CustomerPersonalDetails DgetpersonalDetailsDAL(string CustID)
        {
            SqlParameter[] parm = new SqlParameter[4];
            SqlDataReader reader;
            CustomerPersonalDetails MobjPersonalsML = null;

            Int64? intNull = null;
            int? iNull = null;
            DateTime? dtnull = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@CustID", SqlDbType.Int);
                parm[0].Value = CustID;
                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, "[dbo].[Usp_getcustomerinformation_NewDesign]", parm);
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {

                        MobjPersonalsML = new CustomerPersonalDetails();
                        MobjPersonalsML.Cust_ID = (reader["Cust_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_ID")) : intNull;
                        MobjPersonalsML.ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : null;
                        MobjPersonalsML.FirstName = (reader["FirstName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FirstName")) : null;
                        MobjPersonalsML.LastName = (reader["LastName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("LastName")) : null;
                        MobjPersonalsML.Name = (reader["Name"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Name")) : null;
                        MobjPersonalsML.Borncountry = (reader["Borncountry"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Borncountry")) : null;
                        MobjPersonalsML.Age = (reader["Age"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Age")) : iNull;
                        MobjPersonalsML.DateofBirth = (reader["DateofBirth"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("DateofBirth")) : null;
                        MobjPersonalsML.Caste = (reader["Caste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Caste")) : null;
                        MobjPersonalsML.SubCaste = (reader["SubCaste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("SubCaste")) : null;
                        MobjPersonalsML.Religion = (reader["Religion"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Religion")) : null;
                        MobjPersonalsML.Complexion = (reader["Complexion"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Complexion")) : null;
                        MobjPersonalsML.Height = (reader["Height"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Height")) : null;
                        MobjPersonalsML.IsBornCountry = (reader["IsBornCountry"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsBornCountry")) : iNull;
                        MobjPersonalsML.MartialStatus = (reader["MartialStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MartialStatus")) : null;
                        MobjPersonalsML.ProfileStatusID = (reader["ProfileStatusID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProfileStatusID")) : iNull;
                        MobjPersonalsML.HeightInCentimeters = (reader["HeightInCentimeters"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("HeightInCentimeters")) : iNull;
                        MobjPersonalsML.ComplexionID = (reader["ComplexionID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ComplexionID")) : iNull;
                        MobjPersonalsML.CountryID = (reader["CountryID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CountryID")) : iNull;
                        MobjPersonalsML.DateOfBirth = (reader["DateOfBirth"]) != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("DateOfBirth")) : dtnull;
                        MobjPersonalsML.SubCasteID = (reader["SubCasteID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("SubCasteID")) : iNull;
                        MobjPersonalsML.CasteID = (reader["CasteID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CasteID")) : iNull;
                        MobjPersonalsML.ReligionID = (reader["ReligionID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ReligionID")) : iNull;
                        MobjPersonalsML.MaritalStatusID = (reader["MaritalStatusID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("MaritalStatusID")) : iNull;
                        MobjPersonalsML.Mothertongue = (reader["Mothertongue"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Mothertongue")) : null;
                        MobjPersonalsML.ProfilePic = (reader["ProfilePic"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfilePic")) : null;
                        MobjPersonalsML.GenderID = (reader["GenderID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("GenderID")) : iNull;
                        MobjPersonalsML.ProfileOwner = (reader["ProfileOwner"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ProfileOwner")) : intNull;
                        MobjPersonalsML.PaidStatus = (reader["PaidStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PaidStatus")) : iNull;

                    }
                }

                reader.Close();
            }

            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog("[dbo].[Usp_getcustomerinformation_NewDesign]", Convert.ToString(EX.Message), Convert.ToInt64(CustID), null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();

            }
            return MobjPersonalsML;

        }
        public int DCustomerPersonal_insertUpdateDetails(UpdatePersonaldetails MobjEdudetails, string strSpName, string strTableparam)
        {
            int iStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] parm = new SqlParameter[5];

                parm[0] = new SqlParameter("@CustID", SqlDbType.Int);
                parm[0].Value = MobjEdudetails.intCusID;
                parm[1] = new SqlParameter(strTableparam, SqlDbType.Structured);
                parm[1].Value = MobjEdudetails.dtTableValues;
                parm[2] = new SqlParameter("@EmpID", SqlDbType.Int);
                parm[2].Value = MobjEdudetails.EmpID;
                parm[3] = new SqlParameter("@IsReViewed", SqlDbType.Int);
                parm[3].Value = MobjEdudetails.Admin;
                parm[4] = new SqlParameter("@Status", SqlDbType.Int);
                parm[4].Direction = ParameterDirection.Output;

                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, strSpName, parm);
                if (string.Compare(parm[4].Value.ToString(), System.DBNull.Value.ToString()) == 0) { iStatus = 0; } else { iStatus = Convert.ToInt32(parm[4].Value); }
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(strSpName, Convert.ToString(ex.Message), MobjEdudetails.intCusID, null, null);
            }

            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return iStatus;
        }
        public ArrayList DgetUpdateEducationdetailsDAL(long? intCusID, string strSpname)
        {
            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[5];
            SqlDataReader reader;
            bool? bnull = null;
            Int64? intNull = null;
            int? iNull = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@CustomerID", SqlDbType.Int);
                parm[0].Value = intCusID;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, strSpname, parm);
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        UpdateEducationdetailsML MobjEdu = new UpdateEducationdetailsML();
                        MobjEdu.intEduID = (reader["intEduID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("intEduID")) : iNull;
                        MobjEdu.EducationCategory = (reader["EducationCategory"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationCategory")) : null;
                        MobjEdu.EducationGroup = (reader["EducationGroup"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationGroup")) : null;
                        MobjEdu.EducationSpecialization = (reader["EducationSpecialization"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationSpecialization")) : null;
                        MobjEdu.EduUniversity = (reader["EduUniversity"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EduUniversity")) : null;
                        MobjEdu.EduCollege = (reader["EduCollege"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EduCollege")) : null;
                        MobjEdu.EduCountryIn = (reader["EduCountryIn"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EduCountryIn")) : null;
                        MobjEdu.EduStateIn = (reader["EduStateIn"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EduStateIn")) : null;
                        MobjEdu.EduDistrictIn = (reader["EduDistrictIn"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EduDistrictIn")) : null;
                        MobjEdu.EduCityIn = (reader["EduCityIn"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EduCityIn")) : null;
                        MobjEdu.EduPassOfYear = (reader["EduPassOfYear"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EduPassOfYear")) : null;
                        MobjEdu.EduHighestDegree = (reader["EduHighestDegree"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("EduHighestDegree")) : iNull;
                        MobjEdu.intCusID = (reader["Cust_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_ID")) : intNull;
                        MobjEdu.EducationID = (reader["EducationID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("EducationID")) : intNull;
                        MobjEdu.Educationdesc = (reader["Educationdesc"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Educationdesc")) : null;

                        MobjEdu.EducationCategoryID = (reader["EducationCategoryID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("EducationCategoryID")) : iNull;
                        MobjEdu.EducationGroupID = (reader["EducationGroupID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("EducationGroupID")) : iNull;
                        MobjEdu.EducationSpecializationID = (reader["EducationSpecializationID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("EducationSpecializationID")) : iNull;
                        MobjEdu.CountryID = (reader["CountryID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CountryID")) : iNull;
                        MobjEdu.StateID = (reader["StateID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("StateID")) : iNull;
                        MobjEdu.DistrictID = (reader["DistrictID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("DistrictID")) : iNull;
                        MobjEdu.CityID = (reader["CityID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CityID")) : iNull;
                        MobjEdu.reviewstatus = (reader["reviewstatus"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("reviewstatus")) : bnull;
                        MobjEdu.EmpLastModificationDate = (reader["EmpLastModificationDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EmpLastModificationDate")) : null;

                        MobjEdu.ProfileGrade = (reader["ProfileGrade"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProfileGrade")) : iNull;
                        MobjEdu.ProfileGradestatus = (reader["ProfileGradestatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProfileGradestatus")) : iNull;

                        arrayList.Add(MobjEdu);
                    }

                }

                reader.Close();

            }

            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(EX.Message), intCusID, null, null);
            }
            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return arrayList;
        }
        public ArrayList DgetUpdateProfessionDetailsDAL(long? intCusID, string strSpname)
        {
            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[5];
            SqlDataReader reader;

            Int64? intNull = null;
            int? iNull = null;

            bool? bnull = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@CustomerID", SqlDbType.Int);
                parm[0].Value = intCusID;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, strSpname, parm);
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        UpdateProfessionML MobjProf = new UpdateProfessionML();
                        MobjProf.iProfID = (reader["ProfID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProfID")) : iNull;
                        MobjProf.ProfessionCategory = (reader["ProfessionCategory"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfessionCategory")) : null;
                        MobjProf.ProfessionGroup = (reader["ProfessionGroup"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfessionGroup")) : null;
                        MobjProf.Professional = (reader["Professional"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Professional")) : null;
                        MobjProf.CompanyName = (reader["CompanyName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CompanyName")) : null;
                        MobjProf.CountryWorkingIn = (reader["CountryWorkingIn"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CountryWorkingIn")) : null;
                        MobjProf.StateWorkingIn = (reader["StateWorkingIn"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("StateWorkingIn")) : null;
                        MobjProf.DistrictWorkingIn = (reader["DistrictWorkingIn"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("DistrictWorkingIn")) : null;
                        MobjProf.CityWorkingIn = (reader["CityWorkingIn"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CityWorkingIn")) : null;
                        MobjProf.OccupationDetails = (reader["OccupationDetails"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("OccupationDetails")) : null;
                        MobjProf.Currency = (reader["Currency"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Currency")) : null;
                        MobjProf.Salary = (reader["Salary"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Salary")) : null;

                        MobjProf.ResidingSince = (reader["ResidingSince"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ResidingSince")) : null;
                        MobjProf.ArrivingDate = (reader["ArrivingDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ArrivingDate")) : null;
                        MobjProf.VisaStatus = (reader["VisaStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("VisaStatus")) : null;
                        MobjProf.WorkingFromDate = (reader["WorkingFromDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("WorkingFromDate")) : null;
                        MobjProf.WorkingToDate = (reader["WorkingToDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("WorkingToDate")) : null;
                        MobjProf.VisaStatus = (reader["VisaStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("VisaStatus")) : null;
                        MobjProf.profGridID = (reader["profGridID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("profGridID")) : iNull;
                        MobjProf.DepartureDate = (reader["DepartureDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("DepartureDate")) : null;

                        MobjProf.ProfessionCategoryID = (reader["ProfessionCategoryID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProfessionCategoryID")) : iNull;
                        MobjProf.ProfessionGroupID = (reader["ProfessionGroupID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProfessionGroupID")) : iNull;
                        MobjProf.ProfessionID = (reader["ProfessionID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProfessionID")) : iNull;
                        MobjProf.CountryID = (reader["CountryID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CountryID")) : iNull;
                        MobjProf.StateID = (reader["StateID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("StateID")) : iNull;
                        MobjProf.DistrictID = (reader["DistrictID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("DistrictID")) : iNull;
                        MobjProf.CityID = (reader["CityID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CityID")) : iNull;
                        MobjProf.SalaryCurrency = (reader["SalaryCurrency"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("SalaryCurrency")) : iNull;
                        MobjProf.VisaTypeID = (reader["VisaTypeID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("VisaTypeID")) : iNull;
                        MobjProf.Cust_Profession_ID = (reader["Cust_Profession_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_Profession_ID")) : intNull;
                        MobjProf.reviewstatus = (reader["reviewstatus"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("reviewstatus")) : bnull;
                        MobjProf.EmpLastModificationDate = (reader["EmpLastModificationDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EmpLastModificationDate")) : null;

                        arrayList.Add(MobjProf);
                    }
                }

                reader.Close();

            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(EX.Message), intCusID, null, null);
            }
            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return arrayList;
        }
        public ArrayList DgetParentDetailsDisplay(long? intCusID, string strSpname)
        {
            DataSet dsParentdetails = new DataSet();
            SqlDataAdapter daParentDetails = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(strSpname, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Custid", intCusID);
                daParentDetails.SelectCommand = cmd;
                daParentDetails.Fill(dsParentdetails);
            }
            catch (Exception Ex)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(Ex.Message), intCusID, null, null);

            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayList(dsParentdetails);
        }

        public ArrayList DgetCustomerpartnerpreferencesDetailsDisplay(long? intCusID, string strSpname)
        {

            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[5];
            SqlDataReader reader;

            Int64? intNull = null;
            int? iNull = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@CustID", SqlDbType.Int);
                parm[0].Value = intCusID;
                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, strSpname, parm);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UpdatePartnerML MObjPartnerML = new UpdatePartnerML();
                        MObjPartnerML.Gender = (reader["Gender"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Gender")) : null;
                        MObjPartnerML.AgeGap = (reader["AgeGap"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("AgeGap")) : null;
                        MObjPartnerML.Height = (reader["Height"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Height")) : null;
                        MObjPartnerML.Mothertongue = (reader["Mothertongue"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Mothertongue")) : null;
                        MObjPartnerML.Religion = (reader["Religion"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Religion")) : null;
                        MObjPartnerML.Caste = (reader["Caste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Caste")) : null;
                        MObjPartnerML.Subcaste = (reader["Subcaste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Subcaste")) : null;
                        MObjPartnerML.MaritalStatus = (reader["MaritalStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MaritalStatus")) : null;
                        MObjPartnerML.EducationGroup = (reader["EducationGroup"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationGroup")) : null;
                        MObjPartnerML.Profession = (reader["Profession"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Profession")) : null;
                        MObjPartnerML.Kujadosham = (reader["Kujadosham"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Kujadosham")) : null;
                        MObjPartnerML.intCusID = (reader["Cust_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_ID")) : intNull;
                        MObjPartnerML.StarLanguage = (reader["StarLanguage"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("StarLanguage")) : null;
                        MObjPartnerML.Stars = (reader["Stars"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Stars")) : null;
                        MObjPartnerML.Diet = (reader["Diet"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Diet")) : null;
                        MObjPartnerML.CountryName = (reader["CountryName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CountryName")) : null;
                        MObjPartnerML.StateName = (reader["StateName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("StateName")) : null;
                        MObjPartnerML.EducationCategory = (reader["EducationCategory"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationCategory")) : null;
                        MObjPartnerML.EducationSpecilization = (reader["EducationSpecilization"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationSpecilization")) : null;
                        MObjPartnerML.professionCategory = (reader["professionCategory"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("professionCategory")) : null;
                        MObjPartnerML.ProfessionGroup = (reader["ProfessionGroup"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfessionGroup")) : null;
                        MObjPartnerML.ProfessionGroupID = (reader["ProfessionGroupID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfessionGroupID")) : null;
                        MObjPartnerML.TypeOfStar = (reader["TypeOfStar"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("TypeOfStar")) : null;
                        MObjPartnerML.MotherTongueID = (reader["MotherTongueID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MotherTongueID")) : null;
                        MObjPartnerML.religionid = (reader["religionid"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("religionid")) : null;
                        MObjPartnerML.casteid = (reader["casteid"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("casteid")) : null;
                        MObjPartnerML.subcasteid = (reader["subcasteid"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("subcasteid")) : null;
                        MObjPartnerML.maritalstatusid = (reader["maritalstatusid"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("maritalstatusid")) : null;
                        MObjPartnerML.complexionid = (reader["complexionid"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("complexionid")) : null;
                        MObjPartnerML.EducationCategoryID = (reader["EducationCategoryID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationCategoryID")) : null;
                        MObjPartnerML.EducationGroupID = (reader["EducationGroupID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationGroupID")) : null;
                        MObjPartnerML.EduSpecializationID = (reader["EduSpecializationID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EduSpecializationID")) : null;
                        MObjPartnerML.ProfessionCategoryID = (reader["ProfessionCategoryID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfessionCategoryID")) : null;
                        MObjPartnerML.diet = (reader["diet"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("diet")) : null;
                        MObjPartnerML.PreferredStars = (reader["PreferredStars"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PreferredStars")) : null;
                        MObjPartnerML.CountryID = (reader["CountryID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CountryID")) : null;
                        MObjPartnerML.StateID = (reader["StateID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("StateID")) : null;
                        MObjPartnerML.Agemin = (reader["Agemin"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Agemin")) : iNull;
                        MObjPartnerML.AgeMax = (reader["AgeMax"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("AgeMax")) : iNull;
                        MObjPartnerML.MinHeight = (reader["MinHeight"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MinHeight")) : null;
                        MObjPartnerML.MaxHeight = (reader["MaxHeight"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MaxHeight")) : null;
                        MObjPartnerML.DistrictID = (reader["DistrictID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("DistrictID")) : null;
                        MObjPartnerML.LocationPrefPlace = (reader["LocationPrefPlace"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("LocationPrefPlace")) : null;
                        MObjPartnerML.KujaDoshamID = (reader["KujaDoshamID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("KujaDoshamID")) : iNull;
                        MObjPartnerML.DietID = (reader["DietID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("DietID")) : null;
                        MObjPartnerML.StarLanguageID = (reader["StarLanguageID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("StarLanguageID")) : iNull;
                        MObjPartnerML.PartnerDescripition = (reader["PartnerDescripition"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PartnerDescripition")) : null;
                        MObjPartnerML.reviewstatus = (reader["reviewstatus"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("reviewstatus")) : false;
                        MObjPartnerML.regionId = (reader["regionId"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("regionId")) : null;
                        MObjPartnerML.branchid = (reader["branchid"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("branchid")) : null;
                        MObjPartnerML.RegionName = (reader["RegionName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RegionName")) : null;
                        MObjPartnerML.BranchName = (reader["BranchName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("BranchName")) : null;
                        MObjPartnerML.EmpLastModificationDate = (reader["EmpLastModificationDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EmpLastModificationDate")) : null;
                        arrayList.Add(MObjPartnerML);
                    }
                }

                reader.Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(EX.Message), intCusID, null, null);
            }
            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return arrayList;
        }
        public ArrayList DgetsiblingsDetailsDisplay(long? intCusID, string strSpname)
        {
            ArrayList arrayList = new ArrayList();

            DataSet dssibling = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[5];
                parm[0] = new SqlParameter("@Custid", SqlDbType.Int);
                parm[0].Value = intCusID;
                parm[1] = new SqlParameter("@SibilingVaritionFlag", SqlDbType.Bit);
                parm[1].Value = 0;
                parm[2] = new SqlParameter("@Status", SqlDbType.Int);
                parm[2].Direction = ParameterDirection.Output;
                dssibling = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, strSpname, parm);

            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(ex.Message), intCusID, null, null);
            }
            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayList(dssibling);
        }

        public ArrayList DgetAstroDetailsDisplay(long? intCusID, string strSpname)
        {
            ArrayList arrayList = new ArrayList();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet dtAstrodetails = new DataSet();
            SqlDataAdapter daParentDetails = new SqlDataAdapter();
            try
            {
                SqlCommand cmd = new SqlCommand(strSpname, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Custid", intCusID);
                daParentDetails.SelectCommand = cmd;
                daParentDetails.Fill(dtAstrodetails);

            }
            catch (Exception Ex)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(Ex.Message), intCusID, null, null);
            }
            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }

            return Commonclass.convertdataTableToArrayList(dtAstrodetails);
        }
        public ArrayList DgetPropertyDetailsDisplay(long? intCusID, string strSpname)
        {
            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[5];
            SqlDataReader reader;
            int? iNull = null;
            bool? bnull = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@CustID", SqlDbType.Int);
                parm[0].Value = intCusID;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, strSpname, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UpdatePropertyML mobjProperty = new UpdatePropertyML();
                        mobjProperty.PropertyDetails = (reader["PropertyDetails"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PropertyDetails")) : null;
                        mobjProperty.isProperty = (reader["isProperty"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("isProperty")) : null;
                        mobjProperty.PropertyType = (reader["PropertyType"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PropertyType")) : null;
                        mobjProperty.PropertyvalueType = (reader["PropertyvalueType"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PropertyvalueType")) : null;
                        mobjProperty.PropertyValue = (reader["PropertyValue"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PropertyValue")) : iNull;
                        mobjProperty.PropertyquantityType = (reader["PropertyquantityType"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PropertyquantityType")) : null;
                        mobjProperty.Propertyquantity = (reader["Propertyquantity"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Propertyquantity")) : iNull;
                        mobjProperty.ProCountry = (reader["ProCountry"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProCountry")) : iNull;
                        mobjProperty.ProState = (reader["ProState"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProState")) : iNull;
                        mobjProperty.ProDistrict = (reader["ProDistrict"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProDistrict")) : iNull;
                        mobjProperty.ProCity = (reader["ProCity"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProCity")) : iNull;
                        mobjProperty.ProShowin = (reader["ProShowin"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProShowin")) : iNull;
                        mobjProperty.PropertyID = (reader["PropertyID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PropertyID")) : iNull;
                        mobjProperty.Custpropertyid = (reader["Custpropertyid"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Custpropertyid")) : iNull;
                        mobjProperty.FamilyStatus = (reader["FamilyStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FamilyStatus")) : null;

                        //backendFields
                        mobjProperty.ProperTypeID = (reader["ProperTypeID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProperTypeID")) : iNull;
                        mobjProperty.PropertyValueCurrencyID = (reader["PropertyValueCurrencyID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PropertyValueCurrencyID")) : iNull;
                        mobjProperty.QuantityTypeID = (reader["QuantityTypeID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("QuantityTypeID")) : iNull;
                        mobjProperty.FamilyValuesID = (reader["FamilyValuesID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("FamilyValuesID")) : iNull;
                        mobjProperty.SharedPropertyID = (reader["SharedPropertyID"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("SharedPropertyID")) : bnull;
                        mobjProperty.ShowInViewProfileID = (reader["ShowInViewProfileID"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("ShowInViewProfileID")) : bnull;
                        mobjProperty.reviewstatus = (reader["reviewstatus"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("reviewstatus")) : bnull;
                        mobjProperty.EmpLastModificationDate = (reader["EmpLastModificationDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EmpLastModificationDate")) : null;
                        arrayList.Add(mobjProperty);
                    }
                }

                reader.Close();
            }

            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(EX.Message), intCusID, null, null);

            }
            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return arrayList;
        }
        public ArrayList DgetRelativeDetailsDisplay(long? intCusID, string strSpname)
        {
            ArrayList arrayList = new ArrayList();
            DataSet dsRelativedetails = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[5];
                parm[0] = new SqlParameter("@CustID", SqlDbType.Int);
                parm[0].Value = intCusID;
                parm[1] = new SqlParameter("@RelativeVaritionFlag", SqlDbType.Bit);
                parm[1].Value = 0;
                parm[2] = new SqlParameter("@Status", SqlDbType.Int);
                parm[2].Direction = ParameterDirection.Output;
                dsRelativedetails = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, strSpname, parm);
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(ex.Message), intCusID, null, null);
            }
            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayList(dsRelativedetails);
        }
        public ArrayList DgetReferenceViewDetailsDisplay(long? intCusID, string strSpname)
        {

            SqlParameter[] parm = new SqlParameter[5];
            ArrayList arrayList = new ArrayList();
            int? iNull = null;
            Int64? intnull = null;
            bool? bnull = null;
            SqlDataReader reader;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@Custid", SqlDbType.Int);
                parm[0].Value = intCusID;
                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, strSpname, parm);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        UpdateReferenceML MobjRef = new UpdateReferenceML();
                        MobjRef.Relatioshiptype = (reader["Relatioshiptype"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Relatioshiptype")) : null;
                        MobjRef.RefrenceName = (reader["RefrenceName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceName")) : null;
                        MobjRef.RefrenceProfessionDetails = (reader["RefrenceProfessionDetails"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceProfessionDetails")) : null;
                        MobjRef.RefrenceNativePlace = (reader["RefrenceNativePlace"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceNativePlace")) : null;
                        MobjRef.RefrenceLandNumberwithCode = (reader["RefrenceLandNumberwithCode"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceLandNumberwithCode")) : null;
                        MobjRef.RefrenceMobileNumberWithcode = (reader["RefrenceMobileNumberWithcode"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceMobileNumberWithcode")) : null;
                        MobjRef.RefrenceEmail = (reader["RefrenceEmail"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceEmail")) : null;
                        MobjRef.RefrenceNarration = (reader["RefrenceNarration"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceNarration")) : null;
                        MobjRef.RefrenceCity = (reader["RefrenceCity"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceCity")) : null;
                        MobjRef.RefenceCurrentLocation = (reader["RefenceCurrentLocation"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefenceCurrentLocation")) : null;
                        MobjRef.RefrenceProfessionCategory = (reader["RefrenceProfessionCategory"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceProfessionCategory")) : null;
                        MobjRef.RefrenceProfessionGroup = (reader["RefrenceProfessionGroup"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceProfessionGroup")) : null;
                        //back end filelds
                        MobjRef.ReletionShipTypeID = (reader["ReletionShipTypeID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ReletionShipTypeID")) : iNull;
                        MobjRef.RefrenceNativePlaceID = (reader["RefrenceNativePlaceID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceNativePlaceID")) : null;
                        MobjRef.RefrenceCityid = (reader["RefrenceCityID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceCityID")) : null;
                        MobjRef.RefrenceDistrictID = (reader["RefrenceDistrictID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceDistrictID")) : null;
                        MobjRef.RefrenceStateID = (reader["RefrenceStateID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceStateID")) : null;
                        MobjRef.RefrenceCountry = (reader["RefrenceCountryID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceCountryID")) : null;
                        MobjRef.RefrenceLandCountryId = (reader["RefrenceLandCountryId"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceLandCountryId")) : null;
                        MobjRef.RefrenceAreaCode = (reader["RefrenceAreaCode"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceAreaCode")) : null;
                        MobjRef.RefrenceLandNumber = (reader["RefrenceLandNumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceLandNumber")) : null;
                        MobjRef.RefrenceMobileCountryID = (reader["RefrenceMobileCountryID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceMobileCountryID")) : null;
                        MobjRef.RefrenceMobileNumberID = (reader["RefrenceMobileNumberID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceMobileNumberID")) : null;
                        MobjRef.RefrenceProfessionCategoryID = (reader["RefrenceProfessionCategoryID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceProfessionCategoryID")) : null;
                        MobjRef.RefrencePRofessionGroupID = (reader["RefrencePRofessionGroupID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrencePRofessionGroupID")) : null;
                        MobjRef.RefrenceProessionID = (reader["RefrenceProessionID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("RefrenceProessionID")) : iNull;
                        MobjRef.RefrenceCust_Reference_ID = (reader["Cust_Reference_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_Reference_ID")) : intnull;
                        MobjRef.RefrenceProfession = (reader["RefrenceProfession"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RefrenceProfession")) : null;
                        MobjRef.ReferenceFirstName = (reader["ReferenceFirstName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ReferenceFirstName")) : null;
                        MobjRef.ReferenceLastName = (reader["ReferenceLastName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ReferenceLastName")) : null;
                        MobjRef.reviewstatus = (reader["reviewstatus"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("reviewstatus")) : bnull;
                        MobjRef.EmpLastModificationDate = (reader["EmpLastModificationDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EmpLastModificationDate")) : null;
                        arrayList.Add(MobjRef);
                    }
                }
                reader.Close();

            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(EX.Message), intCusID, null, null);
            }
            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return arrayList;
        }
        public ArrayList DGetphotosofCustomer(string Custid, int? EmpIDQueryInt, string spName)
        {
            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[10];
            SqlDataReader reader;
            Int64? intNull = null;
            int? iNull = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@cust_id", SqlDbType.Int);
                parm[0].Value = Custid;
                parm[1] = new SqlParameter("@Empid", SqlDbType.Int);
                parm[1].Value = EmpIDQueryInt;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PhotoSectionMl ml = new PhotoSectionMl();
                        ml.Cust_ID = (reader["Cust_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_Id")) : intNull;
                        ml.PhotoName = (reader["PhotoName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoName")) : null;
                        ml.PhotoPassword = (reader["PhotoPassword"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoPassword")) : null;
                        ml.VisibleToID = (reader["VisibleToID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("VisibleToID")) : iNull;
                        ml.DisplayOrder = (reader["DisplayOrder"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("DisplayOrder")) : iNull;
                        ml.UploadedByEmpID = (reader["UploadedByEmpID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("UploadedByEmpID")) : intNull;
                        ml.UploadedDate = (reader["UploadedDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("UploadedDate")) : null;
                        ml.ModifiedDate = (reader["ModifiedDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ModifiedDate")) : null;
                        ml.IsMain = (reader["IsMain"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsMain")) : iNull;
                        ml.IsActive = (reader["IsActive"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsActive")) : iNull;
                        ml.PhotoStatus = (reader["PhotoStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoStatus")) : iNull;
                        ml.AssignedTo = (reader["AssignedTo"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("AssignedTo")) : iNull;
                        ml.AssignedDate = (reader["AssignedDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("AssignedDate")) : null;
                        ml.IsReviewed = (reader["IsReviewed"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsReviewed")) : iNull;
                        ml.ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : null;
                        ml.IsThumbNailCreated = (reader["IsThumbNailCreated"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsThumbNailCreated")) : iNull;
                        ml.Cust_Photos_ID = (reader["Cust_Photos_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_Photos_ID")) : intNull;
                        ml.strModifiedByEmpID = (reader["ModifiedByEmpID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ModifiedByEmpID")) : null;
                        ml.UploadedBy = (reader["UploadedBy"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("UploadedBy")) : null;
                        ml.GenderID = (reader["GenderID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("GenderID")) : iNull;
                        arrayList.Add(ml);
                    }
                }
                reader.Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt64(Custid), null, null);
            }
            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return arrayList;
        }

        public string DgetDiscribeYour(string CustID, string AboutYourself, int? flag, string spName)
        {
            SqlParameter[] parm = new SqlParameter[4];
            SqlDataReader reader;
            string strDesc = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@CustID", SqlDbType.VarChar);
                parm[0].Value = CustID;
                parm[1] = new SqlParameter("@v_AboutYourself", SqlDbType.VarChar);
                parm[1].Value = AboutYourself;
                parm[2] = new SqlParameter("@i_flag", SqlDbType.Int);
                parm[2].Value = flag;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        strDesc = (reader["Describe"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Describe")) : null;
                    }
                }
                reader.Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt64(CustID), null, null);
            }
            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return strDesc;
        }

        public int DUpdateSibblingCounts(SibblingCounts sibcount, string spName)
        {
            int iStatus = 0;
            DataSet ds = new DataSet();
            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[10];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@CustID", SqlDbType.VarChar);
                parm[0].Value = sibcount.CustID;
                parm[1] = new SqlParameter("@NoOfBrothers", SqlDbType.VarChar);
                parm[1].Value = sibcount.NoOfBrothers;
                parm[2] = new SqlParameter("@NoOfSisters", SqlDbType.Int);
                parm[2].Value = sibcount.NoOfSisters;
                parm[3] = new SqlParameter("@NoOfYoungerBrothers", SqlDbType.Int);
                parm[3].Value = sibcount.NoOfYoungerBrothers;
                parm[4] = new SqlParameter("@NoOfElderBrothers", SqlDbType.Int);
                parm[4].Value = sibcount.NoOfElderBrothers;
                parm[5] = new SqlParameter("@NoOfElderSisters", SqlDbType.Int);
                parm[5].Value = sibcount.NoOfElderSisters;
                parm[6] = new SqlParameter("@NoOfYoungerSisters", SqlDbType.Int);
                parm[6].Value = sibcount.NoOfYoungerSisters;
                parm[7] = new SqlParameter("@Status", SqlDbType.Int);
                parm[7].Direction = ParameterDirection.Output;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
                if (string.Compare(parm[7].Value.ToString(), System.DBNull.Value.ToString()) == 0) { iStatus = 0; } else { iStatus = Convert.ToInt32(parm[7].Value); }

            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt64(sibcount.CustID), null, null);
            }
            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return iStatus;
        }
        public ArrayList Savephotosofcustomer(UpdatePersonaldetails savePhoto, string spName)
        {
            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[10];
            SqlDataReader reader;
            Int64? intNull = null;
            int? iNull = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@dtPhotoUpload", SqlDbType.Structured);
                parm[0].Value = savePhoto.dtTableValues;
                parm[1] = new SqlParameter("@CustID", SqlDbType.VarChar);
                parm[1].Value = Convert.ToString(savePhoto.intCusID);
                parm[2] = new SqlParameter("@Empid", SqlDbType.VarChar);
                parm[2].Value = Convert.ToString(savePhoto.EmpID);

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PhotoSectionMl ml = new PhotoSectionMl();
                        ml.Cust_ID = (reader["Cust_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_Id")) : intNull;
                        ml.PhotoName = (reader["PhotoName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoName")) : null;
                        ml.PhotoPassword = (reader["PhotoPassword"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoPassword")) : null;
                        ml.VisibleToID = (reader["VisibleToID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("VisibleToID")) : iNull;
                        ml.DisplayOrder = (reader["DisplayOrder"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("DisplayOrder")) : iNull;
                        ml.UploadedByEmpID = (reader["UploadedByEmpID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("UploadedByEmpID")) : intNull;
                        ml.UploadedDate = (reader["UploadedDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("UploadedDate")) : null;
                        ml.ModifiedDate = (reader["ModifiedDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ModifiedDate")) : null;
                        ml.IsMain = (reader["IsMain"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsMain")) : iNull;
                        ml.IsActive = (reader["IsActive"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsActive")) : iNull;
                        ml.PhotoStatus = (reader["PhotoStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoStatus")) : iNull;
                        ml.AssignedTo = (reader["AssignedTo"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("AssignedTo")) : iNull;
                        ml.AssignedDate = (reader["AssignedDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("AssignedDate")) : null;
                        ml.IsReviewed = (reader["IsReviewed"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsReviewed")) : iNull;
                        ml.ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : null;
                        ml.IsThumbNailCreated = (reader["IsThumbNailCreated"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IsThumbNailCreated")) : iNull;
                        ml.Cust_Photos_ID = (reader["Cust_Photos_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_Photos_ID")) : intNull;
                        ml.strModifiedByEmpID = (reader["ModifiedByEmpID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ModifiedByEmpID")) : null;
                        ml.UploadedBy = (reader["UploadedBy"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("UploadedBy")) : null;
                        arrayList.Add(ml);
                    }
                }
                reader.Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), savePhoto.intCusID, null, null);
                throw EX;
            }
            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return arrayList;
        }

        public int PhotoPassword(long? CustID, int? ipassword, string spName)
        {
            int iStatus = 0;
            DataSet ds = new DataSet();
            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[3];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@CustID", SqlDbType.BigInt);
                parm[0].Value = CustID;
                parm[1] = new SqlParameter("@iPassword", SqlDbType.Int);
                parm[1].Value = ipassword;
                parm[2] = new SqlParameter("@Status", SqlDbType.Int);
                parm[2].Direction = ParameterDirection.Output;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
                if (string.Compare(parm[2].Value.ToString(), System.DBNull.Value.ToString()) == 0) { iStatus = 0; } else { iStatus = Convert.ToInt32(parm[2].Value); }
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
            return iStatus;
        }
        public int AstroDetailsUpdateDelete(AstroUploadDelete astroupdate, string spName)
        {
            int iStatus = 0;
            DataSet ds = new DataSet();
            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[8];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@Cust_ID", SqlDbType.BigInt);
                parm[0].Value = astroupdate.Cust_ID;
                parm[1] = new SqlParameter("@Horopath", SqlDbType.VarChar);
                parm[1].Value = astroupdate.Horopath;
                parm[2] = new SqlParameter("@ModifiedByEmpID", SqlDbType.Int);
                parm[2].Value = astroupdate.ModifiedByEmpID;
                parm[3] = new SqlParameter("@VisibleToID", SqlDbType.Int);
                parm[3].Value = astroupdate.VisibleToID;
                parm[4] = new SqlParameter("@Empid", SqlDbType.Int);
                parm[4].Value = astroupdate.Empid;
                parm[5] = new SqlParameter("@IsActive", SqlDbType.Bit);
                parm[5].Value = astroupdate.IsActive;
                parm[6] = new SqlParameter("@i_flag", SqlDbType.Int);
                parm[6].Value = astroupdate.i_flag;
                parm[7] = new SqlParameter("@Status", SqlDbType.Int);
                parm[7].Direction = ParameterDirection.Output;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
                if (string.Compare(parm[7].Value.ToString(), System.DBNull.Value.ToString()) == 0) { iStatus = 0; } else { iStatus = Convert.ToInt32(parm[7].Value); }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), Convert.ToInt64(astroupdate.Cust_ID), null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return iStatus;
        }
        public List<GenerateHoroML> GeneaterHorosupport(int? customerid, int? CityID)
        {
            SqlParameter[] param = new SqlParameter[3];
            List<GenerateHoroML> lstgeneaterhoro = new List<GenerateHoroML>();
            GenerateHoroML generateHoro = new GenerateHoroML();
            SqlDataReader reader = null;
            int? int32 = null;
            DateTime? iDateTime = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                param[0] = new SqlParameter("@CustID", SqlDbType.BigInt);
                param[0].Value = customerid;
                param[1] = new SqlParameter("@CityID", SqlDbType.Int);
                param[1].Value = CityID;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, "[dbo].[usp_GeneaterHorosupport]", param);
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        generateHoro.CityOfBirthID = reader["CityOfBirthID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CityOfBirthID")) : int32;
                        generateHoro.TimeOfBirth = reader["TimeOfBirth"] != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("TimeOfBirth")) : iDateTime;
                        generateHoro.Longitude = reader["Longitude"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Longitude")) : null;
                        generateHoro.Latitude = reader["Latitude"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Latitude")) : null;
                        generateHoro.GenderID = reader["GenderID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("GenderID")) : int32;
                        generateHoro.strName = reader["NAME"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("NAME")) : null;
                        generateHoro.CityName = reader["CityName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("CityName")) : null;
                    }
                }
                lstgeneaterhoro.Add(generateHoro);
                reader.Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog("[dbo].[usp_GeneaterHorosupport]", Convert.ToString(EX.Message), Convert.ToInt32(customerid), null, null);
            }
            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return lstgeneaterhoro;
        }

        public HoroGeneration GenerateHoroscorpe(int? customerid, string EmpIDQueryString, int? intDay, int? intMonth, int? intYear, int? CityID)
        {
            string accesspathhoro = "~\\access\\Images\\";
            string withouraccesspathhoro = "~\\Images\\";
            string str = null;
            List<GenerateHoroML> li = new List<GenerateHoroML>();
            int? iNULL = null;
            li = GeneaterHorosupport(customerid, CityID);
            DateTime myDate = Convert.ToDateTime((li[0].TimeOfBirth).ToString());
            string strTime = myDate.ToString("HH:mm:ss");

            HoroGeneration horogeneration = new HoroGeneration();

            if (!string.IsNullOrEmpty(li[0].Longitude) && !string.IsNullOrEmpty(li[0].Latitude))
            {
                int ilongitude = Convert.ToInt32((li[0].Longitude).Substring(4, 2));
                int ilatitude = Convert.ToInt32((li[0].Latitude).Substring(3, 2));
                if (ilongitude > 59)
                {
                    li[0].Longitude = (li[0].Longitude).Remove(4, 2).Insert(4, "59");
                }
                if (ilatitude > 59)
                {
                    li[0].Latitude = (li[0].Latitude).Remove(3, 2).Insert(3, "59");
                }
                if (customerid != 0)
                {
                    if (!string.IsNullOrEmpty(li[0].CityName))
                    {
                        string path = customerid + "_HaroscopeImage/";
                        string fullpath = GenerateHoroML.fullpath + path;
                        str = GenerateHoroML.str + customerid +
                                 "</CUSTID><SEX>" + (li[0].GenderID == 1 ? "Male" : "Female") + "</SEX><NAME>" + li[0].strName + "</NAME><DAY>"
                                 + intDay + "</DAY><MONTH>" + intMonth + "</MONTH><YEAR>" + intYear + "</YEAR><TIME24HR>"
                                 + strTime + "</TIME24HR><CORR>1</CORR><PLACE>" + li[0].CityName + "</PLACE><LONG>" + li[0].Longitude
                                 + "</LONG><LAT>" + li[0].Latitude +
                                 "</LAT><LONGDIR>E</LONGDIR><LATDIR>N</LATDIR><TZONE>05.30</TZONE><TZONEDIR>E</TZONEDIR></BIRTHDATA><OPTIONS>"
                                 + "<CHARTSTYLE>0</CHARTSTYLE><LANGUAGE>ENG</LANGUAGE><REPTYPE>LS-SP</REPTYPE><REPDMN>kaakateeya</REPDMN><HSETTINGS>"
                                 + "<AYANAMSA>1</AYANAMSA><DASASYSTEM>1</DASASYSTEM><GULIKATYPE>1</GULIKATYPE><PARYANTHARSTART>0</PARYANTHARSTART>"
                                 + "<PARYANTHAREND>25</PARYANTHAREND><FAVMARPERIOD>50</FAVMARPERIOD><BHAVABALAMETHOD>1</BHAVABALAMETHOD><ADVANCEDOPTION1>"
                                 + "0</ADVANCEDOPTION1><ADVANCEDOPTION2>0</ADVANCEDOPTION2><ADVANCEDOPTION3>0</ADVANCEDOPTION3><ADVANCEDOPTION4>0</ADVANCEDOPTION4>"
                                 + "</HSETTINGS><IMGURL>" + fullpath + "</IMGURL></OPTIONS>"
                                 + "<PARAMS>employee</PARAMS></DATA>";

                        // path = "../../Images/HoroscopeImages/" + customerid + "_HaroscopeImage/" + customerid + "_HaroscopeImage.html";
                        path = ((string.IsNullOrEmpty(EmpIDQueryString) ? "../../Images" : "../Images")) + "/HoroscopeImages/" + customerid + "_HaroscopeImage/" + customerid + "_HaroscopeImage.html";

                        if (EmpIDQueryString != null)
                        {
                            AstroUploadDelete astroupdate = new AstroUploadDelete();
                            astroupdate.Cust_ID = customerid;
                            astroupdate.Horopath = path;
                            astroupdate.ModifiedByEmpID = path.Contains("HaroscopeImage.html") ? 141 : iNULL;
                            astroupdate.VisibleToID = 1;
                            astroupdate.Empid = !string.IsNullOrEmpty(EmpIDQueryString) ? Convert.ToInt32(EmpIDQueryString) : iNULL;
                            astroupdate.IsActive = true;
                            astroupdate.i_flag = 1;
                            AstroDetailsUpdateDelete(astroupdate, "[dbo].[usp_AstroUpload_Delete]");
                        }

                        string strCustDtryName = customerid + "_HaroscopeImage";
                        string FileName = customerid + "_HaroscopeImage.html";

                        string Strpaths3 = (HttpContext.Current.Server.MapPath(withouraccesspathhoro + "HoroscopeImages\\")) + strCustDtryName + "\\" + FileName;

                        // string Strpaths3 = "http:\\e.kaakateeya.com\\access\\Images\\" + "HoroscopeImages\\" + strCustDtryName + "\\" + FileName;

                        //string Strpaths3 = ("http://e.kaakateeya.com/access" + "HoroscopeImages\\")) + strCustDtryName + "\\" + FileName;

                        string Strkeyname = "Images/HoroscopeImages/" + strCustDtryName + "/" + FileName;

                        // string strPath = null;
                        //if (Strpaths3.Contains("http://kaakateeya.com/"))
                        //{
                        //    strPath = Strpaths3.Replace("http://kaakateeya.com/", "http://e.kaakateeya.com/");
                        //}
                        //else
                        //{
                        //    strPath = Strpaths3;
                        //}

                        //if (!string.IsNullOrEmpty(Commonclass.GlobalImgPath))
                        //{
                        //    if (Directory.Exists(path))
                        //    {
                        //        Commonclass.S3upload(Strpaths3, Strkeyname);
                        //    }
                        //}

                        string strHoro = Strkeyname.Replace("/", "\\");
                        string strPath = "C:\\inetpub\\wwwroot\\access\\" + strHoro;
                        string strTestPath = System.IO.Path.Combine(System.Environment.CurrentDirectory, strPath);
                        horogeneration.KeyName = Strkeyname;
                        horogeneration.Path = Strpaths3;
                        horogeneration.AstroGeneration = str;
                        horogeneration.strTestPath = strTestPath;

                    }
                }
            }

            return horogeneration;
        }

        // Employee Pages webApi

        public ArrayList Emplanding_counts_Admin(EmployeeLandingCount employeecount, string strSpName)
        {

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet ds = new DataSet();

            try
            {
                SqlParameter[] parm = new SqlParameter[10];

                parm[0] = new SqlParameter("@owner", SqlDbType.Structured);
                parm[0].Value = employeecount.owner;
                parm[1] = new SqlParameter("@Branch", SqlDbType.Structured);
                parm[1].Value = employeecount.Branch;
                parm[2] = new SqlParameter("@intStartIndex", SqlDbType.Int);
                parm[2].Value = employeecount.StartIndex;
                parm[3] = new SqlParameter("@intEndIndex", SqlDbType.Int);
                parm[3].Value = employeecount.EndIndex;
                parm[4] = new SqlParameter("@strTableType", SqlDbType.VarChar);
                parm[4].Value = employeecount.strTableType;
                parm[5] = new SqlParameter("@intLoadStatus", SqlDbType.Int);
                parm[5].Value = employeecount.intLoadStatus;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, strSpName, parm);
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(strSpName, Convert.ToString(ex.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }

            return Commonclass.convertdataTableToArrayListTable(ds);
        }


        /// <summary>
        /// create Date : 31/08/2017
        /// created By: S.A.Kiran
        /// DES :display Employee landing  tables
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="ID"></param>
        /// <param name="spName"></param>
        /// <returns></returns>
        /// 

        public ArrayList Emplanding_counts_TablesDisplay(EmployeeLandingCount employeecount, string strSpName)
        {
            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[10];
            SqlDataReader reader;

            int? iNull = null;
            Int64? i64null = null;
            bool? ibool = null;

            //DateTime? idate = null;

            Emplanding_counts _EmpAdminCount = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            List<Emplanding_counts> empcount = null;

            try
            {
                parm[0] = new SqlParameter("@owner", SqlDbType.Structured);
                parm[0].Value = employeecount.owner;
                parm[1] = new SqlParameter("@Branch", SqlDbType.Structured);
                parm[1].Value = employeecount.Branch;
                parm[2] = new SqlParameter("@intStartIndex", SqlDbType.Int);
                parm[2].Value = employeecount.StartIndex;
                parm[3] = new SqlParameter("@intEndIndex", SqlDbType.Int);
                parm[3].Value = employeecount.EndIndex;
                parm[4] = new SqlParameter("@strTableType", SqlDbType.VarChar);
                parm[4].Value = employeecount.strTableType;
                parm[5] = new SqlParameter("@intLoadStatus", SqlDbType.Int);
                parm[5].Value = employeecount.intLoadStatus;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, strSpName, parm);

                while (reader.HasRows)
                {
                    empcount = new List<Emplanding_counts>();

                    while (reader.Read())
                    {

                        _EmpAdminCount = new Emplanding_counts();
                        _EmpAdminCount.TableName = (reader["TableName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("TableName")) : null;
                        _EmpAdminCount.Profileid = (reader["Profileid"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Profileid")) : null;
                        _EmpAdminCount.Name = (reader["Name"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Name")) : null;
                        _EmpAdminCount.ServiceCount = (reader["ServiceCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ServiceCount")) : iNull;
                        _EmpAdminCount.Date = (reader["Date"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Date")) : null;
                        _EmpAdminCount.Photo = (reader["Photo"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Photo")) : null;

                        if (_EmpAdminCount.TableName != "No Photos Customers" && _EmpAdminCount.TableName != "Not Yet Verified Contact Details")
                        {
                            _EmpAdminCount.PaidStatus = (reader["PaidStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PaidStatus")) : iNull;
                        }
                        if (_EmpAdminCount.TableName == "Inactive Customers")
                        {
                            _EmpAdminCount.Reason4InActive = (reader["Reason4InActive"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Reason4InActive")) : null;
                        }
                        if (_EmpAdminCount.TableName == "Marketing Tickets Assigned Since 10 Days" || _EmpAdminCount.TableName == "Marketing Ticket Expiry With in Two days")
                        {
                            _EmpAdminCount.Tickets = (reader["Tickets"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Tickets")) : null;
                            _EmpAdminCount.TicketID = (reader["TicketID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("TicketID")) : i64null;

                        }
                        if (_EmpAdminCount.TableName == "No Sa Form For Paid Profiles")
                        {
                            _EmpAdminCount.SAFormStatus = (reader["SAFormStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("SAFormStatus")) : null;
                        }
                        if (_EmpAdminCount.TableName == "Customer Notification Status")
                        {
                            _EmpAdminCount.ReadStatus = (reader["ReadStatus"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("ReadStatus")) : ibool;

                            _EmpAdminCount.NotificationID = (reader["NotificationID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("NotificationID")) : iNull;
                        }

                        empcount.Add(_EmpAdminCount);
                    }

                    arrayList.Add(empcount);
                    reader.NextResult();
                }


                reader.Close();

            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(strSpName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return arrayList;
        }


        public ArrayList CustomerPersonaloffice_purpose(string flag, string ID, string AboutProfile, int? IsConfidential, int? HighConfendential, string strSpname)
        {
            ArrayList arrayList = new ArrayList();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet dtAstrodetails = new DataSet();
            SqlDataAdapter daParentDetails = new SqlDataAdapter();

            try
            {

                SqlCommand cmd = new SqlCommand(strSpname, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@v_dflag", flag);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@AboutProfile", AboutProfile);
                cmd.Parameters.AddWithValue("@IsConfidential", IsConfidential);
                cmd.Parameters.AddWithValue("@HighConfendential", HighConfendential);

                daParentDetails.SelectCommand = cmd;
                daParentDetails.Fill(dtAstrodetails);

            }
            catch (Exception Ex)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(Ex.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }

            return Commonclass.convertdataTableToArrayList(dtAstrodetails);
        }
        public ArrayList CustomerPersonalContact_Details(long? intCusID, string strSpname)
        {

            DataSet dscontactsALL = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            int iStatus = 0;
            try
            {
                SqlParameter[] parm = new SqlParameter[5];
                parm[0] = new SqlParameter("@CustID", SqlDbType.Int);
                parm[0].Value = intCusID;
                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;
                dscontactsALL = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, strSpname, parm);
                if (string.Compare(parm[1].Value.ToString(), System.DBNull.Value.ToString()) == 0)
                {
                    iStatus = 0;
                }
                else
                {
                    iStatus = Convert.ToInt32(parm[1].Value);
                }
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(ex.Message), intCusID, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayList(dscontactsALL);
        }
        public ArrayList CustomerPersonalSpouse_Details(long? intCusID, string strSpname)
        {
            DataSet dssibling = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            int iStatus = 0;
            try
            {

                SqlParameter[] parm = new SqlParameter[5];
                parm[0] = new SqlParameter("@CustomerID", SqlDbType.Int);
                parm[0].Value = intCusID;

                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;
                dssibling = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, strSpname, parm);
                if (string.Compare(parm[1].Value.ToString(), System.DBNull.Value.ToString()) == 0)
                {
                    iStatus = 0;
                }
                else
                {
                    iStatus = Convert.ToInt32(parm[1].Value);
                }
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(ex.Message), intCusID, null, null);
            }
            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayList(dssibling);
        }
        public ArrayList CustomerprofilesettingDetails(long? intCusID, string strSpname)
        {
            DataSet dsprofilesettings = new DataSet();
            int? iStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[5];
                parm[0] = new SqlParameter("@cust_id", SqlDbType.Int);
                parm[0].Value = intCusID;
                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;
                dsprofilesettings = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, strSpname, parm);
                if (string.Compare(parm[1].Value.ToString(), System.DBNull.Value.ToString()) == 0)
                {
                    iStatus = 0;
                }
                else
                {
                    iStatus = Convert.ToInt32(parm[1].Value);
                }
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(ex.Message), intCusID, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayList(dsprofilesettings);
        }

        public int UpdateSpoucedetails_Customersetails(UpdatePersonaldetails Mobjspouce, string strSpname)
        {
            int iStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] parm = new SqlParameter[5];
                parm[0] = new SqlParameter("@CustID", SqlDbType.Int);
                parm[0].Value = Mobjspouce.intCusID;

                parm[1] = new SqlParameter("@dtSpoucedetailsupdate", SqlDbType.Structured);
                parm[1].Value = Mobjspouce.dtTableValues;
                parm[2] = new SqlParameter("@EmpID", SqlDbType.Int);
                parm[2].Value = Mobjspouce.EmpID;
                parm[3] = new SqlParameter("@IsReViewed", SqlDbType.Int);
                parm[3].Value = Mobjspouce.Admin;
                parm[4] = new SqlParameter("@Status", SqlDbType.Int);
                parm[4].Direction = ParameterDirection.Output;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, strSpname, parm);
                if (string.Compare(parm[4].Value.ToString(), System.DBNull.Value.ToString()) == 0)
                {
                    iStatus = 0;
                }
                else
                {
                    iStatus = Convert.ToInt32(parm[4].Value);
                }
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(ex.Message), Mobjspouce.intCusID, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return iStatus;
        }

        public int UpdateSpouseChildDetails(UpdatePersonaldetails customerpersonaldetails, string strSpname)
        {
            int iStatus = 0;

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] parm = new SqlParameter[5];
                parm[0] = new SqlParameter("@CustID", SqlDbType.Int);
                parm[0].Value = customerpersonaldetails.intCusID;

                parm[1] = new SqlParameter("@dtSpouceChilddetails", SqlDbType.Structured);
                parm[1].Value = customerpersonaldetails.dtTableValues;
                parm[2] = new SqlParameter("@EmpID", SqlDbType.Int);
                parm[2].Value = customerpersonaldetails.EmpID;
                parm[3] = new SqlParameter("@IsReViewed", SqlDbType.Int);
                parm[3].Value = customerpersonaldetails.Admin;
                parm[4] = new SqlParameter("@Status", SqlDbType.Int);
                parm[4].Direction = ParameterDirection.Output;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, strSpname, parm);
                if (string.Compare(parm[4].Value.ToString(), System.DBNull.Value.ToString()) == 0)
                {
                    iStatus = 0;
                }
                else
                {
                    iStatus = Convert.ToInt32(parm[4].Value);
                }
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(ex.Message), customerpersonaldetails.intCusID, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return iStatus;
        }
        public int CustomerContactDetails_Update(ContactDetals mobCandidateContact, string strSpname)
        {
            int iStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] parm = new SqlParameter[31];
                parm[0] = new SqlParameter("@CustID", SqlDbType.Int);
                parm[0].Value = mobCandidateContact.intCusID;
                parm[1] = new SqlParameter("@EmpID", SqlDbType.Int);
                parm[1].Value = mobCandidateContact.EmpID;
                parm[2] = new SqlParameter("@IsReViewed", SqlDbType.Int);
                parm[2].Value = mobCandidateContact.Admin;
                parm[3] = new SqlParameter("@custfamiliyid", SqlDbType.Int);
                parm[3].Value = mobCandidateContact.familyID;
                parm[4] = new SqlParameter("@MoblieCountryCode", SqlDbType.Int);
                parm[4].Value = mobCandidateContact.MoblieCountryCode;
                parm[5] = new SqlParameter("@MobileNumber", SqlDbType.BigInt);
                parm[5].Value = mobCandidateContact.MobileNumber;
                parm[6] = new SqlParameter("@LandCountryCode", SqlDbType.Int);
                parm[6].Value = mobCandidateContact.LandCountryCode;
                parm[7] = new SqlParameter("@LandAreaCode", SqlDbType.BigInt);
                parm[7].Value = mobCandidateContact.LandAreaCode;
                parm[8] = new SqlParameter("@LandNumber", SqlDbType.BigInt);
                parm[8].Value = mobCandidateContact.LandNumber;
                parm[9] = new SqlParameter("@Email", SqlDbType.VarChar);
                parm[9].Value = mobCandidateContact.Email;
                parm[10] = new SqlParameter("@Name", SqlDbType.VarChar);
                parm[10].Value = mobCandidateContact.Name;
                parm[11] = new SqlParameter("@CandidateAddressID", SqlDbType.VarChar);
                parm[11].Value = mobCandidateContact.CandidateAddressID;
                parm[12] = new SqlParameter("@HouseFlatNum", SqlDbType.VarChar);
                parm[12].Value = mobCandidateContact.HouseFlatNum;
                parm[13] = new SqlParameter("@Apartmentname", SqlDbType.VarChar);
                parm[13].Value = mobCandidateContact.Apartmentname;
                parm[14] = new SqlParameter("@Streetname", SqlDbType.VarChar);
                parm[14].Value = mobCandidateContact.Streetname;
                parm[15] = new SqlParameter("@AreaName", SqlDbType.VarChar);
                parm[15].Value = mobCandidateContact.AreaName;
                parm[16] = new SqlParameter("@Landmark", SqlDbType.VarChar);
                parm[16].Value = mobCandidateContact.Landmark;
                parm[17] = new SqlParameter("@Country", SqlDbType.Int);
                parm[17].Value = mobCandidateContact.Country;
                parm[18] = new SqlParameter("@State", SqlDbType.Int);
                parm[18].Value = mobCandidateContact.State;
                parm[19] = new SqlParameter("@District", SqlDbType.Int);
                parm[19].Value = mobCandidateContact.District;
                parm[20] = new SqlParameter("@City", SqlDbType.VarChar);
                parm[20].Value = mobCandidateContact.City;
                parm[21] = new SqlParameter("@ZipPin", SqlDbType.BigInt);
                parm[21].Value = mobCandidateContact.ZipPin;
                parm[22] = new SqlParameter("@addresstype", SqlDbType.Int);
                parm[22].Value = mobCandidateContact.addresstype;
                parm[23] = new SqlParameter("@Status", SqlDbType.Int);
                parm[23].Direction = ParameterDirection.Output;
                parm[24] = new SqlParameter("@spouseflag", SqlDbType.VarChar);
                parm[24].Value = mobCandidateContact.SibblingFlag;

                parm[25] = new SqlParameter("@FatherMobileCountryID", SqlDbType.Int);
                parm[25].Value = mobCandidateContact.FFMobileCountryID;
                parm[26] = new SqlParameter("@FatherMobileNumber", SqlDbType.BigInt);
                parm[26].Value = mobCandidateContact.FFMobileNumber;
                parm[27] = new SqlParameter("@FarherLandLineCountryCodeID", SqlDbType.Int);
                parm[27].Value = mobCandidateContact.FFLandLineCountryCodeID;
                parm[28] = new SqlParameter("@FatherLandAreaCode", SqlDbType.BigInt);
                parm[28].Value = mobCandidateContact.FFLandAreaCode;
                parm[29] = new SqlParameter("@FatherLandNumber", SqlDbType.BigInt);
                parm[29].Value = mobCandidateContact.FFLandNumber;
                parm[30] = new SqlParameter("@iflagFF", SqlDbType.Int);
                parm[30].Value = mobCandidateContact.iflagFF;

                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, strSpname, parm);

                if (string.Compare(parm[23].Value.ToString(), System.DBNull.Value.ToString()) == 0)
                {
                    iStatus = 0;
                }
                else
                {
                    iStatus = Convert.ToInt32(parm[23].Value);
                }
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(ex.Message), mobCandidateContact.intCusID, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }

            return iStatus;
        }
        public int CustomerProfileSetting_ProfileSetting(UpdateprofileeMl mobjprofile, string strSpname)
        {
            int iStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] parm = new SqlParameter[14];
                parm[0] = new SqlParameter("@CustID", SqlDbType.Int);
                parm[0].Value = mobjprofile.intCusID;

                parm[1] = new SqlParameter("@EmpID", SqlDbType.BigInt);
                parm[1].Value = mobjprofile.EmpID;

                parm[2] = new SqlParameter("@currentprofilestatusid", SqlDbType.Int);
                parm[2].Value = mobjprofile.currentprofilestatusid;

                parm[3] = new SqlParameter("@profilegrade", SqlDbType.Int);
                parm[3].Value = mobjprofile.profilegrade;

                parm[4] = new SqlParameter("@NoofDaysinactivated", SqlDbType.Int);
                parm[4].Value = mobjprofile.NoofDaysinactivated;

                parm[5] = new SqlParameter("@Reason4InActive", SqlDbType.VarChar);
                parm[5].Value = mobjprofile.Reason4InActive;

                parm[6] = new SqlParameter("@RequestedBy", SqlDbType.Int);
                parm[6].Value = mobjprofile.RequestedBy;

                parm[7] = new SqlParameter("@TypeofReport", SqlDbType.VarChar);
                parm[7].Value = mobjprofile.TypeofReport;

                parm[8] = new SqlParameter("@ProfileDisplayName", SqlDbType.Int);
                parm[8].Value = mobjprofile.ProfileDisplayName;

                parm[9] = new SqlParameter("@LoginStatusName", SqlDbType.Int);
                parm[9].Value = mobjprofile.LoginStatusName;
                parm[10] = new SqlParameter("@Admin", SqlDbType.BigInt);
                parm[10].Value = mobjprofile.Admin;
                parm[11] = new SqlParameter("@ProfileBlockReason", SqlDbType.VarChar);
                parm[11].Value = mobjprofile.Blockedreason;
                parm[12] = new SqlParameter("@Status", SqlDbType.Int);
                parm[12].Direction = ParameterDirection.Output;

                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, strSpname, parm);
                if (string.Compare(parm[12].Value.ToString(), System.DBNull.Value.ToString()) == 0)
                {
                    iStatus = 0;
                }
                else
                {
                    iStatus = Convert.ToInt32(parm[12].Value);
                }
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(ex.Message), mobjprofile.intCusID, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return iStatus;
        }
        public int CustomerProfileSetting_Gradeselection(NoProfileGradingMl Mobj, string strSpname)
        {
            int status = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dsSet = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_InsertProfileGrading", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustId", Mobj.CustID);
                cmd.Parameters.AddWithValue("@EmpID", Mobj.EmpID);
                cmd.Parameters.AddWithValue("@GFamily", Mobj.GFamily);
                cmd.Parameters.AddWithValue("@GPhotos", Mobj.GPhotos);
                cmd.Parameters.AddWithValue("@GEducation", Mobj.GEducation);
                cmd.Parameters.AddWithValue("@GProfession", Mobj.GProfession);
                cmd.Parameters.AddWithValue("@GProperty", Mobj.GProperty);
                SqlParameter outputParamStatus = cmd.Parameters.Add("@Status", SqlDbType.Int);
                outputParamStatus.Direction = ParameterDirection.Output;
                da.SelectCommand = cmd;
                da.Fill(dsSet);
                if (Convert.ToInt32(cmd.Parameters[7].Value) == 1)
                {
                    status = 1;
                }
                else
                {
                    status = 0;
                }
                SQLHelper.GetSQLConnection().Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(EX.Message), Mobj.CustID, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return status;
        }
        public int UpdatePersonalDetails_Customersetails(UpdatePersonaldetails mobjpersonal, string strSpname)
        {
            int iStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] parm = new SqlParameter[5];
                parm[0] = new SqlParameter("@CustID", SqlDbType.Int);
                parm[0].Value = mobjpersonal.intCusID;
                parm[1] = new SqlParameter("@dtpersonalDetails", SqlDbType.Structured);
                parm[1].Value = mobjpersonal.dtTableValues;
                parm[2] = new SqlParameter("@EmpID", SqlDbType.Int);
                parm[2].Value = mobjpersonal.EmpID;
                parm[3] = new SqlParameter("@IsReViewed", SqlDbType.Int);
                parm[3].Value = mobjpersonal.Admin;
                parm[4] = new SqlParameter("@Status", SqlDbType.Int);
                parm[4].Direction = ParameterDirection.Output;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, strSpname, parm);

                if (string.Compare(parm[4].Value.ToString(), System.DBNull.Value.ToString()) == 0)
                {
                    iStatus = 0;
                }
                else
                {
                    iStatus = Convert.ToInt32(parm[4].Value);
                }
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(ex.Message), mobjpersonal.intCusID, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return iStatus;
        }

        public NoDataFoundDisplay NoDataInformationLinkDisplay(string ProfileID, string strSpname)
        {
            string strval = string.Empty;
            NoDataFoundDisplay nodata = new NoDataFoundDisplay();
            int? inull = null;
            SqlDataReader reader;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[2];
                parm[0] = new SqlParameter("@ProfileID", SqlDbType.VarChar);
                parm[0].Value = ProfileID;


                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, strSpname, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        nodata.ProfileID = reader["ProfileID"] != DBNull.Value ? reader["ProfileID"].ToString() : null;
                        nodata.CustID = reader["CustID"] != DBNull.Value ? reader["CustID"].ToString() : null;
                        nodata.iCustomerPersonalDetails = reader["CustomerPersonalDetails"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CustomerPersonalDetails")) : inull;
                        nodata.iManagePhoto = reader["ManagePhoto"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ManagePhoto")) : inull;
                        nodata.iParentDetails = reader["ParentDetails"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ParentDetails")) : inull;
                        nodata.iPartnerPreference = reader["PartnerPreference"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PartnerPreference")) : inull;
                        nodata.iSiblingDetails = reader["SiblingDetails"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("SiblingDetails")) : inull;
                        nodata.iAstroDetails = reader["AstroDetails"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("AstroDetails")) : inull;
                        nodata.iPropertyDetails = reader["PropertyDetails"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PropertyDetails")) : inull;
                        nodata.iRelativeDetails = reader["RelativeDetails"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("RelativeDetails")) : inull;
                        nodata.iReferenceDetails = reader["ReferenceDetails"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ReferenceDetails")) : inull;
                        nodata.LoginStatusID = reader["LoginStatusID"] != DBNull.Value ? reader["LoginStatusID"].ToString() : null;
                    }
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(EX.Message), Convert.ToInt64(ProfileID), null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return nodata;
        }

        public int CustomerSectionsDeletions(string sectioname, long? CustID, long? identityid, string strSpname)
        {
            DataSet dsprofilesettings = new DataSet();
            int iStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                SqlParameter[] parm = new SqlParameter[5];
                parm[0] = new SqlParameter("@sectioname", SqlDbType.VarChar);
                parm[0].Value = sectioname;
                parm[1] = new SqlParameter("@CustID", SqlDbType.BigInt);
                parm[1].Value = CustID;
                parm[2] = new SqlParameter("@identityid", SqlDbType.BigInt);
                parm[2].Value = identityid;
                parm[3] = new SqlParameter("@Status", SqlDbType.Int);
                parm[3].Direction = ParameterDirection.Output;
                dsprofilesettings = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, strSpname, parm);
                if (string.Compare(parm[3].Value.ToString(), System.DBNull.Value.ToString()) == 0)
                {
                    iStatus = 0;
                }
                else
                {
                    iStatus = Convert.ToInt32(parm[3].Value);
                }
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(ex.Message), CustID, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return iStatus;
        }

        public int UpdateContactdetails_Reference(ContactdetailsRef Mobj, string strSpname)
        {
            DataSet dsprofilesettings = new DataSet();
            int iStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                SqlParameter[] parm = new SqlParameter[14];
                parm[0] = new SqlParameter("@Cust_Reference_ID", SqlDbType.BigInt);
                parm[0].Value = Mobj.Cust_Reference_ID;
                parm[1] = new SqlParameter("@Cust_ID", SqlDbType.BigInt);
                parm[1].Value = Mobj.Cust_ID;
                parm[2] = new SqlParameter("@FirstName", SqlDbType.VarChar);
                parm[2].Value = Mobj.FirstName;
                parm[3] = new SqlParameter("@MobileCode", SqlDbType.VarChar);
                parm[3].Value = Mobj.MobileCode;
                parm[4] = new SqlParameter("@Number", SqlDbType.VarChar);
                parm[4].Value = Mobj.Number;
                parm[5] = new SqlParameter("@CountryCode", SqlDbType.VarChar);
                parm[5].Value = Mobj.CountryCode;
                parm[6] = new SqlParameter("@AreaCode", SqlDbType.VarChar);
                parm[6].Value = Mobj.AreaCode;
                parm[7] = new SqlParameter("@Landlinenumber", SqlDbType.VarChar);
                parm[7].Value = Mobj.Landlinenumber;
                parm[8] = new SqlParameter("@Email", SqlDbType.VarChar);
                parm[8].Value = Mobj.Email;
                parm[9] = new SqlParameter("@Status", SqlDbType.Int);
                parm[9].Direction = ParameterDirection.Output;
                dsprofilesettings = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, strSpname, parm);

                if (string.Compare(parm[9].Value.ToString(), System.DBNull.Value.ToString()) == 0)
                {
                    iStatus = 0;
                }
                else
                {
                    iStatus = Convert.ToInt32(parm[9].Value);
                }
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(ex.Message), Mobj.Cust_ID, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return iStatus;
        }

        public ArrayList personaldetails_Customer(long? CustID, string strSpname)
        {
            DataSet dspersonal = new DataSet();
            SqlDataAdapter daParentDetails = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                SqlParameter[] parm = new SqlParameter[5];
                parm[0] = new SqlParameter("@cust_Id", SqlDbType.Int);
                parm[0].Value = CustID;
                dspersonal = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, strSpname, parm);

            }
            catch (Exception Ex)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(Ex.Message), CustID, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayList(dspersonal);
        }

        public ArrayList ViewAllCustomersSearch(int? intEmpID, string strSearchData, string profileStatus, int? StartIndex, int? EndIndex, string spName)
        {
            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[10];
            SqlDataReader reader;
            Int64? intNull = null;
            int? iNull = null;

            ViewAllCustomersSearchnew MobjPersonalsML = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parm[0].Value = intEmpID;
                parm[1] = new SqlParameter("@SearchData", SqlDbType.VarChar);
                parm[1].Value = strSearchData;
                parm[2] = new SqlParameter("@profileStatus", SqlDbType.VarChar);
                parm[2].Value = profileStatus;
                parm[3] = new SqlParameter("@intStartIndex", SqlDbType.Int);
                parm[3].Value = StartIndex;
                parm[4] = new SqlParameter("@intEndIndex", SqlDbType.Int);
                parm[4].Value = EndIndex;
                parm[5] = new SqlParameter("@Status", SqlDbType.Int);
                parm[5].Direction = ParameterDirection.Output;
                parm[6] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
                parm[6].Direction = ParameterDirection.Output;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MobjPersonalsML = new ViewAllCustomersSearchnew();
                        MobjPersonalsML.CustID = (reader["CustID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("CustID")) : intNull;
                        MobjPersonalsML.FirstName = (reader["FirstName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FirstName")) : null;
                        MobjPersonalsML.LastName = (reader["LastName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("LastName")) : null;
                        MobjPersonalsML.CasteName = (reader["CasteName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CasteName")) : null;
                        MobjPersonalsML.ProfileOwner = (reader["ProfileOwner"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileOwner")) : null;
                        MobjPersonalsML.Height = (reader["Height"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Height")) : null;
                        MobjPersonalsML.LoginStatus = (reader["LoginStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("LoginStatus")) : null;
                        MobjPersonalsML.educationgroup = (reader["educationgroup"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("educationgroup")) : null;
                        MobjPersonalsML.Age = (reader["Age"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Age")) : null;
                        MobjPersonalsML.GenderID = (reader["GenderID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("GenderID")) : iNull;
                        MobjPersonalsML.ProfileStatusID = (reader["ProfileStatusID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProfileStatusID")) : iNull;
                        MobjPersonalsML.Confidential = (reader["Confidential"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Confidential")) : null;
                        MobjPersonalsML.ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : null;
                        MobjPersonalsML.TotalRows = (reader["TotalRows"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TotalRows")) : iNull;
                        MobjPersonalsML.Totalpages = (reader["Totalpages"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Totalpages")) : iNull;
                        MobjPersonalsML.Profession = (reader["Profession"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Profession")) : null;
                        arrayList.Add(MobjPersonalsML);
                    }

                }
                reader.Close();

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
            return arrayList;

        }

        public ArrayList ViewAllCustomersKMPLProfileID(int? EmpID, string SearchData, string spName)
        {
            DataSet dsCustomerList = new DataSet();
            int intStatus = 0;
            string strErrorMsg = string.Empty;
            SqlParameter[] parm = new SqlParameter[5];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parm[0].Value = EmpID;
                parm[1] = new SqlParameter("@SearchData", SqlDbType.VarChar);
                parm[1].Value = SearchData;
                parm[2] = new SqlParameter("@Status", SqlDbType.Int);
                parm[2].Direction = ParameterDirection.Output;
                parm[3] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
                parm[3].Direction = ParameterDirection.Output;

                dsCustomerList = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
                if (string.Compare(parm[2].Value.ToString(), System.DBNull.Value.ToString()) == 0)
                {
                    intStatus = 0;
                }
                else { intStatus = Convert.ToInt32(parm[2].Value); }
                if (string.Compare(parm[2].Value.ToString(), System.DBNull.Value.ToString()) == 0) { strErrorMsg = ""; }
                else { strErrorMsg = parm[3].Value.ToString(); }
            }
            catch (Exception Ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(Ex.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayList(dsCustomerList);

        }

        public ArrayList CustomerPersonalMenuReview(long? CustID, int? iReview, string SectionID, string strSpname)
        {
            ArrayList arrayList = new ArrayList();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet dtAstrodetails = new DataSet();
            SqlDataAdapter daParentDetails = new SqlDataAdapter();
            try
            {
                SqlCommand cmd = new SqlCommand(strSpname, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Custid", CustID);
                cmd.Parameters.AddWithValue("@iReview", iReview);
                cmd.Parameters.AddWithValue("@SectionID", SectionID);
                daParentDetails.SelectCommand = cmd;
                daParentDetails.Fill(dtAstrodetails);

            }
            catch (Exception Ex)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(Ex.Message), CustID, null, null);
            }
            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }

            return Commonclass.convertdataTableToArrayList(dtAstrodetails);
        }

        public ArrayList Search_ViewEditProfile(ViewEditProfileSearch Mobj, string spName)
        {

            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[12];
            SqlDataReader reader;
            Int64? intNull = null;
            int? iNull = null;
            long? iLong = null;
            string empty = "--";
            ViewAllCustomersSearch MobjPersonalsML = null;
            ViewAllCustomersSearchtable MobjPersonalstable = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@strFName", SqlDbType.VarChar);
                parm[0].Value = Mobj.strFName;
                parm[1] = new SqlParameter("@strSurName", SqlDbType.VarChar);
                parm[1].Value = Mobj.strSurName;
                parm[2] = new SqlParameter("@strProfileID", SqlDbType.VarChar);
                parm[2].Value = Mobj.strProfileID;
                parm[3] = new SqlParameter("@strKMMLID", SqlDbType.VarChar);
                parm[3].Value = Mobj.strKMMLID;
                parm[4] = new SqlParameter("@intEmpID", SqlDbType.Int);
                parm[4].Value = Mobj.intEmpID;
                parm[5] = new SqlParameter("@profileStatus", SqlDbType.VarChar);
                parm[5].Value = Mobj.profileStatus;
                parm[6] = new SqlParameter("@isSlide", SqlDbType.Bit);
                parm[6].Value = Mobj.isSlide;
                parm[7] = new SqlParameter("@intGender", SqlDbType.Int);
                parm[7].Value = Mobj.genderID;
                parm[8] = new SqlParameter("@intStartIndex", SqlDbType.Int);
                parm[8].Value = Mobj.intStartIndex;
                parm[9] = new SqlParameter("@intEndIndex", SqlDbType.Int);
                parm[9].Value = Mobj.intEndIndex;
                parm[10] = new SqlParameter("@Status", SqlDbType.Int);
                parm[10].Direction = ParameterDirection.Output;
                parm[11] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
                parm[11].Direction = ParameterDirection.Output;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (Mobj.isSlide == false)
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            MobjPersonalstable = new ViewAllCustomersSearchtable();
                            MobjPersonalstable.CustID = (reader["CustID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("CustID")) : intNull;
                            MobjPersonalstable.FirstName = (reader["FirstName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FirstName")) : null;
                            MobjPersonalstable.LastName = (reader["LastName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("LastName")) : null;
                            MobjPersonalstable.CasteName = (reader["CasteName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CasteName")) : null;
                            MobjPersonalstable.ProfileOwner = (reader["ProfileOwner"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileOwner")) : null;
                            MobjPersonalstable.Height = (reader["Height"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Height")) : null;
                            MobjPersonalstable.LoginStatus = (reader["LoginStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("LoginStatus")) : null;
                            MobjPersonalstable.educationgroup = (reader["educationgroup"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("educationgroup")) : null;
                            MobjPersonalstable.Age = (reader["Age"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Age")) : null;
                            MobjPersonalstable.GenderID = (reader["GenderID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("GenderID")) : iNull;
                            MobjPersonalstable.ProfileStatusID = (reader["ProfileStatusID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProfileStatusID")) : iNull;
                            MobjPersonalstable.Confidential = (reader["Confidential"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Confidential")) : null;
                            MobjPersonalstable.ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : null;
                            MobjPersonalstable.TotalRows = (reader["TotalRows"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TotalRows")) : iNull;
                            MobjPersonalstable.Profession = (reader["Profession"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Profession")) : null;
                            MobjPersonalstable.PaidSatus = (reader["PaidSatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PaidSatus")) : iNull;
                            MobjPersonalstable.ProfileOwnerID = (reader["ProfileOwnerID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ProfileOwnerID")) : intNull;
                            arrayList.Add(MobjPersonalstable);

                        }
                    }
                }

                else
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            MobjPersonalsML = new ViewAllCustomersSearch();

                            MobjPersonalsML.Cust_ID = (reader["Cust_ID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Cust_ID")) : empty;
                            MobjPersonalsML.ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : empty;
                            MobjPersonalsML.KMPLID = (reader["KMPLID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("KMPLID")) : empty;
                            MobjPersonalsML.paid = (reader["paid"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("paid")) : iNull;
                            MobjPersonalsML.IsConfidential = (reader["IsConfidential"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("IsConfidential")) : false;
                            MobjPersonalsML.SuperConfidentila = (reader["SuperConfidentila"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("SuperConfidentila")) : false;
                            MobjPersonalsML.FirstName = (reader["FirstName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FirstName")) : empty;
                            MobjPersonalsML.LastName = (reader["LastName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("LastName")) : empty;
                            MobjPersonalsML.Caste = (reader["Caste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Caste")) : empty;
                            MobjPersonalsML.ProfileGrade = (reader["ProfileGrade"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProfileGrade")) : iNull;
                            MobjPersonalsML.TotalRows = (reader["TotalRows"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TotalRows")) : iNull;
                            MobjPersonalsML.SRCount = (reader["SRCount"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("SRCount")) : empty;
                            MobjPersonalsML.ExpiryDate = (reader["ExpiryDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ExpiryDate")) : empty;
                            MobjPersonalsML.Points = (reader["Points"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Points")) : empty;
                            MobjPersonalsML.CNumberVerStatus = (reader["CNumberVerStatus"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("CNumberVerStatus")) : false;
                            MobjPersonalsML.CEmailVerStatus = (reader["CEmailVerStatus"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("CEmailVerStatus")) : false;
                            MobjPersonalsML.SAForm = (reader["SAForm"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("SAForm")) : empty;
                            MobjPersonalsML.TicketID = (reader["TicketID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("TicketID")) : empty;
                            MobjPersonalsML.MatchMeetingCount = (reader["MatchMeetingCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("MatchMeetingCount")) : iNull;
                            MobjPersonalsML.CountryCodeID = (reader["CountryCodeID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CountryCodeID")) : iNull;
                            MobjPersonalsML.Reason4InActive = (reader["Reason4InActive"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Reason4InActive")) : empty;
                            MobjPersonalsML.mothertongue = (reader["MotherTongue"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MotherTongue")) : empty;
                            MobjPersonalsML.PhotoCount = (reader["PhotoCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoCount")) : iNull;
                            MobjPersonalsML.CreatedDate = (reader["CreatedDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CreatedDate")) : empty;
                            MobjPersonalsML.Cust_Family_ID = (reader["Cust_Family_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_Family_ID")) : iLong;
                            MobjPersonalsML.Gender = (reader["Gender"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Gender")) : empty;
                            MobjPersonalsML.SubCaste = (reader["SubCaste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("SubCaste")) : empty;
                            MobjPersonalsML.Photo = (reader["Photo"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Photo")) : empty;
                            MobjPersonalsML.PhotoNames = (reader["PhotoNames"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoNames")) : empty;
                            MobjPersonalsML.Ownerflag = (reader["Ownerflag"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("Ownerflag")) : false;
                            MobjPersonalsML.DOR = MobjPersonalsML.RegistrationDate = (reader["DOR"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("DOR")) : empty;
                            MobjPersonalsML.UploadedPhotoscount = (reader["UploadedPhotoscount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("UploadedPhotoscount")) : iNull;
                            MobjPersonalsML.PhotoshopCount = (reader["PhotoshopCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoshopCount")) : iNull;
                            MobjPersonalsML.OwnerName = (reader["OwnerName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("OwnerName")) : empty;
                            MobjPersonalsML.HoroscopeStatus = (reader["HoroscopeStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("HoroscopeStatus")) : iNull;
                            MobjPersonalsML.Emp_Ticket_ID = (reader["Emp_Ticket_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Emp_Ticket_ID")) : iLong;
                            MobjPersonalsML.ProfileOwnername = (reader["ProfileOwnername"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileOwnername")) : empty;
                            MobjPersonalsML.EmpUserName = (reader["EmpUserName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EmpUserName")) : empty;
                            MobjPersonalsML.Primaryemail = (reader["Primaryemail"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Primaryemail")) : empty;
                            MobjPersonalsML.Primarynumber = (reader["Primarynumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Primarynumber")) : empty;
                            MobjPersonalsML.HoroScopeImage = (reader["HoroScope"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("HoroScope")) : empty;
                            MobjPersonalsML.ApplicationPhotoPath = (reader["ApplicationPhotoPath"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ApplicationPhotoPath")) : empty;
                            MobjPersonalsML.LastLoginDate = (reader["LastLoginDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("LastLoginDate")) : empty;
                            MobjPersonalsML.PaidAmount = (reader["PaidAmount"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PaidAmount")) : empty;
                            arrayList.Add(MobjPersonalsML);
                        }
                    }
                }
                reader.Close();
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
            return arrayList;

        }
        //public ArrayList Search_ViewEditProfile(ViewEditProfileSearch Mobj, string spName)
        //{

        //    ArrayList arrayList = new ArrayList();
        //    SqlParameter[] parm = new SqlParameter[12];
        //    SqlDataReader reader;
        //    Int64? intNull = null;
        //    int? iNull = null;
        //    long? iLong = null;
        //    string empty = "--";
        //    ViewAllCustomersSearch MobjPersonalsML = null;
        //    SqlConnection connection = new SqlConnection();
        //    connection = SQLHelper.GetSQLConnection();
        //    connection.Open();

        //    try
        //    {
        //        parm[0] = new SqlParameter("@strFName", SqlDbType.VarChar);
        //        parm[0].Value = Mobj.strFName;
        //        parm[1] = new SqlParameter("@strSurName", SqlDbType.VarChar);
        //        parm[1].Value = Mobj.strSurName;
        //        parm[2] = new SqlParameter("@strProfileID", SqlDbType.VarChar);
        //        parm[2].Value = Mobj.strProfileID;
        //        parm[3] = new SqlParameter("@strKMMLID", SqlDbType.VarChar);
        //        parm[3].Value = Mobj.strKMMLID;
        //        parm[4] = new SqlParameter("@intEmpID", SqlDbType.Int);
        //        parm[4].Value = Mobj.intEmpID;
        //        parm[5] = new SqlParameter("@profileStatus", SqlDbType.VarChar);
        //        parm[5].Value = Mobj.profileStatus;
        //        parm[6] = new SqlParameter("@isSlide", SqlDbType.Bit);
        //        parm[6].Value = Mobj.isSlide;
        //        parm[7] = new SqlParameter("@intGender", SqlDbType.Int);
        //        parm[7].Value = Mobj.genderID;
        //        parm[8] = new SqlParameter("@intStartIndex", SqlDbType.Int);
        //        parm[8].Value = Mobj.intStartIndex;
        //        parm[9] = new SqlParameter("@intEndIndex", SqlDbType.Int);
        //        parm[9].Value = Mobj.intEndIndex;
        //        parm[10] = new SqlParameter("@Status", SqlDbType.Int);
        //        parm[10].Direction = ParameterDirection.Output;
        //        parm[11] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
        //        parm[11].Direction = ParameterDirection.Output;

        //        reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);

        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                MobjPersonalsML = new ViewAllCustomersSearch();
        //                if (Mobj.isSlide == false)
        //                {
        //                    MobjPersonalsML.CustID = (reader["CustID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("CustID")) : intNull;
        //                    MobjPersonalsML.FirstName = (reader["FirstName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FirstName")) : null;
        //                    MobjPersonalsML.LastName = (reader["LastName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("LastName")) : null;
        //                    MobjPersonalsML.CasteName = (reader["CasteName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CasteName")) : null;
        //                    MobjPersonalsML.ProfileOwner = (reader["ProfileOwner"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileOwner")) : null;
        //                    MobjPersonalsML.Height = (reader["Height"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Height")) : null;
        //                    MobjPersonalsML.LoginStatus = (reader["LoginStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("LoginStatus")) : null;
        //                    MobjPersonalsML.educationgroup = (reader["educationgroup"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("educationgroup")) : null;
        //                    MobjPersonalsML.Age = (reader["Age"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Age")) : null;
        //                    MobjPersonalsML.GenderID = (reader["GenderID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("GenderID")) : iNull;
        //                    MobjPersonalsML.ProfileStatusID = (reader["ProfileStatusID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProfileStatusID")) : iNull;
        //                    MobjPersonalsML.Confidential = (reader["Confidential"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Confidential")) : null;
        //                    MobjPersonalsML.ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : null;
        //                    MobjPersonalsML.TotalRows = (reader["TotalRows"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TotalRows")) : iNull;
        //                    MobjPersonalsML.Totalpages = (reader["Totalpages"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Totalpages")) : iNull;
        //                    MobjPersonalsML.Profession = (reader["Profession"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Profession")) : null;
        //                    MobjPersonalsML.PaidSatus = (reader["PaidSatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PaidSatus")) : iNull;
        //                    MobjPersonalsML.ProfileOwnerID = (reader["ProfileOwnerID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ProfileOwnerID")) : intNull;
        //                }
        //                //slideData
        //                else
        //                {
        //                    MobjPersonalsML.Cust_ID = (reader["Cust_ID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Cust_ID")) : empty;
        //                    MobjPersonalsML.ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : empty;
        //                    MobjPersonalsML.KMPLID = (reader["KMPLID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("KMPLID")) : empty;
        //                    MobjPersonalsML.paid = (reader["paid"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("paid")) : iNull;
        //                    MobjPersonalsML.IsConfidential = (reader["IsConfidential"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("IsConfidential")) : false;
        //                    MobjPersonalsML.SuperConfidentila = (reader["SuperConfidentila"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("SuperConfidentila")) : false;
        //                    MobjPersonalsML.FirstName = (reader["FirstName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FirstName")) : empty;
        //                    MobjPersonalsML.LastName = (reader["LastName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("LastName")) : empty;
        //                    MobjPersonalsML.Caste = (reader["Caste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Caste")) : empty;
        //                    MobjPersonalsML.ProfileGrade = (reader["ProfileGrade"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProfileGrade")) : iNull;
        //                    MobjPersonalsML.TotalRows = (reader["TotalRows"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TotalRows")) : iNull;
        //                    MobjPersonalsML.Totalpages = (reader["Totalpages"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Totalpages")) : iNull;
        //                    MobjPersonalsML.SRCount = (reader["SRCount"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("SRCount")) : empty;
        //                    MobjPersonalsML.ExpiryDate = (reader["ExpiryDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ExpiryDate")) : empty;
        //                    MobjPersonalsML.Points = (reader["Points"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Points")) : empty;
        //                    MobjPersonalsML.CNumberVerStatus = (reader["CNumberVerStatus"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("CNumberVerStatus")) : false;
        //                    MobjPersonalsML.CEmailVerStatus = (reader["CEmailVerStatus"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("CEmailVerStatus")) : false;
        //                    MobjPersonalsML.SAForm = (reader["SAForm"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("SAForm")) : empty;
        //                    MobjPersonalsML.TicketID = (reader["TicketID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("TicketID")) : empty;
        //                    MobjPersonalsML.MatchMeetingCount = (reader["MatchMeetingCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("MatchMeetingCount")) : iNull;
        //                    MobjPersonalsML.CountryCodeID = (reader["CountryCodeID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CountryCodeID")) : iNull;
        //                    MobjPersonalsML.Reason4InActive = (reader["Reason4InActive"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Reason4InActive")) : empty;
        //                    MobjPersonalsML.mothertongue = (reader["MotherTongue"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MotherTongue")) : empty;
        //                    MobjPersonalsML.PhotoCount = (reader["PhotoCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoCount")) : iNull;
        //                    MobjPersonalsML.CreatedDate = (reader["CreatedDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CreatedDate")) : empty;
        //                    MobjPersonalsML.Cust_Family_ID = (reader["Cust_Family_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_Family_ID")) : iLong;
        //                    MobjPersonalsML.Gender = (reader["Gender"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Gender")) : empty;
        //                    MobjPersonalsML.SubCaste = (reader["SubCaste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("SubCaste")) : empty;
        //                    MobjPersonalsML.Photo = (reader["Photo"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Photo")) : empty;
        //                    MobjPersonalsML.PhotoNames = (reader["PhotoNames"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoNames")) : empty;
        //                    MobjPersonalsML.Ownerflag = (reader["Ownerflag"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("Ownerflag")) : false;
        //                    MobjPersonalsML.RegistrationDate = (reader["DOR"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("DOR")) : empty;
        //                    MobjPersonalsML.UploadedPhotoscount = (reader["UploadedPhotoscount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("UploadedPhotoscount")) : iNull;
        //                    MobjPersonalsML.PhotoshopCount = (reader["PhotoshopCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoshopCount")) : iNull;
        //                    MobjPersonalsML.OwnerName = (reader["OwnerName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("OwnerName")) : empty;
        //                    MobjPersonalsML.IsConfidential = (reader["IsConfidential"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("IsConfidential")) : false;
        //                    MobjPersonalsML.HoroscopeStatus = (reader["HoroscopeStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("HoroscopeStatus")) : iNull;
        //                    MobjPersonalsML.Emp_Ticket_ID = (reader["Emp_Ticket_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Emp_Ticket_ID")) : iLong;
        //                    MobjPersonalsML.ProfileOwnername = (reader["ProfileOwnername"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileOwnername")) : empty;
        //                    MobjPersonalsML.EmpUserName = (reader["EmpUserName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EmpUserName")) : empty;
        //                    MobjPersonalsML.Primaryemail = (reader["Primaryemail"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Primaryemail")) : empty;
        //                    MobjPersonalsML.Primarynumber = (reader["Primarynumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Primarynumber")) : empty;
        //                    MobjPersonalsML.HoroscopeStatus = (reader["HoroscopeStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("HoroscopeStatus")) : iNull;
        //                    MobjPersonalsML.HoroScopeImage = (reader["HoroScope"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("HoroScope")) : empty;
        //                    MobjPersonalsML.ApplicationPhotoPath = (reader["ApplicationPhotoPath"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ApplicationPhotoPath")) : empty;
        //                    MobjPersonalsML.DOR = (reader["DOR"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("DOR")) : empty;
        //                    MobjPersonalsML.LastLoginDate = (reader["LastLoginDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("LastLoginDate")) : empty;
        //                    MobjPersonalsML.PaidAmount = (reader["PaidAmount"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PaidAmount")) : empty;

        //                }
        //                arrayList.Add(MobjPersonalsML);

        //            }

        //        }
        //        reader.Close();

        //    }
        //    catch (Exception EX)
        //    {
        //        Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //        SqlConnection.ClearPool(connection);
        //        SqlConnection.ClearAllPools();
        //    }
        //    return arrayList;

        //}



        public int CustomerphotoRequestDisplay(string profileid, int? EMPID, long? ticketIDs, string strSpname)
        {
            SqlParameter[] parm = new SqlParameter[5];
            SqlDataReader reader;
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            Smtpemailsending smtp = new Smtpemailsending();
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            try
            {
                parm[0] = new SqlParameter("@profileid", SqlDbType.VarChar);
                parm[0].Value = profileid;
                parm[1] = new SqlParameter("@EmpID", SqlDbType.Int);
                parm[1].Value = EMPID;
                parm[2] = new SqlParameter("@EmpTickeID", SqlDbType.BigInt);
                parm[2].Value = ticketIDs;
                parm[3] = new SqlParameter("@Status", SqlDbType.Int);
                parm[3].Direction = ParameterDirection.Output;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, strSpname, parm);

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
                reader.Close();
                Commonclass.SendMailSmtpMethod(li, "info");
                intStatus = smtp.Statusint;
            }
            catch (Exception Ex)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(Ex.Message), Convert.ToInt64(profileid), null, null);
            }
            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return intStatus;
        }
        public ArrayList CandidateContactdetailsRelationName(long? CustID, int? PrimaryMobileRel, int? PrimaryEmailRel, int? iflage, string strSpname)
        {
            ArrayList arrayList = new ArrayList();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet dtCandidateContact = new DataSet();
            SqlDataAdapter daParentDetails = new SqlDataAdapter();
            try
            {
                SqlCommand cmd = new SqlCommand(strSpname, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cust_ID", CustID);
                cmd.Parameters.AddWithValue("@PrimaryMobileRel", PrimaryMobileRel);
                cmd.Parameters.AddWithValue("@PrimaryEmailRel", PrimaryEmailRel);
                cmd.Parameters.AddWithValue("@iflage", iflage);
                daParentDetails.SelectCommand = cmd;
                daParentDetails.Fill(dtCandidateContact);

            }
            catch (Exception Ex)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(Ex.Message), CustID, null, null);
            }
            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }

            return Commonclass.convertdataTableToArrayList(dtCandidateContact);
        }

        public int CandidateContactsendmailtoemailverify(long? CustID, string strSpname)
        {
            SqlParameter[] parm = new SqlParameter[5];
            SqlDataReader reader;
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            Smtpemailsending smtp = new Smtpemailsending();
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            try
            {
                parm[0] = new SqlParameter("@CustID", SqlDbType.BigInt);
                parm[0].Value = CustID;
                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, strSpname, parm);

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
                reader.Close();
                Commonclass.SendMailSmtpMethod(li, "info");
                intStatus = smtp.Statusint;
            }
            catch (Exception Ex)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(Ex.Message), CustID, null, null);
            }
            finally
            {

                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return intStatus;
        }

        public ArrayList ProfileIDPlaybutton(string ProfileID, string strSpname)
        {
            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[10];
            SqlDataReader reader;
            int? iNull = null;
            Int64? lnull = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            ProfilePlay profileplay = null;

            try
            {
                parm[0] = new SqlParameter("@ProfileID", SqlDbType.VarChar, 200);
                parm[0].Value = ProfileID;
                parm[1] = new SqlParameter("@flag", SqlDbType.VarChar, 200);
                parm[1].Value = 1;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, strSpname, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        profileplay = new ProfilePlay();
                        profileplay.Profileid = (reader["Profileid"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Profileid")) : null;
                        profileplay.RegistrationDate = (reader["RegistrationDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RegistrationDate")) : null;
                        profileplay.paidamount = (reader["paidamount"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("paidamount")) : null;
                        profileplay.paiddate = (reader["paiddate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("paiddate")) : null;
                        profileplay.sentreceivecount = (reader["sentreceivecount"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("sentreceivecount")) : null;
                        profileplay.photocount = (reader["photocount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("photocount")) : iNull;
                        profileplay.PD = (reader["PD"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PD")) : iNull;
                        profileplay.DPD = (reader["DPD"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("DPD")) : iNull;
                        profileplay.lnkView = (reader["lnkView"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("lnkView")) : iNull;
                        profileplay.notview = (reader["notview"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("notview")) : iNull;
                        profileplay.bothinterst = (reader["bothinterst"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("bothinterst")) : iNull;
                        profileplay.OppI = (reader["OppI"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("OppI")) : iNull;
                        profileplay.custid = (reader["custid"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("custid")) : iNull;
                        profileplay.OWNER = (reader["OWNER"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("OWNER")) : null;
                        profileplay.HoroPhotoName = (reader["HoroPhotoName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("HoroPhotoName")) : null;
                        profileplay.Settle = (reader["Settle"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Settle")) : null;
                        profileplay.TicketID = (reader["TicketID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TicketID")) : iNull;
                        profileplay.TicketNumber = (reader["TicketNumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("TicketNumber")) : null;
                        arrayList.Add(profileplay);

                    }
                }
                reader.Close();

            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return arrayList;
        }

        public ArrayList ViewAllCustomersSettledeleteinfo(string CustID, string typeofdata, string strSpname)
        {

            ArrayList arrayList = new ArrayList();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet dsPlaybutton = new DataSet();
            SqlDataAdapter daParentDetails = new SqlDataAdapter();

            try
            {
                SqlParameter[] parm = new SqlParameter[2];
                parm[0] = new SqlParameter("@ProfileID", SqlDbType.VarChar, 200);
                parm[0].Value = CustID;
                parm[1] = new SqlParameter("@status", SqlDbType.VarChar, 200);
                parm[1].Value = typeofdata;
                dsPlaybutton = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, strSpname, parm);
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(ex.Message), Convert.ToInt64(CustID), null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }

            return Commonclass.convertdataTableToArrayList(dsPlaybutton);

        }

        public int UploadsettlementForm(SettlementPaidBalanceDetailsMl Mobj, string strSpname)
        {
            DataSet dsprofilesettings = new DataSet();
            int iStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[15];
                parm[0] = new SqlParameter("@CreatedbyEmpID", SqlDbType.BigInt);
                parm[0].Value = Mobj.CreatedByEmpID;
                parm[1] = new SqlParameter("@CreatedDate", SqlDbType.VarChar);
                parm[1].Value = Mobj.CreatedDate;
                parm[2] = new SqlParameter("@ModifiedByEMPID", SqlDbType.Int);
                parm[2].Value = Mobj.ModifiedByEmpID;
                parm[3] = new SqlParameter("@ModifiedEmpDate", SqlDbType.VarChar);
                parm[3].Value = Mobj.ModifiedEmpDate;
                parm[4] = new SqlParameter("@settlementAgreedAmount", SqlDbType.Int);
                parm[4].Value = Mobj.SettlementAgreedAmount;
                parm[5] = new SqlParameter("@Notes", SqlDbType.VarChar);
                parm[5].Value = Mobj.Notes;
                parm[6] = new SqlParameter("@isActive", SqlDbType.Int);
                parm[6].Value = Mobj.isActive;
                parm[7] = new SqlParameter("@settlementFromPath", SqlDbType.VarChar);
                parm[7].Value = Mobj.Settlementfrompath;
                parm[8] = new SqlParameter("@isassaigned", SqlDbType.Int);
                parm[8].Value = Mobj.isassigned;
                parm[9] = new SqlParameter("@ReferenceID", SqlDbType.Int);
                parm[9].Value = Mobj.ReferenceID;
                parm[10] = new SqlParameter("@ProfileID", SqlDbType.VarChar);
                parm[10].Value = Mobj.Profileidnew;
                parm[11] = new SqlParameter("@Status", SqlDbType.Int);
                parm[11].Direction = ParameterDirection.Output;

                dsprofilesettings = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, strSpname, parm);
                if (string.Compare(parm[11].Value.ToString(), System.DBNull.Value.ToString()) == 0)
                {
                    iStatus = 0;
                }
                else
                {
                    iStatus = Convert.ToInt32(parm[11].Value);
                }
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(strSpname, Convert.ToString(ex.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return iStatus;
        }

        public static string PathChange = ConfigurationManager.AppSettings["PathChange"];
        string withouraccesspathhoro = "~\\Images\\";
        public int AstroGenerationUpdate(string Path, string KeyName)
        {
            int iresult = 0;

            //string strHoro = KeyName.Replace("/", "\\");
            string strHoro = KeyName;

            //Path = PathChange + strHoro;

            //Path = "e.kaakateeya.com\\access\\Images\\HoroscopeImages\\91022_HaroscopeImage\\91022_HaroscopeImage.html";
            //Path = "http:\\e.kaakateeya.com\\access\\" + strHoro;
            // KeyName = "Images/HoroscopeImages/91022_HaroscopeImage/91022_HaroscopeImage.html";

            //Path = "C:\\91022_HaroscopeImage\\91022_HaroscopeImage.html";
            //KeyName = "D:\\9_HaroscopeImage\\91022_HaroscopeImage.html";
            //Path = System.IO.Path(KeyName);

            //  string parentDir = System.IO.Path.GetDirectoryName(Path);

            //  Path = parentDir + "\\91022_HaroscopeImage.html";
            //  Path = Server.MapPath("~/" + KeyName);

            //Path = "www.e.kaakateeya.com\\access\\Images\\HoroscopeImages\\91022_HaroscopeImage\\91022_HaroscopeImage.html";

            //Path = System.IO.Path.Combine(System.Environment.CurrentDirectory, Path);


            if (!string.IsNullOrEmpty(Commonclass.GlobalImgPath))
            {
                Commonclass.S3upload(Path, KeyName);
                iresult = 1;
            }

            return iresult;
        }
    }
}

