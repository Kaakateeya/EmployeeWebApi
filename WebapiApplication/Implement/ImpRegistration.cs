using System;
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
    public class ImpRegistration : IRegistration
    {
        public int? RegisterCustomerHomepages(PrimaryInformationMl Mobj) { return new RegistrationDAL().DRegisterCustomerHomepages(Mobj, "[dbo].[usp_Cust_QuickRegistration_Customer]"); }
        public ArrayList EmployeeRegisterCustomerHomepages(PrimaryInformationMl Mobj) { return new RegistrationDAL().EmployeeRegisterCustomerHomepages(Mobj, "[dbo].[usp_Cust_QuickRegistration_Customer_New]"); }

        public int CustomerRegProfileDetails_Myprofile(UpdatePersonaldetails Mobj) { return new RegistrationDAL().DgetCustomerRegProfileDetails_Myprofile(Mobj, "[dbo].[usp_CustomerRegProfiledetails-Customer_NewDesign]"); }
        public ArrayList CustomermissindDatagetting(long? CustomerCustID) { return new RegistrationDAL().CustomermissindDatagetting(CustomerCustID, "[dbo].[usp_CustomermissindDatagetting_Customer]"); }

        public string BgetPassword(string Username) { return new RegistrationDAL().BgetPassword(Username); }
        public ArrayList DGetloginCustinformation(string Username, string Password, int? iflag) { return new RegistrationDAL().DGetloginCustinformation(Username, Password, iflag); }
        public int CheckUserPwd(string Username, string Password) { return new RegistrationDAL().CheckUserPwd(Username, Password); }


    }
}