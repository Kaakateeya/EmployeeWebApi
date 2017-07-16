﻿using System;
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
                parm[31] = new SqlParameter("@intTableType", SqlDbType.Int);
                parm[31].Value = Mobj.intTableType;
                parm[32] = new SqlParameter("@v_MaritalStatus", SqlDbType.VarChar);
                parm[32].Value = Mobj.v_MaritalStatus;
                parm[33] = new SqlParameter("@i_Domacile", SqlDbType.Int);
                parm[33].Value = Mobj.i_Domacile;
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
                            myprofile.KMPLID = (reader["KMPLID"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("KMPLID")) : empty;
                            myprofile.paid = (reader["paid"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("paid")) : false;
                            myprofile.IsConfidential = (reader["IsConfidential"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("IsConfidential")) : false;
                            myprofile.SuperConfidentila = (reader["SuperConfidentila"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("SuperConfidentila")) : false;

                            myprofile.FirstName = (reader["FirstName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FirstName")) : empty;
                            myprofile.LastName = (reader["LastName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("LastName")) : empty;
                            myprofile.NoOfBrothers = (reader["NoOfBrothers"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("NoOfBrothers")) : intnull;
                            myprofile.NoOfSisters = (reader["NoOfSisters"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("NoOfSisters")) : intnull;
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
                            myprofile.CountryCodeID = (reader["CountryCodeID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CountryCodeID")) : intnull;
                            myprofile.Reason4InActive = (reader["Reason4InActive"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Reason4InActive")) : empty;
                            myprofile.mothertongue = (reader["MotherTongue"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("MotherTongue")) : empty;
                            myprofile.PhotoCount = (reader["PhotoCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoCount")) : intnull;
                            myprofile.CreatedDate = (reader["CreatedDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CreatedDate")) : empty;
                            myprofile.Cust_Family_ID = (reader["Cust_Family_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_Family_ID")) : iLong;

                            //if (Mobj.intTableType == 1)
                            //{
                            myprofile.GenderID = (reader["Gender"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Gender")) : empty;
                            myprofile.SubCaste = (reader["SubCaste"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("SubCaste")) : empty;
                            myprofile.Age = (reader["Age"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Age")) : intnull;
                            myprofile.Height = (reader["Height"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Height")) : empty;
                            myprofile.Color = (reader["Color"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Color")) : empty;
                            myprofile.EducationGroup = (reader["EducationGroup"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationGroup")) : empty;
                            myprofile.Profession = (reader["Profession"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Profession")) : empty;
                            myprofile.JobLocation = (reader["JobLocation"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("JobLocation")) : empty;
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
                            myprofile.PlaceOfBirth = (reader["PlaceOfBirth"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PlaceOfBirth")) : empty;
                            myprofile.Photo = (reader["Photo"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Photo")) : empty;
                            myprofile.PhotoNames = (reader["PhotoNames"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("PhotoNames")) : empty;
                            myprofile.currency = (reader["currency"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("currency")) : empty;
                            myprofile.Ownerflag = (reader["Ownerflag"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("Ownerflag")) : false;
                            myprofile.RegistrationDate = (reader["RegistrationDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("RegistrationDate")) : empty;
                            myprofile.UploadedPhotoscount = (reader["UploadedPhotoscount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("UploadedPhotoscount")) : intnull;
                            myprofile.PhotoshopCount = (reader["PhotoshopCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoshopCount")) : intnull;
                            //myprofile.onlinepaid = (reader["onlinepaid"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("onlinepaid")) : empty;
                            //myprofile.offlinepaid = (reader["offlinepaid"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("offlinepaid")) : empty;
                            //myprofile.onlinepaidcls = (reader["onlinepaidcls"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("onlinepaidcls")) : empty;
                            //myprofile.offlinepaidcls = (reader["offlinepaidcls"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("offlinepaidcls")) : empty;
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

                            //}

                            //if (Mobj.intTableType == 0)
                            //{

                            myprofile.ApplicationPhotoPath = (reader["ApplicationPhotoPath"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ApplicationPhotoPath")) : empty;
                            myprofile.DOR = (reader["DOR"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("DOR")) : empty;
                            myprofile.LastLoginDate = (reader["LastLoginDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("LastLoginDate")) : empty;
                            // myprofile.LoginCount = (reader["LoginCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("LoginCount")) : intnull;
                            myprofile.PaidAmount = (reader["Payment"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Payment")) : empty;
                            myprofile.ContactNumber = (reader["ContactNumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ContactNumber")) : empty;
                            //  myprofile.Email = (reader["Email"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Email")) : empty;
                            // myprofile.MybookMarkedProfCount = (reader["MybookMarkedProfCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("MybookMarkedProfCount")) : intnull;
                            //  myprofile.WhobookmarkedCount = (reader["WhobookmarkedCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("WhobookmarkedCount")) : intnull;
                            //myprofile.RectViewedProfCount = (reader["RectViewedProfCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("RectViewedProfCount")) : intnull;
                            //  myprofile.RectWhoViewedCout = (reader["RectWhoViewedCout"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("RectWhoViewedCout")) : intnull;
                            // myprofile.IgnoreProfileCount = (reader["IgnoreProfileCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("IgnoreProfileCount")) : intnull;
                            // myprofile.SentPhotoRequestCount = (reader["SentPhotoRequestCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("SentPhotoRequestCount")) : intnull;
                            myprofile.EmpName = (reader["EmpName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EmpName")) : empty;
                            myprofile.UserName = (reader["UserName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("UserName")) : empty;

                            myprofile.Row = (reader["Row"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Row")) : iLong;
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
                            //Binterest.FromofflineDetails = (reader["FromofflineDetails"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromofflineDetails")) : empty;
                            //Binterest.FromonlineDetails = (reader["FromonlineDetails"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromonlineDetails")) : empty;
                            // Binterest.TofflineDetails = (reader["TofflineDetails"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("TofflineDetails")) : empty;
                            //Binterest.ToonlineDetails = (reader["ToonlineDetails"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToonlineDetails")) : empty;
                            // Binterest.FromOfflineExpiryDate = (reader["FromOfflineExpiryDate"]) != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("FromOfflineExpiryDate")).ToString() : empty;
                            // Binterest.FromOnlineMembershipExpiryDate = (reader["FromOnlineMembershipExpiryDate"]) != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("FromOnlineMembershipExpiryDate")).ToString() : empty;
                            // Binterest.ToOfflineExpiryDate = (reader["ToOfflineExpiryDate"]) != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("ToOfflineExpiryDate")).ToString() : empty;
                            //Binterest.ToonlineExpiryDate = (reader["ToonlineExpiryDate"]) != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("ToonlineExpiryDate")).ToString() : empty;
                            Binterest.FromApplicationPhoto = (reader["FromApplicationPhoto"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromApplicationPhoto")).ToString() : null;
                            Binterest.ToApplicationPhoto = (reader["ToApplicationPhoto"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ToApplicationPhoto")).ToString() : null;
                            Binterest.FromPaidStatus = (reader["FromPaidStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("FromPaidStatus")) : intnull;
                            Binterest.ToPaidStatus = (reader["ToPaidStatus"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ToPaidStatus")) : intnull;
                            Binterest.FromExpiryDate = (reader["FromExpiryDate"]) != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("FromExpiryDate")) : dnull;
                            Binterest.ToExpiryDate = (reader["ToExpiryDate"]) != DBNull.Value ? reader.GetDateTime(reader.GetOrdinal("ToExpiryDate")) : dnull;

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

                parm[16] = new SqlParameter("@i_Onlineeexpiry", SqlDbType.Int);
                parm[16].Value = Mobj.v_OnlineExprd;
                //parm[17] = new SqlParameter("@i_Ooflineexpiry", SqlDbType.Int);
                //parm[17].Value = Mobj.v_OfflineExprd;

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
                            //Prirority = (drReader["Prirority"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("Prirority")).ToString() : string.Empty,
                            RegistrationDate = (drReader["RegistrationDate"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("RegistrationDate")).ToString() : string.Empty,
                            //HighPriority = (drReader["HighPriority"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("HighPriority")).ToString() : string.Empty,
                            Category = (drReader["Category"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("Category")).ToString() : string.Empty,
                            TicketStatus = (drReader["TicketStatus"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("TicketStatus")).ToString() : string.Empty,
                            ProfileID = (drReader["ProfileID"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ProfileID")).ToString() : string.Empty,
                            //TicketIDSuffix = (drReader["TicketIDSuffix"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("TicketIDSuffix")).ToString() : string.Empty,
                            //CustLandingContID = (drReader["CustLandingContID"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("CustLandingContID")).ToString() : string.Empty,
                            MybookMarkedProfCount = (drReader["MybookMarkedProfCount"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("MybookMarkedProfCount")).ToString() : string.Empty,
                            WhobookmarkedCount = (drReader["WhobookmarkedCount"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("WhobookmarkedCount")).ToString() : string.Empty,
                            RectViewedProfCount = (drReader["RectViewedProfCount"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("RectViewedProfCount")).ToString() : string.Empty,
                            RectWhoViewedCout = (drReader["RectWhoViewedCout"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("RectWhoViewedCout")).ToString() : string.Empty,
                            IgnoreProfileCount = (drReader["IgnoreProfileCount"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("IgnoreProfileCount")).ToString() : string.Empty,
                            SentPhotoRequestCount = (drReader["SentPhotoRequestCount"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("SentPhotoRequestCount")).ToString() : string.Empty,
                            EmpPhoto = (drReader["EmpPhoto"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("EmpPhoto")).ToString() : string.Empty,
                            EmpName = (drReader["EmpName"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("EmpName")).ToString() : string.Empty,
                            //PhotoCount = (drReader["PhotoCount"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("PhotoCount")).ToString() : string.Empty,
                            registeredBranch = (drReader["registeredBranch"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("registeredBranch")).ToString() : string.Empty,
                            ReminderDate = (drReader["ReminderDate"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ReminderDate")).ToString() : string.Empty,
                            Lastlogin = (drReader["Lastlogin"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("Lastlogin")).ToString() : string.Empty,
                            LoginCount = (drReader["LoginCount"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("LoginCount")).ToString() : string.Empty,
                            TotalRows = (drReader["TotalRows"]) != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("TotalRows")).ToString() : string.Empty,
                            Emp_Ticket_ID = (drReader["Emp_Ticket_ID"]) != DBNull.Value ? drReader.GetInt64(drReader.GetOrdinal("Emp_Ticket_ID")).ToString() : string.Empty,
                            TicketOpenedOn = (drReader["TicketOpenedOn"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("TicketOpenedOn")).ToString() : string.Empty,
                            ReminderID = (drReader["ReminderID"]) != DBNull.Value ? drReader.GetInt64(drReader.GetOrdinal("ReminderID")) : longnull,
                            //ReminderDatepopup = (drReader["ReminderDatepopup"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ReminderDatepopup")).ToString() : string.Empty,
                            EmpMobilenumber = (drReader["EmpMobilenumber"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("EmpMobilenumber")).ToString() : string.Empty,
                            PrimaryEmail = (drReader["PrimaryEmail"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("PrimaryEmail")).ToString() : string.Empty,
                            PrimaryContactNumber = (drReader["PrimaryContactNumber"]) != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("PrimaryContactNumber")).ToString() : string.Empty,
                            //AssignedToEmpID = (drReader["AssignedToEmpID"]) != DBNull.Value ? drReader.GetInt64(drReader.GetOrdinal("AssignedToEmpID")) : longnull,
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
                            //isCustEmailID = drReader["isCustEmailID"] != DBNull.Value ? drReader.GetInt64(drReader.GetOrdinal("isCustEmailID")) : longnull,
                            IsCustContactNumbersID = drReader["IsCustContactNumbersID"] != DBNull.Value ? drReader.GetInt64(drReader.GetOrdinal("IsCustContactNumbersID")) : longnull,
                            NodataFound = drReader["NodataFound"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("NodataFound")) : string.Empty,
                            Photo = drReader["PhotoPath"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("PhotoPath")) : string.Empty,
                            TicketTypeID = drReader["TicketTypeID"] != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("TicketTypeID")).ToString() : string.Empty,
                            ReminderRelationName = drReader["ReminderRelationName"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ReminderRelationName")) : string.Empty,
                            Reminderbody = drReader["ReminderBody"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("ReminderBody")) : string.Empty,
                            ReminderRelationID = drReader["ReminderRelationID"] != DBNull.Value ? drReader.GetInt64(drReader.GetOrdinal("ReminderRelationID")) : longnull,
                            SAPath = drReader["SAFORM"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("SAFORM")) : string.Empty,
                            primaryCountryID = drReader["PrimaryContactNumberCountyID"] != DBNull.Value ? drReader.GetInt32(drReader.GetOrdinal("PrimaryContactNumberCountyID")) : intnull,
                            FatherName = drReader["FatherName"] != DBNull.Value ? drReader.GetString(drReader.GetOrdinal("FatherName")) : string.Empty

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
                                sh.MobileNumber = reader["MobileNumber"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("MobileNumber")) : Snull;
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
                                Marketing.ReminderID = reader["ReminderID"] != DBNull.Value ? (reader.GetInt64(reader.GetOrdinal("ReminderID"))) : iLong;
                                Marketing.ReminderDate = reader["ReminderDate"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("ReminderDate"))).ToString() : Snull;
                                Marketing.TicketTypeID = reader["TicketTypeID"] != DBNull.Value ? (reader.GetInt32(reader.GetOrdinal("TicketTypeID"))) : iNULLs;
                                Marketing.ReminderRelationID = reader["ReminderRelationID"] != DBNull.Value ? (reader.GetInt64(reader.GetOrdinal("ReminderRelationID"))) : iLong;
                                Marketing.ReminderRelationName = reader["ReminderRelationName"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("ReminderRelationName"))).ToString() : Snull;
                                Marketing.Category = reader["Category"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("Category"))).ToString() : Snull;
                                Marketing.Reminderbody = reader["Reminderbody"] != DBNull.Value ? (reader.GetString(reader.GetOrdinal("Reminderbody"))).ToString() : Snull;
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

        // Communication log page

        #region

        public List<EmpCommunication> EmployeeCommunicationLog(string ProfileID, int? intEmpId, string spName)
        {
            List<CommunicationLogResult> details1 = new List<CommunicationLogResult>();
            List<CommunicationLogResult> details2 = new List<CommunicationLogResult>();
            List<CommunicationLogResult> details3 = new List<CommunicationLogResult>();
            List<CommunicationLogResult> details4 = new List<CommunicationLogResult>();
            List<EmpCommunication> logList = new List<EmpCommunication>();

            SqlDataReader reader;
            int? iNull = null;
            Int64? LNull = null;

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
                reader = SQLHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, parm);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CommunicationLogResult display = new CommunicationLogResult();
                        {

                            display.ProfileID = reader["ProfileID"] != DBNull.Value ? (reader["ProfileID"]).ToString() : null;
                            display.Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : null;
                            display.ServiceDate = reader["ServiceDate"] != DBNull.Value ? reader["ServiceDate"].ToString() : null;
                            display.TypeOfService = reader["TypeOfService"] != DBNull.Value ? reader["TypeOfService"].ToString() : null;
                            display.EmpName = reader["EmpName"] != DBNull.Value ? reader["EmpName"].ToString() : null;
                            display.Branch = reader["BranchName"] != DBNull.Value ? reader["BranchName"].ToString() : null;
                            display.MFPStatus = reader["MFPStatus"] != DBNull.Value ? reader["MFPStatus"].ToString() : null;
                            display.MFPStatusDate = reader["MFPStatusDate"] != DBNull.Value ? reader["MFPStatusDate"].ToString() : null;
                            display.TicketID = reader["TicketID"] != DBNull.Value ? reader["TicketID"].ToString() : null;
                            display.Emp_FollowupTicket_ID = reader["Emp_FollowupTicket_ID"] != DBNull.Value ? Convert.ToInt64(reader["Emp_FollowupTicket_ID"]) : LNull;
                            display.ProfileStatusID = reader["ProfileStatusID"] != DBNull.Value ? Convert.ToInt32(reader["ProfileStatusID"]) : iNull;
                            display.TicketStatusID = reader["TicketStatusID"] != DBNull.Value ? Convert.ToInt32(reader["TicketStatusID"]) : iNull;
                            display.TotalRows = reader["TotalRows"] != DBNull.Value ? Convert.ToInt32(reader["TotalRows"]) : iNull;
                            display.ProfileOwner = reader["ProfileOwner"] != DBNull.Value ? reader["ProfileOwner"].ToString() : null;
                            display.ExpressInterestID = reader["ExpressInterestID"] != DBNull.Value ? Convert.ToInt32(reader["ExpressInterestID"]) : iNull;
                            display.LogID = reader["LogID"] != DBNull.Value ? reader["LogID"] : LNull;
                            display.ISRvrSend = reader["ISRvrSend"] != DBNull.Value ? reader["ISRvrSend"] : iNull;
                            display.PD = reader["I"] != DBNull.Value ? Convert.ToInt32(reader["I"]) : iNull;
                            display.DPD = reader["NI"] != DBNull.Value ? Convert.ToInt32(reader["NI"]) : iNull;
                            display.Viewed = reader["V"] != DBNull.Value ? Convert.ToInt32(reader["V"]) : iNull;
                            display.NViewed = reader["NV"] != DBNull.Value ? Convert.ToInt32(reader["NV"]) : iNull;
                            display.paid = reader["Paid"] != DBNull.Value ? Convert.ToInt32(reader["Paid"]) : iNull;
                            display.ProfileStatus = reader["ProfileStatus"] != DBNull.Value ? reader["ProfileStatus"].ToString() : null;

                            display.iFromCustID = reader["FromCustID"] != DBNull.Value ? Convert.ToInt32(reader["FromCustID"]) : iNull;
                            display.FromName = reader["FromName"] != DBNull.Value ? reader["FromName"].ToString() : null;
                            display.iToCustID = reader["ToCustID"] != DBNull.Value ? Convert.ToInt32(reader["ToCustID"]) : iNull;

                        }

                        details1.Add(display);
                    }

                }

                logList.Add(new EmpCommunication { log = details1 });
                reader.NextResult();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CommunicationLogResult display = new CommunicationLogResult();
                        {
                            display.ProfileID = reader["ProfileID"] != DBNull.Value ? (reader["ProfileID"]).ToString() : null;
                            //display.ServiceID = reader["ServiceID"] != DBNull.Value ? reader["ServiceID"].ToString() : null;
                            display.Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : null;
                            display.ServiceDate = reader["ServiceDate"] != DBNull.Value ? reader["ServiceDate"].ToString() : null;
                            display.TypeOfService = reader["TypeOfService"] != DBNull.Value ? reader["TypeOfService"].ToString() : null;
                            display.EmpName = reader["EmpName"] != DBNull.Value ? reader["EmpName"].ToString() : null;
                            display.Branch = reader["BranchName"] != DBNull.Value ? reader["BranchName"].ToString() : null;
                            display.MFPStatus = reader["MFPStatus"] != DBNull.Value ? reader["MFPStatus"].ToString() : null;
                            display.MFPStatusDate = reader["MFPStatusDate"] != DBNull.Value ? reader["MFPStatusDate"].ToString() : null;
                            display.TicketID = reader["TicketID"] != DBNull.Value ? reader["TicketID"].ToString() : null;
                            display.Emp_FollowupTicket_ID = reader["Emp_FollowupTicket_ID"] != DBNull.Value ? Convert.ToInt64(reader["Emp_FollowupTicket_ID"]) : LNull;
                            display.ProfileStatusID = reader["ProfileStatusID"] != DBNull.Value ? Convert.ToInt32(reader["ProfileStatusID"]) : iNull;
                            display.TicketStatusID = reader["TicketStatusID"] != DBNull.Value ? Convert.ToInt32(reader["TicketStatusID"]) : iNull;
                            display.TotalRows = reader["TotalRows"] != DBNull.Value ? Convert.ToInt32(reader["TotalRows"]) : iNull;
                            display.ProfileOwner = reader["ProfileOwner"] != DBNull.Value ? reader["ProfileOwner"].ToString() : null;
                            display.ExpressInterestID = reader["ExpressInterestID"] != DBNull.Value ? Convert.ToInt32(reader["ExpressInterestID"]) : iNull;
                            display.LogID = reader["LogID"] != DBNull.Value ? reader["LogID"] : LNull;
                            display.ISRvrSend = reader["ISRvrSend"] != DBNull.Value ? reader["ISRvrSend"] : iNull;
                            display.PhotoCount = reader["PhotoCount"] != DBNull.Value ? reader["PhotoCount"] : iNull;
                            //
                            display.PD = reader["I"] != DBNull.Value ? Convert.ToInt32(reader["I"]) : iNull;
                            display.DPD = reader["NI"] != DBNull.Value ? Convert.ToInt32(reader["NI"]) : iNull;
                            display.Viewed = reader["V"] != DBNull.Value ? Convert.ToInt32(reader["V"]) : iNull;
                            display.NViewed = reader["NV"] != DBNull.Value ? Convert.ToInt32(reader["NV"]) : iNull;
                            display.paid = reader["Paid"] != DBNull.Value ? Convert.ToInt32(reader["Paid"]) : iNull;

                            //
                            display.ProfileStatus = reader["ProfileStatus"] != DBNull.Value ? reader["ProfileStatus"].ToString() : null;
                            display.ServiceExpiryDate = reader["ServiceExpiryDate"] != DBNull.Value ? reader["ServiceExpiryDate"].ToString() : null;
                            display.ServicePoints = reader["ServicePoints"] != DBNull.Value ? reader["ServicePoints"].ToString() : null;

                            display.iFromCustID = reader["FromCustID"] != DBNull.Value ? Convert.ToInt32(reader["FromCustID"]) : iNull;
                            display.FromName = reader["FromName"] != DBNull.Value ? reader["FromName"].ToString() : null;
                            display.iToCustID = reader["ToCustID"] != DBNull.Value ? Convert.ToInt32(reader["ToCustID"]) : iNull;
                            display.FromEmail = reader["FromEmail"] != DBNull.Value ? reader["FromEmail"].ToString() : null;
                        }
                        details2.Add(display);
                    }

                }

                logList.Add(new EmpCommunication { log = details2 });
                reader.NextResult();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CommunicationLogResult display = new CommunicationLogResult();
                        {
                            display.ProfileID = reader["ProfileID"] != DBNull.Value ? (reader["ProfileID"]).ToString() : null;
                            display.Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : null;
                            display.ResendDate = reader["ResendDate"] != DBNull.Value ? reader["ResendDate"].ToString() : null;
                            display.TypeOfService = reader["TypeOfService"] != DBNull.Value ? reader["TypeOfService"].ToString() : null;
                            display.EmpName = reader["EmpName"] != DBNull.Value ? reader["EmpName"].ToString() : null;
                            display.Branch = reader["BranchName"] != DBNull.Value ? reader["BranchName"].ToString() : null;
                            display.ServiceDate = reader["ServiceDate"] != DBNull.Value ? reader["ServiceDate"].ToString() : null;
                            display.ProfileStatusID = reader["ProfileStatusID"] != DBNull.Value ? Convert.ToInt32(reader["ProfileStatusID"]) : iNull;
                            display.TotalRows = reader["TotalRows"] != DBNull.Value ? Convert.ToInt32(reader["TotalRows"]) : iNull;
                            display.paid = reader["Paid"] != DBNull.Value ? Convert.ToInt32(reader["Paid"]) : iNull;
                            display.ProfileStatus = reader["ProfileStatus"] != DBNull.Value ? reader["ProfileStatus"].ToString() : null;

                            display.iFromCustID = reader["FromCustID"] != DBNull.Value ? Convert.ToInt32(reader["FromCustID"]) : iNull;
                            display.FromName = reader["FromName"] != DBNull.Value ? reader["FromName"].ToString() : null;
                            display.iToCustID = reader["ToCustID"] != DBNull.Value ? Convert.ToInt32(reader["ToCustID"]) : iNull;

                        }
                        details3.Add(display);
                    }

                }

                logList.Add(new EmpCommunication { log = details3 });

                reader.NextResult();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CommunicationLogResult display = new CommunicationLogResult();
                        {
                            display.Sno = reader["Sno"] != DBNull.Value ? Convert.ToInt32(reader["Sno"]) : iNull;
                            display.ProfileID = reader["ProfileID"] != DBNull.Value ? (reader["ProfileID"]).ToString() : null;
                            display.Name = reader["FirstName"] != DBNull.Value ? reader["FirstName"].ToString() : null;
                            display.LastName = reader["LastName"] != DBNull.Value ? reader["LastName"].ToString() : null;
                            display.ProfileOwner = reader["EmpName"] != DBNull.Value ? reader["EmpName"].ToString() : null;
                            display.MeetingDate = reader["MeetingDate"] != DBNull.Value ? reader["MeetingDate"].ToString() : null;
                            display.TotalRows = reader["TotalRows"] != DBNull.Value ? Convert.ToInt32(reader["TotalRows"]) : iNull;
                            display.paid = reader["Paid"] != DBNull.Value ? Convert.ToInt32(reader["Paid"]) : iNull;
                            display.ProfileStatus = reader["ProfileStatus"] != DBNull.Value ? reader["ProfileStatus"].ToString() : null;

                            display.iFromCustID = reader["FromCustID"] != DBNull.Value ? Convert.ToInt32(reader["FromCustID"]) : iNull;
                            display.FromName = reader["FromName"] != DBNull.Value ? reader["FromName"].ToString() : null;
                            display.iToCustID = reader["ToCustID"] != DBNull.Value ? Convert.ToInt32(reader["ToCustID"]) : iNull;
                        }

                        details4.Add(display);
                    }
                }

                logList.Add(new EmpCommunication { log = details4 });

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

            return logList;
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
                                display.ProfileID = reader["ProfileID"] != DBNull.Value ? (reader["ProfileID"]).ToString() : null;
                                display.Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : null;
                                display.ResendDate = reader["ResendDate"] != DBNull.Value ? reader["ResendDate"].ToString() : null;
                                display.TypeOfService = reader["TypeOfService"] != DBNull.Value ? reader["TypeOfService"].ToString() : null;
                                display.EmpName = reader["EmpName"] != DBNull.Value ? reader["EmpName"].ToString() : null;
                                display.Branch = reader["BranchName"] != DBNull.Value ? reader["BranchName"].ToString() : null;
                                display.ServiceDate = reader["ServiceDate"] != DBNull.Value ? reader["ServiceDate"].ToString() : null;
                                display.ProfileStatusID = reader["ProfileStatusID"] != DBNull.Value ? Convert.ToInt32(reader["ProfileStatusID"]) : iNull;
                                display.TotalRows = reader["TotalRows"] != DBNull.Value ? Convert.ToInt32(reader["TotalRows"]) : iNull;
                                display.paid = reader["Paid"] != DBNull.Value ? Convert.ToInt32(reader["Paid"]) : iNull;
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
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
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
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
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
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
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
                            sh.ActiveCount = reader["ActiveCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("ActiveCount")) : inull;
                            sh.DeletedCount = reader["DeletedCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("DeletedCount")) : inull;
                            sh.SettledCount = reader["SettledCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("SettledCount")) : inull;
                            sh.InActiveCount = reader["InActiveCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("InActiveCount")) : inull;
                            sh.MMSerious = reader["MMSerious"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("MMSerious")) : inull;
                            sh.TicketID = reader["TicketID"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("TicketID")) : Lnull;
                            sh.TicketHistoryID = reader["TicketHisID"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("TicketHisID")) : Snull;
                            sh.paid = reader["PaidStatus"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PaidStatus")) : inull;
                            sh.NoOfBrothers = reader["NoOfBrothers"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("NoOfBrothers")) : inull;
                            sh.NoOfSisters = reader["NoOfSisters"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("NoOfSisters")) : inull;
                            sh.Age = reader["Age"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Age")) : inull;
                            sh.DOB = reader["DateOfBirth"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("DateOfBirth")) : Snull;
                            sh.TOB = reader["TimeofBirth"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("TimeofBirth")) : Snull;
                            sh.PlaceOfBirth = reader["PlaceofBirth"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("PlaceofBirth")) : Snull;
                            sh.Gothram = reader["Gothram"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Gothram")) : Snull;
                            sh.fathercaste = reader["FatherCaste"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("FatherCaste")) : Snull;
                            sh.mothercaste = reader["MotherCaste"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("MotherCaste")) : Snull;
                            sh.maritalstatus = reader["MaritalStatus"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("MaritalStatus")) : Snull;
                            sh.Star = reader["Star"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Star")) : Snull;
                            sh.Color = reader["Color"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Color")) : Snull;
                            sh.Height = reader["Height"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Height")) : Snull;
                            sh.EducationGroup = reader["EducationCategory"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationCategory")) : Snull;
                            sh.EduGroupnamenew = reader["EducationGroupName"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("EducationGroupName")) : Snull;
                            sh.Profession = reader["ProfessionDetails"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfessionDetails")) : Snull;
                            sh.JobLocation = reader["JobLocation"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("JobLocation")) : Snull;
                            sh.Income = reader["MonthlyIncome"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("MonthlyIncome")) : Snull;
                            sh.FFNative = reader["FatherNativePlace"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("FatherNativePlace")) : Snull;
                            sh.MFNative = reader["MotherNativePlace"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("MotherNativePlace")) : Snull;
                            sh.Property = reader["Property"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("Property")) : Snull;
                            sh.PhotoCount = reader["PhotoCount"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("PhotoCount")) : inull;
                            sh.CustomerFullPhoto = reader["FromApplicationPhoto"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("FromApplicationPhoto")) : Snull;
                            sh.KMPL = reader["KMPLID"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("KMPLID")) : Snull;
                            sh.IsConfidential = reader["IsConfidential"] != DBNull.Value ? reader.GetSqlBoolean(reader.GetOrdinal("IsConfidential")).ToString() : Snull;
                            sh.SuperConfidentila = reader["HighConfendential"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("HighConfendential")) : inull;
                            sh.HoroscopeStatus = reader["HoroscopeStatus"] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("HoroscopeStatus")) : inull;
                            sh.Cust_ID = reader["cust_id"] != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("cust_id")) : Lnull;
                            sh.Intercaste = reader["Intercaste"] != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("Intercaste")).ToString() : Snull;

                            sh.SRCount = (reader["SRCount"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("SRCount")) : empty;
                            sh.PaidAmount = (reader["Payment"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("Payment")) : inull;
                            sh.ExpiryDate = (reader["ExpiryDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ExpiryDate")) : empty;
                            sh.Points = (reader["Points"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Points")) : empty;
                            sh.Emp_Ticket_ID = (reader["Emp_Ticket_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Emp_Ticket_ID")) : Lnull;
                            sh.MatchMeetingCount = (reader["MatchMeetingCount"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("MatchMeetingCount")) : inull;
                            sh.ProfileOwnername = (reader["ProfileOwnername"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ProfileOwnername")) : empty;
                            sh.EmpUserName = (reader["EmpUserName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EmpUserName")) : empty;
                            sh.EmpName = (reader["EmpName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("EmpName")) : empty;
                            sh.SAForm = (reader["SAForm"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("SAForm")) : empty;
                            sh.CNumberVerStatus = (reader["CNumberVerStatus"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("CNumberVerStatus")) : false;
                            sh.CEmailVerStatus = (reader["CEmailVerStatus"]) != DBNull.Value ? reader.GetBoolean(reader.GetOrdinal("CEmailVerStatus")) : false;
                            sh.Reason4InActive = (reader["Reason4InActive"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Reason4InActive")) : empty;
                            sh.Cust_Family_ID = (reader["Cust_Family_ID"]) != DBNull.Value ? reader.GetInt64(reader.GetOrdinal("Cust_Family_ID")) : Lnull;
                            sh.CountryCodeID = (reader["CountryCodeID"]) != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("CountryCodeID")) : inull;
                            sh.CreatedDate = (reader["CreatedDate"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("CreatedDate")) : empty;
                            sh.Primarynumber = (reader["Primarynumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Primarynumber")) : empty;
                            sh.Primaryemail = (reader["Primaryemail"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("Primaryemail")) : empty;
                            sh.ContactNumber = (reader["ContactNumber"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("ContactNumber")) : empty;
                            sh.UserName = (reader["UserName"]) != DBNull.Value ? reader.GetString(reader.GetOrdinal("UserName")) : empty;
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
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
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
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            status = 1;
            return details;
        }


        internal int FeeUpdateDalWithInternalMemoUpdate(FeeUpdateML Mobj, string spname)
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
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
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
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
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
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
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
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();

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
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
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
                parm[4] = new SqlParameter("@pagefrom", SqlDbType.Int);
                parm[4].Value = Mobj.pagefrom;
                parm[5] = new SqlParameter("@pageto", SqlDbType.Int);
                parm[5].Value = Mobj.pageto;
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
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
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
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return status;
        }

        internal int deletedprofilesInsertionDal(SettledDeletedML Mobj, string spname)
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
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
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
                cmd.Parameters.AddWithValue("@i_Gender", Mobj.Gender);
                cmd.Parameters.AddWithValue("@i_isConfidential", Mobj.boolIsConfidential);
                cmd.Parameters.AddWithValue("@dt_DateofRegistrationFrom", Mobj.FromDate);
                cmd.Parameters.AddWithValue("@dt_DateofRegistrationTo", Mobj.ToDate);
                cmd.Parameters.AddWithValue("@t_CasteIds", Commonclass.returndt(Mobj.castes, Mobj.Caste, "CasteID", "CasteID"));
                cmd.Parameters.AddWithValue("@t_BranchIds", Commonclass.returndt(Mobj.branches, Mobj.Branch, "BranchID", "BranchID"));
                cmd.Parameters.AddWithValue("@t_StatusIds", Commonclass.returndt(Mobj.applicationstatus, Mobj.ApplicationStatus, "ApplicationStatusID", "ApplicationStatusID"));
                cmd.Parameters.AddWithValue("@i_PageSize", Mobj.PageSize);
                cmd.Parameters.AddWithValue("@i_PageNumber", Mobj.PageNumber);
                cmd.Parameters.AddWithValue("@i_StartIndex", Mobj.intlowerBound);
                cmd.Parameters.AddWithValue("@I_EndIndex", Mobj.intUpperBound);
                cmd.Parameters.AddWithValue("@i_Payment", Mobj.PaymentStatus);
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
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
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
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
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
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
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
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();

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
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
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
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
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
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();


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
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();


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
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();


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
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();


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
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();


            }


            return Commonclass.convertdataTableToArrayListTable(ds);
        }

    }
}
