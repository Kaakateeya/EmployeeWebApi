﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;

namespace WebapiApplication.UserDefinedTable
{
    public class PersonaldetailsUDTables
    {

        public static DataTable createEducationdataTable()
        {
            DataTable dtEducationdetails = new DataTable();
            dtEducationdetails.Columns.Add("CustID");
            dtEducationdetails.Columns.Add("Educationcategory");
            dtEducationdetails.Columns.Add("Educationgroup");
            dtEducationdetails.Columns.Add("Educationspecialization");
            dtEducationdetails.Columns.Add("University");
            dtEducationdetails.Columns.Add("College");
            dtEducationdetails.Columns.Add("Passofyear");
            dtEducationdetails.Columns.Add("Countrystudyin");
            dtEducationdetails.Columns.Add("Statestudyin");
            dtEducationdetails.Columns.Add("Districtstudyin");
            dtEducationdetails.Columns.Add("CitystudyIn");
            dtEducationdetails.Columns.Add("OtherCity");
            dtEducationdetails.Columns.Add("Highestdegree");
            dtEducationdetails.Columns.Add("Educationalmerits");
            dtEducationdetails.Columns.Add("Cust_Education_ID");
            dtEducationdetails.Columns.Add("intEduID");
            return dtEducationdetails;

        }

        public static DataTable createDataTableprofessiondetails()
        {
            DataTable dtProfession = new DataTable();
            dtProfession.Columns.Add("CustID");
            dtProfession.Columns.Add("EmployedIn");
            dtProfession.Columns.Add("Professionalgroup");
            dtProfession.Columns.Add("Profession");
            dtProfession.Columns.Add("Companyname");
            dtProfession.Columns.Add("Currency");
            dtProfession.Columns.Add("Monthlysalary");
            dtProfession.Columns.Add("CountryID");
            dtProfession.Columns.Add("StateID");
            dtProfession.Columns.Add("DistrictID");
            dtProfession.Columns.Add("CityID");
            dtProfession.Columns.Add("OtherCity");
            dtProfession.Columns.Add("Workingfromdate");
            dtProfession.Columns.Add("OccupationDetails");
            dtProfession.Columns.Add("visastatus");
            dtProfession.Columns.Add("Sincedate");
            dtProfession.Columns.Add("ArrivalDate");
            dtProfession.Columns.Add("DepartureDate");
            dtProfession.Columns.Add("profGridID");
            dtProfession.Columns.Add("ProfessionID");
            return dtProfession;
        }

        public static DataTable createDataTablePaymentDetails()
        {
            DataTable dtPayment = new DataTable();

            dtPayment.Columns.Add("ProfileID");
            dtPayment.Columns.Add("Genderid");
            dtPayment.Columns.Add("NoofPoints");
            dtPayment.Columns.Add("MemberShipName");
            dtPayment.Columns.Add("AgreedAmount");
            dtPayment.Columns.Add("Casteid");
            dtPayment.Columns.Add("MemberShipTypeID");
            dtPayment.Columns.Add("SettlementAmount");
            dtPayment.Columns.Add("DateDuration");
            dtPayment.Columns.Add("ServiceTax");
            dtPayment.Columns.Add("Branch");
            dtPayment.Columns.Add("AmountPaid");
            dtPayment.Columns.Add("EndDate");
            dtPayment.Columns.Add("ReceiptNumber");
            dtPayment.Columns.Add("TransactionID");
            dtPayment.Columns.Add("ChequeNoOrDDNo");
            dtPayment.Columns.Add("BranchName");
            dtPayment.Columns.Add("BankName");
            dtPayment.Columns.Add("Place");
            dtPayment.Columns.Add("Paydescription");
            dtPayment.Columns.Add("ModeOfPayment");
            dtPayment.Columns.Add("EmpID");
            dtPayment.Columns.Add("MembershipID");
            dtPayment.Columns.Add("Cust_ID");
            dtPayment.Columns.Add("FirstName");
            dtPayment.Columns.Add("LastName");
            dtPayment.Columns.Add("StartDate");
            dtPayment.Columns.Add("MemberShipDescription");
            dtPayment.Columns.Add("ApplicationName");
            dtPayment.Columns.Add("MemberShipType");
            dtPayment.Columns.Add("CasteName");
            dtPayment.Columns.Add("Gender");
            dtPayment.Columns.Add("Flag");
            return dtPayment;
        }


        public static DataTable createDataTablePayment_New()
        {
            DataTable dtPayment = new DataTable();
            dtPayment.Columns.Add("ProfileID");
            dtPayment.Columns.Add("Cust_id");
            dtPayment.Columns.Add("Payment_Id");
            dtPayment.Columns.Add("Renual_Type");
            dtPayment.Columns.Add("NoofPoints");
            dtPayment.Columns.Add("AgreedAmount");
            dtPayment.Columns.Add("SettlementAmount");
            dtPayment.Columns.Add("DateDuration");
            dtPayment.Columns.Add("ServiceTax");
            dtPayment.Columns.Add("ServiceTaxAmt");
            dtPayment.Columns.Add("AmountPaid");
            dtPayment.Columns.Add("StartDate");
            dtPayment.Columns.Add("EndDate");
            dtPayment.Columns.Add("ReceiptNumber");
            dtPayment.Columns.Add("TransactionID");
            dtPayment.Columns.Add("ChequeNoOrDDNo");
            dtPayment.Columns.Add("BranchName");
            dtPayment.Columns.Add("BankName");
            dtPayment.Columns.Add("Place");
            dtPayment.Columns.Add("Paydescription");
            dtPayment.Columns.Add("ModeOfPayment");
            dtPayment.Columns.Add("EmpID");
            dtPayment.Columns.Add("AccessFeatureID");
            dtPayment.Columns.Add("MembershipDuration");
            dtPayment.Columns.Add("PaymentHist_ID");


            return dtPayment;
        }


        public static DataTable dtcreateParentsDetail()
        {
            DataTable dtParentsDetails = new DataTable();
            dtParentsDetails.Columns.Add("CustID");
            dtParentsDetails.Columns.Add("FatherName");
            dtParentsDetails.Columns.Add("Educationcategory");
            dtParentsDetails.Columns.Add("Educationgroup");
            dtParentsDetails.Columns.Add("Educationspecialization");
            dtParentsDetails.Columns.Add("Employedin");
            dtParentsDetails.Columns.Add("Professiongroup");
            dtParentsDetails.Columns.Add("Profession");
            dtParentsDetails.Columns.Add("CompanyName");
            dtParentsDetails.Columns.Add("JobLocation");
            dtParentsDetails.Columns.Add("Professiondetails");
            dtParentsDetails.Columns.Add("MobileCountry");
            dtParentsDetails.Columns.Add("MobileNumber");
            dtParentsDetails.Columns.Add("LandlineCountry");
            dtParentsDetails.Columns.Add("LandAreCode");
            dtParentsDetails.Columns.Add("landLineNumber");
            dtParentsDetails.Columns.Add("Email");
            dtParentsDetails.Columns.Add("FatherFatherName");

            //  ----------------------------MOTHER DETAILS-----------------
            dtParentsDetails.Columns.Add("MotherName");
            dtParentsDetails.Columns.Add("MotherEducationcategory");
            dtParentsDetails.Columns.Add("MotherEducationgroup");
            dtParentsDetails.Columns.Add("MotherEducationspecialization");
            dtParentsDetails.Columns.Add("MotherEmployedIn");
            dtParentsDetails.Columns.Add("MotherProfessiongroup");
            dtParentsDetails.Columns.Add("MotherProfession");
            dtParentsDetails.Columns.Add("MotherCompanyName");
            dtParentsDetails.Columns.Add("MotherJobLocation");
            dtParentsDetails.Columns.Add("MotherProfessiondetails");
            dtParentsDetails.Columns.Add("MotherMobileCountryID");
            dtParentsDetails.Columns.Add("MotherMobileNumber");
            dtParentsDetails.Columns.Add("MotherLandCountryID");
            dtParentsDetails.Columns.Add("MotherLandAreaCode");
            dtParentsDetails.Columns.Add("MotherLandNumber");
            dtParentsDetails.Columns.Add("MotherEmail");
            dtParentsDetails.Columns.Add("MotherFatherFistname");
            dtParentsDetails.Columns.Add("MotherFatherLastname");
            dtParentsDetails.Columns.Add("FatherCustFamilyID");
            dtParentsDetails.Columns.Add("MotherCustFamilyID");
            dtParentsDetails.Columns.Add("FatherEducationDetails");
            dtParentsDetails.Columns.Add("MotherEducationDetails");


            dtParentsDetails.Columns.Add("FatherCountry");
            dtParentsDetails.Columns.Add("FatherState");
            dtParentsDetails.Columns.Add("FatherDistric");
            dtParentsDetails.Columns.Add("FatherCity");
            dtParentsDetails.Columns.Add("MotherCountry");
            dtParentsDetails.Columns.Add("MotherState");
            dtParentsDetails.Columns.Add("MotherDistric");
            dtParentsDetails.Columns.Add("MotherCity");


            dtParentsDetails.Columns.Add("AreParentsInterCaste");
            dtParentsDetails.Columns.Add("FatherfatherMobileCountryID");
            dtParentsDetails.Columns.Add("FatherFatherMobileNumber");
            dtParentsDetails.Columns.Add("FatherFatherLandCountryID");
            dtParentsDetails.Columns.Add("FatherFatherLandAreaCode");
            dtParentsDetails.Columns.Add("FatherFatherLandNumber");
            dtParentsDetails.Columns.Add("MotherfatherMobileCountryID");
            dtParentsDetails.Columns.Add("MotherFatherMobileNumber");
            dtParentsDetails.Columns.Add("MotherFatherLandCountryID");
            dtParentsDetails.Columns.Add("MotherFatherLandAreaCode");
            dtParentsDetails.Columns.Add("MotherFatherLandNumber");
            dtParentsDetails.Columns.Add("MotherCaste");
            dtParentsDetails.Columns.Add("FatherCaste");
            dtParentsDetails.Columns.Add("FatherProfessionCategoryID");
            dtParentsDetails.Columns.Add("MotherProfessionCategoryID");

            return dtParentsDetails;
        }

