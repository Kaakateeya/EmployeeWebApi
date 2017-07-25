using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebapiApplication.Interfaces;
using WebapiApplication.Implement;
using System.Collections;
using WebapiApplication.ML;

namespace WebapiApplication.Api
{
    public class smallPagesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        //private readonly ISmallPages Iobj = new ImpSmallPages();
        private readonly ISmallPages Iobj;

        public smallPagesController():base()
        {
            Iobj = new ImpSmallPages();
        }

        public ArrayList MacIpValues(macIPInput mobj)
        {
            return Iobj.getMacIpValues(mobj);
        }

        public Tuple<int, ArrayList> matchMeetingEntryForm(matchMeetingEntryForm mobj)
        {
            return Iobj.matchMeetingEntryForm(mobj);
        }


        public Tuple<int, ArrayList> GetEmployeeName(string profileID, int BridegroomFlag)
        {
            return Iobj.EmpDetailsNew(profileID, BridegroomFlag);
        }

        public Tuple<ArrayList, int, int, int, int> GetmatchMeetingData(int? brideCustID,int? groomCustID)
        {
            return Iobj.GetmatchMeetingData(brideCustID, groomCustID);
        }

        public int GetcheckMarketingTicket(string ticketID)
        {
            return Iobj.checkMarketingTicket(ticketID);
        }

        public int brokerFormInsert(brokerEntryForm  mobj)
        {
            return Iobj.brokerFormInsert(mobj);
        }

    }
}