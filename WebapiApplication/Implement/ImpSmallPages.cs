using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebapiApplication.Interfaces;
using System.Collections;
using WebapiApplication.DAL;
using WebapiApplication.ML;

namespace WebapiApplication.Implement
{
  
    public class ImpSmallPages:ISmallPages
    {
        smallPageDal dobj;
        public ArrayList getMacIpValues(macIPInput mobj) { return dobj.getMacIpValuesDal(mobj, "usp_BranchIpaddress"); }
    }
}