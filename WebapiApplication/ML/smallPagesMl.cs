using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

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
    public class GetEmployeeList
    {

        public string EmpPhoto { get; set; }

        public string CreatedByEmployeeName { get; set; }

        public long? CreatedByID { get; set; }

        public string Created_Date { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OfficialEmailID { get; set; }

        public int? BranchID { get; set; }

        public string BranchesName { get; set; }

        public string BranchCode { get; set; }

        public string WorkPhone { get; set; }

        public string OfficialContactNumber { get; set; }

        public string HomePhone { get; set; }

        public int? DesignationID { get; set; }

        public string LoginLocation { get; set; }

        public string WorkingStartTIme { get; set; }

        public string WorkingEndTIme { get; set; }

        public int? DayOff { get; set; }

        public string DateOfJoining { get; set; }

        public string DateOfReleaving { get; set; }

        public long? ReportingMngrID { get; set; }

        public string ReportingMngrName { get; set; }

        public double? AnnualIncome { get; set; }

        public int? CountryID { get; set; }

        public string CountryName { get; set; }

        public int? StateID { get; set; }

        public string StateName { get; set; }

        public int? DistrictID { get; set; }

        public string DistrictName { get; set; }

        public int? CityID { get; set; }

        public string CityName { get; set; }

        public string CityOther { get; set; }

        public string Address { get; set; }

        public int? EducationCategoryID { get; set; }

        public string EducationCategoryName { get; set; }

        public int? EducationGroupID { get; set; }

        public string EducationGroupName { get; set; }

        public int? EducationSpecializaionID { get; set; }

        public string EducationSpecializaionName { get; set; }

        public int? isAdmin { get; set; }

        public long? EmpID { get; set; }

        public string CreatedDate { get; set; }

        public string UserID { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public int? IsActive { get; set; }

        public string IsActiveStatus { get; set; }

        public int? LoginStatusID { get; set; }

        public string LoginStatus { get; set; }

        public bool? isLoginanywhere { get; set; }
    }
    public class GetEmployeeListRequest
    {
        public int? Empid { get; set; }
        public string BranchIDs { get; set; }
        public int? EmpStatus { get; set; }
        public string EmpTypeIDs { get; set; }
        public bool? isLoginanywhere { get; set; }
        public string region { get; set; }

    }


    public class EmployeeCreationInput
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OfficialEmailID { get; set; }
        public int? HomeBranchID { get; set; }
        public string WorkPhone { get; set; }
        public string OfficialCellPhone { get; set; }
        public string HomePhone { get; set; }
        public string PersonalEmailID { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public int? Designation { get; set; }
        public string LoginLocation { get; set; }
        public string OfficeFromHrs { get; set; }
        public string OfficeToHrs { get; set; }
        public int? DayOff { get; set; }
        public string DateofJoining { get; set; }
        public string DateofReleaving { get; set; }
        public int? ReportingMngrID { get; set; }
        public string AnnualIncome { get; set; }
        public int? Country { get; set; }
        public int? State { get; set; }
        public int? District { get; set; }
        public int? City { get; set; }
        public string CityOther { get; set; }
        public string Address { get; set; }
        public int? EducationCategory { get; set; }
        public int? EducationGroup { get; set; }
        public int? EducationSpecialization { get; set; }
        public string EmployeeImgPath { get; set; }
        public int? TypeOfEmployee { get; set; }
        public int? EmployeeStatus { get; set; }
        public long? CreatedEMPID { get; set; }
        public long? EMPID { get; set; }

        public DataTable dtEmployeecreation { get; set; }

        public bool? isLoginAnywhere { get; set; }
    }


    public class EmpAssignCounts
    {
        public int? EMployeeID { get; set; }
        public int? servicegivencount { get; set; }
        public int? matchfollowupcount { get; set; }
        public int? marketingticketscount { get; set; }
        public int? PhotoCount { get; set; }
        public int? HoroCount { get; set; }
        public int? EMpname { get; set; }
    }

    public class EmpLoginLogoutReportML
    {
        public string EmpUserID { get; set; }
        public string Branch { get; set; }
        public DataTable dtBranch { get; set; }
        public DataTable dtEmployeeName { get; set; }
        public string EmployeeName { get; set; }
        public int? WorkingHours { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? FromRange { get; set; }
        public int? ToRange { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int flag { get; set; }

    }
    public class EmpWorkSheetMl
    {
        public DateTime? FromDate { get; set; }
        public DateTime? toDate { get; set; }
        public DataTable dtEmployeename { get; set; }
        public string Employeename { get; set; }

        public DataTable dtBranch { get; set; }
        public string Branch { get; set; }

        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int? SerialnoFrom { get; set; }
        public int? serialnoto { get; set; }
        public int flag { get; set; }
        public String Pagename { get; set; }
        public string timings { get; set; }
    }


    public class mediaterRegFormValidation
    {
        public int i_MediaterID { get; set; }
        public string v_FirstName { get; set; }
        public string v_Surname { get; set; }
        public string v_Email { get; set; }
        public string v_Mobilenumber { get; set; }
        public string v_CounttyCode { get; set; }
    }


    public class CommunicationRequest
    {
        public string profileID { get; set; }
        public string v_Grid { get; set; }
        public int? intEmpId { get; set; }
        public int? startIndex { get; set; }
        public int? endIndex { get; set; }
        public int? Gridvalue { get; set; }
    }
    public class viewSuccessStoriesRequest
    {
        public string profileID { get; set; }
        public int? Region { set; get; }
        public DataTable dtCaste { get; set; }
        public DataTable dtBranch { get; set; }
        public string strCaste { get; set; }
        public string strBranch { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int intlowerBound { get; set; }
        public int intUpperBound { get; set; }
        public int? value { set; get; }
      
    }


}




