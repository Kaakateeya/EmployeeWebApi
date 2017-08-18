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
    }
}