using System;
using System.Collections.Generic;
using System.Data;

namespace SAPWeb.Models
{
    public class LeaveTypeListDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<LeaveTypeList> LeaveList { get; set; }
    }
    public class LeaveDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public DataTable tab { get; set; }
    }
    public class LeaveTypeList
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double AvalibleBalance { get; set; }

    }
    public class ParamLeaveTypeList
    {
        public string SchemaName { get; set; }
        public string EMPID { get; set; }
    }
    public class LeaveRequestDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
    }

    public class A_LEVBCollection
    {
        public string SchemaName { get; set; }
        public string U_EMPID { get; set; }

        public int? DocEntry { get; set; }
        public string U_LEAVECODE { get; set; }

        public double? U_TOTAL_ASS_LEAVE { get; set; }
        public double? U_TOTAL_ENCASH_LEAVE { get; set; }
        public double? U_TOTAL_TAKEN_LEAVE { get; set; }

        public DateTime? U_CREATEDDATE { get; set; }
        public DateTime? U_UPDATEDDATE { get; set; }
        public string U_CREATEDBY { get; set; }
        public string U_UPDATEDBY { get; set; }
        public string U_SYSTEMID { get; set; }
        public string U_PORTALMODULE { get; set; }
    }

    public class A_LEVRCollection
    {
        public A_LEVRCollection()
        {
            A_LEV5Collection = new List<A_LEV5Collection>();
        }

        public string SchemaName { get; set; }
        public string U_EMPID { get; set; }

        public int? DocEntry { get; set; }
        public string U_DOCUMENTNUMBER { get; set; }
        public DateTime? U_DOCUMENTDATE { get; set; }
        public string U_LEAVETYPE { get; set; }
        public DateTime? U_FROMDATE { get; set; }
        public DateTime? U_TODATE { get; set; }
        public string U_NOOFDAYS { get; set; }
        public string U_LEAVECODE { get; set; }
        public string U_REASON { get; set; }

        public string U_CREATEDBY { get; set; }
        public string U_SYSTEMID { get; set; }
        public string U_PORTALMODULE { get; set; }
        public string U_STATUS { get; set; }

        public List<A_LEV5Collection> A_LEV5Collection { get; set; }

    }

    public class A_LEV5Collection
    {
        public int? LineId { get; set; }
        public string U_APPROVEDID { get; set; }
        public string U_APPROVEDSTATUS { get; set; }
        public string U_APPROVEDREMARKS { get; set; }
        public string U_LEVEL { get; set; }
        public string U_APPROVEDPOSITIONID { get; set; }
        public string U_CREATEDBY { get; set; }
        public string U_UPDATEDBY { get; set; }
        public string U_CREATEDDATE { get; set; }
        public string U_UPDATEDDATE { get; set; }
    }

    public class LeaveDetails
    {
        public string Code { get; set; }

    }
    public class PendingLeaveDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<LeaveApproval> LeaveList { get; set; }
    }

    public class LeaveApproval
    {
        public string DocEntry { get; set; }
        public string EmpName { get; set; }
        public string LeaveName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string NoofDays { get; set; }
        public string Reason { get; set; }
        public string RowID { get; set; }
        public string Level { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentDate { get; set; }
        public string Status { get; set; }
    }

    public class LeaveApprover
    {
        public string SchemaName { get; set; }
        public string EMPID { get; set; }

        public int? DOCENTRY { get; set; }
        public int? LINEID { get; set; }
        public string APPROVERLEVEL { get; set; }
        public string APPROVERSTATUS { get; set; }
        public string APPROVERREMARKS { get; set; }

    }

    public class LeaveDetailDefault
    {
        public string SchemaName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string LeaveCode { get; set; }
        public string EMPID { get; set; }
        public string Status { get; set; }
    }
}