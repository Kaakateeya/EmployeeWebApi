using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


namespace WebapiApplication.ML
{
    public class ExpressInterestInsert
    {
        public int? FromCustID { get; set; }
        public long ? EmpID { get; set; }
        public DataTable dtExpInt { get; set; }
        public string emailaddress { get; set; }
    }
}