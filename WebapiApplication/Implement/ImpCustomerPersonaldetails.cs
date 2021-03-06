﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebapiApplication.ML;
using WebapiApplication.Interfaces;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Web.Http;
using WebapiApplication.DAL;

namespace WebapiApplication.Implement
{

    public class ImpCustomerPersonaldetails : ICustomerPersonaldetails
    {

        customerPersonalDetails customerdetails = new customerPersonalDetails();


        public CustomerPersonalDetails getpersonalMenuDetails(string CustID) { return customerdetails.DgetpersonalDetailsDAL(CustID); }
        public ArrayList getCustomerEducationdetails(long? CustID) { return customerdetails.DgetUpdateEducationdetailsDAL(CustID, "[dbo].[usp_ViewCustomerEducationprofdetails]"); }
        public ArrayList getUpdateProfessionDetails(long? CustID) { return customerdetails.DgetUpdateProfessionDetailsDAL(CustID, "[dbo].[usp_ViewCustomerProfessioncustomer]"); }
        public ArrayList getParentDetailsDisplay(long? CustID) { return customerdetails.DgetParentDetailsDisplay(CustID, "[dbo].[USp_GetParentDetails]"); }
        public ArrayList getCustomerpartnerpreferencesDetailsDisplay(long? CustID) { return customerdetails.DgetCustomerpartnerpreferencesDetailsDisplay(CustID, "[dbo].[usp_Customer_PartnerDataPageload]"); }
        public ArrayList getsiblingsDetailsDisplay(long? CustID) { return customerdetails.DgetsiblingsDetailsDisplay(CustID, "[dbo].[usp_Customer_getSibilingByValue_NewDesign]"); }
        public ArrayList getAstroDetailsDisplay(long? CustID) { return customerdetails.DgetAstroDetailsDisplay(CustID, "[dbo].[usp_Customer_getAstroDetailsByValue]"); }
        public ArrayList getPropertyDetailsDisplay(long? CustID) { return customerdetails.DgetPropertyDetailsDisplay(CustID, "[dbo].[usp_Customer_getpropertyDetails]"); }
        public ArrayList getRelativeDetailsDisplay(long? CustID) { return customerdetails.DgetRelativeDetailsDisplay(CustID, "[dbo].[usp_Customer_ReletivesPageload_NewDesign]"); }
        public ArrayList getReferenceViewDetailsDisplay(long? CustID) { return customerdetails.DgetReferenceViewDetailsDisplay(CustID, "[dbo].[usp_Customer_RefrencePageload]"); }
        public ArrayList GetphotosofCustomer(string Custid, int? EmpID) { return customerdetails.DGetphotosofCustomer(Custid, EmpID, "[dbo].[Usp_GetphotosofCustomer]"); }
        public ArrayList getCustomerPersonalMenu(long? CustID, int? iReview, string SectionID) { return customerdetails.CustomerPersonalMenuReview(CustID, iReview, SectionID, "[dbo].[usp_CustomerPersonalMenu_Emp_NewDesign]"); }
        public ArrayList getCustomerPersonalSpouse_Details(long? CustID) { return customerdetails.CustomerPersonalSpouse_Details(CustID, "[dbo].[usp_ViewMySpouse_Details]"); }
        public ArrayList getCustomerPersonalContact_Details(long? CustID) { return customerdetails.CustomerPersonalContact_Details(CustID, "[dbo].[usp_employyee_allcontacts]"); }
        public ArrayList getCustomerPersonaloffice_purpose(string flag, string ID, string AboutProfile, int? IsConfidential, int? HighConfendential) { return customerdetails.CustomerPersonaloffice_purpose(flag, ID, AboutProfile, IsConfidential, HighConfendential, "[dbo].[usp_Customerlinq]"); }
        public ArrayList CustomerprofilesettingDetails(long? CustID) { return customerdetails.CustomerprofilesettingDetails(CustID, "[dbo].[usp_GetProfileSettings_forcustomer]"); }
        public string getDiscribeYour(string CustID, string AboutYourself, int? flag, string spName) { return customerdetails.DgetDiscribeYour(CustID, AboutYourself, flag, spName); }
        public ArrayList personaldetails_Customer(long? CustID) { return customerdetails.personaldetails_Customer(CustID, "[dbo].[usp_customerpersonaldetails_pageload]"); }
        public ArrayList ViewAllCustomersSearch(int? intEmpID, string SearchData, string profileStatus, int? StartIndex, int? EndIndex) { return customerdetails.ViewAllCustomersSearch(intEmpID, SearchData, profileStatus,StartIndex,EndIndex ,"[dbo].[usp_emp_searchCustomer_test_NewDesign]"); }
        public ArrayList ViewAllCustomersKMPLProfileID(int? EmpID, string SearchData) { return customerdetails.ViewAllCustomersKMPLProfileID(EmpID, SearchData, "[dbo].[usp_emp_searchKMPLCustomer]"); }
        public int CustomerphotoRequestDisplay(string profileid, int? EMPID, long? ticketIDs) { return customerdetails.CustomerphotoRequestDisplay(profileid, EMPID, ticketIDs, "[dbo].[sp_email_nophotos_Marketslideshow]"); }
        public ArrayList CandidateContactdetailsRelationName(long? CustID, int? PrimaryMobileRel, int? PrimaryEmailRel, int? iflage) { return customerdetails.CandidateContactdetailsRelationName(CustID, PrimaryMobileRel, PrimaryEmailRel, iflage, "[dbo].[Usp_PrimaryMobileEmailRel]"); }
        public int CandidateContactsendmailtoemailverify(long? CustID) { return customerdetails.CandidateContactsendmailtoemailverify(CustID, "[dbo].[Usp_ResendEmailVerficationLink]"); }
        public ArrayList ProfileIDPlaybutton(string ProfileID) { return customerdetails.ProfileIDPlaybutton(ProfileID, "[dbo].[Usp_GetFullInfoofCustomer_NewDesign]"); }
        public ArrayList ViewAllCustomersSettledeleteinfo(string CustID, string typeofdata) { return customerdetails.ViewAllCustomersSettledeleteinfo(CustID, typeofdata, "[dbo].[usp_ViewSettleDeleteProfiledsinfo_NewDesign]"); }
        public ArrayList Search_ViewEditProfile(ViewEditProfileSearch Mobj) { return customerdetails.Search_ViewEditProfile(Mobj, Mobj.isSlide == true ? "[dbo].[Usp_Emp_ViewEditProfileSLIDE_AJS]" : "[dbo].[Usp_Emp_ViewEditProfile_AJS]"); }// "[dbo].[Usp_Search_ViewEditProfile_Slide]" : "[dbo].[Usp_Search_ViewEditProfile_Table]"
        public ArrayList getNoPhotoStatus(long custid) { return customerdetails.getNoPhotoStatusDal(custid, "GetPhotoStatusForUpload"); }
    }

