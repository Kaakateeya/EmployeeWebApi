using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebapiApplication.ML
{
    public class macIPInput
    {
        public int? Religion { get; set; }
        public int? BranchID { get; set; }
        public string Ipaddress { get; set; }
        public int? flag { get; set; }
    }

    public class matchMeetingEntryForm
    {
        public string BrideprofileID { get; set; }
        public string GroomprofileID { get; set; }
        public DateTime? MeetingDate { get; set; }
        public string MeetingPlace { get; set; }
        public string BrideRelationName { get; set; }
        public string GroomRelaionName { get; set; }
        public Int64 EmpID { get; set; }
        public string Notes { get; set; }
        public Int64? CreatedEMPID { get; set; }
        public int? BCode { get; set; }
        public string BLand { get; set; }
        public string BMobile { get; set; }
        public int? GCode { get; set; }
        public string GLand { get; set; }
        public string GMobile { get; set; }
    }
    public class brokerEntryForm
    {
        public string name { get; set; }
        public string place { get; set; }
        public string email { get; set; }
        public string mobileNumber { get; set; }
        public int? brokerId { get; set; }
        public int? flag { get; set; }
        public int? BranchID { get; set; }

        public string whatsappNumber { get; set; }
    }

    public class myassignedPhotoInputMl
    {
        public int? I_EmpID { get; set; }
        public string StrProfileID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EnDate { get; set; }
        public int? PageFrom { get; set; }
        public int? PageTo { get; set; }
    }



    public class MyassignedPhotosOutPut
    {

        public long? Row { get; set; }

        public int? TotalRows { get; set; }

        public int? Totalpages { get; set; }

        public long? Cust_ID { get; set; }

        public string ProfileID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UploadedDate { get; set; }

        public string AssignedDate { get; set; }

        public string PhotoName { get; set; }

        public long? Cust_Photos_ID { get; set; }

        public string AssignEmpName { get; set; }

        public int? paid { get; set; }

        public string Uploaded_by { get; set; }

        public string Uploaded_branch { get; set; }
    }
    public class myassignPhotoSubmit
    {
        public Int64? EmpID { get; set; }
        public string StrThumbNail { get; set; }
        public string StrFullPhoto { get; set; }
        public string StrApplicationPhoto { get; set; }
        public Int64 PhotoID { get; set; }  
    }

    public class downloadInput
    {
        public string custid { get; set; }
        public string profileid { get; set; }
        public string photoname { get; set; }
    }

    public class UnassignPhotoSelect
    {
        public int iEmpID { get; set; }
        public string StrProfileID { get; set; }
        public int? PhotoAssigned { get; set; }
        public int? GenderID { get; set; }
        public int? PhotoStatus { get; set; }
        public string strBranch { get; set; }
        public string strRegion { get; set; }
        public string strCaste { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EnDate { get; set; }
        public int intlowerBound { get; set; }
        public int intUpperBound { get; set; }
       
    }
    public class UnassignedPhotoSelect
    {
        public Int64? Row { get; set; }
        public int? TotalRows { get; set; }
        public int? Totalpages { get; set; }
        public Int64? cust_id { get; set; }
        public string ProfileID { get; set; }
        public string CustomerName { get; set; }
        public string OwnerName { get; set; }
        public int? PhotosCount { get; set; }
        public int? AccepCount { get; set; }
        public int? RejectCount { get; set; }
        public string IdS { get; set; }
        public int? paid { get; set; }
    }
}




