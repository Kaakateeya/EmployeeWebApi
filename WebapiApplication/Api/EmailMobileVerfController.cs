using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebapiApplication.ML;
using WebapiApplication.Implement;
using WebapiApplication.Interfaces;

namespace WebapiApplication.Api
{
    public class EmailMobileVerfController : ApiController
    {
        private readonly IEmailMobileVerf IEmailMobile; public EmailMobileVerfController() : base() { this.IEmailMobile = new ImpEmailMobileVerf(); }
        [HttpGet]
        public VerifiedContactInformationML EmailMobileVerfRequest([FromUri]int id) { return this.IEmailMobile.DgetMobileEmailVerification(id); }
    }
}