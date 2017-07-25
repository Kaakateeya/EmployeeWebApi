using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebapiApplication.ML
{
    public class macIPInput
    {
        public int? Religion { get; set; }
        public int? BranchID { get; set; }
        public string Ipaddress { get; set; }
        public int? flag { get; set; }
    }

    public class matchMeetingEntryForm
    {
        public string BrideprofileID { get; set; }
        public string GroomprofileID { get; set; }
        public DateTime? MeetingDate { get; set; }
        public string MeetingPlace { get; set; }
        public string BrideRelationName { get; set; }
        public string GroomRelaionName { get; set; }
        public Int64 EmpID { get; set; }
        public string Notes { get; set; }
        public Int64? CreatedEMPID { get; set; }
        public int? BCode { get; set; }
        public string BLand { get; set; }
        public string BMobile { get; set; }
        public int? GCode { get; set; }
        public string GLand { get; set; }
        public string GMobile { get; set; }
    }
    public class brokerEntryForm
    {
        public string name { get;set; }
        public string place { get; set; }
        public string email { get; set; }
        public string mobileNumber { get; set; }
        public int? brokerId { get; set; }
        public int? flag { get; set; }
      
    }


}




