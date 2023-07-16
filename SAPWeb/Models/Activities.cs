using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SAPWeb.Models
{

    public class ActivitiesDefault
    {
        public ActivitiesDefault()
        {
            activities = new List<Activities>();
        }
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<Activities> activities { get; set; }
    }

    public class Activities
    {
        public string EMPID { get; set; }
        public int ActivityCode { get; set; }
        public string ActivityDate { get; set; }
        public string CardCode { get; set; }
        public string StartDate { get; set; }
        public int? ParentObjectId { get; set; } //Opportunity ID
        public int? SalesOpportunityId { get; set; }
        public int? SalesOpportunityLine { get; set; }
        public string ParentObjectType { get; set; } //Opportunity ObjType
        public Int64? ContactPersonCode { get; set; }
        //public string InactiveFlag { get; set; }
        public string Closed { get; set; }
        public string CloseDate { get; set; }
        public int? ActivityType { get; set; }
        public string Subject { get; set; }
        public string Details { get; set; }
        public string Notes { get; set; }
        public string U_MODTRAVEL { get; set; }
        public string U_FromLoc { get; set; }
        public string U_ToLoc { get; set; }
        public double? U_Kilometer { get; set; }
        public double? U_Rate { get; set; }
        public string U_FollowUpDate { get; set; }
        public string U_FollowUpTime { get; set; }
        public string U_FolloupRemarks { get; set; }
        public string StartTime { get; set; }
        public string EndDueDate { get; set; }
        public string EndTime { get; set; }
        public string U_StartLat { get; set; }
        public string U_StartLong { get; set; }
        public string U_EndLat { get; set; }
        public string U_EndLong { get; set; }
        public double? U_CallHrs { get; set; }
        public double? U_TotCallHrs { get; set; }
        public string U_JointCall { get; set; }
        public int? AttachmentEntry { get; set; }
        public int? HandledByEmployee { get; set; }
        public int? PreviousActivity { get; set; }
        public string U_CASTDT { get; set; }    //Call Attend Start Date
        public string U_CAENDT { get; set; }    //Call Attend End Date
        public string U_CASTTIME { get; set; }  //Call Attend Start Time
        public string U_CAENTIME { get; set; }  //Call Attend End Time
        public string U_CASTLAT { get; set; }   //Call Attend Start Lattitude
        public string U_CAENLAT { get; set; }   //Call Attend End Lattitude
        public string U_CASTLONG { get; set; }  //Call Attend Start Longitude
        public string U_CAENLONG { get; set; }  //Call Attend End Longitude
        public string U_Remarks { get; set; }   //Activity Remarks
        public string U_EMPID { get; set; }
        public string U_ISJCC { get; set; }
        public string U_REJECTREMARK { get; set; }
        public string U_Status { get; set; }
        public int? DocEntry { get; set; }
        public string DocType { get; set; }
        public string U_Reason { get; set; }
        public string U_PORTALMODULE { get; set; }
        public string U_COMPLAINNO { get; set; }
        public string Priority { get; set; }
        public string U_SYSTEMID { get; set; }
        public string U_FROMWHERE { get; set; }

        public string U_ONEWAYTRIPMODE { get; set; }
        public double U_ONEWAYTRIPMODERATE { get; set; }
        public double U_ONEWAYTRIPAMT { get; set; }
        public string U_ONEWAYTRIPKM { get; set; }

        public string U_RETURNTRIPMODE { get; set; }
        public double U_RETURNTRIPMODERATE { get; set; }
        public double U_RETURNTRIPAMT { get; set; }
        public string U_RERURNTRIPKM { get; set; }       
       
        public string U_TRIPSTARTPLACE { get; set; }
        public string U_TRIPSTARTMANUALLY { get; set; }
        public string U_TRIPENDPLACE { get; set; }
        public string U_TRIPENDMANUALLY { get; set; }

        public string U_CALLSTARTPLACE { get; set; }
        public string U_CALLSTARTMANUALLY { get; set; }       
        public string U_CALLENDPLACE { get; set; }
        public string U_CALLENDMANUALLY { get; set; }

        public string U_RequestStatus { get; set; }
        public string U_JOINTCALLTODOFLAG { get; set; }

        public string U_SPECIFICCRITERIA { get; set; } 

        public List<UploadFile> AttechmentFiles { get; set; }
    }

    public class UploadFile
    {
        public string Subject { get; set; }
        public string Notes { get; set; }
        public string AttachFileName { get; set; }
        public string AttachPath { get; set; }

        public string Base64 { get; set; }
        public string FileName { get; set; }
        public string Extention { get; set; }
    }

    public class ParamActivities
    {
        public string EMPID { get; set; }
        public string ActCode { get; set; }
    }

    public class ParamActivityList
    {
        
        public string EMPID { get; set; }
        public string STATUS { get; set; }
    }

    public class ParamActivityListRedirect
    {
        
        public string EMPID { get; set; }
        public string STATUS { get; set; }
        public string REPORTTYPE { get; set; }
    }

    public class ActivityList
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public DataTable tab { get; set; }
    }

    public class ParamActivityApprovalList
    {
        
        public string EMPID { get; set; }
        public string CLOSED { get; set; }
        public string ISJCC { get; set; }
        public string Status { get; set; }
        public string PrevActivityStatus { get; set; }
    }

    public class ActivitiesApproval
    {
        public string EMPID { get; set; }
        public int ActivityCode { get; set; }
        public string Closed { get; set; }
        public string U_REJECTREMARK { get; set; }
        public string U_Status { get; set; }
        public string U_PORTALMODULE { get; set; }
        public string U_COMPLAINNO { get; set; }
        public string U_SYSTEMID { get; set; }
        public string U_FROMWHERE { get; set; }
    }

    public class ActivitiesApprovalTransfer
    {
        public string EMPID { get; set; }
        public int ActivityCode { get; set; }
        public string Closed { get; set; }
        public string U_REJECTREMARK { get; set; }
        public string U_Status { get; set; }
        public string U_PORTALMODULE { get; set; }
        public string U_COMPLAINNO { get; set; }
        public int? PreviousActivityCode { get; set; }
        public string U_SYSTEMID { get; set; }
    }

    public class DynamicTable
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public DataTable tab { get; set; }
    }

    public class ActivitiesTransfer
    {
        public string EMPID { get; set; }
        public string ActivityCode { get; set; }
        public string EmpCode { get; set; }
        public string U_Remarks { get; set; }
        public string U_Reason { get; set; }
        public string SYSTEMID { get; set; }
    }

    #region Activity
    public class ActivityDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<Activity> activities { get; set; }
    }

    [Serializable]
    public class Activity
    {
        public string EMPID { get; set; }
        public int ActivityCode { get; set; }
        public string ActivityDate { get; set; }
        public string CardCode { get; set; }
        public string StartDate { get; set; }
        public int? ParentObjectId { get; set; } //Opportunity ID
        public int? SalesOpportunityId { get; set; }
        public int? SalesOpportunityLine { get; set; }
        public string ParentObjectType { get; set; } //Opportunity ObjType
        public Int64? ContactPersonCode { get; set; }
        //public string InactiveFlag { get; set; }
        public string Closed { get; set; }
        public string CloseDate { get; set; }
        public int? ActivityType { get; set; }
        public string Subject { get; set; }
        public string Details { get; set; }
        public string Notes { get; set; }
        public string U_MODTRAVEL { get; set; }
        public string U_FromLoc { get; set; }
        public string U_ToLoc { get; set; }
        public double? U_Kilometer { get; set; }
        public double? U_Rate { get; set; }
        public string U_FollowUpDate { get; set; }
        public string U_FollowUpTime { get; set; }
        public string U_FolloupRemarks { get; set; }
        public string StartTime { get; set; }
        public string EndDueDate { get; set; }
        public string EndTime { get; set; }
        public string U_StartLat { get; set; }
        public string U_StartLong { get; set; }
        public string U_EndLat { get; set; }
        public string U_EndLong { get; set; }
        public double? U_CallHrs { get; set; }
        public double? U_TotCallHrs { get; set; }
        public string U_JointCall { get; set; }
        public int? AttachmentEntry { get; set; }
        public int? HandledByEmployee { get; set; }
        public int? PreviousActivity { get; set; }
        public string U_CASTDT { get; set; }    //Call Attend Start Date
        public string U_CAENDT { get; set; }    //Call Attend End Date
        public string U_CASTTIME { get; set; }  //Call Attend Start Time
        public string U_CAENTIME { get; set; }  //Call Attend End Time
        public string U_CASTLAT { get; set; }   //Call Attend Start Lattitude
        public string U_CAENLAT { get; set; }   //Call Attend End Lattitude
        public string U_CASTLONG { get; set; }  //Call Attend Start Longitude
        public string U_CAENLONG { get; set; }  //Call Attend End Longitude
        public string U_Remarks { get; set; }   //Activity Remarks
        public string U_EMPID { get; set; }
        public string U_ISJCC { get; set; }
        public string U_REJECTREMARK { get; set; }
        public string U_Status { get; set; }
        public int? DocEntry { get; set; }
        public string DocType { get; set; }
        public string U_Reason { get; set; }
        public string U_PORTALMODULE { get; set; }
        public string U_SYSTEMID { get; set; }
        public string U_FROMWHERE { get; set; }
        public string U_RequestStatus { get; set; }

        public string U_ONEWAYTRIPMODE { get; set; }
        public double U_ONEWAYTRIPMODERATE { get; set; }
        public string U_TRIPSTARTPLACE { get; set; }
        public string U_TRIPSTARTMANUALLY { get; set; }
        public string U_CALLSTARTPLACE { get; set; }
        public string U_CALLSTARTMANUALLY { get; set; }
        public string U_RETURNTRIPMODE { get; set; }
        public double U_RETURNTRIPMODERATE { get; set; }
        public string U_CALLENDPLACE { get; set; }
        public string U_CALLENDMANUALLY { get; set; }
        public string U_TRIPENDPLACE { get; set; }
        public string U_TRIPENDMANUALLY { get; set; }
        public double U_ONEWAYTRIPAMT { get; set; }
        public string U_ONEWAYTRIPKM { get; set; }
        public double U_RETURNTRIPAMT { get; set; }
        public string U_RERURNTRIPKM { get; set; }       

        public List<ActivityUploadFile> AttechmentFiles { get; set; }
    }

    [Serializable]
    public class ActivityUploadFile
    {
        public string Base64 { get; set; }
        public string FileName { get; set; }
        public string Extention { get; set; }
    }

    #endregion

    public class ActivityHistoryDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public DataTable tab { get; set; }
    }

    public class ParamActivityHistory
    {
        public string EMPID { get; set; }
        public string ACTIVITYCODE { get; set; }
        public string PORTALMODULE { get; set; }
    }

    #region GetActivity

    public class ParamActivity
    {
        public string EMPID { get; set; }
        public string ActivityCode { get; set; }
    }

    #endregion

    public class ParamOpportunityNameByOpportunityNo
    {
        public string EMPID { get; set; }
        public string OPPORTUNITYNO { get; set; }
        public string STATUS { get; set; }
        public string REPORTTYPE { get; set; }
    }

}
