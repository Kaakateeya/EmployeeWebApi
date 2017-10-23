using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebapiApplication.ML
{
    public class userLoginML
    {
        public Int64 CustID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ReligionName { get; set; }
        public string CasteName { get; set; }
        public int CasteID { get; set; }
        public string MotherTongueName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int GenderID { get; set; }
        public string Email { get; set; }
        public int MotherTongueID { get; set; }
        public int ReligionID { get; set; }
        public string ProfileID { get; set; }
        public string VerificationCode { get; set; }
        public Int64 FamilyID { get; set; }
        public int PaidStatus { get; set; }
        public string PartnerCastedata { get; set; }
        public int PhotoStatus { get; set; }
        public int PhotoCount { get; set; }
        public bool ViewProfileFlag { get; set; }
        public int ResigNophotoFlgPaid { get; set; }
        public int SuccessStoryFlag { get; set; }
        public int Emailverified { get; set; }
        public string strProfileID { get; set; }
        public Int64 Flag { get; set; }

        //MObile Verf
        public Int64 cust_emailid { set; get; }
        public string email { set; get; }
        public bool isemailverified { set; get; }
        public Int64 cust_contant_id { set; get; }
        public string number { set; get; }
        public bool isnumberverifed { set; get; }
        public string MObileverficationcode { get; set; }

        public string ProfilePic { get; set; }

    }
    public class CustLoginMl
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public string StrHtmlText { get; set; }
        public Int64 CustID { get; set; }
        public string StrCustID { get; set; }

        public int? iflag { get; set; }
    }
    public class EmpDetailsMl
    {
        public long EmpID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime WorkingStartTIme { get; set; }
        public DateTime WorkingEndTIme { get; set; }
        public int DesignationID { get; set; }
        public int ReportingMngrID { get; set; }
        public int BranchID { get; set; }
        public DateTime LastLoginDate { get; set; }
        public string Email { get; set; }
        public int isAdmin { get; set; }
        public int? RegionID { get; set; }
        public bool isManagement { get; set; }
        public string EmpPhotoPath { get; set; }


        public int? Dashboard_Status { get; set; }
    }
    public class MenuItem
    {
        public int? MenuID { get; set; }
        public int? ParentMenuID { get; set; }
        public bool View { get; set; }
        public bool Add { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public string URL { get; set; }
        public string ToolTip { get; set; }
        public string Title { get; set; }
    }
    public class ScrollText
    {
        public string str_scrollText { get; set; }
    }
    
    public class StarRating
    {

        public string str_StarRating { get; set; }
        public string str_daystar { get; set; }
    }

    public class EmployeeLoginMl
    {
        public List<MenuItem> MenuItem { set; get; }
        public List<EmpDetailsMl> EmpDetailsMl { set; get; }
        public List<ScrollText> ScrollText { set; get; }
        public List<StarRating> StarRating { set; get; }
    }
}