        //contact details
        public static DataTable dtcreateContactAddressdetails()
        {
            DataTable dtcreateContactdetails = new DataTable();
            dtcreateContactdetails.Columns.Add("CustID");
            dtcreateContactdetails.Columns.Add("HouseFlateNumber");
            dtcreateContactdetails.Columns.Add("Apartmentname");
            dtcreateContactdetails.Columns.Add("Streetname");
            dtcreateContactdetails.Columns.Add("AreaName");
            dtcreateContactdetails.Columns.Add("Landmark");
            dtcreateContactdetails.Columns.Add("Country");
            dtcreateContactdetails.Columns.Add("STATE");
            dtcreateContactdetails.Columns.Add("District");
            dtcreateContactdetails.Columns.Add("othercity");
            dtcreateContactdetails.Columns.Add("city");
            dtcreateContactdetails.Columns.Add("ZipPin");
            dtcreateContactdetails.Columns.Add("Cust_Family_ID");
            return dtcreateContactdetails;


        }
        //physical Attributes
        public static DataTable dtcreaPhysicalAttributedetails()
        {
            DataTable dtPhysicalAttribute = new DataTable();
            dtPhysicalAttribute.Columns.Add("CustID");
            dtPhysicalAttribute.Columns.Add("BWKgs");
            dtPhysicalAttribute.Columns.Add("BWlbs");
            dtPhysicalAttribute.Columns.Add("BloodGroup");
            dtPhysicalAttribute.Columns.Add("HealthConditions");
            dtPhysicalAttribute.Columns.Add("HealthConditiondesc");
            dtPhysicalAttribute.Columns.Add("DietID");
            dtPhysicalAttribute.Columns.Add("SmokeID");
            dtPhysicalAttribute.Columns.Add("DrinkID");
            dtPhysicalAttribute.Columns.Add("BodyTypeID");
            return dtPhysicalAttribute;


        }
        //partnerpref
        public static DataTable dtCreatePartnerPreferences()
        {
            DataTable dtPartberPref = new DataTable();
            dtPartberPref.Columns.Add("CustID");
            dtPartberPref.Columns.Add("AgeGapFrom");
            dtPartberPref.Columns.Add("AgeGapTo");
            dtPartberPref.Columns.Add("HeightFrom");
            dtPartberPref.Columns.Add("HeightTo");
            dtPartberPref.Columns.Add("Religion");
            dtPartberPref.Columns.Add("Mothertongue");
            dtPartberPref.Columns.Add("Caste");
            dtPartberPref.Columns.Add("Subcaste");
            dtPartberPref.Columns.Add("Maritalstatus");
            dtPartberPref.Columns.Add("ManglikKujadosham");
            dtPartberPref.Columns.Add("PreferredstarLanguage");
            dtPartberPref.Columns.Add("Educationcategory");
            dtPartberPref.Columns.Add("Educationgroup");
            dtPartberPref.Columns.Add("Employedin");
            dtPartberPref.Columns.Add("Professiongroup");
            dtPartberPref.Columns.Add("Diet");
            dtPartberPref.Columns.Add("Preferredcountry");
            dtPartberPref.Columns.Add("Preferredstate");
            dtPartberPref.Columns.Add("Preferreddistrict");
            dtPartberPref.Columns.Add("Preferredlocation");
            dtPartberPref.Columns.Add("TypeofStar");
            dtPartberPref.Columns.Add("PrefredStars");
            dtPartberPref.Columns.Add("GenderID");
            dtPartberPref.Columns.Add("Region");
            dtPartberPref.Columns.Add("Branch");
            dtPartberPref.Columns.Add("Domacile");
            dtPartberPref.Columns.Add("WillingtoSecondMarriage");

            dtPartberPref.Columns.Add("Property_From");
            dtPartberPref.Columns.Add("Property_To");

            //dtPartberPref.Columns.Add("CityID");

            return dtPartberPref;
        }

        public static DataTable dtCreateDatatableBrotherDetail()
        {
            DataTable dtsibBrotherdetails = new DataTable();
            dtsibBrotherdetails.Columns.Add("CustID");
            dtsibBrotherdetails.Columns.Add("BroName");
            dtsibBrotherdetails.Columns.Add("BroElderYounger");
            dtsibBrotherdetails.Columns.Add("BroEducationcategory");
            dtsibBrotherdetails.Columns.Add("BroEducationgroup");
            dtsibBrotherdetails.Columns.Add("BroEducationspecialization");
            dtsibBrotherdetails.Columns.Add("BroEmployedin");
            dtsibBrotherdetails.Columns.Add("BroProfessiongroup");
            dtsibBrotherdetails.Columns.Add("BroProfession");
            dtsibBrotherdetails.Columns.Add("BroCompanyName");
            dtsibBrotherdetails.Columns.Add("BroJobLocation");
            dtsibBrotherdetails.Columns.Add("BroMobileCountryCodeID");
            dtsibBrotherdetails.Columns.Add("BroMobileNumber");
            dtsibBrotherdetails.Columns.Add("BroLandCountryCodeID");
            dtsibBrotherdetails.Columns.Add("BroLandAreaCode");
            dtsibBrotherdetails.Columns.Add("BroLandNumber");
            dtsibBrotherdetails.Columns.Add("BroEmail");
            dtsibBrotherdetails.Columns.Add("BIsMarried");
            dtsibBrotherdetails.Columns.Add("BroWifeName");
            dtsibBrotherdetails.Columns.Add("BroWifeEducationcategory");
            dtsibBrotherdetails.Columns.Add("BroWifeEducationgroup");
            dtsibBrotherdetails.Columns.Add("BroWifeEducationspecialization");
            dtsibBrotherdetails.Columns.Add("BroWifeEmployedin");
            dtsibBrotherdetails.Columns.Add("BroWifeProfessiongroup");
            dtsibBrotherdetails.Columns.Add("BroWifeProfession");
            dtsibBrotherdetails.Columns.Add("BroWifeCompanyName");
            dtsibBrotherdetails.Columns.Add("BroWifeJobLocation");
            dtsibBrotherdetails.Columns.Add("BroWifeMobileCountryCodeID");
            dtsibBrotherdetails.Columns.Add("BroWifeMobileNumber");
            dtsibBrotherdetails.Columns.Add("BroWifeLandCountryCodeID");
            dtsibBrotherdetails.Columns.Add("BroWifeLandAreacode");
            dtsibBrotherdetails.Columns.Add("BroWifeLandNumber");
            dtsibBrotherdetails.Columns.Add("BroWifeFatherSurName");
            dtsibBrotherdetails.Columns.Add("BroWifeFatherName");
            dtsibBrotherdetails.Columns.Add("BroSibilingCustfamilyID");
            dtsibBrotherdetails.Columns.Add("BroEducationDetails");
            dtsibBrotherdetails.Columns.Add("BrowifeEducationDetails");
            dtsibBrotherdetails.Columns.Add("BroProfessionDetails");
            dtsibBrotherdetails.Columns.Add("BroWifeProfessionDetails");
            dtsibBrotherdetails.Columns.Add("BroSpouseFatherCountryID");
            dtsibBrotherdetails.Columns.Add("BroSpouseFatherStateID");
            dtsibBrotherdetails.Columns.Add("BroSpouseFatherDitrictID");
            dtsibBrotherdetails.Columns.Add("BroSpouseFatherNativePlace");
            dtsibBrotherdetails.Columns.Add("BrotherSpouseEmail");
            dtsibBrotherdetails.Columns.Add("SibilingSpouseFatherCasteID");
            dtsibBrotherdetails.Columns.Add("BroProfessionCategoryID");
            dtsibBrotherdetails.Columns.Add("BroSpouseProfessionCategoryID");
            dtsibBrotherdetails.Columns.Add("BroSpouseFatherEmailID");
            dtsibBrotherdetails.Columns.Add("BroSpouseFatherMobileCountryID");
            dtsibBrotherdetails.Columns.Add("BroSpouseFatherMobileNo");
            dtsibBrotherdetails.Columns.Add("BroSpouseFatherLandCountryID");
            dtsibBrotherdetails.Columns.Add("BroSpouseFatherLandAreaCode");
            dtsibBrotherdetails.Columns.Add("BroSpouseFatherLandNo");
            dtsibBrotherdetails.Columns.Add("BornOrder");

            return dtsibBrotherdetails;


        }

        public static DataTable dtCreateDatatableSisterDetail()
        {
            DataTable dtsibsisterdetails = new DataTable();
            dtsibsisterdetails.Columns.Add("CustID");
            dtsibsisterdetails.Columns.Add("SisName");
            dtsibsisterdetails.Columns.Add("SisElderYounger");
            dtsibsisterdetails.Columns.Add("SisEducationcategory");
            dtsibsisterdetails.Columns.Add("SisEducationgroup");
            dtsibsisterdetails.Columns.Add("SisEducationspecialization");
            dtsibsisterdetails.Columns.Add("SisEmployedin");
            dtsibsisterdetails.Columns.Add("SisProfessiongroup");
            dtsibsisterdetails.Columns.Add("SisProfession");
            dtsibsisterdetails.Columns.Add("SisCompanyName");
            dtsibsisterdetails.Columns.Add("SisJobLocation");
            dtsibsisterdetails.Columns.Add("SisMobileCountryCodeID");
            dtsibsisterdetails.Columns.Add("SisMobileNumber");
            dtsibsisterdetails.Columns.Add("SisLandCountryCodeID");
            dtsibsisterdetails.Columns.Add("SisLandAreaCode");
            dtsibsisterdetails.Columns.Add("SisLandNumber");
            dtsibsisterdetails.Columns.Add("SisEmail");
            dtsibsisterdetails.Columns.Add("SIsMarried");
            dtsibsisterdetails.Columns.Add("SisHusbandName");
            dtsibsisterdetails.Columns.Add("SisHusbandEducationcategory");
            dtsibsisterdetails.Columns.Add("SisHusbandEducationgroup");
            dtsibsisterdetails.Columns.Add("SisHusbandEducationspecialization");
            dtsibsisterdetails.Columns.Add("SisHusbandEmployedin");
            dtsibsisterdetails.Columns.Add("SisHusbandProfessiongroup");
            dtsibsisterdetails.Columns.Add("SisHusbandProfession");
            dtsibsisterdetails.Columns.Add("SisHusCompanyName");
            dtsibsisterdetails.Columns.Add("SisHusJobLocation");
            dtsibsisterdetails.Columns.Add("SisHusbandMobileCountryCodeID");
            dtsibsisterdetails.Columns.Add("SisHusbandMobileNumber");
            dtsibsisterdetails.Columns.Add("SisHusbandLandCountryCodeID");
            dtsibsisterdetails.Columns.Add("SisHusbandLandAreacode");
            dtsibsisterdetails.Columns.Add("SisHusbandLandNumber");
            dtsibsisterdetails.Columns.Add("SisHusbandFatherSurName");
            dtsibsisterdetails.Columns.Add("SisHusbandFatherName");
            dtsibsisterdetails.Columns.Add("SisSibilingCustfamilyID");
            dtsibsisterdetails.Columns.Add("siseducationdetails");
            dtsibsisterdetails.Columns.Add("sisprofessiondetails");
            dtsibsisterdetails.Columns.Add("sisspouseeducationdetails");
            dtsibsisterdetails.Columns.Add("sisspouseprofessiondetails");
            dtsibsisterdetails.Columns.Add("SisSpouseFatherCountryID");
            dtsibsisterdetails.Columns.Add("SisSpouseFatherStateID");
            dtsibsisterdetails.Columns.Add("SisSpouseFatherDitrictID");
            dtsibsisterdetails.Columns.Add("SisSpouseFatherNativePlace");
            dtsibsisterdetails.Columns.Add("SisSpouseEmail");
            dtsibsisterdetails.Columns.Add("SibilingSpouseFatherCasteID");
            dtsibsisterdetails.Columns.Add("SisProfessionCategoryID");
            dtsibsisterdetails.Columns.Add("SisSpouseProfessionCategoryID");
            dtsibsisterdetails.Columns.Add("SisSpouseFatherEmailID");
            dtsibsisterdetails.Columns.Add("SisSpouseFatherMobileCountryID");
            dtsibsisterdetails.Columns.Add("SisSpouseFatherMobileNo");
            dtsibsisterdetails.Columns.Add("SisSpouseFatherLandCountryID");
            dtsibsisterdetails.Columns.Add("SisSpouseFatherLandAreaCode");
            dtsibsisterdetails.Columns.Add("SisSpouseFatherLandNo");
            dtsibsisterdetails.Columns.Add("BornOrder");

            return dtsibsisterdetails;
        }

