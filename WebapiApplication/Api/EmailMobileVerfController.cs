using System.Web.Http;
using WebapiApplication.Implement;
using WebapiApplication.Interfaces;
using WebapiApplication.ML;

namespace WebapiApplication.Api
{
    public class EmailMobileVerfController : ApiController
    {
        private readonly IEmailMobileVerf IEmailMobile;
        public EmailMobileVerfController()
            : base()
        {
            this.IEmailMobile = new ImpEmailMobileVerf();
        }

        [HttpGet]
        public VerifiedContactInformationML EmailMobileVerfRequest([FromUri]int id) { return this.IEmailMobile.DgetMobileEmailVerification(id); }
    }
}