using KaakateeyaDAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using WebapiApplication.ML;
using WebapiApplication.ServiceReference1;
using WebapiApplication.UserDefinedTable;
using Dapper;
using System.Reflection;


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
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
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
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
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
                        Myprofilebind.Region = (reader["Region"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Region")) : iNull;
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
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
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
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
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
                parm[31] = new SqlParameter("@intTableType", SqlDbType.Int);
                parm[31].Value = Mobj.intTableType;
                parm[32] = new SqlParameter("@v_MaritalStatus", SqlDbType.VarChar);
                parm[32].Value = Mobj.v_MaritalStatus;
                parm[33] = new SqlParameter("@i_Domacile", SqlDbType.Int);
                parm[33].Value = Mobj.i_Domacile;

                parm[34] = new SqlParameter("@intNoActivity", SqlDbType.Int);
                parm[34].Value = Mobj.noActivity;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                int count = reader.FieldCount;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        myprofile = new myprofileResponse();
                        {
                            myprofile.Cust_ID = (reader["Cust_ID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Cust_ID")) : empty;
                            myprofile.ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : empty;
                            myprofile.KMPLID = (reader["KMPLID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("KMPLID")) : empty;
                            myprofile.paid = (reader["paid"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("paid")) : false;
                            myprofile.IsConfidential = (reader["IsConfidential"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("IsConfidential")) : false;
                            myprofile.SuperConfidentila = (reader["SuperConfidentila"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("SuperConfidentila")) : false;
                            myprofile.FirstName = (reader["FirstName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FirstName")) : empty;
                            myprofile.LastName = (reader["LastName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("LastName")) : empty;
                            //myprofile.NoOfBrothers = (reader["NoOfBrothers"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("NoOfBrothers")) : intnull;
                            //myprofile.NoOfSisters = (reader["NoOfSisters"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("NoOfSisters")) : intnull;
                            myprofile.Caste = (reader["Caste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Caste")) : empty;
                            myprofile.ProfileGrade = (reader["ProfileGrade"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProfileGrade")) : intnull;
                            myprofile.TotalRows = (reader["TotalRows"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TotalRows")) : intnull;
                            myprofile.Totalpages = (reader["Totalpages"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Totalpages")) : intnull;
                            myprofile.SRCount = (reader["SRCount"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("SRCount")) : empty;
                            myprofile.ExpiryDate = (reader["ExpiryDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ExpiryDate")) : empty;
                            myprofile.Points = (reader["Points"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Points")) : empty;
                            myprofile.CNumberVerStatus = (reader["CNumberVerStatus"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("CNumberVerStatus")) : false;
                            myprofile.CEmailVerStatus = (reader["CEmailVerStatus"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("CEmailVerStatus")) : false;
                            myprofile.SAForm = (reader["SAForm"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("SAForm")) : empty;
                            myprofile.TicketID = (reader["TicketID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("TicketID")) : empty;
                            myprofile.MatchMeetingCount = (reader["MatchMeetingCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("MatchMeetingCount")) : intnull;
                            myprofile.mothertongue = (reader["MotherTongue"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MotherTongue")) : empty;
                            myprofile.PhotoCount = (reader["PhotoCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoCount")) : intnull;
                            myprofile.GenderID = (reader["Gender"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Gender")) : empty;
                            myprofile.SubCaste = (reader["SubCaste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("SubCaste")) : empty;
                            myprofile.Age = (reader["Age"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Age")) : intnull;
                            myprofile.Height = (reader["Height"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Height")) : empty;
                            myprofile.Photo = (reader["Photo"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Photo")) : empty;
                            myprofile.PhotoNames = (reader["PhotoNames"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoNames")) : empty;
                            myprofile.RegistrationDate = (reader["RegistrationDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RegistrationDate")) : empty;
                            myprofile.UploadedPhotoscount = (reader["UploadedPhotoscount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("UploadedPhotoscount")) : intnull;
                            myprofile.PhotoshopCount = (reader["PhotoshopCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoshopCount")) : intnull;
                            myprofile.OwnerName = (reader["OwnerName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("OwnerName")) : empty;
                            myprofile.DOB = (reader["DOB"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("DOB")) : empty;
                            myprofile.serviceDate = (reader["CreatedDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CreatedDate")) : empty;
                            myprofile.IsConfidential = (reader["IsConfidential"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("IsConfidential")) : false;
                            myprofile.HoroscopeStatus = (reader["HoroscopeStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("HoroscopeStatus")) : intnull;
                            myprofile.Emp_Ticket_ID = (reader["Emp_Ticket_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Emp_Ticket_ID")) : iLong;
                            myprofile.ProfileOwnername = (reader["ProfileOwnername"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileOwnername")) : empty;
                            myprofile.EmpUserName = (reader["EmpUserName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EmpUserName")) : empty;
                            myprofile.Primaryemail = (reader["email"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("email")) : empty;
                            myprofile.Primarynumber = (reader["number"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("number")) : empty;
                            myprofile.HoroscopeStatus = (reader["HoroscopeStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("HoroscopeStatus")) : intnull;
                            myprofile.HoroScopeImage = (reader["HoroScope"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("HoroScope")) : empty;
                            myprofile.ApplicationPhotoPath = (reader["ApplicationPhotoPath"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ApplicationPhotoPath")) : empty;
                            myprofile.DOR = (reader["DOR"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("DOR")) : empty;
                            myprofile.PaidAmount = (reader["Payment"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Payment")) : empty;
                            myprofile.Row = (reader["Row"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Row")) : iLong;

                            myprofile.LastLoginDate = (reader["LastLoginDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("LastLoginDate")) : empty;
                            myprofile.LoginCount = (reader["LoginCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("LoginCount")) : intnull;

                            //27-09-2017
                            myprofile.Thumbnailpath = (reader["Thumbnailpath"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Thumbnailpath")) : empty;

                            myprofile.qualification = (reader["qualification"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("qualification")) : empty;
                            myprofile.Profession = (reader["Profession"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Profession")) : empty;
                            myprofile.JobLocation = (reader["JobLocation"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("JobLocation")) : empty;
                            myprofile.MaritalStatus = (reader["MaritalStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MaritalStatus")) : empty;
                            myprofile.Star = (reader["Star"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Star")) : empty;
                            myprofile.Gothram = (reader["Gothram"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Gothram")) : empty;
                            myprofile.TOB = (reader["TOB"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("TOB")) : empty;
                            myprofile.Property = (reader["Property"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Property")) : intnull;
                            myprofile.Income = (reader["Income"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Income")) : empty;
                            myprofile.FFNative = (reader["FFNative"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FFNative")) : empty;
                            myprofile.MFNative = (reader["MFNative"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MFNative")) : empty;
                            myprofile.PlaceOfBirth = (reader["PlaceOfBirth"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PlaceOfBirth")) : empty;
                            myprofile.Intercaste = (reader["Intercaste"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("Intercaste")) : false;
                            myprofile.fathercaste = (reader["fathercaste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("fathercaste")) : empty;
                            myprofile.mothercaste = (reader["mothercaste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("mothercaste")) : empty;
                            myprofile.currency = (reader["currency"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("currency")) : empty;
                            myprofile.ProfileStatusID = (reader["ProfileStatusID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProfileStatusID")) : intnull;
                            //
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
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
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
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
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
            DateTime? dnull = null;

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
            parm[7].Value = (Mobj.CustID != null && Mobj.CustID != 0) || (Mobj.oppclose == 1 || Mobj.oppclose == 2) ? 1 : Mobj.Spflag;
            parm[8] = new SqlParameter("@cust_id", SqlDbType.Int);
            parm[8].Value = Mobj.CustID;
            parm[9] = new SqlParameter("@Region", SqlDbType.Structured);
            parm[9].Value = Mobj.region;
            parm[10] = new SqlParameter("@ViewedPhoneNumbers", SqlDbType.Int);
            parm[10].Value = Mobj.Viewedcontacts;
            parm[11] = new SqlParameter("@oppclose", SqlDbType.Int);
            parm[11].Value = Mobj.oppclose;
            parm[12] = new SqlParameter("@empwaiting", SqlDbType.Bit);
            parm[12].Value = Mobj.Empwaiting;

            try
            {
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
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
                            Binterest.FromApplicationPhoto = (reader["FromApplicationPhoto"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromApplicationPhoto")).ToString() : null;
                            Binterest.ToApplicationPhoto = (reader["ToApplicationPhoto"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToApplicationPhoto")).ToString() : null;
                            Binterest.FromPaidStatus = (reader["FromPaidStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("FromPaidStatus")) : intnull;
                            Binterest.ToPaidStatus = (reader["ToPaidStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ToPaidStatus")) : intnull;
                            Binterest.FromExpiryDate = (reader["FromExpiryDate"]) != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("FromExpiryDate")) : dnull;
                            Binterest.ToExpiryDate = (reader["ToExpiryDate"]) != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("ToExpiryDate")) : dnull;
                            Binterest.Expressinterestlogid = (reader["ExpressinterestFromlogid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ExpressinterestFromlogid")) : Lnull;
                            Binterest.ExpressinterestTologid = (reader["ExpressinterestTologid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ExpressinterestTologid")) : Lnull;
                            Binterest.fromgenderid = (reader["fromgenderid"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("fromgenderid")) : intnull;
                            Binterest.togenderid = (reader["togenderid"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("togenderid")) : intnull;
                            Binterest.fromIsconfidential = (reader["fromIsconfidential"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("fromIsconfidential")) : intnull;
                            Binterest.fromHighconfidential = (reader["fromHighconfidential"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("fromHighconfidential")) : intnull;
                            Binterest.toIsconfidential = (reader["toIsconfidential"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("toIsconfidential")) : intnull;
                            Binterest.toHighconfidential = (reader["toHighconfidential"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("toHighconfidential")) : intnull;
                            Binterest.FromEmpownerid = (reader["FromEmpownerid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("FromEmpownerid")) : Lnull;
                            Binterest.ToEmpownerid = (reader["ToEmpownerid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ToEmpownerid")) : Lnull;
                            Binterest.fromEmpmobilenumber = (reader["fromEmpmobilenumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("fromEmpmobilenumber")) : null;
                            Binterest.toEmpmobilenumber = (reader["toEmpmobilenumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("toEmpmobilenumber")) : null;
                            Binterest.Fromsurname = (reader["Fromsurname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Fromsurname")) : null;
                            Binterest.Tosurname = (reader["Tosurname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Tosurname")) : null;
                            Binterest.fromonlyempname = (reader["fromonlyempname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("fromonlyempname")) : null;
                            Binterest.toonlyempname = (reader["toonlyempname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("toonlyempname")) : null;

                            Binterest.MFPFromEntered = (reader["MFPFromEntered"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MFPFromEntered")) : null;
                            Binterest.MFPToEntered = (reader["MFPToEntered"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MFPToEntered")) : null;

                            Binterest.FromRemDate = (reader["FromRemDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromRemDate")) : null;
                            Binterest.ToRemDate = (reader["ToRemDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToRemDate")) : null;
                            Binterest.RowID = (reader["RowNum"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("RowNum")) : intnull;
                            Binterest.EmpName = (reader["EmpName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EmpName")) : null;
                            Binterest.ExpressInterestID = (reader["ExpressInterestID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ExpressInterestID")) : intnull;
                            Binterest.ServicePending_EmpID = (reader["ServicePending_EmpID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ServicePending_EmpID")) : intnull;
                            Binterest.ServicePending_EmpName = (reader["ServicePending_EmpName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ServicePending_EmpName")) : null;
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
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
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

                parm[16] = new SqlParameter("@i_Onlineeexpiry", SqlDbType.Int);
                parm[16].Value = Mobj.v_OnlineExprd;

                parm[17] = new SqlParameter("@i_TicketId", SqlDbType.VarChar);
                parm[17].Value = Mobj.i_TicketId;

                parm[18] = new SqlParameter("@i_EmailId", SqlDbType.VarChar);
                parm[18].Value = Mobj.i_EmailId;
                parm[19] = new SqlParameter("@i_PhoneNumber", SqlDbType.VarChar);
                parm[19].Value = Mobj.i_PhoneNumber;

                parm[20] = new SqlParameter("@i_ProfileId", SqlDbType.VarChar);
                parm[20].Value = Mobj.i_ProfileId;

                parm[21] = new SqlParameter("@dt_FromReminderDate", SqlDbType.DateTime);
                parm[21].Value = Mobj.dt_FromRemainderdate;

                parm[22] = new SqlParameter("@dt_ToReminderDate", SqlDbType.DateTime);
                parm[22].Value = Mobj.dt_ToReminderdate;

                parm[23] = new SqlParameter("@V_Notpay", SqlDbType.VarChar);
                parm[23].Value = Mobj.V_Notpay;

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
                            RegistrationDate = (drReader["RegistrationDate"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("RegistrationDate")).ToString() : string.Empty,
                            Category = (drReader["Category"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("Category")).ToString() : string.Empty,
                            TicketStatus = (drReader["TicketStatus"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("TicketStatus")).ToString() : string.Empty,
                            ProfileID = (drReader["ProfileID"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ProfileID")).ToString() : string.Empty,
                            MybookMarkedProfCount = (drReader["MybookMarkedProfCount"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("MybookMarkedProfCount")).ToString() : string.Empty,
                            WhobookmarkedCount = (drReader["WhobookmarkedCount"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("WhobookmarkedCount")).ToString() : string.Empty,
                            RectViewedProfCount = (drReader["RectViewedProfCount"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("RectViewedProfCount")).ToString() : string.Empty,
                            RectWhoViewedCout = (drReader["RectWhoViewedCout"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("RectWhoViewedCout")).ToString() : string.Empty,
                            IgnoreProfileCount = (drReader["IgnoreProfileCount"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("IgnoreProfileCount")).ToString() : string.Empty,
                            SentPhotoRequestCount = (drReader["SentPhotoRequestCount"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("SentPhotoRequestCount")).ToString() : string.Empty,
                            EmpPhoto = (drReader["EmpPhoto"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("EmpPhoto")).ToString() : string.Empty,
                            EmpName = (drReader["EmpName"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("EmpName")).ToString() : string.Empty,
                            registeredBranch = (drReader["registeredBranch"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("registeredBranch")).ToString() : string.Empty,
                            ReminderDate = (drReader["ReminderDate"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ReminderDate")).ToString() : string.Empty,
                            Lastlogin = (drReader["Lastlogin"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("Lastlogin")).ToString() : string.Empty,
                            LoginCount = (drReader["LoginCount"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("LoginCount")).ToString() : string.Empty,
                            TotalRows = (drReader["TotalRows"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("TotalRows")).ToString() : string.Empty,
                            Emp_Ticket_ID = (drReader["Emp_Ticket_ID"]) != DBNull.Value ? drReader.GetInt64(drReader.GetOrdinal("Emp_Ticket_ID")).ToString() : string.Empty,
                            TicketOpenedOn = (drReader["TicketOpenedOn"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("TicketOpenedOn")).ToString() : string.Empty,
                            ReminderID = (drReader["ReminderID"]) != DBNull.Value ? drReader.GetInt64(drReader.GetOrdinal("ReminderID")) : longnull,
                            EmpMobilenumber = (drReader["EmpMobilenumber"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("EmpMobilenumber")).ToString() : string.Empty,
                            PrimaryEmail = (drReader["PrimaryEmail"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("PrimaryEmail")).ToString() : string.Empty,
                            PrimaryContactNumber = (drReader["PrimaryContactNumber"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("PrimaryContactNumber")).ToString() : string.Empty,
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
                            IsCustContactNumbersID = drReader["IsCustContactNumbersID"] != DBNull.Value ? drReader.GetInt64(drReader.GetOrdinal("IsCustContactNumbersID")) : longnull,
                            NodataFound = drReader["NodataFound"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("NodataFound")) : string.Empty,
                            Photo = drReader["PhotoPath"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("PhotoPath")) : string.Empty,
                            TicketTypeID = drReader["TicketTypeID"] != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("TicketTypeID")).ToString() : string.Empty,
                            ReminderRelationName = drReader["ReminderRelationName"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ReminderRelationName")) : string.Empty,
                            Reminderbody = drReader["ReminderBody"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ReminderBody")) : string.Empty,
                            ReminderRelationID = drReader["ReminderRelationID"] != DBNull.Value ? drReader.GetInt64(drReader.GetOrdinal("ReminderRelationID")) : longnull,
                            SAPath = drReader["SAFORM"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("SAFORM")) : string.Empty,
                            primaryCountryID = drReader["PrimaryContactNumberCountyID"] != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("PrimaryContactNumberCountyID")) : intnull,
                            FatherName = drReader["FatherName"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("FatherName")) : string.Empty,
                            paidStatus = drReader["PaidStatus"] != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("PaidStatus")) : 0
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
                            //ExpressintrestID = drReader["ExpressintrestID"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ExpressintrestID")).ToString() : string.Empty,
                            NAME = drReader["NAME"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("NAME")).ToString() : string.Empty,
                            ReplyDesc = drReader["ReplyDesc"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ReplyDesc")).ToString() : string.Empty,
                            CallStatus = drReader["CallStatus"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("CallStatus")).ToString() : string.Empty,
                            CallReceivedBy = drReader["CallReceivedBy"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("CallReceivedBy")).ToString() : string.Empty,
                            CallDiscussion = drReader["CallDiscussion"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("CallDiscussion")).ToString() : string.Empty,
                            //EmpRed = drReader["EmpRed"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("EmpRed")).ToString() : string.Empty,
                            RelationShip = drReader["RelationShip"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("RelationShip")).ToString() : string.Empty,
                            //Number = drReader["Number"] != DBNull.Value ? drReader.GetInt64(drReader.GetOrdinal("Number")).ToString() : string.Empty,
                            ReplyDate = drReader["ReplyDate"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ReplyDate")).ToString() : string.Empty,
                            TicketingCallHistoryID = drReader["TicketingCallHistoryID"] != DBNull.Value ? drReader.GetInt64(drReader.GetOrdinal("TicketingCallHistoryID")).ToString() : string.Empty,
                            //RelationShipID = drReader["RelationShipID"] != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("RelationShipID")).ToString() : string.Empty,
                            //TicketTypeID = drReader["TicketTypeID"] != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("TicketTypeID")).ToString() : string.Empty,
                            ReminderRelationName = drReader["ReminderRelationName"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ReminderRelationName")) : string.Empty,
                            //ReminderRelation = drReader["ReminderRelation"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ReminderRelation")) : string.Empty,
                            //ReminderRelationID = drReader["ReminderRelationID"] != DBNull.Value ? drReader.GetInt64(drReader.GetOrdinal("ReminderRelationID")) : longnull
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
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
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
            int? inull = null;
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
                                sh.MobileNumber = reader["MobileNumber"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("MobileNumber")) : Snull;
                                //14_10_2017_status
                                sh.GenderID = reader["GenderID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("GenderID")) : inull;
                                sh.FromCust_InterestStatus = reader["FromCust_InterestStatus"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromCust_InterestStatus")) : string.Empty;
                                sh.ToCust_InterestStatus = reader["ToCust_InterestStatus"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToCust_InterestStatus")) : string.Empty;
                                sh.TicketToStatus = reader["TicketToStatus"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("TicketToStatus")) : string.Empty;
                                sh.FromOwner = reader["FromOwner"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromOwner")) : string.Empty;
                                sh.ToOwner = reader["ToOwner"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToOwner")) : string.Empty;
                                sh.ToCustIDLastName = reader["ToCustIDLastName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToCustIDLastName")) : string.Empty;
                                sh.CustomerLastName = reader["CustomerLastName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("CustomerLastName")) : string.Empty;

                                sh.fromIsconfidential = reader["fromIsconfidential"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("fromIsconfidential")) : inull;

                                sh.fromHighconfidential = reader["fromHighconfidential"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("fromHighconfidential")) : inull;

                                sh.toIsconfidential = reader["toIsconfidential"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("toIsconfidential")) : inull;

                                sh.toHighconfidential = reader["toHighconfidential"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("toHighconfidential")) : inull;

                                sh.Cust_ProfileInterestsLog_ID = reader["Cust_ProfileInterestsLog_ID"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_ProfileInterestsLog_ID")) : Lnull;

                                sh.ToEmail = reader["ToEmail"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToEmail")) : Snull;

                                //
                                sh.Toticketid = reader["Toticketid"] != DBNull.Value ? Convert.ToInt64(reader["Toticketid"]) : Lnull;

                                sh.ExpressInterestID = reader["ExpressInterestID"] != DBNull.Value ? Convert.ToInt32(reader["ExpressInterestID"]) : inull;

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
            }

            return details;
        }

        public List<MarketingTicketResponseinfo> MarketingTicketinformation(long? Ticketid, char Type, string spName)
        {
            List<MarketingTicketResponseinfo> details = new List<MarketingTicketResponseinfo>();
            SqlDataReader reader;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string Snull = "--";
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
                        MarketingTicketResponseinfo Marketing = new MarketingTicketResponseinfo();
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
                            Marketing.ReminderID = reader["ReminderID"] != DBNull.Value ? (reader.GetInt64(reader.GetOrdinal("ReminderID"))) : iLong;
                            Marketing.ReminderDate = reader["ReminderDate"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("ReminderDate"))).ToString() : Snull;
                            Marketing.TicketTypeID = reader["TicketTypeID"] != DBNull.Value ? (reader.GetInt32(reader.GetOrdinal("TicketTypeID"))) : iNULLs;
                            Marketing.ReminderRelationID = reader["ReminderRelationID"] != DBNull.Value ? (reader.GetInt64(reader.GetOrdinal("ReminderRelationID"))) : iLong;
                            Marketing.ReminderRelationName = reader["ReminderRelationName"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("ReminderRelationName"))).ToString() : Snull;
                            Marketing.Category = reader["Category"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("Category"))).ToString() : Snull;
                            Marketing.Reminderbody = reader["Reminderbody"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("Reminderbody"))).ToString() : Snull;

                            //16_10_2017 added by lakshmi
                            Marketing.Cust_Name = reader["Cust_Name"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("Cust_Name"))).ToString() : Snull;
                            Marketing.DOR = reader["DOR"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("DOR"))).ToString() : Snull;
                            Marketing.BranchCode = reader["BranchCode"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("BranchCode"))).ToString() : Snull;
                            Marketing.email = reader["email"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("email"))).ToString() : Snull;
                            Marketing.number = reader["number"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("number"))).ToString() : Snull;

                            Marketing.CustomerApplicationPhoto = reader["CustomerApplicationPhoto"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("CustomerApplicationPhoto"))).ToString() : Snull;
                            //20_10_2017_custid
                            Marketing.Cust_ID = reader["Cust_ID"] != DBNull.Value ? (reader.GetInt64(reader.GetOrdinal("Cust_ID"))) : iLong;
                            Marketing.PaidAmt = reader["PaidAmt"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("PaidAmt"))) : null;
                            Marketing.SettleAmt = reader["SettleAmt"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("SettleAmt"))) : null;

                            Marketing.NoDatafound = reader["NoDatafound"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("NoDatafound"))) : null;

                            Marketing.EmpID = reader["EmpID"] != DBNull.Value ? (reader.GetInt64(reader.GetOrdinal("EmpID"))) : iLong;

                            Marketing.IsPrimaryCon = reader["IsPrimaryCon"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("IsPrimaryCon"))) : null;
                            Marketing.FatherCon = reader["FatherCon"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("FatherCon"))) : Snull;
                            Marketing.MotherCon = reader["MotherCon"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("MotherCon"))) : Snull;


                            Marketing.isemailverified = reader["isemailverified"] != DBNull.Value ? (reader.GetInt32(reader.GetOrdinal("isemailverified"))) : iNULLs;
                            Marketing.ismobileverified = reader["ismobileverified"] != DBNull.Value ? (reader.GetInt32(reader.GetOrdinal("ismobileverified"))) : iNULLs;

                            Marketing.mobileverifieddate = reader["mobileverifieddate"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("mobileverifieddate"))) : Snull;
                            Marketing.emailverifieddate = reader["emailverifieddate"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("emailverifieddate"))) : Snull;

                            Marketing.PaidSatus = reader["PaidSatus"] != DBNull.Value ? (reader.GetInt32(reader.GetOrdinal("PaidSatus"))) : iNULLs;


                            Marketing.mobilecountyid = reader["mobilecountyid"] != DBNull.Value ? (reader.GetInt32(reader.GetOrdinal("mobilecountyid"))) : iNULLs;
                            Marketing.countrycode = reader["countrycode"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("countrycode"))) : null;
                            Marketing.custfamilyID = reader["custfamilyID"] != DBNull.Value ? (reader.GetInt64(reader.GetOrdinal("custfamilyID"))) : iLong;
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
            }
            return 1;
        }

        public int Insertout_incomingcallCommunicationlogData(TicketCallHistory Mobj, string spName)
        {
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            SqlParameter[] parm = new SqlParameter[16];
            SqlDataReader drReader = null;
            try
            {
                parm[0] = new SqlParameter("@CallType", SqlDbType.VarChar);
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

                parm[12] = new SqlParameter("@intExpressIntID", SqlDbType.Int);
                parm[12].Value = Mobj.intExpressIntID;
                parm[13] = new SqlParameter("@intPendingEmpID", SqlDbType.Int);
                parm[13].Value = Mobj.intPendingEmpID;

                parm[14] = new SqlParameter("@intFromTicketStatus", SqlDbType.Int);
                parm[14].Value = Mobj.intFromTicketStatus;
                parm[15] = new SqlParameter("@VoiceCallType", SqlDbType.Int);
                parm[15].Value = Mobj.VoiceCallType;

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
            }

            return intStatus;
        }

        public int Insertout_incomingcallData(IncomingOutgoing Mobj, string spName)
        {
            SqlParameter[] parm = new SqlParameter[20];
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
                parm[13] = new SqlParameter("@VoiceCallType", SqlDbType.Int);
                parm[13].Value = Mobj.VoiceCallType;

                SqlDataReader drReader = null;
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
                drResult = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
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
                drResult = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
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
            }
            return 1;
        }

        #endregion

        // Communication log page

        #region

        //public List<EmpCommunication> EmployeeCommunicationLog(string ProfileID, int? intEmpId, string spName)
        //{
        //    List<CommunicationLogResult> details1 = new List<CommunicationLogResult>();
        //    List<CommunicationLogResult> details2 = new List<CommunicationLogResult>();
        //    List<CommunicationLogResult> details3 = new List<CommunicationLogResult>();
        //    List<CommunicationLogResult> details4 = new List<CommunicationLogResult>();
        //    List<EmpCommunication> logList = new List<EmpCommunication>();

        //    SqlDataReader reader;
        //    int? iNull = null;
        //    Int64? LNull = null;

        //    SqlConnection connection = new SqlConnection();
        //    connection = SQLHelper.GetSQLConnection();
        //    connection.Open();

        //    try
        //    {
        //        SqlParameter[] parm = new SqlParameter[2];

        //        parm[0] = new SqlParameter("@ProfielD", SqlDbType.VarChar);
        //        parm[0].Value = ProfileID;
        //        parm[1] = new SqlParameter("@intEmpId", SqlDbType.Int);
        //        parm[1].Value = intEmpId;
        //        reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);

        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                CommunicationLogResult display = new CommunicationLogResult();
        //                {
        //                    display.ProfileID = reader["ProfileID"] != DBNull.Value ? (reader["ProfileID"]).ToString() : null;
        //                    display.Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : null;
        //                    display.ServiceDate = reader["ServiceDate"] != DBNull.Value ? reader["ServiceDate"].ToString() : null;
        //                    display.TypeOfService = reader["TypeOfService"] != DBNull.Value ? reader["TypeOfService"].ToString() : null;
        //                    display.EmpName = reader["EmpName"] != DBNull.Value ? reader["EmpName"].ToString() : null;
        //                    display.Branch = reader["BranchName"] != DBNull.Value ? reader["BranchName"].ToString() : null;
        //                    display.MFPStatus = reader["MFPStatus"] != DBNull.Value ? reader["MFPStatus"].ToString() : null;
        //                    display.MFPStatusDate = reader["MFPStatusDate"] != DBNull.Value ? reader["MFPStatusDate"].ToString() : null;
        //                    display.TicketID = reader["TicketID"] != DBNull.Value ? reader["TicketID"].ToString() : null;
        //                    display.Emp_FollowupTicket_ID = reader["Emp_FollowupTicket_ID"] != DBNull.Value ? Convert.ToInt64(reader["Emp_FollowupTicket_ID"]) : LNull;
        //                    display.ProfileStatusID = reader["ProfileStatusID"] != DBNull.Value ? Convert.ToInt32(reader["ProfileStatusID"]) : iNull;
        //                    display.TicketStatusID = reader["TicketStatusID"] != DBNull.Value ? Convert.ToInt32(reader["TicketStatusID"]) : iNull;
        //                    display.TotalRows = reader["TotalRows"] != DBNull.Value ? Convert.ToInt32(reader["TotalRows"]) : iNull;
        //                    display.ProfileOwner = reader["ProfileOwner"] != DBNull.Value ? reader["ProfileOwner"].ToString() : null;
        //                    display.ExpressInterestID = reader["ExpressInterestID"] != DBNull.Value ? Convert.ToInt32(reader["ExpressInterestID"]) : iNull;
        //                    display.LogID = reader["LogID"] != DBNull.Value ? reader["LogID"] : LNull;
        //                    display.ISRvrSend = reader["ISRvrSend"] != DBNull.Value ? reader["ISRvrSend"] : iNull;
        //                    display.PD = reader["I"] != DBNull.Value ? Convert.ToInt32(reader["I"]) : iNull;
        //                    display.DPD = reader["NI"] != DBNull.Value ? Convert.ToInt32(reader["NI"]) : iNull;
        //                    display.Viewed = reader["V"] != DBNull.Value ? Convert.ToInt32(reader["V"]) : iNull;
        //                    display.NViewed = reader["NV"] != DBNull.Value ? Convert.ToInt32(reader["NV"]) : iNull;
        //                    display.paid = reader["Paid"] != DBNull.Value ? Convert.ToInt32(reader["Paid"]) : iNull;
        //                    display.ProfileStatus = reader["ProfileStatus"] != DBNull.Value ? reader["ProfileStatus"].ToString() : null;

        //                    display.iFromCustID = reader["FromCustID"] != DBNull.Value ? Convert.ToInt32(reader["FromCustID"]) : iNull;
        //                    display.FromName = reader["FromName"] != DBNull.Value ? reader["FromName"].ToString() : null;
        //                    display.iToCustID = reader["ToCustID"] != DBNull.Value ? Convert.ToInt32(reader["ToCustID"]) : iNull;

        //                }

        //                details1.Add(display);
        //            }

        //        }

        //        logList.Add(new EmpCommunication { log = details1 });
        //        reader.NextResult();

        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                CommunicationLogResult display = new CommunicationLogResult();
        //                {
        //                    display.ProfileID = reader["ProfileID"] != DBNull.Value ? (reader["ProfileID"]).ToString() : null;
        //                    //display.ServiceID = reader["ServiceID"] != DBNull.Value ? reader["ServiceID"].ToString() : null;
        //                    display.Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : null;
        //                    display.ServiceDate = reader["ServiceDate"] != DBNull.Value ? reader["ServiceDate"].ToString() : null;
        //                    display.TypeOfService = reader["TypeOfService"] != DBNull.Value ? reader["TypeOfService"].ToString() : null;
        //                    display.EmpName = reader["EmpName"] != DBNull.Value ? reader["EmpName"].ToString() : null;
        //                    display.Branch = reader["BranchName"] != DBNull.Value ? reader["BranchName"].ToString() : null;
        //                    display.MFPStatus = reader["MFPStatus"] != DBNull.Value ? reader["MFPStatus"].ToString() : null;
        //                    display.MFPStatusDate = reader["MFPStatusDate"] != DBNull.Value ? reader["MFPStatusDate"].ToString() : null;
        //                    display.TicketID = reader["TicketID"] != DBNull.Value ? reader["TicketID"].ToString() : null;
        //                    display.Emp_FollowupTicket_ID = reader["Emp_FollowupTicket_ID"] != DBNull.Value ? Convert.ToInt64(reader["Emp_FollowupTicket_ID"]) : LNull;
        //                    display.ProfileStatusID = reader["ProfileStatusID"] != DBNull.Value ? Convert.ToInt32(reader["ProfileStatusID"]) : iNull;
        //                    display.TicketStatusID = reader["TicketStatusID"] != DBNull.Value ? Convert.ToInt32(reader["TicketStatusID"]) : iNull;
        //                    display.TotalRows = reader["TotalRows"] != DBNull.Value ? Convert.ToInt32(reader["TotalRows"]) : iNull;
        //                    display.ProfileOwner = reader["ProfileOwner"] != DBNull.Value ? reader["ProfileOwner"].ToString() : null;
        //                    display.ExpressInterestID = reader["ExpressInterestID"] != DBNull.Value ? Convert.ToInt32(reader["ExpressInterestID"]) : iNull;
        //                    display.LogID = reader["LogID"] != DBNull.Value ? reader["LogID"] : LNull;
        //                    display.ISRvrSend = reader["ISRvrSend"] != DBNull.Value ? reader["ISRvrSend"] : iNull;
        //                    display.PhotoCount = reader["PhotoCount"] != DBNull.Value ? reader["PhotoCount"] : iNull;
        //                    //
        //                    display.PD = reader["I"] != DBNull.Value ? Convert.ToInt32(reader["I"]) : iNull;
        //                    display.DPD = reader["NI"] != DBNull.Value ? Convert.ToInt32(reader["NI"]) : iNull;
        //                    display.Viewed = reader["V"] != DBNull.Value ? Convert.ToInt32(reader["V"]) : iNull;
        //                    display.NViewed = reader["NV"] != DBNull.Value ? Convert.ToInt32(reader["NV"]) : iNull;
        //                    display.paid = reader["Paid"] != DBNull.Value ? Convert.ToInt32(reader["Paid"]) : iNull;

        //                    //
        //                    display.ProfileStatus = reader["ProfileStatus"] != DBNull.Value ? reader["ProfileStatus"].ToString() : null;
        //                    display.ServiceExpiryDate = reader["ServiceExpiryDate"] != DBNull.Value ? reader["ServiceExpiryDate"].ToString() : null;
        //                    display.ServicePoints = reader["ServicePoints"] != DBNull.Value ? reader["ServicePoints"].ToString() : null;

        //                    display.iFromCustID = reader["FromCustID"] != DBNull.Value ? Convert.ToInt32(reader["FromCustID"]) : iNull;
        //                    display.FromName = reader["FromName"] != DBNull.Value ? reader["FromName"].ToString() : null;
        //                    display.iToCustID = reader["ToCustID"] != DBNull.Value ? Convert.ToInt32(reader["ToCustID"]) : iNull;
        //                    display.FromEmail = reader["FromEmail"] != DBNull.Value ? reader["FromEmail"].ToString() : null;
        //                }
        //                details2.Add(display);
        //            }

        //        }

        //        logList.Add(new EmpCommunication { log = details2 });
        //        reader.NextResult();

        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                CommunicationLogResult display = new CommunicationLogResult();
        //                {
        //                    display.ProfileID = reader["ProfileID"] != DBNull.Value ? (reader["ProfileID"]).ToString() : null;
        //                    display.Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : null;
        //                    display.ResendDate = reader["ResendDate"] != DBNull.Value ? reader["ResendDate"].ToString() : null;
        //                    display.TypeOfService = reader["TypeOfService"] != DBNull.Value ? reader["TypeOfService"].ToString() : null;
        //                    display.EmpName = reader["EmpName"] != DBNull.Value ? reader["EmpName"].ToString() : null;
        //                    display.Branch = reader["BranchName"] != DBNull.Value ? reader["BranchName"].ToString() : null;
        //                    display.ServiceDate = reader["ServiceDate"] != DBNull.Value ? reader["ServiceDate"].ToString() : null;
        //                    display.ProfileStatusID = reader["ProfileStatusID"] != DBNull.Value ? Convert.ToInt32(reader["ProfileStatusID"]) : iNull;
        //                    display.TotalRows = reader["TotalRows"] != DBNull.Value ? Convert.ToInt32(reader["TotalRows"]) : iNull;
        //                    display.paid = reader["Paid"] != DBNull.Value ? Convert.ToInt32(reader["Paid"]) : iNull;
        //                    display.ProfileStatus = reader["ProfileStatus"] != DBNull.Value ? reader["ProfileStatus"].ToString() : null;

        //                    display.iFromCustID = reader["FromCustID"] != DBNull.Value ? Convert.ToInt32(reader["FromCustID"]) : iNull;
        //                    display.FromName = reader["FromName"] != DBNull.Value ? reader["FromName"].ToString() : null;
        //                    display.iToCustID = reader["ToCustID"] != DBNull.Value ? Convert.ToInt32(reader["ToCustID"]) : iNull;

        //                }
        //                details3.Add(display);
        //            }

        //        }

        //        logList.Add(new EmpCommunication { log = details3 });

        //        reader.NextResult();

        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                CommunicationLogResult display = new CommunicationLogResult();
        //                {
        //                    display.Sno = reader["Sno"] != DBNull.Value ? Convert.ToInt32(reader["Sno"]) : iNull;
        //                    display.ProfileID = reader["ProfileID"] != DBNull.Value ? (reader["ProfileID"]).ToString() : null;
        //                    display.Name = reader["FirstName"] != DBNull.Value ? reader["FirstName"].ToString() : null;
        //                    display.LastName = reader["LastName"] != DBNull.Value ? reader["LastName"].ToString() : null;
        //                    display.ProfileOwner = reader["EmpName"] != DBNull.Value ? reader["EmpName"].ToString() : null;
        //                    display.MeetingDate = reader["MeetingDate"] != DBNull.Value ? reader["MeetingDate"].ToString() : null;
        //                    display.TotalRows = reader["TotalRows"] != DBNull.Value ? Convert.ToInt32(reader["TotalRows"]) : iNull;
        //                    display.paid = reader["Paid"] != DBNull.Value ? Convert.ToInt32(reader["Paid"]) : iNull;
        //                    display.ProfileStatus = reader["ProfileStatus"] != DBNull.Value ? reader["ProfileStatus"].ToString() : null;

        //                    display.iFromCustID = reader["FromCustID"] != DBNull.Value ? Convert.ToInt32(reader["FromCustID"]) : iNull;
        //                    display.FromName = reader["FromName"] != DBNull.Value ? reader["FromName"].ToString() : null;
        //                    display.iToCustID = reader["ToCustID"] != DBNull.Value ? Convert.ToInt32(reader["ToCustID"]) : iNull;
        //                }

        //                details4.Add(display);
        //            }
        //        }

        //        logList.Add(new EmpCommunication { log = details4 });

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

        //    return logList;
        //}
        public ArrayList EmployeeCommunicationLog(string ProfileID, int? intEmpId, string spName)
        {
            SqlDataReader reader;
            int? iNull = null;
            Int64? LNull = null;
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                SqlParameter[] parm = new SqlParameter[2];

                parm[0] = new SqlParameter("@ProfielD", SqlDbType.VarChar);
                parm[0].Value = ProfileID;
                parm[1] = new SqlParameter("@intEmpId", SqlDbType.Int);
                parm[1].Value = intEmpId;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }

            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public Tuple<int, List<CommunicationLogResult>> EmployeeCommunicationLogRvrAndResend(RvrRequest Mobj, string spName)
        {
            SqlParameter[] parm = new SqlParameter[13];
            List<CommunicationLogResult> details3 = new List<CommunicationLogResult>();
            int intStatus = 0;
            int? iNull = null;

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            Smtpemailsending smtp = new Smtpemailsending();
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            SqlDataReader reader;

            try
            {
                parm[0] = new SqlParameter("@fromcust_id", SqlDbType.Int);
                parm[0].Value = Mobj.FromcustID;

                parm[1] = new SqlParameter("@Tocust_id", SqlDbType.Int);
                parm[1].Value = Mobj.TocustID;
                parm[2] = new SqlParameter("@AcceptLink", SqlDbType.VarChar);
                parm[2].Value = Mobj.AcceptLink;

                parm[3] = new SqlParameter("@RejectLink", SqlDbType.VarChar);
                parm[3].Value = Mobj.RejectLink;

                parm[4] = new SqlParameter("@ExpressInterestId", SqlDbType.BigInt);
                parm[4].Value = Mobj.ExpressInterestId;

                parm[5] = new SqlParameter("@LogID", SqlDbType.BigInt);
                parm[5].Value = Mobj.LogID;

                parm[6] = new SqlParameter("@isRvrflag", SqlDbType.VarChar);
                parm[6].Value = Mobj.isRvrflag;
                parm[7] = new SqlParameter("@i_empid", SqlDbType.Int);
                parm[7].Value = Mobj.empid;

                parm[8] = new SqlParameter("@i_status", SqlDbType.Int);
                parm[8].Direction = ParameterDirection.Output;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, "Usp_insert_Rvr_Resend_Log", parm);

                if (Mobj.isRvrflag == "RVR")
                {
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
                    Commonclass.SendMailSmtpMethod(li, "exp");
                    intStatus = smtp.Statusint;
                }
                else if (Mobj.isRvrflag == "RS")
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            CommunicationLogResult display = new CommunicationLogResult();
                            {
                                //display.ProfileID = reader["ProfileID"] != DBNull.Value ? (reader["ProfileID"]).ToString() : null;
                                //display.Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : null;
                                //display.ResendDate = reader["ResendDate"] != DBNull.Value ? reader["ResendDate"].ToString() : null;
                                //display.TypeOfService = reader["TypeOfService"] != DBNull.Value ? reader["TypeOfService"].ToString() : null;
                                //display.EmpName = reader["EmpName"] != DBNull.Value ? reader["EmpName"].ToString() : null;
                                //display.Branch = reader["BranchName"] != DBNull.Value ? reader["BranchName"].ToString() : null;
                                //display.ServiceDate = reader["ServiceDate"] != DBNull.Value ? reader["ServiceDate"].ToString() : null;
                                //display.ProfileStatusID = reader["ProfileStatusID"] != DBNull.Value ? Convert.ToInt32(reader["ProfileStatusID"]) : iNull;
                                //display.TotalRows = reader["TotalRows"] != DBNull.Value ? Convert.ToInt32(reader["TotalRows"]) : iNull;
                                //display.paid = reader["Paid"] != DBNull.Value ? Convert.ToInt32(reader["Paid"]) : iNull;
                                //display.ProfileStatus = reader["ProfileStatus"] != DBNull.Value ? reader["ProfileStatus"].ToString() : null;

                                display.ProfileID = reader["ProfileID"] != DBNull.Value ? (reader["ProfileID"]).ToString() : null;
                                display.NAME = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : null;
                                display.ResendDate = reader["ResendDate"] != DBNull.Value ? reader["ResendDate"].ToString() : null;
                                display.TypeOfService = reader["TypeOfService"] != DBNull.Value ? reader["TypeOfService"].ToString() : null;
                                display.EmpName = reader["EmpName"] != DBNull.Value ? reader["EmpName"].ToString() : null;
                                display.BranchName = reader["BranchName"] != DBNull.Value ? reader["BranchName"].ToString() : null;
                                display.ServiceDate = reader["ServiceDate"] != DBNull.Value ? reader["ServiceDate"].ToString() : null;
                                display.ProfileStatusID = reader["ProfileStatusID"] != DBNull.Value ? Convert.ToInt32(reader["ProfileStatusID"]) : iNull;
                                display.TotalRows = reader["TotalRows"] != DBNull.Value ? Convert.ToInt32(reader["TotalRows"]) : iNull;
                                display.Paid = reader["Paid"] != DBNull.Value ? Convert.ToInt32(reader["Paid"]) : iNull;
                                display.ProfileStatus = reader["ProfileStatus"] != DBNull.Value ? reader["ProfileStatus"].ToString() : null;
                            }
                            details3.Add(display);
                        }
                    }
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
                            smtp.Statusint = (reader["Status"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Status")) : 0;
                            li.Add(smtp);
                        }
                    }

                    Commonclass.SendMailSmtpMethod(li, "exp");
                    intStatus = smtp.Statusint;
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }

            if (Mobj.isRvrflag == "RVR")
            {
                return new Tuple<int, List<CommunicationLogResult>>(intStatus, null);
            }
            else
            {
                return new Tuple<int, List<CommunicationLogResult>>(intStatus, details3);
            }
        }

        public int EmployeeCommunicationLogSentphotosemail(string Email, string CustID, string spName)
        {
            Smtpemailsending smtp = new Smtpemailsending();
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            SqlDataReader reader;
            SqlParameter[] parm = new SqlParameter[12];
            int status = 0;

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@email", SqlDbType.VarChar);
                parm[0].Value = Email;
                parm[1] = new SqlParameter("@cust_Id", SqlDbType.VarChar);
                parm[1].Value = CustID;
                parm[2] = new SqlParameter("@Status", SqlDbType.Int);
                parm[2].Direction = ParameterDirection.Output;
                DataSet dsMessages = new DataSet();

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, "usp_sentemailwithimages_New", parm);

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
                status = smtp.Statusint;
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return status;
        }

        public int EmployeeCommunicationLogSendMarketingMail(CreateEmployeeMl Mobj, string spName)
        {
            int intStatus = 0;
            int? inull = null;
            int? Istatus = null;
            SqlDataReader reader;

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

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
            }
            return intStatus;
        }

        #endregion

        // Reg  Validation

        public List<GetRegprofilevalidation> RegistrationValidation(Regprofilevalidation partnerdata, string spName)
        {
            List<GetRegprofilevalidation> details = new List<GetRegprofilevalidation>();
            SqlDataReader reader;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string Snull = "--";
            int? inull = null;
            Int64? Lnull = null;
            int status = 0;
            string empty = "--";
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                SqlParameter[] parm = new SqlParameter[20];

                parm[0] = new SqlParameter("@strMFFNativePlace", SqlDbType.VarChar);
                parm[0].Value = partnerdata.strMFFNativePlace;
                parm[1] = new SqlParameter("@strFatherName", SqlDbType.VarChar);
                parm[1].Value = partnerdata.strFatherName;
                parm[2] = new SqlParameter("@strMotherName", SqlDbType.VarChar);
                parm[2].Value = partnerdata.strMotherName;
                parm[3] = new SqlParameter("@strFFName", SqlDbType.VarChar);
                parm[3].Value = partnerdata.strFFName;
                parm[4] = new SqlParameter("@strMFName", SqlDbType.VarChar);
                parm[4].Value = partnerdata.strMFName;
                parm[5] = new SqlParameter("@strMFSurName", SqlDbType.VarChar);
                parm[5].Value = partnerdata.strMFSurName;
                parm[6] = new SqlParameter("@strCustSurName", SqlDbType.VarChar);
                parm[6].Value = partnerdata.strCustSurName;
                parm[7] = new SqlParameter("@strCustName", SqlDbType.VarChar);
                parm[7].Value = partnerdata.strCustName;
                parm[8] = new SqlParameter("@strCaste", SqlDbType.VarChar);
                parm[8].Value = partnerdata.strCaste;
                parm[9] = new SqlParameter("@strAllPhones", SqlDbType.VarChar);
                parm[9].Value = partnerdata.strAllPhones;
                parm[10] = new SqlParameter("@strAllEmailIds", SqlDbType.VarChar);
                parm[10].Value = partnerdata.strAllEmailIds;
                parm[11] = new SqlParameter("@intAppicationStatusID", SqlDbType.Int);
                parm[11].Value = partnerdata.intAppicationStatusID;
                parm[12] = new SqlParameter("@intEmpID", SqlDbType.Int);
                parm[12].Value = partnerdata.intEmpID;
                parm[13] = new SqlParameter("@i_Startindex", SqlDbType.Int);
                parm[13].Value = partnerdata.i_Startindex;
                parm[14] = new SqlParameter("@i_EndIndex", SqlDbType.Int);
                parm[14].Value = partnerdata.i_EndIndex;
                parm[15] = new SqlParameter("@intGenderID", SqlDbType.Int);
                parm[15].Value = partnerdata.intGenderID;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        GetRegprofilevalidation sh = new GetRegprofilevalidation();
                        {
                            sh.ViewfullProfileID = reader["ProfileID"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : Snull;
                            sh.ProfileID = reader["ViewfullProfileID"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ViewfullProfileID")) : Snull;
                            sh.FirstName = reader["FirstName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("FirstName")) : Snull;
                            sh.LastName = reader["LastName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("LastName")) : Snull;
                            sh.Caste = reader["CasteName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("CasteName")) : Snull;
                            sh.DOR = reader["DOR"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("DOR")) : Snull;
                            sh.BranchCode = reader["BranchCode"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("BranchCode")) : Snull;
                            sh.ProfileOwner = reader["ProfileOwner"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileOwner")) : Snull;
                            sh.TotalRows = reader["TotalRows"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TotalRows")) : inull;
                            sh.TotalPages = reader["TotalPages"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TotalPages")) : inull;
                            sh.ProfileStatusID = reader["ProfileStatusID"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileStatusID")) : Snull;
                            // sh.ActiveCount = reader["ActiveCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ActiveCount")) : inull;
                            // sh.DeletedCount = reader["DeletedCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("DeletedCount")) : inull;
                            // sh.SettledCount = reader["SettledCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("SettledCount")) : inull;
                            //  sh.InActiveCount = reader["InActiveCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("InActiveCount")) : inull;
                            // sh.MMSerious = reader["MMSerious"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("MMSerious")) : inull;
                            sh.TicketID = reader["TicketID"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("TicketID")) : Lnull;
                            sh.TicketHistoryID = reader["TicketHisID"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("TicketHisID")) : Snull;
                            sh.paid = reader["PaidStatus"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PaidStatus")) : inull;
                            sh.PhotoCount = reader["PhotoCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoCount")) : inull;
                            sh.CustomerFullPhoto = reader["FromApplicationPhoto"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromApplicationPhoto")) : Snull;
                            sh.KMPL = reader["KMPLID"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("KMPLID")) : Snull;
                            sh.IsConfidential = reader["IsConfidential"] != DBNull.Value ? reader.GetSqlBoolean(reader.GetOrdinal("IsConfidential")).ToString() : Snull;
                            sh.SuperConfidentila = reader["HighConfendential"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("HighConfendential")) : inull;
                            sh.HoroscopeStatus = reader["HoroscopeStatus"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("HoroscopeStatus")) : inull;
                            sh.Cust_ID = reader["cust_id"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("cust_id")) : Lnull;
                            sh.SRCount = (reader["SRCount"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("SRCount")) : empty;
                            sh.PaidAmount = (reader["Payment"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Payment")) : inull;
                            sh.ExpiryDate = (reader["ExpiryDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ExpiryDate")) : empty;
                            sh.Points = (reader["Points"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Points")) : empty;
                            sh.Emp_Ticket_ID = (reader["Emp_Ticket_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Emp_Ticket_ID")) : Lnull;
                            sh.MatchMeetingCount = (reader["MatchMeetingCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("MatchMeetingCount")) : inull;
                            sh.ProfileOwnername = (reader["ProfileOwnername"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileOwnername")) : empty;
                            sh.EmpUserName = (reader["EmpUserName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EmpUserName")) : empty;
                            sh.SAForm = (reader["SAForm"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("SAForm")) : empty;
                            sh.CNumberVerStatus = (reader["CNumberVerStatus"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("CNumberVerStatus")) : false;
                            sh.CEmailVerStatus = (reader["CEmailVerStatus"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("CEmailVerStatus")) : false;
                            sh.CountryCodeID = (reader["CountryCodeID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CountryCodeID")) : inull;
                            sh.Primarynumber = (reader["Primarynumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Primarynumber")) : empty;
                            sh.Primaryemail = (reader["Primaryemail"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Primaryemail")) : empty;
                            sh.ProfileGrade = (reader["ProfileGrade"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProfileGrade")) : inull;
                            sh.mothertongue = (reader["mothertongue"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("mothertongue")) : empty;
                            sh.CustomerApplicationPhoto = (reader["CustomerFullPhoto"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CustomerFullPhoto")) : empty;
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
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }

            status = 1;
            return details;
        }

        public List<RegprofilevalidationPlaybutton> RegistrationValidation_Playbutton(string Profileid, string spName)
        {
            List<RegprofilevalidationPlaybutton> details = new List<RegprofilevalidationPlaybutton>();
            SqlDataReader reader;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string Snull = "--";
            int? inull = null;
            int status = 0;

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                SqlParameter[] parm = new SqlParameter[2];
                parm[0] = new SqlParameter("@ProfileID", SqlDbType.VarChar, 200);
                parm[0].Value = Profileid;
                parm[1] = new SqlParameter("@flag", SqlDbType.VarChar, 200);
                parm[1].Value = 1;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        RegprofilevalidationPlaybutton sh = new RegprofilevalidationPlaybutton();
                        {
                            sh.Profileid = reader["Profileid"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Profileid")) : Snull;
                            sh.Branch_Dor = reader["RegistrationDate"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("RegistrationDate")) : Snull;
                            sh.paidamount = reader["paidamount"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("paidamount")) : Snull;
                            sh.paiddate = reader["paiddate"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("paiddate")) : Snull;
                            sh.ProfileOwner = reader["OWNER"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("OWNER")) : Snull;
                            sh.sentreceivecount = reader["sentreceivecount"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("sentreceivecount")) : Snull;
                            sh.PC = reader["photocount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("photocount")) : inull;
                            sh.custid = reader["custid"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("custid")) : inull;
                            sh.empid = reader["empid"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("empid")) : inull;
                            sh.branchid = reader["branchid"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("branchid")) : inull;
                            sh.Horo = reader["horoscope"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("horoscope")) : inull;
                            sh.SA = reader["Settle"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Settle")) : Snull;
                            sh.PD = reader["PD"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PD")) : inull;
                            sh.DPD = reader["DPD"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("DPD")) : inull;
                            sh.View = reader["lnkView"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("lnkView")) : inull;
                            sh.Nview = reader["notview"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("notview")) : inull;
                            sh.BI = reader["bothinterst"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("bothinterst")) : inull;
                            sh.OppI = reader["OppI"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("OppI")) : inull;
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
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            status = 1;
            return details;
        }

        public int FeeUpdateDalWithInternalMemoUpdate(FeeUpdateML Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[9];
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@TicketID", SqlDbType.BigInt);
                parm[0].Value = Mobj.EmpTicketID;
                parm[1] = new SqlParameter("@EmpID", SqlDbType.BigInt);
                parm[1].Value = Mobj.EmpID;
                parm[2] = new SqlParameter("@Memo", SqlDbType.VarChar);
                parm[2].Value = Mobj.Message;
                parm[3] = new SqlParameter("@AssignedEmpID", SqlDbType.BigInt);
                parm[3].Value = Mobj.AssignedEmpID;
                parm[4] = new SqlParameter("@FeeValue", SqlDbType.VarChar);
                parm[4].Value = Mobj.feevalue;
                parm[5] = new SqlParameter("@CustID", SqlDbType.Int);
                parm[5].Value = Mobj.CustID;
                parm[6] = new SqlParameter("@SettlementValue", SqlDbType.VarChar);
                parm[6].Value = Mobj.SettlementValue;
                parm[7] = new SqlParameter("@isSiblings", SqlDbType.Char);
                parm[7].Value = Mobj.isSiblings;
                parm[8] = new SqlParameter("@Status", SqlDbType.Int);
                parm[8].Direction = ParameterDirection.Output;

                SqlDataReader reader = null;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[8].Value.ToString()).Equals(0))
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[8].Value);
                }
            }
            catch (Exception EX)
            {
                throw EX;
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return intStatus;
        }

        public int createReminderDal(CreateReminderMI Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[12];
            int intStatus = 0;

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@ProfileId", SqlDbType.VarChar, 5000);
                parm[0].Value = Mobj.ProfileID;
                parm[1] = new SqlParameter("@ReminderID", SqlDbType.BigInt);
                parm[1].Value = Mobj.ReminderID;
                parm[2] = new SqlParameter("@EmpID", SqlDbType.BigInt);
                parm[2].Value = Mobj.EmpID;
                parm[3] = new SqlParameter("@TicketID", SqlDbType.VarChar, 5000);
                parm[3].Value = Mobj.TicketID;
                parm[4] = new SqlParameter("@DateOfReminder", SqlDbType.VarChar, 5000);
                parm[4].Value = Mobj.DateOfReminder;
                parm[5] = new SqlParameter("@ReminderType", SqlDbType.BigInt);
                parm[5].Value = Mobj.ReminderType1;
                parm[6] = new SqlParameter("@Body", SqlDbType.VarChar, 5000);
                parm[6].Value = Mobj.Body;
                parm[7] = new SqlParameter("@Status", SqlDbType.Int);
                parm[7].Direction = ParameterDirection.Output;
                parm[8] = new SqlParameter("@RelationID", SqlDbType.BigInt);
                parm[8].Value = Mobj.RelationID;
                parm[9] = new SqlParameter("@Name", SqlDbType.VarChar, 5000);
                parm[9].Value = Mobj.Name;
                parm[10] = new SqlParameter("@Category", SqlDbType.Int);
                parm[10].Value = Mobj.Category;
                parm[11] = new SqlParameter("@IsFollowup", SqlDbType.Int);
                parm[11].Value = Mobj.IsFollowup;

                SqlDataReader reader = null;
                //reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spname, parm);
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spname, parm);

                if (string.Compare(System.DBNull.Value.ToString(), parm[7].Value.ToString()).Equals(0))
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[7].Value);
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return intStatus;
        }

        public int marketingSendSmsdal(EmployeeMarketslidesendmail Mobj, string spName)
        {
            SqlParameter[] parm = new SqlParameter[5];

            int intStatus = 0;

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@Emp_Ticket_ID", SqlDbType.BigInt);
                parm[0].Value = Mobj.Emp_TicketingCallHistoryID;
                parm[1] = new SqlParameter("@Body", SqlDbType.VarChar);
                parm[1].Value = Mobj.strbody;
                parm[2] = new SqlParameter("@CreatedByEmpID", SqlDbType.BigInt);
                parm[2].Value = Mobj.Empid;
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
                //    SqlConnection.ClearPool(connection);
                //    SqlConnection.ClearAllPools();
            }
            return intStatus;
        }

        public int uploadSettlementFormDal(uploadFormMl Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[13];

            int intStatus = 0;

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@CreatedbyEmpID", SqlDbType.BigInt);
                parm[0].Value = Mobj.CreatedByEmpID;
                parm[1] = new SqlParameter("@CreatedDate", SqlDbType.VarChar);
                parm[1].Value = Mobj.CreatedDate;
                parm[2] = new SqlParameter("@ModifiedByEMPID", SqlDbType.BigInt);
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
                parm[12] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
                parm[12].Direction = ParameterDirection.Output;

                DataSet ds = new DataSet();

                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
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
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return intStatus;
        }

        public int checkSettlementProfileID(string profileID, string spname, out int intStatus)
        {
            SqlParameter[] Parm = new SqlParameter[2];

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            intStatus = 0;
            try
            {
                Parm[0] = new SqlParameter("@ProfileID", SqlDbType.VarChar, 5000);
                Parm[0].Value = profileID;
                Parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                Parm[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, Parm);

                if (string.Compare(System.DBNull.Value.ToString(), Convert.ToString(Parm[1].Value)) == 0)
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(Parm[1].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return intStatus;
        }

        public List<BothsideInterestObjs> ServiceSlideshowdata(Servicesslideslideshowbasedonprofile Mobj, string spname)
        {
            SqlDataReader reader;
            List<BothsideInterestserveice> li = new List<BothsideInterestserveice>();
            List<BothsideInterestserveice> li1 = new List<BothsideInterestserveice>();
            List<BothsideInterestObjs> objlist = new List<BothsideInterestObjs>();

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                SqlParameter[] parm = new SqlParameter[15];
                DataTable dt = new DataTable();
                parm[0] = new SqlParameter("@v_profileid", SqlDbType.VarChar);
                parm[0].Value = Mobj.v_profileid;
                parm[1] = new SqlParameter("@i_empid", SqlDbType.Int);
                parm[1].Value = Mobj.i_empid;
                parm[2] = new SqlParameter("@c_intersttype", SqlDbType.VarChar);
                parm[2].Value = Mobj.c_intersttype;
                parm[3] = new SqlParameter("@c_oppintersttype", SqlDbType.VarChar);
                parm[3].Value = Mobj.c_oppintersttype;

                parm[4] = new SqlParameter("@intApplicationStatus", SqlDbType.VarChar);
                parm[4].Value = Mobj.intApplicationStatus;

                parm[5] = new SqlParameter("@pagefrom", SqlDbType.Int);
                parm[5].Value = Mobj.pagefrom;
                parm[6] = new SqlParameter("@pageto", SqlDbType.Int);
                parm[6].Value = Mobj.pageto;

                parm[7] = new SqlParameter("@strProfileFNameLName", SqlDbType.VarChar);
                parm[7].Value = Mobj.strProfileFNameLName;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spname, parm);
                int count = reader.FieldCount;

                string empty = "--";
                int? intnull = null;
                long? Lnull = null;
                Boolean? bnul = null;
                double? fnull = null;
                int intnullVal = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        BothsideInterestserveice Binterest = new BothsideInterestserveice();
                        {
                            Binterest.RowID = (reader["RowID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("RowID")) : Lnull;
                            Binterest.TotalRows = (reader["TotalRows"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TotalRows")) : intnullVal;
                            Binterest.TotalPages = (reader["TotalPages"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TotalPages")) : intnullVal;
                            Binterest.fromcust_id = (reader["FromCust_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("FromCust_ID")) : Lnull;
                            Binterest.tocustid = (reader["ToCust_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ToCust_ID")) : Lnull;
                            Binterest.ExpressInterestID = (reader["ExpressInterestID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ExpressInterestID")) : intnullVal;
                            Binterest.PhotoCountnew = (reader["PhotoCountnew"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoCountnew")) : intnullVal;
                            Binterest.Toprofileid = (reader["Toprofileid"]) != DBNull.Value ? (reader.GetString(reader.GetOrdinal("Toprofileid"))).ToString() : null;
                            Binterest.ToName = (reader["ToName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToName")) : empty;
                            Binterest.ToApplicationPhoto = (reader["CustPhoto"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CustPhoto")) : empty;
                            Binterest.FromTicket = (reader["FromTicket"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("FromTicket")) : Lnull;
                            Binterest.ToTicket = (reader["ToTicket"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ToTicket")) : Lnull;
                            Binterest.fromticketid = (reader["fromticketid"]) != DBNull.Value ? (reader.GetString(reader.GetOrdinal("fromticketid"))).ToString() : empty;
                            Binterest.Toticketid = (reader["Toticketid"]) != DBNull.Value ? (reader.GetString(reader.GetOrdinal("Toticketid"))).ToString() : empty;
                            Binterest.ServiceDate = (reader["ServiceDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ServiceDate")).ToString() : empty;
                            Binterest.TOEmail = (reader["ToEmail"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToEmail")) : empty;
                            Binterest.ToMobileNumber = (reader["ToMobileNumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToMobileNumber")) : empty;
                            Binterest.ToMobileCountryCode = (reader["ToMobileCountryCode"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToMobileCountryCode")) : empty;
                            Binterest.FromticketStatusIDb = (reader["FromticketStatusID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromticketStatusID")) : string.Empty;
                            Binterest.ToticketStatusIDb = (reader["ToticketStatusID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToticketStatusID")) : string.Empty;
                            Binterest.FromTicketCreated = (reader["FromInterestDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromInterestDate")).ToString() : empty;
                            Binterest.ToTicketCreated = (reader["ToInterestDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToInterestDate")).ToString() : empty;
                            Binterest.FROMNEW = (reader["FROMNEW"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("FROMNEW")) : intnull;
                            Binterest.TONEW = (reader["TONEW"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TONEW")) : intnull;
                            //
                            Binterest.DOB = (reader["DOB"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("DOB")) : empty;
                            Binterest.ToB = (reader["TOB"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("TOB")) : empty;
                            Binterest.PlaceOfBirth = (reader["PlaceOfBirth"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PlaceOfBirth")) : empty;
                            Binterest.Gothram = (reader["Gothram"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Gothram")) : empty;
                            Binterest.Caste = (reader["Caste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Caste")) : empty;
                            Binterest.maritalstatus = (reader["maritalstatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("maritalstatus")) : empty;
                            Binterest.Color = (reader["Color"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Color")) : empty;
                            Binterest.Star = (reader["Star"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Star")) : empty;
                            Binterest.Height = (reader["Height"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Height")) : empty;
                            Binterest.EducationGroup = (reader["EducationGroup"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationGroup")) : empty;
                            Binterest.EduGroupnamenew = (reader["EduGroupnamenew"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EduGroupnamenew")) : empty;
                            Binterest.Profession = (reader["Profession"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Profession")) : empty;
                            Binterest.JobLocation = (reader["JobLocation"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("JobLocation")) : empty;
                            Binterest.Income = (reader["Income"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Income")) : empty;
                            Binterest.FFNative = (reader["FFNative"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FFNative")) : empty;
                            Binterest.MFNative = (reader["MFNative"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MFNative")) : empty;
                            Binterest.Property = (reader["Property"]) != DBNull.Value ? reader.GetDouble(reader.GetOrdinal("Property")) : fnull;
                            Binterest.Intercaste = (reader["Intercaste"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("Intercaste")) : bnul;
                            Binterest.fathercaste = (reader["fathercaste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("fathercaste")) : empty;
                            Binterest.mothercaste = (reader["mothercaste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("mothercaste")) : empty;
                            Binterest.CustPhoto = (reader["CustPhoto"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CustPhoto")) : empty;
                            Binterest.IsConfidential = (reader["IsConfidential"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("IsConfidential")) : bnul;
                            Binterest.SuperConfidentila = (reader["SuperConfidentila"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("SuperConfidentila")) : intnull;
                            Binterest.HoroscopeStatus = (reader["HoroscopeStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("HoroscopeStatus")) : intnull;
                            Binterest.KMPLID = (reader["KMPLID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("KMPLID")) : empty;
                            Binterest.Logid = (reader["Logid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Logid")) : Lnull;
                            Binterest.FromCust_InterestStatus = (reader["FromCust_InterestStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromCust_InterestStatus")) : empty;
                            Binterest.ToCust_InterestStatus = (reader["ToCust_InterestStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToCust_InterestStatus")) : empty;
                            Binterest.ISRvrSend = (reader["ISRvrSend"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ISRvrSend")) : intnull;
                            Binterest.PaidStatus = (reader["PaidStatus"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PaidStatus")) : empty;
                            Binterest.ApplicationPhoto = (reader["ApplicationPhoto"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ApplicationPhoto")) : empty;
                            Binterest.ProfileStatusID = (reader["ProfileStatusID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ProfileStatusID")) : intnull;


                        }
                        li.Add(Binterest);
                    }
                }
                objlist.Add(new BothsideInterestObjs { BothsideInterest = li });
                reader.NextResult();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        BothsideInterestserveice Binterest = new BothsideInterestserveice();
                        {
                            Binterest.FromEmail = (reader["Email"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Email")) : empty;
                            Binterest.FromMobileNumber = reader["MobileNumber"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("MobileNumber")) : empty;
                            Binterest.FromMobileCountryCode = reader["MobileCountryCode"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("MobileCountryCode")) : empty;
                            Binterest.ApplicationPhoto = reader["ApplicationPhoto"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ApplicationPhoto")) : empty;
                            Binterest.paid = reader["paid"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("paid")) : empty;
                            Binterest.FromProfileid = reader["Profileid"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Profileid")) : empty;
                            Binterest.FromName = reader["Name"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Name")) : empty;
                            Binterest.genderid = reader["Gender"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Gender")) : intnull;
                        }
                        li1.Add(Binterest);
                    }
                }
                objlist.Add(new BothsideInterestObjs { BothsideInterest = li1 });
                reader.Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }

            return objlist;
        }

        public int settledprofilesInsertionDal(SettledDeletedML Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[20];
            int status = 0;

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@BrideCustID", SqlDbType.BigInt);
                parm[0].Value = Mobj.BrideCustID;
                parm[1] = new SqlParameter("@BrideEmpID", SqlDbType.BigInt);
                parm[1].Value = Mobj.BrideEmpID;
                parm[2] = new SqlParameter("@GroomCustID", SqlDbType.BigInt);
                parm[2].Value = Mobj.GroomCustID;
                parm[3] = new SqlParameter("@GroomEmpID", SqlDbType.BigInt);
                parm[3].Value = Mobj.GroomEmpID;
                parm[4] = new SqlParameter("@Engagementdate", SqlDbType.DateTime);
                parm[4].Value = Mobj.Engagementdate;
                parm[5] = new SqlParameter("@EngagementVenue", SqlDbType.VarChar, 500);
                parm[5].Value = Mobj.EngagementVenue;
                parm[6] = new SqlParameter("@Marriagedate", SqlDbType.DateTime);
                parm[6].Value = Mobj.Marriagedate;
                parm[7] = new SqlParameter("@MarriageVenue", SqlDbType.VarChar, 500);
                parm[7].Value = Mobj.MarriageVenue;
                parm[8] = new SqlParameter("@InformedBySide", SqlDbType.Int);
                parm[8].Value = Mobj.InformedBySide;
                parm[9] = new SqlParameter("@InformedBy", SqlDbType.Int);
                parm[9].Value = Mobj.InformedBy;
                parm[10] = new SqlParameter("@Narriation", SqlDbType.VarChar, 8000);
                parm[10].Value = Mobj.Narriation;
                parm[11] = new SqlParameter("@EmpID", SqlDbType.BigInt);
                parm[11].Value = Mobj.EmpID;
                parm[12] = new SqlParameter("@AuthorizeStatus", SqlDbType.Int);
                parm[12].Value = Mobj.AuthorizeStatus;
                parm[13] = new SqlParameter("@Status", SqlDbType.Int);
                parm[13].Direction = ParameterDirection.Output;
                parm[14] = new SqlParameter("@rbnmail", SqlDbType.VarChar, 100);
                parm[14].Value = Mobj.SendMailfornew;

                //
                parm[15] = new SqlParameter("@Settleddate", SqlDbType.VarChar, 500);
                parm[15].Value = Mobj.Settleddate;

                DataSet ds = new DataSet();

                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(parm[13].Value.ToString(), System.DBNull.Value.ToString()) == 1)
                {
                    status = 1;
                }
                else
                {
                    status = Convert.ToInt32(parm[13].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return status;
        }

        public int deletedprofilesInsertionDal(SettledDeletedML Mobj, string spname)
        {
            DataSet ds = new DataSet();
            int status = 0;

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[20];
                parm[0] = new SqlParameter("@ProfileID", SqlDbType.BigInt);
                parm[0].Value = Mobj.Int64ProfileID;
                parm[1] = new SqlParameter("@SendEmail", SqlDbType.Int);
                parm[1].Value = Mobj.SendMail;
                parm[2] = new SqlParameter("@Engagementdate", SqlDbType.DateTime);
                parm[2].Value = Mobj.Engagementdate;
                parm[3] = new SqlParameter("@EngagementVenue", SqlDbType.VarChar, 500);
                parm[3].Value = Mobj.EngagementVenue;
                parm[4] = new SqlParameter("@Marriagedate", SqlDbType.DateTime);
                parm[4].Value = Mobj.Marriagedate;
                parm[5] = new SqlParameter("@MarriageVenue", SqlDbType.VarChar, 500);
                parm[5].Value = Mobj.MarriageVenue;
                parm[6] = new SqlParameter("@Surname", SqlDbType.VarChar, 250);
                parm[6].Value = Mobj.DelSurname;
                parm[7] = new SqlParameter("@Name", SqlDbType.VarChar, 250);
                parm[7].Value = Mobj.DelName1;
                parm[8] = new SqlParameter("@FatherName", SqlDbType.VarChar, 250);
                parm[8].Value = Mobj.DelFatherName;
                parm[9] = new SqlParameter("@Native", SqlDbType.VarChar, 250);
                parm[9].Value = Mobj.DelNative;
                parm[10] = new SqlParameter("@Education", SqlDbType.VarChar, 250);
                parm[10].Value = Mobj.DelEducation;
                parm[11] = new SqlParameter("@Profession", SqlDbType.VarChar, 250);
                parm[11].Value = Mobj.DelProfession;
                parm[12] = new SqlParameter("@ReasonForDelete", SqlDbType.Int);
                parm[12].Value = Mobj.DelReasonForDelete;
                parm[13] = new SqlParameter("@Relationship", SqlDbType.Int);
                parm[13].Value = Mobj.DelRelationship;
                parm[14] = new SqlParameter("@RelationshipName", SqlDbType.VarChar, 250);
                parm[14].Value = Mobj.DelRelationshipName;
                parm[15] = new SqlParameter("@Narriation", SqlDbType.VarChar, 8000);
                parm[15].Value = Mobj.Narriation;
                parm[16] = new SqlParameter("@EmpID", SqlDbType.BigInt);
                parm[16].Value = Mobj.EmpID;
                parm[17] = new SqlParameter("@AuthorizeStatus", SqlDbType.Int);
                parm[17].Value = Mobj.AuthorizeStatus;
                parm[18] = new SqlParameter("@Status", SqlDbType.Int);
                parm[18].Direction = ParameterDirection.Output;
                parm[19] = new SqlParameter("@rbnmail", SqlDbType.VarChar, 100);
                parm[19].Value = Mobj.SendMailfornew;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(parm[18].Value.ToString(), System.DBNull.Value.ToString()) == 1)
                {
                    status = 1;
                }
                else
                {
                    status = Convert.ToInt32(parm[18].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }

            return status;
        }

        public ArrayList AssignSettings(NoServiceML Mobj, string sp)
        {
            ArrayList arrayList = new ArrayList();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet dtAssignSettings = new DataSet();
            SqlDataAdapter daParentDetails = new SqlDataAdapter();
            try
            {
                SqlCommand cmd = new SqlCommand(sp, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_AppUserId", Mobj.EmpID);
                cmd.Parameters.AddWithValue("@i_ProfileId", Mobj.ProfileID);
                // cmd.Parameters.AddWithValue("@i_Gender", Mobj.Gender);
                // cmd.Parameters.AddWithValue("@i_isConfidential", Mobj.boolIsConfidential);
                // cmd.Parameters.AddWithValue("@dt_DateofRegistrationFrom", Mobj.FromDate);
                // cmd.Parameters.AddWithValue("@dt_DateofRegistrationTo", Mobj.ToDate);
                cmd.Parameters.AddWithValue("@t_CasteIds", Commonclass.returndt(Mobj.castes, Mobj.Caste, "CasteID", "CasteID"));
                cmd.Parameters.AddWithValue("@t_BranchIds", Commonclass.returndt(Mobj.branches, Mobj.Branch, "BranchID", "BranchID"));
                cmd.Parameters.AddWithValue("@t_StatusIds", Commonclass.returndt(Mobj.applicationstatus, Mobj.ApplicationStatus, "ApplicationStatusID", "ApplicationStatusID"));
                cmd.Parameters.AddWithValue("@i_PageSize", Mobj.PageSize);
                cmd.Parameters.AddWithValue("@i_PageNumber", Mobj.PageNumber);
                cmd.Parameters.AddWithValue("@i_StartIndex", Mobj.intlowerBound);
                cmd.Parameters.AddWithValue("@I_EndIndex", Mobj.intUpperBound);
                // cmd.Parameters.AddWithValue("@i_Payment", Mobj.PaymentStatus);
                daParentDetails.SelectCommand = cmd;
                daParentDetails.Fill(dtAssignSettings);
            }
            catch (Exception Ex)
            {
                Commonclass.ApplicationErrorLog(sp, Convert.ToString(Ex.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }

            return Commonclass.convertdataTableToArrayListTable(dtAssignSettings);
        }

        public ArrayList ReviewpendingReports(AssigningProfileML Mobj, string sp)
        {
            ArrayList arrayList = new ArrayList();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet dtreviewsettings = new DataSet();
            SqlDataAdapter dareview = new SqlDataAdapter();
            try
            {
                SqlCommand cmd = new SqlCommand(sp, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Empid", Mobj.EmpID);
                cmd.Parameters.AddWithValue("@t_genderId", Commonclass.returndt(Mobj.genderId, Mobj.Gender, "Gender", "Gender"));
                cmd.Parameters.AddWithValue("@t_isPaid", Commonclass.returndt(Mobj.isPaid, Mobj.paid, "Paid", "Paid"));
                cmd.Parameters.AddWithValue("@IsConfidential", Mobj.IsConfidential);
                cmd.Parameters.AddWithValue("@ReviewFromDate", Mobj.ReviewFromDate);
                cmd.Parameters.AddWithValue("@ReviewToDate", Mobj.ReviewToDate);
                cmd.Parameters.AddWithValue("@SectionID", Mobj.SectionID);
                cmd.Parameters.AddWithValue("@ReviewStatusID", Mobj.ReviewStatusID);
                cmd.Parameters.AddWithValue("@ISRegistarion", Mobj.ISRegistarion);
                cmd.Parameters.AddWithValue("@t_ProfileStatusID", Commonclass.returndt(Mobj.ProfileStatusID, Mobj.isProfileStatusID, "ProfileStatusID", "ProfileStatusID"));
                cmd.Parameters.AddWithValue("@t_Caste", Commonclass.returndt(Mobj.Casteid, Mobj.Caste, "Caste", "Caste"));
                cmd.Parameters.AddWithValue("@t_Branch", Commonclass.returndt(Mobj.Branchid, Mobj.Branch, "Branch", "Branch"));
                cmd.Parameters.AddWithValue("@t_ProfileReviewedEmpID", Commonclass.returndt(Mobj.ProfileReviewedEmpID, Mobj.ProfileReviewedEmp, "ProfileReviewedEmp", "ProfileReviewedEmp"));
                cmd.Parameters.AddWithValue("@i_region", Mobj.region);
                cmd.Parameters.AddWithValue("@i_PageFrom", Mobj.PageFrom);
                cmd.Parameters.AddWithValue("@i_PageTo", Mobj.PageTo);

                dareview.SelectCommand = cmd;
                dareview.Fill(dtreviewsettings);
            }
            catch (Exception Ex)
            {
                Commonclass.ApplicationErrorLog(sp, Convert.ToString(Ex.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }

            return Commonclass.convertdataTableToArrayListTable(dtreviewsettings);
        }

        public int? assignprofiles(assignprofiles assign, string spname)
        {
            SqlParameter[] Parm = new SqlParameter[3];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            int? intStatus = 0;
            try
            {
                Parm[0] = new SqlParameter("@t_ProfileOwners", SqlDbType.Structured);
                Parm[0].Value = assign.dtTableValues;
                Parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                Parm[1].Direction = ParameterDirection.Output;
                Parm[2] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
                Parm[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, Parm);

                if (string.Compare(System.DBNull.Value.ToString(), Convert.ToString(Parm[1].Value)) == 0)
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(Parm[1].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return intStatus;
        }

        public int? ReviewpendingReassign(Reviewpending Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[10];
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@CustID", SqlDbType.BigInt);
                parm[0].Value = Mobj.CustID;
                parm[1] = new SqlParameter("@EmpID", SqlDbType.VarChar);
                parm[1].Value = Mobj.EmpID;
                parm[2] = new SqlParameter("@i_Reviewpending", SqlDbType.BigInt);
                parm[2].Value = Mobj.i_Reviewpending;
                parm[3] = new SqlParameter("@Status", SqlDbType.Int);
                parm[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
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
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return intStatus;
        }

        public ArrayList getDuplicateProfilesDal(string profileID, string spname)
        {
            SqlParameter[] parm = new SqlParameter[1];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet ds = new DataSet();
            try
            {
                parm[0] = new SqlParameter("@strProfileID", SqlDbType.VarChar);
                parm[0].Value = profileID;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public ArrayList Guestticketcreation(guestticketcreation Mobj, string sp)
        {
            ArrayList arrayList = new ArrayList();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet guestticket = new DataSet();
            SqlDataAdapter dareview = new SqlDataAdapter();
            try
            {
                SqlCommand cmd = new SqlCommand(sp, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpID", Mobj.EmpID);
                cmd.Parameters.AddWithValue("@ProfileID", Mobj.ProfileID);
                cmd.Parameters.AddWithValue("@MobileNumber", Mobj.MobileNumber);
                cmd.Parameters.AddWithValue("@Email", Mobj.Email);
                SqlParameter outputParamStatus = cmd.Parameters.Add("@Status", SqlDbType.Int);
                outputParamStatus.Direction = ParameterDirection.Output;
                dareview.SelectCommand = cmd;
                dareview.Fill(guestticket);
            }
            catch (Exception Ex)
            {
                Commonclass.ApplicationErrorLog(sp, Convert.ToString(Ex.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }

            return Commonclass.convertdataTableToArrayListTable(guestticket);
        }

        public int ChangeEmployeePassword(int? EmpID, string EmpoldPassword, string EmpNewPassword, string spname)
        {
            SqlParameter[] parm = new SqlParameter[10];
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parm[0].Value = EmpID;
                parm[1] = new SqlParameter("@EmpoldPassword", SqlDbType.VarChar);
                parm[1].Value = EmpoldPassword;
                parm[2] = new SqlParameter("@EmpNewPassword", SqlDbType.VarChar);
                parm[2].Value = EmpNewPassword;
                parm[3] = new SqlParameter("@Status", SqlDbType.Int);
                parm[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
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
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return intStatus;
        }

        public ArrayList getmmSeriesDataDal(string profileID, int empid, string spname)
        {
            SqlParameter[] parm = new SqlParameter[2];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet ds = new DataSet();
            try
            {
                parm[0] = new SqlParameter("@ProfielD", SqlDbType.VarChar);
                parm[0].Value = profileID;
                parm[1] = new SqlParameter("@intEmpId", SqlDbType.Int);
                parm[1].Value = empid;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }

            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public int CheckemployeePassord(int? EmpID, string Emppassword, string spname)
        {
            SqlParameter[] parm = new SqlParameter[10];
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parm[0].Value = EmpID;
                parm[1] = new SqlParameter("@Password", SqlDbType.VarChar);
                parm[1].Value = Emppassword;
                parm[2] = new SqlParameter("@status", SqlDbType.Int);
                parm[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[2].Value.ToString()).Equals(0))
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
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return intStatus;
        }

        public int profileidexistornot(string profileid, string spname)
        {
            SqlParameter[] parm = new SqlParameter[10];
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@Profileid", SqlDbType.VarChar);
                parm[0].Value = profileid;
                parm[1] = new SqlParameter("@status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[1].Value.ToString()).Equals(0))
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
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return intStatus;
        }

        public ArrayList presentunpaidmember(int? empid, string spname)
        {
            SqlParameter[] parm = new SqlParameter[2];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet ds = new DataSet();
            try
            {
                parm[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parm[0].Value = empid;
                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }

            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public int UpadteMacAddess(string strProfileID, string ipaddresss2, int? BranchID, string spname)
        {
            SqlParameter[] parm = new SqlParameter[10];
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@v_IpAddress", SqlDbType.VarChar);
                parm[0].Value = strProfileID;
                parm[1] = new SqlParameter("@v_IpAddress_1", SqlDbType.VarChar);
                parm[1].Value = ipaddresss2;
                parm[2] = new SqlParameter("@i_BranchID", SqlDbType.Int);
                parm[2].Value = BranchID;
                parm[3] = new SqlParameter("@Status", SqlDbType.Int);
                parm[3].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
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
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return intStatus;
        }

        public ArrayList customermeassgeverification(messagesverification Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[10];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet ds = new DataSet();
            int intStatus = 0;
            try
            {
                parm[0] = new SqlParameter("@i_Type", SqlDbType.Int);
                parm[0].Value = Mobj.i_Type;
                parm[1] = new SqlParameter("@Body", SqlDbType.VarChar, 1000);
                parm[1].Value = Mobj.Body;
                parm[2] = new SqlParameter("@Subject", SqlDbType.VarChar, 1000);
                parm[2].Value = Mobj.Subject;
                parm[3] = new SqlParameter("@MessagesID", SqlDbType.BigInt);
                parm[3].Value = Mobj.MessagesID;
                parm[4] = new SqlParameter("@MessageStatusID", SqlDbType.Int);
                parm[4].Value = Mobj.MessageStatusID;
                parm[5] = new SqlParameter("@EmpID", SqlDbType.BigInt);
                parm[5].Value = Mobj.EmpID;
                parm[6] = new SqlParameter("@Status", SqlDbType.Int);
                parm[6].Direction = ParameterDirection.Output;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[6].Value.ToString()).Equals(0))
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[6].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public int updatecustomermessages(updatemessagesverification Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[12];
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@i_FromCustID", SqlDbType.BigInt);
                parm[0].Value = Mobj.FromCustID;
                parm[1] = new SqlParameter("@i_ToCustId", SqlDbType.BigInt);
                parm[1].Value = Mobj.ToCustID;
                parm[2] = new SqlParameter("@vc_Message", SqlDbType.NVarChar);
                parm[2].Value = Mobj.StrHtmlText;
                parm[3] = new SqlParameter("@i_MessageStatusId", SqlDbType.Int);
                parm[3].Value = Mobj.MessageStatusId;
                parm[4] = new SqlParameter("@i_EmpId", SqlDbType.BigInt);
                parm[4].Value = Mobj.EmpId;
                parm[5] = new SqlParameter("@b_ReadFlag", SqlDbType.Int);
                parm[5].Value = Mobj.ReadFlag;
                parm[6] = new SqlParameter("@i_messageHistoryId", SqlDbType.BigInt);
                parm[6].Value = Mobj.MessageHistoryId;
                parm[7] = new SqlParameter("@b_Accepted", SqlDbType.Int);
                parm[7].Value = Mobj.Accepted;
                parm[8] = new SqlParameter("@i_MessageLinkId", SqlDbType.BigInt);
                parm[8].Value = Mobj.MessageLinkId;
                parm[9] = new SqlParameter("@Status", SqlDbType.Int);
                parm[9].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[9].Value.ToString()).Equals(0))
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[9].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return intStatus;
        }

        public int Editpaymentpointexpdate(EditpaymentpointS Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[12];
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@intEmpId", SqlDbType.BigInt);
                parm[0].Value = Mobj.intEmpId;
                parm[1] = new SqlParameter("@intCust_Id", SqlDbType.Int);
                parm[1].Value = Mobj.intCust_Id;
                parm[2] = new SqlParameter("@strProfileId", SqlDbType.VarChar);
                parm[2].Value = Mobj.strProfileId;
                parm[3] = new SqlParameter("@Allowed_Points", SqlDbType.Int);
                parm[3].Value = Mobj.Allowed_Points;
                parm[4] = new SqlParameter("@Allowed_Days", SqlDbType.Int);
                parm[4].Value = Mobj.Allowed_Days;
                parm[5] = new SqlParameter("@Old_ExpiryDate", SqlDbType.DateTime);
                parm[5].Value = Mobj.Old_ExpiryDate;
                parm[6] = new SqlParameter("@Status", SqlDbType.Int);
                parm[6].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[6].Value.ToString()).Equals(0))
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[6].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return intStatus;
        }

        public ArrayList Paymentexentionpointsdays(string Profileid, string spname)
        {
            SqlParameter[] parm = new SqlParameter[3];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet ds = new DataSet();
            try
            {
                parm[0] = new SqlParameter("@strProfileID", SqlDbType.VarChar);
                parm[0].Value = Profileid;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public ArrayList authorizationpaymentamoutReport(authorizationpayment Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[8];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet ds = new DataSet();
            try
            {
                parm[0] = new SqlParameter("@intRegional", SqlDbType.Int);
                parm[0].Value = Mobj.intRegional;
                parm[1] = new SqlParameter("@intBranch", SqlDbType.VarChar);
                parm[1].Value = Mobj.intBranch;
                parm[2] = new SqlParameter("@intEmpID", SqlDbType.VarChar);
                parm[2].Value = Mobj.intEmpID;
                parm[3] = new SqlParameter("@dtStartDate", SqlDbType.DateTime);
                parm[3].Value = Mobj.dtStartDate;
                parm[4] = new SqlParameter("@dtEndDate", SqlDbType.DateTime);
                parm[4].Value = Mobj.dtEndDate;
                parm[5] = new SqlParameter("@intTicketVerified", SqlDbType.Int);
                parm[5].Value = Mobj.intTicketVerified;
                parm[6] = new SqlParameter("@intMarked", SqlDbType.Int);
                parm[6].Value = Mobj.intMarked;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public int Editpayment(employeepaymentedit Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[8];
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@intempid", SqlDbType.Int);
                parm[0].Value = Mobj.Empid;
                parm[1] = new SqlParameter("@intpaymentid", SqlDbType.Int);
                parm[1].Value = Mobj.intpaymentid;
                parm[2] = new SqlParameter("@intPaymentHisId", SqlDbType.Int);
                parm[2].Value = Mobj.intPaymentHisId;
                parm[3] = new SqlParameter("@strprofileid", SqlDbType.VarChar);
                parm[3].Value = Mobj.ProfileID;
                parm[4] = new SqlParameter("@decgreedAmount", SqlDbType.Decimal);
                parm[4].Value = Mobj.decgreedAmount;
                parm[5] = new SqlParameter("@decPaidAmount", SqlDbType.Decimal);
                parm[5].Value = Mobj.decPaidAmount;
                parm[6] = new SqlParameter("@strPaydescription", SqlDbType.VarChar);
                parm[6].Value = Mobj.strPaydescription;
                parm[7] = new SqlParameter("@Status", SqlDbType.Int);
                parm[7].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[7].Value.ToString()).Equals(0))
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[7].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return intStatus;
        }

        public int InsertEmailBouceEntry(insertemailsbounce Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[15];
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@ProfileID", SqlDbType.VarChar, 20);
                parm[0].Value = Mobj.profileID;
                parm[1] = new SqlParameter("@EmailID", SqlDbType.VarChar, 100);
                parm[1].Value = Mobj.EmailID;
                parm[2] = new SqlParameter("@CategoryID", SqlDbType.Int);
                parm[2].Value = Mobj.CategoryID;
                parm[3] = new SqlParameter("@Bounce_From_date", SqlDbType.DateTime);
                parm[3].Value = Mobj.Bounce_From_date;
                parm[4] = new SqlParameter("@Email_Sent_From_Date", SqlDbType.DateTime);
                parm[4].Value = Mobj.Email_Sent_From_Date;
                parm[5] = new SqlParameter("@Narration_date", SqlDbType.DateTime);
                parm[5].Value = Mobj.Narration_Date;
                parm[6] = new SqlParameter("@Narration", SqlDbType.VarChar, 4000);
                parm[6].Value = Mobj.Narration;
                parm[7] = new SqlParameter("@EnteredbyEmpID", SqlDbType.BigInt);
                parm[7].Value = Mobj.EnteredbyEmpID;
                parm[8] = new SqlParameter("@Status", SqlDbType.Bit);
                parm[8].Value = Mobj.status;
                parm[9] = new SqlParameter("@rtnstatus", SqlDbType.Int);
                parm[9].Direction = ParameterDirection.Output;
                parm[10] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 4000);
                parm[10].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[9].Value.ToString()).Equals(0))
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[9].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return intStatus;
        }

        public int existanceprofileornot(string profileid, string spname)
        {
            SqlParameter[] parm = new SqlParameter[4];
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@ProfileID", SqlDbType.VarChar, 20);
                parm[0].Value = profileid;
                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[1].Value.ToString()).Equals(0))
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
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return intStatus;
        }

        public ArrayList EmplyeepaymentReportspayment(paymentreports Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[30];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter daParentDetails = new SqlDataAdapter();
            try
            {
                SqlCommand cmd = new SqlCommand(spname, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@vc_ProfileId", Mobj.StrProfileID);
                cmd.Parameters.AddWithValue("@b_IsAdmin", Mobj.IsAdmin);
                cmd.Parameters.AddWithValue("@i_Gender", Mobj.Gender);
                cmd.Parameters.AddWithValue("@i_PaymentType", Mobj.PaymenytStatus);
                cmd.Parameters.AddWithValue("@i_Region", Mobj.Region);
                cmd.Parameters.AddWithValue("@b_IsConfidential", Mobj.Confidential);
                cmd.Parameters.AddWithValue("@b_IsBalance", Mobj.IsAmountThere);
                cmd.Parameters.AddWithValue("@t_ProfileOwnerId", Commonclass.returndt(Mobj.profileownerid, Mobj.OwnerOFProfile, "ProfileOwner", "ProfileOwner"));
                cmd.Parameters.AddWithValue("@t_ApplicationStatus", Commonclass.returndt(Mobj.ApplicationStatusid, Mobj.ApplicationStatus, "Applicationstatus", "Applicationstatus"));
                cmd.Parameters.AddWithValue("@i_PaidFrom", Mobj.FromAmount);
                cmd.Parameters.AddWithValue("@i_PaidTo", Mobj.ToAmount);
                cmd.Parameters.AddWithValue("@t_Caste", Commonclass.returndt(Mobj.Casteid, Mobj.Caste, "Caste", "Caste"));
                cmd.Parameters.AddWithValue("@t_Branch", Commonclass.returndt(Mobj.Branchid, Mobj.Branch, "Branch", "Branch"));
                cmd.Parameters.AddWithValue("@dt_PaymentStartDate", Mobj.StartDate);
                cmd.Parameters.AddWithValue("@dt_PaymentEndDate", Mobj.EndDate);
                cmd.Parameters.AddWithValue("@i_StartIndex", Mobj.From);
                cmd.Parameters.AddWithValue("@i_EndIndex", Mobj.To);
                cmd.Parameters.AddWithValue("@_Excel", Mobj.flag);
                cmd.Parameters.AddWithValue("@ModeOfPaymentID", Mobj.ModeOfPaymentID);
                daParentDetails.SelectCommand = cmd;
                daParentDetails.Fill(ds);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public int SendMailRegidtrationFeeDetails(long? CustID, string spname)
        {
            SqlParameter[] param = new SqlParameter[4];
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                param[0] = new SqlParameter("@CustID", SqlDbType.BigInt);
                param[0].Value = CustID;
                param[1] = new SqlParameter("@Status", SqlDbType.Int);
                param[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, param);
                if (string.Compare(System.DBNull.Value.ToString(), param[1].Value.ToString()).Equals(0))
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(param[1].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return intStatus;
        }

        public int EmployeepaymentreportsSendsms(paymentreportsms Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[10];
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@CategoryID", SqlDbType.Int);
                parm[0].Value = Mobj.CategoryID;
                parm[1] = new SqlParameter("@Message", SqlDbType.VarChar, 8000);
                parm[1].Value = Mobj.MessageText;
                parm[2] = new SqlParameter("@FromEmp", SqlDbType.BigInt);
                parm[2].Value = Mobj.FromEmpID;
                parm[3] = new SqlParameter("@ToEmp", SqlDbType.BigInt);
                parm[3].Value = Mobj.ToEmpID;
                parm[4] = new SqlParameter("@CustID", SqlDbType.BigInt);
                parm[4].Value = Mobj.CustID;
                parm[5] = new SqlParameter("@Status", SqlDbType.Int);
                parm[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[5].Value.ToString()).Equals(0))
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[5].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return intStatus;
        }

        public ArrayList Paymentoffersbasedonselect(string Profileid, int? casteid, string spname)
        {
            SqlParameter[] parm = new SqlParameter[8];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet ds = new DataSet();
            try
            {
                parm[0] = new SqlParameter("@strProfileid", SqlDbType.VarChar);
                parm[0].Value = Profileid;
                parm[1] = new SqlParameter("@strCaste", SqlDbType.Int);
                parm[1].Value = casteid;

                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public int Editanddeleteupdateoffers(paymenteditdelete Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[10];
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@strProfileID", SqlDbType.VarChar);
                parm[0].Value = Mobj.strProfileID;
                parm[1] = new SqlParameter("@intPaymentID", SqlDbType.Int);
                parm[1].Value = Mobj.intPaymentID;
                parm[2] = new SqlParameter("@intMemberShipTypeID", SqlDbType.Int);
                parm[2].Value = Mobj.intMemberShipTypeID;
                parm[3] = new SqlParameter("@floatAgreedAmt", SqlDbType.Decimal);
                parm[3].Value = Mobj.floatAgreedAmt;
                parm[4] = new SqlParameter("@intCasteID", SqlDbType.Int);
                parm[4].Value = Mobj.intCasteID;
                parm[5] = new SqlParameter("@intFlagID", SqlDbType.Int);
                parm[5].Value = Mobj.intFlagID;
                parm[6] = new SqlParameter("@intStatus", SqlDbType.Int);
                parm[6].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[6].Value.ToString()).Equals(0))
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[6].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return intStatus;
        }

        /// <summary>
        /// A.Lakshmi---07-08-2017
        /// </summary>
        /// <param name="profileid">profileid--varchar</param>
        /// <returns>int---status</returns>
        /// To get Status of Profileid for Fact sheeet
        public int VerifyProfileid(string profileid, string spname)
        {
            SqlParameter[] parm = new SqlParameter[10];
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@vc_ProfileID", SqlDbType.VarChar);
                parm[0].Value = profileid;
                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[1].Value.ToString()).Equals(0))
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
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return intStatus;
        }

        /// <summary>
        /// A.Lakshmi---07-08-2017
        /// </summary>
        /// <param name="profileid">profileid--varchar</param>
        /// <returns>ArrayList</returns>
        /// To get Factsheetdetails of Profileid
        public ArrayList CustomerFactsheetDetails(string Profileid, string spname)
        {
            SqlParameter[] parm = new SqlParameter[2];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet ds = new DataSet();
            try
            {
                parm[0] = new SqlParameter("@i_custID1", SqlDbType.VarChar);
                parm[0].Value = Profileid;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        /// <summary>
        /// A.Lakshmi---07-08-2017
        /// </summary>
        /// <param name="profileid">profileid--varchar</param>
        /// <returns>int status</returns>
        /// To get Factsheet email status
        public int custmorfactsheetsendMail(string profileid, string spname)
        {
            SqlParameter[] parm = new SqlParameter[4];
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@ProfileID", SqlDbType.VarChar);
                parm[0].Value = profileid;
                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[1].Value.ToString()).Equals(0))
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
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return intStatus;
        }

        /// <summary>
        /// A.Lakshmi---07-08-2017
        /// </summary>
        /// <param name="profileid">profileid--varchar</param>
        ///    /// <param name="Encryptedtext">Encryptedtext--encrypted profileid</param>
        /// <returns>int status</returns>
        /// To send Factsheet email
        public int? sendEmail_factResetPassword(string profileid, string Encryptedtext, string spName)
        {
            int? status = 0;

            SqlDataReader reader;
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                SqlParameter[] parm = new SqlParameter[5];
                parm[0] = new SqlParameter("@PROFILEID", SqlDbType.VarChar);
                parm[0].Value = profileid;
                parm[1] = new SqlParameter("@EncryptedText", SqlDbType.VarChar);
                parm[1].Value = Encryptedtext;
                parm[2] = new SqlParameter("@Status", SqlDbType.Int);
                parm[2].Direction = ParameterDirection.Output;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        li.Clear();
                        Smtpemailsending smtp = new Smtpemailsending();
                        {
                            smtp.profile_name = (reader["profile_name"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("profile_name")) : string.Empty;
                            smtp.recipients = (reader["recipients"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("recipients")) : string.Empty;
                            smtp.body = (reader["body"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("body")) : string.Empty;
                            smtp.subject = (reader["subject"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("subject")) : string.Empty;
                            smtp.body_format = (reader["body_format"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("body_format")) : string.Empty;
                            status = smtp.Status = (reader["Status"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Status")) : status;
                        }
                        li.Add(smtp);
                        Commonclass.SendMailSmtpMethod(li, "exp");
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(ex.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }

            return status;
        }

        /// <summary>
        /// A.Lakshmi---07-08-2017
        /// </summary>
        /// <param name="profileid">profileid--varchar</param>
        ///    /// <param name="Encryptedtext">Encryptedtext--encrypted profileid</param>
        /// <returns>int status</returns>
        /// To send forget password email
        public int? sendEmail_ResetPassword(string profileid, string spname)
        {
            SqlDataReader reader;
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            SqlParameter[] parm = new SqlParameter[4];
            int? intStatus = 0;
            Smtpemailsending smtp = new Smtpemailsending();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@ProfileID", SqlDbType.VarChar);
                parm[0].Value = profileid;
                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spname, parm);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        li.Clear();

                        smtp.profile_name = (reader["profile_name"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("profile_name")) : string.Empty;
                        smtp.recipients = (reader["recipients"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("recipients")) : string.Empty;
                        smtp.body = (reader["body"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("body")) : string.Empty;
                        smtp.subject = (reader["subject"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("subject")) : string.Empty;
                        smtp.body_format = (reader["body_format"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("body_format")) : string.Empty;
                        smtp.Status = (reader["Status"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Status")) : intStatus;
                        li.Add(smtp);
                        Commonclass.SendMailSmtpMethod(li, "exp");
                    }
                }
                intStatus = smtp.Status;
                reader.Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return intStatus;
        }

        public int Successstoriesupload(emplyeeSuccessStoryML Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[15];
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@EmpID", SqlDbType.BigInt);
                parm[0].Value = Mobj.EmpID;

                parm[1] = new SqlParameter("@BrideID", SqlDbType.BigInt);
                parm[1].Value = Mobj.BrideID;
                parm[2] = new SqlParameter("@Bridename", SqlDbType.VarChar, 250);
                parm[2].Value = Mobj.Bridename;
                parm[3] = new SqlParameter("@GroomID", SqlDbType.BigInt);
                parm[3].Value = Mobj.GroomID;
                parm[4] = new SqlParameter("@Groomname", SqlDbType.VarChar, 500);
                parm[4].Value = Mobj.Groomname;
                parm[5] = new SqlParameter("@Engagementdate", SqlDbType.DateTime);
                parm[5].Value = Mobj.StartDate;
                parm[6] = new SqlParameter("@Marriagedate", SqlDbType.DateTime);
                parm[6].Value = Mobj.EndDate;

                parm[7] = new SqlParameter("@Attachphoto", SqlDbType.VarChar, 500);
                parm[7].Value = Mobj.Attachphoto;

                parm[8] = new SqlParameter("@Successstory", SqlDbType.VarChar, 500);
                parm[8].Value = Mobj.SuccesSstory;

                parm[9] = new SqlParameter("@DisplayInWeb", SqlDbType.Bit);
                parm[9].Value = Mobj.Displayinweb;

                parm[10] = new SqlParameter("@flag", SqlDbType.Int);
                parm[10].Value = Mobj.flag;

                parm[11] = new SqlParameter("@Successstory_ID", SqlDbType.VarChar, 500);
                parm[11].Value = Mobj.strSuccessstories;

                parm[12] = new SqlParameter("@status", SqlDbType.Int);
                parm[12].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[12].Value.ToString()).Equals(0))
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[12].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return intStatus;
        }

        public int? Marketingticketstatus(long? ticketid, string EmpID, string spname)
        {
            SqlParameter[] parm = new SqlParameter[5];
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@intTicketID", SqlDbType.BigInt);
                parm[0].Value = ticketid;
                parm[1] = new SqlParameter("@intEmpID", SqlDbType.VarChar);
                parm[1].Value = EmpID;
                parm[2] = new SqlParameter("@Status", SqlDbType.Int);
                parm[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[2].Value.ToString()).Equals(0))
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
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return intStatus;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="i_EmpID"></param>
        /// <param name="i_BranchID"></param>
        /// <param name="v_MacAddress"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public ArrayList AdminReportsAllProfiles(int? i_EmpID, string i_BranchID, int? i_Region, string v_MacAddress, int? flag, string v_ProfileOwnerEmpID, string spname)
        {
            SqlParameter[] parm = new SqlParameter[7];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet ds = new DataSet();
            try
            {
                parm[0] = new SqlParameter("@i_EmpID", SqlDbType.Int);
                parm[0].Value = i_EmpID;
                parm[1] = new SqlParameter("@i_BranchID", SqlDbType.VarChar);
                parm[1].Value = i_BranchID;
                parm[2] = new SqlParameter("@i_Region", SqlDbType.Int);
                parm[2].Value = i_Region;
                parm[3] = new SqlParameter("@v_MacAddress", SqlDbType.VarChar);
                parm[3].Value = v_MacAddress;
                parm[4] = new SqlParameter("@flag", SqlDbType.Int);
                parm[4].Value = flag;
                parm[5] = new SqlParameter("@v_ProfileOwnerEmpID", SqlDbType.VarChar);
                parm[5].Value = v_ProfileOwnerEmpID;

                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public ArrayList CheckSurNameNamedob(string strSurName, string StrName, DateTime? dtDOB, string spname)
        {
            ArrayList arrayList = new ArrayList();
            SqlParameter[] parm = new SqlParameter[8];
            int? intStatus = 0;
            responsechksurname response = null;
            SqlDataReader reader;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@strSurName", SqlDbType.VarChar);
                parm[0].Value = strSurName;
                parm[1] = new SqlParameter("@StrName", SqlDbType.VarChar);
                parm[1].Value = StrName;
                parm[2] = new SqlParameter("@dtDOB", SqlDbType.DateTime);
                parm[2].Value = dtDOB;
                parm[3] = new SqlParameter("@Status", SqlDbType.Int);
                parm[3].Direction = ParameterDirection.Output;
                parm[4] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
                parm[4].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spname, parm);
                int count = reader.FieldCount;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        response = new responsechksurname();
                        {
                            response.Profileid = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : string.Empty;
                            response.Name = (reader["FirstName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FirstName")) : string.Empty;
                            response.Surname = (reader["LastName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("LastName")) : string.Empty;
                            response.Status = (reader["Status"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Status")) : intStatus;
                            arrayList.Add(response);
                        }
                    }
                }

                reader.Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return arrayList;
        }

        public int? InsertResonForNoService(insetnoserice Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[10];
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@intCust_ID", SqlDbType.Int);
                parm[0].Value = Mobj.intCust_ID;
                parm[1] = new SqlParameter("@strProfileID", SqlDbType.VarChar);
                parm[1].Value = Mobj.strProfileID;
                parm[2] = new SqlParameter("@intTicketOwnerID", SqlDbType.Int);
                parm[2].Value = Mobj.intTicketOwnerID;
                parm[3] = new SqlParameter("@strReason", SqlDbType.VarChar);
                parm[3].Value = Mobj.strReason;
                parm[4] = new SqlParameter("@intEnteredBy", SqlDbType.Int);
                parm[4].Value = Mobj.intEnteredBy;
                parm[5] = new SqlParameter("@Status", SqlDbType.Int);
                parm[5].Direction = ParameterDirection.Output;
                parm[6] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
                parm[6].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[5].Value.ToString()).Equals(0))
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[5].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return intStatus;
        }

        public ArrayList Nomatchesreasons(nomatchesreason Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[12];
            ArrayList arrayList = new ArrayList();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            int intStatus = 0;
            DataSet ds = new DataSet();
            try
            {
                parm[0] = new SqlParameter("@v_EmpID", SqlDbType.VarChar);
                parm[0].Value = Mobj.v_EmpID;
                parm[1] = new SqlParameter("@i_Region", SqlDbType.Int);
                parm[1].Value = Mobj.i_Region;
                parm[2] = new SqlParameter("@v_Branch", SqlDbType.VarChar);
                parm[2].Value = Mobj.v_Branch;
                parm[3] = new SqlParameter("@i_flag", SqlDbType.Int);
                parm[3].Value = Mobj.i_flag;
                parm[4] = new SqlParameter("@i_Cust_ID", SqlDbType.Int);
                parm[4].Value = Mobj.i_Cust_ID;
                parm[5] = new SqlParameter("@v_Reason", SqlDbType.VarChar);
                parm[5].Value = Mobj.v_Reason;
                parm[6] = new SqlParameter("@i_Authorized", SqlDbType.Int);
                parm[6].Value = Mobj.i_Authorized;

                parm[7] = new SqlParameter("@i_Startindex", SqlDbType.Int);
                parm[7].Value = Mobj.startindex;
                parm[8] = new SqlParameter("@i_EndIndex", SqlDbType.Int);
                parm[8].Value = Mobj.endindex;

                parm[9] = new SqlParameter("@Status", SqlDbType.Int);
                parm[9].Direction = ParameterDirection.Output;

                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (Mobj.i_flag == 1 || Mobj.i_flag == 2 || Mobj.i_flag == 3)
                {
                    if (string.Compare(System.DBNull.Value.ToString(), parm[9].Value.ToString()).Equals(0))
                    {
                        intStatus = 0;
                    }
                    else
                    {
                        intStatus = Convert.ToInt32(parm[9].Value);
                    }
                    arrayList.Add(intStatus);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Mobj.i_flag == 1 || Mobj.i_flag == 2 || Mobj.i_flag == 3 ? arrayList : Commonclass.convertdataTableToArrayListTable(ds);
        }

        public ArrayList Oldkmplkeywordlikesearch(CreateKeywordLlikesearchReqoldkmpl oldkmpl, string spname)
        {
            SqlParameter[] parm = new SqlParameter[7];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet ds = new DataSet();
            try
            {
                parm[0] = new SqlParameter("@TblDetails", SqlDbType.Structured);
                parm[0].Value = oldkmpl.dtPartnerPreference;
                parm[1] = new SqlParameter("@intEmpID", SqlDbType.Int);
                parm[1].Value = oldkmpl.EmpID;
                parm[2] = new SqlParameter("@i_Startindex", SqlDbType.Int);
                parm[2].Value = oldkmpl.startindex;
                parm[3] = new SqlParameter("@i_EndIndex", SqlDbType.Int);
                parm[3].Value = oldkmpl.EndIndex;
                parm[4] = new SqlParameter("@Status", SqlDbType.Int);
                parm[4].Direction = ParameterDirection.Output;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public List<GetRegprofilevalidationtable> RegistrationValidation_Table(Regprofilevalidation partnerdata, string spName)
        {
            List<GetRegprofilevalidationtable> details = new List<GetRegprofilevalidationtable>();
            SqlDataReader reader;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string Snull = "--";
            int? inull = null;
            Int64? Lnull = null;
            int status = 0;
            string empty = "--";
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                SqlParameter[] parm = new SqlParameter[20];

                parm[0] = new SqlParameter("@strMFFNativePlace", SqlDbType.VarChar);
                parm[0].Value = partnerdata.strMFFNativePlace;
                parm[1] = new SqlParameter("@strFatherName", SqlDbType.VarChar);
                parm[1].Value = partnerdata.strFatherName;
                parm[2] = new SqlParameter("@strMotherName", SqlDbType.VarChar);
                parm[2].Value = partnerdata.strMotherName;
                parm[3] = new SqlParameter("@strFFName", SqlDbType.VarChar);
                parm[3].Value = partnerdata.strFFName;
                parm[4] = new SqlParameter("@strMFName", SqlDbType.VarChar);
                parm[4].Value = partnerdata.strMFName;
                parm[5] = new SqlParameter("@strMFSurName", SqlDbType.VarChar);
                parm[5].Value = partnerdata.strMFSurName;
                parm[6] = new SqlParameter("@strCustSurName", SqlDbType.VarChar);
                parm[6].Value = partnerdata.strCustSurName;
                parm[7] = new SqlParameter("@strCustName", SqlDbType.VarChar);
                parm[7].Value = partnerdata.strCustName;
                parm[8] = new SqlParameter("@strCaste", SqlDbType.VarChar);
                parm[8].Value = partnerdata.strCaste;
                parm[9] = new SqlParameter("@strAllPhones", SqlDbType.VarChar);
                parm[9].Value = partnerdata.strAllPhones;
                parm[10] = new SqlParameter("@strAllEmailIds", SqlDbType.VarChar);
                parm[10].Value = partnerdata.strAllEmailIds;
                parm[11] = new SqlParameter("@intAppicationStatusID", SqlDbType.Int);
                parm[11].Value = partnerdata.intAppicationStatusID;
                parm[12] = new SqlParameter("@intEmpID", SqlDbType.Int);
                parm[12].Value = partnerdata.intEmpID;
                parm[13] = new SqlParameter("@i_Startindex", SqlDbType.Int);
                parm[13].Value = partnerdata.i_Startindex;
                parm[14] = new SqlParameter("@i_EndIndex", SqlDbType.Int);
                parm[14].Value = partnerdata.i_EndIndex;
                parm[15] = new SqlParameter("@intGenderID", SqlDbType.Int);
                parm[15].Value = partnerdata.intGenderID;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        GetRegprofilevalidationtable sh = new GetRegprofilevalidationtable();
                        {
                            sh.ViewfullProfileID = reader["ProfileID"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : Snull;
                            sh.ProfileID = reader["ViewfullProfileID"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ViewfullProfileID")) : Snull;
                            sh.FirstName = reader["FirstName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("FirstName")) : Snull;
                            sh.LastName = reader["LastName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("LastName")) : Snull;
                            sh.Caste = reader["CasteName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("CasteName")) : Snull;
                            sh.DOR = reader["DOR"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("DOR")) : Snull;
                            sh.BranchCode = reader["BranchCode"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("BranchCode")) : Snull;
                            sh.ProfileOwner = reader["ProfileOwner"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileOwner")) : Snull;
                            sh.TotalRows = reader["TotalRows"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TotalRows")) : inull;
                            sh.TotalPages = reader["TotalPages"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TotalPages")) : inull;
                            sh.ProfileStatusID = reader["ProfileStatusID"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileStatusID")) : Snull;
                            //sh.ActiveCount = reader["ActiveCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ActiveCount")) : inull;
                            //sh.DeletedCount = reader["DeletedCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("DeletedCount")) : inull;
                            //sh.SettledCount = reader["SettledCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("SettledCount")) : inull;
                            //sh.InActiveCount = reader["InActiveCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("InActiveCount")) : inull;
                            //sh.MMSerious = reader["MMSerious"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("MMSerious")) : inull;
                            sh.TicketID = reader["TicketID"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("TicketID")) : Lnull;
                            sh.TicketHistoryID = reader["TicketHisID"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("TicketHisID")) : Snull;
                            sh.paid = reader["PaidStatus"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PaidStatus")) : inull;
                            sh.Cust_ID = reader["cust_id"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("cust_id")) : Lnull;
                            sh.Emp_Ticket_ID = (reader["Emp_Ticket_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Emp_Ticket_ID")) : Lnull;
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
            }

            status = 1;
            return details;
        }

        public List<MarketingTicketResponseHistory> MarketingTickethistory(long? Ticketid, char Type, string spName)
        {
            List<MarketingTicketResponseHistory> details = new List<MarketingTicketResponseHistory>();
            SqlDataReader reader;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string Snull = "--";
            DateTime? dtTime = null;
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
                        MarketingTicketResponseHistory Marketing = new MarketingTicketResponseHistory();
                        {
                            Marketing.TicketType = reader["TicketType"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("TicketType")) : Snull;
                            Marketing.ReplyDatenew = reader["ReplyDatenew"] != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("ReplyDatenew")) : dtTime;
                            Marketing.ReplyDate = reader["ReplyDate"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ReplyDate")) : null;
                            Marketing.NAME = reader["NAME"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("NAME")) : Snull;
                            Marketing.CallStatus = reader["CallStatus"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("CallStatus"))).ToString() : Snull;
                            Marketing.CallReceivedBy = reader["CallReceivedBy"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("CallReceivedBy"))).ToString() : Snull;
                            Marketing.RelationShip = reader["RelationShip"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("RelationShip"))).ToString() : Snull;
                            Marketing.ReplyDesc = reader["ReplyDesc"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("ReplyDesc"))).ToString() : Snull;
                            Marketing.MatchmeetingStatus = reader["MatchmeetingStatus"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("MatchmeetingStatus")) : Snull;
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
            }

            return details;
        }

        public List<EmpNotifications> employeenotications(EmpNotifications Notification, string spName)
        {
            List<EmpNotifications> details = new List<EmpNotifications>();
            SqlDataReader reader;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            int? iNull = null;
            Int64? lnull = null;
            try
            {
                SqlParameter[] parm = new SqlParameter[6];
                parm[0] = new SqlParameter("@EmpID", SqlDbType.Int);
                parm[0].Value = Notification.iEmpID;

                parm[1] = new SqlParameter("@i_display", SqlDbType.Int);
                parm[1].Value = Notification.i_display;

                parm[2] = new SqlParameter("@i_NotificationID", SqlDbType.Int);
                parm[2].Value = Notification.iNotificationID;
                parm[3] = new SqlParameter("@i_CategoryID", SqlDbType.Int);
                parm[3].Value = Notification.CategoryID;
                parm[4] = new SqlParameter("@CustID", SqlDbType.Int);
                parm[4].Value = !string.IsNullOrEmpty(Notification.strProfileID) ? Convert.ToInt32((Notification.strProfileID)) : iNull;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        EmpNotifications display = new EmpNotifications();
                        {
                            display.strActionName = reader["ActionName"] != DBNull.Value ? reader["ActionName"].ToString() : null;
                            display.strProfileID = reader["ProfileID"] != DBNull.Value ? reader["ProfileID"].ToString() : null;
                            display.strCustomerName = reader["CustomerName"] != DBNull.Value ? reader["CustomerName"].ToString() : null;
                            display.iNotificationID = reader["NotificationID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("NotificationID")) : iNull;
                            display.strCustomerPhoto = reader["CustomerPhoto"] != DBNull.Value ? reader["CustomerPhoto"].ToString() : null;
                            display.NotifyCount = reader["NotifyCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("NotifyCount")) : iNull;
                            display.CategoryID = reader["CategoryID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CategoryID")) : iNull;
                            display.ICustID = reader["Cust_ID"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_ID")) : lnull;
                        }
                        details.Add(display);
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
            }

            return details;
        }

        public int? notviewedprofilesemails(ExpressInterestInsert Mobj, string spName)
        {
            int? Istatus = null;
            int? intStatus = 0;

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            SqlDataReader reader;

            SqlParameter[] parm = new SqlParameter[10];
            try
            {
                parm[0] = new SqlParameter("@TblDetails", SqlDbType.Structured);
                parm[0].Value = Mobj.dtExpInt;
                parm[1] = new SqlParameter("@empid", SqlDbType.BigInt);
                parm[1].Value = Mobj.EmpID;

                parm[2] = new SqlParameter("@Status", SqlDbType.Int);
                parm[2].Direction = ParameterDirection.Output;
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
                if (li.Count > 0)
                {
                    Commonclass.SendMailSmtpMethod(li, "info");
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return intStatus;
        }

        public int? noserviceemailsfromcustomer(string profileid, int? empid, string spName)
        {
            int? Istatus = null;
            Int64? lnull = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            SqlDataReader reader;

            SqlParameter[] parm = new SqlParameter[5];
            try
            {
                parm[0] = new SqlParameter("@Profileid", SqlDbType.VarChar);
                parm[0].Value = profileid;
                parm[1] = new SqlParameter("@EmpID", SqlDbType.Int);
                parm[1].Value = empid;

                List<Smtpemailsending> li = new List<Smtpemailsending>();
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                List<notviewedprofiles> notviewd = new List<notviewedprofiles>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        notviewedprofiles noservice = new notviewedprofiles();
                        {
                            noservice.FromProfileID = (reader["FromProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromProfileID")) : string.Empty;
                            noservice.ToProfileID = (reader["ToProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToProfileID")) : string.Empty;
                            noservice.FromCustID = (reader["FromCustID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("FromCustID")) : lnull;
                            noservice.ToCustID = (reader["ToCustID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ToCustID")) : lnull;
                        }
                        notviewd.Add(noservice);
                    }
                }
                reader.Close();

                DataTable dtExpress = new DataTable();
                ExpressInterestInsert EXI = new ExpressInterestInsert();
                EXI.EmpID = empid;
                dtExpress = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtExpressInterestTable(), notviewd);
                if (dtExpress != null && dtExpress.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtExpress.Rows)
                    {
                        string FromProfileID = dr["FromProfileID"].ToString();
                        string ToProfileID = dr["ToProfileID"].ToString();

                        dr["Acceptlink"] = Commonclass.getEncryptedExpressIntrestString("FromProfileID=" + FromProfileID + "&" + "ToProfileID=" + ToProfileID + "&" + "Flag=" + 1);
                        dr["Rejectlink"] = Commonclass.getEncryptedExpressIntrestString("FromProfileID=" + FromProfileID + "&" + "ToProfileID=" + ToProfileID + "&" + "Flag=" + 0);
                        dr["RvrAcceptlink"] = Commonclass.getEncryptedExpressIntrestString("FromProfileID=" + ToProfileID + "&" + "ToProfileID=" + FromProfileID + "&" + "Flag=" + 1);
                        dr["RvrRejectlink"] = Commonclass.getEncryptedExpressIntrestString("FromProfileID=" + ToProfileID + "&" + "ToProfileID=" + FromProfileID + "&" + "Flag=" + 0);
                        dr["Sendsms"] = (!string.IsNullOrEmpty(dr["Sendsms"].ToString()) && dr["Sendsms"].ToString() == "True") ? true : false;
                        dr["IsRvrSend"] = (!string.IsNullOrEmpty(dr["IsRvrSend"].ToString()) && dr["IsRvrSend"].ToString() == "True") ? true : false;
                    }
                }

                EXI.dtExpInt = dtExpress;
                Istatus = notviewedprofilesemails(EXI, "[dbo].[usp_GetUnviewedServiceProfilesData]");
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Istatus;
        }

        public ArrayList keywordlikesearch(keywordlikesearch keyword, string spname)
        {
            SqlParameter[] parm = new SqlParameter[10];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet ds = new DataSet();
            try
            {
                parm[0] = new SqlParameter("@TblDetails", SqlDbType.Structured);
                parm[0].Value = keyword.dtPartnerPreference;
                parm[1] = new SqlParameter("@ApplicationStatus", SqlDbType.VarChar);
                parm[1].Value = keyword.ApplicationStatus;
                parm[2] = new SqlParameter("@Caste", SqlDbType.VarChar);
                parm[2].Value = keyword.Caste;
                parm[3] = new SqlParameter("@Age", SqlDbType.Int);
                parm[3].Value = keyword.Age;
                parm[4] = new SqlParameter("@intEmpID", SqlDbType.Int);
                parm[4].Value = keyword.EmpID;
                parm[5] = new SqlParameter("@i_Startindex", SqlDbType.Int);
                parm[5].Value = keyword.startindex;
                parm[6] = new SqlParameter("@i_EndIndex", SqlDbType.Int);
                parm[6].Value = keyword.EndIndex;
                parm[7] = new SqlParameter("@Status", SqlDbType.Int);
                parm[7].Direction = ParameterDirection.Output;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public List<GetRegprofilevalidation> RegistrationValidation_Counts(Regprofilevalidation partnerdata, string spName)
        {
            List<GetRegprofilevalidation> details = new List<GetRegprofilevalidation>();
            SqlDataReader reader;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string Snull = "--";
            int? inull = null;
            Int64? Lnull = null;
            int status = 0;
            string empty = "--";
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                SqlParameter[] parm = new SqlParameter[20];

                parm[0] = new SqlParameter("@strMFFNativePlace", SqlDbType.VarChar);
                parm[0].Value = partnerdata.strMFFNativePlace;
                parm[1] = new SqlParameter("@strFatherName", SqlDbType.VarChar);
                parm[1].Value = partnerdata.strFatherName;
                parm[2] = new SqlParameter("@strMotherName", SqlDbType.VarChar);
                parm[2].Value = partnerdata.strMotherName;
                parm[3] = new SqlParameter("@strFFName", SqlDbType.VarChar);
                parm[3].Value = partnerdata.strFFName;
                parm[4] = new SqlParameter("@strMFName", SqlDbType.VarChar);
                parm[4].Value = partnerdata.strMFName;
                parm[5] = new SqlParameter("@strMFSurName", SqlDbType.VarChar);
                parm[5].Value = partnerdata.strMFSurName;
                parm[6] = new SqlParameter("@strCustSurName", SqlDbType.VarChar);
                parm[6].Value = partnerdata.strCustSurName;
                parm[7] = new SqlParameter("@strCustName", SqlDbType.VarChar);
                parm[7].Value = partnerdata.strCustName;
                parm[8] = new SqlParameter("@strCaste", SqlDbType.VarChar);
                parm[8].Value = partnerdata.strCaste;
                parm[9] = new SqlParameter("@strAllPhones", SqlDbType.VarChar);
                parm[9].Value = partnerdata.strAllPhones;
                parm[10] = new SqlParameter("@strAllEmailIds", SqlDbType.VarChar);
                parm[10].Value = partnerdata.strAllEmailIds;
                parm[11] = new SqlParameter("@intAppicationStatusID", SqlDbType.Int);
                parm[11].Value = partnerdata.intAppicationStatusID;
                parm[12] = new SqlParameter("@intEmpID", SqlDbType.Int);
                parm[12].Value = partnerdata.intEmpID;
                parm[13] = new SqlParameter("@i_Startindex", SqlDbType.Int);
                parm[13].Value = partnerdata.i_Startindex;
                parm[14] = new SqlParameter("@i_EndIndex", SqlDbType.Int);
                parm[14].Value = partnerdata.i_EndIndex;
                parm[15] = new SqlParameter("@intGenderID", SqlDbType.Int);
                parm[15].Value = partnerdata.intGenderID;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        GetRegprofilevalidation sh = new GetRegprofilevalidation();
                        {
                            sh.ActiveCount = reader["ActiveCnt"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ActiveCnt")) : inull;
                            sh.DeletedCount = reader["DeletedCnt"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("DeletedCnt")) : inull;
                            sh.SettledCount = reader["SettledCnt"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("SettledCnt")) : inull;
                            sh.InActiveCount = reader["InActiveCnt"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("InActiveCnt")) : inull;
                            sh.MMSerious = reader["MMSCnt"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("MMSCnt")) : inull;
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
            }

            status = 1;
            return details;
        }

        public int InsertMatchfollowupExpressinterest(int? fromcustid, int? tocustid, long? logID, string interstTYpe, int? empid, string spName)
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
            }
            return status;
        }

        public ArrayList Marketingtickethistory(int? custid, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                SqlParameter[] parm = new SqlParameter[2];
                parm[0] = new SqlParameter("@intCust_id", SqlDbType.Int);
                parm[0].Value = custid;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }

            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public int? CloseReminderStatus(closereminder Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[6];
            Smtpemailsending smtp = new Smtpemailsending();
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            SqlDataReader reader;
            int? status = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@ReminderID", SqlDbType.BigInt);
                parm[0].Value = Mobj.Reminderid;
                parm[1] = new SqlParameter("@ClosedEmpid", SqlDbType.BigInt);
                parm[1].Value = Mobj.closeEmpid;
                parm[2] = new SqlParameter("@ClosedReminderreason", SqlDbType.VarChar);
                parm[2].Value = Mobj.ClosedReminderreason;
                parm[3] = new SqlParameter("@Status", SqlDbType.Int);
                parm[3].Direction = ParameterDirection.Output;

                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[3].Value.ToString()).Equals(0))
                {
                    status = 0;
                }
                else
                {
                    status = Convert.ToInt32(parm[3].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), Mobj.Reminderid, null, null);
            }
            finally
            {
                connection.Close();
            }
            return status;
        }

        public int? ChangeEmppassword(string UserID, string spname)
        {
            SqlParameter[] parm = new SqlParameter[6];
            Smtpemailsending smtp = new Smtpemailsending();
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            int? status = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@USERID", SqlDbType.VarChar);
                parm[0].Value = UserID;
                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;

                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[1].Value.ToString()).Equals(0))
                {
                    status = 0;
                }
                else
                {
                    status = Convert.ToInt32(parm[1].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, UserID, null);
            }
            finally
            {
                connection.Close();
            }
            return status;
        }

        public ArrayList MatchfollowupTicketStatus(long? Ticketid, string spname)
        {
            SqlParameter[] parm = new SqlParameter[4];
            Smtpemailsending smtp = new Smtpemailsending();
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet ds = new DataSet();
            ArrayList arr = new ArrayList();
            SqlDataReader reader;
            string Tktstatus;
            try
            {
                parm[0] = new SqlParameter("@Empticketid", SqlDbType.BigInt);
                parm[0].Value = Ticketid;

                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spname, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Tktstatus = reader["ToTicketStatus"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToTicketStatus")) : string.Empty;

                        arr.Add(Tktstatus);
                    }
                }

                reader.Close();
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, Ticketid.ToString(), null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return arr;
        }

        public int? RestoredProfileidupdate(RestoredProfileid Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[12];
            Smtpemailsending smtp = new Smtpemailsending();
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            int? status = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@CustID", SqlDbType.BigInt);
                parm[0].Value = Mobj.CustID;
                parm[1] = new SqlParameter("@EmpID", SqlDbType.BigInt);
                parm[1].Value = Mobj.EmpID;
                parm[2] = new SqlParameter("@RequestedBY", SqlDbType.Int);
                parm[2].Value = Mobj.RequestedBY;
                parm[3] = new SqlParameter("@RequestedBYEmpID", SqlDbType.BigInt);
                parm[3].Value = Mobj.RequestedBYEmpID;
                parm[4] = new SqlParameter("@RelationshipID", SqlDbType.Int);
                parm[4].Value = Mobj.RelationshipID;
                parm[5] = new SqlParameter("@Relationshipname", SqlDbType.VarChar);
                parm[5].Value = Mobj.Relationshipname;
                parm[6] = new SqlParameter("@Reasonforrestore", SqlDbType.VarChar);
                parm[6].Value = Mobj.Reasonforrestore;
                parm[7] = new SqlParameter("@PriviousProfileStatus", SqlDbType.Int);
                parm[7].Value = Mobj.PriviousProfileStatus;
                parm[8] = new SqlParameter("@status", SqlDbType.Int);
                parm[8].Direction = ParameterDirection.Output;

                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[8].Value.ToString()).Equals(0))
                {
                    status = 0;
                }
                else
                {
                    status = Convert.ToInt32(parm[8].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), Mobj.CustID, null, null);
            }
            finally
            {
                connection.Close();
            }
            return status;
        }

        public ArrayList KeywordlikeSearchnewpage(newkeywordlikesrch Mobj, string spName)
        {
            SqlParameter[] parm = new SqlParameter[9];
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            DataSet ds = new DataSet();
            SqlDataReader reader;
            string Snull = "--";
            int? inull = null;
            bool? bnull = null;
            Int64? Lnull = null;
            ArrayList array = new ArrayList();
            try
            {
                parm[0] = new SqlParameter("@TblDetails", SqlDbType.Structured);
                parm[0].Value = Mobj.dtPartnerPreference;
                parm[1] = new SqlParameter("@ApplicationStatus", SqlDbType.VarChar);
                parm[1].Value = Mobj.ApplicationStatus;
                parm[2] = new SqlParameter("@intEmpID", SqlDbType.Int);
                parm[2].Value = Mobj.EmpID;
                parm[3] = new SqlParameter("@i_Startindex", SqlDbType.Int);
                parm[3].Value = Mobj.startindex;
                parm[4] = new SqlParameter("@i_EndIndex", SqlDbType.Int);
                parm[4].Value = Mobj.EndIndex;
                parm[5] = new SqlParameter("@Status", SqlDbType.Int);
                parm[5].Direction = ParameterDirection.Output;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        keywordslideshowNew sh = new keywordslideshowNew();

                        {
                            sh.Cust_ID = reader["Cust_ID"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Cust_ID")) : Snull;
                            sh.paid = reader["paid"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("paid")) : inull;
                            sh.ProfileID = reader["ProfileID"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : Snull;
                            sh.KMPLID = reader["KMPLID"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("KMPLID")) : Snull;
                            sh.IsConfidential = reader["IsConfidential"] != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("IsConfidential")) : bnull;
                            sh.SuperConfidentila = reader["SuperConfidentila"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("SuperConfidentila")) : inull;
                            sh.FirstName = reader["FirstName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("FirstName")) : Snull;
                            sh.LastName = reader["LastName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("LastName")) : Snull;
                            sh.Name = reader["FirstName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("FirstName")) : Snull;
                            sh.SurName = reader["LastName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("LastName")) : Snull;
                            sh.DOB = reader["DOB"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("DOB")) : Snull;
                            sh.Age = reader["Age"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Age")) : inull;
                            sh.Height = reader["Height"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Height")) : Snull;
                            sh.Caste = reader["Caste"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Caste")) : Snull;
                            sh.MotherTongue = reader["MotherTongue"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("MotherTongue")) : Snull;
                            // sh.Caste = (reader["MotherTongue"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("MotherTongue")) + "-") : "") + (reader["Caste"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("Caste")).ToString()) : Snull) + (reader["SubCaste"] != DBNull.Value ? ("(" + (reader.GetString(reader.GetOrdinal("SubCaste"))) + ")") : "");
                            sh.EduGroupnamenew = reader["EduGroupnamenew"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("EduGroupnamenew")) : Snull;
                            sh.Profession = reader["Profession"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Profession")) : Snull;
                            sh.JobLocation = reader["JobLocation"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("JobLocation")) : Snull;
                            sh.Income = reader["Income"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Income")) : Snull;
                            sh.Property = reader["Property"] != DBNull.Value ? reader.GetDouble(reader.GetOrdinal("Property")).ToString() : Snull;
                            sh.PlaceOfBirth = reader["PlaceOfBirth"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("PlaceOfBirth")) : Snull;
                            sh.TOB = reader["TOB"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("TOB")) : Snull;
                            sh.Gothram = reader["Gothram"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Gothram")) : Snull;
                            sh.Star = reader["Star"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Star")) : Snull;
                            sh.FFNative = reader["FFNative"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("FFNative")) : Snull;
                            sh.MFNative = reader["MFNative"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("MFNative")) : Snull;
                            sh.Gender = reader["Gender"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Gender")) : Snull;
                            //sh.PhotoNames = reader["PhotoNames"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoNames")) : Snull;
                            sh.Photo = reader["CustomerFullPhoto"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("CustomerFullPhoto")) : Snull;
                            // sh.ApplicationPhotoPath = reader["ApplicationPhotoPath"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ApplicationPhotoPath")) : Snull;
                            sh.HoroscopeStatus = reader["HoroscopeStatus"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("HoroscopeStatus")) : inull;
                            sh.HoroscopePath = reader["HoroscopePath"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("HoroscopePath")) : Snull;
                            sh.email = reader["email"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("email")) : Snull;
                            sh.NoOfBrothers = reader["NoOfBrothers"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("NoOfBrothers")) : inull;
                            sh.NoOfSisters = reader["NoOfSisters"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("NoOfSisters")) : inull;
                            sh.CasteID = reader["CasteID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CasteID")) : inull;
                            sh.HeightInCentimeters = reader["HeightInCentimeters"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("HeightInCentimeters")) : inull;
                            sh.MaritalStatusID = reader["MaritalStatusID"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("MaritalStatusID")) : inull;
                            sh.maritalstatus = reader["MaritalStatus"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("MaritalStatus")) : Snull;
                            sh.Color = reader["Color"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Color")) : Snull;
                            sh.Education = reader["EducationGroup"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationGroup")) : Snull;
                            sh.EducationGroup = reader["EducationGroup"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationGroup")) : Snull;
                            sh.currency = reader["currency"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("currency")) : Snull;
                            sh.Intercaste = reader["Intercaste"] != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("Intercaste")) : bnull;
                            sh.fathercaste = reader["fathercaste"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("fathercaste")) : Snull;
                            sh.mothercaste = reader["mothercaste"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("mothercaste")) : Snull;
                            sh.PhotoCount = reader["PhotoCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoCount")) : inull;
                            sh.TotalRows = reader["TotalRows"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("TotalRows")) : inull;
                            sh.countrylivingin = reader["CountryLivingin"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("CountryLivingin")) : Snull;
                            //sh.CustomerApplicationPhoto = reader["CustomerApplicationPhoto"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("CustomerApplicationPhoto"))) : Snull;
                            sh.CompanyName = reader["CompanyName"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("CompanyName"))) : Snull;
                            //Added by lakshmi 31_10_2017_keywordlikesearch
                            sh.LastLoginDT = reader["LastLoginDT"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("LastLoginDT"))) : Snull;
                            sh.LastLoginDate = reader["LastLoginDate"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("LastLoginDate"))) : Snull;
                            sh.LoginCount = reader["LoginCount"] != DBNull.Value ? (reader.GetInt32(reader.GetOrdinal("LoginCount"))) : inull;
                            sh.ProfileStatusID = reader["ProfileStatusID"] != DBNull.Value ? (reader.GetInt32(reader.GetOrdinal("ProfileStatusID"))) : inull;
                            sh.ProfileGrade = reader["ProfileGrade"] != DBNull.Value ? (reader.GetInt32(reader.GetOrdinal("ProfileGrade"))) : inull;
                            sh.IsPaidMember = reader["IsPaidMember"] != DBNull.Value ? (reader.GetInt32(reader.GetOrdinal("IsPaidMember"))) : inull;
                            sh.OwnerName = reader["OwnerName"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("OwnerName"))) : Snull;
                            sh.RegistrationDate = reader["RegistrationDate"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("RegistrationDate"))) : Snull;
                            sh.SRCount = reader["SRCount"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("SRCount"))) : Snull;
                            sh.ExpiryDate = reader["ExpiryDate"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("ExpiryDate"))) : Snull;
                            sh.Points = reader["Points"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("Points"))) : Snull;
                            sh.TicketID = reader["TicketID"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("TicketID"))) : Snull;
                            sh.Emp_Ticket_ID = reader["Emp_Ticket_ID"] != DBNull.Value ? (reader.GetInt64(reader.GetOrdinal("Emp_Ticket_ID"))) : Lnull;
                            sh.MatchMeetingCount = reader["MatchMeetingCount"] != DBNull.Value ? (reader.GetInt32(reader.GetOrdinal("MatchMeetingCount"))) : inull;
                            sh.ProfileOwnername = reader["ProfileOwnername"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("ProfileOwnername"))) : Snull;
                            sh.EmpUserName = reader["EmpUserName"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("EmpUserName"))) : Snull;
                            sh.SAForm = reader["SAForm"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("SAForm"))) : Snull;
                            sh.CNumberVerStatus = reader["CNumberVerStatus"] != DBNull.Value ? (reader.GetBoolean(reader.GetOrdinal("CNumberVerStatus"))) : bnull;
                            sh.CEmailVerStatus = reader["CEmailVerStatus"] != DBNull.Value ? (reader.GetBoolean(reader.GetOrdinal("CEmailVerStatus"))) : bnull;
                            sh.Primarynumber = reader["Primarynumber"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("Primarynumber"))) : Snull;
                            sh.Primaryemail = reader["Primaryemail"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("Primaryemail"))) : Snull;
                            sh.Payment = reader["Payment"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("Payment"))) : Snull;
                            sh.CreatedDate = reader["CreatedDate"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("CreatedDate"))) : Snull;

                        }

                        array.Add(sh);
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
            }
            return array;
        }

        public ArrayList MasterDataselect(MasterData Mobj, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                SqlParameter[] parm = new SqlParameter[10];
                parm[0] = new SqlParameter("@i_AppUserId", SqlDbType.Int);
                parm[0].Value = Mobj.AppuserID;
                parm[1] = new SqlParameter("@vc_MasterType", SqlDbType.VarChar);
                parm[1].Value = Mobj.MasterType;
                parm[2] = new SqlParameter("@i_DependentId", SqlDbType.Int);
                parm[2].Value = Mobj.DependentId;
                parm[3] = new SqlParameter("@i_MasterTypeID", SqlDbType.Int);
                parm[3].Value = Mobj.MasterTypeID;
                parm[4] = new SqlParameter("@b_StatusCode", SqlDbType.Bit);
                parm[4].Value = Mobj.StatusCode;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);

            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }

            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public int MasterdataInsertUpdate(MasterInsertUpdate Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[25];
            Smtpemailsending smtp = new Smtpemailsending();
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            int status = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@i_AppUserId", SqlDbType.Int);
                parm[0].Value = Mobj.AppUserId;
                parm[1] = new SqlParameter("@vc_Name", SqlDbType.VarChar);
                parm[1].Value = Mobj.Name;
                parm[2] = new SqlParameter("@vc_CountryCode", SqlDbType.VarChar);
                parm[2].Value = Mobj.CountryCode;
                parm[3] = new SqlParameter("@vc_CountryCurrency", SqlDbType.VarChar);
                parm[3].Value = Mobj.CountryCurrency;
                parm[4] = new SqlParameter("@i_MobileLength", SqlDbType.Int);
                parm[4].Value = Mobj.MobileLength;
                parm[5] = new SqlParameter("@i_landlineLength", SqlDbType.Int);
                parm[5].Value = Mobj.landlineLength;
                parm[6] = new SqlParameter("@b_StatusCode", SqlDbType.Bit);
                parm[6].Value = Mobj.StatusCode;
                parm[7] = new SqlParameter("@vc_MasterType", SqlDbType.VarChar);
                parm[7].Value = Mobj.MasterType;
                parm[8] = new SqlParameter("@i_DependentId", SqlDbType.Int);
                parm[8].Value = Mobj.DependentId;

                parm[9] = new SqlParameter("@i_DependentDistrictId", SqlDbType.Int);
                parm[9].Value = Mobj.DependentDistrictIDId;

                parm[10] = new SqlParameter("@i_SubDependentId", SqlDbType.Int);
                parm[10].Value = Mobj.SubDependentId;

                parm[11] = new SqlParameter("@i_MinWords", SqlDbType.Float);
                parm[11].Value = Mobj.MinWords;
                parm[12] = new SqlParameter("@i_MaxWords", SqlDbType.Float);
                parm[12].Value = Mobj.MaxWords;
                parm[13] = new SqlParameter("@i_CostPOBox", SqlDbType.Float);
                parm[13].Value = Mobj.CostPOBox;
                parm[14] = new SqlParameter("@i_LanguageID", SqlDbType.Int);
                parm[14].Value = Mobj.LanguageID;

                parm[15] = new SqlParameter("@vc_Comments", SqlDbType.VarChar);
                parm[15].Value = Mobj.Comments;
                parm[16] = new SqlParameter("@i_ExtraWordPrice", SqlDbType.Float);
                parm[16].Value = Mobj.ExtraWordPrice;
                parm[17] = new SqlParameter("@vc_TamilStarName", SqlDbType.VarChar);
                parm[17].Value = Mobj.TamilStarName;
                parm[18] = new SqlParameter("@vc_KannadaStarName", SqlDbType.VarChar);
                parm[18].Value = Mobj.KannadaStarName;
                parm[19] = new SqlParameter("@i_MasterTypeID", SqlDbType.Int);
                parm[19].Value = Mobj.MasterTypeID;
                parm[20] = new SqlParameter("@O_MasterTypeID", SqlDbType.Int);
                parm[20].Value = 0;
                parm[21] = new SqlParameter("@Status", SqlDbType.Int);
                parm[21].Direction = ParameterDirection.Output;

                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[21].Value.ToString()).Equals(0))
                {
                    status = 0;
                }
                else
                {
                    status = Convert.ToInt32(parm[21].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), Mobj.AppUserId, null, null);
            }
            finally
            {
                connection.Close();
            }
            return status;
        }

        public ArrayList Customerinfobasedoncustid(string custids, int Empid, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[10];
                parm[0] = new SqlParameter("@strcust_id", SqlDbType.VarChar);
                parm[0].Value = custids;
                parm[1] = new SqlParameter("@intEmpID", SqlDbType.Int);
                parm[1].Value = Empid;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }

            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public int? updatemarketingvrfycation(ticketverification Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[10];
            Smtpemailsending smtp = new Smtpemailsending();
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            int status = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@Empid", SqlDbType.BigInt);
                parm[0].Value = Mobj.Empid;
                parm[1] = new SqlParameter("@Profileid", SqlDbType.VarChar);
                parm[1].Value = Mobj.Profileid;
                parm[2] = new SqlParameter("@Emp_commisionTicketid", SqlDbType.Int);
                parm[2].Value = Mobj.Emp_commisionTicketid;
                parm[3] = new SqlParameter("@PaidAmount", SqlDbType.Decimal);
                parm[3].Value = Mobj.PaidAmount;
                parm[4] = new SqlParameter("@commisionAmount", SqlDbType.Decimal);
                parm[4].Value = Mobj.commisionAmount;
                parm[5] = new SqlParameter("@TicketMrkedStatus", SqlDbType.Bit);
                parm[5].Value = Mobj.TicketMrkedStatus;
                parm[6] = new SqlParameter("@Status", SqlDbType.Int);
                parm[6].Direction = ParameterDirection.Output;

                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[6].Value.ToString()).Equals(0))
                {
                    status = 0;
                }
                else
                {
                    status = Convert.ToInt32(parm[6].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), Convert.ToInt64(Mobj.Profileid), null, null);
            }
            finally
            {
                connection.Close();
            }
            return status;
        }

        public ArrayList EmployeeMenulist(long? Empid, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[2];
                parm[0] = new SqlParameter("@EmpID", SqlDbType.BigInt);
                parm[0].Value = Empid;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }

            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public int? Updatedeletecustomerdetails(updatedeletecustomer Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[17];
            Smtpemailsending smtp = new Smtpemailsending();
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            int status = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@Engagementdate", SqlDbType.DateTime);
                parm[0].Value = Mobj.Engagementdate;
                parm[1] = new SqlParameter("@EngagementVenue", SqlDbType.VarChar, 500);
                parm[1].Value = Mobj.EngagementVenue;
                parm[2] = new SqlParameter("@Marriagedate", SqlDbType.DateTime);
                parm[2].Value = Mobj.Marriagedate;
                parm[3] = new SqlParameter("@MarriageVenue", SqlDbType.VarChar, 500);
                parm[3].Value = Mobj.MarriageVenue;
                parm[4] = new SqlParameter("@Surname", SqlDbType.VarChar, 250);
                parm[4].Value = Mobj.DelSurname;
                parm[5] = new SqlParameter("@Name", SqlDbType.VarChar, 250);
                parm[5].Value = Mobj.DelName1;
                parm[6] = new SqlParameter("@FatherName", SqlDbType.VarChar, 250);
                parm[6].Value = Mobj.DelFatherName;
                parm[7] = new SqlParameter("@Native", SqlDbType.VarChar, 250);
                parm[7].Value = Mobj.DelNative;
                parm[8] = new SqlParameter("@Education", SqlDbType.VarChar, 250);
                parm[8].Value = Mobj.DelEducation;
                parm[9] = new SqlParameter("@Profession", SqlDbType.VarChar, 250);
                parm[9].Value = Mobj.DelProfession;
                parm[10] = new SqlParameter("@ReasonForDelete", SqlDbType.Int);
                parm[10].Value = Mobj.DelReasonForDelete;
                parm[11] = new SqlParameter("@Relationship", SqlDbType.Int);
                parm[11].Value = Mobj.DelRelationship;
                parm[12] = new SqlParameter("@RelationshipName", SqlDbType.VarChar, 250);
                parm[12].Value = Mobj.DelRelationshipName;
                parm[13] = new SqlParameter("@Narriation", SqlDbType.VarChar, 8000);
                parm[13].Value = Mobj.Narriation;
                parm[14] = new SqlParameter("@Status", SqlDbType.Int);
                parm[14].Direction = ParameterDirection.Output;
                parm[15] = new SqlParameter("@ID", SqlDbType.Int);
                parm[15].Value = Mobj.ID;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[14].Value.ToString()).Equals(0))
                {
                    status = 0;
                }
                else
                {
                    status = Convert.ToInt32(parm[14].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), Convert.ToInt64(Mobj.ID), null, null);
            }
            finally
            {
                connection.Close();
            }
            return status;
        }

        public int? Updatedeletecustomerdetails_new(updatedeletecustomer Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[14];
            Smtpemailsending smtp = new Smtpemailsending();
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            int status = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@Surname", SqlDbType.VarChar, 250);
                parm[0].Value = Mobj.DelSurname;
                parm[1] = new SqlParameter("@Name", SqlDbType.VarChar, 250);
                parm[1].Value = Mobj.DelName1;
                parm[2] = new SqlParameter("@FatherName", SqlDbType.VarChar, 250);
                parm[2].Value = Mobj.DelFatherName;
                parm[3] = new SqlParameter("@Education", SqlDbType.VarChar, 250);
                parm[3].Value = Mobj.DelEducation;
                parm[4] = new SqlParameter("@Profession", SqlDbType.VarChar, 250);
                parm[4].Value = Mobj.DelProfession;
                parm[5] = new SqlParameter("@Relationship", SqlDbType.Int);
                parm[5].Value = Mobj.DelRelationship;
                parm[6] = new SqlParameter("@Joblocation", SqlDbType.VarChar, 500);
                parm[6].Value = Mobj.Joblocation;
                parm[7] = new SqlParameter("@Narriation", SqlDbType.VarChar, 8000);
                parm[7].Value = Mobj.Narriation;
                parm[8] = new SqlParameter("@Status", SqlDbType.Int);
                parm[8].Direction = ParameterDirection.Output;
                parm[9] = new SqlParameter("@ID", SqlDbType.Int);
                parm[9].Value = Mobj.ID;
                parm[10] = new SqlParameter("@AuthorizationStatus", SqlDbType.Int);
                parm[10].Value = Mobj.AuthorizationStatus;
                parm[11] = new SqlParameter("@Authorizeempid", SqlDbType.BigInt);
                parm[11].Value = Mobj.Authorizeempid;

                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[8].Value.ToString()).Equals(0))
                {
                    status = 0;
                }
                else
                {
                    status = Convert.ToInt32(parm[8].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), Convert.ToInt64(Mobj.ID), null, null);
            }
            finally
            {
                connection.Close();
            }
            return status;
        }

        public ArrayList EmployeePermissions(int? Empuserid, string Pageid, int? flag, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[5];
                parm[0] = new SqlParameter("@i_EmpID", SqlDbType.Int);
                parm[0].Value = Empuserid;
                parm[1] = new SqlParameter("@v_permissionpages", SqlDbType.VarChar);
                parm[1].Value = Pageid;
                parm[2] = new SqlParameter("@flag", SqlDbType.Int);
                parm[2].Value = flag;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }

            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public int? Updateinsertemployeepermission(Employeepermission Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[8];
            Smtpemailsending smtp = new Smtpemailsending();
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            int status = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@EmployeeID", SqlDbType.VarChar);
                parm[0].Value = Mobj.EmployeeID;
                parm[1] = new SqlParameter("@dtPagePermissions", SqlDbType.Structured);
                parm[1].Value = Mobj.dtPagePermissions;
                parm[2] = new SqlParameter("@CreatedEmpID", SqlDbType.BigInt);
                parm[2].Value = Mobj.CreatedEmpID;
                parm[3] = new SqlParameter("@Status", SqlDbType.Int);
                parm[3].Direction = ParameterDirection.Output;
                parm[4] = new SqlParameter("@ErrorMsg", SqlDbType.VarChar, 1000);
                parm[4].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[3].Value.ToString()).Equals(0))
                {
                    status = 0;
                }
                else
                {
                    status = Convert.ToInt32(parm[3].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), Convert.ToInt64(Mobj.EmployeeID), null, null);
            }
            finally
            {
                connection.Close();
            }
            return status;
        }

        public ArrayList EmployeeReportsCounts(EmpCountsreport Mobj, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[16];
                parm[0] = new SqlParameter("@Branch", SqlDbType.Structured);
                parm[0].Value = Commonclass.returndt(Mobj.strBranch, Mobj.dtBranch, "branch", "branchTable");
                parm[1] = new SqlParameter("@strEmpIDs", SqlDbType.Structured);
                parm[1].Value = Commonclass.returndt(Mobj.strEmpIDs, Mobj.dtEmpids, "Employee", "EmployeeTable");
                parm[2] = new SqlParameter("@intRegion", SqlDbType.Int);
                parm[2].Value = Mobj.intRegion;
                parm[3] = new SqlParameter("@intStartIndex", SqlDbType.Int);
                parm[3].Value = Mobj.intStartIndex;
                parm[4] = new SqlParameter("@intEndIndex", SqlDbType.Int);
                parm[4].Value = Mobj.intEndIndex;
                parm[5] = new SqlParameter("@intServiceDate", SqlDbType.Int);
                parm[5].Value = Mobj.intServiceDate;
                parm[6] = new SqlParameter("@intPaymentExp", SqlDbType.Int);
                parm[6].Value = Mobj.intPaymentExp;
                parm[7] = new SqlParameter("@intNoPhoto", SqlDbType.Int);
                parm[7].Value = Mobj.intNoPhoto;
                parm[8] = new SqlParameter("@intNOtYetVerified", SqlDbType.Int);
                parm[8].Value = Mobj.intNOtYetVerified;
                parm[9] = new SqlParameter("@intUnPaid", SqlDbType.Int);
                parm[9].Value = Mobj.intUnPaid;
                parm[10] = new SqlParameter("@intInactive", SqlDbType.Int);
                parm[10].Value = Mobj.intInactive;
                parm[11] = new SqlParameter("@intEmailBounce", SqlDbType.Int);
                parm[11].Value = Mobj.intEmailBounce;
                parm[12] = new SqlParameter("@intNoSAFirm", SqlDbType.Int);
                parm[12].Value = Mobj.intNoSAFirm;
                parm[13] = new SqlParameter("@inrPresentInIndia", SqlDbType.Int);
                parm[13].Value = Mobj.inrPresentInIndia;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }

            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public int? updateprofilebranchid(string Profileid, string spname)
        {
            SqlParameter[] parm = new SqlParameter[8];
            Smtpemailsending smtp = new Smtpemailsending();
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            int status = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@ProfileID", SqlDbType.VarChar);
                parm[0].Value = Profileid;
                parm[1] = new SqlParameter("@Status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[1].Value.ToString()).Equals(0))
                {
                    status = 0;
                }
                else
                {
                    status = Convert.ToInt32(parm[1].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), Convert.ToInt64(Profileid), null, null);
            }
            finally
            {
                connection.Close();
            }
            return status;
        }

        public int? inserttorestoretable(long? Profileid, string spname)
        {
            SqlParameter[] parm = new SqlParameter[8];
            Smtpemailsending smtp = new Smtpemailsending();
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            int status = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@profileid", SqlDbType.BigInt);
                parm[0].Value = Profileid;
                parm[1] = new SqlParameter("@status", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[1].Value.ToString()).Equals(0))
                {
                    status = 0;
                }
                else
                {
                    status = Convert.ToInt32(parm[1].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), Convert.ToInt64(Profileid), null, null);
            }
            finally
            {
                connection.Close();
            }
            return status;
        }

        public int? InsertamountintoBank(bankamount Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[10];
            Smtpemailsending smtp = new Smtpemailsending();
            List<Smtpemailsending> li = new List<Smtpemailsending>();
            int status = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            try
            {
                parm[0] = new SqlParameter("@Bankname", SqlDbType.VarChar);
                parm[0].Value = Mobj.Bankname;
                parm[1] = new SqlParameter("@modeofdeposit", SqlDbType.VarChar);
                parm[1].Value = Mobj.modeofdeposit;
                parm[2] = new SqlParameter("@depositamount", SqlDbType.Float);
                parm[2].Value = Mobj.depositamount;
                parm[3] = new SqlParameter("@depositedby", SqlDbType.Int);
                parm[3].Value = Mobj.depositedby;
                parm[4] = new SqlParameter("@depositeddate", SqlDbType.DateTime);
                parm[4].Value = Mobj.depositeddate;
                parm[5] = new SqlParameter("@Description", SqlDbType.VarChar);
                parm[5].Value = Mobj.Description;
                parm[6] = new SqlParameter("@Typeofamount", SqlDbType.VarChar);
                parm[6].Value = Mobj.Typeofamount;
                parm[7] = new SqlParameter("@status", SqlDbType.Int);
                parm[7].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[7].Value.ToString()).Equals(0))
                {
                    status = 0;
                }
                else
                {
                    status = Convert.ToInt32(parm[7].Value);
                    ServiceSoapClient cc = new ServiceSoapClient();

                    if (Mobj.empRegionID == "409")
                    {
                        string result1 = cc.SendTextSMS("ykrishna", "summary$1", "9848344977", "" + Mobj.depositamount + " " + Mobj.modeofdeposit + " desposited in " + Mobj.Banknametext + " by " + Mobj.LoginEmpName + "(" + Mobj.usernameemployeeid + ")", "smscntry");
                        string result2 = cc.SendTextSMS("ykrishna", "summary$1", "9841282222", "" + Mobj.depositamount + " " + Mobj.modeofdeposit + " desposited in " + Mobj.Banknametext + " by " + Mobj.LoginEmpName + "(" + Mobj.usernameemployeeid + ")", "smscntry");
                    }
                    else
                    {
                        string result3 = cc.SendTextSMS("ykrishna", "summary$1", "9848344977", "" + Mobj.depositamount + " " + Mobj.modeofdeposit + " desposited in " + Mobj.Banknametext + " by " + Mobj.LoginEmpName + "(" + Mobj.usernameemployeeid + ")", "smscntry");
                        string result4 = cc.SendTextSMS("ykrishna", "summary$1", "9848355213", "" + Mobj.depositamount + " " + Mobj.modeofdeposit + " desposited in " + Mobj.Banknametext + " by " + Mobj.LoginEmpName + "(" + Mobj.usernameemployeeid + ")", "smscntry");
                    }
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return status;
        }



        public EmployeeMarketingTicketResponse GetMarketingTicketHistoryInfo_New(EmployeeMarketingTketRequestNew Mobj, string spName)
        {
            EmployeeMarketingTicketResponse responseBody = new EmployeeMarketingTicketResponse();

            SqlParameter[] parm = new SqlParameter[30];



            try
            {

                var p = new DynamicParameters();

                p.Add("@i_EmpID", Mobj.i_EmpID);
                p.Add("@i_PageFrom", Mobj.i_PageFrom);
                p.Add("@i_PageTo", Mobj.i_PageTo);
                p.Add("@v_EmpIDs", Mobj.strEmpName);
                p.Add("@v_BranchIDs", Mobj.strBranch);
                p.Add("@dt_FromProceedDate", Mobj.dtFromProceedDate);

                p.Add("@dt_ToProceedDate", Mobj.dtToProceedDate);
                p.Add("@i_days", Mobj.i_days);

                p.Add("@i_RegionID", Mobj.i_RegionID);
                p.Add("@i_TicketId", Mobj.i_TicketId);
                p.Add("@i_EmailId", Mobj.i_EmailId);
                p.Add("@i_PhoneNumber", Mobj.i_PhoneNumber);

                p.Add("@i_ProfileId", Mobj.i_ProfileId);
                p.Add("@dt_FromReminderDate", Mobj.dt_FromRemainderdate);

                p.Add("@dt_ToReminderDate", Mobj.dt_ToReminderdate);
                p.Add("@b_unpaidProfiles", Mobj.b_unpaidProfiles);

                p.Add("@v_Marketreminder", Mobj.v_MarketremindeFlag);
                p.Add("@i_UnmarriedSiblingDetails", Mobj.v_siblingflag);

                p.Add("@i_GuestTickets", Mobj.v_guestticketflag);
                p.Add("@i_Onlineeexpiry", Mobj.v_OnlineExprd);

                p.Add("@V_Notpay", Mobj.V_Notpay);


                responseBody.Marketingslideticket = new List<EmployeeMarketingslideticket>();
                responseBody.MarketingslideHistory = new List<EmployeeMarketingslideHistory>();


                using (IDbConnection conn = SQLHelper.GetSQLConnection())
                {

                    IEnumerable<dynamic> results = conn.Query(sql: spName, param: p, commandType: CommandType.StoredProcedure);
                    var reader = conn.QueryMultiple(spName, param: p, commandType: CommandType.StoredProcedure);


                    var userdetails = reader.Read<EmployeeMarketingslideticket>().ToList();
                    var salarydetails = reader.Read<EmployeeMarketingslideHistory>().ToList();

                    responseBody.Marketingslideticket = userdetails;
                    responseBody.MarketingslideHistory = salarydetails;
                }

            }

            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }

            return responseBody;
        }




        public List<EmployeeUnassignedPages> deselectPagePermissions(int? Empid, string pageid, int? flag, string spName)
        {
            List<EmployeeUnassignedPages> response = new List<EmployeeUnassignedPages>();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                //SqlParameter[] parm = new SqlParameter[6];
                //parm[0] = new SqlParameter("@empid", SqlDbType.Int);
                //parm[0].Value = Empid;
                //parm[1] = new SqlParameter("@pageid", SqlDbType.VarChar);
                //parm[1].Value = pageid;
                //parm[2] = new SqlParameter("@flag", SqlDbType.Int);
                //parm[2].Value = flag;
                //parm[3] = new SqlParameter("@status", SqlDbType.Int);
                //parm[3].Direction = ParameterDirection.Output;
                //    ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);


                var p = new DynamicParameters();

                p.Add("@empid", Empid);
                p.Add("@pageid", pageid);
                p.Add("@flag", flag);
                p.Add("@status", ParameterDirection.Output);

                using (IDbConnection conn = SQLHelper.GetSQLConnection())
                {
                    var reader = conn.QueryMultiple(spName, param: p, commandType: CommandType.StoredProcedure);
                    var userdetails = reader.Read<EmployeeUnassignedPages>().ToList();
                    response = userdetails;
                }


            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return response;

        }

        public ArrayList bankdepositedreport(bankamountreport Mobj, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[7];
                parm[0] = new SqlParameter("@bankname", SqlDbType.VarChar);
                parm[0].Value = Mobj.bankname;
                parm[1] = new SqlParameter("@modeofdeposit", SqlDbType.VarChar);
                parm[1].Value = Mobj.modeofdeposit;
                parm[2] = new SqlParameter("@branch", SqlDbType.VarChar);
                parm[2].Value = Mobj.branch;
                parm[3] = new SqlParameter("@fromdate", SqlDbType.VarChar);
                parm[3].Value = Mobj.fromdate;
                parm[4] = new SqlParameter("@todate", SqlDbType.VarChar);
                parm[4].Value = Mobj.todate;
                parm[5] = new SqlParameter("@empid", SqlDbType.Int);
                parm[5].Value = Mobj.empid;

                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public ArrayList bankNamesreport(int? RegionId, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[2];
                parm[0] = new SqlParameter("@RegionId", SqlDbType.Int);
                parm[0].Value = RegionId;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public ArrayList employeeDailyworkreport(employeeworkreport Mobj, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[11];
                parm[0] = new SqlParameter("@EMPID", SqlDbType.VarChar);
                parm[0].Value = Mobj.EMPID;
                parm[1] = new SqlParameter("@BRANCHID", SqlDbType.VarChar);
                parm[1].Value = Mobj.BRANCHID;
                parm[2] = new SqlParameter("@MARKETCOUNT", SqlDbType.Int);
                parm[2].Value = Mobj.MARKETCOUNT;
                parm[3] = new SqlParameter("@MATCHFOLLOWUPCOUNT", SqlDbType.Int);
                parm[3].Value = Mobj.MATCHFOLLOWUPCOUNT;
                parm[4] = new SqlParameter("@SERVICECOUNT", SqlDbType.Int);
                parm[4].Value = Mobj.SERVICECOUNT;
                parm[5] = new SqlParameter("@dtFromDate", SqlDbType.VarChar);
                parm[5].Value = Mobj.dtFromDate;
                parm[6] = new SqlParameter("@dtToDate", SqlDbType.VarChar);
                parm[6].Value = Mobj.dtToDate;
                parm[7] = new SqlParameter("@intStartIndex", SqlDbType.Int);
                parm[7].Value = Mobj.intStartIndex;
                parm[8] = new SqlParameter("@intEndIndex", SqlDbType.Int);
                parm[8].Value = Mobj.intEndIndex;
                parm[9] = new SqlParameter("@intRegionID", SqlDbType.VarChar);
                parm[9].Value = Mobj.intRegionID;

                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public ArrayList Employeecustomerprint(string strProfileID, int? intAdminId, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[3];
                parm[0] = new SqlParameter("@strProfileID", SqlDbType.VarChar);
                parm[0].Value = strProfileID;
                parm[1] = new SqlParameter("@intAdminId", SqlDbType.Int);
                parm[1].Value = intAdminId;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public ArrayList deselectPagePermissionsupdate(int? Empid, string Pageid, int? flag, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[6];
                parm[0] = new SqlParameter("@empid", SqlDbType.Int);
                parm[0].Value = Empid;
                parm[1] = new SqlParameter("@pageid", SqlDbType.VarChar);
                parm[1].Value = Pageid;
                parm[2] = new SqlParameter("@flag", SqlDbType.Int);
                parm[2].Value = flag;
                parm[3] = new SqlParameter("@status", SqlDbType.Int);
                parm[3].Direction = ParameterDirection.Output;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public ArrayList EmployeeWorkgrade(string EMPID, string dtFromDate, string dtToDate, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[6];
                parm[0] = new SqlParameter("@EMPID", SqlDbType.VarChar);
                parm[0].Value = EMPID;
                parm[1] = new SqlParameter("@dtFromDate", SqlDbType.VarChar);
                parm[1].Value = dtFromDate;
                parm[2] = new SqlParameter("@dtToDate", SqlDbType.VarChar);
                parm[2].Value = dtToDate;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public ArrayList EmployeeWorkperformance(string intRegionID, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[2];
                parm[0] = new SqlParameter("@intRegionID", SqlDbType.VarChar);
                parm[0].Value = intRegionID;

                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public int? OpenMatchfollowupticket(long? ticketid, string EmpID, string spname)
        {
            SqlParameter[] parm = new SqlParameter[5];
            int intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@intTicketID", SqlDbType.BigInt);
                parm[0].Value = ticketid;
                parm[1] = new SqlParameter("@intEmpID", SqlDbType.VarChar);
                parm[1].Value = EmpID;
                parm[2] = new SqlParameter("@Status", SqlDbType.Int);
                parm[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[2].Value.ToString()).Equals(0))
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
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return intStatus;
        }

        public ArrayList SettlementReasonbasedonEmp(string empid, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[2];
                parm[0] = new SqlParameter("@empid", SqlDbType.VarChar);
                parm[0].Value = empid;

                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public ArrayList Dontshowservice(long cust_id, string toprofileid, int empid, string Relation_type, int flag, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[7];
                parm[0] = new SqlParameter("@cust_id", SqlDbType.BigInt);
                parm[0].Value = cust_id;
                parm[1] = new SqlParameter("@tocust_id", SqlDbType.VarChar);
                parm[1].Value = toprofileid;
                parm[2] = new SqlParameter("@empid", SqlDbType.Int);
                parm[2].Value = empid;
                parm[3] = new SqlParameter("@Relation_type", SqlDbType.VarChar);
                parm[3].Value = Relation_type;
                parm[4] = new SqlParameter("@flag", SqlDbType.Int);
                parm[4].Value = flag;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public ArrayList NewmatchfollowupticketCreation(long fromcust_id, long tocust_id, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[3];
                parm[0] = new SqlParameter("@fromcust_id", SqlDbType.BigInt);
                parm[0].Value = fromcust_id;
                parm[1] = new SqlParameter("@tocust_id", SqlDbType.BigInt);
                parm[1].Value = tocust_id;

                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public int? Remindercreation(long fromcust_id, long tocust_id, int? empid, long intTicketID, DateTime? dtRemainderDate, string spname)
        {

            SqlParameter[] parm = new SqlParameter[8];
            int? intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@fromcust_id", SqlDbType.BigInt);
                parm[0].Value = fromcust_id;
                parm[1] = new SqlParameter("@tocust_id", SqlDbType.BigInt);
                parm[1].Value = tocust_id;


                parm[2] = new SqlParameter("@inEmpID", SqlDbType.Int);
                parm[2].Value = empid;

                parm[3] = new SqlParameter("@intTicketID", SqlDbType.BigInt);
                parm[3].Value = intTicketID;

                parm[4] = new SqlParameter("@dtRemainderDate", SqlDbType.DateTime);
                parm[4].Value = dtRemainderDate;

                parm[5] = new SqlParameter("@intStatus", SqlDbType.Int);
                parm[5].Direction = ParameterDirection.Output;

                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[5].Value.ToString()).Equals(0))
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[5].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return intStatus;
        }

        public int? Partnerpreference_Indetailedata(long? CustID, string indetaileddesc, string spname)
        {
            SqlParameter[] parm = new SqlParameter[5];
            int? intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@fromcust_id", SqlDbType.BigInt);
                parm[0].Value = CustID;
                parm[1] = new SqlParameter("@strIndetaildReq", SqlDbType.VarChar);
                parm[1].Value = indetaileddesc;
                parm[2] = new SqlParameter("@intStatus", SqlDbType.Int);
                parm[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[2].Value.ToString()).Equals(0))
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
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return intStatus;
        }

        public getCustomerinfoKeyword InfoCustomer(string Profileid, string spName)
        {

            getCustomerinfoKeyword custinfo = new getCustomerinfoKeyword();
            SqlParameter[] parm = new SqlParameter[10];
            SqlDataReader reader;
            Int64? iNull = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@strProfileId", SqlDbType.VarChar);
                parm[0].Value = Profileid;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        custinfo.ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : null;
                        custinfo.Cust_ID = (reader["Cust_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_ID")) : iNull;
                        custinfo.FullName = (reader["FullName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FullName")) : null;
                        custinfo.PhotoPath = (reader["PhotoPath"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoPath")) : null;
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
            }
            return custinfo;
        }


        public DataTable createSendServiceKeywordSearch(string fromProfileID, string toProfileIDs, bool ischk)
        {
            string strarraytoProfileID = null;
            DataTable dtEncript = new DataTable();
            dtEncript.Columns.Add("FromProfileID");
            dtEncript.Columns.Add("toProfileID");
            dtEncript.Columns.Add("AcceptEncript");

            string[] splitData = !string.IsNullOrEmpty(toProfileIDs) ? toProfileIDs.Split(',') : null;

            if (splitData != null)
            {
                if (ischk == false)
                {
                    for (int iarraycount = 0; splitData.Length > iarraycount; iarraycount++)
                    {
                        strarraytoProfileID = splitData[iarraycount].ToString();
                        string EncriptedText = Commonclass.ReturnEncryptLink("Accept", (!string.IsNullOrEmpty(strarraytoProfileID) ? strarraytoProfileID : null), (!string.IsNullOrEmpty(fromProfileID) ? fromProfileID : null));
                        dtEncript.Rows.Add(strarraytoProfileID, fromProfileID, EncriptedText, 0);
                    }
                }
                else
                {
                    for (int iarraycount = 0; splitData.Length > iarraycount; iarraycount++)
                    {
                        strarraytoProfileID = splitData[iarraycount].ToString();
                        string EncriptedText = Commonclass.ReturnEncryptLink("Accept", (!string.IsNullOrEmpty(fromProfileID) ? fromProfileID : null), (!string.IsNullOrEmpty(strarraytoProfileID) ? strarraytoProfileID : null));
                        dtEncript.Rows.Add(fromProfileID, strarraytoProfileID, EncriptedText, 1);
                    }
                    for (int iarraycount = 0; splitData.Length > iarraycount; iarraycount++)
                    {
                        strarraytoProfileID = splitData[iarraycount].ToString();
                        string EncriptedText = Commonclass.ReturnEncryptLink("Accept", (!string.IsNullOrEmpty(strarraytoProfileID) ? strarraytoProfileID : null), (!string.IsNullOrEmpty(fromProfileID) ? fromProfileID : null));
                        dtEncript.Rows.Add(strarraytoProfileID, fromProfileID, EncriptedText, 0);
                    }
                }
            }


            return dtEncript;
        }

        public int? sendkeywordsearchemal(keywordsearchemail Mobj, string spName)
        {
            int? Istatus = null;
            int? intStatus = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            SqlDataReader reader;
            Mobj.dtnotviewedprofiles = createSendServiceKeywordSearch(Mobj.strProfilid, Mobj.strtoprofilids, Mobj.chkRvr);
            SqlParameter[] parm = new SqlParameter[5];
            try
            {
                parm[0] = new SqlParameter("@v_FromprofileID", SqlDbType.VarChar);
                parm[0].Value = Mobj.strProfilid;
                parm[1] = new SqlParameter("@v_toProfileID", SqlDbType.VarChar);
                parm[1].Value = Mobj.strtoprofilids;
                parm[2] = new SqlParameter("@dtnotviewedprofiles", SqlDbType.Structured);
                parm[2].Value = Mobj.dtnotviewedprofiles;

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
            }
            return intStatus;
        }

        public List<getCustomerinfoKeyword> PhotosOfCustomers(string Profileids, string spName)
        {
            List<getCustomerinfoKeyword> custinfoli = new List<getCustomerinfoKeyword>();
            // getCustomerinfoKeyword custinfo = new getCustomerinfoKeyword();
            SqlParameter[] parm = new SqlParameter[1];
            SqlDataReader reader;
            Int64? iNull = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@strProfileId", SqlDbType.VarChar);
                parm[0].Value = Profileids;
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        getCustomerinfoKeyword custinfo = new getCustomerinfoKeyword();
                        {
                            custinfo.ProfileID = (reader["ProfileID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileID")) : null;
                            custinfo.Cust_ID = (reader["Cust_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_ID")) : iNull;
                            custinfo.FullName = (reader["FullName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FullName")) : null;
                            custinfo.PhotoPath = (reader["PhotoPath"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoPath")) : null;
                        }
                        custinfoli.Add(custinfo);
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
            }
            return custinfoli;
        }

        public ArrayList UnMatchfollowupSlideShowResult(SearchML Mobj, string spName)
        {
            ArrayList arrayList = new ArrayList();

            SqlParameter[] parm = new SqlParameter[15];
            SqlDataReader reader;
            BothsideInterest Binterest = null;
            string empty = "--";
            int? intnull = null;
            long? Lnull = null;
            int intnullVal = 0;
            DateTime? dnull = null;

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
            parm[7].Value = (Mobj.CustID != null && Mobj.CustID != 0) || (Mobj.oppclose == 1 || Mobj.oppclose == 2) ? 1 : Mobj.Spflag;
            parm[8] = new SqlParameter("@cust_id", SqlDbType.Int);
            parm[8].Value = Mobj.CustID;
            parm[9] = new SqlParameter("@Region", SqlDbType.Structured);
            parm[9].Value = Mobj.region;
            parm[10] = new SqlParameter("@ViewedPhoneNumbers", SqlDbType.Int);
            parm[10].Value = Mobj.Viewedcontacts;
            parm[11] = new SqlParameter("@oppclose", SqlDbType.Int);
            parm[11].Value = Mobj.oppclose;
            parm[12] = new SqlParameter("@empwaiting", SqlDbType.Bit);
            parm[12].Value = Mobj.Empwaiting;

            try
            {
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
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
                            Binterest.FromApplicationPhoto = (reader["FromApplicationPhoto"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromApplicationPhoto")).ToString() : null;
                            Binterest.ToApplicationPhoto = (reader["ToApplicationPhoto"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToApplicationPhoto")).ToString() : null;
                            Binterest.FromPaidStatus = (reader["FromPaidStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("FromPaidStatus")) : intnull;
                            Binterest.ToPaidStatus = (reader["ToPaidStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ToPaidStatus")) : intnull;
                            Binterest.FromExpiryDate = (reader["FromExpiryDate"]) != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("FromExpiryDate")) : dnull;
                            Binterest.ToExpiryDate = (reader["ToExpiryDate"]) != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("ToExpiryDate")) : dnull;
                            Binterest.Expressinterestlogid = (reader["ExpressinterestFromlogid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ExpressinterestFromlogid")) : Lnull;
                            Binterest.ExpressinterestTologid = (reader["ExpressinterestTologid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ExpressinterestTologid")) : Lnull;
                            Binterest.fromgenderid = (reader["fromgenderid"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("fromgenderid")) : intnull;
                            Binterest.togenderid = (reader["togenderid"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("togenderid")) : intnull;
                            Binterest.fromIsconfidential = (reader["fromIsconfidential"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("fromIsconfidential")) : intnull;
                            Binterest.fromHighconfidential = (reader["fromHighconfidential"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("fromHighconfidential")) : intnull;
                            Binterest.toIsconfidential = (reader["toIsconfidential"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("toIsconfidential")) : intnull;
                            Binterest.toHighconfidential = (reader["toHighconfidential"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("toHighconfidential")) : intnull;
                            Binterest.FromEmpownerid = (reader["FromEmpownerid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("FromEmpownerid")) : Lnull;
                            Binterest.ToEmpownerid = (reader["ToEmpownerid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ToEmpownerid")) : Lnull;
                            Binterest.fromEmpmobilenumber = (reader["fromEmpmobilenumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("fromEmpmobilenumber")) : null;
                            Binterest.toEmpmobilenumber = (reader["toEmpmobilenumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("toEmpmobilenumber")) : null;
                            Binterest.Fromsurname = (reader["Fromsurname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Fromsurname")) : null;
                            Binterest.Tosurname = (reader["Tosurname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Tosurname")) : null;
                            Binterest.fromonlyempname = (reader["fromonlyempname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("fromonlyempname")) : null;
                            Binterest.toonlyempname = (reader["toonlyempname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("toonlyempname")) : null;

                            Binterest.MFPFromEntered = (reader["MFPFromEntered"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MFPFromEntered")) : null;
                            Binterest.MFPToEntered = (reader["MFPToEntered"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MFPToEntered")) : null;

                            Binterest.FromRemDate = (reader["FromRemDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromRemDate")) : null;
                            Binterest.ToRemDate = (reader["ToRemDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToRemDate")) : null;
                            Binterest.ExpressInterestID = (reader["ExpressInterestID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ExpressInterestID")) : intnull;
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
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return arrayList;
        }

        public int? InsertMonthlyBills(insertmonthlybills Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[6];
            int? intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@dtaymentDate", SqlDbType.DateTime);
                parm[0].Value = Mobj.paymentdate;
                parm[1] = new SqlParameter("@PaymentType", SqlDbType.Int);
                parm[1].Value = Mobj.paymenttype;
                parm[2] = new SqlParameter("@strNarration", SqlDbType.VarChar);
                parm[2].Value = Mobj.paymentnarration;
                parm[3] = new SqlParameter("@intEmpID", SqlDbType.Int);
                parm[3].Value = Mobj.Empid;
                parm[4] = new SqlParameter("@intStatus", SqlDbType.Int);
                parm[4].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
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
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return intStatus;
        }

        public ArrayList PartnerPreferenceEditData(employeeEditpartnerInfo Mobj, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[7];
                parm[0] = new SqlParameter("@strprofileID", SqlDbType.VarChar);
                parm[0].Value = Mobj.strprofileID;
                parm[1] = new SqlParameter("@dtFromdate", SqlDbType.DateTime);
                parm[1].Value = Mobj.dtFromdate;
                parm[2] = new SqlParameter("@dtTodate", SqlDbType.DateTime);
                parm[2].Value = Mobj.dtTodate;
                parm[3] = new SqlParameter("@intSessionValues", SqlDbType.VarChar);
                parm[3].Value = Mobj.intSessionValues;
                parm[4] = new SqlParameter("@intStartId", SqlDbType.Int);
                parm[4].Value = Mobj.startindex;
                parm[5] = new SqlParameter("@intEndId", SqlDbType.Int);
                parm[5].Value = Mobj.endindex;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public int? PartnerPreferenceModifileddata(employeemodifiedpartner Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[6];
            int? intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@intEntryid", SqlDbType.Int);
                parm[0].Value = Mobj.Entryid;
                parm[1] = new SqlParameter("@intEmpid", SqlDbType.Int);
                parm[1].Value = Mobj.Empid;
                parm[2] = new SqlParameter("@intReadStatus", SqlDbType.Int);
                parm[2].Value = Mobj.flag;
                parm[3] = new SqlParameter("@intcustid", SqlDbType.Int);
                parm[3].Value = Mobj.custid;
                parm[4] = new SqlParameter("@intStatus", SqlDbType.Int);
                parm[4].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
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
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return intStatus;
        }

        public ArrayList RegistrationprofilesInformation(employeRegistrationInfo Mobj, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[13];
                parm[0] = new SqlParameter("@intProfileID", SqlDbType.VarChar);
                parm[0].Value = Mobj.strprofileID;
                parm[1] = new SqlParameter("@intCategId", SqlDbType.VarChar);
                parm[1].Value = Mobj.intSessionValues;
                parm[2] = new SqlParameter("@dtFromdate", SqlDbType.DateTime);
                parm[2].Value = Mobj.dtFromdate;
                parm[3] = new SqlParameter("@dtTodate", SqlDbType.DateTime);
                parm[3].Value = Mobj.dtTodate;
                parm[4] = new SqlParameter("@intRegion", SqlDbType.Int);
                parm[4].Value = Mobj.intRegion;
                parm[5] = new SqlParameter("@strBranchID", SqlDbType.VarChar);
                parm[5].Value = Mobj.strBranchID;
                parm[6] = new SqlParameter("@strProfileOwn", SqlDbType.VarChar);
                parm[6].Value = Mobj.strProfileOwn;
                parm[7] = new SqlParameter("@intchkNotdata", SqlDbType.VarChar);
                parm[7].Value = Mobj.intchkNotdata;
                parm[8] = new SqlParameter("@pagefrom", SqlDbType.Int);
                parm[8].Value = Mobj.startindex;
                parm[9] = new SqlParameter("@pageto", SqlDbType.Int);
                parm[9].Value = Mobj.endindex;
                //parm[10] = new SqlParameter("@strNodataType", SqlDbType.VarChar);
                //parm[10].Value = Mobj.strNodataType;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public ArrayList CompareSearchResultsInfo(int? empId, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[2];
                parm[0] = new SqlParameter("@intEmpId", SqlDbType.Int);
                parm[0].Value = empId;

                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public List<slideshowNew> CompareSearchProfiles(string strCustIds, string spName)
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

                SqlParameter[] parm = new SqlParameter[2];

                parm[0] = new SqlParameter("@strCustIds", SqlDbType.VarChar);
                parm[0].Value = strCustIds;

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
                            sh.DOB = reader["DOB"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("DOB")) : Snull;
                            sh.Age = reader["Age"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Age")) : inull;
                            sh.Caste = (reader["MotherTongue"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("MotherTongue")) + "-") : "") + (reader["Caste"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("Caste")).ToString()) : Snull) + (reader["SubCaste"] != DBNull.Value ? ("(" + (reader.GetString(reader.GetOrdinal("SubCaste"))) + ")") : "");
                            sh.maritalstatus = reader["MaritalStatus"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("MaritalStatus")) : Snull;
                            sh.Height = reader["Height"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Height")) : Snull;
                            sh.EducationGroup = reader["EducationGroup"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationGroup")) : Snull;
                            sh.Profession = reader["Profession"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Profession")) : Snull;
                            sh.JobLocation = reader["JobLocation"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("JobLocation")) : Snull;
                            sh.Gender = reader["Gender"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Gender")) : Snull;
                            sh.countrylivingin = reader["CountryLivingin"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("CountryLivingin")) : Snull;
                        }
                        details.Add(sh);
                    }
                }

                reader.Close();

            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), 0, null, null);
            }
            finally
            {
                connection.Close();
            }

            return details;

        }



        public ArrayList KeywordSearchProfileidInfo(string ProfileID, string strSpname)
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
            }
            return arrayList;
        }

        public ArrayList MatchfollowupSelectCounts(int? fromEmpid, int? toEmpid, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[2];
                parm[0] = new SqlParameter("@fromEmpid", SqlDbType.Int);
                parm[0].Value = fromEmpid;
                parm[1] = new SqlParameter("@toEmpid", SqlDbType.Int);
                parm[1].Value = toEmpid;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public ArrayList MatchfollowupSelectBasedOnEmp(int? fromEmpid, int? toEmpid, int? pagefrom, int? pageto, string spName)
        {



            ArrayList arrayList = new ArrayList();

            SqlParameter[] parm = new SqlParameter[5];
            SqlDataReader reader;
            BothsideInterest Binterest = null;
            string empty = "--";
            int? intnull = null;
            long? Lnull = null;
            int intnullVal = 0;
            DateTime? dnull = null;

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            DataTable dt = new DataTable();
            parm[0] = new SqlParameter("@fromEmpid", SqlDbType.Int);
            parm[0].Value = fromEmpid;
            parm[1] = new SqlParameter("@toEmpid", SqlDbType.Int);
            parm[1].Value = toEmpid;
            parm[2] = new SqlParameter("@pagefrom", SqlDbType.Int);
            parm[2].Value = pagefrom;
            parm[3] = new SqlParameter("@pageto", SqlDbType.Int);
            parm[3].Value = pageto;

            try
            {
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
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
                            Binterest.FromApplicationPhoto = (reader["FromApplicationPhoto"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromApplicationPhoto")).ToString() : null;
                            Binterest.ToApplicationPhoto = (reader["ToApplicationPhoto"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToApplicationPhoto")).ToString() : null;
                            Binterest.FromPaidStatus = (reader["FromPaidStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("FromPaidStatus")) : intnull;
                            Binterest.ToPaidStatus = (reader["ToPaidStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ToPaidStatus")) : intnull;
                            Binterest.FromExpiryDate = (reader["FromExpiryDate"]) != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("FromExpiryDate")) : dnull;
                            Binterest.ToExpiryDate = (reader["ToExpiryDate"]) != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("ToExpiryDate")) : dnull;
                            Binterest.Expressinterestlogid = (reader["ExpressinterestFromlogid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ExpressinterestFromlogid")) : Lnull;
                            Binterest.ExpressinterestTologid = (reader["ExpressinterestTologid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ExpressinterestTologid")) : Lnull;
                            Binterest.fromgenderid = (reader["fromgenderid"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("fromgenderid")) : intnull;
                            Binterest.togenderid = (reader["togenderid"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("togenderid")) : intnull;
                            Binterest.fromIsconfidential = (reader["fromIsconfidential"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("fromIsconfidential")) : intnull;
                            Binterest.fromHighconfidential = (reader["fromHighconfidential"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("fromHighconfidential")) : intnull;
                            Binterest.toIsconfidential = (reader["toIsconfidential"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("toIsconfidential")) : intnull;
                            Binterest.toHighconfidential = (reader["toHighconfidential"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("toHighconfidential")) : intnull;
                            Binterest.FromEmpownerid = (reader["FromEmpownerid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("FromEmpownerid")) : Lnull;
                            Binterest.ToEmpownerid = (reader["ToEmpownerid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ToEmpownerid")) : Lnull;
                            Binterest.fromEmpmobilenumber = (reader["fromEmpmobilenumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("fromEmpmobilenumber")) : null;
                            Binterest.toEmpmobilenumber = (reader["toEmpmobilenumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("toEmpmobilenumber")) : null;
                            Binterest.Fromsurname = (reader["Fromsurname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Fromsurname")) : null;
                            Binterest.Tosurname = (reader["Tosurname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Tosurname")) : null;
                            Binterest.fromonlyempname = (reader["fromonlyempname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("fromonlyempname")) : null;
                            Binterest.toonlyempname = (reader["toonlyempname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("toonlyempname")) : null;

                            Binterest.MFPFromEntered = (reader["MFPFromEntered"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MFPFromEntered")) : null;
                            Binterest.MFPToEntered = (reader["MFPToEntered"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MFPToEntered")) : null;

                            Binterest.FromRemDate = (reader["FromRemDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromRemDate")) : null;
                            Binterest.ToRemDate = (reader["ToRemDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToRemDate")) : null;
                            //Binterest.RowID = (reader["RowID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("RowID")) : intnull;
                            Binterest.ExpressInterestID = (reader["ExpressInterestID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ExpressInterestID")) : intnull;
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
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return arrayList;
        }

        public ArrayList MatchfollowupSlideShowResultForwardBackward(SearchML Mobj, string spName)
        {
            ArrayList arrayList = new ArrayList();

            SqlParameter[] parm = new SqlParameter[15];
            SqlDataReader reader;
            BothsideInterest Binterest = null;
            string empty = "--";
            int? intnull = null;
            long? Lnull = null;
            int intnullVal = 0;
            DateTime? dnull = null;

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
            parm[7].Value = (Mobj.CustID != null && Mobj.CustID != 0) || (Mobj.oppclose == 1 || Mobj.oppclose == 2) ? 1 : Mobj.Spflag;
            parm[8] = new SqlParameter("@cust_id", SqlDbType.Int);
            parm[8].Value = Mobj.CustID;
            parm[9] = new SqlParameter("@Region", SqlDbType.Structured);
            parm[9].Value = Mobj.region;
            parm[10] = new SqlParameter("@ViewedPhoneNumbers", SqlDbType.Int);
            parm[10].Value = Mobj.Viewedcontacts;
            parm[11] = new SqlParameter("@oppclose", SqlDbType.Int);
            parm[11].Value = Mobj.oppclose;
            parm[12] = new SqlParameter("@empwaiting", SqlDbType.Bit);
            parm[12].Value = Mobj.Empwaiting;
            parm[13] = new SqlParameter("@intViewPoint", SqlDbType.Int);
            parm[13].Value = Mobj.intViewPoint;
            parm[14] = new SqlParameter("@intBackSear", SqlDbType.Int);
            parm[14].Value = Mobj.intBackSear;
            parm[15] = new SqlParameter("@intFowardSear", SqlDbType.Int);
            parm[15].Value = Mobj.intFowardSear;

            try
            {
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
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
                            Binterest.FromApplicationPhoto = (reader["FromApplicationPhoto"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromApplicationPhoto")).ToString() : null;
                            Binterest.ToApplicationPhoto = (reader["ToApplicationPhoto"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToApplicationPhoto")).ToString() : null;
                            Binterest.FromPaidStatus = (reader["FromPaidStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("FromPaidStatus")) : intnull;
                            Binterest.ToPaidStatus = (reader["ToPaidStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ToPaidStatus")) : intnull;
                            Binterest.FromExpiryDate = (reader["FromExpiryDate"]) != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("FromExpiryDate")) : dnull;
                            Binterest.ToExpiryDate = (reader["ToExpiryDate"]) != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("ToExpiryDate")) : dnull;
                            Binterest.Expressinterestlogid = (reader["ExpressinterestFromlogid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ExpressinterestFromlogid")) : Lnull;
                            Binterest.ExpressinterestTologid = (reader["ExpressinterestTologid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ExpressinterestTologid")) : Lnull;
                            Binterest.fromgenderid = (reader["fromgenderid"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("fromgenderid")) : intnull;
                            Binterest.togenderid = (reader["togenderid"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("togenderid")) : intnull;
                            Binterest.fromIsconfidential = (reader["fromIsconfidential"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("fromIsconfidential")) : intnull;
                            Binterest.fromHighconfidential = (reader["fromHighconfidential"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("fromHighconfidential")) : intnull;
                            Binterest.toIsconfidential = (reader["toIsconfidential"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("toIsconfidential")) : intnull;
                            Binterest.toHighconfidential = (reader["toHighconfidential"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("toHighconfidential")) : intnull;
                            Binterest.FromEmpownerid = (reader["FromEmpownerid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("FromEmpownerid")) : Lnull;
                            Binterest.ToEmpownerid = (reader["ToEmpownerid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ToEmpownerid")) : Lnull;
                            Binterest.fromEmpmobilenumber = (reader["fromEmpmobilenumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("fromEmpmobilenumber")) : null;
                            Binterest.toEmpmobilenumber = (reader["toEmpmobilenumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("toEmpmobilenumber")) : null;
                            Binterest.Fromsurname = (reader["Fromsurname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Fromsurname")) : null;
                            Binterest.Tosurname = (reader["Tosurname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Tosurname")) : null;
                            Binterest.fromonlyempname = (reader["fromonlyempname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("fromonlyempname")) : null;
                            Binterest.toonlyempname = (reader["toonlyempname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("toonlyempname")) : null;

                            Binterest.MFPFromEntered = (reader["MFPFromEntered"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MFPFromEntered")) : null;
                            Binterest.MFPToEntered = (reader["MFPToEntered"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MFPToEntered")) : null;

                            Binterest.FromRemDate = (reader["FromRemDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromRemDate")) : null;
                            Binterest.ToRemDate = (reader["ToRemDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToRemDate")) : null;
                            //Binterest.RowID = (reader["RowID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("RowID")) : intnull;
                            Binterest.ExpressInterestID = (reader["ExpressInterestID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ExpressInterestID")) : intnull;
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
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return arrayList;
        }

        public ArrayList fromExpressToExpressStatusEmail(long? Fromcustid, long? ToCustIds, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@fromCustIds", SqlDbType.BigInt);
                parm[0].Value = Fromcustid;
                parm[1] = new SqlParameter("@ToCustIds", SqlDbType.BigInt);
                parm[1].Value = ToCustIds;
                parm[2] = new SqlParameter("@EmpID", SqlDbType.Int);
                parm[2].Value = null;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public ArrayList ViewFullProfilePaidUnpaidEmail(long? fromCustId, long? toCustId, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@fromCustId", SqlDbType.BigInt);
                parm[0].Value = fromCustId;
                parm[1] = new SqlParameter("@toCust_id", SqlDbType.BigInt);
                parm[1].Value = toCustId;
                parm[2] = new SqlParameter("@intAdminId", SqlDbType.Int);
                parm[2].Value = null;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayList(ds);
        }

        public ArrayList ViewFullProfilePartialInfoEmail(long? toCustId, long? fromCustId, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@toCustid", SqlDbType.BigInt);
                parm[0].Value = toCustId;
                parm[1] = new SqlParameter("@fromCustid", SqlDbType.BigInt);
                parm[1].Value = fromCustId;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayList(ds);
        }

        public ArrayList YesterdayMatchfollowups(int? Empid, int? pagefrom, int? pageto, string spName)
        {
            ArrayList arrayList = new ArrayList();

            SqlParameter[] parm = new SqlParameter[15];
            SqlDataReader reader;
            BothsideInterest Binterest = null;
            string empty = "--";
            int? intnull = null;
            long? Lnull = null;
            int intnullVal = 0;
            DateTime? dnull = null;

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            DataTable dt = new DataTable();
            parm[0] = new SqlParameter("@Empid", SqlDbType.Int);
            parm[0].Value = Empid;
            parm[1] = new SqlParameter("@pagefrom", SqlDbType.Int);
            parm[1].Value = pagefrom;
            parm[2] = new SqlParameter("@pageto", SqlDbType.Int);
            parm[2].Value = pageto;

            try
            {
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
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
                            Binterest.FromApplicationPhoto = (reader["FromApplicationPhoto"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromApplicationPhoto")).ToString() : null;
                            Binterest.ToApplicationPhoto = (reader["ToApplicationPhoto"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToApplicationPhoto")).ToString() : null;
                            Binterest.FromPaidStatus = (reader["FromPaidStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("FromPaidStatus")) : intnull;
                            Binterest.ToPaidStatus = (reader["ToPaidStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ToPaidStatus")) : intnull;
                            Binterest.FromExpiryDate = (reader["FromExpiryDate"]) != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("FromExpiryDate")) : dnull;
                            Binterest.ToExpiryDate = (reader["ToExpiryDate"]) != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("ToExpiryDate")) : dnull;
                            Binterest.Expressinterestlogid = (reader["ExpressinterestFromlogid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ExpressinterestFromlogid")) : Lnull;
                            Binterest.ExpressinterestTologid = (reader["ExpressinterestTologid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ExpressinterestTologid")) : Lnull;
                            Binterest.fromgenderid = (reader["fromgenderid"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("fromgenderid")) : intnull;
                            Binterest.togenderid = (reader["togenderid"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("togenderid")) : intnull;
                            Binterest.fromIsconfidential = (reader["fromIsconfidential"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("fromIsconfidential")) : intnull;
                            Binterest.fromHighconfidential = (reader["fromHighconfidential"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("fromHighconfidential")) : intnull;
                            Binterest.toIsconfidential = (reader["toIsconfidential"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("toIsconfidential")) : intnull;
                            Binterest.toHighconfidential = (reader["toHighconfidential"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("toHighconfidential")) : intnull;
                            Binterest.FromEmpownerid = (reader["FromEmpownerid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("FromEmpownerid")) : Lnull;
                            Binterest.ToEmpownerid = (reader["ToEmpownerid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ToEmpownerid")) : Lnull;
                            Binterest.fromEmpmobilenumber = (reader["fromEmpmobilenumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("fromEmpmobilenumber")) : null;
                            Binterest.toEmpmobilenumber = (reader["toEmpmobilenumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("toEmpmobilenumber")) : null;
                            Binterest.Fromsurname = (reader["Fromsurname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Fromsurname")) : null;
                            Binterest.Tosurname = (reader["Tosurname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Tosurname")) : null;
                            Binterest.fromonlyempname = (reader["fromonlyempname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("fromonlyempname")) : null;
                            Binterest.toonlyempname = (reader["toonlyempname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("toonlyempname")) : null;

                            Binterest.MFPFromEntered = (reader["MFPFromEntered"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MFPFromEntered")) : null;
                            Binterest.MFPToEntered = (reader["MFPToEntered"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MFPToEntered")) : null;

                            Binterest.FromRemDate = (reader["FromRemDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromRemDate")) : null;
                            Binterest.ToRemDate = (reader["ToRemDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToRemDate")) : null;
                            Binterest.RowID = (reader["RowNum"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("RowNum")) : intnull;
                            Binterest.ExpressInterestID = (reader["ExpressInterestID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ExpressInterestID")) : intnull;
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
                //SqlConnection.ClearPool(connection);
                //SqlConnection.ClearAllPools();
            }
            return arrayList;
        }

        public ArrayList YesterdaySettledDeletedInActivePhotosUpload(int? Empid, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@intEmpID", SqlDbType.Int);
                parm[0].Value = Empid;
                //parm[1] = new SqlParameter("@pagefrom", SqlDbType.Int);
                //parm[1].Value = pagefrom;
                //parm[2] = new SqlParameter("@pageto", SqlDbType.Int);
                //parm[2].Value = pageto;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public EmployeeMarketingTicketResponse UnpaidServiceNotUpdatedTickets(unpaidnotupdated Mobj, string spName)
        {
            EmployeeMarketingTicketResponse MarketingTicketResponse = new EmployeeMarketingTicketResponse();
            string strErrorMsg = string.Empty;
            int? intnull = null;
            Int64? longnull = null;
            SqlParameter[] parm = new SqlParameter[12];
            SqlDataReader drReader = null;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@i_EmpID", SqlDbType.Int);
                parm[0].Value = Mobj.i_EmpID;
                parm[1] = new SqlParameter("@i_PageFrom", SqlDbType.Int);
                parm[1].Value = Mobj.i_PageFrom;
                parm[2] = new SqlParameter("@i_PageTo", SqlDbType.Int);
                parm[2].Value = Mobj.i_PageTo;
                parm[3] = new SqlParameter("@Status", SqlDbType.Int);
                parm[3].Direction = ParameterDirection.Output;
                parm[4] = new SqlParameter("@Errormsg", SqlDbType.VarChar, 1000);
                parm[4].Direction = ParameterDirection.Output;
                parm[5] = new SqlParameter("@strRegional", SqlDbType.VarChar);
                parm[5].Value = Mobj.strRegional;
                parm[6] = new SqlParameter("@strBranch", SqlDbType.VarChar);
                parm[6].Value = Mobj.strBranch;
                parm[7] = new SqlParameter("@strProfileowner", SqlDbType.VarChar);
                parm[7].Value = Mobj.strProfileowner;
                parm[8] = new SqlParameter("@intGender", SqlDbType.Int);
                parm[8].Value = Mobj.intGender;
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
                            RegistrationDate = (drReader["RegistrationDate"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("RegistrationDate")).ToString() : string.Empty,
                            Category = (drReader["Category"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("Category")).ToString() : string.Empty,
                            TicketStatus = (drReader["TicketStatus"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("TicketStatus")).ToString() : string.Empty,
                            ProfileID = (drReader["ProfileID"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ProfileID")).ToString() : string.Empty,
                            MybookMarkedProfCount = (drReader["MybookMarkedProfCount"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("MybookMarkedProfCount")).ToString() : string.Empty,
                            WhobookmarkedCount = (drReader["WhobookmarkedCount"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("WhobookmarkedCount")).ToString() : string.Empty,
                            RectViewedProfCount = (drReader["RectViewedProfCount"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("RectViewedProfCount")).ToString() : string.Empty,
                            RectWhoViewedCout = (drReader["RectWhoViewedCout"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("RectWhoViewedCout")).ToString() : string.Empty,
                            IgnoreProfileCount = (drReader["IgnoreProfileCount"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("IgnoreProfileCount")).ToString() : string.Empty,
                            SentPhotoRequestCount = (drReader["SentPhotoRequestCount"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("SentPhotoRequestCount")).ToString() : string.Empty,
                            EmpPhoto = (drReader["EmpPhoto"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("EmpPhoto")).ToString() : string.Empty,
                            EmpName = (drReader["EmpName"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("EmpName")).ToString() : string.Empty,
                            registeredBranch = (drReader["registeredBranch"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("registeredBranch")).ToString() : string.Empty,
                            ReminderDate = (drReader["ReminderDate"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ReminderDate")).ToString() : string.Empty,
                            Lastlogin = (drReader["Lastlogin"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("Lastlogin")).ToString() : string.Empty,
                            LoginCount = (drReader["LoginCount"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("LoginCount")).ToString() : string.Empty,
                            TotalRows = (drReader["TotalRows"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("TotalRows")).ToString() : string.Empty,
                            Emp_Ticket_ID = (drReader["Emp_Ticket_ID"]) != DBNull.Value ? drReader.GetInt64(drReader.GetOrdinal("Emp_Ticket_ID")).ToString() : string.Empty,
                            TicketOpenedOn = (drReader["TicketOpenedOn"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("TicketOpenedOn")).ToString() : string.Empty,
                            ReminderID = (drReader["ReminderID"]) != DBNull.Value ? drReader.GetInt64(drReader.GetOrdinal("ReminderID")) : longnull,
                            EmpMobilenumber = (drReader["EmpMobilenumber"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("EmpMobilenumber")).ToString() : string.Empty,
                            PrimaryEmail = (drReader["PrimaryEmail"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("PrimaryEmail")).ToString() : string.Empty,
                            PrimaryContactNumber = (drReader["PrimaryContactNumber"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("PrimaryContactNumber")).ToString() : string.Empty,
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
                            IsCustContactNumbersID = drReader["IsCustContactNumbersID"] != DBNull.Value ? drReader.GetInt64(drReader.GetOrdinal("IsCustContactNumbersID")) : longnull,
                            NodataFound = drReader["NodataFound"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("NodataFound")) : string.Empty,
                            Photo = drReader["PhotoPath"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("PhotoPath")) : string.Empty,
                            TicketTypeID = drReader["TicketTypeID"] != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("TicketTypeID")).ToString() : string.Empty,
                            ReminderRelationName = drReader["ReminderRelationName"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ReminderRelationName")) : string.Empty,
                            Reminderbody = drReader["ReminderBody"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ReminderBody")) : string.Empty,
                            ReminderRelationID = drReader["ReminderRelationID"] != DBNull.Value ? drReader.GetInt64(drReader.GetOrdinal("ReminderRelationID")) : longnull,
                            SAPath = drReader["SAFORM"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("SAFORM")) : string.Empty,
                            primaryCountryID = drReader["PrimaryContactNumberCountyID"] != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("PrimaryContactNumberCountyID")) : intnull,
                            FatherName = drReader["FatherName"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("FatherName")) : string.Empty,
                            paidStatus = drReader["PaidStatus"] != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("PaidStatus")) : 0
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
                            NAME = drReader["NAME"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("NAME")).ToString() : string.Empty,
                            ReplyDesc = drReader["ReplyDesc"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ReplyDesc")).ToString() : string.Empty,
                            CallStatus = drReader["CallStatus"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("CallStatus")).ToString() : string.Empty,
                            CallReceivedBy = drReader["CallReceivedBy"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("CallReceivedBy")).ToString() : string.Empty,
                            CallDiscussion = drReader["CallDiscussion"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("CallDiscussion")).ToString() : string.Empty,
                            RelationShip = drReader["RelationShip"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("RelationShip")).ToString() : string.Empty,
                            ReplyDate = drReader["ReplyDate"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ReplyDate")).ToString() : string.Empty,
                            TicketingCallHistoryID = drReader["TicketingCallHistoryID"] != DBNull.Value ? drReader.GetInt64(drReader.GetOrdinal("TicketingCallHistoryID")).ToString() : string.Empty,
                            ReminderRelationName = drReader["ReminderRelationName"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ReminderRelationName")) : string.Empty,
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
            }

            return MarketingTicketResponse;
        }

        public ArrayList ArrivalDeparturedates(string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[2];
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public int? InsertSAAmount(int? custid, decimal? saAmount, string spname)
        {
            SqlParameter[] parm = new SqlParameter[4];
            int? intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@intCust_id", SqlDbType.Int);
                parm[0].Value = custid;
                parm[1] = new SqlParameter("@strSettleamt", SqlDbType.Decimal);
                parm[1].Value = saAmount;
                parm[2] = new SqlParameter("@intStatus", SqlDbType.Int);
                parm[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[2].Value.ToString()).Equals(0))
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
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return intStatus;
        }

        public ArrayList EmployeeYesterdayWorkPendingReport(ystryPending mobj, string spName)
        {

            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[4];
                parm[0] = new SqlParameter("@intRegion", SqlDbType.Int);
                parm[0].Value = mobj.strRegional;
                parm[1] = new SqlParameter("@intBranch", SqlDbType.VarChar);
                parm[1].Value = mobj.strBranch;
                parm[2] = new SqlParameter("@intEmpID", SqlDbType.VarChar);
                parm[2].Value = mobj.strProfileowner;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        // schdulepageinfo

        public ArrayList SchdulepageReport(schdulepageinfo mobj, string spName)
        {

            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[10];
                parm[0] = new SqlParameter("@schdulename", SqlDbType.VarChar);
                parm[0].Value = mobj.Schdulename;

                parm[1] = new SqlParameter("@purposepoint", SqlDbType.VarChar);
                parm[1].Value = mobj.Purposepoint;
                parm[2] = new SqlParameter("@timeperiod", SqlDbType.VarChar);
                parm[2].Value = mobj.Timeperiod;

                parm[3] = new SqlParameter("@spname", SqlDbType.VarChar);
                parm[3].Value = mobj.Spname;

                // parm[4] = new SqlParameter("@Runstatus", SqlDbType.VarChar);
                // parm[4].Value = mobj.Runstatus;

                parm[4] = new SqlParameter("@iflag", SqlDbType.Int);
                parm[4].Value = mobj.iflag;

                parm[5] = new SqlParameter("@scdularId", SqlDbType.BigInt);
                parm[5].Value = mobj.scdularId;


                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }
        //schdule end

        // Teamheadinfoend

        public ArrayList Yesterday48hoursSerives(int? Empid, int? pagefrom, int? pageto, string spName)
        {
            ArrayList arrayList = new ArrayList();

            SqlParameter[] parm = new SqlParameter[15];
            SqlDataReader reader;
            BothsideInterest Binterest = null;
            string empty = "--";
            int? intnull = null;
            long? Lnull = null;
            int intnullVal = 0;
            DateTime? dnull = null;

            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();

            DataTable dt = new DataTable();
            parm[0] = new SqlParameter("@Empid", SqlDbType.Int);
            parm[0].Value = Empid;
            parm[1] = new SqlParameter("@pagefrom", SqlDbType.Int);
            parm[1].Value = pagefrom;
            parm[2] = new SqlParameter("@pageto", SqlDbType.Int);
            parm[2].Value = pageto;

            try
            {
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
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
                            Binterest.FromApplicationPhoto = (reader["FromApplicationPhoto"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromApplicationPhoto")).ToString() : null;
                            Binterest.ToApplicationPhoto = (reader["ToApplicationPhoto"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToApplicationPhoto")).ToString() : null;
                            Binterest.FromPaidStatus = (reader["FromPaidStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("FromPaidStatus")) : intnull;
                            Binterest.ToPaidStatus = (reader["ToPaidStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ToPaidStatus")) : intnull;
                            Binterest.FromExpiryDate = (reader["FromExpiryDate"]) != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("FromExpiryDate")) : dnull;
                            Binterest.ToExpiryDate = (reader["ToExpiryDate"]) != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("ToExpiryDate")) : dnull;
                            Binterest.Expressinterestlogid = (reader["ExpressinterestFromlogid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ExpressinterestFromlogid")) : Lnull;
                            Binterest.ExpressinterestTologid = (reader["ExpressinterestTologid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ExpressinterestTologid")) : Lnull;
                            Binterest.fromgenderid = (reader["fromgenderid"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("fromgenderid")) : intnull;
                            Binterest.togenderid = (reader["togenderid"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("togenderid")) : intnull;
                            Binterest.fromIsconfidential = (reader["fromIsconfidential"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("fromIsconfidential")) : intnull;
                            Binterest.fromHighconfidential = (reader["fromHighconfidential"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("fromHighconfidential")) : intnull;
                            Binterest.toIsconfidential = (reader["toIsconfidential"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("toIsconfidential")) : intnull;
                            Binterest.toHighconfidential = (reader["toHighconfidential"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("toHighconfidential")) : intnull;
                            Binterest.FromEmpownerid = (reader["FromEmpownerid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("FromEmpownerid")) : Lnull;
                            Binterest.ToEmpownerid = (reader["ToEmpownerid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ToEmpownerid")) : Lnull;
                            Binterest.fromEmpmobilenumber = (reader["fromEmpmobilenumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("fromEmpmobilenumber")) : null;
                            Binterest.toEmpmobilenumber = (reader["toEmpmobilenumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("toEmpmobilenumber")) : null;
                            Binterest.Fromsurname = (reader["Fromsurname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Fromsurname")) : null;
                            Binterest.Tosurname = (reader["Tosurname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Tosurname")) : null;
                            Binterest.fromonlyempname = (reader["fromonlyempname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("fromonlyempname")) : null;
                            Binterest.toonlyempname = (reader["toonlyempname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("toonlyempname")) : null;

                            Binterest.MFPFromEntered = (reader["MFPFromEntered"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MFPFromEntered")) : null;
                            Binterest.MFPToEntered = (reader["MFPToEntered"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MFPToEntered")) : null;

                            Binterest.FromRemDate = (reader["FromRemDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromRemDate")) : null;
                            Binterest.ToRemDate = (reader["ToRemDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToRemDate")) : null;
                            Binterest.RowID = (reader["RowNum"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("RowNum")) : intnull;
                            Binterest.ExpressInterestID = (reader["ExpressInterestID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ExpressInterestID")) : intnull;
                            Binterest.EmpName = (reader["EmpName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EmpName")) : null;
                            Binterest.ServicePending_EmpID = (reader["ServicePending_EmpID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ServicePending_EmpID")) : intnull;
                            Binterest.ServicePending_EmpName = (reader["ServicePending_EmpName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ServicePending_EmpName")) : null;
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
            }
            return arrayList;
        }



        public ArrayList MatchfollowupSlideShowResult_New(SearchML Mobj, string spName)
        {
            ArrayList arrayList = new ArrayList();

            SqlParameter[] parm = new SqlParameter[16];
            SqlDataReader reader;
            BothsideInterest Binterest = null;
            string empty = "--";
            int? intnull = null;
            long? Lnull = null;
            int intnullVal = 0;
            DateTime? dnull = null;

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
            parm[7].Value = (Mobj.CustID != null && Mobj.CustID != 0) || (Mobj.oppclose == 1 || Mobj.oppclose == 2) ? 1 : Mobj.Spflag;
            parm[8] = new SqlParameter("@cust_id", SqlDbType.Int);
            parm[8].Value = Mobj.CustID;
            parm[9] = new SqlParameter("@Region", SqlDbType.Structured);
            parm[9].Value = Mobj.region;
            parm[10] = new SqlParameter("@ViewedPhoneNumbers", SqlDbType.Int);
            parm[10].Value = Mobj.Viewedcontacts;
            parm[11] = new SqlParameter("@oppclose", SqlDbType.Int);
            parm[11].Value = Mobj.oppclose;
            parm[12] = new SqlParameter("@empwaiting", SqlDbType.Bit);
            parm[12].Value = Mobj.Empwaiting;
            parm[13] = new SqlParameter("@intMyInterest", SqlDbType.Int);
            parm[13].Value = Mobj.intMyInterest;
            try
            {
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);
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
                            Binterest.FromApplicationPhoto = (reader["FromApplicationPhoto"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromApplicationPhoto")).ToString() : null;
                            Binterest.ToApplicationPhoto = (reader["ToApplicationPhoto"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToApplicationPhoto")).ToString() : null;
                            Binterest.FromPaidStatus = (reader["FromPaidStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("FromPaidStatus")) : intnull;
                            Binterest.ToPaidStatus = (reader["ToPaidStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ToPaidStatus")) : intnull;
                            Binterest.FromExpiryDate = (reader["FromExpiryDate"]) != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("FromExpiryDate")) : dnull;
                            Binterest.ToExpiryDate = (reader["ToExpiryDate"]) != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("ToExpiryDate")) : dnull;
                            Binterest.Expressinterestlogid = (reader["ExpressinterestFromlogid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ExpressinterestFromlogid")) : Lnull;
                            Binterest.ExpressinterestTologid = (reader["ExpressinterestTologid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ExpressinterestTologid")) : Lnull;
                            Binterest.fromgenderid = (reader["fromgenderid"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("fromgenderid")) : intnull;
                            Binterest.togenderid = (reader["togenderid"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("togenderid")) : intnull;
                            Binterest.fromIsconfidential = (reader["fromIsconfidential"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("fromIsconfidential")) : intnull;
                            Binterest.fromHighconfidential = (reader["fromHighconfidential"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("fromHighconfidential")) : intnull;
                            Binterest.toIsconfidential = (reader["toIsconfidential"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("toIsconfidential")) : intnull;
                            Binterest.toHighconfidential = (reader["toHighconfidential"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("toHighconfidential")) : intnull;
                            Binterest.FromEmpownerid = (reader["FromEmpownerid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("FromEmpownerid")) : Lnull;
                            Binterest.ToEmpownerid = (reader["ToEmpownerid"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("ToEmpownerid")) : Lnull;
                            Binterest.fromEmpmobilenumber = (reader["fromEmpmobilenumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("fromEmpmobilenumber")) : null;
                            Binterest.toEmpmobilenumber = (reader["toEmpmobilenumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("toEmpmobilenumber")) : null;
                            Binterest.Fromsurname = (reader["Fromsurname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Fromsurname")) : null;
                            Binterest.Tosurname = (reader["Tosurname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Tosurname")) : null;
                            Binterest.fromonlyempname = (reader["fromonlyempname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("fromonlyempname")) : null;
                            Binterest.toonlyempname = (reader["toonlyempname"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("toonlyempname")) : null;

                            Binterest.MFPFromEntered = (reader["MFPFromEntered"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MFPFromEntered")) : null;
                            Binterest.MFPToEntered = (reader["MFPToEntered"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MFPToEntered")) : null;

                            Binterest.FromRemDate = (reader["FromRemDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromRemDate")) : null;
                            Binterest.ToRemDate = (reader["ToRemDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToRemDate")) : null;
                            Binterest.RowID = (reader["RowNum"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("RowNum")) : intnull;
                            Binterest.EmpName = (reader["EmpName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EmpName")) : null;
                            Binterest.ExpressInterestID = (reader["ExpressInterestID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ExpressInterestID")) : intnull;
                            Binterest.ServicePending_EmpID = (reader["ServicePending_EmpID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ServicePending_EmpID")) : intnull;
                            Binterest.ServicePending_EmpName = (reader["ServicePending_EmpName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ServicePending_EmpName")) : null;
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
            }
            return arrayList;
        }

        public ArrayList MatchfollowupCounts(int? intEmpID, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[2];
                parm[0] = new SqlParameter("@fromEmpid", SqlDbType.Int);
                parm[0].Value = intEmpID;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }


        public ArrayList TeamheadReport(Teamheadinfo mobj, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[11];
                parm[0] = new SqlParameter("@intEmpType", SqlDbType.Int);
                parm[0].Value = mobj.EmpType;
                parm[1] = new SqlParameter("@intRegionID", SqlDbType.Int);
                parm[1].Value = mobj.Regions;
                parm[2] = new SqlParameter("@strBranchIds", SqlDbType.VarChar);
                parm[2].Value = mobj.Branchs;
                parm[3] = new SqlParameter("@strEmpIds", SqlDbType.VarChar);
                parm[3].Value = mobj.ProfileOwner;
                parm[4] = new SqlParameter("@strProfGeneral", SqlDbType.VarChar);
                parm[4].Value = mobj.Generalprocess;
                parm[5] = new SqlParameter("@strMarketing", SqlDbType.VarChar);
                parm[5].Value = mobj.Marketingprocess;
                parm[6] = new SqlParameter("@srMatchFollowup", SqlDbType.VarChar);
                parm[6].Value = mobj.MatchFollowupprocess;
                parm[7] = new SqlParameter("@strTeamhead", SqlDbType.VarChar);
                parm[7].Value = mobj.Teamhead;
                parm[8] = new SqlParameter("@istartIndex", SqlDbType.Int);
                parm[8].Value = mobj.istartIndex;
                parm[9] = new SqlParameter("@iEndIndex", SqlDbType.Int);
                parm[9].Value = mobj.iEndIndex;

                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }
        // strickers page start
        public ArrayList StrickersReport(strickerspageinfo mobj, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[6];
                parm[0] = new SqlParameter("@BranchId", SqlDbType.Int);
                parm[0].Value = mobj.BranchId;
                parm[1] = new SqlParameter("@Region", SqlDbType.Int);
                parm[1].Value = mobj.Region;
                parm[2] = new SqlParameter("@ApplicationStatus", SqlDbType.Int);
                parm[2].Value = mobj.ApplicationStatus;

                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }
        // strickers page end



        public ArrayList EmpMatchFollowupandMarketingHistory(employeematchfollowupinfo mobj, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[13];
                parm[0] = new SqlParameter("@intFollowupStatus", SqlDbType.Int);
                parm[0].Value = mobj.intFollowupStatus;
                parm[1] = new SqlParameter("@intCallStatus", SqlDbType.Int);
                parm[1].Value = mobj.intCallStatus;
                parm[2] = new SqlParameter("@intNoOfDays", SqlDbType.Int);
                parm[2].Value = mobj.intNoOfDays;
                parm[3] = new SqlParameter("@intEmpID", SqlDbType.Int);
                parm[3].Value = mobj.intEmpID;
                parm[4] = new SqlParameter("@intVoiceCallType", SqlDbType.Int);
                parm[4].Value = mobj.intVoiceCallType;
                parm[5] = new SqlParameter("@istartindex", SqlDbType.Int);
                parm[5].Value = mobj.istartindex;
                parm[6] = new SqlParameter("@iendIndex", SqlDbType.Int);
                parm[6].Value = mobj.iendIndex;
                parm[7] = new SqlParameter("@dtfromDate", SqlDbType.DateTime);
                parm[7].Value = mobj.dtfromDate;
                parm[8] = new SqlParameter("@dtTodate", SqlDbType.DateTime);
                parm[8].Value = mobj.dtTodate;
                parm[9] = new SqlParameter("@iapplicationStatus", SqlDbType.VarChar);
                parm[9].Value = mobj.iapplicationStatus;
                parm[10] = new SqlParameter("@iCalltype", SqlDbType.Int);
                parm[10].Value = mobj.iCalltype;
             
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
              
            }
              
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        // Accountsdetailspage 
        public ArrayList Accountsdetailspage(accountspageinfo mobj, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[13];
                parm[0] = new SqlParameter("@idate", SqlDbType.Int);
                parm[0].Value = mobj.idate;
                parm[1] = new SqlParameter("@iTypeofPayment", SqlDbType.VarChar);
                parm[1].Value = mobj.iTypeofPayment;
                parm[2] = new SqlParameter("@ibankName", SqlDbType.VarChar);
                parm[2].Value = mobj.ibankName;
                parm[3] = new SqlParameter("@iAmount", SqlDbType.Int);
                parm[3].Value = mobj.iAmount;
                parm[4] = new SqlParameter("@v_Beneficiaryname", SqlDbType.VarChar);
                parm[4].Value = mobj.v_Beneficiaryname;
                parm[5] = new SqlParameter("@ibranchName", SqlDbType.VarChar);
                parm[5].Value = mobj.ibranchName;
                parm[6] = new SqlParameter("@v_Description", SqlDbType.VarChar);
                parm[6].Value = mobj.v_Description;
                parm[7] = new SqlParameter("@iflag", SqlDbType.Int);
                parm[7].Value = mobj.iflag;
               ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);

            }

            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        // viewdetailspage 
        public ArrayList Viewdetailspage(viewpageinfo mobj, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[13];
                parm[0] = new SqlParameter("@datefrom", SqlDbType.Int);
                parm[0].Value = mobj.datefrom;
                parm[1] = new SqlParameter("@dateTo", SqlDbType.Int);
                parm[1].Value = mobj.dateTo;
                parm[2] = new SqlParameter("@typeofPayment", SqlDbType.VarChar);
                parm[2].Value = mobj.typeofPayment;
                parm[3] = new SqlParameter("@bankName", SqlDbType.VarChar);
                parm[3].Value = mobj.bankName;
                parm[4] = new SqlParameter("@Branchname", SqlDbType.VarChar);
                parm[4].Value = mobj.Branchname;
                parm[5] = new SqlParameter("@iflag", SqlDbType.Int);
                parm[5].Value = mobj.iflag;
                parm[6] = new SqlParameter("@Paidstatus", SqlDbType.Int);
                parm[6].Value = mobj.Paidstatus;
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }

            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }


        public int UserProfileForgotPassword(string userName, string spName)
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
                parm[0].Value = userName;
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

                connection.Close();

            }
            return Status;
        }

        public ArrayList TeamleadBranches(string strvalename, int? strflg, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[3];
                parm[0] = new SqlParameter("@strValueName", SqlDbType.VarChar);
                parm[0].Value = strvalename;
                parm[1] = new SqlParameter("@strVFlag", SqlDbType.Int);
                parm[1].Value = strflg;


                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }

        public int? KaakateeyaAgentCalling(kakagentCall Mobj, string spname)
        {
            SqlParameter[] parm = new SqlParameter[10];
            int? intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@AgentNumber", SqlDbType.BigInt);
                parm[0].Value = Mobj.AgentNumber;
                parm[1] = new SqlParameter("@CustomerNumber", SqlDbType.BigInt);
                parm[1].Value = Mobj.CustomerNumber;
                parm[2] = new SqlParameter("@callid", SqlDbType.VarChar);
                parm[2].Value = Mobj.callid;
                parm[3] = new SqlParameter("@StatusMessages", SqlDbType.VarChar);
                parm[3].Value = Mobj.StatusMessages;
                parm[4] = new SqlParameter("@StatusId", SqlDbType.Int);
                parm[4].Value = Mobj.StatusId;
                parm[5] = new SqlParameter("@intStatus", SqlDbType.Int);
                parm[5].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[5].Value.ToString()).Equals(0))
                {
                    intStatus = 0;
                }
                else
                {
                    intStatus = Convert.ToInt32(parm[5].Value);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return intStatus;
        }

        public int? ProfileStatustoActive(string BrideProfileId, string GroomProfileId, string spname)
        {
            SqlParameter[] parm = new SqlParameter[4];
            int? intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                parm[0] = new SqlParameter("@BrideProfileId", SqlDbType.BigInt);
                parm[0].Value = BrideProfileId;
                parm[1] = new SqlParameter("@GroomProfileId", SqlDbType.BigInt);
                parm[1].Value = GroomProfileId;
                parm[2] = new SqlParameter("@intStatus", SqlDbType.Int);
                parm[2].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[2].Value.ToString()).Equals(0))
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
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return intStatus;
        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        public int? MarketingMatchfollowupCompare(fileuploadexcel mobj, string spname)
        {
           
            SqlParameter[] parm = new SqlParameter[4];
            int? intStatus = 0;
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                //parm[0] = new SqlParameter("@DateTime", SqlDbType.DateTime);
                //parm[0].Value = (mobj.exceluploaddate);
                parm[0] = new SqlParameter("@TblDetails", SqlDbType.Structured);
                parm[0].Value = ToDataTable(mobj.exceluploaddatelist);
                parm[1] = new SqlParameter("@intStatus", SqlDbType.Int);
                parm[1].Direction = ParameterDirection.Output;
                DataSet ds = new DataSet();
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spname, parm);
                if (string.Compare(System.DBNull.Value.ToString(), parm[1].Value.ToString()).Equals(0))
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
                Commonclass.ApplicationErrorLog(spname, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return intStatus;
        }

        public ArrayList MarketingTicketHistoryCompareSelect(int? intBranchID, DateTime? dtDateofRecording, string spName)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection();
            connection = SQLHelper.GetSQLConnection();
            connection.Open();
            try
            {
                SqlParameter[] parm = new SqlParameter[3];
                parm[0] = new SqlParameter("@intBranchID", SqlDbType.Int);
                parm[0].Value = intBranchID;
                parm[1] = new SqlParameter("@dtDateofRecording", SqlDbType.DateTime);
                parm[1].Value = dtDateofRecording;


                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, spName, parm);
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog(spName, Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                connection.Close();
            }
            return Commonclass.convertdataTableToArrayListTable(ds);
        }
    }
}
