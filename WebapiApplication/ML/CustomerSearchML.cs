using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;

namespace WebapiApplication.ML
{
    public class PrimaryInformationMl
    {
        public string strFirstName { get; set; }
        public string strLastName { get; set; }
        // public DateTime dtDOB { get; set; }
        public string dtDOB { get; set; }
        public int intGenderID { get; set; }
        public int? intReligionID { get; set; }//
        public int intMotherTongueID { get; set; }
        public int? intCasteID { get; set; }
        public int? intCountryLivingID { get; set; }
        public int? intMobileCode { get; set; }
        public int? intLandCode { get; set; }
        public int IsCustomer { get; set; }
        public string strMobileNo { get; set; }
        public int ID { get; set; }
        public string strAreaCode { get; set; }
        public string strLandNo { get; set; }
        public string strEmail { get; set; }
        public string strPassword { get; set; }
        public Int64? intProfileRegisteredBy { get; set; }
        public Int64? intEmpID { get; set; }
        public string strKMPLID { get; set; }
        public string strMobileVerificationCode { get; set; }
        public int ischeckboxchecked { get; set; }
        public long cust_id { get; set; }
        public string strCust_id { get; set; }
        public DataTable dtQuicksearch { get; set; }
        public DataTable dtCustprofileDetails { get; set; }
        public int intCustPostedBY { set; get; }
        public int? intMaritalstatus { get; set; }
        public int? StartIndex { get; set; }
        public int? EndIndex { get; set; }
        public int? Name { set; get; }
        public int? FromAge { set; get; }
        public int? ToAge { set; get; }
        public int? iFromHeight { set; get; }
        public int? iToHeight { set; get; }
        public Int64? intCusID { set; get; }
        public int? intGender { get; set; }
        public int? intCountryID { get; set; }
        public string strProfileID { get; set; }
        public string strAgeAndHeight { get; set; }
        public string strReligionName { get; set; }
        public string strCaste { get; set; }
        public string strStar { get; set; }
        public string strLocation { get; set; }
        public string strEducation { get; set; }
        public string strProfession { get; set; }
        public int? intComplexion { get; set; }
        public int? PhysicalStatus { get; set; }
        public string AgeandHeihts { set; get; }
        public int? iStateID { get; set; }
        public int? iEducationID { get; set; }
        public int? iProfessionID { get; set; }
        public int intEndIndex { get; set; }
        public int? i_Registrationdays { set; get; }
        public int intStartIndex { get; set; }
        public int? iStarID { get; set; }
        public string AGE { get; set; }
        public string Heihts { get; set; }
        public DataTable dtCountry { get; set; }
        public DataTable dtCateIDs { get; set; }
        public DataTable dtEducation { get; set; }
        public DataTable dtProfession { get; set; }
        public DataTable dtMotherTongue { get; set; }
        public int? intPhotoCount { get; set; }
        public DataTable dtMaritalstatus { get; set; }
        public DataTable dtMothertongue { get; set; }
        public DataTable dtComplexion { get; set; }
        public DataTable dtCountrylivingin { get; set; }
        public DataTable dtStateLivingIn { get; set; }
        public DataTable dtVisaStatus { get; set; }
        public DataTable dtEduactionCat { get; set; }
        public DataTable dtEducationGroup { get; set; }
        public DataTable dtProfessionGroup { get; set; }
        public DataTable dtStarLang { get; set; }
        public DataTable dtStar { get; set; }
        public int? iAnnualincome { get; set; }
        public Int64? iFromSal { get; set; }
        public Int64? iToSal { get; set; }
        public int? iManglinkKujaDosham { get; set; }
        public int? iDrink { get; set; }
        public int? iSmoke { get; set; }
        public int? iDiet { get; set; }
        public int? iPhysicalstatus { get; set; }
        public int? iCityID { get; set; }
        public int? i_SalaryIncurrency { get; set; }
        public int? iStarLanguage { get; set; }
        public DataTable dtsaveAdvsearch { get; set; }
        public int iupdateFlag { get; set; }
        public DataTable dtsaveGeneralsearch { get; set; }
        public DataTable dtsaveProfileIDsearch { get; set; }
        public int? mybookmarked { get; set; }
        public int? ExpressFlag { get; set; }
        public int? ignode { get; set; }
        public DataTable dtTotalsearch { get; set; }
        public string Maritalstatus { get; set; }
        public string Religion { get; set; }
        public string MotherTongue { get; set; }
        public string Caste { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Educationcategory { get; set; }
        public string Education { get; set; }
        public string Professiongroup { get; set; }
        public string Stars { get; set; }
        public string Complexion { get; set; }
        public string Visastatus { get; set; }
        public string SearchResult_ID { get; set; }
        public int PageFrom { get; set; }
        public int PageTo { get; set; }
        public string strsendPassword { get; set; }
        public string PhysicalStatusstring { get; set; }
        public string bodytype { get; set; }
        public string Agefrom { get; set; }
        public string Ageto { get; set; }
        public string Heightfrom { get; set; }
        public string Heightto { get; set; }
        public string flagforurl { get; set; }
        public string CasteText { get; set; }
        public string CustID { get; set; }
        public string gender { get; set; }
        public string SavedSearch { get; set; }
        public string SavedSearchresultid { get; set; }
        public string SearchPageID { get; set; }
        public string Searchresult { get; set; }
        public string PageName { get; set; }
        public int? intSubCasteID { set; get; }

        public int? BrokerNameID { get; set; }
    }

