using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Web.Http;
using WebapiApplication.DAL;
using WebapiApplication.Implement;
using WebapiApplication.Interfaces;
using WebapiApplication.ML;
using WebapiApplication.UserDefinedTable;

namespace WebapiApplication.Api
{
    public class RegistrationController : ApiController
    {
        private readonly IRegistration IRegistration;

        public RegistrationController()
            : base()
        {
            this.IRegistration = new ImpRegistration();
        }

        public int? RegisterCustomerHomepages(PrimaryInformationMl CustomerHome)
        {
            return this.IRegistration.RegisterCustomerHomepages(CustomerHome);
        }

        public ArrayList EmployeeRegisterCustomerHomepages(PrimaryInformationMl CustomerHome)
        {
            return this.IRegistration.EmployeeRegisterCustomerHomepages(CustomerHome);
        }

        public ArrayList EmployeeRegisterCustomerHomepagesBrokerProfiles(PrimaryInformationMl CustomerHome)
        {
            return this.IRegistration.EmployeeRegisterCustomerHomepagesBrokerProfiles(CustomerHome);
        }

        public int? CustomerRegProfileDetails([FromBody]JObject CustomerHome)
        {
            TDetailedRegistration TCustomer = CustomerHome["GetDetails"].ToObject<TDetailedRegistration>();
            UpdatePersonaldetails customerpersonaldetails = CustomerHome["customerpersonaldetails"].ToObject<UpdatePersonaldetails>();
            List<TDetailedRegistration> lstProf = new List<TDetailedRegistration>();
            lstProf.Add(TCustomer);
            customerpersonaldetails.dtTableValues = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtCustomerRegProfileDetails(), lstProf);
            return this.IRegistration.CustomerRegProfileDetails_Myprofile(customerpersonaldetails);
        }

        public ArrayList getCustomermissindDatagetting(long? CustomerCustID)
        {
            return this.IRegistration.CustomermissindDatagetting(CustomerCustID);
        }

        public string getPassword(string Username)
        {
            return this.IRegistration.BgetPassword(Username);
        }

        public ArrayList getloginCustinformation(string Username, string Password, int? iflag)
        {
            return this.IRegistration.DGetloginCustinformation(Username, Password, iflag);
        }

        public int getCheckUserPwd(string Username, string Password)
        {
            return this.IRegistration.CheckUserPwd(Username, Password);
        }

        public int getUpdateEmplogintoCustomersite(int empid, string ProfileID, string Narration)
        {
            return this.IRegistration.UpdateEmplogintoCustomersite(empid, ProfileID, Narration);
        }
    }
}