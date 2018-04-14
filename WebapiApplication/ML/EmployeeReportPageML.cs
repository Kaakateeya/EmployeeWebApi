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
    public class NoServiceML
    {

        public Int64 EmpID { get; set; }

        public string ProfileID { get; set; }

        public int? Gender { get; set; }

        public bool boolIsConfidential { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public DataTable Caste { get; set; }

        public DataTable Branch { get; set; }

        public DataTable ApplicationStatus { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public int intlowerBound { get; set; }

        public int intUpperBound { get; set; }

        public int? PaymentStatus { get; set; }

        //Added by lakshmi
        public string castes { get; set; }
        public string branches { get; set; }
        public string applicationstatus { get; set; }

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
        //public string Color { get; set; }
        //public string EducationGroup { get; set; }
        //public string Profession { get; set; }
        //public string JobLocation { get; set; }
        public string mothertongue { get; set; }
        //public string countrylivingin { get; set; }
        //public string Star { get; set; }
        //public string MaritalStatusID { get; set; }
        //public string Gothram { get; set; }
        //public string TOB { get; set; }
        //public string educationspecialisation { get; set; }
        //public string EduGroupnamenew { get; set; }
        //public string Employeedin { get; set; }
        //public string Income { get; set; }
        //public string FFNative { get; set; }
        //public string MFNative { get; set; }
        //public int? NoOfBrothers { get; set; }
        //public int? NoOfSisters { get; set; }
        //public string PlaceOfBirth { get; set; }
        public string Photo { get; set; }
        public int? PhotoCount { get; set; }
        public string PhotoNames { get; set; }
        public int? HoroscopeStatus { get; set; }
        //public string currency { get; set; }
        public bool? paid { get; set; }
        //public bool? Ownerflag { get; set; }
        public string RegistrationDate { get; set; }
        public int? UploadedPhotoscount { get; set; }
        public int? PhotoshopCount { get; set; }
        //public string onlinepaid { get; set; }
        //public string offlinepaid { get; set; }
        //public string onlinepaidcls { get; set; }
        //public string offlinepaidcls { get; set; }
        public string OwnerName { get; set; }
        public int? ProfileGrade { get; set; }
        public string serviceDate { get; set; }
        public bool SuperConfidentila { get; set; }
        public string DOB { get; set; }
        //public int Property { get; set; }
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
        //public string Reason4InActive { get; set; }
        //public long? Cust_Family_ID { get; set; }
        //public int? CountryCodeID { get; set; }
        //public string CreatedDate { get; set; }
        public string Primarynumber { get; set; }
        public string Primaryemail { get; set; }


        public string ApplicationPhotoPath { get; set; }

        public string DOR { get; set; }

        //public string LastLoginDate { get; set; }

        //public int? LoginCount { get; set; }

        public string PaidAmount { get; set; }

        //public string ContactNumber { get; set; }

        //public string Email { get; set; }

        //public int? MybookMarkedProfCount { get; set; }

        //public int? WhobookmarkedCount { get; set; }

        //public int? RectViewedProfCount { get; set; }

        //public int? RectWhoViewedCout { get; set; }

        //public int? IgnoreProfileCount { get; set; }

        //public int? SentPhotoRequestCount { get; set; }

        //public string EmpName { get; set; }

        //public string UserName { get; set; }
        public string HoroscopeImage { get; set; }


        public long? Row { get; set; }


        public string LastLoginDate { get; set; }

        public int? LoginCount { get; set; }

        public string Thumbnailpath { get; set; }

        public string qualification { get; set; }

        public string Profession { get; set; }

        public string JobLocation { get; set; }

        public string MaritalStatus { get; set; }

        public string Star { get; set; }

        public string Gothram { get; set; }

        public string TOB { get; set; }

        public int? Property { get; set; }

        public string Income { get; set; }

        public string FFNative { get; set; }

        public string MFNative { get; set; }

        public string PlaceOfBirth { get; set; }

        public bool Intercaste { get; set; }

        public string fathercaste { get; set; }

        public string mothercaste { get; set; }

        public string currency { get; set; }

        public int? ProfileStatusID { get; set; }
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
    public class AssigningProfileML
    {
        public DateTime? ReviewFromDate { get; set; }

        public int? IsConfidential { get; set; }

        public string isPaid { get; set; }

        public string genderId { get; set; }

        public int? EmpID { get; set; }


        public DataTable Gender { get; set; }

        public DataTable Paid { get; set; }

        public DateTime? ReviewToDate { get; set; }

        public int? SectionID { get; set; }



        public int? ReviewStatusID { get; set; }

        public bool ISRegistarion { get; set; }

        public string ProfileStatusID { get; set; }

        public DataTable isProfileStatusID { get; set; }

        public string Casteid { get; set; }

        public DataTable Caste { get; set; }

        public string Branchid { get; set; }

        public DataTable Branch { get; set; }

        public string ProfileReviewedEmpID { get; set; }

        public DataTable ProfileReviewedEmp { get; set; }

        public int? PageTo { get; set; }

        public int? PageFrom { get; set; }

        public DataTable paid { get; set; }

        public int? region { get; set; }
    }


    public class guestticketcreation
    {

        public int? EmpID { get; set; }

        public string ProfileID { get; set; }

        public string MobileNumber { get; set; }
        public string Email { get; set; }
    }


    public class messagesverification
    {
        public int? i_Type { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        public Int64? MessagesID { get; set; }
        public int? MessageStatusID { get; set; }
        public Int64? EmpID { get; set; }
    }
    public class updatemessagesverification
    {
        public Int64? FromCustID { get; set; }
        public Int64? ToCustID { get; set; }
        public string StrHtmlText { get; set; }
        public Int32? MessageStatusId { get; set; }
        public Int64? EmpId { get; set; }
        public Int32 ReadFlag { get; set; }
        public Int64? MessageHistoryId { get; set; }
        public Int32 Accepted { get; set; }
        public Int64? MessageLinkId { get; set; }
    }
    public class EditpaymentpointS
    {
        public Int64? intEmpId { get; set; }
        public int? intCust_Id { get; set; }
        public string strProfileId { get; set; }
        public int? Allowed_Points { get; set; }
        public int? Allowed_Days { get; set; }
        public DateTime? Old_ExpiryDate { get; set; }
    }
    public class authorizationpayment
    {
        public int? intRegional { get; set; }
        public string intBranch { get; set; }
        public string intEmpID { get; set; }
        public int? intTicketVerified { get; set; }
        public int? intMarked { get; set; }
        public DateTime? dtStartDate { get; set; }
        public DateTime? dtEndDate { get; set; }
    }

    public class employeepaymentedit
    {

        public int? Empid { get; set; }
        public int? intpaymentid { get; set; }
        public int? intPaymentHisId { get; set; }
        public string ProfileID { get; set; }
        public Decimal? decgreedAmount { get; set; }
        public Decimal? decPaidAmount { get; set; }
        public string strPaydescription { get; set; }
    }
    public class insertemailsbounce
    {
        public int PageID { get; set; }
        public string EmailID { get; set; }
        public string profileID { get; set; }
        public int CategoryID { get; set; }
        public DateTime Bounce_From_date { get; set; }
        public DateTime Email_Sent_From_Date { get; set; }
        public DateTime Narration_Date { get; set; }
        public string Narration { get; set; }
        public Int64 EnteredbyEmpID { get; set; }
        public string status { get; set; }

    }
    public class paymentreports
    {
        public string StrProfileID { get; set; }
        public int? Gender { get; set; }
        public int IsAdmin { get; set; }
        public int? PayFor { get; set; }
        public int? PaymenytStatus { get; set; }
        public int? Region { get; set; }
        public int? PayAmountFrom { get; set; }
        public int? PayAmountTo { get; set; }
        public int? FromAmount { get; set; }
        public int? ToAmount { get; set; }
        public int? Confidential { get; set; }
        public int? IsServiceTaxPaid { get; set; }
        public int IsAmountThere { get; set; }
        public int? EmpType { get; set; }
        public DataTable ApplicationStatus { get; set; }
        public DataTable SearchedBy { get; set; }
        public DataTable Caste { get; set; }
        public DataTable Branch { get; set; }
        public DataTable OwnerOFProfile { get; set; }
        public DataTable Relationship { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? From { get; set; }
        public int? To { get; set; }
        public int? ModeOfPaymentID { set; get; }

        //Added by:S.Ashakiran,Date:8/26/13,Description:Add paging to gridview

        public int flag { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int intlowerBound { get; set; }
        public int intUpperBound { get; set; }

        public string profileownerid { get; set; }

        public string ApplicationStatusid { get; set; }

        public string Casteid { get; set; }

        public string Branchid { get; set; }
    }

    public class paymentreportsms
    {

        public int? CategoryID { get; set; }

        public string MessageText { get; set; }

        public Int64? FromEmpID { get; set; }

        public Int64? ToEmpID { get; set; }

        public Int64? CustID { get; set; }
    }
    public class paymenteditdelete
    {


        public string strProfileID { get; set; }

        public int? intPaymentID { get; set; }

        public int? intMemberShipTypeID { get; set; }

        public Decimal? floatAgreedAmt { get; set; }

        public int? intCasteID { get; set; }

        public int? intFlagID { get; set; }
    }

    public class emplyeeSuccessStoryML
    {



        public Int64? EmpID { get; set; }

        public Int64? BrideID { get; set; }

        public string Bridename { get; set; }

        public Int64? GroomID { get; set; }

        public string Groomname { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Attachphoto { get; set; }

        public string SuccesSstory { get; set; }

        public bool Displayinweb { get; set; }

        public int? flag { get; set; }

        public string strSuccessstories { get; set; }
    }


    public class insetnoserice
    {
        public int? intCust_ID { get; set; }

        public string strProfileID { get; set; }

        public int? intTicketOwnerID { get; set; }

        public string strReason { get; set; }

        public int? intEnteredBy { get; set; }
    }
    public class responsechksurname
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Profileid { get; set; }
        public int? Status { get; set; }
    }
    public class CreateKeywordLlikesearchReqoldkmpl
    {


        public string CEducationalDetails { get; set; }
        public string CEducationCategory { get; set; }
        public string CEduUniversity { get; set; }
        public string CSecondaryQualification { get; set; }
        public string CPrimaryQualification { get; set; }
        public string CQualificationDetails { get; set; }
        public string CJobLocation { get; set; }
        public string Companyname { get; set; }
        public string CMonthlysalary { get; set; }
        public string CProfession { get; set; }
        public string CprofessionDetails { get; set; }
        public string CPropertyDetails { get; set; }
        public string CpropertyType { get; set; }
        public string CPropertyValue { get; set; }
        public string CPlaceOfBirth { get; set; }
        public string CGothram { get; set; }
        public string CKujadosham { get; set; }
        public string CLagnam { get; set; }
        public string CMaternalGothram { get; set; }
        public string CMotherTongue { get; set; }
        public string CPaadam { get; set; }
        public string CRaasi { get; set; }
        public string CStar { get; set; }
        public string CStarLanguage { get; set; }
        public string CTimeofBirth { get; set; }
        public string CApplicationStatus { get; set; }
        public string Caste { get; set; }
        public string CBornCitigen { get; set; }
        public string CContactAddress { get; set; }
        public string CContactNo { get; set; }
        public string CDateofReg { get; set; }
        public string CDOB { get; set; }
        public string CEmailID { get; set; }
        public string CFName { get; set; }
        public string CLName { get; set; }
        public string CPhotos { get; set; }
        public string CRelision { get; set; }
        public string CSubCaste { get; set; }
        public string CFromAge { get; set; }
        public string CFromHeight { get; set; }
        public string CGender { get; set; }
        public string CMaritalstatus { get; set; }
        public string CToAge { get; set; }
        public string CToHeight { get; set; }
        public string CCityOfLiving { get; set; }
        public string CDistrictOfLiving { get; set; }
        public string CDomicile { get; set; }
        public string CStateOfLiving { get; set; }
        public string CPhNosOffice { get; set; }
        public string CResidence { get; set; }
        public string CMobile { get; set; }
        public string CSecondary_EmailID { get; set; }
        public string CPermt_Add { get; set; }
        public string CNotes { get; set; }
        public string CKnown_Language { get; set; }
        public string CDiet { get; set; }
        public string CSmoker { get; set; }
        public string CDrinker { get; set; }
        public string CBodyType { get; set; }
        public string CFamilyValue { get; set; }
        public string PAgeFrom { get; set; }
        public string PAgeTo { get; set; }
        public string PHeightFrom { get; set; }
        public string PHeightTo { get; set; }
        public string PCaste { get; set; }
        public string PSubCaste { get; set; }
        public string PCategory { get; set; }
        public string PQualifications { get; set; }
        public string PProfession { get; set; }
        public string PJobPreference { get; set; }
        public string PLocation { get; set; }
        public string PAbroadPrefer { get; set; }
        public string PCountry { get; set; }
        public string PState { get; set; }
        public string PDistrict { get; set; }
        public string PMotherTongue { get; set; }
        public string PComplexion { get; set; }
        public string PPrefStars { get; set; }
        public string PNonPrefStars { get; set; }
        public string CBName { get; set; }
        public string CBType { get; set; }
        public string CBEducation { get; set; }
        public string CBProfession { get; set; }
        public string CBDesignation { get; set; }
        public string CBJobLocation { get; set; }
        public string CBPhone { get; set; }
        public string CBEmail { get; set; }
        public string CBWName { get; set; }
        public string CBWEducation { get; set; }
        public string CBWProfession { get; set; }
        public string CBWDesignation { get; set; }
        public string CBWPhone { get; set; }
        public string CBWEmailId { get; set; }
        public string CBWFatherName { get; set; }
        public string CBWFatherSName { get; set; }
        public string CBWFPhoneNumber { get; set; }
        public string CBWFNativePlace { get; set; }
        public string CSName { get; set; }
        public string CSType { get; set; }
        public string CSEducation { get; set; }
        public string CSDesignation { get; set; }
        public string CSJobLocation { get; set; }
        public string CSPNumber { get; set; }
        public string CSEmailID { get; set; }
        public string CSHFirstName { get; set; }
        public string CSHSurName { get; set; }
        public string CSHEducation { get; set; }
        public string CSHProfession { get; set; }
        public string CSHDesignation { get; set; }
        public string CSHNumber { get; set; }
        public string CSHEmailID { get; set; }
        public string CSHFName { get; set; }
        public string CSHFPNumbe { get; set; }
        public string CSHFNative { get; set; }
        public string CSHCaste { get; set; }
        public string FName { get; set; }
        public string FEducation { get; set; }
        public string FProfession { get; set; }
        public string FPhone { get; set; }
        public string FEmailId { get; set; }
        public string FFName { get; set; }
        public string FFPhone { get; set; }
        public string FFEmailID { get; set; }
        public string FFState { get; set; }
        public string FFDistrict { get; set; }
        public string FFNative { get; set; }
        public string MName { get; set; }
        public string MEducation { get; set; }
        public string MProfession { get; set; }
        public string MPhone { get; set; }
        public string MEmailId { get; set; }
        public string MFName { get; set; }
        public string MFPhone { get; set; }
        public string MFEmailID { get; set; }
        public string MFState { get; set; }
        public string MFDistrict { get; set; }
        public string MFNative { get; set; }
        public string MBName { get; set; }
        public string MBType { get; set; }
        public string MBProfession { get; set; }
        public string MBPNumber { get; set; }
        public string MBEmailId { get; set; }
        public string MSName { get; set; }
        public string MSType { get; set; }
        public string MSHFName { get; set; }
        public string MSHSName { get; set; }
        public string MSHNative { get; set; }
        public string MSHProfession { get; set; }
        public string MSHPNumber { get; set; }
        public string MSHEmailID { get; set; }
        public string FBName { get; set; }
        public string FBType { get; set; }
        public string FBProfession { get; set; }
        public string FBPNuFBer { get; set; }
        public string FBEmailId { get; set; }
        public string FSName { get; set; }
        public string FSType { get; set; }
        public string FSHFName { get; set; }
        public string FSHSName { get; set; }
        public string FSHNative { get; set; }
        public string FSHProfession { get; set; }
        public string FSHPNuFBer { get; set; }
        public string FSHEmailID { get; set; }
        public string CandidateAll { get; set; }
        public string FatherAll { get; set; }
        public string MotherAll { get; set; }
        public string BrotherAll { get; set; }
        public string SisterAll { get; set; }
        public string MotherBortherAll { get; set; }
        public string MotherSisterAll { get; set; }
        public string FatherBrotheAll { get; set; }
        public string FatherSisterAll { get; set; }
        public string startindex { get; set; }
        public string EndIndex { get; set; }
        public string EmpID { get; set; }

        public DataTable dtPartnerPreference { get; set; }
    }
    public class nomatchesreason
    {
        public string v_EmpID { get; set; }
        public int? i_Region { get; set; }
        public string v_Branch { get; set; }
        public int? i_flag { get; set; }
        public int? i_Cust_ID { get; set; }
        public string v_Reason { get; set; }
        public int? i_Authorized { get; set; }
        public int? startindex { get; set; }
        public int? endindex { get; set; }


    }
    public class EmpNotifications
    {
        public Int64? ICustID { get; set; }
        public string strActionName { set; get; }
        public int? iEmpID { set; get; }
        public int i_display { set; get; }
        public int? iNotificationID { set; get; }
        public string strCustomerPhoto { set; get; }
        public string strCustomerName { set; get; }
        public string strProfileID { set; get; }
        public int? NotifyCount { get; set; }
        public int? CategoryID { get; set; }
    }

    public class keywordlikesearch
    {


        public DataTable dtPartnerPreference { get; set; }

        public int? EmpID { get; set; }

        public int? startindex { get; set; }

        public int? EndIndex { get; set; }

        public string ApplicationStatus { get; set; }


        //
        public string AllContactNo { get; set; }
        public string AllEmails { get; set; }
        public string AllSurNames { get; set; }
        public string AllNatives { get; set; }
        public string CEducationAll { get; set; }
        public string CProfAll { get; set; }
        public string FAllFields { get; set; }
        public string MAllFields { get; set; }
        public string Br_AllFields { get; set; }
        public string Sr_AllFields { get; set; }
        public string FB_AllFields { get; set; }
        public string FS_AllFields { get; set; }
        public string MB_AllFields { get; set; }
        public string MS_AllFields { get; set; }
        public string CAll { get; set; }
        public int? Gender { get; set; }
        public string Caste { get; set; }
        public int? Age { get; set; }

        public int? AgeFr { get; set; }
        public int? AgeTo { get; set; }
        public float? HeightFr { get; set; }
        public float? HeightTo { get; set; }
        public int? Democel { get; set; }

        public string SP_AllFields { get; set; }

    }
    public class closereminder
    {
        public long? Reminderid { get; set; }
        public long? closeEmpid { get; set; }
        public string ClosedReminderreason { get; set; }

    }

    public class RestoredProfileid
    {
        public long? CustID { get; set; }
        public long? EmpID { get; set; }
        public int? RequestedBY { get; set; }
        public long? RequestedBYEmpID { get; set; }
        public int? RelationshipID { get; set; }
        public string Relationshipname { get; set; }
        public string Reasonforrestore { get; set; }
        public int? PriviousProfileStatus { get; set; }
    }


    public class newkeywordlikesrch
    {
        //Candidates
        public string Gender { get; set; }
        public string maritalstatus { get; set; }
        public string FromAge { get; set; }
        public string ToAge { get; set; }
        public string FromHeight { get; set; }
        public string ToHeight { get; set; }
        public string Caste { get; set; }

        //
        public string CEducationAll { get; set; }
        public string CEducationCategory { get; set; }
        public string CEduGroup { get; set; }
        public string CEduSplecialization { get; set; }
        public string CEduUniversity { get; set; }
        public string CEduCollege { get; set; }
        public string CEduCountry { get; set; }
        public string CEduState { get; set; }
        public string CEduDistrict { get; set; }
        public string CEduCity { get; set; }
        public string CEduMerits { get; set; }
        public string CEduPass_Year { get; set; }

        //Profession
        public string CProfAll { get; set; }
        public string EmployeedIn { get; set; }
        public string Professionalgroup { get; set; }
        public string Profession { get; set; }
        public string Companyname { get; set; }
        public string monthlysalary { get; set; }

        public string countryworking { get; set; }
        public string stateworking { get; set; }
        public string districtworking { get; set; }
        public string cityworking { get; set; }
        public string workingfromdate { get; set; }
        public string professionDetails { get; set; }

        //Add Kiran 20/08/2016

        public string CDOB { get; set; }
        public string CColor { get; set; }
        public string CPhotos { get; set; }
        public string CBornCitigen { get; set; }
        public string CRelision { get; set; }
        public string CMotherTongue { get; set; }
        public string CApplicationStatus { get; set; }
        public string CDomicile { get; set; }
        public string CRegionalOfBranch { get; set; }
        public string CBranch { get; set; }
        public string CDateofReg { get; set; }
        public string CRegStatus { get; set; }
        public string CPhotoGrade { get; set; }
        public string CEducationGrade { get; set; }
        public string CPropertyGrade { get; set; }
        public string CFamilyGrade { get; set; }
        public string CProfessionGrade { get; set; }
        public string CPhysicalStatus { get; set; }
        public string CDrink { get; set; }
        public string CSmoke { get; set; }
        public string CDiet { get; set; }
        public string CBodyType { get; set; }
        public string CParentCaste { get; set; }
        public string CAboutMe { get; set; }
        public string CAboutFamily { get; set; }
        public string CWebsiteStatus { get; set; }
        public string CCountryOfBirth { get; set; }
        public string CStateOfBirth { get; set; }
        public string CDistrictOfBirth { get; set; }
        public string CCityOfBirth { get; set; }
        public string CStarLanguage { get; set; }
        public string CStar { get; set; }
        public string CPaadam { get; set; }
        public string CLagnam { get; set; }
        public string CRaasi { get; set; }
        public string CGothram { get; set; }
        public string CMaternalGothram { get; set; }
        public string CKujadosham { get; set; }
        public string CHouseflatNumner { get; set; }
        public string CApartmentName { get; set; }
        public string CStreetName { get; set; }
        public string CAreaName { get; set; }
        public string CLandmark { get; set; }
        public string CCountry { get; set; }
        public string CSate { get; set; }
        public string CDistrict { get; set; }
        public string CCity { get; set; }
        public string CZippin { get; set; }

        public string SFName { get; set; }
        public string SLName { get; set; }
        public string SpouseEducation { get; set; }
        public string SpouseProfession { get; set; }
        public string SpouseMarriedOn { get; set; }
        public string SpouseSeparatedDate { get; set; }
        public string SpouseLegallyDivorced { get; set; }
        public string SouseFatherName { get; set; }
        public string SpouseFatherSurname { get; set; }
        public string Spouseaboutpreviousmarriage { get; set; }
        public string SpousefamilyPlaning { get; set; }
        public string SspouseNoOfChildrens { get; set; }


        public string RefName { get; set; }
        public string RefSurname { get; set; }
        public string Refprofession { get; set; }
        public string Refcountry { get; set; }
        public string RefState { get; set; }
        public string RefDistrict { get; set; }
        public string RefNativePlace { get; set; }
        public string RefPresentLocation { get; set; }
        public string RefMobile { get; set; }
        public string ReflandLine { get; set; }
        public string RefEmail { get; set; }
        public string RefNarration { get; set; }

        public string CFName { get; set; }
        public string CLName { get; set; }
        public string CpropertyType { get; set; }
        public string CPropertyValue { get; set; }
        public string CPropertyDescription { get; set; }
        //
        public string FFirstName { get; set; }
        public string FEducationDetails { get; set; }
        public string FProfessionDetails { get; set; }
        public string FCompanyId { get; set; }
        public string FJobLocation { get; set; }
        public string FNumber { get; set; }
        public string Femail { get; set; }
        public string FFatherName { get; set; }
        public string FFatherContactNumber { get; set; }
        public string FFStateName { get; set; }
        public string FFDistrictName { get; set; }
        public string FFNativePlace { get; set; }
        public string FAllFields { get; set; }

        //Mother
        //06/06/2016

        public string MFirstName { get; set; }
        public string MLastName { get; set; }
        public string MEducationDetails { get; set; }
        public string MProfessionDetails { get; set; }
        public string MCompanyId { get; set; }
        public string MJobLocation { get; set; }
        public string MNumber { get; set; }
        public string Memail { get; set; }
        public string MFatherFirstName { get; set; }
        public string MFatherLastName { get; set; }
        public string MFatherContactNumber { get; set; }
        public string MFStateName { get; set; }
        public string MFDistrictName { get; set; }
        public string MFNativePlace { get; set; }
        public string MAllFields { get; set; }

        //Brother
        public string Br_AllFields { get; set; }
        public string Br_Name { get; set; }
        public string Br_Education { get; set; }
        public string Br_Profession { get; set; }
        public string Br_CompanyNAME { get; set; }
        public string Br_Joblocation { get; set; }
        public string BrContactNo { get; set; }

        public string Br_Email { get; set; }
        public string Brw_Name { get; set; }
        public string Brw_Education { get; set; }
        public string Brw_Profession { get; set; }
        public string Brw_CompanyNAME { get; set; }
        public string Brw_Joblocation { get; set; }
        public string BrwContactNo { get; set; }

        public string Brw_Email { get; set; }
        public string Brwf_Surname { get; set; }
        public string Brwf_Name { get; set; }
        public string BrwfStateName { get; set; }
        public string BrwfDistrictName { get; set; }
        public string BrwfCity { get; set; }
        //Sister
        public string Sr_AllFields { get; set; }
        public string Sr_Name { get; set; }
        public string Sr_Education { get; set; }
        public string Sr_Profession { get; set; }
        public string Sr_CompanyNAME { get; set; }
        public string Sr_Joblocation { get; set; }
        public string SrContactNo { get; set; }

        public string Sr_Email { get; set; }
        public string Srh_Name { get; set; }
        public string Srh_Education { get; set; }
        public string Srh_Profession { get; set; }
        public string Srh_CompanyNAME { get; set; }
        public string Srh_Joblocation { get; set; }
        public string SrhContactNo { get; set; }

        public string Srh_Email { get; set; }
        public string Srhf_Surname { get; set; }
        public string Srhf_Name { get; set; }
        public string SrhfStateName { get; set; }
        public string SrhfDistrictName { get; set; }
        public string SrhfCity { get; set; }
        //father brother
        public string FB_AllFields { get; set; }
        public string FB_ElderYounger { get; set; }
        public string FB_Name { get; set; }
        public string FB_Education { get; set; }
        public string FB_Profession { get; set; }
        public string FB_Contactnumber { get; set; }
        public string FB_Email { get; set; }
        public string FB_professionlocation { get; set; }
        //father sister
        public string FS_AllFields { get; set; }
        public string FS_Name { get; set; }
        public string FSH_Surname { get; set; }
        public string FSH_Name { get; set; }
        public string FSH_Education { get; set; }
        public string FSH_Profession { get; set; }
        public string FSHContactNo { get; set; }
        public string FSH_Email { get; set; }
        public string FSH_ProfessionLocation { get; set; }
        public string FSHStateName { get; set; }
        public string FSHDistrictName { get; set; }
        public string FSHCityName { get; set; }

        //mother brother
        public string MB_AllFields { get; set; }
        public string MB_Name { get; set; }
        public string MB_Education { get; set; }
        public string MB_Profession { get; set; }
        public string MB_ContactNo { get; set; }
        public string MB_Email { get; set; }
        public string MB_professionlocation { get; set; }
        //mother sister
        public string MS_AllFields { get; set; }
        public string MS_Name { get; set; }
        public string MSH_Surname { get; set; }
        public string MSH_Name { get; set; }
        public string MSH_Education { get; set; }
        public string MSH_Profession { get; set; }
        public string MSH_ContactNo { get; set; }
        public string MSH_Email { get; set; }
        public string MSH_ProfessionLocation { get; set; }
        public string MSHStateName { get; set; }
        public string MSHDistrictName { get; set; }
        public string MSHCityName { get; set; }

        //


        public string startindex { get; set; }

        public string EndIndex { get; set; }

        public string EmpID { get; set; }

        public string ApplicationStatus { get; set; }
        public int? CDomiciletext { get; set; }

        //Add Kiran 13/09/2016

        public string Pr_Age_fr { set; get; }
        public string Pr_Age_to { set; get; }
        public string Pr_Hight_fr { set; get; }
        public string Pr_Hight_to { set; get; }
        public string Pr_MotherTongue { set; get; }
        public string Pr_Religion { set; get; }
        public string Pr_Caste { set; get; }
        public string Pr_SubCaste { set; get; }
        public string Pr_MaritalStatus { set; get; }
        public string Pr_Education { set; get; }
        public string Pr_Profession { set; get; }
        public string Pr_Mangalic { set; get; }
        public string Pr_StarLanguage { set; get; }
        public string Pr_NonPreferredStar { set; get; }
        public string Pr_Diet { set; get; }
        public string Pr_PreferredCountry { set; get; }
        public string Pr_PreferredState { set; get; }
        public string Pr_Region { set; get; }
        public string Pr_Branch { set; get; }

        //contct All
        public string CContactAddress_All { set; get; }
        //public string CAll { get; set; }
        //public string ContactNo_All { get; set; }
        ////
        //public string SLegallyDivorcedDate { get; set; }
        //public string SNoofChilds_Boys { get; set; }
        //public string SNoofChilds_Girls { get; set; }
        //public string CSinceDate { get; set; }
        //public string CArrivalDate { get; set; }
        //public string CDepartureDate { get; set; }
        //public string CVisaSatus { get; set; }
        //public string CSalaryCurrency { get; set; }
        //public string CTimeofBirth { get; set; }
        //public string CMeternalGothram { get; set; }
        //public string RefRelationShipType { get; set; }
        //public string CProfileGrade { get; set; }
        //public string CPhotoProtectStatus { get; set; }
        //public string CConfidentialStatus { get; set; }
        //public string CHighConfidentialStatus { get; set; }
        //public string IsSeriousMatch { get; set; }
        //public string AllEmails { get; set; }

        public DataTable dtPartnerPreference { get; set; }

        public string strShowprofile { get; set; }

        public string monthlysalary_To { set; get; }
        public string CSubCaste { set; get; }

        public string Arrivaldatefrom { set; get; }
        public string Arrivaldateto { set; get; }
        public string Departuredatefrom { set; get; }
        public string DeparturedateTo { set; get; }
        public string Residingsincefrom { set; get; }
        public string ResidingsinceTo { set; get; }
        public string Sp_NoofChilds_Boys { set; get; }
        public string Sp_NoofChilds_Girls { set; get; }
        public string C_PropertyValue_To { set; get; }
        public string VisaStatus { set; get; }
        public string C_SibCount_Bro { set; get; }
        public string C_SibCount_Sis { set; get; }
        public string C_ParentCaste { set; get; }
        public string C_FatherCaste { set; get; }
        public string C_MotherName { set; get; }
        public string Ref_RelationShipType { set; get; }
        public string C_FamilyStatusGrade { set; get; }
        public string C_ProfileGrade { set; get; }

        //
        public string Pr_WillingtoSecondMrg { set; get; }
        //
        public string CB_MarriedStatus { set; get; }
        public string CB_YEStatus { set; get; }
        public string CS_MarriedStatus { set; get; }
        public string CS_YEStatus { set; get; }
        public string CFS_YEStatus { set; get; }
        public string CMS_YEStatus { set; get; }
        public string CMB_YEStatus { set; get; }
        public string Pr_ProfessionDetails { set; get; }
        public string Pr_NativeLocation { set; get; }

        public string Pr_PreferredStar { set; get; }
        public string C_ArrivalBetween100Days { set; get; }
        public string C_DepartureBetween100Days { set; get; }

        public string PaidStatus { get; set; }
    }

    public class MasterData
    {
        public int AppuserID { get; set; }
        public string MasterType { get; set; }
        public int? MasterTypeID { get; set; }
        public int? DependentId { get; set; }
        public bool? StatusCode { get; set; }
    }
    public class MasterInsertUpdate
    {
        public int? AppUserId { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string CountryCurrency { get; set; }
        public int? MobileLength { get; set; }
        public int? landlineLength { get; set; }
        public bool StatusCode { get; set; }
        public string MasterType { get; set; }
        public int? MasterTypeID { get; set; }
        public int? DependentId { get; set; }
        public int? DependentDistrictIDId { get; set; }
        public int? SubDependentId { get; set; }
        public float? MinWords { get; set; }
        public float? MaxWords { get; set; }
        public float? CostPOBox { get; set; }
        public int? LanguageID { get; set; }
        public string Comments { get; set; }
        public float? ExtraWordPrice { get; set; }
        public string TamilStarName { get; set; }
        public string KannadaStarName { get; set; }

    }

    public class ticketverification
    {

        public long? Empid { get; set; }

        public string Profileid { get; set; }

        public int? Emp_commisionTicketid { get; set; }

        public Decimal? PaidAmount { get; set; }

        public Decimal? commisionAmount { get; set; }

        public Boolean? TicketMrkedStatus { get; set; }
    }

    public class updatedeletecustomer
    {
        public DateTime? Engagementdate { get; set; }
        public string EngagementVenue { get; set; }
        public DateTime? Marriagedate { get; set; }
        public string MarriageVenue { get; set; }
        public string DelSurname { get; set; }
        public string DelName1 { get; set; }
        public string DelFatherName { get; set; }
        public string DelNative { get; set; }
        public string DelEducation { get; set; }
        public string DelProfession { get; set; }
        public int? DelReasonForDelete { get; set; }
        public int? DelRelationship { get; set; }
        public string DelRelationshipName { get; set; }
        public string Narriation { get; set; }
        public int? ID { get; set; }

        public string Joblocation { get; set; }

        public int? AuthorizationStatus { get; set; }

        public long? Authorizeempid { get; set; }
    }

    public class Employeepermission
    {
        public string EmployeeID { get; set; }
        public DataTable dtPagePermissions { get; set; }
        public long? CreatedEmpID { get; set; }
        public int? PageID { get; set; }
        public Boolean? IsView { get; set; }
        public Boolean? IsAdd { get; set; }
        public Boolean? IsDelete { get; set; }
    }

    public class EmpCountsreport
    {

        public DataTable dtBranch { get; set; }

        public string strBranch { get; set; }

        public string strEmpIDs { get; set; }

        public DataTable dtEmpids { get; set; }

        public int? intRegion { get; set; }

        public int? intStartIndex { get; set; }

        public int? intEndIndex { get; set; }

        public int? intServiceDate { get; set; }

        public int? intPaymentExp { get; set; }

        public int? intNoPhoto { get; set; }

        public int? intNOtYetVerified { get; set; }

        public int? intUnPaid { get; set; }

        public int? intInactive { get; set; }

        public int? intEmailBounce { get; set; }

        public int? intNoSAFirm { get; set; }

        public int? inrPresentInIndia { get; set; }
    }

    public class bankamount
    {

        public string Bankname { get; set; }
        public string modeofdeposit { get; set; }
        public float? depositamount { get; set; }
        public int? depositedby { get; set; }
        public DateTime? depositeddate { get; set; }
        public string Description { get; set; }
        public string LoginEmpName { get; set; }
        public string usernameemployeeid { get; set; }
        public string Typeofamount { get; set; }
        public string empRegionID { get; set; }
        public string Banknametext { get; set; }
    }

    public class EmployeeMarketingTketRequestNew
    {

        public string strBranch { set; get; }
        public string strEmpName { set; get; }
        public int? i_isAdmin { set; get; }
        public int? i_EmpID { set; get; }
        public int? i_PageFrom { set; get; }
        public int? i_PageTo { set; get; }
        public DateTime? dtFromProceedDate { get; set; }
        public DateTime? dtToProceedDate { get; set; }
        public int? i_days { set; get; }
        public int? i_RegionID { get; set; }
        public Boolean? v_MarketremindeFlag { get; set; }
        public Boolean? v_siblingflag { get; set; }
        public Boolean? v_guestticketflag { get; set; }
        public Boolean? v_OnlineExprd { get; set; }
        public int? v_OfflineExprd { get; set; }
        public string i_TicketId { get; set; }
        public string i_EmailId { get; set; }
        public string i_PhoneNumber { get; set; }
        public string i_Name { get; set; }
        public DateTime? dt_Opendate { get; set; }
        public string i_ProfileId { get; set; }
        public string i_Category { get; set; }
        public string i_Ticketstatus { get; set; }
        public DateTime? dt_FromRemainderdate { get; set; }
        public DateTime? dt_ToReminderdate { get; set; }
        public int? i_Excelflag { get; set; }
        public Boolean? V_Notpay { get; set; }
        public Boolean? b_unpaidProfiles { get; set; }

    }

    public class bankamountreport
    {
        public string bankname { get; set; }
        public string modeofdeposit { get; set; }
        public string branch { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }

        public int? empid { get; set; }
    }

    public class employeeworkreport
    {

        public string EMPID { get; set; }
        public string BRANCHID { get; set; }
        public int? MARKETCOUNT { get; set; }
        public int? MATCHFOLLOWUPCOUNT { get; set; }
        public int? SERVICECOUNT { get; set; }
        public string dtFromDate { get; set; }
        public string dtToDate { get; set; }
        public int? intStartIndex { get; set; }
        public int? intEndIndex { get; set; }

        public string intRegionID { get; set; }
    }

    public class employeesmsmatchfollowup
    {


        public string Mobilenumber { get; set; }
        public string Matchfollouptext { get; set; }
    }
}




