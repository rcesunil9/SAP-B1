using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SAPWeb.Models
{
    public class ProjectionDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public DataTable tab { get; set; }
    }

    public class ParamProjectionCustomerList
    {
        public string SchemaName { get; set; }
        public string EMPID { get; set; }
        public string SALESEMPLOYEEID { get; set; }
        public string PROJECTIONNAME { get; set; }
    }

    public class ParamProjectionItemList
    {
        public string SchemaName { get; set; }
        public string EMPID { get; set; }
        public string SALESEMPLOYEEID { get; set; }
        public string CUSTOMERCODE { get; set; }
        public string PROJECTIONNAME { get; set; }
    }

    public class ParamProjectionListForSalesEmployee
    {
        public string SchemaName { get; set; }
        public string EMPID { get; set; }
        public string FROMDATE { get; set; }
        public string TODATE { get; set; }
        public string ISAPPROVER { get; set; }
        public string POSITIONID { get; set; }
        public string STATUS { get; set; }
    }

    public class ParamProjectionByDocEntry
    {
        public string SchemaName { get; set; }
        public string EMPID { get; set; }
        public string SALESEMPLOYEEID { get; set; }
        public string DOCENTRY { get; set; }
    }

    public class ParamProjectionByDocEntryforApprover
    {
        public string SchemaName { get; set; }
        public string EMPID { get; set; }
        public string SALESEMPLOYEEID { get; set; }
        public string PROJECTIONNAME { get; set; }

        public string APPROVERSTATUS { get; set; }
        public string APPROVERREMARKS { get; set; }
    }

    public class ParamProjectionDate
    {
        public string SchemaName { get; set; }
        public string EMPID { get; set; }
        public string DATE { get; set; }
    }

    public class A_OPRJDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
    }

    public class A_OPRJCollection
    {
        public A_OPRJCollection()
        {
            A_PRJ1Collection = new List<A_PRJ1Collection>();
            A_PRJ5Collection = new List<A_PRJ5Collection>();
        }

        public string SchemaName { get; set; }
        public string EMPID { get; set; }

        public int? DocEntry { get; set; }
        public string U_SALESEMPLOYEEID { get; set; }
        public string U_PROJECTIONNAME { get; set; }
        public string U_PROJECTIONMONTH { get; set; }
        public string U_PROJECTIONYEAR { get; set; }
        public string U_REMARKS { get; set; }

        public DateTime? U_DATE { get; set; }
        public DateTime? U_STARTDATE { get; set; }
        public DateTime? U_ENDDATE { get; set; }
        public int? U_WEEKINMONTH { get; set; }

        public List<A_PRJ1Collection> A_PRJ1Collection { get; set; }
        public List<A_PRJ5Collection> A_PRJ5Collection { get; set; }
    }


    public class A_PRJ1Collection
    {
        public int? DocEntry { get; set; }
        public int? LineId { get; set; }
        public string U_CARDCODE { get; set; }
        public string U_ITEMCODE { get; set; }

        public double? U_MONTH1TARGET { get; set; }
        public double? U_MONTH1ACTUAL { get; set; }
        public double? U_MONTH2TARGET { get; set; }
        public double? U_MONTH2ACTUAL { get; set; }
        public double? U_MONTH3TARGET { get; set; }
        public double? U_MONTH3ACTUAL { get; set; }
        public double? U_MONTH4TARGET { get; set; }
        public double? U_MONTH4ACTUAL { get; set; }
        public double? U_MONTH5TARGET { get; set; }
        public double? U_MONTH5ACTUAL { get; set; }
        public double? U_MONTH6TARGET { get; set; }
        public double? U_MONTH6ACTUAL { get; set; }

        public double? U_CUWEEK1 { get; set; }
        public double? U_CUWEEK2 { get; set; }
        public double? U_CUWEEK3 { get; set; }
        public double? U_CUWEEK4 { get; set; }
        public double? U_CUWEEK5 { get; set; }
        public double? U_CUWEEK6 { get; set; }

        public string U_REMARKS { get; set; }

        public string U_SALESPERSONWHSCODE { get; set; }
        public string U_LASTRECEIVEDWHSCODE { get; set; }
    }

    public class A_PRJ5Collection
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
        public string U_SENDAPPROVER { get; set; }
    }

    public class SalesForecast
    {
        public SalesForecast()
        {
            SalesForecastLines = new List<SalesForecastLines>();
        }

        public string SchemaName { get; set; }

        public int? Numerator { get; set; }
        public DateTime? ForecastStartDate { get; set; }
        public DateTime? ForecastEndDate { get; set; }
        public string ForecastCode { get; set; }
        public string ForecastName { get; set; }
        public string View { get; set; }

        public List<SalesForecastLines> SalesForecastLines { get; set; }
    }

    public class SalesForecastLines
    {
        public double? Quantity { get; set; }
        public DateTime? ForecastedDay { get; set; }
        public string ItemNo { get; set; }
        public string Warehouse { get; set; }
    }

    public class ParamProjectionWarehouse
    {
        public string SchemaName { get; set; }
    }

    public class ParamProjectionCount
    {
        public string SchemaName { get; set; }
        public string SALESEMPLOYEEID { get; set; }
        public string PROJECTIONNAME { get; set; }
    }

    public class ParamSalesProjectionForDownload
    {
        public string SchemaName { get; set; }
        public string EMPID { get; set; }
        public string SALESEMPLOYEEID { get; set; }
        public string PROJECTIONNAME { get; set; }
    }

    public class ParamProjectionUpload
    {
        public string SchemaName { get; set; }
        public string EMPID { get; set; }
        public string SALESEMPLOYEEID { get; set; }
        public string PROJECTIONNAME { get; set; }
        public string DOCENTRY { get; set; }
        public string CUSTMERCODE { get; set; }
        public string ITEMCODE { get; set; }
        public string LASTRECEIVEDWHS { get; set; }
        public string WEEK1 { get; set; }
        public string WEEK2 { get; set; }
        public string WEEK3 { get; set; }
        public string WEEK4 { get; set; }
        public string WEEK5 { get; set; }
    }

    public class ParamSalesProjectionForDownloadReport
    {
        public string SchemaName { get; set; }
        public string EMPID { get; set; }
        public string POSITIONID { get; set; }
    }

    public class ParamProjectionListForSalesOrder
    {
        public string SchemaName { get; set; }
        public string EMPID { get; set; }
    }

}