using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebapiApplication.Interfaces;
using WebapiApplication.Implement;
using System.Collections;
using WebapiApplication.ML;
using System.IO;
using Amazon.S3;
using Amazon.S3.Model;
using System.Web;
using System.Web.UI;
using Ionic.Zip;
using WebapiApplication.DAL;
using System.Net.Http.Headers;

namespace WebapiApplication.Api
{
    public class smallPagesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        //private readonly ISmallPages Iobj = new ImpSmallPages();
        private readonly ISmallPages Iobj;

        public smallPagesController()
            : base()
        {
            Iobj = new ImpSmallPages();
        }

        public ArrayList MacIpValues(macIPInput mobj)
        {
            return Iobj.getMacIpValues(mobj);
        }

        public Tuple<int, ArrayList> matchMeetingEntryForm(matchMeetingEntryForm mobj)
        {
            return Iobj.matchMeetingEntryForm(mobj);
        }


        public Tuple<int, ArrayList> GetEmployeeName(string profileID, int BridegroomFlag)
        {
            return Iobj.EmpDetailsNew(profileID, BridegroomFlag);
        }

        public Tuple<ArrayList, int, int, int, int> GetmatchMeetingData(int? brideCustID, int? groomCustID)
        {
            return Iobj.GetmatchMeetingData(brideCustID, groomCustID);
        }

        public int GetcheckMarketingTicket(string ticketID)
        {
            return Iobj.checkMarketingTicket(ticketID);
        }

        public int brokerFormInsert(brokerEntryForm mobj)
        {
            return Iobj.brokerFormInsert(mobj);
        }
        public List<MyassignedPhotosOutPut> myAssignedPhotos(myassignedPhotoInputMl mobj)
        {
            return Iobj.myAssignedPhotos(mobj);
        }

        public int myAssignedPhotosSubmit(myassignPhotoSubmit mobj)
        {
            return Iobj.myAssignedPhotosSubmit(mobj);
        }



        //public void downloadImages(List<downloadInput> li)
        //{
        //    List<downloadInput> listval = li;

        //    if (Directory.Exists("C:\\kaakateeyaPhotos"))
        //    {
        //        Directory.Delete("C:\\kaakateeyaPhotos", true);
        //    }

        //    if (listval.Count > 0)
        //    {

        //        if (listval.Count == 1)
        //        {
        //            listval[0].photoname = listval[0].photoname.Replace("i", "I");
        //            string[] imggg = listval[0].photoname.Split('.');
        //            string strtest = "Images/ProfilePics/KMPL_" + listval[0].custid + "_Images/" + imggg[0] + "." + (imggg[1].ToLower());
        //            string strimagedisplay = listval[0].profileid + "_" + (((listval[0].photoname).Split('.'))[0]).Substring(3) + "." + (imggg[1].ToLower());

        //            Download(strtest, listval[0].profileid + "_" + listval[0].photoname, strimagedisplay);

        //        }

        //        if (listval.Count > 1)
        //        {
        //            for (int i = 0; i < listval.Count; i++)
        //            {

        //                listval[i].photoname = (listval[i].photoname.Replace("i", "I"));
        //                string[] imgggall = listval[i].photoname.Split('.');
        //                string strtest1 = "Images/ProfilePics/KMPL_" + listval[i].custid + "_Images/" + imgggall[0] + "." + (imgggall[1].ToLower());
        //                string[] keySplit = strtest1.Split('/');
        //                string fileName = keySplit[keySplit.Length - 1];
        //                string strimagenum = (((listval[i].photoname).Split('.'))[0]).Substring(3) + "." + (imgggall[1].ToLower());

        //                string destAll = "C:\\kaakateeyaPhotos\\" + listval[i].profileid + "_" + strimagenum;
        //                AmazonLoad(strtest1, destAll);
        //            }
        //            downloadFolder();
        //        }

        //    }

        //}




        //public void Download(string keyName, string destination, string strimagedisplay)
        //{
        //    var http = System.Web.HttpContext.Current;
        //    var page = http.CurrentHandler as System.Web.UI.Page;

        //    string dest = "C:\\kaakateeyaPhotos\\" + strimagedisplay;

        //    AmazonLoad(keyName, dest);

        //    HttpContext.Current.Response.ContentType = "doc/docx";
        //    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=\"" + strimagedisplay);
        //    if (File.Exists(dest))
        //    {
        //        HttpResponseMessage Response = new HttpResponseMessage(HttpStatusCode.OK);
        //        //HttpResponse Response = new HttpResponse(page);
        //        page.Response.TransmitFile(dest);
        //    }

        //    string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        //    string pathDownload = Path.Combine(pathUser, "Downloads");
        //    DirectoryInfo dinfo2 = new DirectoryInfo(pathDownload);
        //    string Physicalpath = dinfo2 + "\\" + strimagedisplay;

        //    if (!File.Exists(Physicalpath) || File.Exists(Physicalpath))
        //    {
        //        try
        //        {
        //            File.Copy(dest, Physicalpath, true);
        //        }
        //        catch (Exception ea)
        //        {
        //        }
        //    }
        //    //page.Response.End();


        //}
        //public void downloadFolder()
        //{
        //    var http = System.Web.HttpContext.Current;
        //    var page = http.CurrentHandler as System.Web.UI.Page;

        //    using (ZipFile zip = new ZipFile())
        //    {
        //        zip.AlternateEncodingUsage = ZipOption.AsNecessary;

        //        zip.AddDirectoryByName("kaakateeyaPhotos");
        //        string[] filePaths = Directory.GetFiles("C:\\kaakateeyaPhotos");
        //        foreach (string filePath in filePaths)
        //        {
        //            zip.AddFile(filePath, "kaakateeyaPhotos");
        //        }
        //        page.Response.Clear();
        //        page.Response.BufferOutput = false;
        //        string zipName = String.Format("kaakateeyaPhotos_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
        //        page.Response.ContentType = "application/zip";
        //        page.Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
        //        zip.Save(page.Response.OutputStream);
        //        page.Response.End();
        //    }

        //}
        //public void AmazonLoad(string keyName, string dest)
        //{


        //    IAmazonS3 client;
        //    using (client = new AmazonS3Client(Amazon.RegionEndpoint.APSouth1))
        //    {
        //        GetObjectRequest request = new GetObjectRequest
        //        {
        //            BucketName = "kaakateeyaprod",
        //            Key = keyName
        //        };
        //        using (GetObjectResponse response = client.GetObject(request))
        //        {
        //            response.WriteResponseStreamToFile(dest, false);

        //        }
        //    }
        //}


    }
}