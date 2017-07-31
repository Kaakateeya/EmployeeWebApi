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
using System.Reflection;
using System.Net.Mail;
using System.Threading;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebapiApplication.UserDefinedTable;
using System.IO;
using WebapiApplication.ServiceReference1;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;

namespace WebapiApplication.DAL
{
    public class Commonclass
    {
        public static void SendMailSmtpMethod(List<Smtpemailsending> list, string fromemail)
        {
            try
            {
                string Password = string.Empty;

                string StrFromMail = ConfigurationManager.AppSettings["SendTutoringHoursFromMails"].ToString();
                string StrFromInfoMail = ConfigurationManager.AppSettings["StrFromInfoMail"].ToString();

                string StrPassword = ConfigurationManager.AppSettings["Password"].ToString();
                string StrInfoPassword = ConfigurationManager.AppSettings["infoPassword"].ToString();

                for (int i = 0; i < list.Count; i++)
                {
                    string[] toemails = list[i].recipients.Split(';');
                    MailMessage mailmessage = new MailMessage();
                    foreach (string str in toemails)
                    {
                        if (!string.IsNullOrEmpty(str) && str.Length > 0)
                        {
                            mailmessage.To.Add(str);
                        }
                    }

                    if (fromemail == "exp")
                    {
                        mailmessage.From = new MailAddress(StrFromMail);
                        Password = StrPassword;
                    }
                    else
                    {
                        mailmessage.From = new MailAddress(StrFromInfoMail);
                        Password = StrInfoPassword;
                    }

                    mailmessage.Subject = list[i].subject;
                    mailmessage.Body = list[i].body;
                    mailmessage.IsBodyHtml = true;
                    SendMail(mailmessage, Password);
                }
            }
            catch (Exception EX)
            {
                Commonclass.ApplicationErrorLog("SendMailSmtpMethod", Convert.ToString(EX.Message), null, null, null);
            }
            finally
            {
                SqlConnection.ClearAllPools();
            }
        }

        public static void SendMail(MailMessage message, string Password)
        {
            var thread = new Thread(() => SendMailThread(message, Password));
            thread.Start();
        }

        //private static void SendMailThread(MailMessage message, string Password)
        //{

        //    string StrMailServer = ConfigurationManager.AppSettings["MailHost"].ToString();

        //    int intPort = Convert.ToInt32(ConfigurationManager.AppSettings["MailHostPort"].ToString());

        //    using (var server = new SmtpClient(StrMailServer.ToString(), Convert.ToInt32(intPort)))
        //    {
        //        server.EnableSsl = true;
        //        server.UseDefaultCredentials = true;
        //        server.Credentials = new System.Net.NetworkCredential((message.From).ToString(), Password);
        //        server.Send(message);
        //    }

        //}

