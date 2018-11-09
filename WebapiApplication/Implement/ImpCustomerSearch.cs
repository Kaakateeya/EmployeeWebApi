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
    public class ImpCustomerSearch : ICustomerSearch
    {

        public PrimaryInformationMl Partnerpreferencedetails_CustomerSearch(int? CustID, int? EmpID, Int64? searchresultID) { return new CustomerSearch().DgetPartnerpreferencedetails(CustID, EmpID, searchresultID, "[dbo].[usp_GetCustomerinfo_Forsearches_NewDesign]"); }
        public List<QuicksearchResultML> ProfileIdsearch(ProfileIDSearch ProfileIDSearch) { return new CustomerSearch().ProfileIdsearch(ProfileIDSearch, "[dbo].[usp_Customers_ProfileSearch_Profor]"); }
        public List<QuicksearchResultML> GeneralandAdvancedSearch(PrimaryInformationMl search) { return new CustomerSearch().GeneralandAdvancedSearch(search, "[dbo].[usp_Customers_GeneralSearch_Perfor]"); }
        public List<QuicksearchResultML> CustomerHomePageSearch(CustomerHomePageSearch search) { return new CustomerSearch().CustomerHomePageSearch(search, "[dbo].[usp_Customers_GeneralSearch_Perfor_HomePage]"); }
        public List<QuicksearchResultML> CustomerAdvanceGeneralandSavedSearch(PrimaryInformationMl primaryInfo, DataTable dtTableValues) { return new CustomerSearch().CustomerGeneralandAdvancedSavedSearch(primaryInfo, dtTableValues, "[dbo].[usp_AdvSearch_Customer]", "@dtAdvsearch", "[dbo].[usp_Customers_GeneralSearch_Perfor]"); }
        public List<QuicksearchResultML> CustomerProfileIDSavedSearch(ProfileIDSearch primaryInfo, DataTable dtTableValues) { return new CustomerSearch().CustomerProfileIDSavedSearch(primaryInfo, dtTableValues, "[dbo].[usp_ProfileIDsearch_Customer]", "@dtProfileIDsearch", "[dbo].[usp_Customers_ProfileSearch_Profor]"); }
        public List<SearchResultSaveEditML> SearchResultSaveEdit(long? Cust_ID, string SaveSearchName, int? iEditDelete) { return new CustomerSearch().SearchResultSaveEdit(Cust_ID, SaveSearchName, iEditDelete, "[dbo].[usp_SearchResultSaveEdit]"); }
       
        //Employee Search Pages

        public GetPrimaryDataCustomerResponse PrimaryCustomerDataResponse(int? CustID, int? EmpID, int? SearchType) { return new CustomerSearch().GetPrimaryInformationDal(CustID, EmpID, SearchType, "[dbo].[usp_GetCustomerinfo_Forsearches_NewDesign]"); }
        public List<slideshowNew> ShowDataForEmployeeGeneral(EmployeeSearch employeesearch) { return new CustomerSearch().GetShowDataForGeneral(employeesearch, "[dbo].[usp_get_SearchResultSet1_Test_Profor_NewDesign]"); }


        public List<slideshowNew> ShowDataForEmployeeGeneral_Nocastebar(EmployeeSearch employeesearch) { return new CustomerSearch().GetShowDataForGeneral(employeesearch, "[dbo].[usp_get_SearchResultSet1_CasteNoBar_NewDesign]"); }


        public List<slideshowNew> ShowDataForEmployeeAdvanceSearch(EmployeeSearch employeesearch) { return new CustomerSearch().GetShowDataForAdvanced(employeesearch, "[dbo].[usp_get_AdvancedSearchResultSet1_Test_Profor_NewDesign]"); }
        public List<slideshowNew> ShowDataForEmployeeAdvanceSearch_Nocastebar(EmployeeSearch employeesearch) { return new CustomerSearch().GetShowDataForAdvanced(employeesearch, "[dbo].[usp_get_AdvancedSearchResultSet1_CasteNoBar_NewDesign]"); }
  
        
    }
}