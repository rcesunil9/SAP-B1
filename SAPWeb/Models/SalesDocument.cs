using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SAPWeb.Models
{
    public class SalesDocumentsDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
    }

    public class SalesDocumentsDefaulttab
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public DataTable tab { get; set; }
    }

    public class SalesOrderQuotationDocument
    {
        public SalesOrderQuotationDocument()
        {
            DocumentLines = new List<DataItems>();
        }
        public string EMPID { get; set; }
        public string CardCode { get; set; }
        public string NumAtCard { get; set; }
        public int? ContactPersonCode { get; set; }
        public string U_Territory { get; set; }
        public string DocCurrency { get; set; }
        public string PayToCode { get; set; }
        public string ShipToCode { get; set; }
        public int? Series { get; set; }
        public DateTime DocDate { get; set; }
        public int? SalesEmployee { get; set; }
        public string Comments { get; set; }
        //public string EMPID { get; set; }
        public int? DocEntry { get; set; }
        public int? DraftDocEntry { get; set; }
        //public int? Series { get; set; }
        //public int? SalesPersonCode { get; set; }
        //public string DocCurrency { get; set; }
        //public string U_Territory { get; set; }
        public double? U_ExchRate { get; set; }
        //public string OrderType { get; set; }
        //public string CustomerCode { get; set; }
        //public DateTime? PostingDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        //public DateTime DocDate { get; set; }
        //public string PayToCode { get; set; }
        //public string ShipToCode { get; set; }
        //public double? TotalAmount { get; set; }
        //public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public string WhsCode { get; set; }
        public List<DataItems> DocumentLines { get; set; }
    }
    public class SalesOrderQuotationDocumentItem
    {
        public int? Linenum { get; set; }
        public string ItemCode { get; set; }
        public double? Quantity { get; set; }
        public double? ItemPrice { get; set; }
        public string TaxCode { get; set; }
        public double? DiscountPercent { get; set; }
        public string WarehouseCode { get; set; }


    }
    #region CLASS OLD Code

    public class SalesDocuments
    {
        public SalesDocuments()
        {

            DataItems = new List<DataItems>();
            DataTermsAndCondition = new List<DataTermsAndCondition>();
            DataAttachment = new List<DataAttachment>();
            DataUpdateAttachment = new List<DataUpdateAttachment>();
            DataBatchInfo = new List<DataBatchInfo>();
            DataLotInfo = new List<DataLotInfo>();
            DataCostBreakup = new List<DataCostBreakup>();
        }

        public string EMPID { get; set; }
        public int? DocEntry { get; set; }
        public int? DraftDocEntry { get; set; }
        public int? Series { get; set; }

        public string OpportunityNo { get; set; }
        public int? SalesEmployee { get; set; }
        public int? PriceListCode { get; set; }
        public string Currency { get; set; }
        public double? CurrencyRate { get; set; }
        public string OrderType { get; set; }

        public string CustomerCode { get; set; }
        public string ContainerType { get; set; }
        public string BrandingType { get; set; }
        public DateTime? PostingDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime DocumentDate { get; set; }
        public string TradeRegion { get; set; }
        public string Consignee { get; set; }

        public int? ContactPersonVal { get; set; }
        public string Subject { get; set; }
        public string CoveringBody { get; set; }

        public string BillToVal { get; set; }
        public string ShiptoVal { get; set; }
        public string WhsCode { get; set; }
        public string Remarks { get; set; }

        public int? PaymentTerms { get; set; }

        public string ProductType { get; set; }
        public string PrincipleCompany { get; set; }
        public string Model { get; set; }

        public double? CBM { get; set; }
        public double? TotalGrossWeight { get; set; }
        public double? TotalNetWeight { get; set; }
        public double? TotalAmount { get; set; }
        public string CommercialRemark { get; set; }

        // --------- Proforma Invoice ----------

        public string FrieghtTerms { get; set; }
        public string ShipmentMode { get; set; }
        public string DestinationPort { get; set; }

        // -------- Sales Invoice ---------------

        public string ExportCertificateNo { get; set; }
        public DateTime? ETD { get; set; }
        public string PreCarriageBy { get; set; }
        public DateTime? ManufacturingDate { get; set; }
        public string PreCarriageReceiptPlace { get; set; }
        public string LeoNo { get; set; }
        public double? Commission { get; set; }

        public string ShippingBillNo { get; set; }
        public DateTime? ETA { get; set; }
        public string Vessel { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string DeliveryPlace { get; set; }
        public string PortCode { get; set; }
        public double? PackageCharges { get; set; }

        public DateTime? ValidityUpTo { get; set; }
        public string BookingParty { get; set; }
        public double? Freight { get; set; }
        public string ReferenceNo { get; set; }
        public string LoadingPort { get; set; }
        public double? Rate { get; set; }

        public string LetterTemplate { get; set; }
        public string LetterTemplateBody { get; set; }

        // ------------------------------------------

        public string CurrentApproverLevel { get; set; }
        public string ApproverStatus { get; set; }
        public string ApproverRemarks { get; set; }
        public int? ApproverDocEntry { get; set; }
        public int? ApproverLineId { get; set; }

        public string System { get; set; }
        public string CreatedBy { get; set; }
        public string SAPSouceAttchPath { get; set; }

        public List<DataItems> DataItems { get; set; }
        public List<DataTermsAndCondition> DataTermsAndCondition { get; set; }
        public List<DataAttachment> DataAttachment { get; set; }
        public List<DataUpdateAttachment> DataUpdateAttachment { get; set; }
        public List<DataBatchInfo> DataBatchInfo { get; set; }
        public List<DataLotInfo> DataLotInfo { get; set; }
        public List<DataCostBreakup> DataCostBreakup { get; set; }
    }

    public class DataItems
    {
        public int? Linenum { get; set; }
        public string ItemBrand { get; set; }
        public string ItemItemCode { get; set; }
        public string ItemSize { get; set; }
        public double? ItemPkgCarton { get; set; }
        public double? ItemNoofCarton { get; set; }
        public double? ItemQuantity { get; set; }
        public double? ItemPrice { get; set; }
        public string ItemTax { get; set; }
        public double? ItemNetWeight { get; set; }
        public double? ItemGrossWeight { get; set; }
        public string ItemUOM { get; set; }
        public double? ItemCBM { get; set; }

        public int? BaseType { get; set; }
        public int? BaseEntry { get; set; }
        public int? BaseLine { get; set; }
        public double? DiscountPercent { get; set; }
        public string WarehouseCode { get; set; }
    }

    public class DataTermsAndCondition
    {
        public int? LineId { get; set; }
        public string TermsCode { get; set; }
        public string TermsName { get; set; }
        public string TermsDescription { get; set; }
    }

    public class DataAttachment
    {
        public string Subject { get; set; }
        public string Notes { get; set; }
        public string AttachFileName { get; set; }
        public string AttachPath { get; set; }

        public string Base64 { get; set; }
        public string FileName { get; set; }
        public string Extention { get; set; }
    }

    public class DataUpdateAttachment
    {
        public string SourcePath { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string FreeText { get; set; }
    }

    public class DataBatchInfo
    {
        public int? LineId { get; set; }
        public string BatchNo { get; set; }
        public string ContainerNo { get; set; }
        public string CSealNo { get; set; }
        public string LSealNo { get; set; }
    }

    public class DataLotInfo
    {
        public int? LineId { get; set; }
        public string LotNo { get; set; }
        public string Drums { get; set; }
        public string ContainerNo { get; set; }
        public string ContractNo { get; set; }
        public string CSealNo { get; set; }
        public string LSealNo { get; set; }
    }

    public class DataCostBreakup
    {
        public int? LineId { get; set; }
        public string ItemCode { get; set; }
        public string Size { get; set; }
        public double? CostKg { get; set; }
        public double? CostBottle { get; set; }
        public double? CostCap { get; set; }
        public double? CostWad { get; set; }
        public double? TotalLabelCostSet { get; set; }
        public double? CartonCostPcs { get; set; }
        public double? ExtraCost { get; set; }
        public string DescofExtraCost { get; set; }
        public double? TotalCostPcs { get; set; }
    }

    public class SalesExportDocuments
    {
        public SalesExportDocuments()
        {
            DataQCParameter = new List<DataQCParameter>();
            DataContainerDocuments = new List<DataContainerDocuments>();
            DataDocClearanceDocuments = new List<DataDocClearanceDocuments>();
            DataClientDocuments = new List<DataClientDocuments>();
            DataAdditioanlAttachments = new List<DataAdditioanlAttachments>();
        }

        public string EMPID { get; set; }
        public int? InvoiceDocEntry { get; set; }
        public string AttachmentFileName { get; set; }
        public string AttachmentFilePath { get; set; }
        public string SAPSouceAttchPath { get; set; }
        public string Remarks { get; set; }

        public List<DataQCParameter> DataQCParameter { get; set; }
        public List<DataContainerDocuments> DataContainerDocuments { get; set; }
        public List<DataDocClearanceDocuments> DataDocClearanceDocuments { get; set; }
        public List<DataClientDocuments> DataClientDocuments { get; set; }
        public List<DataAdditioanlAttachments> DataAdditioanlAttachments { get; set; }
    }

    public class DataQCParameter
    {
        public int? LineId { get; set; }
        public string QCParameterCode { get; set; }
        public string QCParameterValue { get; set; }
    }

    public class DataContainerDocuments
    {
        public int? LineId { get; set; }
        public string DocumentType { get; set; }
        public string AttachmentFileName { get; set; }
        public string AttachmentFilePath { get; set; }
    }

    public class DataDocClearanceDocuments
    {
        public int? LineId { get; set; }
        public string DocumentType { get; set; }
        public string AttachmentFileName { get; set; }
        public string AttachmentFilePath { get; set; }
    }

    public class DataClientDocuments
    {
        public int? LineId { get; set; }
        public string DocumentType { get; set; }
        public string AttachmentFileName { get; set; }
        public string AttachmentFilePath { get; set; }
    }

    public class DataAdditioanlAttachments
    {
        public int? LineId { get; set; }
        public string Remarks { get; set; }
        public string AttachmentFileName { get; set; }
        public string AttachmentFilePath { get; set; }
    }

    #endregion

    #region SAPCLASS

    public class Documents
    {
        public Documents()
        {
            DocumentLines = new List<DocumentLines>();
        }

        public int? DocEntry { get; set; }
        public string DocObjectCode { get; set; }
        public string U_DRAFTDOCENTRY { get; set; }

        public string U_OPPORTUNITYNO { get; set; }
        public int? SalesPersonCode { get; set; }
        public int? U_PRICELISTCODE { get; set; }
        public string DocCurrency { get; set; }
        public double? DocRate { get; set; }
        public string U_ORDERTYPE { get; set; }

        public string CardCode { get; set; }
        public string U_CONTAINERTYPE { get; set; }
        public string U_BRANDINGTYPE { get; set; }

        public int? Series { get; set; }
        public DateTime? DocDate { get; set; }
        public DateTime? TaxDate { get; set; }
        public DateTime? DocDueDate { get; set; }
        public string U_TRADEREGION { get; set; }

        public int? ContactPersonCode { get; set; }
        public string U_SUBJECT { get; set; }
        public string U_COVERINGBODY { get; set; }

        public string PayToCode { get; set; }
        public string ShipToCode { get; set; }
        public string Comments { get; set; }

        public int? PaymentGroupCode { get; set; }

        public double? U_CBM { get; set; }
        public double? U_TOTALGROSSWEIGHT { get; set; }
        public double? U_TOTALNETWEIGHT { get; set; }
        public string U_COMMERCIALREMARK { get; set; }
        public string U_PRODUCTTYPE { get; set; }
        public string U_PRINCIPALCOMPANY { get; set; }
        public string U_MODEL { get; set; }

        // --------- Proforma Invoice ----------

        public string U_SHIPMENTMODE { get; set; }
        public string U_FRIEGHTTERMS { get; set; }
        public string U_DESTINATIONPORT { get; set; }

        // -------- Sales Invoice ---------------

        public string U_EXPORTCERTIFICATENO { get; set; }
        public DateTime? U_ETD { get; set; }
        public string U_PRECARRIAGEBY { get; set; }
        public DateTime? U_MANUFACTURINGDATE { get; set; }
        public string U_PRECARRIAGERECEIPTPLACE { get; set; }
        public string U_LEONO { get; set; }
        public double? U_COMMISSION { get; set; }

        public string U_SHIPPINGBILLNO { get; set; }
        public DateTime? U_ETA { get; set; }
        public string U_VESSEL { get; set; }
        public DateTime? U_EXPIRYDATE { get; set; }
        public string U_DELIVERYPLACE { get; set; }
        public string U_PORTCODE { get; set; }
        public double? U_PACKAGECHARGES { get; set; }

        public DateTime? U_VALIDITYUPTO { get; set; }
        public string U_BOOKINGPARTY { get; set; }
        public double? U_FREIGHT { get; set; }
        public string U_REFERENCENO { get; set; }
        public string U_LOADINGPORT { get; set; }
        public double? U_RATE { get; set; }

        public string U_LETTERTEMPLATE { get; set; }
        public string U_LETTERTEMPLATEBODY { get; set; }

        // ------------------------------------------

        public string U_CREATEDBY { get; set; }
        public string U_UPDATEDBY { get; set; }
        public string U_PORTALMODULE { get; set; }
        public string U_SYSTEMID { get; set; }

        public string U_LASTAPPROVEDBY { get; set; }
        public string U_LASTAPPROVEDDATETIME { get; set; }

        public int? AttachmentEntry { get; set; }

        public List<DocumentLines> DocumentLines { get; set; }
    }

    public class DocumentLines
    {
        public int? LineNum { get; set; }

        public string U_BRAND { get; set; }
        public string ItemCode { get; set; }
        public string U_SIZE { get; set; }
        public double? U_PKGCARTON { get; set; }
        public double? U_NOOFCARTON { get; set; }
        public double? Quantity { get; set; }
        public double? UnitPrice { get; set; }
        public string TaxCode { get; set; }
        public string UseBaseUnits { get; set; }
        public int? UoMEntry { get; set; }
        public string WarehouseCode { get; set; }
        public Int32? LocationCode { get; set; }
        public double? U_NETWEIGHT { get; set; }
        public double? U_GROSSWEIGHT { get; set; }
        public string U_UOM { get; set; }
        public int? SalesPersonCode { get; set; }
        public DateTime? ShipDate { get; set; }
        public double? U_CBM { get; set; }

        public int? BaseType { get; set; }
        public int? BaseEntry { get; set; }
        public int? BaseLine { get; set; }
    }

    #region A_OQUT

    public class A_OQUTDocuments
    {
        public A_OQUTDocuments()
        {
            A_QUT1Collection = new List<A_QUT1Collection>();
        }

        public int? DocEntry { get; set; }
        public string U_DOCENTRY { get; set; }

        public List<A_QUT1Collection> A_QUT1Collection { get; set; }
    }

    public class A_QUT1Collection // Terms & Condition
    {
        public int? LineId { get; set; }
        public string U_TERMSCODE { get; set; }
        public string U_TERMSNAME { get; set; }
        public string U_TERMSDESCRIPTION { get; set; }
    }

    #endregion

    #region A_ODLN

    public class A_ODLNDocuments
    {
        public A_ODLNDocuments()
        {
            A_DLN1Collection = new List<A_DLN1Collection>();
        }

        public int? DocEntry { get; set; }
        public string U_DOCENTRY { get; set; }

        public List<A_DLN1Collection> A_DLN1Collection { get; set; }
    }

    public class A_DLN1Collection // Terms & Condition
    {
        public int? LineId { get; set; }
        public string U_TERMSCODE { get; set; }
        public string U_TERMSNAME { get; set; }
        public string U_TERMSDESCRIPTION { get; set; }
    }

    #endregion

    #region A_OINV

    public class A_OINVDocuments
    {
        public A_OINVDocuments()
        {
            A_INV1Collection = new List<A_INV1Collection>();
            A_INV2Collection = new List<A_INV2Collection>();
            A_INV3Collection = new List<A_INV3Collection>();
            A_INV4Collection = new List<A_INV4Collection>();
            A_INV5Collection = new List<A_INV5Collection>();
            A_INV6Collection = new List<A_INV6Collection>();
            A_INV7Collection = new List<A_INV7Collection>();
            A_INV8Collection = new List<A_INV8Collection>();
            A_INV9Collection = new List<A_INV9Collection>();
            A_INV10Collection = new List<A_INV10Collection>();
        }

        public int? DocEntry { get; set; }
        public string U_DOCENTRY { get; set; }
        public string U_ATTACHMENTFILENAME { get; set; }
        public string U_ATTACHMENTPATH { get; set; }

        public List<A_INV1Collection> A_INV1Collection { get; set; } // Terms & Condition
        public List<A_INV2Collection> A_INV2Collection { get; set; } // Batch Info
        public List<A_INV3Collection> A_INV3Collection { get; set; } // Lot Info
        public List<A_INV4Collection> A_INV4Collection { get; set; } // Cost Breakup
        public List<A_INV5Collection> A_INV5Collection { get; set; } // Approval History
        public List<A_INV6Collection> A_INV6Collection { get; set; } // QC Parameter 
        public List<A_INV7Collection> A_INV7Collection { get; set; } // Container Documnets
        public List<A_INV8Collection> A_INV8Collection { get; set; } // Doc Clearance Documents
        public List<A_INV9Collection> A_INV9Collection { get; set; } // Client Documents
        public List<A_INV10Collection> A_INV10Collection { get; set; } // Additional Attachments
    }

    public class A_INV1Collection // Terms & Condition
    {
        public int? LineId { get; set; }
        public string U_TERMSCODE { get; set; }
        public string U_TERMSNAME { get; set; }
        public string U_TERMSDESCRIPTION { get; set; }
    }

    public class A_INV2Collection // Batch Info
    {
        public int? LineId { get; set; }
        public string U_BATCHNO { get; set; }
        public string U_CONTAINERNO { get; set; }
        public string U_CSEALNO { get; set; }
        public string U_LSEALNO { get; set; }
    }

    public class A_INV3Collection // Lot Info
    {
        public int? LineId { get; set; }
        public string U_LOTNO { get; set; }
        public string U_DRUMS { get; set; }
        public string U_CONTAINERNO { get; set; }
        public string U_CONTRACTNO { get; set; }
        public string U_CSEALNO { get; set; }
        public string U_LSEALNO { get; set; }
    }

    public class A_INV4Collection // Cost Breakup
    {
        public int? LineId { get; set; }
        public string U_ITEMCODE { get; set; }
        public string U_SIZE { get; set; }
        public double? U_COSTKG { get; set; }
        public double? U_COSTBOTTLE { get; set; }
        public double? U_COSTCAP { get; set; }
        public double? U_COSTWAD { get; set; }
        public double? U_TOTALLABELCOSTSET { get; set; }
        public double? U_CARTONCOSTPCS { get; set; }
        public double? U_EXTRACOST { get; set; }
        public string U_DESCOFEXTRACOST { get; set; }
        public double? U_TOTALCOSTPCS { get; set; }
    }

    public class A_INV5Collection // Approval History
    {
        public int? LineId { get; set; }
        public string U_APPROVEDID { get; set; }
        public string U_APPROVEDSTATUS { get; set; }
        public string U_APPROVEDREMARKS { get; set; }
        public string U_TABLENAME { get; set; }
        public string U_LEVEL { get; set; }
        public double? U_AMOUNT { get; set; }
        public string U_APPROVEDPOSITIONID { get; set; }
        public string U_CREATEDBY { get; set; }
        public string U_UPDATEDBY { get; set; }
        public string U_CREATEDDATE { get; set; }
        public string U_UPDATEDDATE { get; set; }
        public string U_ATTACHMENTFILENAME { get; set; }
        public string U_ATTACHMENTPATH { get; set; }
    }

    public class A_INV6Collection // QC Parameter 
    {
        public int? LineId { get; set; }
        public string U_QCPARAMTERCODE { get; set; }
        public string U_QCPARAMETERVALUE { get; set; }
    }

    public class A_INV7Collection // Container Documnets
    {
        public int? LineId { get; set; }
        public string U_DOCUMENTYPE { get; set; }
        public string U_ATTACHMENTFILENAME { get; set; }
        public string U_ATTACHMENTPATH { get; set; }
    }

    public class A_INV8Collection // Doc Clearance Documents
    {
        public int? LineId { get; set; }
        public string U_DOCUMENTYPE { get; set; }
        public string U_ATTACHMENTFILENAME { get; set; }
        public string U_ATTACHMENTPATH { get; set; }
    }

    public class A_INV9Collection // Client Documents
    {
        public int? LineId { get; set; }
        public string U_DOCUMENTYPE { get; set; }
        public string U_ATTACHMENTFILENAME { get; set; }
        public string U_ATTACHMENTPATH { get; set; }
    }

    public class A_INV10Collection // Additional Attachments
    {
        public int? LineId { get; set; }
        public string U_REMARKS { get; set; }
        public string U_ATTACHMENTFILENAME { get; set; }
        public string U_ATTACHMENTPATH { get; set; }
    }

    #endregion

    #region A_ODRF

    public class A_ODRFDocuments
    {
        public A_ODRFDocuments()
        {
            A_DRF1Collection = new List<A_DRF1Collection>();
            A_DRF5Collection = new List<A_DRF5Collection>();
        }

        public int? DocEntry { get; set; }
        public string U_DOCENTRY { get; set; }
        public string U_MENUID { get; set; }

        public List<A_DRF1Collection> A_DRF1Collection { get; set; }
        public List<A_DRF5Collection> A_DRF5Collection { get; set; }
    }

    public class A_DRF1Collection // Terms & Condition
    {
        public int? LineId { get; set; }
        public string U_TERMSCODE { get; set; }
        public string U_TERMSNAME { get; set; }
        public string U_TERMSDESCRIPTION { get; set; }
    }

    public class A_DRF5Collection // Approver
    {
        public string U_APPROVEDID { get; set; }
        public string U_APPROVEDSTATUS { get; set; }
        public string U_APPROVEDREMARKS { get; set; }
        public string U_TABLENAME { get; set; }
        public string U_LEVEL { get; set; }
        public double? U_AMOUNT { get; set; }
        public string U_APPROVEDPOSITIONID { get; set; }
        public string U_CREATEDBY { get; set; }
        public string U_UPDATEDBY { get; set; }
        public string U_CREATEDDATE { get; set; }
        public string U_UPDATEDDATE { get; set; }
        public int? LineId { get; set; }
    }

    #endregion

    #endregion

    #region SOCompletedQty

    public class ParamSOCompletedQty
    {
        public string SchemaName { get; set; }
        public string SQDocEntry { get; set; }
        public string SQLineNum { get; set; }
    }

    #endregion

    #region WarrantyPercentage

    public class WarrantyPercentage
    {
        public string SchemaName { get; set; }
        public string ItemCode { get; set; }
        public string WarrantyType { get; set; }
        public string AdditionalWarrantyPeriod { get; set; }
    }

    #endregion

    #region CustomerCurrency

    public class CustomerCurrency
    {
        public string EMPID { get; set; }
        public string CustomerCode { get; set; }
        public string DocumentDate { get; set; }
    }

    #endregion

    #region SOVendorList

    public class SOVendorList
    {
        public string SchemaName { get; set; }
    }

    #endregion

    #region SalesDocumentAttachment

    public class ParamSalesDocumentAttachment
    {
        public string EMPID { get; set; }
        public string DOCTYPE { get; set; }
        public string DOCENTRY { get; set; }
    }

    #endregion



}