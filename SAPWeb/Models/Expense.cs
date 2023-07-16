using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SAPWeb.Models
{

    public class ExpenseDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public DataTable tab { get; set; }
    }

    public class ExpenseDefaultSave
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
    }

    public class ParamDefaultForExpense
    {
        public string EMPID { get; set; }
    }

    public class ParamDefaultForExpenseMode
    {
        
        public string EMPID { get; set; }
        public string EXPENSETYPE { get; set; }

    }
    public class ParameterForExpenseHistory
    {
        public string EMPID { get; set; }
        public string DocEntry { get; set; }
    }
    public class ParameterForExpenseList
    {
        
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Status { get; set; }
        public string EMPID { get; set; }
    }
    #region Expense

    public class ExpenseApprover
    {
        
        public string EMPID { get; set; }

        public int? DOCENTRY { get; set; }
        public int? LINEID { get; set; }
        public string APPROVERLEVEL { get; set; }
        public string APPROVERSTATUS { get; set; }
        public string APPROVERREMARKS { get; set; }

    }

    public class A_OEXPCollection
    {
        public A_OEXPCollection()
        {
            A_EXP1Collection = new List<A_EXP1Collection>();
            A_EXP5Collection = new List<A_EXP5Collection>();
        }

        public string EMPID { get; set; }
        public int? DocEntry { get; set; }

        public string U_DOCUMENTNUMBER { get; set; }
        public DateTime? U_DOCUMENTDATE { get; set; }
        public string U_EMPID { get; set; }
        public string U_TRAVELREQUEST { get; set; }
        public double? U_AMOUNT { get; set; }

        public string U_CREATEDBY { get; set; }
        public string U_SYSTEMID { get; set; }
        public string U_PORTALMODULE { get; set; }
        public string U_STATUS { get; set; }

        public List<A_EXP1Collection> A_EXP1Collection { get; set; }
        public List<A_EXP5Collection> A_EXP5Collection { get; set; }
    }

    public class A_EXP1Collection
    {
        public string U_TYPE { get; set; }
        public string U_MODE { get; set; }
        public string U_FROMLOCATION { get; set; }
        public string U_TOLOCATION { get; set; }
        public DateTime? U_EXPENSEDATE { get; set; }
        public double? U_AMOUNT { get; set; }
        public string U_ATTACHMENT { get; set; }
        public string U_ATTACHMENT1 { get; set; }
        public string U_REMARKS { get; set; }

        public string Base64 { get; set; }
        public string FileName { get; set; }
        public string Extention { get; set; }
    }

    public class A_EXP5Collection
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

    #endregion
}