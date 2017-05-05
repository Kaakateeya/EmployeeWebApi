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
    public class EmployeeReportPageDAL
    {

        public int SaveViewedBookmark_Customer(CustSearchMl Mobj, string spName)
        {
            int intStatus = 0;
            SqlParameter[] parm = new SqlParameter[5];
            Smtpemailsending smtp = new Smtpemailsending();
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            SqlDataReader reader;
            try
            {
                parm[0] = new SqlParameter("@ProfileCustID", SqlDbType.BigInt);
                parm[0].Value = Mobj.FromCustID;
                parm[1] = new SqlParameter("@TargetCustID", SqlDbType.BigInt);
                parm[1].Value = Mobj.ToCustID;

                parm[2] = new SqlParameter("@BookmarkFlag", SqlDbType.BigInt);
                parm[2].Value = Mobj.BookmaredFlag;

                parm[3] = new SqlParameter("@Status", SqlDbType.Int);
                parm[3].Direction = ParameterDirection.Output;

                if (!string.IsNullOrEmpty(Mobj.StrTocustIDs))
                {
                    parm[4] = new SqlParameter("@TargetCustIDs", SqlDbType.VarChar);
                    parm[4].Value = Mobj.StrTocustIDs;
                }
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (Convert.ToString(parm[3].Value) == "1")
                {
                    intStatus = 1;
                }
                else
                {
                    intStatus = 0;
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
            return intStatus;
        }
        public ArrayList MarketingSldeshowshortlistprofiles(string CustID, string spName)
        {
            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[10];
            SqlDataReader reader;

            int? iNull = null;
            bool? bnull = null;
            double? idecimal = null;

            MarketingSldeshow MobjMarketing = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@custid", SqlDbType.VarChar);
                parm[0].Value = CustID;
                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        MobjMarketing = new MarketingSldeshow();


                        MobjMarketing.Cust_ID = (reader["Cust_ID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Cust_ID")) : null;
                        MobjMarketing.paid = (reader["paid"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("paid")) : iNull;
                        MobjMarketing.ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : null;
                        MobjMarketing.KMPLID = (reader["KMPLID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("KMPLID")) : null;
                        MobjMarketing.IsConfidential = (reader["IsConfidential"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("IsConfidential")) : bnull;
                        MobjMarketing.SuperConfidentila = (reader["SuperConfidentila"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("SuperConfidentila")) : iNull;
                        MobjMarketing.FirstName = (reader["FirstName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FirstName")) : null;
                        MobjMarketing.LastName = (reader["LastName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("LastName")) : null;
                        MobjMarketing.PhotoNames = (reader["PhotoNames"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoNames")) : null;
                        MobjMarketing.Photo = (reader["Photo"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Photo")) : null;
                        MobjMarketing.ApplicationPhotoPath = (reader["ApplicationPhotoPath"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ApplicationPhotoPath")) : null;
                        MobjMarketing.HoroscopeStatus = (reader["HoroscopeStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("HoroscopeStatus")) : iNull;
                        MobjMarketing.HoroscopePath = (reader["HoroscopePath"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("HoroscopePath")) : null;
                        MobjMarketing.email = (reader["email"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("email")) : null;
                        MobjMarketing.NoOfBrothers = (reader["NoOfBrothers"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("NoOfBrothers")) : iNull;
                        MobjMarketing.NoOfSisters = (reader["NoOfSisters"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("NoOfSisters")) : iNull;
                        MobjMarketing.CasteID = (reader["Caste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Caste")) : null;
                        MobjMarketing.HeightInCentimeters = (reader["HeightInCentimeters"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("HeightInCentimeters")) : iNull;
                        MobjMarketing.maritalstatus = (reader["MaritalStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MaritalStatus")) : null;
                        MobjMarketing.DOB = (reader["DOB"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("DOB")) : null;
                        MobjMarketing.Age = (reader["Age"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Age")) : iNull;
                        MobjMarketing.TOB = (reader["TOB"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("TOB")) : null;
                        MobjMarketing.PlaceOfBirth = (reader["PlaceOfBirth"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PlaceOfBirth")) : null;
                        MobjMarketing.Gothram = (reader["Gothram"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Gothram")) : null;
                        MobjMarketing.Caste = (reader["MotherTongue"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("MotherTongue")) + "-") : "") + (reader["Caste"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("Caste")).ToString()) : null) + (reader["SubCaste"] != DBNull.Value ? ("(" + (reader.GetString(reader.GetOrdinal("SubCaste"))) + ")") : "");
                        MobjMarketing.Star = (reader["Star"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Star")) : null;
                        MobjMarketing.Color = (reader["Color"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Color")) : null;
                        MobjMarketing.Height = (reader["Height"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Height")) : null;
                        MobjMarketing.EducationGroup = (reader["EducationGroup"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationGroup")) : null;
                        MobjMarketing.EduGroupnamenew = (reader["EduGroupnamenew"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EduGroupnamenew")) : null;
                        MobjMarketing.Profession = (reader["Profession"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Profession")) : null;
                        MobjMarketing.JobLocation = (reader["JobLocation"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("JobLocation")) : null;
                        MobjMarketing.Income = (reader["Income"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Income")) : null;
                        MobjMarketing.currency = (reader["currency"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("currency")) : null;
                        MobjMarketing.FFNative = (reader["FF Native"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FF Native")) : null;
                        MobjMarketing.MFNative = (reader["MF Native"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MF Native")) : null;
                        MobjMarketing.Property = (reader["Property"]) != DBNull.Value ? reader.GetDouble(reader.GetOrdinal("Property")) : idecimal;
                        MobjMarketing.Intercaste = (reader["Intercaste"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("Intercaste")) : bnull;
                        MobjMarketing.fathercaste = (reader["fathercaste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("fathercaste")) : null;
                        MobjMarketing.mothercaste = (reader["mothercaste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("mothercaste")) : null;
                        MobjMarketing.PhotoCount = (reader["PhotoCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoCount")) : iNull;

                        MobjMarketing.CustomerFullPhoto = reader["CustomerFullPhoto"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("CustomerFullPhoto")) : null;

                        arrayList.Add(MobjMarketing);
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
        public ArrayList MyProfileBindings(string flag, string ID, string spName)
        {
            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[10];
            SqlDataReader reader;

            int? iNull = null;

            CountryDependency Myprofilebind = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@v_dflag", SqlDbType.VarChar);
                parm[0].Value = flag;
                parm[1] = new SqlParameter("@ID", SqlDbType.VarChar);
                parm[1].Value = ID;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Myprofilebind = new CountryDependency();
                        Myprofilebind.ID = (reader["ID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ID")) : iNull;
                        Myprofilebind.Name = (reader["Name"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Name")) : null;
                        Myprofilebind.CountryCode = (reader["ddlName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ddlName")) : null;
                        arrayList.Add(Myprofilebind);
                    }

                }
                reader.NextResult();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Myprofilebind = new CountryDependency();
                        Myprofilebind.ID = (reader["ID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ID")) : iNull;
                        Myprofilebind.Name = (reader["Name"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Name")) : null;
                        Myprofilebind.CountryCode = (reader["ddlName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ddlName")) : null;
                        arrayList.Add(Myprofilebind);
                    }
                }
                reader.NextResult();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Myprofilebind = new CountryDependency();
                        Myprofilebind.ID = (reader["ID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ID")) : iNull;
                        Myprofilebind.Name = (reader["Name"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Name")) : null;
                        Myprofilebind.CountryCode = (reader["ddlName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ddlName")) : null;
                        arrayList.Add(Myprofilebind);
                    }
                }
                reader.NextResult();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Myprofilebind = new CountryDependency();
                        Myprofilebind.ID = (reader["ID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ID")) : iNull;
                        Myprofilebind.Name = (reader["Name"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Name")) : null;
                        Myprofilebind.CountryCode = (reader["ddlName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ddlName")) : null;
                        arrayList.Add(Myprofilebind);
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

        public ArrayList MyProfileBindingsBranch(string flag, string ID, string spName)
        {
            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[10];
            SqlDataReader reader;

            int? iNull = null;

            MyprofileBranchbind Myprofilebind = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@v_dflag", SqlDbType.VarChar);
                parm[0].Value = flag;
                parm[1] = new SqlParameter("@ID", SqlDbType.VarChar);
                parm[1].Value = ID;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Myprofilebind = new MyprofileBranchbind();
                        Myprofilebind.ID = (reader["ID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ID")) : iNull;
                        Myprofilebind.Name = (reader["Name"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Name")) : null;
                        Myprofilebind.CountryCode = (reader["ddlName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ddlName")) : null;
                        Myprofilebind.BranchesName = (reader["BranchesName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("BranchesName")) : null;
                        Myprofilebind.Branch_ID = (reader["Branch_ID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Branch_ID")) : iNull;
                        arrayList.Add(Myprofilebind);
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
            return arrayList;
        }




        public ArrayList MyprofileAllslides(myprofileRequest Mobj, string spName)
        {
            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[40];
            SqlDataReader reader;

            Int32 intnull = 0;
            string empty = "--";
            long? iLong = null;

            myprofileResponse myprofile = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@Empid", SqlDbType.Int);
                parm[0].Value = Mobj.Empid;
                parm[1] = new SqlParameter("@KmplIDText", SqlDbType.VarChar);
                parm[1].Value = Mobj.Kmpl;
                parm[2] = new SqlParameter("@ProfileID", SqlDbType.VarChar);
                parm[2].Value = Mobj.Profileid;
                parm[3] = new SqlParameter("@HighConfidential", SqlDbType.Bit);
                parm[3].Value = Mobj.HighConfidential;
                parm[4] = new SqlParameter("@Confidential", SqlDbType.Bit);
                parm[4].Value = Mobj.Confidential;
                parm[5] = new SqlParameter("@Renewal", SqlDbType.Bit);
                parm[5].Value = Mobj.Renewal;
                parm[6] = new SqlParameter("@KmplyExpiry", SqlDbType.Bit);
                parm[6].Value = Mobj.chkKmplexperiry;
                parm[7] = new SqlParameter("@GenderID", SqlDbType.Int);
                parm[7].Value = Mobj.GenderID;

                parm[8] = new SqlParameter("@Surname", SqlDbType.VarChar);
                parm[8].Value = Mobj.Surname;
                parm[9] = new SqlParameter("@exactsurname", SqlDbType.Bit);
                parm[9].Value = Mobj.Chksurname;
                parm[10] = new SqlParameter("@FirstName", SqlDbType.VarChar);
                parm[10].Value = Mobj.FirstName;
                parm[11] = new SqlParameter("@exactfirstname", SqlDbType.Bit);
                parm[11].Value = Mobj.chkfirstname;
                parm[12] = new SqlParameter("@TypeofprofileID", SqlDbType.Int);
                parm[12].Value = Mobj.TypeofprofileID;

                parm[13] = new SqlParameter("@ApplicationstatusID", SqlDbType.VarChar);
                parm[13].Value = Mobj.ApplicationstatusID;

                parm[14] = new SqlParameter("@MarketingownerID", SqlDbType.VarChar);
                parm[14].Value = Mobj.MarketingownerID;

                parm[15] = new SqlParameter("@BranchID", SqlDbType.VarChar);
                parm[15].Value = Mobj.BranchID;

                parm[16] = new SqlParameter("@CasteID", SqlDbType.VarChar);
                parm[16].Value = Mobj.CasteID;

                parm[17] = new SqlParameter("@OwneroftheprofileID", SqlDbType.VarChar);
                parm[17].Value = Mobj.OwneroftheprofileID;

                parm[18] = new SqlParameter("@HavingprofilesID", SqlDbType.VarChar);
                parm[18].Value = Mobj.HavingprofilesID;

                parm[19] = new SqlParameter("@Assigneddatefromdate", SqlDbType.DateTime);
                parm[19].Value = Mobj.Assigneddatefromdate;
                parm[20] = new SqlParameter("@Assigneddatetodate", SqlDbType.DateTime);
                parm[20].Value = Mobj.Assigneddatetodate;
                parm[21] = new SqlParameter("@DORFromdate", SqlDbType.DateTime);
                parm[21].Value = Mobj.DORFromdate;
                parm[22] = new SqlParameter("@DORTodate", SqlDbType.DateTime);
                parm[22].Value = Mobj.DORTodate;
                parm[23] = new SqlParameter("@FatherName", SqlDbType.VarChar);
                parm[23].Value = Mobj.FatherName;
                parm[24] = new SqlParameter("@MotherName", SqlDbType.VarChar);
                parm[24].Value = Mobj.MotherName;
                parm[25] = new SqlParameter("@LogoutId", SqlDbType.Int);
                parm[25].Value = Mobj.LogoutId;
                parm[26] = new SqlParameter("@i_PageFrom", SqlDbType.Int);
                parm[26].Value = Mobj.pagefrom;
                parm[27] = new SqlParameter("@i_PageTo", SqlDbType.Int);
                parm[27].Value = Mobj.pageto;
                parm[28] = new SqlParameter("@previousownerID", SqlDbType.VarChar);
                parm[28].Value = Mobj.previousownerID;
                parm[29] = new SqlParameter("@VerifiedContancts", SqlDbType.Int);
                parm[29].Value = Mobj.verfiedcontacts;
                parm[30] = new SqlParameter("@WebsiteBlocked", SqlDbType.Int);
                parm[30].Value = Mobj.WebsiteBlocked;
                reader = SQLHelper.ExecuteReader(SQLHelper.GetSQLConnection(), CommandType.StoredProcedure, spName, parm);

                int count = reader.FieldCount;
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        myprofile = new myprofileResponse();
                        {
                            myprofile.Cust_ID = (reader["Cust_ID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Cust_ID")) : empty;
                            myprofile.ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : empty;
                            myprofile.TotalRows = (reader["TotalRows"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TotalRows")) : intnull;
                            myprofile.Totalpages = (reader["Totalpages"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Totalpages")) : intnull;
                            myprofile.KMPLID = (reader["KMPLID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("KMPLID")) : empty;
                            myprofile.IsConfidential = (reader["IsConfidential"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("IsConfidential")) : false;
                            myprofile.FirstName = (reader["FirstName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FirstName")) : empty;
                            myprofile.LastName = (reader["LastName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("LastName")) : empty;
                            myprofile.GenderID = (reader["Gender"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Gender")) : empty;
                            myprofile.Caste = (reader["Caste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Caste")) : empty;
                            myprofile.SubCaste = (reader["SubCaste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("SubCaste")) : empty;
                            myprofile.Age = (reader["Age"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Age")) : intnull;
                            myprofile.Height = (reader["Height"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Height")) : empty;
                            myprofile.Color = (reader["Color"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Color")) : empty;
                            myprofile.EducationGroup = (reader["EducationGroup"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationGroup")) : empty;
                            myprofile.Profession = (reader["Profession"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Profession")) : empty;
                            myprofile.JobLocation = (reader["JobLocation"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("JobLocation")) : empty;
                            myprofile.mothertongue = (reader["MotherTongue"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MotherTongue")) : empty;
                            myprofile.countrylivingin = (reader["CountryLivingin"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CountryLivingin")) : empty;
                            myprofile.MaritalStatusID = (reader["MaritalStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MaritalStatus")) : empty;
                            myprofile.Star = (reader["Star"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Star")) : empty;
                            myprofile.Gothram = (reader["Gothram"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Gothram")) : empty;
                            myprofile.TOB = (reader["TOB"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("TOB")) : empty;
                            myprofile.educationspecialisation = (reader["EduSpecialization"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EduSpecialization")) : empty;
                            myprofile.EduGroupnamenew = (reader["EduGroupnamenew"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EduGroupnamenew")) : empty;
                            myprofile.Employeedin = (reader["EmployeedIn"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EmployeedIn")) : empty;
                            myprofile.Profession = (reader["ProfGroup"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfGroup")) : empty;
                            myprofile.Property = (reader["Property"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Property")) : intnull;
                            myprofile.Income = (reader["Income"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Income")) : empty;
                            myprofile.FFNative = (reader["FFNative"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FFNative")) : empty;
                            myprofile.MFNative = (reader["MFNative"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MFNative")) : empty;
                            myprofile.NoOfBrothers = (reader["NoOfBrothers"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("NoOfBrothers")) : intnull;
                            myprofile.NoOfSisters = (reader["NoOfSisters"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("NoOfSisters")) : intnull;
                            myprofile.PlaceOfBirth = (reader["PlaceOfBirth"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PlaceOfBirth")) : empty;
                            myprofile.Photo = (reader["Photo"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Photo")) : empty;
                            myprofile.PhotoCount = (reader["PhotoCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoCount")) : intnull;
                            myprofile.PhotoNames = (reader["PhotoNames"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoNames")) : empty;
                            myprofile.HoroscopeStatus = (reader["HoroscopeStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("HoroscopeStatus")) : intnull;
                            myprofile.currency = (reader["currency"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("currency")) : empty;
                            myprofile.paid = (reader["paid"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("paid")) : false;
                            myprofile.Ownerflag = (reader["Ownerflag"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("Ownerflag")) : false;
                            myprofile.RegistrationDate = (reader["RegistrationDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RegistrationDate")) : empty;
                            myprofile.UploadedPhotoscount = (reader["UploadedPhotoscount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("UploadedPhotoscount")) : intnull;
                            myprofile.PhotoshopCount = (reader["PhotoshopCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoshopCount")) : intnull;
                            myprofile.onlinepaid = (reader["onlinepaid"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("onlinepaid")) : empty;
                            myprofile.offlinepaid = (reader["offlinepaid"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("offlinepaid")) : empty;
                            myprofile.onlinepaidcls = (reader["onlinepaidcls"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("onlinepaidcls")) : empty;
                            myprofile.offlinepaidcls = (reader["offlinepaidcls"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("offlinepaidcls")) : empty;
                            myprofile.OwnerName = (reader["OwnerName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("OwnerName")) : empty;
                            myprofile.ProfileGrade = (reader["ProfileGrade"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProfileGrade")) : intnull;
                            myprofile.DOB = (reader["DOB"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("DOB")) : empty;
                            myprofile.serviceDate = (reader["CreatedDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CreatedDate")) : empty;
                            myprofile.IsConfidential = (reader["IsConfidential"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("IsConfidential")) : false;
                            myprofile.SuperConfidentila = (reader["SuperConfidentila"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("SuperConfidentila")) : false;
                            myprofile.HoroscopeStatus = (reader["HoroscopeStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("HoroscopeStatus")) : intnull;
                            myprofile.HoroScopeImage = (reader["HoroScope"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("HoroScope")) : empty;

                            myprofile.SRCount = (reader["SRCount"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("SRCount")) : empty;
                            myprofile.ExpiryDate = (reader["ExpiryDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ExpiryDate")) : empty;
                            myprofile.Points = (reader["Points"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Points")) : empty;
                            myprofile.TicketID = (reader["TicketID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("TicketID")) : empty;
                            myprofile.Emp_Ticket_ID = (reader["Emp_Ticket_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Emp_Ticket_ID")) : iLong;
                            myprofile.MatchMeetingCount = (reader["MatchMeetingCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("MatchMeetingCount")) : intnull;
                            myprofile.ProfileOwnername = (reader["ProfileOwnername"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileOwnername")) : empty;
                            myprofile.EmpUserName = (reader["EmpUserName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EmpUserName")) : empty;
                            myprofile.SAForm = (reader["SAForm"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("SAForm")) : empty;
                            myprofile.CNumberVerStatus = (reader["CNumberVerStatus"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("CNumberVerStatus")) : false;
                            myprofile.CEmailVerStatus = (reader["CEmailVerStatus"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("CEmailVerStatus")) : false;
                            myprofile.Reason4InActive = (reader["Reason4InActive"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Reason4InActive")) : empty;
                            myprofile.Cust_Family_ID = (reader["Cust_Family_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_Family_ID")) : iLong;
                            myprofile.CountryCodeID = (reader["CountryCodeID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CountryCodeID")) : intnull;
                            myprofile.CreatedDate = (reader["CreatedDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CreatedDate")) : empty;
                            myprofile.Primaryemail = (reader["email"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("email")) : empty;
                            myprofile.Primarynumber = (reader["number"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("number")) : empty;

                            arrayList.Add(myprofile);

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
        public ArrayList SendServiceProfileIDs(string ProfileIDs, string spName)
        {
            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[10];
            SqlDataReader reader;
            int? iNull = null;
            long? ilong = null;
            SendServiceProfileIds Myprofilebind = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@ProfileIDs", SqlDbType.VarChar);
                parm[0].Value = ProfileIDs;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Myprofilebind = new SendServiceProfileIds();
                        Myprofilebind.FirstName = (reader["FirstName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FirstName")) : null;
                        Myprofilebind.LastName = (reader["LastName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("LastName")) : null;
                        Myprofilebind.ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : null;
                        Myprofilebind.ProfileStatusID = (reader["ProfileStatusID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProfileStatusID")) : iNull;
                        Myprofilebind.CustID = (reader["Cust_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_ID")) : ilong;
                        arrayList.Add(Myprofilebind);
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

        public ArrayList MatchfollowupSlideShowResult(SearchML Mobj, string spName)
        {
            ArrayList arrayList = new ArrayList();

            SqlParameter[] parm = new SqlParameter[15];
            SqlDataReader reader;
            BothsideInterest Binterest = null;
            string empty = "--";
            int? intnull = null;
            long? Lnull = null;
            int intnullVal = 0;

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            DataTable dt = new DataTable();
            parm[0] = new SqlParameter("@Empid", SqlDbType.VarChar, 20);
            parm[0].Value = Mobj.empid;
            parm[1] = new SqlParameter("@pagefrom", SqlDbType.Int);
            parm[1].Value = Mobj.pagefrom;
            parm[2] = new SqlParameter("@pageto", SqlDbType.Int);
            parm[2].Value = Mobj.pageto;
            parm[3] = new SqlParameter("@d_proceedFromdate", SqlDbType.DateTime);
            parm[3].Value = Mobj.Fromdate;
            parm[4] = new SqlParameter("@d_proceedTodate", SqlDbType.DateTime);
            parm[4].Value = Mobj.Todate;
            parm[5] = new SqlParameter("@owner", SqlDbType.Structured);
            parm[5].Value = Mobj.ProfileOwner;
            parm[6] = new SqlParameter("@Branch", SqlDbType.Structured);
            parm[6].Value = Mobj.ProfileOwnerBranch;
            parm[7] = new SqlParameter("@isoneside", SqlDbType.Int);
            parm[7].Value = (Mobj.CustID != null && Mobj.CustID != 0) || (Mobj.oppclose == true) ? 1 : Mobj.Spflag;
            parm[8] = new SqlParameter("@cust_id", SqlDbType.Int);
            parm[8].Value = Mobj.CustID;
            parm[9] = new SqlParameter("@Region", SqlDbType.Structured);
            parm[9].Value = Mobj.region;
            parm[10] = new SqlParameter("@ViewedPhoneNumbers", SqlDbType.Int);
            parm[10].Value = Mobj.Viewedcontacts;
            parm[11] = new SqlParameter("@oppclose", SqlDbType.Bit);
            parm[11].Value = Mobj.oppclose;
            parm[12] = new SqlParameter("@empwaiting", SqlDbType.Bit);
            parm[12].Value = Mobj.Empwaiting;

            try
            {


                reader = SQLHelper.ExecuteReader(SQLHelper.GetSQLConnection(), CommandType.StoredProcedure, spName, parm);
                int count = reader.FieldCount;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Binterest = new BothsideInterest();
                        {
                            Binterest.fromcust_id = (reader["FromCust_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("FromCust_ID")) : Lnull;
                            Binterest.tocustid = (reader["ToCust_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ToCust_ID")) : Lnull;
                            Binterest.PhotoCount = (reader["PhotoCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoCount")) : intnullVal;
                            Binterest.PhotoCountnew = (reader["PhotoCountnew"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoCountnew")) : intnullVal;
                            Binterest.fromemp = (reader["fromemp"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("fromemp")) : empty;
                            Binterest.toemp = (reader["toemp"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("toemp")) : empty;
                            Binterest.FromProfileid = (reader["FromProfileid"]) != DBNull.Value ? (reader.GetString(reader.GetOrdinal("FromProfileid"))).ToString() : null;
                            Binterest.Toprofileid = (reader["Toprofileid"]) != DBNull.Value ? (reader.GetString(reader.GetOrdinal("Toprofileid"))).ToString() : null;
                            Binterest.FromName = (reader["FromName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromName")) : empty;
                            Binterest.ToName = (reader["ToName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToName")) : empty;
                            Binterest.fromticketid = (reader["fromticketid"]) != DBNull.Value ? (reader.GetString(reader.GetOrdinal("fromticketid"))).ToString() : empty;
                            Binterest.Toticketid = (reader["Toticketid"]) != DBNull.Value ? (reader.GetString(reader.GetOrdinal("Toticketid"))).ToString() : empty;
                            Binterest.fromempname = (reader["fromempname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("fromempname")) : empty;
                            Binterest.toempname = (reader["toempname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("toempname")) : empty;
                            Binterest.TotalRows = (reader["TotalRows"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TotalRows")) : intnullVal;
                            Binterest.TotalPages = (reader["TotalPages"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TotalPages")) : intnullVal;
                            Binterest.FromTicketMatchmeetingStatus = (reader["FromTicketMatchmeetingStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromTicketMatchmeetingStatus")) : empty;
                            Binterest.FromTicket = (reader["FromTicket"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("FromTicket")) : Lnull;
                            Binterest.FromTicketAssignedEmpID = (reader["FromTicketAssignedEmpID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromTicketAssignedEmpID")) : empty;
                            Binterest.FromTicketCreated = (reader["FromInterestDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromInterestDate")).ToString() : empty;
                            Binterest.ToTicket = (reader["ToTicket"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ToTicket")) : Lnull;
                            Binterest.ToTicketAssignedEmpID = (reader["ToTicketAssignedEmpID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToTicketAssignedEmpID")) : empty;
                            Binterest.ToTicketCreated = (reader["ToInterestDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToInterestDate")).ToString() : empty;
                            Binterest.ToTicketMatchmeetingStatus = (reader["ToTicketMatchmeetingStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToTicketMatchmeetingStatus")) : empty;
                            Binterest.FromTicketHisoryType = (reader["FromTicketHisoryType"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromTicketHisoryType")) : empty;
                            Binterest.FromTicketHisoryDatenew = (reader["FromTicketHisoryDatenew"]) != DBNull.Value ? (reader.GetString(reader.GetOrdinal("FromTicketHisoryDatenew"))).ToString() : empty;
                            Binterest.FromTicketHisoryNAME = (reader["FromTicketHisoryNAME"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromTicketHisoryNAME")) : empty;
                            Binterest.FromTicketHisoryReplyDesc = (reader["FromTicketHisoryReplyDesc"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromTicketHisoryReplyDesc")) : empty;
                            Binterest.FromTicketHisoryCallStatus = (reader["FromTicketHisoryCallStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromTicketHisoryCallStatus")) : empty;
                            Binterest.FromTicketHisoryCallReceivedBy = (reader["FromTicketHisoryCallReceivedBy"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromTicketHisoryCallReceivedBy")) : empty;
                            Binterest.ToTicketHisoryType = (reader["ToTicketHisoryType"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToTicketHisoryType")) : empty; ;
                            Binterest.ToTicketHisoryDatenew = (reader["ToTicketHisoryDatenew"]) != DBNull.Value ? (reader.GetString(reader.GetOrdinal("ToTicketHisoryDatenew"))).ToString() : empty;
                            Binterest.ToTicketHisoryNAME = (reader["ToTicketHisoryNAME"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToTicketHisoryNAME")) : empty;
                            Binterest.ToTicketHisoryReplyDesc = (reader["ToTicketHisoryReplyDesc"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToTicketHisoryReplyDesc")) : empty;
                            Binterest.ToTicketHisoryCallStatus = (reader["ToTicketHisoryCallStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToTicketHisoryCallStatus")) : empty;
                            Binterest.ToTicketHisoryCallReceivedBy = (reader["ToTicketHisoryCallReceivedBy"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToTicketHisoryCallReceivedBy")) : empty;
                            Binterest.ServiceDate = (reader["ServiceDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ServiceDate")).ToString() : empty;
                            Binterest.FromEmail = (reader["FromEmail"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromEmail")) : empty;
                            Binterest.FromMobileNumber = (reader["FromMobileNumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromMobileNumber")) : empty;
                            Binterest.TOEmail = (reader["ToEmail"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToEmail")) : empty;
                            Binterest.ToMobileNumber = (reader["ToMobileNumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToMobileNumber")) : empty;
                            Binterest.FromExpressCount = (reader["FromExpressCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("FromExpressCount")) : intnull;
                            Binterest.ToExpressCount = (reader["ToExpressCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ToExpressCount")) : intnull;
                            Binterest.FromSaPath = (reader["FromSaPath"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromSaPath")) : string.Empty;
                            Binterest.ToSaPath = (reader["ToSaPath"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToSaPath")) : string.Empty;
                            Binterest.FromBranchCode = (reader["FromBranchCode"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromBranchCode")) : empty;
                            Binterest.ToBranchCode = (reader["ToBranchCode"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToBranchCode")) : empty;
                            Binterest.FromticketStatusIDb = (reader["FromticketStatusID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromticketStatusID")) : string.Empty;
                            Binterest.ToticketStatusIDb = (reader["ToticketStatusID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToticketStatusID")) : string.Empty;
                            Binterest.FromTicketInfo = (reader["FromTicketInfo"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromTicketInfo")) : string.Empty;
                            Binterest.ToTicketInfo = (reader["ToTicketInfo"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToTicketInfo")) : string.Empty;
                            Binterest.ToTicketHisoryRelationShip = (reader["ToTicketHisoryRelationShip"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToTicketHisoryRelationShip")) : empty;
                            Binterest.FromTicketHisoryRelationShip = (reader["FromTicketHisoryRelationShip"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromTicketHisoryRelationShip")) : empty;
                            Binterest.FromMobileCountryCode = (reader["FromMobileCountryCode"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromMobileCountryCode")) : empty;
                            Binterest.ToMobileCountryCode = (reader["ToMobileCountryCode"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToMobileCountryCode")) : empty;
                            Binterest.FRomSerivceCount = (reader["FromServiceCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("FromServiceCount")) : intnull;
                            Binterest.ToSerivceCount = (reader["ToServiceCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ToServiceCount")) : intnull;
                            Binterest.ISRvrSend = (reader["ISRvrSend"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ISRvrSend")) : intnull;
                            Binterest.FROMNEW = (reader["FROMNEW"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("FROMNEW")) : intnull;
                            Binterest.TONEW = (reader["TONEW"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TONEW")) : intnull;
                            Binterest.FromofflineDetails = (reader["FromofflineDetails"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromofflineDetails")) : empty;
                            Binterest.FromonlineDetails = (reader["FromonlineDetails"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromonlineDetails")) : empty;
                            Binterest.TofflineDetails = (reader["TofflineDetails"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("TofflineDetails")) : empty;
                            Binterest.ToonlineDetails = (reader["ToonlineDetails"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToonlineDetails")) : empty;
                            Binterest.FromOfflineExpiryDate = (reader["FromOfflineExpiryDate"]) != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("FromOfflineExpiryDate")).ToString() : empty;
                            Binterest.FromOnlineMembershipExpiryDate = (reader["FromOnlineMembershipExpiryDate"]) != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("FromOnlineMembershipExpiryDate")).ToString() : empty;
                            Binterest.ToOfflineExpiryDate = (reader["ToOfflineExpiryDate"]) != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("ToOfflineExpiryDate")).ToString() : empty;
                            Binterest.ToonlineExpiryDate = (reader["ToonlineExpiryDate"]) != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("ToonlineExpiryDate")).ToString() : empty;
                            Binterest.FromApplicationPhoto = (reader["FromApplicationPhoto"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromApplicationPhoto")).ToString() : null;
                            Binterest.ToApplicationPhoto = (reader["ToApplicationPhoto"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToApplicationPhoto")).ToString() : null;
                            arrayList.Add(Binterest);

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

        public EmployeeMarketingTicketResponse GetmarketingTicketHistoryInfo(EmployeeMarketingTicketRequest Mobj, string spName)
        {

            EmployeeMarketingTicketResponse MarketingTicketResponse = new EmployeeMarketingTicketResponse();

            string strErrorMsg = string.Empty;
            int? intnull = null;
            Int64? longnull = null;

            SqlParameter[] parm = new SqlParameter[30];
            SqlDataReader drReader = null;

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@i_EmpID", SqlDbType.BigInt);
                parm[0].Value = Mobj.v_MarketremindeFlag == 1 ? Mobj.i_EmpID : null;

                parm[1] = new SqlParameter("@i_PageFrom", SqlDbType.BigInt);
                parm[1].Value = Mobj.i_PageFrom;

                parm[2] = new SqlParameter("@i_PageTo", SqlDbType.BigInt);
                parm[2].Value = Mobj.i_PageTo;

                parm[3] = new SqlParameter("@Status", SqlDbType.Int);
                parm[3].Direction = ParameterDirection.Output;

                parm[4] = new SqlParameter("@Errormsg", SqlDbType.VarChar, 1000);
                parm[4].Direction = ParameterDirection.Output;

                parm[5] = new SqlParameter("@v_EmpIDs", SqlDbType.VarChar, 1000);
                parm[5].Value = Mobj.v_MarketremindeFlag == 1 ? null : Mobj.strEmpName;

                parm[6] = new SqlParameter("@v_BranchIDs", SqlDbType.VarChar, 1000);
                parm[6].Value = Mobj.v_MarketremindeFlag == 1 ? null : Mobj.strBranch;

                parm[7] = new SqlParameter("@i_isAdmin", SqlDbType.BigInt);
                parm[7].Value = Mobj.i_isAdmin;

                parm[8] = new SqlParameter("@dt_FromProceedDate", SqlDbType.DateTime);
                parm[8].Value = Mobj.dtFromProceedDate;

                parm[9] = new SqlParameter("@dt_ToProceedDate", SqlDbType.DateTime);
                parm[9].Value = Mobj.dtToProceedDate;

                parm[10] = new SqlParameter("@i_days", SqlDbType.BigInt);
                parm[10].Value = Mobj.i_days;

                parm[11] = new SqlParameter("@i_LoginEmpID", SqlDbType.Int);
                parm[11].Value = Mobj.i_EmpID;

                parm[12] = new SqlParameter("@i_RegionID", SqlDbType.Int);
                parm[12].Value = Mobj.i_RegionID;

                parm[13] = new SqlParameter("@v_Marketreminder", SqlDbType.Int);
                parm[13].Value = Mobj.v_MarketremindeFlag;

                parm[14] = new SqlParameter("@i_UnmarriedSiblingDetails", SqlDbType.Int);
                parm[14].Value = Mobj.v_siblingflag;

                parm[15] = new SqlParameter("@i_GuestTickets", SqlDbType.Int);
                parm[15].Value = Mobj.v_guestticketflag;

                parm[16] = new SqlParameter("@i_Onlineexpiry", SqlDbType.Int);
                parm[16].Value = Mobj.v_OnlineExprd;
                parm[17] = new SqlParameter("@i_Ooflineexpiry", SqlDbType.Int);
                parm[17].Value = Mobj.v_OfflineExprd;

                parm[18] = new SqlParameter("@i_TicketId", SqlDbType.VarChar);
                parm[18].Value = Mobj.i_TicketId;

                parm[19] = new SqlParameter("@i_EmailId", SqlDbType.VarChar);
                parm[19].Value = Mobj.i_EmailId;
                parm[20] = new SqlParameter("@i_PhoneNumber", SqlDbType.VarChar);
                parm[20].Value = Mobj.i_PhoneNumber;

                parm[21] = new SqlParameter("@i_ProfileId", SqlDbType.VarChar);
                parm[21].Value = Mobj.i_ProfileId;

                parm[22] = new SqlParameter("@dt_FromReminderDate", SqlDbType.DateTime);
                parm[22].Value = Mobj.dt_FromRemainderdate;

                parm[23] = new SqlParameter("@dt_ToReminderDate", SqlDbType.DateTime);
                parm[23].Value = Mobj.dt_ToReminderdate;

                parm[24] = new SqlParameter("@V_Notpay", SqlDbType.VarChar);
                parm[24].Value = Mobj.V_Notpay;

                drReader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);

                List<EmployeeMarketingslideticket> ticket = new List<EmployeeMarketingslideticket>();
                List<EmployeeMarketingslideHistory> ticketHistory = new List<EmployeeMarketingslideHistory>();

                if (drReader.HasRows)
                {

                    while (drReader.Read())
                    {

                        ticket.Add(new EmployeeMarketingslideticket
                        {

                            CustID = (drReader["CustID"]) != DBNull.Value ? drReader.GetInt64(drReader.GetOrdinal("CustID")).ToString() : string.Empty,
                            TicketID = (drReader["TicketID"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("TicketID")).ToString() : string.Empty,
                            CustomerName = (drReader["CustomerName"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("CustomerName")).ToString() : string.Empty,
                            Prirority = (drReader["Prirority"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("Prirority")).ToString() : string.Empty,
                            RegistrationDate = (drReader["RegistrationDate"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("RegistrationDate")).ToString() : string.Empty,
                            HighPriority = (drReader["HighPriority"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("HighPriority")).ToString() : string.Empty,
                            Category = (drReader["Category"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("Category")).ToString() : string.Empty,
                            TicketStatus = (drReader["TicketStatus"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("TicketStatus")).ToString() : string.Empty,
                            ProfileID = (drReader["ProfileID"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ProfileID")).ToString() : string.Empty,
                            TicketIDSuffix = (drReader["TicketIDSuffix"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("TicketIDSuffix")).ToString() : string.Empty,
                            CustLandingContID = (drReader["CustLandingContID"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("CustLandingContID")).ToString() : string.Empty,
                            MybookMarkedProfCount = (drReader["MybookMarkedProfCount"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("MybookMarkedProfCount")).ToString() : string.Empty,
                            WhobookmarkedCount = (drReader["WhobookmarkedCount"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("WhobookmarkedCount")).ToString() : string.Empty,
                            RectViewedProfCount = (drReader["RectViewedProfCount"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("RectViewedProfCount")).ToString() : string.Empty,
                            RectWhoViewedCout = (drReader["RectWhoViewedCout"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("RectWhoViewedCout")).ToString() : string.Empty,
                            IgnoreProfileCount = (drReader["IgnoreProfileCount"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("IgnoreProfileCount")).ToString() : string.Empty,
                            SentPhotoRequestCount = (drReader["SentPhotoRequestCount"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("SentPhotoRequestCount")).ToString() : string.Empty,
                            EmpPhoto = (drReader["EmpPhoto"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("EmpPhoto")).ToString() : string.Empty,
                            EmpName = (drReader["EmpName"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("EmpName")).ToString() : string.Empty,
                            PhotoCount = (drReader["PhotoCount"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("PhotoCount")).ToString() : string.Empty,
                            registeredBranch = (drReader["registeredBranch"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("registeredBranch")).ToString() : string.Empty,
                            ReminderDate = (drReader["ReminderDate"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ReminderDate")).ToString() : string.Empty,
                            Lastlogin = (drReader["Lastlogin"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("Lastlogin")).ToString() : string.Empty,
                            LoginCount = (drReader["LoginCount"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("LoginCount")).ToString() : string.Empty,
                            TotalRows = (drReader["TotalRows"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("TotalRows")).ToString() : string.Empty,
                            Emp_Ticket_ID = (drReader["Emp_Ticket_ID"]) != DBNull.Value ? drReader.GetInt64(drReader.GetOrdinal("Emp_Ticket_ID")).ToString() : string.Empty,
                            TicketOpenedOn = (drReader["TicketOpenedOn"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("TicketOpenedOn")).ToString() : string.Empty,
                            ReminderID = (drReader["ReminderID"]) != DBNull.Value ? drReader.GetInt64(drReader.GetOrdinal("ReminderID")) : longnull,
                            ReminderDatepopup = (drReader["ReminderDatepopup"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ReminderDatepopup")).ToString() : string.Empty,
                            EmpMobilenumber = (drReader["EmpMobilenumber"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("EmpMobilenumber")).ToString() : string.Empty,
                            PrimaryEmail = (drReader["PrimaryEmail"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("PrimaryEmail")).ToString() : string.Empty,
                            PrimaryContactNumber = (drReader["PrimaryContactNumber"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("PrimaryContactNumber")).ToString() : string.Empty,
                            AssignedToEmpID = (drReader["AssignedToEmpID"]) != DBNull.Value ? drReader.GetInt64(drReader.GetOrdinal("AssignedToEmpID")) : longnull,
                            isEmailVerified = (drReader["isEmailVerified"]) != DBNull.Value ? drReader.GetBoolean(drReader.GetOrdinal("isEmailVerified")).ToString() : string.Empty,
                            IsMobileVerified = (drReader["IsMobileVerified"]) != DBNull.Value ? drReader.GetBoolean(drReader.GetOrdinal("IsMobileVerified")).ToString() : string.Empty,
                            ReminderTime = (drReader["ReminderTime"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ReminderTime")).ToString() : string.Empty,
                            PrimaryContactNumberCountyCode = (drReader["PrimaryContactNumberCountyCode"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("PrimaryContactNumberCountyCode")).ToString() : string.Empty,
                            NoofDays = drReader["NoofDays"] != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("NoofDays")) : 0,
                            Feedetails = (drReader["Feedetails"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("Feedetails")) : string.Empty,
                            onlinePayment = (drReader["onlinePayment"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("onlinePayment")) : string.Empty,
                            offlinePayment = (drReader["offlinePayment"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("offlinePayment")) : string.Empty,
                            settleddeleted = (drReader["settleddeleted"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("settleddeleted")) : intnull,
                            ProfileStatusID = drReader["ProfileStatusID"] != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("ProfileStatusID")) : intnull,
                            SettlementValue = drReader["SettlementValue"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("SettlementValue")) : string.Empty,
                            PD = (drReader["PD"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("PD")) : intnull,
                            DPD = (drReader["DPD"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("DPD")) : intnull,
                            ViewCount = (drReader["ViewCount"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("ViewCount")) : intnull,
                            NView = (drReader["NView"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("NView")) : intnull,
                            BI = (drReader["BI"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("BI")) : intnull,
                            OppI = (drReader["OppI"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("OppI")) : intnull,
                            ServiceDate = drReader["ServiceDate"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ServiceDate")) : string.Empty,
                            isCustEmailID = drReader["isCustEmailID"] != DBNull.Value ? drReader.GetInt64(drReader.GetOrdinal("isCustEmailID")) : longnull,
                            IsCustContactNumbersID = drReader["IsCustContactNumbersID"] != DBNull.Value ? drReader.GetInt64(drReader.GetOrdinal("IsCustContactNumbersID")) : longnull,
                            NodataFound = drReader["NodataFound"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("NodataFound")) : string.Empty,
                            Photo = drReader["PhotoPath"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("PhotoPath")) : string.Empty,
                            TicketTypeID = drReader["TicketTypeID"] != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("TicketTypeID")).ToString() : string.Empty,
                            ReminderRelationName = drReader["ReminderRelationName"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ReminderRelationName")) : string.Empty,
                            Reminderbody = drReader["ReminderBody"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ReminderBody")) : string.Empty,
                            ReminderRelationID = drReader["ReminderRelationID"] != DBNull.Value ? drReader.GetInt64(drReader.GetOrdinal("ReminderRelationID")) : longnull

                        });

                    }

                    MarketingTicketResponse.Marketingslideticket = ticket;

                }

                drReader.NextResult();

                if (drReader.HasRows)
                {
                    while (drReader.Read())
                    {
                        ticketHistory.Add(new EmployeeMarketingslideHistory
                        {

                            TicketType = drReader["TicketType"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("TicketType")) : string.Empty,
                            Emp_Ticket_ID = drReader["Emp_Ticket_ID"] != DBNull.Value ? drReader.GetInt64(drReader.GetOrdinal("Emp_Ticket_ID")).ToString() : string.Empty,
                            TicketID = drReader["TicketID"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("TicketID")).ToString() : string.Empty,
                            ReplyDatenew = drReader["ReplyDatenew"] != DBNull.Value ? drReader.GetDateTime(drReader.GetOrdinal("ReplyDatenew")).ToString() : string.Empty,
                            MatchmeetingStatus = drReader["MatchmeetingStatus"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("MatchmeetingStatus")).ToString() : string.Empty,
                            MatchMeetingReason = drReader["MatchMeetingReason"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("MatchMeetingReason")).ToString() : string.Empty,
                            NoOfDays = drReader["NoOfDays"] != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("NoOfDays")).ToString() : string.Empty,
                            ExpressintrestID = drReader["ExpressintrestID"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ExpressintrestID")).ToString() : string.Empty,
                            NAME = drReader["NAME"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("NAME")).ToString() : string.Empty,
                            ReplyDesc = drReader["ReplyDesc"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ReplyDesc")).ToString() : string.Empty,
                            CallStatus = drReader["CallStatus"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("CallStatus")).ToString() : string.Empty,
                            CallReceivedBy = drReader["CallReceivedBy"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("CallReceivedBy")).ToString() : string.Empty,
                            CallDiscussion = drReader["CallDiscussion"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("CallDiscussion")).ToString() : string.Empty,
                            EmpRed = drReader["EmpRed"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("EmpRed")).ToString() : string.Empty,
                            RelationShip = drReader["RelationShip"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("RelationShip")).ToString() : string.Empty,
                            Number = drReader["Number"] != DBNull.Value ? drReader.GetInt64(drReader.GetOrdinal("Number")).ToString() : string.Empty,
                            ReplyDate = drReader["ReplyDate"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ReplyDate")).ToString() : string.Empty,
                            TicketingCallHistoryID = drReader["TicketingCallHistoryID"] != DBNull.Value ? drReader.GetInt64(drReader.GetOrdinal("TicketingCallHistoryID")).ToString() : string.Empty,
                            RelationShipID = drReader["RelationShipID"] != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("RelationShipID")).ToString() : string.Empty,
                            TicketTypeID = drReader["TicketTypeID"] != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("TicketTypeID")).ToString() : string.Empty,
                            ReminderRelationName = drReader["ReminderRelationName"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ReminderRelationName")) : string.Empty,
                            ReminderRelation = drReader["ReminderRelation"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ReminderRelation")) : string.Empty,
                            ReminderRelationID = drReader["ReminderRelationID"] != DBNull.Value ? drReader.GetInt64(drReader.GetOrdinal("ReminderRelationID")) : longnull

                        });
                    }

                    MarketingTicketResponse.MarketingslideHistory = ticketHistory;
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

            return MarketingTicketResponse;
        }

        //matchFollowuppage Send SMS ,Send Email,No SA Form ,View Contacts,Send Numbers

        #region

        public int MatchFollowupSendSms(EmployeeMarketslidesendmail Mobj, string spName)
        {
            SqlParameter[] parm = new SqlParameter[5];

            int intStatus = 0;

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@intFollowUpTicket", SqlDbType.Int);
                parm[0].Value = Mobj.i_TicketID;
                parm[1] = new SqlParameter("@strBody", SqlDbType.VarChar);
                parm[1].Value = Mobj.strbody;
                parm[2] = new SqlParameter("@intCreatedEmpID", SqlDbType.Int);
                parm[2].Value = Mobj.strEmpid;
                parm[3] = new SqlParameter("@status", SqlDbType.Int);
                parm[3].Direction = ParameterDirection.Output;

                SqlDataReader drResult = null;
                drResult = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[3].Value.ToString()).Equals(0))
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[3].Value);
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
            return intStatus;
        }

        public int MatchFollowupMailSend(MatchFollowupMailSend Mobj, string spName)
        {

            int? Istatus = null;
            int intStatus = 0;

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            SqlDataReader reader;

            SqlParameter[] parm = new SqlParameter[11];
            try
            {
                parm[0] = new SqlParameter("@v_ProfileID", SqlDbType.VarChar);
                parm[0].Value = Mobj.profileid;
                parm[1] = new SqlParameter("@v_mailtext", SqlDbType.VarChar);
                parm[1].Value = Mobj.Notes;
                parm[2] = new SqlParameter("@EmpID", SqlDbType.Int);
                parm[2].Value = Mobj.EMPID;
                parm[3] = new SqlParameter("@EmpTickeID", SqlDbType.BigInt);
                parm[3].Value = Mobj.LTicketID;
                parm[4] = new SqlParameter("@i_HistoryUpdate", SqlDbType.Int);
                parm[4].Value = Mobj.HistoryUpdate;
                parm[5] = new SqlParameter("@Acceptlink", SqlDbType.VarChar);
                parm[5].Value = Mobj.AcceptLink;
                parm[6] = new SqlParameter("@Rejectlink", SqlDbType.VarChar);
                parm[6].Value = Mobj.RejectLink;
                parm[7] = new SqlParameter("@FromCustID", SqlDbType.VarChar);
                parm[7].Value = Mobj.FromCustID;
                parm[8] = new SqlParameter("@RevCustID", SqlDbType.VarChar);
                parm[8].Value = Mobj.TocustID;
                parm[9] = new SqlParameter("@MatchfollowupStatus", SqlDbType.VarChar);
                parm[9].Value = Mobj.TicketStatusID;
                parm[10] = new SqlParameter("@Status", SqlDbType.Int);
                parm[10].Direction = ParameterDirection.Output;

                List<Smtpemailsending> li = new List<Smtpemailsending>();
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
                            Istatus = (reader["Status"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Status")) : 0;
                        }
                        li.Add(smtp);

                    }

                }
                intStatus = Istatus != null && Istatus != 0 ? 1 : 0;

                reader.Close();
                Commonclass.SendMailSmtpMethod(li, "info");

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
            return intStatus;
        }

        public List<TicketHistoryinfoResponse> MatchFollowupTicketinformation(long? Ticketid, char Type, string spName)
        {
            List<TicketHistoryinfoResponse> details = new List<TicketHistoryinfoResponse>();
            SqlDataReader reader;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string Snull = "--";
            long? Lnull = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

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

            return details;
        }

        public List<MarketingTicketResponse> MarketingTicketinformation(long? Ticketid, char Type, string spName)
        {

            List<MarketingTicketResponse> details = new List<MarketingTicketResponse>();
            SqlDataReader reader;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string Snull = "--";
            DateTime? dtTime = null;
            int? iNULLs = null;
            long? iLong = null;

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                SqlParameter[] parm = new SqlParameter[6];
                parm[0] = new SqlParameter("@TicketID", SqlDbType.BigInt);
                parm[0].Value = Ticketid;
                parm[1] = new SqlParameter("@Type", SqlDbType.Char);
                parm[1].Value = Type;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        MarketingTicketResponse Marketing = new MarketingTicketResponse();
                        {
                            if (Type == 'I')
                            {

                                Marketing.TicketID = reader["TicketID"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("TicketID")) : Snull;
                                Marketing.TotalRows = reader["TotalRows"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TotalRows")) : iNULLs;
                                Marketing.Emp_Ticket_ID = reader["Emp_Ticket_ID"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Emp_Ticket_ID")) : iLong;
                                Marketing.TicketStatus = reader["TicketStatus"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("TicketStatus")) : Snull;
                                Marketing.TicketOpenedOn = reader["TicketOpenedOn"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("TicketOpenedOn")) : null;
                                Marketing.Prirority = reader["Prirority"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Prirority")) : null;
                                Marketing.EmpName = reader["EmpName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("EmpName")) : Snull;
                                Marketing.PrimaryContactNumber = reader["PrimaryContactNumber"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("PrimaryContactNumber")) : Snull;
                                Marketing.NoofDays = reader["NoofDays"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("NoofDays")) : iNULLs;
                                Marketing.ProfileID = reader["ProfileID"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("ProfileID"))).ToString() : Snull;
                                Marketing.HighPriority = reader["HighPriority"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("HighPriority"))).ToString() : Snull;

                            }
                            else
                            {
                                Marketing.TicketType = reader["TicketType"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("TicketType")) : Snull;
                                Marketing.ReplyDatenew = reader["ReplyDatenew"] != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("ReplyDatenew")) : dtTime;
                                Marketing.ReplyDate = reader["ReplyDate"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ReplyDate")) : null;
                                Marketing.NAME = reader["NAME"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("NAME")) : Snull;
                                Marketing.CallStatus = reader["CallStatus"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("CallStatus"))).ToString() : Snull;
                                Marketing.CallReceivedBy = reader["CallReceivedBy"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("CallReceivedBy"))).ToString() : Snull;
                                Marketing.RelationShip = reader["RelationShip"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("RelationShip"))).ToString() : Snull;
                                Marketing.ReplyDesc = reader["ReplyDesc"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("ReplyDesc"))).ToString() : Snull;
                                //  Marketing.NoOfDays = reader["NoOfDays"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("NoOfDays")) : iNULLs;
                                Marketing.MatchmeetingStatus = reader["MatchmeetingStatus"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("MatchmeetingStatus")) : Snull;

                            }
                        }

                        details.Add(Marketing);
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

            return details;

        }

        public int MatchFollowupResendMail(MatchFollowupResendMail Mobj, string spName)
        {

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            SqlParameter[] parm = new SqlParameter[11];
            try
            {
                parm[0] = new SqlParameter("@i_FromCustID", SqlDbType.BigInt);
                parm[0].Value = Mobj.LFromCustID;
                parm[1] = new SqlParameter("@i_ToCustId", SqlDbType.BigInt);
                parm[1].Value = Mobj.LToCustID;
                parm[2] = new SqlParameter("@subject", SqlDbType.VarChar);
                parm[2].Value = Mobj.Subject;
                parm[3] = new SqlParameter("@Acceptlink", SqlDbType.VarChar);
                parm[3].Value = Mobj.AcceptLink;
                parm[4] = new SqlParameter("@Rejectlink", SqlDbType.VarChar);
                parm[4].Value = Mobj.RejectLink;
                parm[5] = new SqlParameter("@empid", SqlDbType.Int);
                parm[5].Value = Mobj.EMPID;
                parm[6] = new SqlParameter("@MatchfollowupStatus", SqlDbType.VarChar);
                parm[6].Value = Mobj.TicketStatusID;
                parm[7] = new SqlParameter("@v_mailtext", SqlDbType.VarChar);
                parm[7].Value = Mobj.Notes;

                SqlDataReader reader = null;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                List<Smtpemailsending> li = new List<Smtpemailsending>();

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
                            //Istatus = smtp.Status = (reader["Status"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Status")) : inull;
                        }
                        li.Add(smtp);
                    }

                }
                //intStatus = Istatus != null ? 1 : 0;

                reader.Close();
                Commonclass.SendMailSmtpMethod(li, "info");

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
            return 1;
        }

        public int Insertout_incomingcallCommunicationlogData(TicketCallHistory Mobj, string spName)
        {
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            SqlParameter[] parm = new SqlParameter[13];
            SqlDataReader drReader = null;
            try
            {
                parm[0] = new SqlParameter("@CallType", SqlDbType.Int);
                parm[0].Value = Mobj.CallType;
                parm[1] = new SqlParameter("@RelationID", SqlDbType.Int);
                parm[1].Value = Mobj.RelationID;
                parm[2] = new SqlParameter("@RelationName", SqlDbType.VarChar, 100);
                parm[2].Value = Mobj.RelationName;
                parm[3] = new SqlParameter("@CallResult", SqlDbType.Int);
                parm[3].Value = Mobj.CallResult;
                parm[4] = new SqlParameter("@Phonenum", SqlDbType.VarChar, 20);
                parm[4].Value = Mobj.PhoneNum;
                parm[5] = new SqlParameter("@Body", SqlDbType.VarChar, 1000);
                parm[5].Value = Mobj.CallDiscussion;
                parm[6] = new SqlParameter("@DisplayStatus", SqlDbType.Bit);
                parm[6].Value = Mobj.DisplayStatus;
                parm[7] = new SqlParameter("@TicketID", SqlDbType.BigInt);
                parm[7].Value = Mobj.TicketID;
                parm[8] = new SqlParameter("@EmpID", SqlDbType.BigInt);
                parm[8].Value = Mobj.EmpID;
                parm[9] = new SqlParameter("@AssignedEmpID", SqlDbType.BigInt);
                parm[9].Value = Mobj.AssignedEmpID;
                parm[10] = new SqlParameter("@ReplyTypeID", SqlDbType.Int);
                parm[10].Value = Mobj.Replaytypeid;
                parm[11] = new SqlParameter("@Status", SqlDbType.Int);
                parm[11].Direction = ParameterDirection.Output;
                drReader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[11].Value.ToString()).Equals(0))
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[11].Value);
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

            return intStatus;
        }

        public int Insertout_incomingcallData(IncomingOutgoing Mobj, string spName)
        {
            SqlParameter[] parm = new SqlParameter[13];
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@CallType", SqlDbType.Int);
                parm[0].Value = Mobj.CallType;
                parm[1] = new SqlParameter("@CalledOn", SqlDbType.VarChar, 100);
                parm[1].Value = Mobj.Calledon;
                parm[2] = new SqlParameter("@RelationID", SqlDbType.Int);
                parm[2].Value = Mobj.RelationID;
                parm[3] = new SqlParameter("@RelationName", SqlDbType.VarChar, 100);
                parm[3].Value = Mobj.RelationName;
                parm[4] = new SqlParameter("@CallResult", SqlDbType.Int);
                parm[4].Value = Mobj.CallResult;
                parm[5] = new SqlParameter("@StaffCalled", SqlDbType.BigInt);
                parm[5].Value = Mobj.StaffCalled;
                parm[6] = new SqlParameter("@Phonenum", SqlDbType.VarChar, 20);
                parm[6].Value = Mobj.PhoneNum;
                parm[7] = new SqlParameter("@CallDiscussion", SqlDbType.VarChar, 1000);
                parm[7].Value = Mobj.CallDiscussion;
                parm[8] = new SqlParameter("@DisplayStatus", SqlDbType.Int);
                parm[8].Value = Mobj.DisplayStatus;
                parm[9] = new SqlParameter("@TicketID", SqlDbType.BigInt);
                parm[9].Value = Mobj.TicketID;
                parm[10] = new SqlParameter("@EmpID", SqlDbType.BigInt);
                parm[10].Value = Mobj.EmpID;
                parm[11] = new SqlParameter("@Status", SqlDbType.Int);
                parm[11].Direction = ParameterDirection.Output;
                parm[12] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
                parm[12].Direction = ParameterDirection.Output;
                SqlDataReader drReader = null;
                drReader = SQLHelper.ExecuteReader(SQLHelper.GetSQLConnection(), CommandType.StoredProcedure, spName, parm);

                if (string.Compare(System.DBNull.Value.ToString(), parm[11].Value.ToString()).Equals(0))
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[11].Value);
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
            return intStatus;
        }
        public int ReaasignEmployee(long? TicketID, long? AssignedEmpID, long? EmpID, int? StatusID, string spName)
        {
            SqlParameter[] parm = new SqlParameter[6];
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@TicketID", SqlDbType.BigInt);
                parm[0].Value = TicketID;
                parm[1] = new SqlParameter("@AssignEmpID", SqlDbType.BigInt);
                parm[1].Value = AssignedEmpID;
                parm[2] = new SqlParameter("@EmpID", SqlDbType.BigInt);
                parm[2].Value = EmpID;
                parm[3] = new SqlParameter("@ID", SqlDbType.Int);
                parm[3].Value = StatusID;
                parm[4] = new SqlParameter("@Status", SqlDbType.Int);
                parm[4].Direction = ParameterDirection.Output;
                parm[5] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
                parm[5].Direction = ParameterDirection.Output;
                SqlDataReader drResult = null;
                drResult = SQLHelper.ExecuteReader(SQLHelper.GetSQLConnection(), CommandType.StoredProcedure, spName, parm);
                if (string.Compare(System.DBNull.Value.ToString(), Convert.ToString(parm[4].Value)).Equals(0))
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[4].Value);
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
            return intStatus;
        }
        public int InsertInternalMemo(string Message, long? TicketID, long? EmpID, long? AssignedEmpID, string spName)
        {
            SqlParameter[] parm = new SqlParameter[6];
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@Memo", SqlDbType.VarChar, 500);
                parm[0].Value = Message;
                parm[1] = new SqlParameter("@TicketID", SqlDbType.BigInt);
                parm[1].Value = TicketID;
                parm[2] = new SqlParameter("@EmpID", SqlDbType.BigInt);
                parm[2].Value = EmpID;
                parm[3] = new SqlParameter("@AssignedEmpID", SqlDbType.BigInt);
                parm[3].Value = AssignedEmpID;
                parm[4] = new SqlParameter("@Status", SqlDbType.Int);
                parm[4].Direction = ParameterDirection.Output;
                parm[5] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
                parm[5].Direction = ParameterDirection.Output;
                SqlDataReader drResult = null;
                drResult = SQLHelper.ExecuteReader(SQLHelper.GetSQLConnection(), CommandType.StoredProcedure, spName, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[4].Value.ToString()).Equals(0))
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[4].Value);
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
            return intStatus;
        }
        public int ClosedTickets(string ReasonforClose, long? TicketID, long? EmpID, string spName)
        {
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            SqlParameter[] parm = new SqlParameter[5];
            try
            {
                parm[0] = new SqlParameter("@ReasonForClose", SqlDbType.VarChar, 500);
                parm[0].Value = ReasonforClose;
                parm[1] = new SqlParameter("@TicketID", SqlDbType.BigInt);
                parm[1].Value = TicketID;
                parm[2] = new SqlParameter("@EmpID", SqlDbType.BigInt);
                parm[2].Value = EmpID;
                parm[3] = new SqlParameter("@Status", SqlDbType.Int);
                parm[3].Direction = ParameterDirection.Output;
                parm[4] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
                parm[4].Direction = ParameterDirection.Output;
                SqlDataReader drResult = null;
                drResult = SQLHelper.ExecuteReader(SQLHelper.GetSQLConnection(), CommandType.StoredProcedure, spName, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[3].Value.ToString()).Equals(0))
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[3].Value);
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

            return intStatus;
        }
        public int SendNumbersMatchfollowup(long? LFromCustID, long? LToCustID, int? empid, string mailTxt, string spName)
        {
            string strval = string.Empty;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            SqlDataReader reader;
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            Smtpemailsending smtp = new Smtpemailsending();

            try
            {
                SqlParameter[] parm = new SqlParameter[5];
                parm[0] = new SqlParameter("@i_FromCustID", SqlDbType.BigInt);
                parm[0].Value = LFromCustID;
                parm[1] = new SqlParameter("@i_ToCustId", SqlDbType.BigInt);
                parm[1].Value = LToCustID;
                parm[2] = new SqlParameter("@empid", SqlDbType.Int);
                parm[2].Value = empid;

                reader = SQLHelper.ExecuteReader(SQLHelper.GetSQLConnection(), CommandType.StoredProcedure, spName, parm);
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

                    }
                }
                Commonclass.SendMailSmtpMethod(li, "info");
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
            return 1;
        }



        #endregion

    }
}