        public static DataTable dtcreateAstrodetail()
        {
            DataTable dtastrodetails = new DataTable();
            dtastrodetails.Columns.Add("CustID");
            dtastrodetails.Columns.Add("TimeofBirth");
            dtastrodetails.Columns.Add("CountryOfBirthID");
            dtastrodetails.Columns.Add("StateOfBirthID");
            dtastrodetails.Columns.Add("DistrictOfBirthID");
            dtastrodetails.Columns.Add("CityOfBirthID");
            dtastrodetails.Columns.Add("Starlanguage");
            dtastrodetails.Columns.Add("Star");
            dtastrodetails.Columns.Add("Paadam");
            dtastrodetails.Columns.Add("Lagnam");
            dtastrodetails.Columns.Add("RasiMoonsign");
            dtastrodetails.Columns.Add("GothramGotra");
            dtastrodetails.Columns.Add("Maternalgothram");
            dtastrodetails.Columns.Add("ManglikKujadosham");
            dtastrodetails.Columns.Add("Pblongitude");
            dtastrodetails.Columns.Add("pblatitude");
            dtastrodetails.Columns.Add("TimeZone");
            return dtastrodetails;
        }
        public static DataTable dtcreatePropertydetails()
        {
            DataTable dtProperty = new DataTable();
            dtProperty.Columns.Add("FamilyStatus");
            dtProperty.Columns.Add("Issharedproperty");
            dtProperty.Columns.Add("Valueofproperty");
            dtProperty.Columns.Add("PropertyType");
            dtProperty.Columns.Add("Propertydescription");
            dtProperty.Columns.Add("Showingviewprofile");
            dtProperty.Columns.Add("Custpropertyid");
            dtProperty.Columns.Add("PropertyID");
            dtProperty.Columns.Add("CustId");
            return dtProperty;
        }
        public static DataTable dtcreateFathersBrotherDetail()
        {
            DataTable dtFBDetails = new DataTable();
            dtFBDetails.Columns.Add("CustID");
            dtFBDetails.Columns.Add("Fatherbrothername");
            dtFBDetails.Columns.Add("FBElderYounger");
            dtFBDetails.Columns.Add("FBEmployedin");
            dtFBDetails.Columns.Add("FBProfessiongroup");
            dtFBDetails.Columns.Add("FBProfession");
            dtFBDetails.Columns.Add("FBProfessiondetails");
            dtFBDetails.Columns.Add("FBMobileCountryID");
            dtFBDetails.Columns.Add("FBMobileNumber");
            dtFBDetails.Columns.Add("FBLandLineCountryID");
            dtFBDetails.Columns.Add("FBLandAreaCode");
            dtFBDetails.Columns.Add("FBLandNumber");
            dtFBDetails.Columns.Add("FBEmails");
            dtFBDetails.Columns.Add("FBCurrentLocation");
            dtFBDetails.Columns.Add("FatherbrotherCust_familyID");
            dtFBDetails.Columns.Add("FatherBrotherEducationDetails");
            dtFBDetails.Columns.Add("BornOrder");
            return dtFBDetails;
        }

        public static DataTable dtcreateFathersSisterDetail()
        {
            DataTable dtFSister = new DataTable();
            dtFSister.Columns.Add("CustID");
            dtFSister.Columns.Add("FSFathersistername");
            dtFSister.Columns.Add("FSElderYounger");
            dtFSister.Columns.Add("FSHusbandfirstname");
            dtFSister.Columns.Add("FSHusbandlastname");
            dtFSister.Columns.Add("FSCountryID");
            dtFSister.Columns.Add("FSHStateID");
            dtFSister.Columns.Add("FSHDistrict");
            dtFSister.Columns.Add("FSNativeplace");
            dtFSister.Columns.Add("FSHEmployedin");
            dtFSister.Columns.Add("FSHProfessiongroup");
            dtFSister.Columns.Add("FSHProfession");
            dtFSister.Columns.Add("FSHProfessiondetails");
            dtFSister.Columns.Add("FSHMobileCountryID");
            dtFSister.Columns.Add("FSHMObileNumber");
            dtFSister.Columns.Add("FSHLandCountryID");
            dtFSister.Columns.Add("FSHLandAreaCode");
            dtFSister.Columns.Add("FSHLandNumber");
            dtFSister.Columns.Add("FSHEmails");
            dtFSister.Columns.Add("FSCurrentLocation");
            dtFSister.Columns.Add("FatherSisterCust_familyID");
            dtFSister.Columns.Add("FSHEducationdetails");
            dtFSister.Columns.Add("BornOrder");
            return dtFSister;
        }

        public static DataTable dtcreateMotherBrotherDetail()
        {
            DataTable dtMBdetails = new DataTable();
            dtMBdetails.Columns.Add("CustID");
            dtMBdetails.Columns.Add("Motherbrothername");
            dtMBdetails.Columns.Add("MBElderYounger");
            dtMBdetails.Columns.Add("MBEmployedin");
            dtMBdetails.Columns.Add("MBProfessiongroup");
            dtMBdetails.Columns.Add("MBProfession");
            dtMBdetails.Columns.Add("MBProfessiondetails");
            dtMBdetails.Columns.Add("MBMobileCountryID");
            dtMBdetails.Columns.Add("MBMObileNumber");
            dtMBdetails.Columns.Add("MBLandLineCountryID");
            dtMBdetails.Columns.Add("MBLandAreaCode");
            dtMBdetails.Columns.Add("MBLandNumber");
            dtMBdetails.Columns.Add("MBEmails");
            dtMBdetails.Columns.Add("MBCurrentLocation");
            dtMBdetails.Columns.Add("MBMotherBrotherCust_familyID");
            dtMBdetails.Columns.Add("MBEducationdetails");
            dtMBdetails.Columns.Add("BornOrder");
            return dtMBdetails;
        }

        public static DataTable dtcreateMotherSisterDetail()
        {
            DataTable dtMSisterDetails = new DataTable();
            dtMSisterDetails.Columns.Add("CustID");
            dtMSisterDetails.Columns.Add("Mothersistername");
            dtMSisterDetails.Columns.Add("MSElderYounger");
            dtMSisterDetails.Columns.Add("MSHusbandfirstname");
            dtMSisterDetails.Columns.Add("MSHusbandlastname");
            dtMSisterDetails.Columns.Add("MSCountryID");
            dtMSisterDetails.Columns.Add("MSMSHStateID");
            dtMSisterDetails.Columns.Add("MSMSHDistrictID");
            dtMSisterDetails.Columns.Add("MSNativeplace");
            dtMSisterDetails.Columns.Add("MSEmployedin");
            dtMSisterDetails.Columns.Add("MSProfession");
            dtMSisterDetails.Columns.Add("MSProfessiondetails");
            dtMSisterDetails.Columns.Add("MSMSHMobileCountryID");
            dtMSisterDetails.Columns.Add("MSMObileNumber");
            dtMSisterDetails.Columns.Add("MSHLandlineCountryID");
            dtMSisterDetails.Columns.Add("MSLandAreaCode");
            dtMSisterDetails.Columns.Add("MSLandNumber");
            dtMSisterDetails.Columns.Add("MSHEmails");
            dtMSisterDetails.Columns.Add("MSCurrentLocation");
            dtMSisterDetails.Columns.Add("MSCust_familyID");
            dtMSisterDetails.Columns.Add("MSEducationdetails");
            dtMSisterDetails.Columns.Add("BornOrder");
            return dtMSisterDetails;
        }

        public static DataTable dtcreateDatatableReferenceDetail()
        {
            DataTable dtRefdetails = new DataTable();
            dtRefdetails.Columns.Add("CustID");
            dtRefdetails.Columns.Add("RelationshiptypeID");
            dtRefdetails.Columns.Add("Firstname");
            dtRefdetails.Columns.Add("Lastname");
            dtRefdetails.Columns.Add("Employedin");
            dtRefdetails.Columns.Add("Professiongroup");
            dtRefdetails.Columns.Add("Profession");
            dtRefdetails.Columns.Add("Professiondetails");
            dtRefdetails.Columns.Add("CountryID");
            dtRefdetails.Columns.Add("StateID");
            dtRefdetails.Columns.Add("DistrictID");
            dtRefdetails.Columns.Add("Nativeplace");
            dtRefdetails.Columns.Add("Presentlocation");
            dtRefdetails.Columns.Add("MobileCountryID");
            dtRefdetails.Columns.Add("MobileNumber");
            dtRefdetails.Columns.Add("LandLineCountryID");
            dtRefdetails.Columns.Add("LandLineAreaCode");
            dtRefdetails.Columns.Add("LandLineNumber");
            dtRefdetails.Columns.Add("Emails");
            dtRefdetails.Columns.Add("Narration");
            dtRefdetails.Columns.Add("Cust_Reference_ID");
            return dtRefdetails;
        }

        public static DataTable dtSavephotosofcustomer()
        {
            DataTable dtsavephoto = new DataTable();
            dtsavephoto.Columns.Add("ID");
            dtsavephoto.Columns.Add("url");
            dtsavephoto.Columns.Add("order");
            dtsavephoto.Columns.Add("IsProfilePic");
            dtsavephoto.Columns.Add("DisplayStatus");
            dtsavephoto.Columns.Add("Password");
            dtsavephoto.Columns.Add("IsReviewed");
            dtsavephoto.Columns.Add("TempImageUrl");
            dtsavephoto.Columns.Add("IsTempActive");
            dtsavephoto.Columns.Add("DeletedImageurl");
            dtsavephoto.Columns.Add("IsImageDeleted");
            dtsavephoto.Columns.Add("PhotoStatus");
            dtsavephoto.Columns.Add("PhotoID");
            dtsavephoto.Columns.Add("PhotoPassword");

            return dtsavephoto;

        }

        public static DataTable dtAdminCount(string Name)
        {
            DataTable dtAC = new DataTable();
            dtAC.Columns.Add(Name);
            return dtAC;
        }

