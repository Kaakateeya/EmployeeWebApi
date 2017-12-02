using System;
using System.Collections.Generic;
using System.Web.Http;
using WebapiApplication.DAL;
using WebapiApplication.Implement;
using WebapiApplication.Interfaces;
using WebapiApplication.ML;

namespace WebapiApplication.Api
{
    public class DBController : ApiController
    {
        private readonly IuserLogin IuserLogin;
        public DBController()
            : base()
        {
            this.IuserLogin = new ImpUserlogin();
        }

        public List<userLoginML> userLogin([FromBody]CustLoginMl id)
        {
            return this.IuserLogin.DGetLogininformationdetails(id);
        }

        public Tuple<EmpDetailsMl, List<MenuItem>, List<ScrollText>, List<StarRating>, int> getValidateLoginNew(string LoginName, string Password, string sMAC)
        {
            return this.IuserLogin.ValidateLoginNew(LoginName, Commonclass.Encrypt(Password), sMAC);
        }
    }
}