    public class ImpCustomerPersonaldetailsUpdate : ICustomerPersonaldetailsUpdate
    {

        customerPersonalDetails customerdetails = new customerPersonalDetails();

        public int getEducationdetails_Updatecustomer(UpdatePersonaldetails MobjEdudetails) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjEdudetails, "[dbo].[usp_edit_updateEducion_CustomerEdit]", "@dtEducationdetails"); }
        public int getProfessionDetails_Customer(UpdatePersonaldetails MobjProf) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjProf, "[dbo].[usp_edit_Profession_CustomerEdit]", "@dtprofessiondetails"); }
        public int CustomerParentUpdatedetails(UpdatePersonaldetails MobjProf) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjProf, "[dbo].[usp_edit_ParenentFatherMother_CustomerEdit]", "@dtParentFathermother"); }
        public int CustomerContactAddressUpdatedetails(UpdatePersonaldetails MobjProf) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjProf, "[dbo].[usp_edit_ContactAddress_CustomerEdit]", "@dtParentContactAddress"); }
        public int CustomerPhysicalAttributesUpdatedetails(UpdatePersonaldetails MobjProf) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjProf, "[dbo].[usp_edit_ParentphysicalHealth_CustomerEdit]", "@dtParentPhysicalhealth"); }
        public int CustomerPartnerPreferencesUpdatedetails(UpdatePersonaldetails MobjProf) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjProf, "[dbo].[usp_edit_PartnerPreferences_EmployeeEdit]", "@dtPartnerPreferences"); }//usp_edit_PartnerPreferences_CustomerEdit replaced Sp(23_02_2018)
        public int CustomerSibBrotherUpdatedetails(UpdatePersonaldetails MobjProf) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjProf, "[dbo].[usp_edit_SibblingBrother_CustomerEdit_NewDesign]", "@dtsibBrotherdetails"); }
        public int CustomerSibSisterUpdatedetails(UpdatePersonaldetails MobjProf) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjProf, "[dbo].[usp_edit_SibblingSister_CustomerEdit_NewDesign]", "@dtsibSisterdetails"); }
        public int CustomerAstrodetailsUpdatedetails(UpdatePersonaldetails MobjProf) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjProf, "[dbo].[usp_edit_Astrodetails_CustomerEdit]", "@dtAstrodetails"); }
        public int CustomerPropertyUpdatedetails(UpdatePersonaldetails MobjProf) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjProf, "[dbo].[usp_Customer_PropertySubmit]", "@dtPropertyCustomerEdit"); }
        public int CustomerFathersBrotherUpdatedetails(UpdatePersonaldetails MobjProf) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjProf, "[dbo].[usp_edit_FathersBrotherDetails_CustomerEdit_NewDesign]", "@dtFatherBrotherRel"); }
        public int CustomerFathersSisterUpdatedetails(UpdatePersonaldetails MobjProf) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjProf, "[dbo].[usp_edit_FathersSisterDetails_CustomerEdit_NewDesign]", "@dtFathersSisterDetails"); }
        public int CustomerMotherBrotherUpdatedetails(UpdatePersonaldetails MobjProf) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjProf, "[dbo].[usp_edit_MotherBrotherDetails_CustomerEdit_NewDesign]", "@dtMotherBrotherDetails"); }
        public int CustomerMotherSisterUpdatedetails(UpdatePersonaldetails MobjProf) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjProf, "[dbo].[usp_edit_MotherSisterDetails_CustomerEdit_NewDesign]", "@dtMotherSisterDetails"); }
        public int CustomerReferencedetailsUpdatedetails(UpdatePersonaldetails MobjProf) { return customerdetails.DCustomerPersonal_insertUpdateDetails(MobjProf, "[dbo].[usp_edit_Refrencedetails_CustomerEdit]", "@dtCustomerRefdetails"); }
        public int UpdateSibblingCounts(SibblingCounts sibcount) { return customerdetails.DUpdateSibblingCounts(sibcount, "[dbo].[usp_SibblingCounts]"); }
        public ArrayList Savephotosofcustomer(UpdatePersonaldetails savePhoto) { return customerdetails.Savephotosofcustomer(savePhoto, "[dbo].[usp_Edit_Photoupload_forCustomer]"); }
        public int PhotoPassword(long? CustID, int? ipassword) { return customerdetails.PhotoPassword(CustID, ipassword, "[dbo].[usp_PhotoPassword]"); }
        public int AstroDetailsUpdateDelete(AstroUploadDelete astroupdate) { return customerdetails.AstroDetailsUpdateDelete(astroupdate, "[dbo].[usp_AstroUpload_Delete]"); }
        public HoroGeneration GenerateHoroscorpe(int? customerid, string EmpIDQueryString, int? intDay, int? intMonth, int? intYear, int? CityID) { return customerdetails.GenerateHoroscorpe(customerid, EmpIDQueryString, intDay, intMonth, intYear, CityID); }
        public ArrayList Emplanding_counts_Admin(EmployeeLandingCount ecount) { return customerdetails.Emplanding_counts_Admin(ecount, "[dbo].[usp_emp_emplanding_counts_Admin_New_AJS]"); }//usp_emplanding_counts_Admin_New

        public ArrayList Emplanding_counts_TablesDisplay(EmployeeLandingCount ecount) { return customerdetails.Emplanding_counts_TablesDisplay(ecount, "[dbo].[usp_emp_emplanding_counts_Admin_New_AJS]"); }//usp_emplanding_counts_Admin_New

        

        public int UpdateSpoucedetails_Customersetails(UpdatePersonaldetails customerpersonaldetails) { return customerdetails.UpdateSpoucedetails_Customersetails(customerpersonaldetails, "[dbo].[usp_edit_Spoucedetails_CustomerEdit]"); }
        public int UpdateSpouseChildDetails(UpdatePersonaldetails customerpersonaldetails) { return customerdetails.UpdateSpouseChildDetails(customerpersonaldetails, "[dbo].[usp_edit_SpoucedetailsChildern_CustomerEdit_NewDesign]"); }
        public int CustomerContactDetails_Update(ContactDetals Mobj) { return customerdetails.CustomerContactDetails_Update(Mobj, "[dbo].[usp_edit_CustomerContactNumbers_EmployeeEdit_NewDesign]"); }
        public int CustomerProfileSetting_ProfileSetting(UpdateprofileeMl Mobj) { return customerdetails.CustomerProfileSetting_ProfileSetting(Mobj, "[dbo].[usp_updateprofilesettings_forcustomer_NewDesign]"); }
        public int CustomerProfileSetting_Gradeselection(NoProfileGradingMl Mobj) { return customerdetails.CustomerProfileSetting_Gradeselection(Mobj, "[dbo].[usp_edit_CustomerContactNumbers_EmployeeEdit]"); }
        public int UpdatePersonalDetails_Customersetails(UpdatePersonaldetails customerpersonaldetails) { return customerdetails.UpdatePersonalDetails_Customersetails(customerpersonaldetails, "[dbo].[usp_edit_Personaldetailsupdate_NewDesign]"); }
        public int CustomerSectionsDeletions(string sectioname, long? CustID, long? identityid) { return customerdetails.CustomerSectionsDeletions(sectioname, CustID, identityid, "[dbo].[usp_CustomerSectionsDeletions]"); }
        public NoDataFoundDisplay NoDataInformationLinkDisplay(string ProfileID) { return customerdetails.NoDataInformationLinkDisplay(ProfileID, "[dbo].[usp_Profile_NoDataFound]"); }
        public int UpdateContactdetails_Reference(ContactdetailsRef Mobj) { return customerdetails.UpdateContactdetails_Reference(Mobj, "[dbo].[usp_UpdateContactdetails_Reference]"); }
        public int UploadsettlementForm(SettlementPaidBalanceDetailsMl settlementForm) { return customerdetails.UploadsettlementForm(settlementForm, "[dbo].[usp_InsertUplaodsettlement_NewDesign]"); }
        public int AstroGenerationS3Update(string Path, string KeyName) { return customerdetails.AstroGenerationUpdate(Path, KeyName); }
    }
}