        private static void SendMailThread(MailMessage message, string Password)
        {
            try
            {
                string StrMailServer = ConfigurationManager.AppSettings["MailHost"].ToString();

                int intPort = Convert.ToInt32(ConfigurationManager.AppSettings["MailHostPort"].ToString());

                using (var server = new SmtpClient(StrMailServer.ToString(), Convert.ToInt32(intPort)))
                {
                    server.EnableSsl = true;
                    server.UseDefaultCredentials = true;
                    server.Credentials = new System.Net.NetworkCredential((message.From).ToString(), Password);
                    try
                    {
                        server.Send(message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception caught in CreateTestMessage2(): {0}", ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}", ex.ToString());
            }
            finally
            {
                SqlConnection.ClearAllPools();
            }
        }

        public static DataTable returnListDatatable<T>(DataTable dt, List<T> items)
        {
            DataTable dtnew = dt;
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            int flag = 0;
            foreach (T item in items)
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                for (int i = 0; i < dtnew.Columns.Count; i++)
                {

                    for (int j = 0; j < Props.Length; j++)
                    {

                        if (dtnew.Columns[i].ColumnName == Props[j].Name)
                        {

                            dtnew.Rows[flag][dtnew.Columns[i].ColumnName] = Props[j].GetValue(item, null);
                        }
                    }
                }

                flag++;
            }
            return dtnew;
        }
        public static string Decrypt(string encrypted)
        {
            string Password;
            byte[] pwdhash;
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            Password = "kaakateeyamatrimony";
            pwdhash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Password));
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = pwdhash;
            des.Mode = CipherMode.ECB;
            byte[] buff = Convert.FromBase64String(encrypted);
            string decrypted = ASCIIEncoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buff, 0, buff.Length));
            return (decrypted);
        }
        public static string Encrypt(string strProfileID)
        {
            string password;
            byte[] pwdhash;
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            password = "kaakateeyamatrimony";
            pwdhash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = pwdhash;
            des.Mode = CipherMode.ECB;
            byte[] buff = ASCIIEncoding.ASCII.GetBytes(strProfileID);
            string encrypted = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buff, 0, buff.Length));
            return (encrypted);
        }
        public static ArrayList convertdataTableToArrayList(DataSet dtSet)
        {
            ArrayList arraylist = new ArrayList();
            if (dtSet != null && dtSet.Tables.Count > 0)
            {
                for (int icount = 0; icount < dtSet.Tables.Count; icount++)
                {
                    arraylist.Add(JsonConvert.SerializeObject(dtSet.Tables[icount]));
                }
            }
            return arraylist;
        }


        public static ArrayList convertdataTableToArrayListTable(DataSet dtSet)
        {

            ArrayList arraylist = new ArrayList();

            if (dtSet != null && dtSet.Tables.Count > 0)
            {
                for (int icount = 0; icount < dtSet.Tables.Count; icount++)
                {
                    arraylist.Add(dtSet.Tables[icount]);
                }
            }

            return arraylist;
        }


        public static ArrayList convertdataTableToArrayGridbind(DataTable dt)
        {
            ArrayList aList = new ArrayList(dt.Rows.Count);
            aList.Add(dt.Rows);
            return aList;
        }

        public static string ViewProfileDecrypt(string inputText)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            inputText = inputText.Replace(" ", string.Empty);
          
            byte[] encryptedData = Encoding.Unicode.GetBytes(inputText);

            PasswordDeriveBytes secretKey = new PasswordDeriveBytes(ENCRYPTION_KEY, SALT);

            using (ICryptoTransform decryptor = rijndaelCipher.CreateDecryptor(secretKey.GetBytes(32), secretKey.GetBytes(16)))
            {
                using (MemoryStream memoryStream = new MemoryStream(encryptedData))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        byte[] plainText = new byte[encryptedData.Length];
                        int decryptedCount = cryptoStream.Read(plainText, 0, plainText.Length);
                        return Encoding.Unicode.GetString(plainText, 0, decryptedCount);
                    }
                }
            }
        }

        private const string ENCRYPTION_KEY = "KMPL";
        private readonly static byte[] SALT = Encoding.ASCII.GetBytes(ENCRYPTION_KEY.Length.ToString());

        public static string getEncryptedExpressIntrestString(string strActualText)
        {
           
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            byte[] plainText = Encoding.Unicode.GetBytes(strActualText);
            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(ENCRYPTION_KEY, SALT);
            using (ICryptoTransform encryptor = rijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16)))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainText, 0, plainText.Length);
                        cryptoStream.FlushFinalBlock();
                        return Convert.ToBase64String(memoryStream.ToArray());
                    }
                }
            }
        }
        public static string ReturnEncryptLink(string type, string fromProfileID, string toprofileID)
        {
            if (!string.IsNullOrEmpty(fromProfileID) && !string.IsNullOrEmpty(toprofileID))
                return getEncryptedExpressIntrestString("FromProfileID=" + fromProfileID + "&" + "ToProfileID=" + toprofileID + "&" + "Flag=" + (type == "Accept" ? 1 : 0));
            else
                return null;
        }



        public static CustSearchMl CustomerViewProfileEncriptedText(CustSearchMl MobjViewprofile)
        {
            if (MobjViewprofile.TypeofInsert == "E")
            {
                MobjViewprofile.EncriptedText = Commonclass.ReturnEncryptLink("Accept", (!string.IsNullOrEmpty(MobjViewprofile.FromProfileID) ? MobjViewprofile.FromProfileID : null), (!string.IsNullOrEmpty(MobjViewprofile.ToProfileID) ? MobjViewprofile.ToProfileID : null));
                MobjViewprofile.EncryptedRejectFlagText = Commonclass.ReturnEncryptLink("Reject", !string.IsNullOrEmpty(MobjViewprofile.FromProfileID) ? MobjViewprofile.FromProfileID : null, !string.IsNullOrEmpty(MobjViewprofile.ToProfileID) ? MobjViewprofile.ToProfileID : null);
                MobjViewprofile.EncriptedTextrvr = Commonclass.ReturnEncryptLink("Accept", (!string.IsNullOrEmpty(MobjViewprofile.ToProfileID) ? MobjViewprofile.ToProfileID : null), (!string.IsNullOrEmpty(MobjViewprofile.FromProfileID) ? MobjViewprofile.FromProfileID : null));
                MobjViewprofile.EncryptedRejectFlagTextrvr = Commonclass.ReturnEncryptLink("Reject", !string.IsNullOrEmpty(MobjViewprofile.ToProfileID) ? MobjViewprofile.ToProfileID : null, !string.IsNullOrEmpty(MobjViewprofile.FromProfileID) ? MobjViewprofile.FromProfileID : null);
            }
            return MobjViewprofile;
        }
        public static string createTicketEncriptedText(string fromCustID, string TocustID) { return getEncryptedExpressIntrestString("FromProfileID=" + TocustID + "&" + "ToProfileID=" + fromCustID + "&" + "Flag=" + 1); }
        public static string GlobalImgPath = "http://d16o2fcjgzj2wp.cloudfront.net/";


        public static DataTable returndt(string commaseperate, DataTable dt, string colname, string tName)
        {
            dt = new DataTable(tName); dt.Rows.Clear(); dt.Columns.Add(colname);
            if (!string.IsNullOrEmpty(commaseperate) && commaseperate != "null")
            {
                string[] strarray = commaseperate.Split(',');
                foreach (var i in strarray) { dt.Rows.Add(i); }
            }

            return dt;
        }
        public static DataTable returndatatable(int? nullable, DataTable dt, string colname, string tName)
        {
            dt = new DataTable(tName);
            dt.Rows.Clear();
            dt.Columns.Add(colname);
            if (nullable != null)
            {
                dt.Rows.Add(nullable);
            }
            return dt;
        }
        public static void ApplicationErrorLog(string ErrorSpName, string ErrorMessage, long? CustID, string PageName, string Type)
        {
            new StaticPagesDAL().DApplicationErrorLog(ErrorSpName, ErrorMessage, CustID, PageName, Type, "[dbo].[usp_ApplicationErrorLog]");
            SqlConnection.ClearAllPools();
        }
        public static void PaymentSMS(DataTable dt, string SendPhonenumber)
        {
            string strMobilenumber = "9392696969";
            ServiceSoapClient cc = new ServiceSoapClient();
            if (dt != null && dt.Rows.Count > 0)
            {
                strMobilenumber = !string.IsNullOrEmpty(dt.Rows[0]["CustomerMobile"].ToString()) ? dt.Rows[0]["CustomerMobile"].ToString() : "9392696969";
            }
            try
            {
                string result = cc.SendTextSMS("ykrishna", "summary$1", strMobilenumber, "Please Contact Me to know more about special Diamond Package " + SendPhonenumber, "smscntry");
            }
            catch (Exception ee)
            {
                throw ee;
            }
            finally
            {
                SqlConnection.ClearAllPools();
            }
        }

        public static void ResendMobileSMS(int? iCountryID, int? iCCode, string MobileNumber, string strMobileverf)
        {
            ServiceSoapClient cc = new ServiceSoapClient();
            if (iCountryID != 1)
            {
                string strMobileOther = iCCode + MobileNumber;
                string result = cc.SendTextSMS("yrd", "01291954", strMobileOther, "Greeting from Kaakateeya.com ! Your pin Number is " + strMobileverf + " Use this PIN to verify your primary mobile", "smscntry");
            }
            else
            {
                string result1 = cc.SendTextSMS("ykrishna", "summary$1", MobileNumber, "Greeting from Kaakateeya.com ! Your pin Number is " + strMobileverf + " Use this PIN to verify your primary mobile", "smscntry");
            }

            SqlConnection.ClearAllPools();
        }

        public static bool S3upload(string filePath, string keyName)
        {
            //filePath = "D://KaakateeyaMainProject//Kaakateeya//Development_Kaakateeya//kaakateeyaWeb//access//Images//ProfilePics//KMPL_71668_Images//img2.jpg";
            try
            {
                TransferUtility fileTransferUtility = new
                    TransferUtility(new AmazonS3Client(Amazon.RegionEndpoint.APSouth1));

                //TransferUtility utility = new TransferUtility();
                //utility.UploadDirectory(directoryPath, bucketName);


                // 1. Upload a file, file name is used as the object key name.
                //fileTransferUtility.Upload(filePath, bucketName);
                //Console.WriteLine("Upload 1 completed");


                //// 2. Specify object key name explicitly.
                //fileTransferUtility.Upload(filePath,
                //                      	bucketName, keyName);
                //Console.WriteLine("Upload 2 completed");


                //// 3. Upload data from a type of System.IO.Stream.
                //using (FileStream fileToUpload =
                //	new FileStream(filePath, FileMode.Open, FileAccess.Read))
                //{
                //	fileTransferUtility.Upload(fileToUpload,
                //                           	bucketName, keyName);
                //}
                //Console.WriteLine("Upload 3 completed");


                // 4.Specify advanced settings/options.
                TransferUtilityUploadRequest fileTransferUtilityRequest = new TransferUtilityUploadRequest
                {
                    BucketName = "kaakateeyaprod",
                    FilePath = filePath,
                    StorageClass = S3StorageClass.ReducedRedundancy,
                    PartSize = 6291456, // 6 MB.
                    Key = keyName,
                    CannedACL = S3CannedACL.PublicRead
                };
                fileTransferUtilityRequest.Metadata.Add("param1", "Value1");
                fileTransferUtilityRequest.Metadata.Add("param2", "Value2");
                fileTransferUtility.Upload(fileTransferUtilityRequest);
                return true;
            }
            catch (AmazonS3Exception s3Exception)
            {
                Commonclass.ApplicationErrorLog("s3 Horo", Convert.ToString(s3Exception.Message), null, null, null);

                return false;
            }
            finally
            {
                SqlConnection.ClearAllPools();
            }
        }

        public static string S3PhotoPathAstro = "https://s3.ap-south-1.amazonaws.com/kaakateeyaprod/";

        public static string gethorophotoS3(string cust_id, string HoroscopeImageName)
        {

            Int64? int64null = null;

            Int64? custid = !string.IsNullOrEmpty(cust_id) ? Convert.ToInt64(cust_id) : int64null;
            string strCustDtryName = cust_id + "_HaroscopeImage";
            // string custDtryPath = !string.IsNullOrEmpty(S3PhotoPath) ? (HttpContext.Current.Server.MapPath("~\\Images\\HoroscopeImages\\")) + strCustDtryName : (HttpContext.Current.Server.MapPath("~\\access\\Images\\HoroscopeImages\\")) + strCustDtryName;

            string path = string.Empty;
            if (!string.IsNullOrEmpty(HoroscopeImageName))
            {
                string[] strextension = !string.IsNullOrEmpty(HoroscopeImageName) ? (HoroscopeImageName).Split(new string[] { "HaroscopeImage." }, StringSplitOptions.None) : null;
                string imgpath = !string.IsNullOrEmpty(S3PhotoPathAstro) ? S3PhotoPathAstro : "../../access/";
                path = imgpath + "Images/HoroscopeImages/" + cust_id + "_HaroscopeImage/" + cust_id + "_HaroscopeImage." + strextension[1];
            }
            else
            {
                path = !string.IsNullOrEmpty(S3PhotoPathAstro) ? S3PhotoPathAstro + "Images/customernoimages/Horo_no.jpg" : "../../Customer_new/images/Horo_no.jpg";
            }
            SqlConnection.ClearAllPools();
            return path;
        }

        public static DataTable getTableData(string str, string col)
        {

            DataTable tbl = new DataTable();
            tbl.Columns.Add(col, typeof(string));

            if (!string.IsNullOrEmpty(str))
            {
                string[] name = str.Split(',');
                for (int i = 0; i < name.Length; i++)
                {
                    tbl.Rows.Add(name[i]);
                }
            }
            return tbl;
        }

        public static int? GetProfileIDCustID(int? iflagEmailmobile, string EmailMobile)
        {
            int? iStatus = 0;
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
                ds = SQLHelper.ExecuteDataset(connection, CommandType.StoredProcedure, "[dbo].[usp_EmailMobilenumberexists_NewDesign]", parm);
                if (string.Compare(parm[2].Value.ToString(), System.DBNull.Value.ToString()) == 0) { iStatus = 0; } else { iStatus = Convert.ToInt32(parm[2].Value); }
            }
            catch (Exception ex)
            {
                Commonclass.ApplicationErrorLog("[dbo].[usp_EmailMobilenumberexists_NewDesign]", Convert.ToString(ex.Message), null, null, null);
            }
            finally
            {
                connection.Close();
                SqlConnection.ClearPool(connection);
                SqlConnection.ClearAllPools();
            }
            return iStatus;
        }

        public static void ExpressInterestSMS(DataTable dTable, string strMessage)
        {
            string strToProfileIDs = string.Empty;
            if (dTable != null && dTable.Rows.Count > 0)
            {
                string strFromProfileID = !string.IsNullOrEmpty(dTable.Rows[0]["FromProfileID"].ToString()) ? dTable.Rows[0]["FromProfileID"].ToString() : null;
                string Sendsms = !string.IsNullOrEmpty(dTable.Rows[0]["Sendsms"].ToString()) ? dTable.Rows[0]["Sendsms"].ToString() : null;
                string ModeofService = !string.IsNullOrEmpty(dTable.Rows[0]["ModeofService"].ToString()) ? dTable.Rows[0]["ModeofService"].ToString() : null;

                if (!string.IsNullOrEmpty(Sendsms) && Sendsms == "1")
                {
                    for (int iCount = 0; dTable.Rows.Count > iCount; iCount++)
                    {
                        if (string.IsNullOrEmpty(strToProfileIDs))
                        {
                            strToProfileIDs = !string.IsNullOrEmpty(dTable.Rows[iCount]["ToProfileID"].ToString()) ? dTable.Rows[0]["ToProfileID"].ToString() : null;
                        }
                        else
                        {
                            strToProfileIDs = strToProfileIDs + "," + (!string.IsNullOrEmpty(dTable.Rows[iCount]["ToProfileID"].ToString()) ? dTable.Rows[0]["ToProfileID"].ToString() : null);
                        }
                    }

                    DataSet dset = new DataSet();
                    dset = (new ExpressInterestDAL().ExpressInterest_SendSms(strFromProfileID, strToProfileIDs, "[dbo].[usp_ExpressInterest_SendSms]"));

                    string strSMS = "Match Recomended By Kaakateeya Marriages";

                    int? HighConfendential = null;
                    int? Confidential = null;
                    int? ProfileStatusID = null;
                    string strMobileOther = null;
                    int? iCountryID = null;
                    int? inull = null;

                    for (int intICount = 0; intICount < dset.Tables.Count; intICount++)
                    {
                        if (dset.Tables[intICount].Rows.Count > 0)
                        {
                            switch (dset.Tables[intICount].Rows[0]["TableName"].ToString())
                            {
                                case "FromTable":

                                    if (ModeofService != "353" && ModeofService != null)
                                    {
                                        strMessage = strFromProfileID + ",You have selected the profiles of '" + strToProfileIDs + "' please check your email for more details.";
                                    }
                                    else
                                    {
                                        strMessage = strFromProfileID + "" + strSMS + " '" + strToProfileIDs + "' please check your email for more details.";
                                    }

                                    HighConfendential = !string.IsNullOrEmpty(dset.Tables[intICount].Rows[0]["HighConfendential"].ToString()) ? Convert.ToInt32(dset.Tables[intICount].Rows[0]["HighConfendential"].ToString()) : inull;
                                    Confidential = !string.IsNullOrEmpty(dset.Tables[intICount].Rows[0]["IsConfidential"].ToString()) ? Convert.ToInt32(dset.Tables[intICount].Rows[0]["IsConfidential"].ToString()) : inull;
                                    ProfileStatusID = !string.IsNullOrEmpty(dset.Tables[intICount].Rows[0]["ProfileStatusID"].ToString()) ? Convert.ToInt32(dset.Tables[intICount].Rows[0]["ProfileStatusID"].ToString()) : inull;
                                    strMobileOther = !string.IsNullOrEmpty(dset.Tables[intICount].Rows[0]["Number"].ToString()) ? dset.Tables[intICount].Rows[0]["Number"].ToString() : null;
                                    iCountryID = !string.IsNullOrEmpty(dset.Tables[intICount].Rows[0]["CountryCodeID"].ToString()) ? Convert.ToInt32(dset.Tables[intICount].Rows[0]["CountryCodeID"].ToString()) : inull;

                                    if ((HighConfendential == 0 || HighConfendential == inull) && (Confidential == 0 || Confidential == inull) && ProfileStatusID == 54)
                                    {
                                        GetSmsNum(iCountryID, strMessage, strMobileOther);
                                    }

                                    break;
                                case "ToTable":

                                    if (dset.Tables[intICount].Rows.Count > 0)
                                    {
                                        DataTable dtresult = new DataTable();
                                        dtresult = dset.Tables[intICount];
                                        for (int iCount = 0; dtresult.Rows.Count > iCount; iCount++)
                                        {
                                            HighConfendential = !string.IsNullOrEmpty(dtresult.Rows[iCount]["HighConfendential"].ToString()) ? Convert.ToInt32(dtresult.Rows[iCount]["HighConfendential"].ToString()) : inull;
                                            Confidential = !string.IsNullOrEmpty(dtresult.Rows[iCount]["IsConfidential"].ToString()) ? Convert.ToInt32(dtresult.Rows[iCount]["IsConfidential"].ToString()) : inull;
                                            ProfileStatusID = !string.IsNullOrEmpty(dtresult.Rows[iCount]["ProfileStatusID"].ToString()) ? Convert.ToInt32(dtresult.Rows[iCount]["ProfileStatusID"].ToString()) : inull;
                                            strMobileOther = !string.IsNullOrEmpty(dtresult.Rows[iCount]["Number"].ToString()) ? dtresult.Rows[iCount]["Number"].ToString() : null;
                                            iCountryID = !string.IsNullOrEmpty(dtresult.Rows[iCount]["CountryCodeID"].ToString()) ? Convert.ToInt32(dtresult.Rows[iCount]["CountryCodeID"].ToString()) : inull;
                                            string strToprofile = !string.IsNullOrEmpty(dtresult.Rows[iCount]["ProfileID"].ToString()) ? dtresult.Rows[iCount]["ProfileID"].ToString() : null;

                                            if (ModeofService != "353" && ModeofService != null)
                                            {
                                                strMessage = strToprofile + ",Your profile is viewed by '" + strFromProfileID + "' Please check your email for more details ";
                                            }
                                            else
                                            {
                                                strMessage = strToprofile + "," + "" + strSMS + " '" + strFromProfileID + "' please check your email for more details.";
                                            }
                                            if ((HighConfendential == 0 || HighConfendential == inull) && (Confidential == 0 || Confidential == inull) && ProfileStatusID == 54)
                                            {
                                                GetSmsNum(iCountryID, strMessage, strMobileOther);
                                            }
                                        }
                                    }

                                    break;
                            }

                        }
                    }


                }

                SqlConnection.ClearAllPools();
            }
        }

        public static void GetSmsNum(int? iCountryID, string strMessage, string strMobileOther)
        {

            ServiceSoapClient cc = new ServiceSoapClient();

            strMessage = strMessage + " from kaakateeya.com";

            if (iCountryID != 1)
            {
                string result1 = cc.SendTextSMS("yrd", "01291954", strMobileOther, strMessage, "smscntry");
            }
            else
            {
                string result = cc.SendTextSMS("ykrishna", "summary$1", strMobileOther, strMessage, "smscntry");
            }

        }

        public static int SendSms_new(EmployeeMarketslidesendmail Mobj)
        {
            int intStatus = 0;
            if (!string.IsNullOrEmpty(Mobj.strbody))
            {
                ServiceSoapClient cc = new ServiceSoapClient();
                try
                {
                    if (Mobj.strMobileCountryCode != "91" && Mobj.strMobileCountryCode != null && Mobj.strMobileCountryCode != "undefined")
                    {
                        string strMobileOther = Mobj.strMobileCountryCode + Mobj.strMobileNumber.Trim();
                        string result = cc.SendTextSMS("yrd", "01291954", strMobileOther, "Dear " + Mobj.strName.Trim() + "," + Mobj.strbody + " Support:" + Mobj.strEmpname + " : 91-" + Mobj.strEmpmobileNumber + " ", "smscntry");
                    }
                    else
                    {
                        string result = cc.SendTextSMS("ykrishna", "summary$1", Mobj.strMobileNumber.Trim(), "Dear " + Mobj.strName.Trim() + "," + Mobj.strbody + " Support:" + Mobj.strEmpname + " : 91-" + Mobj.strEmpmobileNumber + "   www.kaakateeya.com ", "smscntry");
                    }

                }
                catch (Exception ee)
                {

                }
                return intStatus;
            }

            return intStatus;
        }
        
    }
}