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

        public int? Region { get; set; }
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

    public class Emplanding_counts
    {

        public string TableName { get; set; }
        public string Profileid { get; set; }
        public string Name { get; set; }
        public int? ServiceCount { get; set; }
        public string Date { get; set; }
        public string Photo { get; set; }
        public int? PaidStatus { get; set; }
        public string Reason4InActive { get; set; }

        public string Tickets { get; set; }

        public long? TicketID { get; set; }

        public string SAFormStatus { get; set; }

        public bool? ReadStatus { get; set; }

        public int? NotificationID { get; set; }
      
    }


   
}