        public static DataTable dtCustomerRegProfileDetails()
        {
            DataTable dtCustomerHome = new DataTable();

            dtCustomerHome.Columns.Add("NAME");
            dtCustomerHome.Columns.Add("Maritalstatus");
            dtCustomerHome.Columns.Add("Heights");
            dtCustomerHome.Columns.Add("Complexion");
            dtCustomerHome.Columns.Add("Physicalstatus");
            dtCustomerHome.Columns.Add("Citizenship");
            dtCustomerHome.Columns.Add("BornCitizenship");
            dtCustomerHome.Columns.Add("EducationCategory");
            dtCustomerHome.Columns.Add("EducationGroup");
            dtCustomerHome.Columns.Add("EducationSpl");
            dtCustomerHome.Columns.Add("EducationDetails");
            dtCustomerHome.Columns.Add("EmployeeIN");
            dtCustomerHome.Columns.Add("ProfessionGroup");
            dtCustomerHome.Columns.Add("Profession");
            dtCustomerHome.Columns.Add("CompanyName");
            dtCustomerHome.Columns.Add("OccupationDetails");
            dtCustomerHome.Columns.Add("AnnualIncome");
            dtCustomerHome.Columns.Add("Currency");
            dtCustomerHome.Columns.Add("Salary");
            dtCustomerHome.Columns.Add("CountryLivingIn");
            dtCustomerHome.Columns.Add("StateLivingIn");
            dtCustomerHome.Columns.Add("DistictLivingIn");
            dtCustomerHome.Columns.Add("CityLivingIN");
            dtCustomerHome.Columns.Add("Cityother");
            dtCustomerHome.Columns.Add("VisaStatus");
            dtCustomerHome.Columns.Add("ResidingSince");
            dtCustomerHome.Columns.Add("FatherName");
            dtCustomerHome.Columns.Add("FatherEducation");
            dtCustomerHome.Columns.Add("FastherProfession");
            dtCustomerHome.Columns.Add("FatherNative");
            dtCustomerHome.Columns.Add("MotherName");
            dtCustomerHome.Columns.Add("MotherEducation");
            dtCustomerHome.Columns.Add("MotherProfession");
            dtCustomerHome.Columns.Add("MotherNative");
            dtCustomerHome.Columns.Add("NOofbrother");
            dtCustomerHome.Columns.Add("NOofSisters");
            dtCustomerHome.Columns.Add("AboutYourself");
            dtCustomerHome.Columns.Add("fathereducationdetails");
            dtCustomerHome.Columns.Add("fatherProfessiondetails");
            dtCustomerHome.Columns.Add("mothereducationdetails");
            dtCustomerHome.Columns.Add("motherProfessiondetails");
            dtCustomerHome.Columns.Add("FatherMobileCountryCode");
            dtCustomerHome.Columns.Add("FatherMobileNumber");
            dtCustomerHome.Columns.Add("MotherMobileCountryCode");
            dtCustomerHome.Columns.Add("MotherMobileNumber");
            return dtCustomerHome;

        }

        public static DataTable dtCustomerGeneralandAdvancedSavedSearch()
        {
            DataTable newsearch = new DataTable();
            newsearch.Columns.Add("CustID");
            newsearch.Columns.Add("Lookingfor");
            newsearch.Columns.Add("FromAge");
            newsearch.Columns.Add("ToAge");
            newsearch.Columns.Add("FromHeight");
            newsearch.Columns.Add("ToHeight");
            newsearch.Columns.Add("Maritalstatus");
            newsearch.Columns.Add("Religion");
            newsearch.Columns.Add("Mothertongue");
            newsearch.Columns.Add("Caste");
            newsearch.Columns.Add("Complexion");
            newsearch.Columns.Add("Physicalstatus");
            newsearch.Columns.Add("CountyWorking");
            newsearch.Columns.Add("StateWorking");
            newsearch.Columns.Add("Visastatus");
            newsearch.Columns.Add("Educationcategory");
            newsearch.Columns.Add("EducationGroup");
            newsearch.Columns.Add("Educationspecialization");
            newsearch.Columns.Add("professioncategory");
            newsearch.Columns.Add("Professiongroup");
            newsearch.Columns.Add("Professionspecialization");
            newsearch.Columns.Add("Annualincome");
            newsearch.Columns.Add("FromSalary");
            newsearch.Columns.Add("ToSalary");
            newsearch.Columns.Add("Starlanguage");
            newsearch.Columns.Add("Star");
            newsearch.Columns.Add("ManglikKujaDosham");
            newsearch.Columns.Add("Drink");
            newsearch.Columns.Add("Smoke");
            newsearch.Columns.Add("Diet");
            newsearch.Columns.Add("Registrationdays");
            newsearch.Columns.Add("CustSavedSearchName");
            newsearch.Columns.Add("searchPageName");
            newsearch.Columns.Add("searchPageID");
            newsearch.Columns.Add("SearchResult_ID");
            return newsearch;
        }

        public static DataTable dtSpouseDetailsUpdate()
        {

            DataTable dtSpouseDetails = new DataTable();
            dtSpouseDetails.Columns.Add("CustID");
            dtSpouseDetails.Columns.Add("NAME");
            dtSpouseDetails.Columns.Add("Education");
            dtSpouseDetails.Columns.Add("Profession");
            dtSpouseDetails.Columns.Add("HouseFlatnumber");
            dtSpouseDetails.Columns.Add("Apartmentname");
            dtSpouseDetails.Columns.Add("Streetname");
            dtSpouseDetails.Columns.Add("Areaname");
            dtSpouseDetails.Columns.Add("Landmark");
            dtSpouseDetails.Columns.Add("Country");
            dtSpouseDetails.Columns.Add("STATE");
            dtSpouseDetails.Columns.Add("District");
            dtSpouseDetails.Columns.Add("City");
            dtSpouseDetails.Columns.Add("Zip");
            dtSpouseDetails.Columns.Add("Marriedon");
            dtSpouseDetails.Columns.Add("Separateddate");
            dtSpouseDetails.Columns.Add("Legallydivorced");
            dtSpouseDetails.Columns.Add("Dateoflegaldivorce");
            dtSpouseDetails.Columns.Add("Uploaddivorcedocument");
            dtSpouseDetails.Columns.Add("Fatherfirstname");
            dtSpouseDetails.Columns.Add("Fatherlastname");
            dtSpouseDetails.Columns.Add("Notesaboutpreviousmarriage");
            dtSpouseDetails.Columns.Add("Familyplanning");
            dtSpouseDetails.Columns.Add("Noofchildren");
            dtSpouseDetails.Columns.Add("Cust_Spouse_ID");
            return dtSpouseDetails;

        }

        public static DataTable dtSpouseChildDetailsUpdate()
        {
            DataTable dtSpouseDetails = new DataTable();
            dtSpouseDetails.Columns.Add("CustID");
            dtSpouseDetails.Columns.Add("Nameofthechild");
            dtSpouseDetails.Columns.Add("Genderofthechild");
            dtSpouseDetails.Columns.Add("DOB");
            dtSpouseDetails.Columns.Add("Childstayingwith");
            dtSpouseDetails.Columns.Add("Childstayingwithrelation");
            dtSpouseDetails.Columns.Add("Cust_Children_ID");
            return dtSpouseDetails;

        }

        public static DataTable dtUpdatePersonalDetails()
        {

            DataTable dtUpdatePersonal = new DataTable();
            dtUpdatePersonal.Columns.Add("CustID");
            dtUpdatePersonal.Columns.Add("MaritalStatusID");
            dtUpdatePersonal.Columns.Add("DateofBirth");
            dtUpdatePersonal.Columns.Add("HeightID");
            dtUpdatePersonal.Columns.Add("ComplexionID");
            dtUpdatePersonal.Columns.Add("ReligionID");
            dtUpdatePersonal.Columns.Add("MotherTongueID");
            dtUpdatePersonal.Columns.Add("CasteID");
            dtUpdatePersonal.Columns.Add("CitizenshipID");
            dtUpdatePersonal.Columns.Add("SubcasteID");
            dtUpdatePersonal.Columns.Add("LastName");
            dtUpdatePersonal.Columns.Add("FirstName");
            dtUpdatePersonal.Columns.Add("Gender");
            dtUpdatePersonal.Columns.Add("PhysicallyChallenged");

            return dtUpdatePersonal;

        }

        //Employee Search

        public static DataTable dtcreateDatatableShowDataForEmployeeGeneral()
        {

            DataTable dtGeneralsearch = new DataTable();
            dtGeneralsearch.Columns.Add("CustID");
            dtGeneralsearch.Columns.Add("GenderID");
            dtGeneralsearch.Columns.Add("GenderText");
            dtGeneralsearch.Columns.Add("AgeFromID");
            dtGeneralsearch.Columns.Add("AgeFromText");
            dtGeneralsearch.Columns.Add("AgeToID");
            dtGeneralsearch.Columns.Add("AgeToText");
            dtGeneralsearch.Columns.Add("HeightFromID");
            dtGeneralsearch.Columns.Add("HeightFromText");
            dtGeneralsearch.Columns.Add("HeightToID");
            dtGeneralsearch.Columns.Add("HeightToText");
            dtGeneralsearch.Columns.Add("MaritalstatusID");
            dtGeneralsearch.Columns.Add("MaritalstatusText ");
            dtGeneralsearch.Columns.Add("ReligionID");
            dtGeneralsearch.Columns.Add("ReligionText");
            dtGeneralsearch.Columns.Add("MothertongueID");
            dtGeneralsearch.Columns.Add("MothertongueText");
            dtGeneralsearch.Columns.Add("castID");
            dtGeneralsearch.Columns.Add("castIDText");
            dtGeneralsearch.Columns.Add("CountryID");
            dtGeneralsearch.Columns.Add("CountryText");
            dtGeneralsearch.Columns.Add("EducationID");
            dtGeneralsearch.Columns.Add("EducationText");
            dtGeneralsearch.Columns.Add("ProfessionID");
            dtGeneralsearch.Columns.Add("ProfessionText");
            dtGeneralsearch.Columns.Add("Showinprofile");
            dtGeneralsearch.Columns.Add("ShowinprofileText");
            dtGeneralsearch.Columns.Add("RegionID");
            dtGeneralsearch.Columns.Add("RegionText");
            dtGeneralsearch.Columns.Add("BranchID");
            dtGeneralsearch.Columns.Add("BranchText");
            dtGeneralsearch.Columns.Add("Dateofregfrom");
            dtGeneralsearch.Columns.Add("Dateofregto");
            dtGeneralsearch.Columns.Add("LastestLoginsfrom");
            dtGeneralsearch.Columns.Add("LastestLoginsto");
            dtGeneralsearch.Columns.Add("ApplicationstatusID");
            dtGeneralsearch.Columns.Add("ApplicationstatusText");
            dtGeneralsearch.Columns.Add("PropertyValuefrom");
            dtGeneralsearch.Columns.Add("PropertyValueto");
            dtGeneralsearch.Columns.Add("AnnualincomeID");
            dtGeneralsearch.Columns.Add("AnnualincomeText");
            dtGeneralsearch.Columns.Add("AnnualIncomefrom");
            dtGeneralsearch.Columns.Add("AnnualIncometo");
            dtGeneralsearch.Columns.Add("ProfileID");
            dtGeneralsearch.Columns.Add("SeriousMatch");
            dtGeneralsearch.Columns.Add("OnlyConfidential");
            dtGeneralsearch.Columns.Add("slidegride");
            dtGeneralsearch.Columns.Add("HoroScopeStatus");
            //Added By Lakshmi
            dtGeneralsearch.Columns.Add("DOBfrom");
            dtGeneralsearch.Columns.Add("DOBTo");
            dtGeneralsearch.Columns.Add("EmpIds");
            //dtGeneralsearch.Columns.Add("ParentInterCaste");
            //Added by lakshmi 12/08/2017
            dtGeneralsearch.Columns.Add("SubCasteID");
            //08/09/2017 Added by lakshmi
            dtGeneralsearch.Columns.Add("FatherCaste");
            dtGeneralsearch.Columns.Add("MotherCaste");
            //
            dtGeneralsearch.Columns.Add("Divorce_NoofChild");
            dtGeneralsearch.Columns.Add("Divorce_Service");
            dtGeneralsearch.Columns.Add("MembershipTypeID");

            //Add StarLanguage by  Asha  23/01/2019

            dtGeneralsearch.Columns.Add("StarLanguageID");
            dtGeneralsearch.Columns.Add("StarLanguageText");
            dtGeneralsearch.Columns.Add("StarsID");
            dtGeneralsearch.Columns.Add("StarsText");

            return dtGeneralsearch;
        }

