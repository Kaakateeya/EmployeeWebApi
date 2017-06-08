using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;

namespace WebapiApplication.ML
{
    public class EmployeeReportPageML
    {

    }

    public class MarketingSldeshow
    {
        public string Cust_ID { get; set; }
        public int? paid { get; set; }
        public string ProfileID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string DOB { get; set; }
        public int? Age { get; set; }
        public string Height { get; set; }
        public string Caste { get; set; }
        public string Education { get; set; }
        public string EducationGroup { get; set; }
        public string EduGroupnamenew { get; set; }
        public string Profession { get; set; }
        public string JobLocation { get; set; }
        public string Income { get; set; }
        public double? Property { get; set; }
        public string companyname { get; set; }
        public string PlaceOfBirth { get; set; }
        public string TOB { get; set; }
        public string Gothram { get; set; }
        public string Star { get; set; }
        public string FFNative { get; set; }
        public string MFNative { get; set; }
        public string KMPLID { get; set; }
        public bool? IsConfidential { get; set; }
        public int? SuperConfidentila { get; set; }
        public int? HoroscopeStatus { get; set; }
        public string PhotoNames { get; set; }
        public string Photo { get; set; }
        public string ApplicationPhotoPath { get; set; }
        public string HoroscopePath { get; set; }
        public string email { get; set; }
        public int? NoOfBrothers { get; set; }
        public int? NoOfSisters { get; set; }
        public string CasteID { get; set; }
        public int? HeightInCentimeters { get; set; }
        public int? MaritalStatusID { get; set; }
        public string Color { get; set; }
        public string currency { get; set; }
        public bool? Intercaste { get; set; }
        public string fathercaste { get; set; }
        public string mothercaste { get; set; }
        public int? PhotoCount { get; set; }
        public string imageurl { get; set; }
        public object Agemin { get; set; }
        public object Agemax { get; set; }
        public object Heightmin { get; set; }
        public object Heightmax { get; set; }
        public string serviceDate { get; set; }
        public string maritalstatus { get; set; }
        public Int64? TotalRows { get; set; }
        public string Totalpages { get; set; }
        public string MinHeight { get; set; }
        public string MaxHeight { get; set; }
        public string AgeMax { get; set; }
        public string GenderID { get; set; }
        public string SubCaste { get; set; }
        public string mothertongue { get; set; }
        public string countrylivingin { get; set; }
        public string educationspecialisation { get; set; }
        public string Employeedin { get; set; }
        public bool Ownerflag { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string ProfileStatusID { get; set; }
        public string Gender { get; set; }
        public string CustomerApplicationPhoto { get; set; }
        public string CustomerFullPhoto { get; set; }
        public Int32? TotalRowsKeyword { get; set; }
        public string OppStatus { get; set; }
        public string FromTicketIdSuf { get; set; }
        public string ToTicketIDSuf { get; set; }
        public long? FromTicketID { get; set; }
        public string Mystatus { get; set; }
        public long? ToTicketID { get; set; }

        public long? Cust_ProfileInterestsLog_ID { get; set; }
    }
    public class myprofileRequest
    {
        public string Kmpl { get; set; }
        public string Profileid { get; set; }
        public bool HighConfidential { get; set; }
        public bool Confidential { get; set; }
        public bool Renewal { get; set; }
        public int? GenderID { get; set; }
        public string Gender { get; set; }
        public string Surname { get; set; }
        public bool Chksurname { get; set; }
        public string FirstName { get; set; }
        public bool chkfirstname { get; set; }
        public bool chkKmplexperiry { get; set; }
        public Int32? TypeofprofileID { get; set; }
        public string TypeofProfile { get; set; }
        public string ApplicationstatusID { get; set; }
        public string Applicationstatus { get; set; }
        public string MarketingownerID { get; set; }

        public string Marketingowner { get; set; }
        public string BranchID { get; set; }
        public string Branch { get; set; }
        public string CasteID { get; set; }
        public string Caste { get; set; }
        public string OwneroftheprofileID { get; set; }
        public string Owneroftheprofile { get; set; }

        public string HavingprofilesID { get; set; }
        public string Havingprofiles { get; set; }
        public DateTime? Assigneddatefromdate { get; set; }
        public DateTime? Assigneddatetodate { get; set; }

