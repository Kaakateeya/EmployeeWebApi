using System.Web.Http;
using WebapiApplication.Implement;
using WebapiApplication.Interfaces;
using WebapiApplication.ML;

namespace WebapiApplication.Api
{
    public class CustomerServiceController : ApiController
    {
        private readonly ICustSearchService ICustSearchService;
        public CustomerServiceController()
            : base()
        {
            this.ICustSearchService = new ImpCustSearchService();
        }

        public int CustomerServiceBal([FromBody]CustSearchMl MobjViewprofile)
        {
            return this.ICustSearchService.CustomerServiceDal(MobjViewprofile);
        }
    }
}