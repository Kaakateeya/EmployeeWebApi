using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using WebapiApplication.DAL;
using WebapiApplication.Implement;
using WebapiApplication.Interfaces;
using WebapiApplication.ML;
using WebapiApplication.UserDefinedTable;

namespace WebapiApplication.Api
{
    public class CustomerSearchController : ApiController
    {
        private readonly ICustomerSearch ICustomerSearch;
        public CustomerSearchController()
            : base()
        {
            this.ICustomerSearch = new ImpCustomerSearch();
        }


        public PrimaryInformationMl getPartnerpreferencedetails(int? CustID, int? EmpID, Int64? searchresultID)
        {
            return this.ICustomerSearch.Partnerpreferencedetails_CustomerSearch(CustID, EmpID, searchresultID);
        }

        public List<QuicksearchResultML> CustomerProfileIdsearch(ProfileIDSearch ProfileIDSearch)
        {
            return this.ICustomerSearch.ProfileIdsearch(ProfileIDSearch);
        }

        public List<QuicksearchResultML> CustomerGeneralandAdvancedSearch(PrimaryInformationMl search)
        {
            return this.ICustomerSearch.GeneralandAdvancedSearch(search);
        }

        public List<QuicksearchResultML> CustomerHomePageSearch(CustomerHomePageSearch Search)
        {
            return this.ICustomerSearch.CustomerHomePageSearch(Search);
        }

        public List<QuicksearchResultML> CustomerGeneralandAdvancedSavedSearch([FromBody]JObject Savesearch)
        {
            Newsavedserach Searchsaved = Savesearch["GetDetails"].ToObject<Newsavedserach>();
            PrimaryInformationMl primaryInfo = Savesearch["customerpersonaldetails"].ToObject<PrimaryInformationMl>();
            List<Newsavedserach> lstSave = new List<Newsavedserach>();
            lstSave.Add(Searchsaved);
            DataTable dtTableValues = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtCustomerGeneralandAdvancedSavedSearch(), lstSave);
            return this.ICustomerSearch.CustomerAdvanceGeneralandSavedSearch(primaryInfo, dtTableValues);
        }

        public List<QuicksearchResultML> CustomerProfileIDSavedSearch([FromBody]JObject Savesearch)
        {
            Newsavedserach Searchsaved = Savesearch["GetDetails"].ToObject<Newsavedserach>();
            ProfileIDSearch primaryInfo = Savesearch["customerpersonaldetails"].ToObject<ProfileIDSearch>();
            List<Newsavedserach> lstSave = new List<Newsavedserach>();
            lstSave.Add(Searchsaved);
            DataTable dtTableValues = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtCustomerGeneralandAdvancedSavedSearch(), lstSave);
            return this.ICustomerSearch.CustomerProfileIDSavedSearch(primaryInfo, dtTableValues);
        }

        public List<SearchResultSaveEditML> getSearchResultSaveEdit(Int64? Cust_ID, string SaveSearchName, int? iEditDelete)
        {
            return this.ICustomerSearch.SearchResultSaveEdit(Cust_ID, SaveSearchName, iEditDelete);
        }

        // Employee Searches

        public GetPrimaryDataCustomerResponse getPrimaryCustomerDataResponse(string ProfileID, int? EmpID, int? SearchType)
        {
            return this.ICustomerSearch.PrimaryCustomerDataResponse(Commonclass.GetProfileIDCustID(10, Convert.ToString(ProfileID)), EmpID, SearchType);
        }

        public List<slideshowNew> ShowDataForEmployeeGeneral([FromBody]JObject CgetDetails)
        {
            TGeneralSearch generalsearch = CgetDetails["GetDetails"].ToObject<TGeneralSearch>();
            EmployeeSearch employeesearch = CgetDetails["customerpersonaldetails"].ToObject<EmployeeSearch>();
            List<TGeneralSearch> lstGeneral = new List<TGeneralSearch>();
            lstGeneral.Add(generalsearch);
            employeesearch.dtTableValues = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtcreateDatatableShowDataForEmployeeGeneral(), lstGeneral);
            return this.ICustomerSearch.ShowDataForEmployeeGeneral(employeesearch);
        }

        public List<slideshowNew> ShowDataForEmployeeAdvanceSearch([FromBody]JObject CgetDetails)
        {
            TAdvanceSearch advancesearch = CgetDetails["GetDetails"].ToObject<TAdvanceSearch>();
            EmployeeSearch employeesearch = CgetDetails["customerpersonaldetails"].ToObject<EmployeeSearch>();
            List<TAdvanceSearch> lstAdvance = new List<TAdvanceSearch>();
            lstAdvance.Add(advancesearch);
            employeesearch.dtTableValues = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtcreateDatatableShowDataForEmployeeAdvanceSearch(), lstAdvance);
            return this.ICustomerSearch.ShowDataForEmployeeAdvanceSearch(employeesearch);
        }
        ////// Employee General search for No castebar
        public List<slideshowNew> ShowDataForEmployeeGeneral_Nocastebar([FromBody]JObject CgetDetails)
        {
            TGeneralSearch generalsearch = CgetDetails["GetDetails"].ToObject<TGeneralSearch>();
            EmployeeSearch employeesearch = CgetDetails["customerpersonaldetails"].ToObject<EmployeeSearch>();
            List<TGeneralSearch> lstGeneral = new List<TGeneralSearch>();
            lstGeneral.Add(generalsearch);
            employeesearch.dtTableValues = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtcreateDatatableShowDataForEmployeeGeneral(), lstGeneral);
            return this.ICustomerSearch.ShowDataForEmployeeGeneral_Nocastebar(employeesearch);
        }

        ////// Employee Advanced search for No castebar
        public List<slideshowNew> ShowDataForEmployeeAdvanceSearch_Nocastebar([FromBody]JObject CgetDetails)
        {
            TAdvanceSearch advancesearch = CgetDetails["GetDetails"].ToObject<TAdvanceSearch>();
            EmployeeSearch employeesearch = CgetDetails["customerpersonaldetails"].ToObject<EmployeeSearch>();
            List<TAdvanceSearch> lstAdvance = new List<TAdvanceSearch>();
            lstAdvance.Add(advancesearch);
            employeesearch.dtTableValues = Commonclass.returnListDatatable(PersonaldetailsUDTables.dtcreateDatatableShowDataForEmployeeAdvanceSearch(), lstAdvance);
            return this.ICustomerSearch.ShowDataForEmployeeAdvanceSearch_Nocastebar(employeesearch);
        }

        /// <summary>
        /// keyword address and print binding
        /// </summary>
        /// <param name="profileID"></param>
        /// <param name="Relationship"></param>
        /// <param name="empID"></param>
        /// <returns></returns>
        public int getSearchPersonalvisit(string profileID, int? Relationship, int empID)   
        {
            return this.ICustomerSearch.getSearchPersonalvisit(profileID, Relationship,empID);
        }




    }
}