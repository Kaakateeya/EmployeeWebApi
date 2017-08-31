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

    public class ImpSmallPages : ISmallPages
    {
        smallPageDal dobj = new smallPageDal();
        public ArrayList getMacIpValues(macIPInput mobj) { return dobj.getMacIpValuesDal(mobj, "usp_BranchIpaddress"); }
        public Tuple<int, ArrayList> matchMeetingEntryForm(matchMeetingEntryForm mobj) { return dobj.matchMeetingEntryFormDal(mobj, "Usp_CreateMatchmeeting"); }
        public Tuple<int, ArrayList> EmpDetailsNew(string profileID, int BridegroomFlag) { return dobj.EmpDetailsNew(profileID, BridegroomFlag, "usp_reg_GetMatchMeetDetailsNew"); }
        public Tuple<ArrayList, int, int, int, int> GetmatchMeetingData(int? brideCustID, int? groomCustID) { return dobj.EmpDetailsNew(brideCustID, groomCustID, "Usp_CheckExpressInterestDetails"); }

        public int checkMarketingTicket(string ticketID) { return dobj.checkMarketingTicketDal(ticketID, "usp_check_marketingTicket"); }
        public int brokerFormInsert(brokerEntryForm mobj) { return dobj.brokerFormInsertDal(mobj, "usp_insert_brokerEntryForm"); }
        public List<MyassignedPhotosOutPut> myAssignedPhotos(myassignedPhotoInputMl mobj) { return dobj.myAssignedPhotosDal(mobj, "usp_Select_Reports_MyAssignedPhotos"); }
        public int myAssignedPhotosSubmit(myassignPhotoSubmit mobj) { return dobj.myAssignedPhotosSubmitDal(mobj, "Usp_update_UploadedExtractedPhoto"); }
        public List<UnassignedPhotoSelect> unassignPhotoSelect(UnassignPhotoSelect mobj) { return dobj.unassignPhotoSelectDal(mobj, "usp_Select_Reports_unassignedphotos"); }
        public int assignPhotos(long? Empid, string PhotoIDs) { return dobj.assignPhotosDal(Empid, PhotoIDs, "usp_insert_assignningPhotosToEmp"); }
        public List<GetEmployeeList> employeeList(GetEmployeeListRequest mobj) { return dobj.employeeListDal(mobj, "usp_Select_Reports_Employee_NewDesign"); }
        public int employeeCreation(EmployeeCreationInput mobj) { return dobj.employeeCreation(mobj, "usp_insert_createEmployee"); }
        public string getLoginName(int intHomeBrchID) { return dobj.getLoginNameDal(intHomeBrchID, "usp_createEmpUserId"); }
        public EmpAssignCounts getEmpWorkAssignCounts(int EmpID) { return dobj.getEmpWorkAssignCountsDal(EmpID, "usp_GetEmpCounts"); }
        public int setEmpAssignCounts(EmpAssignCounts mobj) { return dobj.setEmpAssignCountsDal(mobj, "usp_InsertViewEditEmplist"); }
        public ArrayList loginLogOutReport(EmpLoginLogoutReportML mobj) { return dobj.loginLogOutReportDal(mobj, "usp_Reports_EmployeeLogIn_Details"); }
        public int getinsertImagepath(long whereId, string strvalue, string flag) { return dobj.getinsertImagepathDal(whereId, strvalue, flag, "usp_insertSingleValues"); }


        public ArrayList empWorksheet(EmpWorkSheetMl mobj) { return dobj.empWorksheetDal(mobj, "usp_Reports_EmpActivityLog"); }
        public int empLogout(int empid) { return dobj.empLogoutDal(empid, "usp_Emp_LogOut"); }
        public ArrayList mediaterRegValidation(mediaterRegFormValidation mobj) { return dobj.mediaterRegValidationDal(mobj, "usp_BrokerProfileRegistaration_Validation"); }
        public ArrayList EmployeeCommunicationLogNew(CommunicationRequest mobj) { return dobj.EmployeeCommunicationLogDal(mobj, "[dbo].[Usp_Select_Communicationlog_NewDesign]"); }
        public int deleteSettleForm(int settleID) { return dobj.deleteSettleFormDal(settleID, "[dbo].[usp_UpdateDeleteSettlementForm]"); }
        public ArrayList ViewSuccessStories(viewSuccessStoriesRequest sObj) { return dobj.ViewSuccessStoriesDal(sObj, "[dbo].[usp_Reports_ViewSuccess]"); }
        public Tuple<int, ArrayList> GetbrideGroomData(string profileID, int iFlag) { return dobj.GetbrideGroomDataDal(profileID, iFlag, "[dbo].[usp_reg_GetMatchMeetDetails]"); }
        public Tuple<int, ArrayList> GetbrideGroomDataNew(string profileID, int iFlag) { return dobj.GetbrideGroomDataDal(profileID, iFlag, "[dbo].[usp_reg_GetMatchMeetDetails_New]"); }

        public int createSuccessStories(createSuccessStoryRequest mobj) { return dobj.createSuccessStoriesDal(mobj, "[dbo].[Usp_Successstories]"); }
        public int deleteSucessStories(string sucessStoryID, string brideProfileID, string groomProfileID) { return dobj.deleteSucessStoriesDal(sucessStoryID,brideProfileID, groomProfileID, "[dbo].[Usp_Successstories_delete]"); }
        public ArrayList matchMeetingCountReport(matchMeetingCountMl mobj) { return dobj.matchMeetingCountReportDal(mobj, "[dbo].[usp_Reports_MatchMeetingCount]"); }
        public ArrayList matchMeetingCountInfo(matchMeetingCountInfoMl mobj) { return dobj.matchMeetingCountInfoDal(mobj, "[dbo].[usp_Reports_MatchMeeting_View]"); }
        public ArrayList ProfileDeleteProfilesReport(settleDeleteProfilesReport mobj) { return dobj.ProfileDeleteProfilesReportDal(mobj, "[dbo].[usp_Reports_SettledandDeleteProf]"); }
        //public int restoreProfile(restoreProfile mobj) { return dobj.restoreProfileDal(mobj, "[dbo].[Usp_InsertRestoreRecord]"); }
        public int checkStatus(string whereID, string flag) { return dobj.checkStatusDal(whereID, flag, "[dbo].[usp_checkStatus]"); }
    }
}