﻿using System;
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

        public Int64 EmpIDgroom { get; set; }
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

        public int? CountyCode { get; set; }

        public string AreaCode { get; set; }

        public string LandNumber { get; set; }
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
        public string CasteName { get; set; }
        public string AssignedTo { get; set; }
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

        public int? Dashboard_Status { get; set; }

        public string loginfrom { get; set; }

        public string loginto { get; set; }

        public bool? isSmartPh { get; set; }

        public string AlternateNumber { get; set; }

        public int? TeamHeadID { get; set; }
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
        public int? Dashboard_Status { get; set; }

        public string loginfrom { get; set; }
        public string loginto { get; set; }

        public int IsSmartPh { get; set; }

        public string AlternateNumber { get; set; }
        public int TeamHeadID { get; set; }
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

    public class createSuccessStoryRequest
    {
        public Int64? EmpID { get; set; }
        public Int64? BrideID { get; set; }
        public string Bridename { get; set; }
        public Int64? GroomID { get; set; }
        public string Groomname { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Attachphoto { set; get; }
        public string SuccesSstory { get; set; }
        public int? Displayinweb { set; get; }
        public int flag { get; set; }
        public string strSuccessstories { get; set; }
    }

    public class matchMeetingCountMl
    {
        public int? AppusrID { get; set; }
        public int? SearchBy { get; set; }
        public string count { get; set; }
        public int? Countfrom { get; set; }
        public int? CountTo { get; set; }
        public int? Dcount { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? toDate { get; set; }
        public string strBranch { get; set; }
        public string strCaste { get; set; }
        public DataTable dtBranch { get; set; }
        public DataTable dtCaste { get; set; }
        public int? SerialnoFrom { get; set; }
        public int? serialnoto { get; set; }
    }

    public class matchMeetingCountInfoMl
    {
        public int? custid { get; set; }
        public int? Empid { get; set; }
        public int? MMCustID { get; set; }
        public int? MMCustID2 { get; set; }

        public string strBranch { get; set; }

        public DataTable dtBranch { get; set; }

        public string strCaste { get; set; }

        public DataTable dtCaste { get; set; }

        public DateTime? toDate { get; set; }

        public DateTime? FromDate { get; set; }

        public int? SerialnoFrom { get; set; }

        public int? serialnoto { get; set; }
    }


    public class settleDeleteProfilesReport
    {
        public int IsAdmin { get; set; }
        public string strProfileID { get; set; }
        public string typeofStatus { get; set; }
        public int? AuthorizeStatus { get; set; }
        public int? Gender { get; set; }
        public int? ProfileType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int IsConfidential { get; set; }
        public DataTable t_authorizedBy { set; get; }
        public DataTable t_enteredBy { set; get; }
        public DataTable t_Branch { set; get; }
        public DataTable t_Caste { get; set; }
        public DataTable t_ProfileOwnerId { set; get; }
        public string strauthorizedBy { set; get; }
        public string strenteredBy { set; get; }
        public string strBranch { set; get; }
        public string strCaste { get; set; }
        public string strProfileOwnerId { set; get; }
        public int? i_Regionfield { set; get; }
        public int? StartIndex { set; get; }
        public int? EndIndex { set; get; }

    }

    public class restoreProfile
    {
        public Int64? Cust_ID { set; get; }
        public Int64? EmpID { get; set; }
        public Int64? RequestedBY { set; get; }
        public Int64? RequestedbyEmpID { set; get; }
        public int? RelationshipID { set; get; }
        public string strRelationshipname { set; get; }
        public string strReasonforrestore { set; get; }
        public Int64 ProfileStatusID { set; get; }
    }

    public class settledProfilesRequest
    {
        public int? i_PaidType { get; set; }
        public int? i_gender { get; set; }
        public string i_Region { get; set; }
        public string t_Branch { get; set; }
        public string t_ProfileOwner { get; set; }
        public DateTime? d_settleStartDate { get; set; }
        public DateTime? d_settleEndDate { get; set; }
        public int? i_Startindex { get; set; }
        public int? i_EndIndex { get; set; }
    }

    public class noProfileGradeRequest
    {
        public string TypeOFGrade { get; set; }
        public string StrProfileID { get; set; }
        public int? Gender { get; set; }
        public int? PaymentStatus { get; set; }
        public int Confidential { get; set; }
        public string GradeID { get; set; }
        public DataTable dtApplicationStatus { get; set; }
        public string strApplicationStatus { get; set; }
        public string GradingType { get; set; }
        public DataTable dtBranch { get; set; }
        public string strBranch { get; set; }
        public DataTable dtCaste { get; set; }
        public string strCaste { get; set; }
        public DataTable dtOwnerOfTheProfile { get; set; }
        public string strOwnerOfTheProfile { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? From { get; set; }
        public int? To { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int flag { get; set; }
        public string strRegion { get; set; }
        public DataTable dtRegion { get; set; }

    }


    public class insertSettlAmountRequest
    {
        //public int? i_CustId { get; set; }
        public string s_ProfileID { get; set; }
        public int? i_SettlementType { get; set; }
        public string i_Discription { get; set; }
        public int? s_EnteredBy { get; set; }
    }

    public class settleInfo
    {
        public long? Cust_ID { get; set; }
        public string paymentStatus { get; set; }
        public string Discription { get; set; }
        public string SettledDate { get; set; }
        public string enteredBy { get; set; }
    }

}




