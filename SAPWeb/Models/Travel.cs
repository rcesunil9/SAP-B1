using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SAPWeb.Models
{
    #region Common

    public class TravelDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public DataTable tab { get; set; }
    }

    public class TravelDefaultSave
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
    }

    #endregion

    #region Travel

    public class TravelApprover
    {
        public string EMPID { get; set; }

        public int? DOCENTRY { get; set; }
        public int? LINEID { get; set; }
        public string APPROVERLEVEL { get; set; }
        public string APPROVERSTATUS { get; set; }
        public string APPROVERREMARKS { get; set; }

    }

    public class A_OTRVCollection
    {
        public A_OTRVCollection()
        {
            A_TRV5Collection = new List<A_TRV5Collection>();
        }

        public string EMPID { get; set; }
        public int? DocEntry { get; set; }

        public string U_DOCUMENTNUMBER { get; set; }
        public DateTime? U_DOCUMENTDATE { get; set; }
        public string U_EMPID { get; set; }
        public string U_TRAVELMODE { get; set; }
        public string U_FROMLOCATION { get; set; }
        public string U_TOLOCATION { get; set; }
        public string U_PURPOSEOFVISIT { get; set; }
        public DateTime? U_FROMDATE { get; set; }
        public DateTime? U_TODATE { get; set; }
        public string U_TOTALDAYS { get; set; }
        public double? U_ADVANCEAMOUNT { get; set; }
        public string U_REMARKS { get; set; }
        public string U_IS_RETURN_TRIP { get; set; }

        public string U_CREATEDBY { get; set; }
        public string U_SYSTEMID { get; set; }
        public string U_PORTALMODULE { get; set; }
        public string U_STATUS { get; set; }

        public List<A_TRV5Collection> A_TRV5Collection { get; set; }
    }

    public class A_TRV5Collection
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

    public class ParameterForApproval
    {
        public string EMPID { get; set; }
    }
    public class ParameterForTravelList
    {
        public string FromDate { get; set; }public string ToDate { get; set; }
        public string Status { get; set; }public string EMPID { get; set; }
    }
    public class ParameterForTravelHistory
    {
        public string EMPID { get; set; }
        public string DocEntry { get; set; }
    }

}