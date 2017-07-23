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
        smallPageDal dobj=new smallPageDal();
        public ArrayList getMacIpValues(macIPInput mobj) { return dobj.getMacIpValuesDal(mobj, "usp_BranchIpaddress"); }
        public Tuple<int, ArrayList> matchMeetingEntryForm(matchMeetingEntryForm mobj) { return dobj.matchMeetingEntryFormDal(mobj, "Usp_CreateMatchmeeting"); }
        public ArrayList EmpDetailsNew(string profileID, int BridegroomFlag) { return dobj.EmpDetailsNew(profileID, BridegroomFlag, "usp_reg_GetMatchMeetDetailsNew"); }

    }
}