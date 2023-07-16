using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPWeb.Models
{
    #region Get SalesQuotation
    public class SalesQuotationData
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<SalesQuotationHeader> GetSalesQuotaionHeaderData { get; set; }
        public List<SalesQuotationItemDetail> GetSalesQuotaionItemDetail { get; set; }
        public List<SalesQuotationTermsAnsCondition> GetSalesQuotaionTermsAndCondition { get; set; }
    }
    public class SalesQuotationHeader
    {
        public string DocNumber { get; set; }
        public string Series { get; set; }
        public string OpprtunityID { get; set; }
        public string OpprtunityName { get; set; }
        public string CardCode { get; set; }
        public string PostingDate { get; set; }
        public string SalesEmployee { get; set; }
        public string ValidityDate { get; set; }
        public string DocDate { get; set; }
        public string Currency { get; set; }
        public string CurrencyRate { get; set; }
        public string OrderType { get; set; }
        public string ContainerType { get; set; }
        public string BrandingType { get; set; }
        public string TradeRegion { get; set; }
        public string PriceList { get; set; }
        public string ContactPerson { get; set; }
        public string CoveringBody { get; set; }
        public string Subject { get; set; }
        public string ProductType { get; set; }
        public string PrincipalCompany { get; set; }
        public string Model { get; set; }
        public string BillTo { get; set; }
        public string ShipTo { get; set; }
        public string WareHouse { get; set; }
        public string PaymentTerms { get; set; }
        public string PaymentRemarks { get; set; }
        public string CommercialRemark { get; set; }
    }
    public class SalesQuotationItemDetail
    {
        public string LineNumber { get; set; }
        public string BrandCode { get; set; }
        public string ItemCode { get; set; }
        public string Size { get; set; }
        public string PKGCarton { get; set; }
        public string NoOFCarton { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public string TaxCode { get; set; }
        public string ItemNetWeight { get; set; }
        public string ItemGrossWeight { get; set; }

        public string BaseType { get; set; }
        public string BaseEntry { get; set; }
        public string BaseLine { get; set; }
        public string UOM { get; set; }
    }
    public class SalesQuotationTermsAnsCondition
    {
        public int? LineId { get; set; }
        public string TermCode { get; set; }
        public string TermName { get; set; }
        public string TermDescription { get; set; }
    }
    public class ParaSalesQuotaion
    {
        public string QuotaionID { get; set; }//ODRF ID
        public string Flag { get; set; }
        public string EMPID { get; set; }
    }
    #endregion

    #region Principal SPR

    public class A_OSPRDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
    }

    public class A_OSPRCollection
    {
        public A_OSPRCollection()
        {
            A_SPR1Collection = new List<A_SPR1Collection>();
            A_SPR2Collection = new List<A_SPR2Collection>();
        }

        public string SchemaName { get; set; }

        public int? DocEntry { get; set; }
        public string U_CARDCODE { get; set; }
        public string U_CARDNAME { get; set; }
        public string U_SALESEMPLOYEE { get; set; }
        public string U_CUSTREFNO { get; set; }
        public string U_SPRREFNO { get; set; }
        public DateTime? U_SPRDATE { get; set; }
        public string U_PRINCIPAL { get; set; }
        public string U_SQDOCENTRY { get; set; }
        public string U_SQDOCNUM { get; set; }
        public string U_REMARKS { get; set; }
        public string U_ITEMCODE { get; set; }
        public string U_ITEMNAME { get; set; }
        public string U_UOM { get; set; }
        public double? U_QUANTITY { get; set; }
        public double? U_PRICE { get; set; }
        public double? U_STANDARDDISCPER { get; set; }
        public double? U_REQUESTEDDISCPER { get; set; }
        public string U_SPRNUMBER { get; set; }
        public string U_PRINCIPALREMARKS { get; set; }
        public DateTime? U_SPRVALIDITYDATE { get; set; }
        public string U_REQUESTEDREMARKS { get; set; }
        public double? U_APPROVEDQUANTITY { get; set; }
        public double? U_APPROVEDDISCPER { get; set; }
        public string U_APPROVEDREMARKS { get; set; }
        public string U_TABLENAME { get; set; }
        public string U_PRINCIPALNAME { get; set; }
        public string U_STATUS { get; set; }
        public DateTime? U_SQDATE { get; set; }
        public double? U_UTILIZEDQUANTITY { get; set; }
        public string SAPSouceAttchPath { get; set; }

        public List<A_SPR1Collection> A_SPR1Collection { get; set; }
        public List<A_SPR2Collection> A_SPR2Collection { get; set; }
    }

    public class A_SPR1Collection
    {
        public int? LineId { get; set; }
        public string U_COMPETITOR { get; set; }
        public string U_REMARKS { get; set; }
    }

    public class A_SPR2Collection
    {
        public int? LineId { get; set; }
        public string U_FILENAME { get; set; }
        public string U_FILEPATH { get; set; }
        public string U_REMARKS { get; set; }
    }

    #endregion

    public class DraftEntryDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public string DocEntry { get; set; }
    }
}
