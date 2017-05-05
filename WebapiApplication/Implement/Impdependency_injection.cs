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
    public class Impdependency_injection : IDependency
    {
        public List<CountryDependency> getCountryDependency(string dependencyName, string dependencyValue, string spName) { return new DependencyDAL().getCountryDependencyDAL(dependencyName, dependencyValue, spName); }
        public List<CountryDependency> getCountryDependencyCountryCode(string dependencyName, string dependencyValue, string spName) { return new DependencyDAL().getCountryDependencyCode(dependencyName, dependencyValue, spName); }
        public List<CountryDependency> getDropdown_filling_values(string strDropdownname) { return new DependencyDAL().getDropdown_filling_values(strDropdownname, "[dbo].[Dropdown_filling_values]"); }
        public List<CountryDependency> ImpgetDropdownValues_dependency_injection(string dependencyName, string dependencyValue, string dependencyflagID) { return new DependencyDAL().getDropdownValues_dependency_injection(dependencyName, dependencyValue, dependencyflagID, "[dbo].[DropdownValues_dependency_injection]"); }
    }
}