        public static DataTable dtcreateDatatableShowDataForEmployeeAdvanceSearch()
        {
            DataTable dtAdvancesearch = new DataTable();
            dtAdvancesearch.Columns.Add("CustID");
            dtAdvancesearch.Columns.Add("GenderID");
            dtAdvancesearch.Columns.Add("GenderText");
            dtAdvancesearch.Columns.Add("AgeFromID");
            dtAdvancesearch.Columns.Add("AgeFromText");
            dtAdvancesearch.Columns.Add("AgeToID");
            dtAdvancesearch.Columns.Add("AgeToText");
            dtAdvancesearch.Columns.Add("HeightFromID");
            dtAdvancesearch.Columns.Add("HeightFromText");
            dtAdvancesearch.Columns.Add("HeightToID");
            dtAdvancesearch.Columns.Add("HeightToText");
            dtAdvancesearch.Columns.Add("MaritalstatusID");
            dtAdvancesearch.Columns.Add("MaritalstatusText");
            dtAdvancesearch.Columns.Add("ReligionID");
            dtAdvancesearch.Columns.Add("ReligionText");
            dtAdvancesearch.Columns.Add("MothertongueID");
            dtAdvancesearch.Columns.Add("MothertongueText");
            dtAdvancesearch.Columns.Add("casteID");
            dtAdvancesearch.Columns.Add("casteText");
            dtAdvancesearch.Columns.Add("CountryID");
            dtAdvancesearch.Columns.Add("CountryText");
            dtAdvancesearch.Columns.Add("EducationID");
            dtAdvancesearch.Columns.Add("EducationText");
            dtAdvancesearch.Columns.Add("ProfessionID");
            dtAdvancesearch.Columns.Add("ProfessionText");
            dtAdvancesearch.Columns.Add("ShowinprofileID");
            dtAdvancesearch.Columns.Add("ShowinprofileText");
            dtAdvancesearch.Columns.Add("RegionID");
            dtAdvancesearch.Columns.Add("RegionText");
            dtAdvancesearch.Columns.Add("BranchID");
            dtAdvancesearch.Columns.Add("BranchText");
            dtAdvancesearch.Columns.Add("Dateofregfrom");
            dtAdvancesearch.Columns.Add("Dateofregto");
            dtAdvancesearch.Columns.Add("LastestLoginsfrom");
            dtAdvancesearch.Columns.Add("LastestLoginsto");
            dtAdvancesearch.Columns.Add("ApplicationstatusID");
            dtAdvancesearch.Columns.Add("ApplicationstatusText");
            dtAdvancesearch.Columns.Add("PropertyValuefrom");
            dtAdvancesearch.Columns.Add("PropertyValueto");
            dtAdvancesearch.Columns.Add("AnnualincomeID");
            dtAdvancesearch.Columns.Add("AnnualincomeText");
            dtAdvancesearch.Columns.Add("AnnualIncomefrom");
            dtAdvancesearch.Columns.Add("AnnualIncometo");
            dtAdvancesearch.Columns.Add("ProfileID");
            dtAdvancesearch.Columns.Add("SeriousMatch");
            dtAdvancesearch.Columns.Add("OnlyConfidential");
            dtAdvancesearch.Columns.Add("slidegride");
            dtAdvancesearch.Columns.Add("ComplexionID");
            dtAdvancesearch.Columns.Add("ComplexionText");
            dtAdvancesearch.Columns.Add("bodytypeID");
            dtAdvancesearch.Columns.Add("bodytypeText");
            dtAdvancesearch.Columns.Add("physicalStatusID");
            dtAdvancesearch.Columns.Add("physicalStatusText");
            dtAdvancesearch.Columns.Add("EducationCategoryID");
            dtAdvancesearch.Columns.Add("EducationCategoryText");
            dtAdvancesearch.Columns.Add("EducationGroupID");
            dtAdvancesearch.Columns.Add("EducationGroupText");
            dtAdvancesearch.Columns.Add("EducationSpecializationID");
            dtAdvancesearch.Columns.Add("EducationSpecializationText  ");
            dtAdvancesearch.Columns.Add("University");
            dtAdvancesearch.Columns.Add("ProfessionAreaID");
            dtAdvancesearch.Columns.Add("ProfessionAreaText");
            dtAdvancesearch.Columns.Add("jobCountryID");
            dtAdvancesearch.Columns.Add("jobCountryText");
            dtAdvancesearch.Columns.Add("StateID");
            dtAdvancesearch.Columns.Add("StateText");
            dtAdvancesearch.Columns.Add("DistrictID");
            dtAdvancesearch.Columns.Add("DistrictText");
            dtAdvancesearch.Columns.Add("CityID");
            dtAdvancesearch.Columns.Add("CityText");
            dtAdvancesearch.Columns.Add("VisaStatusID");
            dtAdvancesearch.Columns.Add("VisaStatusText");
            dtAdvancesearch.Columns.Add("Arrivaldateto");
            dtAdvancesearch.Columns.Add("Departuredatefrom");
            dtAdvancesearch.Columns.Add("DeparturedateTo");
            dtAdvancesearch.Columns.Add("StarLanguageID");
            dtAdvancesearch.Columns.Add("StarLanguageText");
            dtAdvancesearch.Columns.Add("StarsID");
            dtAdvancesearch.Columns.Add("StarsText");
            dtAdvancesearch.Columns.Add("KojadoshamID");
            dtAdvancesearch.Columns.Add("KojadoshamText");
            dtAdvancesearch.Columns.Add("DrinkID");
            dtAdvancesearch.Columns.Add("DrinkText");
            dtAdvancesearch.Columns.Add("SmokeID");
            dtAdvancesearch.Columns.Add("SmokeText");
            dtAdvancesearch.Columns.Add("DietID");
            dtAdvancesearch.Columns.Add("DietText");
            dtAdvancesearch.Columns.Add("preferedCityID");
            dtAdvancesearch.Columns.Add("preferedCityText");
            dtAdvancesearch.Columns.Add("MembershipTypeID");
            dtAdvancesearch.Columns.Add("MembershipTypeText");
            dtAdvancesearch.Columns.Add("WorkingwithID");
            dtAdvancesearch.Columns.Add("WorkingwithText");
            dtAdvancesearch.Columns.Add("CompanyName");
            dtAdvancesearch.Columns.Add("Residingsincefrom");
            dtAdvancesearch.Columns.Add("ResidingsinceTo");
            dtAdvancesearch.Columns.Add("Arrivaldatefrom");
            dtAdvancesearch.Columns.Add("FirstName");
            dtAdvancesearch.Columns.Add("LastName");
            dtAdvancesearch.Columns.Add("PreferedCountryID");
            dtAdvancesearch.Columns.Add("PreferedCountryText");
            dtAdvancesearch.Columns.Add("PreferedStateID");
            dtAdvancesearch.Columns.Add("PreferedStateText");
            dtAdvancesearch.Columns.Add("preferedDistrictID");
            dtAdvancesearch.Columns.Add("preferedDistrictText");
            dtAdvancesearch.Columns.Add("HoroScopeStatus");
            dtAdvancesearch.Columns.Add("Status_Photo");
            dtAdvancesearch.Columns.Add("Status_Education");
            dtAdvancesearch.Columns.Add("Status_Property");
            dtAdvancesearch.Columns.Add("Status_Family");
            dtAdvancesearch.Columns.Add("Status_Profession");
            dtAdvancesearch.Columns.Add("DOBfrom");
            dtAdvancesearch.Columns.Add("DOBTo");
            dtAdvancesearch.Columns.Add("EmpIds");
            // dtAdvancesearch.Columns.Add("ParentInterCaste");
            //Added by LAkshmi 12/08/2017
            dtAdvancesearch.Columns.Add("SubCasteID");
            //08/09/2017 Added by lakshmi
            dtAdvancesearch.Columns.Add("FatherCaste");
            dtAdvancesearch.Columns.Add("MotherCaste");

            dtAdvancesearch.Columns.Add("Divorce_NoofChild");
            dtAdvancesearch.Columns.Add("Divorce_Service");
           
            return dtAdvancesearch;
        }

        public static DataTable dtExpressInterestTable()
        {

            DataTable dtexp = new DataTable();
            dtexp.Columns.Add("FromProfileID");
            dtexp.Columns.Add("ToProfileID");
            dtexp.Columns.Add("EmpID");
            dtexp.Columns.Add("ModeofService");
            dtexp.Columns.Add("RelationShipID");
            dtexp.Columns.Add("Name");
            dtexp.Columns.Add("TypeOfService");
            dtexp.Columns.Add("ProfileType");
            dtexp.Columns.Add("NotesofCustomer");
            dtexp.Columns.Add("Sendsms");
            dtexp.Columns.Add("IsRvrSend");
            dtexp.Columns.Add("SelectedImages");
            dtexp.Columns.Add("Acceptlink");
            dtexp.Columns.Add("Rejectlink");
            dtexp.Columns.Add("EmailAddress");
            dtexp.Columns.Add("RvrAcceptlink");
            dtexp.Columns.Add("RvrRejectlink");
            return dtexp;

        }

        public static DataTable dtassignsettings()
        {

            DataTable dtassign = new DataTable();
            dtassign.Columns.Add("ProfileID");
            dtassign.Columns.Add("CustID");
            dtassign.Columns.Add("ModifiedEMPID");
            dtassign.Columns.Add("ProfileOwner");
            dtassign.Columns.Add("MarketingOwner");
            dtassign.Columns.Add("ReviewOwner");
            return dtassign;
        }