    public class CustomerHomePageSearch
    {
        public int? CustId { set; get; }
        public int? GenderId { set; get; }
        public int? FromAge { set; get; }
        public int? ToAge { set; get; }
        public int? FromHeight { set; get; }
        public int? ToHeight { set; get; }
        public string Caste { set; get; }
        public int? Country { set; get; }
        public int? StartIndex { set; get; }
        public int? EndIndex { set; get; }

    }

    public class SearchResultSaveEditML
    {
        public Int64? SearchResult_ID { set; get; }
        public string CustID { set; get; }
        public string SearchpageID { set; get; }
        public string CustSavedSearchName { set; get; }
        public string SaveSearchPageName { set; get; }
    }


    public class MissingFieldsUpdateRequest
    {
        public string Starlanguage { get; set; }
        public int? i_updateflag { set; get; }
        public int? iJoblocationCountry { get; set; }
        public int? iJoblocationDistrict { get; set; }
        public int? iJoblocationState { get; set; }
        public int? iJobLocation { get; set; }
        public int? IsSharedProperty { get; set; }
        public int? AstroFlag { get; set; }
        public int? ParentsFlag { get; set; }
        public long? MFCustFamilyID { get; set; }
        public long? FFCustFamilyID { get; set; }
        public string Gothram { get; set; }
        public string MotherNative { get; set; }
        public string Salarycurrency { get; set; }
        public string Salary { get; set; }
        public string Complexion { get; set; }
        public string Star { get; set; }
        public string FatherNative { get; set; }
        public string Propertylakhs { get; set; }
        public string Maritalstatus { get; set; }
        public string Height { get; set; }
        public string CustID { get; set; }
    }


    public class QuicksearchResultML
    {
        public Int64? intCusID { set; get; }
        public string NAME { set; get; }
        public string AgeAndHeight { set; get; }
        public string ReligionName { set; get; }
        public string Caste { set; get; }
        public string Star { set; get; }
        public string Location { set; get; }
        public string Education { set; get; }
        public string Profession { set; get; }
        public string ProfileID { set; get; }
        public string PhoneNumber { set; get; }
        public string Email { set; get; }
        public int? IsprofileMarked { set; get; }
        public string HoroscopeImage { set; get; }
        public int? IsExpressIntrestMarked { set; get; }
        public int? IsIntrested { set; get; }
        public int? IsMessage { set; get; }
        public Int64? TotalRows { set; get; }
        public Int64? TotalPages { set; get; }
        public string placeofbirth { set; get; }
        public string Photo { set; get; }
        public string Photofullpath { set; get; }
        public string PhotoClass { set; get; }
        public int? PhotoCount { set; get; }
        public int? GenderID { get; set; }
        public int? intReligionID { get; set; }
        public int? intGender { get; set; }
        public int? intRefFromAge { get; set; }
        public int? intRefToAge { get; set; }
        public int? intRefFromHeight { get; set; }
        public int? intRefToHeight { get; set; }
        public DataTable dtRefCastType { get; set; }
        public DataTable dtRefMotherTongueType { get; set; }
        public DataTable dtRefLocationType { get; set; }
        public DataTable dtRefEducationDetailsType { get; set; }
        public DataTable dtRefProfessionType { get; set; }
        public DataTable dtRefPhotoType { get; set; }
        public int? intPhotoType { get; set; }
        public int intEndIndex { get; set; }
        public int intStartIndex { get; set; }
        public int? iCasteID { get; set; }
        public int? iStarID { get; set; }
        public int? iCountryID { get; set; }
        public int? iReligionID { get; set; }
        public int? iProfessionID { get; set; }
        public int? iProfessionGroupID { get; set; }
        public int? iHeightInCentimeters { get; set; }
        public int? iStarLanguageID { get; set; }
        public int? iCityID { get; set; }
        public int? iStateID { get; set; }
        public int? iEducationGroupID { get; set; }
        public string Age { get; set; }
        public string Height { get; set; }
        public string PhotoPassword { set; get; }
        public string MaritalStatusId { get; set; }
        public string MaritualStatus { get; set; }
        public int? IsPaidMember { get; set; }
        public string strFirstName { get; set; }
        public DataTable dtCateIDs { get; set; }
        public DataTable dtCountry { get; set; }
        public DataTable dtEducation { get; set; }
        public DataTable dtProfession { get; set; }
        public DataTable dtMotherTongue { get; set; }
        public DataTable dtMaritalstatus { get; set; }
        public int? i_Registrationdays { get; set; }
        public int iToHeight { get; set; }
        public int iFromHeight { get; set; }
        public int ToAge { get; set; }
        public int FromAge { get; set; }
        public int? intPhotoCount { get; set; }
        public DataTable dtStateLivingIn { get; set; }
        public DataTable dtComplexion { get; set; }
        public DataTable dtVisaStatus { get; set; }
        public DataTable dtEducationGroup { get; set; }
        public DataTable dtProfessionGroup { get; set; }
        public DataTable dtStarLang { get; set; }
        public DataTable dtStar { get; set; }
        public int? iAnnualincome { get; set; }
        public long? iFromSal { get; set; }
        public int? iManglinkKujaDosham { get; set; }
        public int? iDiet { get; set; }
        public int? iPhysicalstatus { get; set; }
        public long? iToSal { get; set; }
        public string strLastName { get; set; }
        public string strProfileID { get; set; }
        public int? NoOfProfiles { get; set; }
        public int? mybookmarked { get; set; }
        public int? ExpressFlag { get; set; }
        public int? ignode { get; set; }
        public string mothertongue { get; set; }
        public long? LogId { get; set; }
        public long? LogID { get; set; }
        public string DistName { get; set; }
    }
    public class Newsavedserach
    {
        public Int64? CustID { get; set; }
        public int? Lookingfor { get; set; }
        public string FromAge { get; set; }
        public string ToAge { get; set; }
        public string FromHeight { get; set; }
        public string ToHeight { get; set; }
        public string Maritalstatus { get; set; }
        public string Religion { get; set; }
        public string Mothertongue { get; set; }
        public string Caste { get; set; }
        public string Complexion { get; set; }
        public string Physicalstatus { get; set; }
        public string CountyWorking { get; set; }
        public string StateWorking { get; set; }
        public string Visastatus { get; set; }
        public string Educationcategory { get; set; }
        public string EducationGroup { get; set; }
        public string Educationspecialization { get; set; }
        public string professioncategory { get; set; }
        public string Professiongroup { get; set; }
        public string Professionspecialization { get; set; }
        public string Annualincome { get; set; }
        public string FromSalary { get; set; }
        public string ToSalary { get; set; }
        public string Starlanguage { get; set; }
        public string Star { get; set; }
        public string ManglikKujaDosham { get; set; }
        public string Drink { get; set; }
        public string Smoke { get; set; }
        public string Diet { get; set; }
        public int? Registrationdays { get; set; }
        public string CustSavedSearchName { get; set; }
        public string searchPageName { get; set; }
        public string searchPageID { get; set; }
        public Int64? SearchResult_ID { get; set; }
    }

