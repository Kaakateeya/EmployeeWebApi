using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Http;
using WebapiApplication.DAL;
using WebapiApplication.Implement;
using WebapiApplication.Interfaces;
using WebapiApplication.ML;
using WebapiApplication.UserDefinedTable;

namespace WebapiApplication.Api
{
    public class smallPagesController : ApiController
    {
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

        public List<GetEmployeeList> employeeList(GetEmployeeListRequest mobj)
        {
            return Iobj.employeeList(mobj);
        }

        public int employeeCreation(EmployeeCreationInput mobj)
        {
            mobj.Password = !string.IsNullOrEmpty(mobj.Password) ? Commonclass.Encrypt(mobj.Password) : mobj.Password;
            List<EmployeeCreationInput> lstEmp = new List<EmployeeCreationInput>();
            lstEmp.Add(mobj);
            mobj.dtEmployeecreation = Commonclass.returnListDatatable(PersonaldetailsUDTables.getEmployeeDatanew(), lstEmp);
            return Iobj.employeeCreation(mobj);
        }

        public string getLoginName(int intHomeBrchID)
        {
            return Iobj.getLoginName(intHomeBrchID);
        }

        public EmpAssignCounts getEmpWorkAssignCounts(int EmpID)
        {
            return Iobj.getEmpWorkAssignCounts(EmpID);
        }

        public int setEmpAssignCounts(EmpAssignCounts mobj)
        {
            return Iobj.setEmpAssignCounts(mobj);
        }

        public ArrayList loginLogOutReport(EmpLoginLogoutReportML mobj)
        {
            return Iobj.loginLogOutReport(mobj);
        }

        public int getinsertImagepath(long whereId, string strvalue, string flag)
        {
            return Iobj.getinsertImagepath(whereId, strvalue, flag);
        }

        public ArrayList empWorksheet(EmpWorkSheetMl mobj)
        {
            return Iobj.empWorksheet(mobj);
        }

        public int getEmpLogout(int empid)
        {
            return Iobj.empLogout(empid);
        }

        public ArrayList mediaterRegValidation(mediaterRegFormValidation mobj)
        {
            return Iobj.mediaterRegValidation(mobj);
        }

        public ArrayList EmployeeCommunicationLogNew(CommunicationRequest mobj)
        {
            return Iobj.EmployeeCommunicationLogNew(mobj);
        }

        public int getdeleteSettleForm(int settleID)
        {
            return Iobj.deleteSettleForm(settleID);
        }

        public ArrayList ViewSuccessStories(viewSuccessStoriesRequest sObj)
        {
            return Iobj.ViewSuccessStories(sObj);
        }

        public Tuple<int, ArrayList> GetbrideGroomData(string profileID, int iFlag)
        {
            return Iobj.GetbrideGroomData(profileID, iFlag);
        }

        public Tuple<int, ArrayList> GetbrideGroomDataNew(string profileID, int iFlag)
        {
            return Iobj.GetbrideGroomDataNew(profileID, iFlag);
        }

        public int createSuccessStories(createSuccessStoryRequest mobj)
        {
            return Iobj.createSuccessStories(mobj);
        }

        [HttpGet]
        public int deleteSucessStories(string sucessStoryID, string brideProfileID, string groomProfileID) { return Iobj.deleteSucessStories(sucessStoryID, brideProfileID, groomProfileID); }

        public ArrayList matchMeetingCountReport(matchMeetingCountMl mobj)
        {
            return Iobj.matchMeetingCountReport(mobj);
        }

        public ArrayList matchMeetingCountInfo(matchMeetingCountInfoMl mobj)
        {
            return Iobj.matchMeetingCountInfo(mobj);
        }

        public ArrayList settleDeleteProfilesReport(settleDeleteProfilesReport mobj)
        {
            return Iobj.ProfileDeleteProfilesReport(mobj);
        }

        //public int restoreProfile(restoreProfile mobj) { return Iobj.restoreProfile(mobj); }

        public int getcheckStatus(string whereID, string secondwhereID, string flag)
        {
            return Iobj.checkStatus(whereID, secondwhereID, flag);
        }

        public ArrayList SettledProfilesInfo(settledProfilesRequest mobj)
        {
            return Iobj.SettledPrfofilesInfo(mobj);
        }

        public ArrayList noProfileGrade(noProfileGradeRequest mobj)
        {
            return Iobj.noProfileGrade(mobj);
        }

        public int insertsettleAmountInfo(insertSettlAmountRequest mobj)
        {
            return Iobj.insertsettleAmountInfo(mobj);
        }

        public List<settleInfo> getSettleInfo(string profileid)
        {
            return Iobj.getSettleInfo(profileid);
        }

        public ArrayList GetDataStaging(string CustID)
        {
            return Iobj.GetDataStaging(CustID);
        }

        public int UpdateGrading(NoProfileGradingMl mobj)
        {
            return Iobj.UpdateGrading(mobj);
        }

        public ArrayList listOFServiceGiven(ListOfServicesTakenM1 mobj)
        {
            return Iobj.listOFServiceGiven(mobj);
        }

        public ArrayList emailBouncelist(EmailBounceReports mobj)
        {
            return Iobj.emailBouncelist(mobj);
        }
    }
}