        public static DataTable getAuthorizationDetailsUpdate()
        {
            DataTable dtMyAuthDetails = new DataTable("Authorization");

            dtMyAuthDetails.Columns.Add("PaymentID");
            dtMyAuthDetails.Columns.Add("PaymentHisID");//added
            dtMyAuthDetails.Columns.Add("ProfileID");
            dtMyAuthDetails.Columns.Add("CustID");//modif
            dtMyAuthDetails.Columns.Add("AutherizationDesc");
            dtMyAuthDetails.Columns.Add("ExpiryDate");
            dtMyAuthDetails.Columns.Add("PaymentStatus");
            dtMyAuthDetails.Columns.Add("EmployeeID");
            dtMyAuthDetails.Columns.Add("TicketID");
            dtMyAuthDetails.Columns.Add("TicketName");
            dtMyAuthDetails.Columns.Add("TicketOwnerIDAmt_1");
            dtMyAuthDetails.Columns.Add("TicketOwnerIDAmt_2");
            dtMyAuthDetails.Columns.Add("MrkTicketVerified");
            dtMyAuthDetails.Columns.Add("Markedted");
            dtMyAuthDetails.Columns.Add("intRegionID");
            //dtMyAuthDetails.Columns.Add("TotalAmount_Ticket");
            return dtMyAuthDetails;

        }
        public static DataTable getEmployeeDatanew()
        {
            DataTable dtCreateEmployee = new DataTable();
            dtCreateEmployee.Columns.Add("FirstName");
            dtCreateEmployee.Columns.Add("LastName");
            dtCreateEmployee.Columns.Add("OfficialEmailID");
            dtCreateEmployee.Columns.Add("HomeBranchID");
            dtCreateEmployee.Columns.Add("WorkPhone");
            dtCreateEmployee.Columns.Add("OfficialCellPhone");
            dtCreateEmployee.Columns.Add("HomePhone");
            dtCreateEmployee.Columns.Add("PersonalEmailID");
            dtCreateEmployee.Columns.Add("LoginName");
            dtCreateEmployee.Columns.Add("Password");
            dtCreateEmployee.Columns.Add("Designation");
            dtCreateEmployee.Columns.Add("LoginLocation");
            dtCreateEmployee.Columns.Add("OfficeFromHrs");
            dtCreateEmployee.Columns.Add("OfficeToHrs");
            dtCreateEmployee.Columns.Add("DayOff");
            dtCreateEmployee.Columns.Add("DateofJoining");
            dtCreateEmployee.Columns.Add("DateofReleaving");
            dtCreateEmployee.Columns.Add("ReportingMngrID");
            dtCreateEmployee.Columns.Add("AnnualIncome");
            dtCreateEmployee.Columns.Add("Country");
            dtCreateEmployee.Columns.Add("State");
            dtCreateEmployee.Columns.Add("District");
            dtCreateEmployee.Columns.Add("City");
            dtCreateEmployee.Columns.Add("CityOther");
            dtCreateEmployee.Columns.Add("Address");
            dtCreateEmployee.Columns.Add("EducationCategory");
            dtCreateEmployee.Columns.Add("EducationGroup");
            dtCreateEmployee.Columns.Add("EducationSpecialization");
            dtCreateEmployee.Columns.Add("EmployeeImgPath");
            dtCreateEmployee.Columns.Add("TypeOfEmployee");
            dtCreateEmployee.Columns.Add("EmployeeStatus");
            dtCreateEmployee.Columns.Add("isLoginAnywhere");
            dtCreateEmployee.Columns.Add("Dashboard_Status");
            //
            dtCreateEmployee.Columns.Add("loginfrom");
            dtCreateEmployee.Columns.Add("loginto");
            dtCreateEmployee.Columns.Add("IsSmartPh");
            dtCreateEmployee.Columns.Add("AlternateNumber");
            dtCreateEmployee.Columns.Add("TeamHeadID");
            return dtCreateEmployee;
        }

        public static DataTable dtkeywordsearch()
        {
            DataTable dtCreate = new DataTable();
            dtCreate.Columns.Add("CEducationalDetails");
            dtCreate.Columns.Add("CEducationCategory");
            dtCreate.Columns.Add("CEduUniversity");
            dtCreate.Columns.Add("CSecondaryQualification");
            dtCreate.Columns.Add("CPrimaryQualification");
            dtCreate.Columns.Add("CQualificationDetails");
            dtCreate.Columns.Add("CJobLocation");
            dtCreate.Columns.Add("Companyname");
            dtCreate.Columns.Add("CMonthlysalary");
            dtCreate.Columns.Add("CProfession");
            dtCreate.Columns.Add("CprofessionDetails");
            dtCreate.Columns.Add("CPropertyDetails");
            dtCreate.Columns.Add("CpropertyType");
            dtCreate.Columns.Add("CPropertyValue");
            dtCreate.Columns.Add("CPlaceOfBirth");
            dtCreate.Columns.Add("CGothram");
            dtCreate.Columns.Add("CKujadosham");
            dtCreate.Columns.Add("CLagnam");
            dtCreate.Columns.Add("CMaternalGothram");
            dtCreate.Columns.Add("CMotherTongue");
            dtCreate.Columns.Add("CPaadam");
            dtCreate.Columns.Add("CRaasi");
            dtCreate.Columns.Add("CStar");
            dtCreate.Columns.Add("CStarLanguage");
            dtCreate.Columns.Add("CTimeofBirth");
            dtCreate.Columns.Add("CApplicationStatus");
            dtCreate.Columns.Add("Caste");
            dtCreate.Columns.Add("CBornCitigen");
            dtCreate.Columns.Add("CContactAddress");
            dtCreate.Columns.Add("CContactNo");
            dtCreate.Columns.Add("CDateofReg");
            dtCreate.Columns.Add("CDOB");
            dtCreate.Columns.Add("CEmailID");
            dtCreate.Columns.Add("CFName");
            dtCreate.Columns.Add("CLName");
            dtCreate.Columns.Add("CPhotos");
            dtCreate.Columns.Add("CRelision");
            dtCreate.Columns.Add("CSubCaste");
            dtCreate.Columns.Add("CFromAge");
            dtCreate.Columns.Add("CFromHeight");
            dtCreate.Columns.Add("CGender");
            dtCreate.Columns.Add("CMaritalstatus");
            dtCreate.Columns.Add("CToAge");
            dtCreate.Columns.Add("CToHeight");
            dtCreate.Columns.Add("CCityOfLiving");
            dtCreate.Columns.Add("CDistrictOfLiving");
            dtCreate.Columns.Add("CDomicile");
            dtCreate.Columns.Add("CStateOfLiving");
            dtCreate.Columns.Add("CPhNosOffice");
            dtCreate.Columns.Add("CResidence");
            dtCreate.Columns.Add("CMobile");
            dtCreate.Columns.Add("CSecondary_EmailID");
            dtCreate.Columns.Add("CPermt_Add");
            dtCreate.Columns.Add("CNotes");
            dtCreate.Columns.Add("CKnown_Language");
            dtCreate.Columns.Add("CDiet");
            dtCreate.Columns.Add("CSmoker");
            dtCreate.Columns.Add("CDrinker");
            dtCreate.Columns.Add("CBodyType");
            dtCreate.Columns.Add("CFamilyValue");
            dtCreate.Columns.Add("PAgeFrom");
            dtCreate.Columns.Add("PAgeTo");
            dtCreate.Columns.Add("PHeightFrom");
            dtCreate.Columns.Add("PHeightTo");
            dtCreate.Columns.Add("PCaste");
            dtCreate.Columns.Add("PSubCaste");
            dtCreate.Columns.Add("PCategory");
            dtCreate.Columns.Add("PQualifications");
            dtCreate.Columns.Add("PProfession");
            dtCreate.Columns.Add("PJobPreference");
            dtCreate.Columns.Add("PLocation");
            dtCreate.Columns.Add("PAbroadPrefer");
            dtCreate.Columns.Add("PCountry");
            dtCreate.Columns.Add("PState");
            dtCreate.Columns.Add("PDistrict");
            dtCreate.Columns.Add("PMotherTongue");
            dtCreate.Columns.Add("PComplexion");
            dtCreate.Columns.Add("PPrefStars");
            dtCreate.Columns.Add("PNonPrefStars");
            dtCreate.Columns.Add("CBName");
            dtCreate.Columns.Add("CBType");
            dtCreate.Columns.Add("CBEducation");
            dtCreate.Columns.Add("CBProfession");
            dtCreate.Columns.Add("CBDesignation");
            dtCreate.Columns.Add("CBJobLocation");
            dtCreate.Columns.Add("CBPhone");
            dtCreate.Columns.Add("CBEmail");
            dtCreate.Columns.Add("CBWName");
            dtCreate.Columns.Add("CBWEducation");
            dtCreate.Columns.Add("CBWProfession");
            dtCreate.Columns.Add("CBWDesignation");
            dtCreate.Columns.Add("CBWPhone");
            dtCreate.Columns.Add("CBWEmailId");
            dtCreate.Columns.Add("CBWFatherName");
            dtCreate.Columns.Add("CBWFatherSName");
            dtCreate.Columns.Add("CBWFPhoneNumber");
            dtCreate.Columns.Add("CBWFNativePlace");
            dtCreate.Columns.Add("CSName");
            dtCreate.Columns.Add("CSType");
            dtCreate.Columns.Add("CSEducation");
            dtCreate.Columns.Add("CSDesignation");
            dtCreate.Columns.Add("CSJobLocation");
            dtCreate.Columns.Add("CSPNumber");
            dtCreate.Columns.Add("CSEmailID");
            dtCreate.Columns.Add("CSHFirstName");
            dtCreate.Columns.Add("CSHSurName");
            dtCreate.Columns.Add("CSHEducation");
            dtCreate.Columns.Add("CSHProfession");
            dtCreate.Columns.Add("CSHDesignation");
            dtCreate.Columns.Add("CSHNumber");
            dtCreate.Columns.Add("CSHEmailID");
            dtCreate.Columns.Add("CSHFName");
            dtCreate.Columns.Add("CSHFPNumbe");
            dtCreate.Columns.Add("CSHFNative");
            dtCreate.Columns.Add("CSHCaste");
            dtCreate.Columns.Add("FName");
            dtCreate.Columns.Add("FEducation");
            dtCreate.Columns.Add("FProfession");
            dtCreate.Columns.Add("FPhone");
            dtCreate.Columns.Add("FEmailId");
            dtCreate.Columns.Add("FFName");
            dtCreate.Columns.Add("FFPhone");
            dtCreate.Columns.Add("FFEmailID");
            dtCreate.Columns.Add("FFState");
            dtCreate.Columns.Add("FFDistrict");
            dtCreate.Columns.Add("FFNative");
            dtCreate.Columns.Add("MName");
            dtCreate.Columns.Add("MEducation");
            dtCreate.Columns.Add("MProfession");
            dtCreate.Columns.Add("MPhone");
            dtCreate.Columns.Add("MEmailId");
            dtCreate.Columns.Add("MFName");
            dtCreate.Columns.Add("MFPhone");
            dtCreate.Columns.Add("MFEmailID");
            dtCreate.Columns.Add("MFState");
            dtCreate.Columns.Add("MFDistrict");
            dtCreate.Columns.Add("MFNative");
            dtCreate.Columns.Add("MBName");
            dtCreate.Columns.Add("MBType");
            dtCreate.Columns.Add("MBProfession");
            dtCreate.Columns.Add("MBPNumber");
            dtCreate.Columns.Add("MBEmailId");
            dtCreate.Columns.Add("MSName");
            dtCreate.Columns.Add("MSType");
            dtCreate.Columns.Add("MSHFName");
            dtCreate.Columns.Add("MSHSName");
            dtCreate.Columns.Add("MSHNative");
            dtCreate.Columns.Add("MSHProfession");
            dtCreate.Columns.Add("MSHPNumber");
            dtCreate.Columns.Add("MSHEmailID");
            dtCreate.Columns.Add("FBName");
            dtCreate.Columns.Add("FBType");
            dtCreate.Columns.Add("FBProfession");
            dtCreate.Columns.Add("FBPNuFBer");
            dtCreate.Columns.Add("FBEmailId");
            dtCreate.Columns.Add("FSName");
            dtCreate.Columns.Add("FSType");
            dtCreate.Columns.Add("FSHFName");
            dtCreate.Columns.Add("FSHSName");
            dtCreate.Columns.Add("FSHNative");
            dtCreate.Columns.Add("FSHProfession");
            dtCreate.Columns.Add("FSHPNuFBer");
            dtCreate.Columns.Add("FSHEmailID");
            dtCreate.Columns.Add("CandidateAll");
            dtCreate.Columns.Add("FatherAll");
            dtCreate.Columns.Add("MotherAll");
            dtCreate.Columns.Add("BrotherAll");
            dtCreate.Columns.Add("SisterAll");
            dtCreate.Columns.Add("MotherBortherAll");
            dtCreate.Columns.Add("MotherSisterAll");
            dtCreate.Columns.Add("FatherBrotheAll");
            dtCreate.Columns.Add("FatherSisterAll");

            return dtCreate;



        }


