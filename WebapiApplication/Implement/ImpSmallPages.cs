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
        public Tuple<int, ArrayList> EmpDetailsNew(string profileID, int BridegroomFlag) { return dobj.EmpDetailsNew(profileID,BridegroomFlag,"usp_reg_GetMatchMeetDetailsNew"); }
        public Tuple<ArrayList, int, int, int, int> GetmatchMeetingData(int? brideCustID, int? groomCustID) { return dobj.EmpDetailsNew(brideCustID, groomCustID, "Usp_CheckExpressInterestDetails"); }

        public int checkMarketingTicket(string ticketID) { return dobj.checkMarketingTicketDal(ticketID, "usp_check_marketingTicket"); }
        public int brokerFormInsert(brokerEntryForm mobj) { return dobj.brokerFormInsertDal(mobj, "usp_insert_brokerEntryForm"); }
        public List<MyassignedPhotosOutPut> myAssignedPhotos(myassignedPhotoInputMl mobj) { return dobj.myAssignedPhotosDal(mobj, "usp_Select_Reports_MyAssignedPhotos"); }
    }
}