        public DateTime? DORFromdate { get; set; }
        public DateTime? DORTodate { get; set; }

        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public int? LogoutId { get; set; }
        public string Logout { get; set; }
        public int? pagefrom { get; set; }
        public int? pageto { get; set; }
        public Int64? custid { get; set; }
        public Int32? Empid { get; set; }
        public int? IsPaidMember { get; set; }
        public string previousownerID { get; set; }
        public string previousowner { get; set; }
        public int? verfiedcontacts { get; set; }
        public int? WebsiteBlocked { get; set; }
        public int? intTableType { get; set; }
        public string v_MaritalStatus { get; set; }
        public int? i_Domacile { get; set; }
    }

    public class myprofileResponse
    {
        public string Cust_ID { get; set; }
        public string ProfileID { get; set; }
        public int? TotalRows { get; set; }
        public int? Totalpages { get; set; }
        public string KMPLID { get; set; }
        public bool? IsConfidential { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GenderID { get; set; }
        public string Caste { get; set; }
        public string SubCaste { get; set; }
        public int? Age { get; set; }
        public string Height { get; set; }
        public string Color { get; set; }
        public string EducationGroup { get; set; }
        public string Profession { get; set; }
        public string JobLocation { get; set; }
        public string mothertongue { get; set; }
        public string countrylivingin { get; set; }
        public string Star { get; set; }
        public string MaritalStatusID { get; set; }
        public string Gothram { get; set; }
        public string TOB { get; set; }
        public string educationspecialisation { get; set; }
        public string EduGroupnamenew { get; set; }
        public string Employeedin { get; set; }
        public string Income { get; set; }
        public string FFNative { get; set; }
        public string MFNative { get; set; }
        public int? NoOfBrothers { get; set; }
        public int? NoOfSisters { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Photo { get; set; }
        public int? PhotoCount { get; set; }
        public string PhotoNames { get; set; }
        public int? HoroscopeStatus { get; set; }
        public string currency { get; set; }
        public bool? paid { get; set; }
        public bool? Ownerflag { get; set; }
        public string RegistrationDate { get; set; }
        public int? UploadedPhotoscount { get; set; }
        public int? PhotoshopCount { get; set; }
        public string onlinepaid { get; set; }
        public string offlinepaid { get; set; }
        public string onlinepaidcls { get; set; }
        public string offlinepaidcls { get; set; }
        public string OwnerName { get; set; }
        public int? ProfileGrade { get; set; }
        public string serviceDate { get; set; }
        public bool SuperConfidentila { get; set; }
        public string DOB { get; set; }
        public int Property { get; set; }
        public string HoroScopeImage { get; set; }


        public string SRCount { get; set; }
        public string ExpiryDate { get; set; }
        public string Points { get; set; }
        public string TicketID { get; set; }
        public long? Emp_Ticket_ID { get; set; }
        public int? MatchMeetingCount { get; set; }
        public string ProfileOwnername { get; set; }
        public string EmpUserName { get; set; }
        public string SAForm { get; set; }
        public bool? CNumberVerStatus { get; set; }
        public bool? CEmailVerStatus { get; set; }
        public string Reason4InActive { get; set; }
        public long? Cust_Family_ID { get; set; }
        public int? CountryCodeID { get; set; }
        public string CreatedDate { get; set; }
        public string Primarynumber { get; set; }
        public string Primaryemail { get; set; }


        public string ApplicationPhotoPath { get; set; }

        public string DOR { get; set; }

        public string LastLoginDate { get; set; }

        public int? LoginCount { get; set; }

        public int? PaidAmount { get; set; }

        public string ContactNumber { get; set; }

        public string Email { get; set; }

        public int? MybookMarkedProfCount { get; set; }

        public int? WhobookmarkedCount { get; set; }

        public int? RectViewedProfCount { get; set; }

        public int? RectWhoViewedCout { get; set; }

        public int? IgnoreProfileCount { get; set; }

        public int? SentPhotoRequestCount { get; set; }

        public string EmpName { get; set; }

        public string UserName { get; set; }
        public string HoroscopeImage { get; set; }
    }

    public class FeeUpdateML
    {
        public long? EmpTicketID { set; get; }
        public long? EmpID { set; get; }
        public string Message { set; get; }
        public long? AssignedEmpID { set; get; }
        public string feevalue { set; get; }
        public int? CustID { set; get; }
        public string SettlementValue { set; get; }
        public char isSiblings { set; get; }
    }

    public class CreateReminderMI
    {
        public string ProfileID { get; set; }
        public Int64? ReminderID { get; set; }
        public Int64? EmpID { get; set; }
        public string TicketID { get; set; }
        public string DateOfReminder { get; set; }
        public Int64? ReminderType1 { get; set; }
        public string Body { get; set; }
        public Int64? RelationID { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public int IsFollowup { get; set; }

    }
}