        public static DataTable dtlikekeywordsearch()
        {
            DataTable dtCreate = new DataTable();
            dtCreate.Columns.Add("AllContactNo");
            dtCreate.Columns.Add("AllEmails");
            dtCreate.Columns.Add("AllSurNames");
            dtCreate.Columns.Add("AllNatives");
            dtCreate.Columns.Add("CEducationAll");
            dtCreate.Columns.Add("CProfAll");
            dtCreate.Columns.Add("FAllFields");
            dtCreate.Columns.Add("MAllFields");
            dtCreate.Columns.Add("Br_AllFields");
            dtCreate.Columns.Add("Sr_AllFields");
            dtCreate.Columns.Add("FB_AllFields");
            dtCreate.Columns.Add("FS_AllFields");
            dtCreate.Columns.Add("MB_AllFields");
            dtCreate.Columns.Add("MS_AllFields");
            dtCreate.Columns.Add("CAll");
            dtCreate.Columns.Add("Gender");
            //
            dtCreate.Columns.Add("AgeFr");
            dtCreate.Columns.Add("AgeTo");
            dtCreate.Columns.Add("HeightFr");
            dtCreate.Columns.Add("HeightTo");
            dtCreate.Columns.Add("Democel");
            dtCreate.Columns.Add("SP_AllFields");

            return dtCreate;
        }

