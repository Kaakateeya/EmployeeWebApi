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
        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}

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



        public string downloadImages([FromBody]List<downloadInput> li)
        {
            List<downloadInput> listval = li;
            string strpathreturn = "";
            if (listval.Count > 0)
            {
                if (listval.Count == 1)
                {
                    listval[0].photoname = listval[0].photoname.Replace("i", "I");
                    string[] imggg = listval[0].photoname.Split('.');
                    string strtest = "Images/ProfilePics/KMPL_" + listval[0].custid + "_Images/" + imggg[0] + "." + (imggg[1].ToLower());
                    string strimagedisplay = listval[0].profileid + "_" + (((listval[0].photoname).Split('.'))[0]).Substring(3) + "." + (imggg[1].ToLower());
                    string dest = "C:\\kaakateeyaPhotos\\" + strimagedisplay;
                    AmazonLoad(strtest, dest);
                    strpathreturn = "C:/kaakateeyaPhotos/" + strimagedisplay;
                }
                else if (listval.Count > 1)
                {
                    for (int i = 0; i < listval.Count; i++)
                    {
                        listval[i].photoname = listval[i].photoname.Replace("i", "I");
                        string[] imggg = listval[i].photoname.Split('.');
                        string strtest = "Images/ProfilePics/KMPL_" + listval[i].custid + "_Images/" + imggg[0] + "." + (imggg[1].ToLower());
                        string strimagedisplay = listval[i].profileid + "_" + (((listval[i].photoname).Split('.'))[0]).Substring(3) + "." + (imggg[1].ToLower());
                        string dest = "C:\\kaakateeyaPhotos\\" + strimagedisplay;
                        AmazonLoad(strtest, dest);
                        strpathreturn = "C:/kaakateeyaPhotos/" + strimagedisplay;
                    }
                }
            }

            return strpathreturn;
        }

        public void AmazonLoad(string keyName, string dest)
        {


            IAmazonS3 client;
            using (client = new AmazonS3Client(Amazon.RegionEndpoint.APSouth1))
            {
                GetObjectRequest request = new GetObjectRequest
                {
                    BucketName = "kaakateeyaprod",
                    Key = keyName
                };
                using (GetObjectResponse response = client.GetObject(request))
                {
                    response.WriteResponseStreamToFile(dest, false);

                }
            }
        }

        public List<UnassignedPhotoSelect> unassignPhotoSelect(UnassignPhotoSelect mobj)
        {
            return Iobj.unassignPhotoSelect(mobj);
        }

        public int GetassignPhotos(long? Empid, string PhotoIDs)
        {
            return Iobj.assignPhotos(Empid, PhotoIDs);
        }
    }
}