    public class ProfileIDSearch
    {
        public Int64? intCusID { set; get; }
        public int? intGender { get; set; }
        public string strFirstName { get; set; }
        public string strLastName { get; set; }
        public string strProfileID { get; set; }
        public int? intCasteID { get; set; }
        public int? StartIndex { get; set; }
        public int? EndIndex { get; set; }
        public int? iupdateFlag { get; set; }
    }
    public class TDetailedRegistration
    {
        public string NAME { set; get; }
        public int? Maritalstatus { set; get; }
        public int? Heights { set; get; }
        public int? Complexion { set; get; }
        public int? Physicalstatus { set; get; }
        public string Citizenship { set; get; }
        public int? BornCitizenship { set; get; }
        public int? EducationCategory { set; get; }
        public int? EducationGroup { set; get; }
        public int? EducationSpl { set; get; }
        public string EducationDetails { set; get; }
        public int? EmployeeIN { set; get; }
        public int? ProfessionGroup { set; get; }
        public int? Profession { set; get; }
        public string CompanyName { set; get; }
        public string OccupationDetails { set; get; }
        public int? AnnualIncome { set; get; }
        public int? Currency { set; get; }
        public string Salary { set; get; }
        public int? CountryLivingIn { set; get; }
        public int? StateLivingIn { set; get; }
        public int? DistictLivingIn { set; get; }
        public int? CityLivingIN { set; get; }
        public string Cityother { set; get; }
        public int? VisaStatus { set; get; }
        public DateTime? ResidingSince { set; get; }
        public string FatherName { set; get; }
        public int? FatherEducation { set; get; }
        public int? FastherProfession { set; get; }
        public string FatherNative { set; get; }
        public string MotherName { set; get; }
        public int? MotherEducation { set; get; }
        public int? MotherProfession { set; get; }
        public string MotherNative { set; get; }
        public int? NOofbrother { set; get; }
        public int? NOofSisters { set; get; }
        public string AboutYourself { set; get; }
        public string fathereducationdetails { set; get; }
        public string fatherProfessiondetails { set; get; }
        public string mothereducationdetails { set; get; }
        public string motherProfessiondetails { set; get; }
        public int? FatherMobileCountryCode { set; get; }
        public string FatherMobileNumber { set; get; }
        public int? MotherMobileCountryCode { set; get; }
        public string MotherMobileNumber { set; get; }
    }
}