        public static DataTable dtlikekeywordsearchnew()
        {


            DataTable dtCreate = new DataTable();
            //

            dtCreate.Columns.Add("Gender");
            dtCreate.Columns.Add("maritalstatus");
            dtCreate.Columns.Add("FromAge");
            dtCreate.Columns.Add("ToAge");
            dtCreate.Columns.Add("FromHeight");
            dtCreate.Columns.Add("ToHeight");
            dtCreate.Columns.Add("Caste");

            //Candidate details

            dtCreate.Columns.Add("CEducationAll");
            dtCreate.Columns.Add("CEducationCategory");
            dtCreate.Columns.Add("CEduGroup");
            dtCreate.Columns.Add("CEduSplecialization");
            dtCreate.Columns.Add("CEduUniversity");
            dtCreate.Columns.Add("CEduCollege");
            dtCreate.Columns.Add("CEduCountry");
            dtCreate.Columns.Add("CEduState");
            dtCreate.Columns.Add("CEduDistrict");
            dtCreate.Columns.Add("CEduCity");
            dtCreate.Columns.Add("CEduMerits");
            dtCreate.Columns.Add("CEduPass_Year");

            //profesion
            dtCreate.Columns.Add("CProfAll");
            dtCreate.Columns.Add("EmployeedIn");
            dtCreate.Columns.Add("Professionalgroup");
            dtCreate.Columns.Add("Profession");
            dtCreate.Columns.Add("Companyname");
            dtCreate.Columns.Add("monthlysalary");
            dtCreate.Columns.Add("countryworking");
            dtCreate.Columns.Add("stateworking");
            dtCreate.Columns.Add("districtworking");
            dtCreate.Columns.Add("cityworking");
            dtCreate.Columns.Add("workingfromdate");
            dtCreate.Columns.Add("professionDetails");





            //Father
            dtCreate.Columns.Add("FFirstName");
            dtCreate.Columns.Add("FEducationDetails");
            dtCreate.Columns.Add("FProfessionDetails");
            dtCreate.Columns.Add("FCompanyId");
            dtCreate.Columns.Add("FJobLocation");
            dtCreate.Columns.Add("FNumber");
            dtCreate.Columns.Add("Femail");
            dtCreate.Columns.Add("FFatherName");
            dtCreate.Columns.Add("FFatherContactNumber");
            dtCreate.Columns.Add("FFStateName");
            dtCreate.Columns.Add("FFDistrictName");
            dtCreate.Columns.Add("FFNativePlace");
            dtCreate.Columns.Add("FAllFields");

            //Mother
            //06/06/2016

            dtCreate.Columns.Add("MFirstName");
            dtCreate.Columns.Add("MLastName");
            dtCreate.Columns.Add("MEducationDetails");
            dtCreate.Columns.Add("MProfessionDetails");
            dtCreate.Columns.Add("MCompanyId");
            dtCreate.Columns.Add("MJobLocation");
            dtCreate.Columns.Add("MNumber");
            dtCreate.Columns.Add("Memail");
            dtCreate.Columns.Add("MFatherFirstName");
            dtCreate.Columns.Add("MFatherLastName");
            dtCreate.Columns.Add("MFatherContactNumber");
            dtCreate.Columns.Add("MFStateName");
            dtCreate.Columns.Add("MFDistrictName");
            dtCreate.Columns.Add("MFNativePlace");
            dtCreate.Columns.Add("MAllFields");

            //Brother
            dtCreate.Columns.Add("Br_AllFields");
            dtCreate.Columns.Add("Br_Name");
            dtCreate.Columns.Add("Br_Education");
            dtCreate.Columns.Add("Br_Profession");
            dtCreate.Columns.Add("Br_CompanyNAME");
            dtCreate.Columns.Add("Br_Joblocation");
            dtCreate.Columns.Add("BrContactNo");

            dtCreate.Columns.Add("Br_Email");
            dtCreate.Columns.Add("Brw_Name");
            dtCreate.Columns.Add("Brw_Education");
            dtCreate.Columns.Add("Brw_Profession");
            dtCreate.Columns.Add("Brw_CompanyNAME");
            dtCreate.Columns.Add("Brw_Joblocation");
            dtCreate.Columns.Add("BrwContactNo");

            dtCreate.Columns.Add("Brw_Email");
            dtCreate.Columns.Add("Brwf_Surname");
            dtCreate.Columns.Add("Brwf_Name");
            dtCreate.Columns.Add("BrwfStateName");
            dtCreate.Columns.Add("BrwfDistrictName");
            dtCreate.Columns.Add("BrwfCity");
            //Sister
            dtCreate.Columns.Add("Sr_AllFields");
            dtCreate.Columns.Add("Sr_Name");
            dtCreate.Columns.Add("Sr_Education");
            dtCreate.Columns.Add("Sr_Profession");
            dtCreate.Columns.Add("Sr_CompanyNAME");
            dtCreate.Columns.Add("Sr_Joblocation");
            dtCreate.Columns.Add("SrContactNo");

            dtCreate.Columns.Add("Sr_Email");
            dtCreate.Columns.Add("Srh_Name");
            dtCreate.Columns.Add("Srh_Education");
            dtCreate.Columns.Add("Srh_Profession");
            dtCreate.Columns.Add("Srh_CompanyNAME");
            dtCreate.Columns.Add("Srh_Joblocation");
            dtCreate.Columns.Add("SrhContactNo");

            dtCreate.Columns.Add("Srh_Email");
            dtCreate.Columns.Add("Srhf_Surname");
            dtCreate.Columns.Add("Srhf_Name");
            dtCreate.Columns.Add("SrhfStateName");
            dtCreate.Columns.Add("SrhfDistrictName");
            dtCreate.Columns.Add("SrhfCity");

            //Father Brother
            dtCreate.Columns.Add("FB_AllFields");
            dtCreate.Columns.Add("FB_ElderYounger");
            dtCreate.Columns.Add("FB_Name");
            dtCreate.Columns.Add("FB_Education");
            dtCreate.Columns.Add("FB_Profession");
            dtCreate.Columns.Add("FB_Contactnumber");
            dtCreate.Columns.Add("FB_Email");
            dtCreate.Columns.Add("FB_professionlocation");
            dtCreate.Columns.Add("FS_AllFields");
            dtCreate.Columns.Add("FS_Name");
            dtCreate.Columns.Add("FSH_Surname");
            dtCreate.Columns.Add("FSH_Name");
            dtCreate.Columns.Add("FSH_Education");
            dtCreate.Columns.Add("FSH_Profession");
            dtCreate.Columns.Add("FSHContactNo");
            dtCreate.Columns.Add("FSH_Email");
            dtCreate.Columns.Add("FSH_ProfessionLocation");
            dtCreate.Columns.Add("FSHStateName");
            dtCreate.Columns.Add("FSHDistrictName");
            dtCreate.Columns.Add("FSHCityName");
            dtCreate.Columns.Add("MB_AllFields");
            dtCreate.Columns.Add("MB_Name");
            dtCreate.Columns.Add("MB_Education");
            dtCreate.Columns.Add("MB_Profession");
            dtCreate.Columns.Add("MB_ContactNo");
            dtCreate.Columns.Add("MB_Email");
            dtCreate.Columns.Add("MB_professionlocation");
            dtCreate.Columns.Add("MS_AllFields");
            dtCreate.Columns.Add("MS_Name");
            dtCreate.Columns.Add("MSH_Surname");
            dtCreate.Columns.Add("MSH_Name");
            dtCreate.Columns.Add("MSH_Education");
            dtCreate.Columns.Add("MSH_Profession");
            dtCreate.Columns.Add("MSH_ContactNo");
            dtCreate.Columns.Add("MSH_Email");
            dtCreate.Columns.Add("MSH_ProfessionLocation");
            dtCreate.Columns.Add("MSHStateName");
            dtCreate.Columns.Add("MSHDistrictName");
            dtCreate.Columns.Add("MSHCityName");

            // Add Kiran 20/08/2016

            dtCreate.Columns.Add("CDOB");
            dtCreate.Columns.Add("CColor");
            dtCreate.Columns.Add("CPhotos");
            dtCreate.Columns.Add("CBornCitigen");
            dtCreate.Columns.Add("CRelision");
            dtCreate.Columns.Add("CMotherTongue");
            dtCreate.Columns.Add("CApplicationStat");
            dtCreate.Columns.Add("CDomicile");
            dtCreate.Columns.Add("CRegionalOfBranc");
            dtCreate.Columns.Add("CBranch");
            dtCreate.Columns.Add("CDateofReg");
            dtCreate.Columns.Add("CRegStatus");
            dtCreate.Columns.Add("CPhotoGrade");
            dtCreate.Columns.Add("CEducationGrade");
            dtCreate.Columns.Add("CPropertyGrade");
            dtCreate.Columns.Add("CFamilyGrade");
            dtCreate.Columns.Add("CProfessionGrade");
            dtCreate.Columns.Add("CPhysicalStatus");
            dtCreate.Columns.Add("CDrink");
            dtCreate.Columns.Add("CSmoke");
            dtCreate.Columns.Add("CDiet");
            dtCreate.Columns.Add("CBodyType");
            dtCreate.Columns.Add("CParentCaste");
            dtCreate.Columns.Add("CAboutMe");
            dtCreate.Columns.Add("CAboutFamily");
            dtCreate.Columns.Add("CWebsiteStatus");
            dtCreate.Columns.Add("CCountryOfBirth");
            dtCreate.Columns.Add("CStateOfBirth");
            dtCreate.Columns.Add("CDistrictOfBirth");
            dtCreate.Columns.Add("CCityOfBirth");
            dtCreate.Columns.Add("CStarLanguage");
            dtCreate.Columns.Add("CStar");
            dtCreate.Columns.Add("CPaadam");
            dtCreate.Columns.Add("CLagnam");
            dtCreate.Columns.Add("CRaasi");
            dtCreate.Columns.Add("CGothram");
            dtCreate.Columns.Add("CMaternalGothram");
            dtCreate.Columns.Add("CKujadosham");
            dtCreate.Columns.Add("CHouseflatNumner");
            dtCreate.Columns.Add("CApartmentName");
            dtCreate.Columns.Add("CStreetName");
            dtCreate.Columns.Add("CAreaName");
            dtCreate.Columns.Add("CLandmark");
            dtCreate.Columns.Add("CCountry");
            dtCreate.Columns.Add("CSate");
            dtCreate.Columns.Add("CDistrict");
            dtCreate.Columns.Add("CCity");
            dtCreate.Columns.Add("CZippin");

            dtCreate.Columns.Add("SFName");
            dtCreate.Columns.Add("SLName");
            dtCreate.Columns.Add("SpouseEducation");
            dtCreate.Columns.Add("SpouseProfession");
            dtCreate.Columns.Add("SpouseMarriedOn");
            dtCreate.Columns.Add("SpouseSeparatedDate");
            dtCreate.Columns.Add("SpouseLegallyDivorced");
            dtCreate.Columns.Add("SouseFatherName");
            dtCreate.Columns.Add("SpouseFatherSurname");
            dtCreate.Columns.Add("Spouseaboutpreviousmarriage");
            dtCreate.Columns.Add("SpousefamilyPlaning");
            dtCreate.Columns.Add("SspouseNoOfChildrens");

            dtCreate.Columns.Add("RefName");
            dtCreate.Columns.Add("RefSurname");
            dtCreate.Columns.Add("Refprofession");
            dtCreate.Columns.Add("Refcountry");
            dtCreate.Columns.Add("RefState");
            dtCreate.Columns.Add("RefDistrict");
            dtCreate.Columns.Add("RefNativePlace");
            dtCreate.Columns.Add("RefPresentLocation");
            dtCreate.Columns.Add("RefMobile");
            dtCreate.Columns.Add("ReflandLine");
            dtCreate.Columns.Add("RefEmail");
            dtCreate.Columns.Add("RefNarration");

            dtCreate.Columns.Add("CFName");
            dtCreate.Columns.Add("CLName");
            dtCreate.Columns.Add("CpropertyType");
            dtCreate.Columns.Add("CPropertyValue");
            dtCreate.Columns.Add("CPropertyDescription");
            //
            dtCreate.Columns.Add("Pr_Age_fr");
            dtCreate.Columns.Add("Pr_Age_to");
            dtCreate.Columns.Add("Pr_Hight_fr");
            dtCreate.Columns.Add("Pr_Hight_to");
            dtCreate.Columns.Add("Pr_MotherTongue");
            dtCreate.Columns.Add("Pr_Religion");
            dtCreate.Columns.Add("Pr_Caste");
            dtCreate.Columns.Add("Pr_SubCaste");
            dtCreate.Columns.Add("Pr_MaritalStatus");
            dtCreate.Columns.Add("Pr_Education");
            dtCreate.Columns.Add("Pr_Profession");
            dtCreate.Columns.Add("Pr_Mangalic");
            dtCreate.Columns.Add("Pr_StarLanguage");
            dtCreate.Columns.Add("Pr_NonPreferredStar");
            dtCreate.Columns.Add("Pr_Diet");
            dtCreate.Columns.Add("Pr_PreferredCountry");
            dtCreate.Columns.Add("Pr_PreferredState");
            dtCreate.Columns.Add("Pr_Region");
            dtCreate.Columns.Add("Pr_Branch");

            //contct All
            dtCreate.Columns.Add("CContactAddress_All");
            //dtCreate.Columns.Add("CAll");
            //dtCreate.Columns.Add("ContactNo_All");
            ////Added By lakshmi
            //dtCreate.Columns.Add("SLegallyDivorcedDate");
            //dtCreate.Columns.Add("SNoofChilds_Boys");
            //dtCreate.Columns.Add("SNoofChilds_Girls");
            //dtCreate.Columns.Add("CSinceDate");
            //dtCreate.Columns.Add("CArrivalDate");
            //dtCreate.Columns.Add("CDepartureDate");
            //dtCreate.Columns.Add("CVisaSatus");
            //dtCreate.Columns.Add("CSalaryCurrency");
            //dtCreate.Columns.Add("CTimeofBirth");
            //dtCreate.Columns.Add("CMeternalGothram");
            //dtCreate.Columns.Add("RefRelationShipType");
            //dtCreate.Columns.Add("CProfileGrade");
            //dtCreate.Columns.Add("CPhotoProtectStatus");
            //dtCreate.Columns.Add("CConfidentialStatus");
            //dtCreate.Columns.Add("CHighConfidentialStatus");
            //dtCreate.Columns.Add("IsSeriousMatch");
            //dtCreate.Columns.Add("AllEmails");

            dtCreate.Columns.Add("monthlysalary_To");
            dtCreate.Columns.Add("CSubCaste");
            //
            dtCreate.Columns.Add("Arrivaldatefrom");
            dtCreate.Columns.Add("Arrivaldateto");
            dtCreate.Columns.Add("Departuredatefrom");
            dtCreate.Columns.Add("DeparturedateTo");
            dtCreate.Columns.Add("Residingsincefrom");
            dtCreate.Columns.Add("ResidingsinceTo");

            //

            dtCreate.Columns.Add("Sp_NoofChilds_Boys");
            dtCreate.Columns.Add("Sp_NoofChilds_Girls");
            dtCreate.Columns.Add("C_PropertyValue_To");
            dtCreate.Columns.Add("VisaStatus");
            dtCreate.Columns.Add("C_SibCount_Bro");


            dtCreate.Columns.Add("C_SibCount_Sis");
            dtCreate.Columns.Add("C_ParentCaste");
            dtCreate.Columns.Add("C_FatherCaste");
            dtCreate.Columns.Add("C_MotherName");
            dtCreate.Columns.Add("Ref_RelationShipType");
            dtCreate.Columns.Add("C_FamilyStatusGrade");
            dtCreate.Columns.Add("C_ProfileGrade");


            //
            dtCreate.Columns.Add("Pr_WillingtoSecondMrg");
            //
            dtCreate.Columns.Add("CB_MarriedStatus");
            dtCreate.Columns.Add("CB_YEStatus");
            dtCreate.Columns.Add("CS_MarriedStatus");
            dtCreate.Columns.Add("CS_YEStatus");
            dtCreate.Columns.Add("CFS_YEStatus");
            dtCreate.Columns.Add("CMS_YEStatus");
            dtCreate.Columns.Add("CMB_YEStatus");
            //
            dtCreate.Columns.Add("Pr_ProfessionDetails");
            dtCreate.Columns.Add("Pr_NativeLocation");
            dtCreate.Columns.Add("Pr_PreferredStar");
            dtCreate.Columns.Add("C_ArrivalBetween100Days");
            dtCreate.Columns.Add("C_DepartureBetween100Days");

            dtCreate.Columns.Add("PaidStatus");

            dtCreate.Columns.Add("sp_LegallyDivercedOn");
            dtCreate.Columns.Add("C_Edu_School_Study");
            dtCreate.Columns.Add("C_Edu_Inter_Study");
            dtCreate.Columns.Add("C_Edu_Degree_Study");
            dtCreate.Columns.Add("C_Edu_PG_Study");
            dtCreate.Columns.Add("C_Edu_PHd_Study");
            dtCreate.Columns.Add("Sp_Father_Native");
            dtCreate.Columns.Add("TimeofBirth");
            dtCreate.Columns.Add("FFAll");
            dtCreate.Columns.Add("MFALL");
            dtCreate.Columns.Add("Phones_All");
            dtCreate.Columns.Add("Emails_All");
            dtCreate.Columns.Add("Natives_All");
            dtCreate.Columns.Add("Name_All");
            dtCreate.Columns.Add("SurName_All");
            dtCreate.Columns.Add("Caste_All");
            dtCreate.Columns.Add("Qualification_All");
            dtCreate.Columns.Add("Profession_All");

            dtCreate.Columns.Add("C_ContactDetails");
            dtCreate.Columns.Add("C_PINCode");

            dtCreate.Columns.Add("Pr_PropertyFrom");
            dtCreate.Columns.Add("Pr_PropertyTo");
            dtCreate.Columns.Add("Pr_EduAll");
            dtCreate.Columns.Add("Pr_ProfAll");
            dtCreate.Columns.Add("Pr_Merit");
            dtCreate.Columns.Add("C_ProfileID");

            return dtCreate;

        }



        public static DataTable dtemppermission()
        {
            DataTable dtCreate = new DataTable();
            dtCreate.Columns.Add("PageID");
            dtCreate.Columns.Add("IsView");
            dtCreate.Columns.Add("IsAdd");
            dtCreate.Columns.Add("IsEdit");
            dtCreate.Columns.Add("IsDelete");
            return dtCreate;
        }
    }
}