using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WebapiApplication.ML
{
    //EducationML
    public class UpdateEducationdetailsML
    {

        public Int64? intCusID { set; get; }
        public Int32? intEduID { set; get; }
        public string EducationCategory { set; get; }
        public string EducationGroup { set; get; }
        public string EducationSpecialization { set; get; }
        public string EduUniversity { set; get; }
        public string EduCollege { set; get; }
        public string EduCountryIn { set; get; }
        public string EduStateIn { set; get; }
        public string EduDistrictIn { set; get; }
        public string EduCityIn { set; get; }
        public string EduPassOfYear { set; get; }
        public Int32? EduHighestDegree { set; get; }
        public Int64? EducationID { set; get; }
        public string Educationdesc { set; get; }
        public int? EducationCategoryID { set; get; }
        public int? EducationGroupID { set; get; }
        public int? EducationSpecializationID { set; get; }
        public int? CountryID { set; get; }
        public int? StateID { set; get; }
        public int? DistrictID { set; get; }
        public int? CityID { set; get; }
        public bool? reviewstatus { set; get; }
        public DataTable dtEducationdetails { get; set; }
        public int? EmpID { get; set; }
        public int? Admin { get; set; }
        public string EmpLastModificationDate { get; set; }
        public int? ProfileGradestatus { get; set; }
        public int? ProfileGrade { get; set; }
    }

    //ProfessionML
    public class UpdateProfessionML
    {
        public Int64? intCusID { set; get; }
        public int? iProfID { set; get; }
        public string ProfessionCategory { get; set; }
        public string ProfessionGroup { get; set; }
        public string Professional { get; set; }
        public string IsCurrentEmployeer { get; set; }
        public string WorkingFromDate { get; set; }
        public string WorkingToDate { get; set; }
        public string CountryWorkingIn { get; set; }
        public string StateWorkingIn { get; set; }
        public string DistrictWorkingIn { get; set; }
        public string CityWorkingIn { get; set; }
        public string OccupationDetails { get; set; }
        public string Income { get; set; }
        public string Currency { get; set; }
        public string Salary { get; set; }
        public string CurrentProfession { get; set; }
        public string ResidingSince { get; set; }
        public string ArrivingDate { get; set; }
        public string DepartureDate { get; set; }
        public string CompanyName { get; set; }
        public string VisaStatus { get; set; }
        public DataTable dtProfession { get; set; }
        public string AboutYourself { get; set; }
        public int? profGridID { get; set; }
        public int? ProfessionCategoryID { get; set; }
        public int? ProfessionGroupID { get; set; }
        public int? ProfessionID { get; set; }
        public int? CountryID { get; set; }
        public int? StateID { get; set; }
        public int? DistrictID { get; set; }
        public int? CityID { get; set; }
        public int? SalaryCurrency { get; set; }
        public int? VisaTypeID { get; set; }
        public Int64? Cust_Profession_ID { get; set; }
        public bool? reviewstatus { set; get; }

        public Int64? EmpID { get; set; }

        public Int64? Admin { get; set; }

        public string EmpLastModificationDate { get; set; }
    }

    //Table Formate
    public class CutomerEducationdetails
    {
        public long? CustID { get; set; }
        public int? Educationcategory { get; set; }
        public int? Educationgroup { get; set; }
        public int? Educationspecialization { get; set; }
        public string University { get; set; }
        public string College { get; set; }
        public long? Passofyear { get; set; }
        public int? Countrystudyin { get; set; }
        public int? Statestudyin { get; set; }
        public int? Districtstudyin { get; set; }
        public int? CitystudyIn { get; set; }
        public string OtherCity { get; set; }
        public int? Highestdegree { get; set; }
        public string Educationalmerits { get; set; }
        public int? Cust_Education_ID { get; set; }
        public int? intEduID { get; set; }
    }
    public class CutomerProfessiondetails
    {
        public long? CustID { get; set; }
        public int? EmployedIn { get; set; }
        public int? Professionalgroup { get; set; }
        public int? Profession { get; set; }
        public string Companyname { get; set; }
        public int? Currency { get; set; }
        public string Monthlysalary { get; set; }
        public int? CountryID { get; set; }
        public int? StateID { get; set; }
        public int? DistrictID { get; set; }
        public int? CityID { get; set; }
        public string OtherCity { get; set; }
        public DateTime? Workingfromdate { get; set; }
        public string OccupationDetails { get; set; }
        public string visastatus { get; set; }
        public DateTime? Sincedate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public DateTime? DepartureDate { get; set; }
        public int? profGridID { get; set; }
        public int? ProfessionID { get; set; }
    }

    public class TCustomerParentsDetails
    {
        public long? CustID { get; set; }
        public string FatherName { get; set; }
        public int? Educationcategory { get; set; }
        public int? Educationgroup { get; set; }
        public int? Educationspecialization { get; set; }
        public int? Employedin { get; set; }
        public int? Professiongroup { get; set; }
        public int? Profession { get; set; }
        public string CompanyName { get; set; }
        public string JobLocation { get; set; }
        public string Professiondetails { get; set; }
        public int? MobileCountry { get; set; }
        public string MobileNumber { get; set; }
        public int? LandlineCountry { get; set; }
        public string LandAreCode { get; set; }
        public string landLineNumber { get; set; }
        public string Email { get; set; }
        public string FatherFatherName { get; set; }
        public string MotherName { get; set; }
        public int? MotherEducationcategory { get; set; }
        public int? MotherEducationgroup { get; set; }
        public int? MotherEducationspecialization { get; set; }
        public int? MotherEmployedIn { get; set; }
        public int? MotherProfessiongroup { get; set; }
        public int? MotherProfession { get; set; }
        public string MotherCompanyName { get; set; }
        public string MotherJobLocation { get; set; }
        public string MotherProfessiondetails { get; set; }
        public int? MotherMobileCountryID { get; set; }
        public string MotherMobileNumber { get; set; }
        public int? MotherLandCountryID { get; set; }
        public string MotherLandAreaCode { get; set; }
        public string MotherLandNumber { get; set; }
        public string MotherEmail { get; set; }
        public string MotherFatherFistname { get; set; }
        public string MotherFatherLastname { get; set; }
        public long? FatherCustFamilyID { get; set; }
        public long? MotherCustFamilyID { get; set; }
        public string FatherEducationDetails { get; set; }
        public string MotherEducationDetails { get; set; }
        public int? FatherCountry { get; set; }
        public int? FatherState { get; set; }
        public int? FatherDistric { get; set; }
        public string FatherCity { get; set; }
        public int? MotherCountry { get; set; }
        public int? MotherState { get; set; }
        public int? MotherDistric { get; set; }
        public string MotherCity { get; set; }
        public int? AreParentsInterCaste { get; set; }
        public int? FatherfatherMobileCountryID { get; set; }
        public string FatherFatherMobileNumber { get; set; }
        public int? FatherFatherLandCountryID { get; set; }
        public string FatherFatherLandAreaCode { get; set; }
        public string FatherFatherLandNumber { get; set; }
        public int? MotherfatherMobileCountryID { get; set; }
        public string MotherFatherMobileNumber { get; set; }
        public int? MotherFatherLandCountryID { get; set; }
        public string MotherFatherLandAreaCode { get; set; }
        public string MotherFatherLandNumber { get; set; }
        public int? MotherCaste { get; set; }
        public int? FatherCaste { get; set; }

        public int? FatherProfessionCategoryID { get; set; }
        public int? MotherProfessionCategoryID { get; set; }
    }



    public class TCustomerContactAddress
    {
        public long? CustID { get; set; }
        public string HouseFlateNumber { get; set; }
        public string Apartmentname { get; set; }
        public string Streetname { get; set; }
        public string AreaName { get; set; }
        public string Landmark { get; set; }
        public int? Country { get; set; }
        public int? STATE { get; set; }
        public int? District { get; set; }
        public string city { get; set; }
        public string othercity { get; set; }
        public string ZipPin { get; set; }
        public long? Cust_Family_ID { get; set; }
    }

    public class TCustomerPhysicalAttributes
    {
        public long? CustID { get; set; }
        public string BWKgs { get; set; }
        public string BWlbs { get; set; }
        public string BloodGroup { get; set; }
        public string HealthConditions { get; set; }
        public string HealthConditiondesc { get; set; }
        public int? DietID { get; set; }
        public int? SmokeID { get; set; }
        public int? DrinkID { get; set; }
        public int? BodyTypeID { get; set; }

    }

    public class TCustomerPartnerPreferences
    {
        public long? CustID { get; set; }
        public int? AgeGapFrom { get; set; }
        public int? AgeGapTo { get; set; }
        public int? HeightFrom { get; set; }
        public int? HeightTo { get; set; }
        public string Religion { get; set; }
        public string Mothertongue { get; set; }
        public string Caste { get; set; }
        public string Subcaste { get; set; }
        public string Maritalstatus { get; set; }
        public string ManglikKujadosham { get; set; }
        public string PreferredstarLanguage { get; set; }
        public string Educationcategory { get; set; }
        public string Educationgroup { get; set; }
        public string Employedin { get; set; }
        public string Professiongroup { get; set; }
        public string Diet { get; set; }
        public string Preferredcountry { get; set; }
        public string Preferredstate { get; set; }
        public string Preferreddistrict { get; set; }
        public string Preferredlocation { get; set; }
        public int? TypeofStar { get; set; }
        public string PrefredStars { get; set; }
        public int? GenderID { get; set; }
        public string Region { get; set; }
        public string Branch { get; set; }
    }
    public class TSibBrother
    {
        public long? CustID { set; get; }
        public string BroName { set; get; }
        public int? BroElderYounger { set; get; }
        public int? BroEducationcategory { set; get; }
        public int? BroEducationgroup { set; get; }
        public int? BroEducationspecialization { set; get; }
        public int? BroEmployedin { set; get; }
        public int? BroProfessiongroup { set; get; }
        public int? BroProfession { set; get; }
        public string BroCompanyName { set; get; }
        public string BroJobLocation { set; get; }
        public int? BroMobileCountryCodeID { set; get; }
        public string BroMobileNumber { set; get; }
        public int? BroLandCountryCodeID { set; get; }
        public string BroLandAreaCode { set; get; }
        public string BroLandNumber { set; get; }
        public string BroEmail { set; get; }
        public int? BIsMarried { set; get; }
        public string BroWifeName { set; get; }
        public int? BroWifeEducationcategory { set; get; }
        public int? BroWifeEducationgroup { set; get; }
        public int? BroWifeEducationspecialization { set; get; }
        public int? BroWifeEmployedin { set; get; }
        public int? BroWifeProfessiongroup { set; get; }
        public int? BroWifeProfession { set; get; }
        public string BroWifeCompanyName { set; get; }
        public string BroWifeJobLocation { set; get; }
        public int? BroWifeMobileCountryCodeID { set; get; }
        public string BroWifeMobileNumber { set; get; }
        public int? BroWifeLandCountryCodeID { set; get; }
        public string BroWifeLandAreacode { set; get; }
        public string BroWifeLandNumber { set; get; }
        public string BroWifeFatherSurName { set; get; }
        public string BroWifeFatherName { set; get; }
        public string BroSibilingCustfamilyID { set; get; }
        public string BroEducationDetails { set; get; }
        public string BrowifeEducationDetails { set; get; }
        public string BroProfessionDetails { set; get; }
        public string BroWifeProfessionDetails { set; get; }
        public int? BroSpouseFatherCountryID { set; get; }
        public int? BroSpouseFatherStateID { set; get; }
        public int? BroSpouseFatherDitrictID { set; get; }
        public string BroSpouseFatherNativePlace { set; get; }
        public string BrotherSpouseEmail { set; get; }
        public int? SibilingSpouseFatherCasteID { set; get; }

        public int? BroProfessionCategoryID { set; get; }
        public int? BroSpouseProfessionCategoryID { set; get; }
        public string BroSpouseFatherEmailID { set; get; }
        public int? BroSpouseFatherMobileCountryID { set; get; }
        public string BroSpouseFatherMobileNo { set; get; }
        public int? BroSpouseFatherLandCountryID { set; get; }
        public string BroSpouseFatherLandAreaCode { set; get; }
        public string BroSpouseFatherLandNo { set; get; }
        public int? BornOrder { set; get; }

    }


    public class TsibSister
    {
        public long? CustID { set; get; }
        public string SisName { set; get; }
        public int? SisElderYounger { set; get; }
        public int? SisEducationcategory { set; get; }
        public int? SisEducationgroup { set; get; }
        public int? SisEducationspecialization { set; get; }
        public int? SisEmployedin { set; get; }
        public int? SisProfessiongroup { set; get; }
        public int? SisProfession { set; get; }
        public string SisCompanyName { set; get; }
        public string SisJobLocation { set; get; }
        public int? SisMobileCountryCodeID { set; get; }
        public string SisMobileNumber { set; get; }
        public int? SisLandCountryCodeID { set; get; }
        public string SisLandAreaCode { set; get; }
        public string SisLandNumber { set; get; }
        public string SisEmail { set; get; }
        public int? SIsMarried { set; get; }
        public string SisHusbandName { set; get; }
        public int? SisHusbandEducationcategory { set; get; }
        public int? SisHusbandEducationgroup { set; get; }
        public int? SisHusbandEducationspecialization { set; get; }
        public int? SisHusbandEmployedin { set; get; }
        public int? SisHusbandProfessiongroup { set; get; }
        public int? SisHusbandProfession { set; get; }
        public string SisHusCompanyName { set; get; }
        public string SisHusJobLocation { set; get; }
        public int? SisHusbandMobileCountryCodeID { set; get; }
        public string SisHusbandMobileNumber { set; get; }
        public int? SisHusbandLandCountryCodeID { set; get; }
        public string SisHusbandLandAreacode { set; get; }
        public string SisHusbandLandNumber { set; get; }
        public string SisHusbandFatherSurName { set; get; }
        public string SisHusbandFatherName { set; get; }
        public string SisSibilingCustfamilyID { set; get; }
        public string siseducationdetails { set; get; }
        public string sisprofessiondetails { set; get; }
        public string sisspouseeducationdetails { set; get; }
        public string sisspouseprofessiondetails { set; get; }
        public int? SisSpouseFatherCountryID { set; get; }
        public int? SisSpouseFatherStateID { set; get; }
        public int? SisSpouseFatherDitrictID { set; get; }
        public string SisSpouseFatherNativePlace { set; get; }
        public string SisSpouseEmail { set; get; }
        public int? SibilingSpouseFatherCasteID { set; get; }
        public int? SisProfessionCategoryID { set; get; }
        public int? SisSpouseProfessionCategoryID { set; get; }
        public string SisSpouseFatherEmailID { set; get; }
        public int? SisSpouseFatherMobileCountryID { set; get; }
        public string SisSpouseFatherMobileNo { set; get; }
        public int? SisSpouseFatherLandCountryID { set; get; }
        public string SisSpouseFatherLandAreaCode { set; get; }
        public string SisSpouseFatherLandNo { set; get; }
        public int? BornOrder { set; get; }
    }

    public class TSpouseDetailsUpdate
    {
        public long? CustID { get; set; }
        public string NAME { get; set; }
        public string Education { get; set; }
        public string Profession { get; set; }
        public string HouseFlatnumber { get; set; }
        public string Apartmentname { get; set; }
        public string Streetname { get; set; }
        public string Areaname { get; set; }
        public string Landmark { get; set; }
        public string Country { get; set; }
        public string STATE { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Marriedon { get; set; }
        public string Separateddate { get; set; }
        public string Legallydivorced { get; set; }
        public string Dateoflegaldivorce { get; set; }
        public string Uploaddivorcedocument { get; set; }
        public string Fatherfirstname { get; set; }
        public string Fatherlastname { get; set; }
        public string Notesaboutpreviousmarriage { get; set; }
        public string Familyplanning { get; set; }
        public string Noofchildren { get; set; }
        public long? Cust_Spouse_ID { get; set; }
    }

    public class TSpouseChildDetailsUpdate
    {
        public long? CustID { get; set; }
        public string Nameofthechild { get; set; }
        public string Genderofthechild { get; set; }
        public string DOB { get; set; }
        public string Childstayingwith { get; set; }
        public string Childstayingwithrelation { get; set; }
        public long? Cust_Children_ID { get; set; }
    }

    public class TpersonalDetailsUpdate
    {

        public int? CustID { get; set; }
        public string MaritalStatusID { get; set; }
        public DateTime? DateofBirth { get; set; }
        public int? HeightID { get; set; }
        public int? ComplexionID { get; set; }
        public int? ReligionID { get; set; }
        public int? MotherTongueID { get; set; }
        public int? CasteID { get; set; }
        public int? CitizenshipID { get; set; }
        public int? SubcasteID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int? Gender { get; set; }
        public int? PhysicallyChallenged { get; set; }
    }


    public class TeditAstro
    {
        public long? CustID { set; get; }
        public string TimeofBirth { set; get; }
        public int? CountryOfBirthID { set; get; }
        public int? StateOfBirthID { set; get; }
        public int? DistrictOfBirthID { set; get; }
        public int? CityOfBirthID { set; get; }
        public int? Starlanguage { set; get; }
        public int? Star { set; get; }
        public int? Paadam { set; get; }
        public int? Lagnam { set; get; }
        public int? RasiMoonsign { set; get; }
        public string GothramGotra { set; get; }
        public string Maternalgothram { set; get; }
        public int? ManglikKujadosham { set; get; }
        public string Pblongitude { set; get; }
        public string pblatitude { set; get; }
        public string TimeZone { set; get; }
    }
    public class TeditProperty
    {
        public int? FamilyStatus { set; get; }
        public int? Issharedproperty { set; get; }
        public int? Valueofproperty { set; get; }
        public int? PropertyType { set; get; }
        public string Propertydescription { set; get; }
        public int? Showingviewprofile { set; get; }
        public int? Custpropertyid { set; get; }
        public int? PropertyID { set; get; }
        public long? CustId { set; get; }
    }
    public class TeditFB
    {
        public long? CustID { set; get; }
        public string Fatherbrothername { set; get; }
        public int? FBElderYounger { set; get; }
        public int? FBEmployedin { set; get; }
        public int? FBProfessiongroup { set; get; }
        public int? FBProfession { set; get; }
        public string FBProfessiondetails { set; get; }
        public int? FBMobileCountryID { set; get; }
        public string FBMobileNumber { set; get; }
        public int? FBLandLineCountryID { set; get; }
        public string FBLandAreaCode { set; get; }
        public string FBLandNumber { set; get; }
        public string FBEmails { set; get; }
        public string FBCurrentLocation { set; get; }
        public long? FatherbrotherCust_familyID { set; get; }
        public string FatherBrotherEducationDetails { set; get; }
        public int? BornOrder { set; get; }
    }


    public class TeditFS
    {
        public long? CustID { set; get; }
        public string FSFathersistername { set; get; }
        public int? FSElderYounger { set; get; }
        public string FSHusbandfirstname { set; get; }
        public string FSHusbandlastname { set; get; }
        public int? FSCountryID { set; get; }
        public int? FSHStateID { set; get; }
        public int? FSHDistrict { set; get; }
        public string FSNativeplace { set; get; }
        public int? FSHEmployedin { set; get; }
        public int? FSHProfessiongroup { set; get; }
        public int? FSHProfession { set; get; }
        public string FSHProfessiondetails { set; get; }
        public int? FSHMobileCountryID { set; get; }
        public string FSHMObileNumber { set; get; }
        public int? FSHLandCountryID { set; get; }
        public string FSHLandAreaCode { set; get; }
        public string FSHLandNumber { set; get; }
        public string FSHEmails { set; get; }
        public string FSCurrentLocation { set; get; }
        public long? FatherSisterCust_familyID { set; get; }
        public string FSHEducationdetails { set; get; }
        public int? BornOrder { set; get; }
    }
    public class TeditMB
    {
        public long? CustID { set; get; }
        public string Motherbrothername { set; get; }
        public int? MBElderYounger { set; get; }
        public int? MBEmployedin { set; get; }
        public int? MBProfessiongroup { set; get; }
        public int? MBProfession { set; get; }
        public string MBProfessiondetails { set; get; }
        public int? MBMobileCountryID { set; get; }
        public string MBMObileNumber { set; get; }
        public int? MBLandLineCountryID { set; get; }
        public string MBLandAreaCode { set; get; }
        public string MBLandNumber { set; get; }
        public string MBEmails { set; get; }
        public string MBCurrentLocation { set; get; }
        public long? MBMotherBrotherCust_familyID { set; get; }
        public string MBEducationdetails { set; get; }
        public int? BornOrder { set; get; }
    }
    public class TeditMS
    {
        public long? CustID { set; get; }
        public string Mothersistername { set; get; }
        public int? MSElderYounger { set; get; }
        public string MSHusbandfirstname { set; get; }
        public string MSHusbandlastname { set; get; }
        public int? MSCountryID { set; get; }
        public int? MSMSHStateID { set; get; }
        public int? MSMSHDistrictID { set; get; }
        public string MSNativeplace { set; get; }
        public int? MSEmployedin { set; get; }
        public int? MSProfession { set; get; }
        public string MSProfessiondetails { set; get; }
        public int? MSMSHMobileCountryID { set; get; }
        public string MSMObileNumber { set; get; }
        public int? MSHLandlineCountryID { set; get; }
        public string MSLandAreaCode { set; get; }
        public string MSLandNumber { set; get; }
        public string MSHEmails { set; get; }
        public string MSCurrentLocation { set; get; }
        public long? MSCust_familyID { set; get; }
        public string MSEducationdetails { set; get; }
        public int? BornOrder { set; get; }
    }
    public class TeditReference
    {
        public long? CustID { set; get; }
        public int? RelationshiptypeID { set; get; }
        public string Firstname { set; get; }
        public string Lastname { set; get; }
        public int? Employedin { set; get; }
        public int? Professiongroup { set; get; }
        public int? Profession { set; get; }
        public string Professiondetails { set; get; }
        public int? CountryID { set; get; }
        public int? StateID { set; get; }
        public int? DistrictID { set; get; }
        public string Nativeplace { set; get; }
        public string Presentlocation { set; get; }
        public int? MobileCountryID { set; get; }
        public string MobileNumber { set; get; }
        public int? LandLineCountryID { set; get; }
        public string LandLineAreaCode { set; get; }
        public string LandLineNumber { set; get; }
        public string Emails { set; get; }
        public string Narration { set; get; }
        public string Cust_Reference_ID { set; get; }
    }

    public class TuploadPhoto
    {
        public int? ID { get; set; }
        public string url { get; set; }
        public int? order { get; set; }
        public int? IsProfilePic { get; set; }
        public int? DisplayStatus { get; set; }
        public string Password { get; set; }
        public int? IsReviewed { get; set; }
        public string TempImageUrl { get; set; }
        public int? IsTempActive { get; set; }
        public string DeletedImageurl { get; set; }
        public int? IsImageDeleted { get; set; }
        public int? PhotoStatus { get; set; }
        public int? PhotoID { get; set; }
        public string PhotoPassword { get; set; }
    }

    public class GenerateHoroML
    {
        public string EmpIDQueryString { set; get; }
        public Int64? customerid { get; set; }
        public int strGender { get; set; }
        public string strName { get; set; }
        public int intDay { get; set; }
        public int intMonth { get; set; }
        public int intYear { get; set; }
        public int strcityid { get; set; }
        public string cityName { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string strTime { get; set; }
        public string oldcityname { get; set; }
        public const string fullpath = "http://localhost:7000/showHoro";
        public const string str = "http://www.astrovisiononline.com/avservices/singlepagehoro/inserttolsdb_v3.php?data=<DATA><BIRTHDATA><CUSTID>";

        public int? CityOfBirthID { get; set; }
        public DateTime? TimeOfBirth { get; set; }
        public string Longitude { get; set; }
        public int? GenderID { get; set; }
        public string CityName { get; set; }
        public string Latitude { get; set; }
    }
    public class PhotoSectionMl
    {
        public string PhotoName { get; set; }
        public string PhotoPassword { get; set; }
        public int? VisibleToID { get; set; }
        public int? DisplayOrder { get; set; }
        public Int64? UploadedByEmpID { get; set; }
        public string UploadedDate { get; set; }
        public string ModifiedDate { get; set; }
        public Int64? Cust_ID { get; set; }
        public Int64? Cust_Photos_ID { get; set; }
        public string strModifiedByEmpID { get; set; }
        public string UploadedBy { get; set; }
        public Int32? IsThumbNailCreated { get; set; }
        public int? IsMain { get; set; }
        public int? IsActive { get; set; }
        public int? AssignedTo { get; set; }
        public string AssignedDate { get; set; }
        public int? IsReviewed { get; set; }
        public string ProfileID { get; set; }
        public int? PhotoStatus { get; set; }
        public int? GenderID { get; set; }
    }

    //public class UploadInsertSelect
    //{

    //    public string Cust_ID { set; get; }
    //    public string PhotoName { set; get; }
    //    public string PhotoPassword { set; get; }
    //    public int? VisibleToID { set; get; }
    //    public int? DisplayOrder { set; get; }
    //    public Int64? UploadedByEmpID { set; get; }
    //    public DateTime? UploadedDate { set; get; }
    //    public DateTime? ModifiedDate { set; get; }
    //    public bool? IsMain { set; get; }
    //    public bool? IsActive { set; get; }
    //    public bool? PhotoStatus { set; get; }
    //    public Int64? AssignedTo { set; get; }
    //    public DateTime? AssignedDate { set; get; }
    //    public int? IsReviewed { set; get; }
    //    public Int64? ProfileID { set; get; }
    //    public int? IsThumbNailCreated { set; get; }
    //    public Int64? Cust_Photos_ID { set; get; }
    //    public int? ModifiedByEmpID { set; get; }
    //    public int? UploadedBy { set; get; }

    //}


    public class SibblingCounts
    {
        public string CustID { set; get; }
        public int? NoOfBrothers { get; set; }
        public int? NoOfSisters { get; set; }
        public int? NoOfYoungerBrothers { get; set; }
        public int? NoOfElderBrothers { get; set; }
        public int? NoOfElderSisters { get; set; }
        public int? NoOfYoungerSisters { get; set; }
        public int? i_flag { get; set; }
    }


    // Side menu 

    public class CustomerPersonalDetails
    {
        public Int64? Cust_ID { set; get; }
        public string ProfileID { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Name { set; get; }
        public string Borncountry { set; get; }
        public int? Age { set; get; }
        public string DateofBirth { set; get; }
        public string Caste { set; get; }
        public string SubCaste { set; get; }
        public string Religion { set; get; }
        public string Complexion { set; get; }
        public string Height { set; get; }
        public int? IsBornCountry { set; get; }
        public string MartialStatus { set; get; }
        public string Mothertongue { set; get; }

        public int? ProfileStatusID { set; get; }
        public int? HeightInCentimeters { set; get; }
        public int? ComplexionID { set; get; }
        public int? CountryID { set; get; }
        public DateTime? DateOfBirth { set; get; }
        public int? SubCasteID { set; get; }
        public int? CasteID { set; get; }
        public int? ReligionID { set; get; }
        public int? MaritalStatusID { set; get; }
        public DataTable dtpersonalDetails { get; set; }
        public int? Admin { get; set; }
        public Int64? EmpID { get; set; }
        public Int64? intCusID { get; set; }
        public string ProfilePic { get; set; }
        public int? GenderID { get; set; }
        public long? ProfileOwner { get; set; }
        public int? PaidStatus { get; set; }
    }

    public class ViewAllCustomersSearch
    {


        public string Cust_ID { get; set; }

        public string ProfileID { get; set; }

        public string KMPLID { get; set; }

        public int? paid { get; set; }

        public bool IsConfidential { get; set; }

        public bool SuperConfidentila { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Caste { get; set; }

        public int? ProfileGrade { get; set; }

        public int? TotalRows { get; set; }
        public string SRCount { get; set; }

        public string ExpiryDate { get; set; }

        public string Points { get; set; }

        public bool CNumberVerStatus { get; set; }

        public bool CEmailVerStatus { get; set; }

        public string SAForm { get; set; }

        public string TicketID { get; set; }

        public int? MatchMeetingCount { get; set; }

        public int? CountryCodeID { get; set; }

        public string Reason4InActive { get; set; }

        public string mothertongue { get; set; }

        public int? PhotoCount { get; set; }

        public string CreatedDate { get; set; }

        public long? Cust_Family_ID { get; set; }

        public string Gender { get; set; }

        public string SubCaste { get; set; }

        public string Photo { get; set; }

        public string PhotoNames { get; set; }

        public bool Ownerflag { get; set; }

        public string RegistrationDate { get; set; }

        public int? UploadedPhotoscount { get; set; }

        public int? PhotoshopCount { get; set; }

        public string OwnerName { get; set; }

        public int? HoroscopeStatus { get; set; }

        public long? Emp_Ticket_ID { get; set; }

        public string ProfileOwnername { get; set; }

        public string EmpUserName { get; set; }

        public string Primaryemail { get; set; }

        public string Primarynumber { get; set; }

        public string HoroScopeImage { get; set; }

        public string ApplicationPhotoPath { get; set; }

        public string LastLoginDate { get; set; }

        public string PaidAmount { get; set; }

        public string DOR { get; set; }
    }
    public class ViewAllCustomersSearchnew
    {
        public long? CustID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CasteName { get; set; }

        public string ProfileOwner { get; set; }

        public string Height { get; set; }

        public string LoginStatus { get; set; }

        public string educationgroup { get; set; }

        public string Age { get; set; }

        public int? GenderID { get; set; }

        public int? ProfileStatusID { get; set; }

        public string Confidential { get; set; }

        public string ProfileID { get; set; }

        public int? TotalRows { get; set; }

        public int? Totalpages { get; set; }

        public string Profession { get; set; }
    }
    public class ViewAllCustomersSearchtable
    {

        public long? CustID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CasteName { get; set; }

        public string ProfileOwner { get; set; }

        public string Height { get; set; }

        public string LoginStatus { get; set; }

        public string educationgroup { get; set; }

        public string Age { get; set; }

        public int? GenderID { get; set; }

        public int? ProfileStatusID { get; set; }

        public string Confidential { get; set; }

        public string ProfileID { get; set; }

        public int? TotalRows { get; set; }
        public string Profession { get; set; }

        public int? PaidSatus { get; set; }

        public long? ProfileOwnerID { get; set; }
    }
    public class ProfilePaymentGridView
    {
        public string ProfileID { get; set; }
        public string Type { get; set; }
        public string membershiptype { get; set; }
        public decimal? AgreedAmount { get; set; }
        public decimal? PaidAmount { get; set; }
        public string PaymentDate { get; set; }
        public string ExpiryDate { get; set; }
        public int? Allowed { get; set; }
        public int? Used { get; set; }
        public string CreatedByEmpID { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string StatusBy { get; set; }
        public int? PaymentID { get; set; }
        public string CustName { get; set; }
        public string ProfileOwner { get; set; }
        public string TaxPaid_Status { get; set; }
        public int? RenewalStatus { get; set; }
        public int? PaymentHist_ID { get; set; }

        public Int64? CustId { get; set; }
    }

    public class UpdatePersonaldetails
    {
        public long? intCusID { set; get; }
        public long? EmpID { set; get; }
        public long? Admin { set; get; }
        public DataTable dtTableValues { set; get; }
    }

    public class ContactDetals
    {
        public int? CustID { get; set; }
        public int? EmpID { get; set; }
        public int? IsReViewed { get; set; }
        //--------Candidate Contacts---  
        public int? custfamiliyid { get; set; }
        public int? MoblieCountryCode { get; set; }
        public long? MobileNumber { get; set; }
        public int? LandCountryCode { get; set; }
        public long? LandAreaCode { get; set; }
        public long? LandNumber { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        //------------address---------  
        public string CandidateAddressID { get; set; }
        public string HouseFlatNum { get; set; }
        public string Apartmentname { get; set; }
        public string Streetname { get; set; }
        public string AreaName { get; set; }
        public string Landmark { get; set; }
        public int? Country { get; set; }
        public int? State { get; set; }
        public int? District { get; set; }
        public string City { get; set; }
        public long? ZipPin { get; set; }
        public int? addresstype { get; set; }
        public int? Status { get; set; }
        public string spouseflag { get; set; }
        public int? intCusID { get; set; }
        public int? Admin { get; set; }
        public int? familyID { get; set; }
        public string SibblingFlag { get; set; }
        public int? iflagFF { get; set; }
        public long? FFLandNumber { get; set; }
        public long? FFLandAreaCode { get; set; }
        public int? FFLandLineCountryCodeID { get; set; }
        public long? FFMobileNumber { get; set; }
        public int? FFMobileCountryID { get; set; }
    }

    public class NoProfileGradingMl
    {
        public int? GFamily { get; set; }
        public int? GPhotos { get; set; }
        public int? GEducation { get; set; }
        public int? GProfession { get; set; }
        public int? GProperty { get; set; }
        public Int64 CustID { get; set; }
        public Int64? EmpID { get; set; }
    }

    public class UpdateprofileeMl
    {
        public Int32? intCusID { set; get; }
        public Int64? Profilid { set; get; }
        public long? EmpID { get; set; }
        public long? Admin { get; set; }
        public int? currentprofilestatusid { get; set; }
        public int? profilegrade { get; set; }
        public int? NoofDaysinactivated { get; set; }
        public string Reason4InActive { get; set; }
        public int? RequestedBy { set; get; }
        public string TypeofReport { set; get; }
        public int? ProfileDisplayName { get; set; }
        public int? LoginStatusName { get; set; }
        public string Blockedreason { set; get; }
    }

    public class ContactdetailsRef
    {
        public long? Cust_Reference_ID { set; get; }
        public long? Cust_ID { set; get; }
        public string FirstName { set; get; }
        public string MobileCode { set; get; }
        public string Number { set; get; }
        public string CountryCode { set; get; }
        public string AreaCode { set; get; }
        public string Landlinenumber { set; get; }
        public string Email { set; get; }

    }
    public class NoDataFoundDisplay
    {
        public string ProfileID { set; get; }
        public string CustID { set; get; }
        public int? iCustomerPersonalDetails { set; get; }
        public int? iManagePhoto { set; get; }
        public int? iParentDetails { set; get; }
        public int? iPartnerPreference { set; get; }
        public int? iSiblingDetails { set; get; }
        public int? iAstroDetails { set; get; }
        public int? iPropertyDetails { set; get; }
        public int? iRelativeDetails { set; get; }
        public int? iReferenceDetails { set; get; }
        public string LoginStatusID { set; get; }

    }



    public class EmployeeLandingCount
    {

        public DataTable owner { set; get; }
        public DataTable Branch { set; get; }
        public string strTableType { get; set; }
        public int? StartIndex { get; set; }
        public int? EndIndex { get; set; }
        public int? intLoadStatus { get; set; }

    }


    public class AstroUploadDelete
    {
        public Int64? Cust_ID { set; get; }
        public string Horopath { set; get; }
        public int? ModifiedByEmpID { set; get; }
        public int? VisibleToID { set; get; }
        public int? Empid { set; get; }
        public bool? IsActive { set; get; }
        public int? i_flag { set; get; }
    }


    //partner preferences
    public class UpdatePartnerML
    {
        public Int64? intCusID { set; get; }
        public string Gender { set; get; }
        public string AgeGap { set; get; }
        public string Height { set; get; }
        public string Mothertongue { set; get; }
        public string Religion { set; get; }
        public string Caste { set; get; }
        public string Subcaste { set; get; }
        public string MaritalStatus { set; get; }
        public string EducationGroup { set; get; }
        public string Profession { set; get; }
        public string Kujadosham { set; get; }
        public string StarLanguage { set; get; }
        public string Stars { set; get; }
        public string Diet { set; get; }
        public string CountryName { set; get; }
        public string StateName { set; get; }
        public string EducationCategory { set; get; }
        public string EducationSpecilization { set; get; }
        public string professionCategory { set; get; }
        public string ProfessionGroup { set; get; }
        public string TypeOfStar { set; get; }
        public string MotherTongueID { set; get; }
        public string religionid { set; get; }
        public string casteid { set; get; }
        public string subcasteid { set; get; }
        public string maritalstatusid { set; get; }
        public string complexionid { set; get; }
        public string EducationCategoryID { set; get; }
        public string EducationGroupID { set; get; }
        public string EduSpecializationID { set; get; }
        public string ProfessionCategoryID { set; get; }
        public string ProfessionGroupID { set; get; }
        public string diet { set; get; }
        public string PreferredStars { set; get; }
        public string CountryID { set; get; }
        public string StateID { set; get; }
        public int? Agemin { set; get; }
        public int? AgeMax { set; get; }
        public string MinHeight { set; get; }
        public string MaxHeight { set; get; }
        public int? ProfessionID { set; get; }
        public int? StarLanguageID { set; get; }
        public object dtPartnerPreferences { get; set; }
        public string DistrictID { set; get; }
        public string LocationPrefPlace { set; get; }
        public int? KujaDoshamID { set; get; }
        public string DietID { set; get; }
        public string PartnerDescripition { set; get; }
        public int? EmpID { get; set; }
        public DataTable dtPartnerPreference { get; set; }
        public int? Admin { get; set; }
        public bool? reviewstatus { get; set; }
        public DataTable dtPartnerPref { get; set; }
        public string regionId { get; set; }
        public string branchid { get; set; }
        public string RegionName { get; set; }
        public string BranchName { get; set; }
        public string EmpLastModificationDate { get; set; }
        public int? CustID { set; get; }


        public int? startindex { get; set; }

        public int? EndIndex { get; set; }
    }


    public class GetPrimaryDataCustomerResponse
    {
        public string GenderID { get; set; }
        public string AgeMin { get; set; }
        public string AgeMax { get; set; }
        public string MinHeight { get; set; }
        public string MaxHeight { get; set; }
        public string maritalstatusid { get; set; }
        public string religionid { get; set; }
        public string MotherTongueID { get; set; }
        public string complexionid { get; set; }
        public string BodyTypeID { get; set; }
        public string casteid { get; set; }
        public string physicalstatusid { get; set; }
        public string EducationCategoryID { get; set; }
        public string EducationGroupID { get; set; }
        public string ProfessionCategoryID { get; set; }
        public string ProfessionGroup { get; set; }
        public string CountryID { get; set; }
        public string StateID { get; set; }
        public string DistrictID { get; set; }
        public string StarLanguageID { get; set; }
        public string PreferredStars { get; set; }
        public string KujaDosham { get; set; }
        public string Drink { get; set; }
        public string Smoke { get; set; }
        public string Diet { get; set; }
        public string PaidFlag { get; set; }
        public string ProfileID { get; set; }
        public string Regions { get; set; }
        public string Branches { get; set; }
        public string Cust_ID { get; set; }
        public string SelfAge { get; set; }
        public string SelfName { get; set; }
        public string Selfheight { get; set; }
        public string SelfEducation { get; set; }
        public string PhotoImageUrl { get; set; }
        public string ApplicationProfilePic { set; get; }
        public string ThumbNailProfilePic { set; get; }

        //added by lakshmi
        public DateTime? MaxDob { get; set; }

        public DateTime? MinDob { get; set; }

        public string Gotram { get; set; }

        public string Surname { get; set; }

        public string SubCasteID { get; set; }
    }

    public class slideshowNew
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
        public string Property { get; set; }
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
        public int? CasteID { get; set; }
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
        public string FTicketStatus { set; get; }
        public string TTicketStatus { set; get; }
    }

    public class EmployeeSearch
    {
        public long? CustID { set; get; }
        public long? EmpID { set; get; }
        public long? Admin { set; get; }
        public DataTable dtTableValues { set; get; }
        public int? startindex { set; get; }
        public int? EndIndex { set; get; }
    }

    public class TGeneralSearch
    {

        public int? CustID { set; get; }
        public int? GenderID { set; get; }
        public string GenderText { set; get; }
        public int? AgeFromID { set; get; }
        public string AgeFromText { set; get; }
        public int? AgeToID { set; get; }
        public string AgeToText { set; get; }
        public int? HeightFromID { set; get; }
        public string HeightFromText { set; get; }
        public int? HeightToID { set; get; }
        public string HeightToText { set; get; }
        public string MaritalstatusID { set; get; }
        public string MaritalstatusText { set; get; }
        public string ReligionID { set; get; }
        public string ReligionText { set; get; }
        public string MothertongueID { set; get; }
        public string MothertongueText { set; get; }
        public string castID { set; get; }
        public string castIDText { set; get; }
        public string CountryID { set; get; }
        public string CountryText { set; get; }
        public string EducationID { set; get; }
        public string EducationText { set; get; }
        public string ProfessionID { set; get; }
        public string ProfessionText { set; get; }
        public string Showinprofile { set; get; }
        public string ShowinprofileText { set; get; }
        public string RegionID { set; get; }
        public string RegionText { set; get; }
        public string BranchID { set; get; }
        public string BranchText { set; get; }
        public string Dateofregfrom { set; get; }
        public string Dateofregto { set; get; }
        public string LastestLoginsfrom { set; get; }
        public string LastestLoginsto { set; get; }
        public string ApplicationstatusID { set; get; }
        public string ApplicationstatusText { set; get; }
        public string PropertyValuefrom { set; get; }
        public string PropertyValueto { set; get; }
        public int? AnnualincomeID { set; get; }
        public string AnnualincomeText { set; get; }
        public string AnnualIncomefrom { set; get; }
        public string AnnualIncometo { set; get; }
        public string ProfileID { set; get; }
        public string SeriousMatch { set; get; }
        public string OnlyConfidential { set; get; }
        public int? slidegride { set; get; }
        public string HoroScopeStatus { set; get; }
        public string DOBfrom { set; get; }
        public string DOBTo { set; get; }
        public string EmpIds { set; get; }
        // public int? ParentInterCaste { set; get; }
        public string SubCasteID { set; get; }
        //08/09/2017 added by lakshmi
        public int? FatherCaste { set; get; }
        public int? MotherCaste { set; get; }
    }

    public class TAdvanceSearch
    {

        public int? CustID { set; get; }
        public int? GenderID { set; get; }
        public string GenderText { set; get; }
        public int? AgeFromID { set; get; }
        public string AgeFromText { set; get; }
        public int? AgeToID { set; get; }
        public string AgeToText { set; get; }
        public int? HeightFromID { set; get; }
        public string HeightFromText { set; get; }
        public int? HeightToID { set; get; }
        public string HeightToText { set; get; }
        public string MaritalstatusID { set; get; }
        public string MaritalstatusText { set; get; }
        public string ReligionID { set; get; }
        public string ReligionText { set; get; }
        public string MothertongueID { set; get; }
        public string MothertongueText { set; get; }
        public string casteID { set; get; }
        public string casteText { set; get; }
        public string CountryID { set; get; }
        public string CountryText { set; get; }
        public string EducationID { set; get; }
        public string EducationText { set; get; }
        public string ProfessionID { set; get; }
        public string ProfessionText { set; get; }
        public string ShowinprofileID { set; get; }
        public string ShowinprofileText { set; get; }
        public string RegionID { set; get; }
        public string RegionText { set; get; }
        public string BranchID { set; get; }
        public string BranchText { set; get; }
        public string Dateofregfrom { set; get; }
        public string Dateofregto { set; get; }
        public string LastestLoginsfrom { set; get; }
        public string LastestLoginsto { set; get; }
        public string ApplicationstatusID { set; get; }
        public string ApplicationstatusText { set; get; }
        public string PropertyValuefrom { set; get; }
        public string PropertyValueto { set; get; }
        public int? AnnualincomeID { set; get; }
        public string AnnualincomeText { set; get; }
        public string AnnualIncomefrom { set; get; }
        public string AnnualIncometo { set; get; }
        public string ProfileID { set; get; }
        public string SeriousMatch { set; get; }
        public string OnlyConfidential { set; get; }
        public int? slidegride { set; get; }
        public string ComplexionID { set; get; }
        public string ComplexionText { set; get; }
        public string bodytypeID { set; get; }
        public string bodytypeText { set; get; }
        public string physicalStatusID { set; get; }
        public string physicalStatusText { set; get; }
        public string EducationCategoryID { set; get; }
        public string EducationCategoryText { set; get; }
        public string EducationGroupID { set; get; }
        public string EducationGroupText { set; get; }
        public string EducationSpecializationID { set; get; }
        public string EducationSpecializationText { set; get; }
        public string University { set; get; }
        public string ProfessionAreaID { set; get; }
        public string ProfessionAreaText { set; get; }
        public string jobCountryID { set; get; }
        public string jobCountryText { set; get; }
        public string StateID { set; get; }
        public string StateText { set; get; }
        public string DistrictID { set; get; }
        public string DistrictText { set; get; }
        public string CityID { set; get; }
        public string CityText { set; get; }
        public string VisaStatusID { set; get; }
        public string VisaStatusText { set; get; }
        public string Arrivaldateto { set; get; }
        public string Departuredatefrom { set; get; }
        public string DeparturedateTo { set; get; }
        public string StarLanguageID { set; get; }
        public string StarLanguageText { set; get; }
        public string StarsID { set; get; }
        public string StarsText { set; get; }
        public string KojadoshamID { set; get; }
        public string KojadoshamText { set; get; }
        public string DrinkID { set; get; }
        public string DrinkText { set; get; }
        public string SmokeID { set; get; }
        public string SmokeText { set; get; }
        public string DietID { set; get; }
        public string DietText { set; get; }
        public string preferedCityID { set; get; }
        public string preferedCityText { set; get; }
        public string MembershipTypeID { set; get; }
        public string MembershipTypeText { set; get; }
        public string WorkingwithID { set; get; }
        public string WorkingwithText { set; get; }
        public string CompanyName { set; get; }
        public string Residingsincefrom { set; get; }
        public string ResidingsinceTo { set; get; }
        public string Arrivaldatefrom { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string PreferedCountryID { set; get; }
        public string PreferedCountryText { set; get; }
        public string PreferedStateID { set; get; }
        public string PreferedStateText { set; get; }
        public string preferedDistrictID { set; get; }
        public string preferedDistrictText { set; get; }
        public string HoroScopeStatus { set; get; }
        public string Status_Photo { set; get; }
        public string Status_Education { set; get; }
        public string Status_Property { set; get; }
        public string Status_Family { set; get; }
        public string Status_Profession { set; get; }

        public string DOBfrom { set; get; }
        public string DOBTo { set; get; }
        public string EmpIds { set; get; }
        // public int? ParentInterCaste { set; get; }

        public string SubCasteID { set; get; }
        //08/09/2017 added by lakshmi
        public int? FatherCaste { set; get; }
        public int? MotherCaste { set; get; }
    }

    //property details
    public class UpdatePropertyML
    {
        public Int64? intCusID { set; get; }
        public string PropertyDetails { set; get; }
        public string isProperty { set; get; }
        public string PropertyType { set; get; }
        public string PropertyvalueType { set; get; }
        public int? PropertyValue { set; get; }
        public string PropertyquantityType { set; get; }
        public int? Propertyquantity { set; get; }
        public int? ProCountry { set; get; }
        public int? ProState { set; get; }
        public int? ProDistrict { set; get; }
        public int? ProCity { set; get; }
        public int? ProShowin { set; get; }
        public int? PropertyID { set; get; }
        public int? Custpropertyid { set; get; }
        public string FamilyStatus { set; get; }
        public int? ProperTypeID { set; get; }
        public int? PropertyValueCurrencyID { set; get; }
        public int? QuantityTypeID { set; get; }
        public int? FamilyValuesID { set; get; }
        public bool? SharedPropertyID { set; get; }
        public bool? ShowInViewProfileID { set; get; }
        public bool? reviewstatus { set; get; }
        public DataTable dtPropertyType { get; set; }
        public int? EmpID { get; set; }
        public int? Admin { get; set; }
        public string EmpLastModificationDate { get; set; }
    }

    //Reference details
    public class UpdateReferenceML
    {
        public Int64? intCusID { set; get; }
        public string Relatioshiptype { set; get; }
        public Int32? ReletionShipTypeID { set; get; }
        public string RefrenceName { set; get; }
        public string RefrenceProfessionCategory { set; get; }
        public string RefrenceProfessionGroup { set; get; }
        public string RefrencePRofessionGroupID { set; get; }
        public string RefrenceProfessionDetails { set; get; }
        public string RefrenceMobileNumberWithcode { get; set; }
        public string RefrenceNativePlace { set; get; }
        public string RefrenceLandNumberwithCode { set; get; }
        public string RefrenceEmail { set; get; }
        public string RefrenceNarration { set; get; }
        public string RefrenceNativePlaceID { set; get; }
        public string RefrenceCityid { set; get; }
        public string RefrenceCity { set; get; }
        public string RefrenceDistrictID { set; get; }
        public string RefrenceStateID { set; get; }
        public string RefrenceCountry { set; get; }
        public string RefrenceLandCountryId { set; get; }
        public string RefrenceAreaCode { set; get; }
        public string RefrenceLandNumber { set; get; }
        public string RefrenceMobileNumberID { set; get; }
        public Int32? RefrenceProessionID { get; set; }
        public string RefenceCurrentLocation { get; set; }
        public Int64? RefrenceCust_Reference_ID { get; set; }
        public string RefrenceMobileCountryID { set; get; }
        public string RefrenceProfessionCategoryID { set; get; }
        public string RefrenceProfession { get; set; }
        public string ReferenceFirstName { get; set; }
        public string ReferenceLastName { get; set; }
        public int? Admin { get; set; }
        public int? EmpID { get; set; }
        public bool? reviewstatus { get; set; }
        public string EmpLastModificationDate { get; set; }
    }

    public class ProfilePlay
    {

        public string Profileid { get; set; }
        public string RegistrationDate { get; set; }
        public string paidamount { get; set; }
        public string paiddate { get; set; }
        public string sentreceivecount { get; set; }
        public int? photocount { get; set; }
        public int? DPD { get; set; }
        public int? lnkView { get; set; }
        public int? notview { get; set; }
        public int? bothinterst { get; set; }
        public int? OppI { get; set; }
        public int? custid { get; set; }
        public string OWNER { get; set; }
        public string HoroPhotoName { get; set; }
        public int? PD { get; set; }
        public string Settle { set; get; }
        public int? TicketID { get; set; }
        public string TicketNumber { get; set; }
    }

    public class SettlementPaidBalanceDetailsMl
    {
        public string StrProfileID { get; set; }
        public int? Gender { get; set; }
        public int? IsServiceTaxPaid { get; set; }
        public int? PaymenytStatus { get; set; }
        public int? PayAmountFrom { get; set; }
        public int? PayAmountTo { get; set; }
        public int? Region { get; set; }
        public int? Confidential { get; set; }
        public int? SettlementStatus { get; set; }
        public int IsInterestedtoPay { get; set; }
        public DataTable ApplicationStatus { get; set; }
        public DataTable OwnerOFProfile { get; set; }
        public DataTable SearchedBy { get; set; }
        public DataTable Caste { get; set; }
        public DataTable Branch { get; set; }
        public DataTable Relationship { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? From { get; set; }
        public int? To { get; set; }
        public Int64? CreatedByEmpID { get; set; }
        public string CreatedDate { get; set; }
        public Int64? ModifiedByEmpID { get; set; }
        public string ModifiedEmpDate { get; set; }
        public int SettlementAgreedAmount { get; set; }
        public string Notes { get; set; }
        public int? isActive { get; set; }
        public string Settlementfrompath { get; set; }
        public int? isassigned { get; set; }
        public int? ReferenceID { get; set; }
        public int? ProfileID { get; set; }
        public string FileName { get; set; }
        public string Filefullpath { get; set; }
        public string Settlementsigned { get; set; }
        public DataTable ProfileOwners { get; set; }
        //Added by:S.A.Kiran,date:8/27/13,Description:add paging parameters
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int flag { get; set; }
        public int intlowerBound { get; set; }
        public int intUpperBound { get; set; }
        public string Profileidnew { get; set; }
    }

    public class TExpressInterest
    {
        public string FromProfileID { set; get; }
        public string ToProfileID { set; get; }
        public int? EmpID { set; get; }
        public int? ModeofService { set; get; }
        public int? RelationShipID { set; get; }
        public string Name { set; get; }
        public int? TypeOfService { set; get; }
        public int? ProfileType { set; get; }
        public string NotesofCustomer { set; get; }
        public bool? Sendsms { set; get; }
        public bool? IsRvrSend { set; get; }
        public string SelectedImages { set; get; }
        public string Acceptlink { set; get; }
        public string Rejectlink { set; get; }
        public string EmailAddress { set; get; }
        public string RVRAcceptlink { set; get; }
        public string RVRRejectlink { set; get; }
    }

    public class lstexGetDetails
    {
        public List<TExpressInterest> Products { get; set; }
    }

    public class ViewEditProfileSearch
    {
        public string strFName { get; set; }
        public string strSurName { get; set; }
        public string strProfileID { get; set; }
        public string strKMMLID { get; set; }
        public string profileStatus { get; set; }
        public int? intStartIndex { get; set; }
        public int? intEndIndex { get; set; }
        public int? intEmpID { set; get; }
        public bool? isSlide { get; set; }
        public int? genderID { get; set; }
    }
    public class HoroGeneration
    {
        public string AstroGeneration { get; set; }
        public string Path { get; set; }
        public string KeyName { get; set; }
        public string strTestPath { get; set; }
    }

    public class ListOfServicesTakenM1
    {
        public Int64? AppUserId { get; set; }
        public int intlowerBound { get; set; }
        public int intUpperBound { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int flag { get; set; }
        public DataTable dtApplicationStatus { get; set; }
        public string strApplicationStatus { get; set; }
        public DataTable dtCaste { get; set; }
        public string strCaste { get; set; }

        public DataTable dtBranch { get; set; }
        public string strBranch { get; set; }
        public DataTable dtOwneroftheProfile { get; set; }
        public string strOwneroftheProfile { get; set; }
        public DataTable dtservicetakeby { get; set; }
        public string strservicetakeby { get; set; }
        public int? IsConfidential { get; set; }
        public string ServiceTakenFromDate { get; set; }
        public int? StartIndex { get; set; }
        public int? EndIndex { get; set; }
        public int? ResultFlag { get; set; }
        public string ServiceTakenToDate { get; set; }
    }




}