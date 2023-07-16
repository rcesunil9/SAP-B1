using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPWeb.Models
{
    public class SalesOpportunityDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
    }

    #region CLASS

    public class SalesOpportunity
    {
        public SalesOpportunity()
        {
            SalesOpportunityItems = new List<SalesOpportunityItems>();
            DataAttachment = new List<SalesOpportunityODataAttachment>();
            DataUpdateAttachment = new List<SalesOpportunityDataUpdateAttachment>();
        }

        public string EMPID { get; set; }
        public int? OpportunityCode { get; set; }
        public string OpportunityName { get; set; }
        public int? CurrentStage { get; set; }
        public int? SalesPerson { get; set; }
        public string FrieghtTerms { get; set; }

        public string CustomerCode { get; set; }
        public string ContactPerson { get; set; }
        public string OrderType { get; set; }
        public string BrandingType { get; set; }
        public string ContainerType { get; set; }

        public DateTime? EnquiryDate { get; set; }
        public string CurrentStatus { get; set; }
        public string PaymentTerms { get; set; }
        public string DestinationPort { get; set; }
        public string Remarks { get; set; }

        public string BrandName { get; set; }
        public string PackedFor { get; set; }
        public string LabelDesign { get; set; }
        public string LabelBarcode { get; set; }
        public string CartonBarcodeReq { get; set; }
        public string AddressForLabel { get; set; }
        public string Website { get; set; }
        public string EMail { get; set; }
        public string SAFLBrand { get; set; }

        public string ProductGroup { get; set; }
        public string ProductSubGroup { get; set; }

        public string CreatedBy { get; set; }
        public string SystemID { get; set; }
        public string SAPSouceAttchPath { get; set; }
        public string ItemDocEntry { get; set; }
        public string U_SYSTEMID { get; set; }

        public List<SalesOpportunityItems> SalesOpportunityItems { get; set; }
        public List<SalesOpportunityODataAttachment> DataAttachment { get; set; }
        public List<SalesOpportunityDataUpdateAttachment> DataUpdateAttachment { get; set; }
    }

    public class SalesOpportunityItems
    {
        public int? LineId { get; set; }
        public string Brand { get; set; }
        public string ItemCode { get; set; }
        public string Size { get; set; }
        public string PakageCarton { get; set; }
        public string NoofCarton { get; set; }
        public string Remarks { get; set; }
    }

    public class SalesOpportunityODataAttachment
    {
        public string Subject { get; set; }
        public string Notes { get; set; }
        public string AttachFileName { get; set; }
        public string AttachPath { get; set; }

        public string Base64 { get; set; }
        public string FileName { get; set; }
        public string Extention { get; set; }
    }

    public class SalesOpportunityDataUpdateAttachment
    {
        public string SourcePath { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string FreeText { get; set; }
    }


    #endregion

    #region SAPCLASS

    public class SAPSalesOpportunity
    {
        public SAPSalesOpportunity()
        {
            SalesOpportunitiesLines = new List<SalesOpportunitiesLines>();
        }

        public int? SequentialNo { get; set; }
        public string OpportunityName { get; set; }
        public string CardCode { get; set; }
        public double? MaxLocalTotal { get; set; }
        public DateTime? PredictedClosingDate { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        //public string U_REMARKS { get; set; }
        public int? SalesPerson { get; set; }
        public DateTime? StartDate { get; set; }
        public string ContactPerson { get; set; }

        public string U_PRODUCTGROUP { get; set; }
        public string U_PRODUCTSUBGROUP { get; set; }

        public string U_FRIEGHTTERMS { get; set; }
        public string U_ORDERTYPE { get; set; }
        public string U_BRANDINGTYPE { get; set; }
        public string U_CONTAINERTYPE { get; set; }
        public string U_PAYMENTTERMS { get; set; }
        public string U_DESTINATIONPORT { get; set; }

        public string U_BRANDNAME { get; set; }
        public string U_PACKEDFOR { get; set; }
        public string U_LABLEDESIGN { get; set; }
        public string U_LABLEBARCODE { get; set; }
        public string U_CARTONBARCODEREQ { get; set; }
        public string U_ADDRESSFORLABEL { get; set; }
        public string U_WEBSITE { get; set; }
        public string U_EMAIL { get; set; }
        public string U_SAFLBRAND { get; set; }

        public string U_CREATEDBY { get; set; }
        public string U_UPDATEDBY { get; set; }
        public string U_PORTALMODULEID { get; set; }
        public string U_SYSTEMID { get; set; }

        public int? AttachmentEntry { get; set; }

        public List<SalesOpportunitiesLines> SalesOpportunitiesLines { get; set; }
    }

    public class SalesOpportunitiesLines
    {
        public int? LineNum { get; set; }
        public int? StageKey { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public double? MaxLocalTotal { get; set; }
        public int? DocumentNumber { get; set; }
        public string DocumentType { get; set; }
    }

    public class A_OOPR
    {
        public A_OOPR()
        {
            A_OPR1Collection = new List<A_OPR1Collection>();
        }

        public int? DocEntry { get; set; }
        public string U_OPPORTUNITYID { get; set; }

        public List<A_OPR1Collection> A_OPR1Collection { get; set; }
    }

    public class A_OPR1Collection
    {
        public int? LineId { get; set; }
        public string U_BRAND { get; set; }
        public string U_ITEMCODE { get; set; }
        public string U_SIZE { get; set; }
        public string U_PKGCARTON { get; set; }
        public string U_NOOFCARTON { get; set; }
        public string U_REMARKS { get; set; }
    }

    #endregion

}