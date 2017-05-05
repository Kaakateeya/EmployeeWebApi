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
    public class CustomerServiceController : ApiController
    {
        private readonly ICustSearchService ICustSearchService; public CustomerServiceController() : base() { this.ICustSearchService = new ImpCustSearchService(); }
        public int CustomerServiceBal([FromBody]CustSearchMl MobjViewprofile) { return this.ICustSearchService.CustomerServiceDal(MobjViewprofile); }
    }
}