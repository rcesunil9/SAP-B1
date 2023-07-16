using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SAPWeb.Models
{
    #region Common

    public class ServiceDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public DataTable tab { get; set; }
    }

    public class ServiceDefaultSet
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public DataSet set { get; set; }
    }

    #endregion

    #region ParamSubCategory
    public class ParamComplaint
    {
        public string SchemaName { get; set; }
        public string EmpID { get; set; }
    }
    #endregion

    #region ServiceContract

    public class ParamServiceContract
    {
        public string SchemaName { get; set; }
        public string CardCode { get; set; }
    }

    public class ServiceContractListDefault
    {

        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<ServiceContract> ServiceContractList { get; set; }
    }

    public class ServiceContract
    {
        public string ContractID { get; set; }
        public string CustomerCode { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string ServiceType { get; set; }
    }

    #endregion

    #region CustomerComplain

    public class CustomerComplainListDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<CustomerComplainData> ComplainList { get; set; }
    }

    public class CustomerComplainListByNoDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<CustomerComplainListData> ComplainList { get; set; }
        public List<CustomerComplainListItemData> ComplainListItem { get; set; }
    }

    public class CustomerComplainListData
    {

        public string ComplainNo { get; set; }
        public string ComplainDate { get; set; }
        public string ComplainTime { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string AddressID { get; set; }
        public string ShipToAddressID { get; set; }
        public string ContactPersonID { get; set; }
        public string ContactPersonName { get; set; }
        public string SubCustName { get; set; }
        public string SubCustAddress { get; set; }
        public string SubCustContactPersonNo { get; set; }
        public string SubCustContactPersonName { get; set; }
        public string SubCustContactEmail { get; set; }
        public string ContractID { get; set; }
        public string CaseID { get; set; }
        public string CustStatusID { get; set; }
        public string CustStatusName { get; set; }
        public string AssignOld { get; set; }
        public string AssignOldName { get; set; }
        public string NatureofComID { get; set; }
        public string NatureofComName { get; set; }
        public string InformToWhomID { get; set; }
        public string InformToWhomName { get; set; }
        public string CompStatusID { get; set; }
        public string CompStatusName { get; set; }
        public string Remarks { get; set; }
        public string InformedDate { get; set; }
        public string InformedTime { get; set; }
        public string ProductType { get; set; }
        public string PrincipalCompany { get; set; }
        public string Model { get; set; }
    }

    public class CustomerComplainListItemData
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public Decimal? Quantity { get; set; }
        public string SerialNumber { get; set; }
        public string ServiceType { get; set; }
        public string ServiceTypeName { get; set; }
        public string RowRemarks { get; set; }
    }

    public class CustomerComplainData
    {
        public string ComplainNo { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        public string CaseID { get; set; }
        public string ComplainDate { get; set; }
        public string ComplainTime { get; set; }
        public string SubCustContactPersonName { get; set; }
        public string SubCustContactPersonNo { get; set; }
    }

    public class CustomerComplainDefault
    {
        public CustomerComplainDefault()
        {
            CustomerComplain = new List<CustomerComplain>();
        }
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<CustomerComplain> CustomerComplain { get; set; }
    }

    public class ParamCustomerComplainList
    {
        public string SchemaName { get; set; }
        public string COMPLAINNO { get; set; }
    }

    public class ParamServiceContractDataByCustomer
    {
        public string SchemaName { get; set; }
        public string CustomerCode { get; set; }
        public string ItemCode { get; set; }
        public string SerialNumber { get; set; }
    }

    public class CustomerComplain
    {
        public CustomerComplain()
        {
            A_CCM1Collection = new List<A_CCM1Collection>();
            A_CCM2Collection = new List<A_CCM2Collection>();
            A_CCM3Collection = new List<A_CCM3Collection>();
            A_CCM4Collection = new List<A_CCM4Collection>();
            A_CCM5Collection = new List<A_CCM5Collection>();
        }

        public string SchemaName { get; set; }
        public int? DocEntry { get; set; }

        public string U_COMPLAINNO { get; set; }
        public DateTime? U_COMPLAINDATE { get; set; }
        public string U_COMPLAINTIME { get; set; }
        public string U_CARDCODE { get; set; }
        public string U_ADDRESSID { get; set; }
        public string U_SHIPTOADDRESSID { get; set; }
        public string U_CONTACTPERSONID { get; set; }
        public string U_SUBCUSTNAME { get; set; }
        public string U_SUBCUSTADDR { get; set; }
        public string U_SUBCUSTCONTNO { get; set; }
        public string U_SUBCUSTCONTPERSON { get; set; }
        public string U_SUBCUSTCONTEMAL { get; set; }
        public string U_CASEID { get; set; }
        public string U_CUSTSTATUSID { get; set; }
        public string U_ASSIGNTOLD { get; set; }
        public string U_NATUREOFCOMID { get; set; }
        public string U_INFORMTOWHOMID { get; set; }
        public DateTime? U_INFORMEDDATE { get; set; }
        public string U_INFORMEDTIME { get; set; }
        public string U_COMPSTATUSID { get; set; }
        public string U_REMARKS { get; set; }

        public string U_PRODUCTTYPE { get; set; }
        public string U_PRINCIPALCOMPANY { get; set; }
        public string U_MODEL { get; set; }

        public string U_BRANCH { get; set; }
        public string U_CREATEDBY { get; set; }
        public string U_SYSTEMID { get; set; }
        public string U_PORTALMODULE { get; set; }

        public List<A_CCM1Collection> A_CCM1Collection { get; set; }
        public List<A_CCM2Collection> A_CCM2Collection { get; set; }
        public List<A_CCM3Collection> A_CCM3Collection { get; set; }
        public List<A_CCM4Collection> A_CCM4Collection { get; set; }
        public List<A_CCM5Collection> A_CCM5Collection { get; set; }
    }

    public class A_CCM1Collection
    {
        public string U_ITEMCODE { get; set; }
        public decimal? U_QUANTITY { get; set; }
        public string U_SERIALNUMBER { get; set; }
        public string U_REMARKS { get; set; }
        public string U_ITEMSTATUS { get; set; }
        public string U_SERVICECONTRACTID { get; set; }
    }

    public class A_CCM2Collection
    {
        public string U_NATUCOMCODE { get; set; }
        public string U_ACTIVE { get; set; }
    }

    public class A_CCM3Collection
    {
        public string U_DIAGONSISCODE { get; set; }
        public string U_ACTIVE { get; set; }
    }

    public class A_CCM4Collection
    {
        public string U_ACTIONTAKENCODE { get; set; }
        public string U_ACTIVE { get; set; }
    }

    public class A_CCM5Collection
    {
        public string U_SOLUTIONCODE { get; set; }
        public string U_ACTIVE { get; set; }
    }

    #endregion

    #region ServiceCall

    public class ServiceCallDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<ServiceCall> ServiceCall { get; set; }
    }

    public class ParamServiceCall
    {
        public string SchemaName { get; set; }
        public string COMPLINNO { get; set; }
        public string EMPID { get; set; }
    }

    public class ParamServiceMaxNumber
    {
        public string SchemaName { get; set; }
        public string DOCTYPE { get; set; }
        public string EMPID { get; set; }
    }

    public class CallCompletionDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
    }

    public class CallCompletion
    {
        public CallCompletion()
        {
            CallCompletionItemData = new List<CallCompletionItemData>();
            CallCompletionPartReplacement = new List<CallCompletionPartReplacement>();
            CallCompletionPartConsumption = new List<CallCompletionPartConsumption>();
        }

        public string errorCode { get; set; }
        public string errorMsg { get; set; }

        public string SchemaName { get; set; }
        public string EMPID { get; set; }
        public string Branch { get; set; }

        public int? ServiceCallID { get; set; }
        public string CustomerCode { get; set; }
        public string ShipToCode { get; set; }
        public string BillToCode { get; set; }
        public string ContactPersonCode { get; set; }

        public string ComplainNumber { get; set; }
        public string LocationType { get; set; }
        public string CustomerStatus { get; set; }
        public string SolvedDate { get; set; }
        public string SolvedTime { get; set; }
        public string OtherReason { get; set; }
        public string OtherReasonRemarks { get; set; }
        public string Reason { get; set; }
        public string ReasonRemarks { get; set; }
        public string FreeService { get; set; }
        public string InstructedBy { get; set; }
        public string SolutionGivenMode { get; set; }
        public string ComplaintStatus { get; set; }
        public string ItemDescProductType { get; set; }
        public string ItemDescPrincipalCompany { get; set; }
        public string ItemDescModel { get; set; }
        public string PartConsProductType { get; set; }
        public string PartConsPrincipalCompany { get; set; }
        public string PartConsModel { get; set; }
        public string PartReplProductType { get; set; }
        public string PartReplPrincipalCompany { get; set; }
        public string PartReplModel { get; set; }
        public string SystemID { get; set; }

        public List<CallCompletionItemData> CallCompletionItemData { get; set; }
        public List<CallCompletionPartReplacement> CallCompletionPartReplacement { get; set; }
        public List<CallCompletionPartConsumption> CallCompletionPartConsumption { get; set; }
    }

    public class CallCompletionItemData
    {
        public string ItemCode { get; set; }
        public string SerialNumber { get; set; }
        public string Diagnosis { get; set; }
        public string DiagnosisName { get; set; }
        public string ActionTaken { get; set; }
        public string ActionTakenName { get; set; }
    }

    public class CallCompletionPartReplacement
    {
        public string ItemCode { get; set; }
        public string SerialNumber { get; set; }
        public string Quantity { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public string ManBtchNum { get; set; }
        public string ManSerNum { get; set; }
    }

    public class CallCompletionPartConsumption
    {
        public string ItemCode { get; set; }
        public string SerialNumber { get; set; }
        public string Quantity { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public string ManBtchNum { get; set; }
        public string ManSerNum { get; set; }

    }

    public class ServiceCall
    {
        public string SchemaName { get; set; }

        public int? ServiceCallID { get; set; }
        public string ServiceBPType { get; set; }
        public string InternalSerialNum { get; set; }
        public string ItemCode { get; set; }
        public string CustomerCode { get; set; }
        public string BPShipToCode { get; set; }
        public string BPBillToCode { get; set; }
        public int? ContactCode { get; set; }
        public string Subject { get; set; }
        public string U_COMPLINNO { get; set; }
        public string U_LOCATIONTYPEID { get; set; }
        public string U_CUSTSTATUSID { get; set; }
        public DateTime? U_SOLVEDDATE { get; set; }
        public string U_SOLVEDTIME { get; set; }
        public string U_OTHERREASONID { get; set; }
        public string U_OTHERREASONTEXT { get; set; }
        public string U_REASONID { get; set; }
        public string U_REASONTEXT { get; set; }
        public string U_FREESERVICE { get; set; }
        public string U_INSTRUCTEDBYID { get; set; }
        public string U_SOLUTIONGIVENMODE { get; set; }
        public string U_COMPLAINSTATUSID { get; set; }
        public string U_ITEMDESCPRODTYPEID { get; set; }
        public string U_ITEMDESCPRINCOMPID { get; set; }
        public string U_ITEMDESCMODELID { get; set; }
        public string U_PARTCONSPRODTYPEID { get; set; }
        public string U_PARTCONSPRINCOMPID { get; set; }
        public string U_PARTCONSMODELID { get; set; }
        public string U_PARTREPLPRODTYPEID { get; set; }
        public string U_PARTREPLPRINCOMPID { get; set; }
        public string U_PARTREPLMODELID { get; set; }
        public string U_DIAGNOSIS { get; set; }
        public string U_ACTIONTAKEN { get; set; }

        public string U_REPAIRBRANCH { get; set; }
        public string U_BRANCH { get; set; }
        public string U_CREATEDBY { get; set; }
        public string U_SYSTEMID { get; set; }
        public string U_EMPID { get; set; }
        public string U_PORTALMODULE { get; set; }
        public string U_WHSCODE { get; set; }
        public string U_REPAIRWHSCODE { get; set; }
        public string U_FROMWHERE { get; set; }
        public string U_REPAIRFROMWHERE { get; set; }

        public string U_BASETYPE { get; set; }
        public string U_BASEENTRY { get; set; }
        public string U_BASELINE { get; set; }

        public int? Status { get; set; }
        public string Resolution { get; set; }

        public string U_STATUS { get; set; }
    }

    #endregion

    #region InwardOutwardEntry

    public class ParamInwardEntryList
    {
        public string SchemaName { get; set; }
        public string EMPID { get; set; }
        public string BRANCH { get; set; }

        public string FROMDATE { get; set; }
        public string TODATE { get; set; }
        public string DOCUMENTNUMBER { get; set; }
        public string SERIALNUMBER { get; set; }
        public string SERVICECALLID { get; set; }
        public string COURIERNUMBER { get; set; }
        public string CUSTOMERCODE { get; set; }
        public string ITEMCODE { get; set; }
        public string EWAYBILL { get; set; }
    }

    public class ParamOutwardEntryList
    {
        public string SchemaName { get; set; }
        public string EMPID { get; set; }
        public string BRANCH { get; set; }
        public string FROMDATE { get; set; }
        public string TODATE { get; set; }
        public string FROMWHERE { get; set; }
        public string JOBID { get; set; }
        public string CUSTOMERNAME { get; set; }
        public string OUTWARDNO { get; set; }
        public string INWARDDOCKETNO { get; set; }
        public string OUTWARDDOCKETNO { get; set; }
        public string CARDSERIALNO { get; set; }
        public string CARDMODEL { get; set; }
        public string SERVICECALLNO { get; set; }
        public string CUSTOMERCASEID { get; set; }
    }

    public class ParamInwardOutwardEntryComplain
    {
        public string SchemaName { get; set; }
        public string EMPID { get; set; }
        public string BRANCH { get; set; }
    }

    public class ParamInwardOutwardEntryComplainData
    {
        public string SchemaName { get; set; }
        public string COMPLAINNO { get; set; }
    }

    public class InwardOutwardEntryDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
    }

    public class ParamInwardOutwardEntryDocEntry
    {
        public string SchemaName { get; set; }
        public string DOCENTRY { get; set; }
    }

    public class InwardOutwardEntry
    {
        public InwardOutwardEntry()
        {
            InwardOutwardEntryLines = new List<InwardOutwardEntryLines>();
        }

        public string errorCode { get; set; }
        public string errorMsg { get; set; }

        public string SchemaName { get; set; }
        public string EMPID { get; set; }

        public int? DocEntry { get; set; }
        public string Branch { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentFrom { get; set; }
        public string DocumentDate { get; set; }
        public string DocumentTime { get; set; }
        public string RefNumber { get; set; }
        public string RefDate { get; set; }
        public string Box { get; set; }
        public string Weight { get; set; }
        public string CourierName { get; set; }
        public string CourierNo { get; set; }
        public string Ewaybill { get; set; }
        public string CardCode { get; set; }
        public string BillToCode { get; set; }
        public string ShipToCode { get; set; }
        public string ContactPerson { get; set; }
        public string SalesPersonCode { get; set; }
        public string Branch2 { get; set; }
        public string SYSTEMID { get; set; }

        public List<InwardOutwardEntryLines> InwardOutwardEntryLines { get; set; }
    }

    public class InwardOutwardEntryLines
    {
        public InwardOutwardEntryLines()
        {
            InwardOutwardLinesSpecialdata = new InwardOutwardLinesSpecialdata();
            InwardOutwardLinesProblemType = new List<InwardOutwardLinesProblemType>();
            InwardOutwardLinesAttachmentData = new List<InwardOutwardLinesAttachmentData>();
            InwardOutwardLinesAccessoriesData = new List<InwardOutwardLinesAccessoriesData>();
        }

        public string ObjType { get; set; }
        public string DocEntry { get; set; }
        public string LineNum { get; set; }

        public string ServiceCallID { get; set; }
        public string ItemType { get; set; }
        public string ItemCode { get; set; }
        public string Quantity { get; set; }
        public string SCNo { get; set; }
        public string SCDate { get; set; }
        public string SerialNo { get; set; }
        public string FromWhs { get; set; }
        public string ToWhs { get; set; }
        public string Status { get; set; }
        public string RepeatCount { get; set; }
        public string Price { get; set; }
        public string Itemremark { get; set; }
        public string ManBtchNum { get; set; }
        public string ManSerNum { get; set; }
        public string JobNo { get; set; }
        public string BatchID { get; set; }

        public InwardOutwardLinesSpecialdata InwardOutwardLinesSpecialdata { get; set; }
        public List<InwardOutwardLinesProblemType> InwardOutwardLinesProblemType { get; set; }
        public List<InwardOutwardLinesAttachmentData> InwardOutwardLinesAttachmentData { get; set; }
        public List<InwardOutwardLinesAccessoriesData> InwardOutwardLinesAccessoriesData { get; set; }
    }

    public class InwardOutwardLinesSpecialdata
    {
        public string SpecialDataID { get; set; }
        public string CradleSrNo { get; set; }
        public string DispatchLocation { get; set; }
        public string AdvanceReturnDate { get; set; }
        public string Distributor { get; set; }
        public string SotiDeviceNo { get; set; }
        public string FaultReceiveDate { get; set; }
        public string Remarks { get; set; }
        public string CaseID { get; set; }
        public string LotNo { get; set; }
        public string AdvanceReturnNo { get; set; }
        public string ServiceEmpCode { get; set; }
        public string IMEI1 { get; set; }
        public string IMEI2 { get; set; }
        public string Octroi { get; set; }
    }

    public class InwardOutwardLinesProblemType
    {
        public string ProblemType { get; set; }
        public string Remark { get; set; }
        public string ProblemStatus { get; set; }
    }

    public class InwardOutwardLinesAttachmentData
    {
        public string subject { get; set; }
        public string notes { get; set; }
        public string attchFileName { get; set; }
    }

    public class InwardOutwardLinesAccessoriesData
    {
        public string AccessoriesCode { get; set; }
        public string SerialNumber { get; set; }
        public string ReplaceSerialNumber { get; set; }
    }

    #endregion

    #region SAPCLASS

    public class InwardOutwardDocuments
    {
        public InwardOutwardDocuments()
        {
            DocumentLines = new List<InwardOutwardDocumentsLines>();
            StockTransferLines = new List<InwardOutwardDocumentsLines>();
        }

        public int? DocEntry { get; set; }

        public string U_Branch { get; set; }
        public string U_DOCNUMBER { get; set; }
        public string U_DOCFROM { get; set; }
        public DateTime? DocDate { get; set; }
        public string U_DOCTIME { get; set; }
        public string U_DOCREFNUMBER { get; set; }
        public DateTime? U_DOCREFDATE { get; set; }
        public string U_BOX { get; set; }
        public double? U_Weight { get; set; }
        public string U_CourierName { get; set; }
        public string U_CourierNo { get; set; }
        public string U_Ewaybill { get; set; }

        public string CardCode { get; set; }
        public string U_CARDCODE { get; set; }

        public string U_BILLTOADDRESS { get; set; }

        public string ShipToCode { get; set; }
        public string U_SHIPTOADDRESS { get; set; }

        public int? ContactPerson { get; set; }
        public string U_CONTACTPERSON { get; set; }

        public int? SalesPersonCode { get; set; }
        public string U_SALESEMPLOYEE { get; set; }
        public string U_SALESEMPLOYEE2 { get; set; }

        public string U_BRANCH2 { get; set; }
        public string U_COMPLINNO { get; set; }

        public string Comments { get; set; }

        public string U_CREATEDBY { get; set; }
        public string U_SYSTEMID { get; set; }
        public string U_PORTALMODULE { get; set; }

        public string U_STATUS { get; set; }

        public string FromWarehouse { get; set; }
        public string ToWarehouse { get; set; }

        public List<InwardOutwardDocumentsLines> DocumentLines { get; set; }
        public List<InwardOutwardDocumentsLines> StockTransferLines { get; set; }
    }

    public class InwardOutwardDocumentsLines
    {
        public InwardOutwardDocumentsLines()
        {
            BatchNumber = new List<BatchNumber>();
            SerialNumbers = new List<SerialNumbers>();
        }

        public string U_NEWADVANCEQUOTE { get; set; }
        public string U_ITEMTYPE { get; set; }
        public string ItemCode { get; set; }
        public double? Quantity { get; set; }
        public string U_SCNO { get; set; }
        public DateTime? U_SCDATE { get; set; }
        public string WarehouseCode { get; set; }
        public string FromWarehouseCode { get; set; }
        public string U_ITEMSTATUS { get; set; }
        public double? UnitPrice { get; set; }
        public string U_FreeTextDesc { get; set; }
        public string U_REPEATCOUNT { get; set; }
        public string U_JOBNUMBER { get; set; }
        public string U_BATCHID { get; set; }
        public string U_ITEMSTATUSSC { get; set; }

        public string U_SDID { get; set; }
        public string U_SDCRADLESRNO { get; set; }
        public string U_SDDISPATCHTOLOCATION { get; set; }
        public DateTime? U_SDADVANCERETURNDATE { get; set; }
        public string U_SDDISTRIBUTOR { get; set; }
        public string U_SDSOTIDEVICENO { get; set; }
        public DateTime? U_SDFAULTRECEIVEDDATE { get; set; }
        public string U_SDREMARKS { get; set; }
        public string U_SDCASEID { get; set; }
        public string U_SDLOTNO { get; set; }
        public string U_SDADVANCERETURNNO { get; set; }
        public string U_SDSERVICEEMPCODE { get; set; }
        public string U_SDIMEI1 { get; set; }
        public string U_SDIMEI2 { get; set; }
        public string U_SDOCTROIAPPLICABLE { get; set; }
        public string U_SERIALBATCHNUM { get; set; }

        public string U_BASETYPE { get; set; }
        public string U_BASEENTRY { get; set; }
        public string U_BASELINE { get; set; }

        public int? U_SrvCallId { get; set; }
        public string U_REPAIRENTRYDOCENTRY { get; set; }

        public List<BatchNumber> BatchNumber { get; set; }
        public List<SerialNumbers> SerialNumbers { get; set; }
    }

    public class BatchNumber
    {
        public string BatchNumberProperty { get; set; }
        public DateTime? AddmisionDate { get; set; }
        public double? Quantity { get; set; }
    }

    public class SerialNumbers
    {
        public string InternalSerialNumber { get; set; }
        public DateTime? ReceptionDate { get; set; }
        public double? Quantity { get; set; }
    }

    public class A_OINDCollection
    {
        public A_OINDCollection()
        {
            A_IND1Collection = new List<A_IND1Collection>();
            A_IND2Collection = new List<A_IND2Collection>();
            A_IND3Collection = new List<A_IND3Collection>();
        }

        public int? DocEntry { get; set; }
        public string U_INWARDNO { get; set; }
        public string U_DOCENTRY { get; set; }
        public string U_DOCOBJECT { get; set; }
        public string U_TABLENAME { get; set; }

        public List<A_IND1Collection> A_IND1Collection { get; set; }
        public List<A_IND2Collection> A_IND2Collection { get; set; }
        public List<A_IND3Collection> A_IND3Collection { get; set; }
    }

    public class A_IND1Collection
    {
        public string U_LINENUM { get; set; }
        public string U_PROBLEMTYPE { get; set; }
        public string U_REMARKS { get; set; }
        public string U_STATUS { get; set; }

    }

    public class A_IND2Collection
    {
        public string U_LINENUM { get; set; }
        public string U_SUBJECT { get; set; }
        public string U_REMARKS { get; set; }
        public string U_FILEPATH { get; set; }
    }

    public class A_IND3Collection
    {
        public string U_LINENUM { get; set; }
        public string U_ACCESSORIESCODE { get; set; }
        public string U_SERIALNUMBER { get; set; }
        public string U_REPLACESERIALNUMBER { get; set; }
    }

    public class A_OOTDCollection
    {
        public A_OOTDCollection()
        {
            A_OTD1Collection = new List<A_OTD1Collection>();
            A_OTD2Collection = new List<A_OTD2Collection>();
            A_OTD3Collection = new List<A_OTD3Collection>();
        }

        public int? DocEntry { get; set; }
        public string U_OUTWARDNO { get; set; }
        public string U_DOCENTRY { get; set; }
        public string U_DOCOBJECT { get; set; }
        public string U_TABLENAME { get; set; }

        public List<A_OTD1Collection> A_OTD1Collection { get; set; }
        public List<A_OTD2Collection> A_OTD2Collection { get; set; }
        public List<A_OTD3Collection> A_OTD3Collection { get; set; }
    }

    public class A_OTD1Collection
    {
        public string U_LINENUM { get; set; }
        public string U_PROBLEMTYPE { get; set; }
        public string U_REMARKS { get; set; }
        public string U_STATUS { get; set; }

    }

    public class A_OTD2Collection
    {
        public string U_LINENUM { get; set; }
        public string U_SUBJECT { get; set; }
        public string U_REMARKS { get; set; }
        public string U_FILEPATH { get; set; }
    }

    public class A_OTD3Collection
    {
        public string U_LINENUM { get; set; }
        public string U_ACCESSORIESCODE { get; set; }
        public string U_SERIALNUMBER { get; set; }
        public string U_REPLACESERIALNUMBER { get; set; }
    }

    #endregion

    #region RepairEntry

    public class RepairEntryDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
    }

    public class ParamRepairEntryList
    {
        public string SchemaName { get; set; }
        public string EMPID { get; set; }
        public string BRANCH { get; set; }
        public string FROMDATE { get; set; }
        public string TODATE { get; set; }
        public string JOBID { get; set; }
        public string SERVICECALLNUMBER { get; set; }
    }

    public class ParamRepairEntryDataByID
    {
        public string SchemaName { get; set; }
        public string SERVICECALLID { get; set; }
        public string REPAIRENTRYID { get; set; }
    }

    public class RepairEntry
    {
        public RepairEntry()
        {
            A_RPE1Collection = new List<A_RPE1Collection>();
            A_RPE2Collection = new List<A_RPE2Collection>();
            A_RPE3Collection = new List<A_RPE3Collection>();
            A_RPE4Collection = new List<A_RPE4Collection>();
            A_RPE5Collection = new List<A_RPE5Collection>();
        }

        public string SchemaName { get; set; }
        public int? DocEntry { get; set; }

        public string U_DOCUMENTNUMBER { get; set; }
        public DateTime? U_DOCUMENTDATE { get; set; }
        public DateTime? U_STARTDATE { get; set; }
        public string U_STARTTIME { get; set; }
        public string U_CARDCODE { get; set; }
        public string U_SERVICECALLID { get; set; }
        public string U_BRANCH { get; set; }
        public string U_CARDSERIALNO { get; set; }
        public string U_PROBLEMSTATUS { get; set; }
        public string U_REPAIRSTATUS { get; set; }
        public string U_REPEATSTATUS { get; set; }
        public string U_REPEATREMARKS { get; set; }
        public DateTime? U_ONHRDATE { get; set; }
        public string U_ONHRTIME { get; set; }
        public DateTime? U_HRFAILDATE { get; set; }
        public DateTime? U_HROKDATE { get; set; }
        public string U_HROKTime { get; set; }
        public DateTime? U_ONHR2DATE { get; set; }
        public string U_DELAYFORREPAIR { get; set; }
        public string U_RMANUMBER { get; set; }
        public string U_UDFRMACost { get; set; }
        public DateTime? U_RMASENTDATE { get; set; }
        public DateTime? U_RMARETURNDATE { get; set; }
        public double? U_PRINCIPALCOST { get; set; }
        public double? U_OTHERCOST { get; set; }
        public string U_ESTIMATEGIVENTO { get; set; }
        public DateTime? U_ESTIMATEDATE { get; set; }
        public DateTime? U_ESTIMATEAPPREJDATE { get; set; }
        public double? U_ESTIMATEAMOUNT { get; set; }
        public string U_ESTIMATEGIVEN { get; set; }
        public string U_ESTIMATEAPPROVE { get; set; }
        public double? U_ESTIMATEAPPROVEAMOUNT { get; set; }
        public string U_MAILREASON { get; set; }
        public DateTime? U_MAILDATE { get; set; }
        public DateTime? U_MAILSENDDATE { get; set; }
        public DateTime? U_MAILRECEIVEDDATE { get; set; }
        public string U_HWVERSION { get; set; }
        public string U_HWFAILUREANALYSIS { get; set; }
        public string U_OLDSWVERSION { get; set; }
        public string U_NEWSWVERSION { get; set; }
        public string U_NEWSOTIDEVICEID { get; set; }
        public string U_PROBLEMANALYSIS { get; set; }
        public string U_FEATURELICENSE { get; set; }
        public string U_TESTDONE { get; set; }
        public string U_REMARKS { get; set; }
        public double? U_SERVICECHARGE { get; set; }
        public double? U_COMPONENTCHARGE { get; set; }
        public double? U_ADDITIONALCHARGE { get; set; }
        public double? U_COURIERCHARGE { get; set; }
        public double? U_SUBTOTALCHARGE { get; set; }
        public double? U_DISCOUNTPERCENTAGE { get; set; }
        public double? U_DISCOUNTPRICE { get; set; }
        public double? U_TOTALCHARGE { get; set; }
        public string U_GSTPERCENTAGE { get; set; }
        public double? U_GSTCHARGE { get; set; }
        public double? U_SUBNETCHARGE { get; set; }
        public double? U_ROUNDING { get; set; }
        public double? U_NETCHARGE { get; set; }
        public string U_CHARGESREMARKS { get; set; }
        public string U_ITEMCODE { get; set; }
        public string U_REPEATCOUNT { get; set; }
        public string U_LABOURCOSTCATEGORY { get; set; }
        public string U_ISCLOSE { get; set; }

        public string U_CREATEDBY { get; set; }
        public string U_SYSTEMID { get; set; }
        public string U_PORTALMODULE { get; set; }

        public List<A_RPE1Collection> A_RPE1Collection { get; set; }
        public List<A_RPE2Collection> A_RPE2Collection { get; set; }
        public List<A_RPE3Collection> A_RPE3Collection { get; set; }
        public List<A_RPE4Collection> A_RPE4Collection { get; set; }
        public List<A_RPE5Collection> A_RPE5Collection { get; set; }
    }

    public class A_RPE1Collection
    {
        public int? LineId { get; set; }
        public string U_PROBLEMLISTCODE { get; set; }
        public string U_ISACTIVE { get; set; }
    }

    public class A_RPE2Collection
    {
        public int? LineId { get; set; }
        public string U_SOLUTIONLISTCODE { get; set; }
        public string U_ISACTIVE { get; set; }
    }
    public class A_RPE4Collection
    {
        public int? LineId { get; set; }
        public string U_MAILREASONLISTCODE { get; set; }
        public string U_ISACTIVE { get; set; }
    }
    public class A_RPE5Collection
    {
        public string U_HVERSION { get; set; }
        public string U_OSVERSION { get; set; }
        public string U_NSVERSION { get; set; }
    }
    public class A_RPE3Collection
    {
        public int? LineId { get; set; }
        public string U_ITEMCODE { get; set; }
        public string U_SERIALNUMBER { get; set; }
        public double? U_PRICE { get; set; }
        public double? U_QUANTITY { get; set; }
        public string U_OLDITEMCODE { get; set; }
        public string U_OLDSERIALNUMBER { get; set; }
        public string U_REMARKS { get; set; }
        public string U_MANBTCHNUM { get; set; }
        public string U_MANSERNUM { get; set; }
        public string U_NEWADVANCEQUOTE { get; set; }
    }

    #endregion

    #region  ComplainEntryList

    public class ParamComplainEntryList
    {
        public string SchemaName { get; set; }
        public string FROMDATE { get; set; }
        public string TODATE { get; set; }
        public string EMPID { get; set; }
    }

    public class ParamComplainEntryItemList
    {
        public string SchemaName { get; set; }
        public string DOCENTRY { get; set; }
    }

    #endregion
}