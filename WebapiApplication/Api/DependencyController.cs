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
    public class DependencyController : ApiController
    {

        private readonly IDependency IDependency; public DependencyController() : base() { this.IDependency = new Impdependency_injection(); }
        public List<CountryDependency> getCountryDependency([FromUri]string dependencyName, [FromUri]string dependencyValue) { return this.IDependency.getCountryDependency(dependencyName, dependencyValue, "[dbo].[Country_dependency_injection]"); }
        public List<CountryDependency> getEducationDependency([FromUri]string dependencyName, [FromUri]string dependencyValue) { return this.IDependency.getCountryDependency(dependencyName, dependencyValue, "[dbo].[Education_dependency_injection]"); }
        public List<CountryDependency> getProfessionDependency([FromUri]string dependencyName, [FromUri]string dependencyValue) { return this.IDependency.getCountryDependency(dependencyName, dependencyValue, "[dbo].[Profession_dependency_injection]"); }
        public List<CountryDependency> getDropdown_filling_values([FromUri]string strDropdownname) { return this.IDependency.getDropdown_filling_values(strDropdownname); }
        public List<CountryDependency> getDropdownValues_dependency_injection([FromUri]string dependencyName, [FromUri]string dependencyValue, [FromUri] string dependencyflagID) { return this.IDependency.ImpgetDropdownValues_dependency_injection(dependencyName, dependencyValue, dependencyflagID); }
        public List<CountryDependency> getCountryDependencyCountryCode([FromUri]string dependencyName, [FromUri]string dependencyValue) { return this.IDependency.getCountryDependencyCountryCode(dependencyName, dependencyValue, "[dbo].[Country_dependency_injection]"); }

    }
}