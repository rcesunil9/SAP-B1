using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SAPWeb.Models
{

    public class BusinessPartnersTab
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public DataTable tab { get; set; }
    }

    public class BusinessPartnersDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public BusinessPartners BusinessPartner { get; set; }
    }

    public class BusinessPartnersDefaultCheckDuplicate
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public string isUnique { get; set; }
    }

    public class ParamBusinessPartnersApproval
    {
    public string EMPID { get; set; }
    }

    public class ParamBusinessPartnersList
    {
    
        public string EMPID { get; set; }
        public string CUSTOMERCODE { get; set; }
    }

    public class ParamBusinessPartnersSeries
    {
        public string EMPID { get; set; }
        public string CardType { get; set; }
    }
    public class ParamBusinessPartnersSeriesLToC
    {
        public string EMPID { get; set; }
        public string CardCode { get; set; }
    }

    #region SeriesList
    public class SeriesDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<Series> series { get; set; }
    }
    public class Series
    {
        public int SeriesCode { get; set; }
        public string SeriesName { get; set; }

    }
    #endregion

    public class ParamBusinessPartners
    {
        public string EMPID { get; set; }
        public string CardCode { get; set; }
    }


    public class ParamBusinessPartnersCINNumber
    {
        public string EMPID { get; set; }
        public string CINNO { get; set; }
    }

    public class BusinessPartners
    {
        public BusinessPartners()
        {
            BPAddresses = new List<BPAddresses>();
            ContactEmployees = new List<ContactEmployees>();
            BPFiscalTaxIDCollection = new List<BPFiscalTaxIDCollection>();
            BPBankInformation = new List<A_CRD2Collection>();
            DataAttachment = new List<BPDataAttachment>();
        }

        public string U_EMPID { get; set; }
        public int? Series { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string CardType { get; set; }
        public int? GroupCode { get; set; }
        public int? SalesPersonCode { get; set; }
        public string Frozen { get; set; }
        public string Currency { get; set; }

        public string U_TRADEREGION { get; set; }
        public string U_BUSIMARKETWORTH { get; set; }
        public string U_CLIENTBRAND { get; set; }
        public string U_CLIENTPRODUCT { get; set; }
        public string U_SYSTEMID { get; set; }

        public string U_CREATEDBY { get; set; }
        public string U_CREATEDDATE { get; set; }
        public string U_UPDATEDBY { get; set; }
        public string U_UPDATEDDATE { get; set; }

        public string UseBillToAddrToDetermineTax { get; set; }
        public string Notes { get; set; }
        public int? AttachmentEntry { get; set; }

        public List<BPAddresses> BPAddresses { get; set; }
        public List<ContactEmployees> ContactEmployees { get; set; }
        public List<BPFiscalTaxIDCollection> BPFiscalTaxIDCollection { get; set; }
        public List<A_CRD2Collection> BPBankInformation { get; set; }
        public List<BPDataAttachment> DataAttachment { get; set; }
    }

    public class BPAddresses
    {
        public string BPCode { get; set; }
        public int? RowNum { get; set; }
        public string AddressName { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string GSTIN { get; set; }
        public string GstType { get; set; }
        public string AddressType { get; set; }
        public string Block { get; set; }
        public string U_PANNUMBER { get; set; }
        public string U_CITYCODE { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }

    }

    public class ContactEmployees
    {
        public int? InternalCode { get; set; }
        public string CardCode { get; set; }
        public string Name { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string MobilePhone { get; set; }
        public string Fax { get; set; }
        public string E_Mail { get; set; }
        public string Position { get; set; }
        public string Remarks1 { get; set; }
        public string Address { get; set; }
        public string U_WHATSAPPNUMBER { get; set; }
    }

    public class BPFiscalTaxIDCollection
    {
        public string Address { get; set; }
        public string TaxId0 { get; set; }
        public string TaxId1 { get; set; }
        public string TaxId2 { get; set; }
        public string TaxId3 { get; set; }
        public string TaxId4 { get; set; }//CIN No
        public string TaxId5 { get; set; }
        public string TaxId6 { get; set; }
        public string TaxId7 { get; set; }
        public string TaxId8 { get; set; }
        public string TaxId9 { get; set; }
        public string TaxId10 { get; set; }
        public string TaxId11 { get; set; }
        public string TaxId12 { get; set; }
        public string TaxId13 { get; set; }
        public string BPCode { get; set; }
        public string AddrType { get; set; }
    }

    public class BPDataAttachment
    {
        public string Subject { get; set; }
        public string Notes { get; set; }
        public string AttachFileName { get; set; }
        public string AttachPath { get; set; }

        public string Base64 { get; set; }
        public string FileName { get; set; }
        public string Extention { get; set; }
    }

    public class A_OCRD
    {
        public A_OCRD()
        {
            A_CRD2Collection = new List<A_CRD2Collection>();
        }

        public string Code { get; set; } // CustomerCode
        public string Name { get; set; } // CustomerName
        
        public List<A_CRD2Collection> A_CRD2Collection { get; set; }
    }

    public class A_CRD2Collection
    {
        public int? LineId { get; set; }
        public string U_BANKNAME { get; set; }
        public string U_ACCOUNTNUMBER { get; set; }
        public string U_ACCOUNTTYPE { get; set; }
        public string U_BANKBRANCH { get; set; }
        public string U_BRANCHCODE { get; set; }
        public string U_ADDRESS { get; set; }
        public string U_CITYCODE { get; set; }
        public string U_CITYNAME { get; set; }
        public string U_PINCODE { get; set; }
        public string U_STATECODE { get; set; }
        public string U_STATENAME { get; set; }
        public string U_COUNTRYCODE { get; set; }
        public string U_COUNTRYNAME { get; set; }
        public string U_ISACTIVE { get; set; }
    }

    public class PendingBPListDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<PendingBPList> BPList { get; set; }
    }

    public class PendingBPList
    {
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string CardType { get; set; }
        public int GroupCode { get; set; }
        public string GroupName { get; set; }
        public int SubVerticaleID { get; set; }
        public string SubVerticaleName { get; set; }
        public int SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public string CIN { get; set; }
        public string Dealer { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public string CreatedDate { get; set; }
        public int SlpCode { get; set; }
        public string SlpName { get; set; }
        public string NatureofBussinessCode { get; set; }
        public string NatureofBussiness { get; set; }
        public string TradeRegion { get; set; }
        public string ContactPersonNm { get; set; }
        public string ContactPersonMobileNo { get; set; }
    }

    //public class PendingBPApprovalDefault
    //{
    //    public string errorCode { get; set; }
    //    public string errorMsg { get; set; }
    //    public List<PendingBPApproval> BPList { get; set; }
    //}

    //public class PendingBPApproval
    //{
    //    public string CardCode { get; set; }
    //    public string CardName { get; set; }
    //    public string CardType { get; set; }
    //    public int GroupCode { get; set; }
    //    public string GroupName { get; set; }
    //    public int SubVerticaleID { get; set; }
    //    public string SubVerticaleName { get; set; }
    //    public int SubCategoryID { get; set; }
    //    public string SubCategoryName { get; set; }
    //    public string CIN { get; set; }
    //    public string Dealer { get; set; }
    //    public string CreatedBy { get; set; }
    //    public string CreatedName { get; set; }
    //    public string CreatedDate { get; set; }
    //    public int SlpCode { get; set; }
    //    public string SlpName { get; set; }
    //}


    //public class ParamBPApproval
    //{
    //    public string SchemaName { get; set; }
    //    public List<BPStatus> bpstatus { get; set; }
    //}

    //public class BPStatus
    //{
    //    public string Remarks { get; set; }
    //    public string Status { get; set; }
    //    public string CardCode { get; set; }
    //    public string SYSTEMID { get; set; }
    //    public string errorCode { get; set; }
    //    public string errorMsg { get; set; }
    //}

    //public class BPListApprovalDefault
    //{
    //    public string errorCode { get; set; }
    //    public string errorMsg { get; set; }
    //    public List<BPStatus> oBPDefault { get; set; }
    //}

    //#region BP Master

    //public class A_OCRD
    //{
    //    public A_OCRD()
    //    {
    //        A_CRD1Collection = new List<A_CRD1Collection>();
    //        A_OCPRCollection = new List<A_OCPRCollection>();
    //    }

    //    public string Code { get; set; }
    //    public string Name { get; set; }
    //    public string U_CardCode { get; set; }
    //    public string U_CardName { get; set; }
    //    public string U_CardType { get; set; }
    //    public int? U_GroupCode { get; set; }
    //    public int? U_SalesPersonCode { get; set; }
    //    public string U_ChannelBP { get; set; }
    //    public string U_Currency { get; set; }

    //    public string U_SUBVERTICALE { get; set; }
    //    public string U_SUBCAT { get; set; }
    //    public string U_Dealer { get; set; }
    //    public string U_Status { get; set; }
    //    public string U_EMPID { get; set; }
    //    public string U_SYSTEMID { get; set; }

    //    public string U_APPROVEDID { get; set; }
    //    public string U_APPROVEDLEVEL { get; set; }
    //    public string U_APPROVEDPOSITIONID { get; set; }

    //    public string U_CINNUMBER { get; set; }
    //    public string U_Notes { get; set; }
    //    public int? U_PayTermsGrpCode { get; set; }
    //    public int? U_LogInstance { get; set; }
    //    public string U_Active { get; set; }

    //    public List<A_CRD1Collection> A_CRD1Collection { get; set; }
    //    public List<A_OCPRCollection> A_OCPRCollection { get; set; }
    //}

    //public class A_CRD1Collection
    //{
    //    public string U_BPCode { get; set; }
    //    public int? U_RowNum { get; set; }
    //    public string U_AddressName { get; set; }
    //    public string U_State { get; set; }
    //    public string U_City { get; set; }
    //    public string U_Street { get; set; }
    //    public string U_ZipCode { get; set; }
    //    public string U_Country { get; set; }
    //    public string U_GSTIN { get; set; }
    //    public string U_GstType { get; set; }
    //    public string U_AddressType { get; set; }
    //    public string U_Block { get; set; }
    //    public string U_PANNUMBER { get; set; }
    //    public string U_CITYCODE { get; set; }
    //}

    //public class A_OCPRCollection
    //{
    //    public int? U_InternalCode { get; set; }
    //    public string U_CardCode { get; set; }
    //    public string U_Name { get; set; }
    //    public string U_FirstName { get; set; }
    //    public string U_LastName { get; set; }
    //    public string U_Phone1 { get; set; }
    //    public string U_Phone2 { get; set; }
    //    public string U_MobilePhone { get; set; }
    //    public string U_Fax { get; set; }
    //    public string U_E_Mail { get; set; }
    //    public string U_Position { get; set; }
    //    public string U_Remarks1 { get; set; }
    //    public string U_Address { get; set; }
    //}

    //#endregion
}