using System.Collections;
using System.Web.Http;
using WebapiApplication.Implement;
using WebapiApplication.Interfaces;
using WebapiApplication.ML;

namespace WebapiApplication.Api
{
    public class CustomerPersonalController : ApiController
    {
        private readonly ICustomerPersonaldetails ICustomerpersonal;

        public CustomerPersonalController()
            : base()
        {
            this.ICustomerpersonal = new ImpCustomerPersonaldetails();
        }

        public CustomerPersonalDetails getpersonalMenuDetails([FromUri]string CustID)
        {
            return this.ICustomerpersonal.getpersonalMenuDetails(CustID);
        }

        public ArrayList getCustomerEducationdetails([FromUri]long CustID)
        {
            return this.ICustomerpersonal.getCustomerEducationdetails(CustID);
        }

        public ArrayList getCustomerProfessiondetails([FromUri]long CustID)
        {
            return this.ICustomerpersonal.getUpdateProfessionDetails(CustID);
        }

        public ArrayList getParentDetailsDisplay([FromUri]long? CustID)
        {
            return this.ICustomerpersonal.getParentDetailsDisplay(CustID);
        }

        public ArrayList getCustomerpartnerpreferencesDetailsDisplay([FromUri]long? CustID)
        {
            return this.ICustomerpersonal.getCustomerpartnerpreferencesDetailsDisplay(CustID);
        }

        public ArrayList getsiblingsDetailsDisplay([FromUri]long? CustID)
        {
            return this.ICustomerpersonal.getsiblingsDetailsDisplay(CustID);
        }

        public ArrayList getAstroDetailsDisplay([FromUri]long? CustID)
        {
            return this.ICustomerpersonal.getAstroDetailsDisplay(CustID);
        }

        public ArrayList getPropertyDetailsDisplay([FromUri]long? CustID)
        {
            return this.ICustomerpersonal.getPropertyDetailsDisplay(CustID);
        }

        public ArrayList getRelativeDetailsDisplay([FromUri]long? CustID)
        {
            return this.ICustomerpersonal.getRelativeDetailsDisplay(CustID);
        }

        public ArrayList getReferenceViewDetailsDisplay([FromUri]long? CustID)
        {
            return this.ICustomerpersonal.getReferenceViewDetailsDisplay(CustID);
        }

        public ArrayList GetphotosofCustomer(string Custid, int? EmpID)
        {
            return this.ICustomerpersonal.GetphotosofCustomer(Custid, EmpID);
        }

        public ArrayList getCustomerPersonalMenuReviewStatus([FromUri]long? CustID, int? iReview, string SectionID)
        {
            return this.ICustomerpersonal.getCustomerPersonalMenu(CustID, iReview, SectionID);
        }

        //New Edit/View

        public ArrayList getCustomerPersonalSpouse_Details([FromUri]long? CustID)
        {
            return this.ICustomerpersonal.getCustomerPersonalSpouse_Details(CustID);
        }

        public ArrayList getCustomerPersonalContact_Details([FromUri]long? CustID)
        {
            return this.ICustomerpersonal.getCustomerPersonalContact_Details(CustID);
        }

        public ArrayList getCustomerPersonaloffice_purpose([FromUri] string flag, [FromUri]string ID, [FromUri] string AboutProfile, [FromUri] int? IsConfidential, [FromUri] int? HighConfendential)
        {
            return this.ICustomerpersonal.getCustomerPersonaloffice_purpose(flag, ID, AboutProfile, IsConfidential, HighConfendential);
        }

        public ArrayList getCustomerprofilesettingDetails([FromUri]long? CustID)
        {
            return this.ICustomerpersonal.CustomerprofilesettingDetails(CustID);
        }

        public ArrayList getpersonaldetails_Customer([FromUri]long? CustID)
        {
            return this.ICustomerpersonal.personaldetails_Customer(CustID);
        }

        public ArrayList getViewAllCustomersSearch(int? EmpID, string SearchData, string ProfileIDStatus, int? StartIndex, int? EndIndex)
        {
            return this.ICustomerpersonal.ViewAllCustomersSearch(EmpID, string.IsNullOrEmpty(SearchData) ? string.Empty : SearchData, string.IsNullOrEmpty(ProfileIDStatus) ? string.Empty : ProfileIDStatus, StartIndex, EndIndex);
        }

        public ArrayList Search_ViewEditProfile([FromBody]ViewEditProfileSearch Mobj)
        {
            return this.ICustomerpersonal.Search_ViewEditProfile(Mobj);
        }

        public ArrayList getViewAllCustomersKMPLProfileID(int? EmpID, string SearchData)
        {
            return this.ICustomerpersonal.ViewAllCustomersKMPLProfileID(EmpID, SearchData);
        }

        public int getCustomerphotoRequestDisplay(string profileid, int? EMPID, long? ticketIDs)
        {
            return this.ICustomerpersonal.CustomerphotoRequestDisplay(profileid, EMPID, ticketIDs);
        }

        public ArrayList getCandidateContactdetailsRelationName(long? CustID, int? PrimaryMobileRel, int? PrimaryEmailRel, int? iflage)
        {
            return this.ICustomerpersonal.CandidateContactdetailsRelationName(CustID, PrimaryMobileRel, PrimaryEmailRel, iflage);
        }

        public int getCandidateContactsendmailtoemailverify(long? CustID)
        {
            return this.ICustomerpersonal.CandidateContactsendmailtoemailverify(CustID);
        }

        public ArrayList getProfileIDPlaybutton(string ProfileID)
        {
            return this.ICustomerpersonal.ProfileIDPlaybutton(ProfileID);
        }

        public ArrayList getViewAllCustomersSettledeleteinfo(string CustID, string typeofdata)
        {
            return this.ICustomerpersonal.ViewAllCustomersSettledeleteinfo(CustID, typeofdata);
        }

        //

        public string getEducationProfession_AboutYourself(string CustID, string AboutYourself, int? flag)
        {
            return this.ICustomerpersonal.getDiscribeYour(CustID, AboutYourself, flag, "[dbo].[usp_Education_Profession_AboutYourself_NewDesign]");
        }

        public string getParents_AboutMyFamily(string CustID, string AboutYourself, int? flag)
        {
            return this.ICustomerpersonal.getDiscribeYour(CustID, AboutYourself, flag, "[dbo].[usp_Parents_AboutMyFamily]");
        }

        public string getPartnerpreference_DiscribeYourPartner(string CustID, string AboutYourself, int? flag)
        {
            return this.ICustomerpersonal.getDiscribeYour(CustID, AboutYourself, flag, "[dbo].[usp_Partnerpreference_DiscribeYourPartner]");
        }
        public ArrayList getNoPhotoStatus(long custid) { return this.ICustomerpersonal.getNoPhotoStatus(custid); }
    }
}