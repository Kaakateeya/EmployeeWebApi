using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebapiApplication.ML
{
    public class CountryDependency
    {
        public int? ID { set; get; }
        public string Name { set; get; }
        public string CountryCode { set; get; }
    }
    public class MyprofileBranchbind
    {
        public int? ID { set; get; }
        public string Name { set; get; }
        public string CountryCode { set; get; }
        public string BranchesName { set; get; }
        public int? Branch_ID { set; get; }
    }

    public class SendServiceProfileIds
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileID { get; set; }
        public int? ProfileStatusID { get; set; }
        public long? CustID { get; set; }
    }
}