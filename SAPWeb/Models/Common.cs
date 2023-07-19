using System;
using System.Collections.Generic;
using System.Data;

namespace SAPWeb.Models
{
    public class CommonDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public DataTable tab { get; set; }
    }

    public class CommonDefaultDS
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public DataSet tab { get; set; }
    }

    public class CommonDefaultBP
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public DataTable Customer { get; set; }
    }

    public class ParamCommon
    {
        public string EMPID { get; set; }
        public string DOCENTRY { get; set; }
    }
    public class ParamCommonWithEmpId
    {
        public string EMPID { get; set; }
    }
    public class ParamGroupCode
    {
        public string EMPID { get; set; }
        public string GroupCode { get; set; }
    }
    #region ProductType
    public class ProductDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<ProductType> ProductType { get; set; }

    }
    public class ProductType
    {
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
    }
    #endregion

    #region PrincipleCompany
    public class PrincipleCompanyDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<PrincipleCompany> PrincipleCompany { get; set; }

    }
    public class PrincipleCompany
    {
        public string FirmCode { get; set; }
        public string FirmName { get; set; }
    }
    #endregion

    #region LocationList
    public class LocationDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<Location> GetAllLocation { get; set; }
    }
    public class Location
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    #endregion

    #region NoObjectList
    public class NoObjectDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<NoObject> NoObjectData { get; set; }
    }
    public class NoObject
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    #endregion

    #region EmployeeList

    public class PramEmployeeList
    {
        public string EMPID { get; set; }
        public int Department { get; set; }

    }

    public class EmployeesInfoDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<EmployeesInfo> Employee { get; set; }
    }
    public class EmployeesInfo
    {
        public int? EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int? Department { get; set; }
        public string DepartmentName { get; set; }
        public int? Manager { get; set; }
        public int? SalesPersonCode { get; set; }
        public string MobilePhone { get; set; }
        public string ExternalEmployeeNumber { get; set; }
        public string EmailID { get; set; }
        public string U_TOKEN { get; set; }

    }

    #endregion

    #region Token

    public class TokenDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
    }

    public class ParamToken
    {
        public string EMPID { get; set; }

        public string Token { get; set; }
    }

    public class ParamTokenUpdate
    {
        public string EMPID { get; set; }
        public string Token { get; set; }
        public string DeviceID { get; set; }
    }

    #endregion

    #region LocationDetail
    public class LocationDetailDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<LocationDetail> GetLocationDetail { get; set; }
    }
    public class LocationDetail
    {
        public string GSTNO { get; set; }
        public string ADDRESS { get; set; }
        public string BRANCHPHONE { get; set; }
        public string BRANCHCONTACTPERSON { get; set; }
        public string BRANCHCONTACTEMAIL { get; set; }
    }
    public class LocationDetailDefaultParameter
    {
        public string EMPID { get; set; }
        public string LocationCode { get; set; }
    }
    #endregion

    #region CourieMaster
    public class CourierMasterDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<CourierMasterData> GetCourierMaster { get; set; }
    }
    public class CourierMasterData
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class ParameterForCourirMaster
    { public string EMPID { get; set; } }
    #endregion

    #region CustomerList
    public class CustomerDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<Customer> Customer { get; set; }

    }
    public class Customer
    {
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
        public string ContactPerson { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public string GSTNumber { get; set; }
        public string Currency { get; set; }
    }

    #endregion

    #region StateList
    public class StateDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<State> State { get; set; }

    }
    public class State
    {
        public string StateCode { get; set; }
        public string StateName { get; set; }

    }
    #endregion

    #region VerticalList
    public class VerticalDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<Vertical> VerticalList { get; set; }

    }
    public class Vertical
    {
        public string Code { get; set; }
        public string Name { get; set; }

    }
    #endregion

    #region SubVerticalList
    public class SubVerticalDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<SubVertical> SubVerticalList { get; set; }

    }
    public class SubVertical
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string GroupCode { get; set; }
        public string GroupName { get; set; }
    }
    #endregion

    #region SubCategoryList
    public class SubCategoryDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<SubCategory> SubCategoryList { get; set; }

    }
    public class SubCategory
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string SubVerticaleCode { get; set; }
        public string SubVerticaleName { get; set; }
    }
    #endregion

    #region Country
    public class CountryDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<Country> country { get; set; }

    }
    public class Country
    {
        public string Code { get; set; }
        public string Name { get; set; }

    }
    #endregion

    #region CityList
    public class CityDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<City> City { get; set; }

    }
    public class City
    {
        public string CityCode { get; set; }
        public string CityName { get; set; }

    }
    #endregion

    #region TravelMode
    public class TravelModedefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<TravelMode> TravelMode { get; set; }
    }
    public class TravelMode
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    #endregion

    #region ItemList
    public class ItemDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<Item> Items { get; set; }

    }
    public class Item
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string ManBtchNum { get; set; }
        public string ManSerNum { get; set; }
        public string VendorCode { get; set; }

    }
    #endregion

    #region SubGroupList
    public class SubGroupDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<SubGroup> SubGroups { get; set; }

    }
    public class SubGroup
    {
        public string Code { get; set; }
        public string Name { get; set; }

    }
    #endregion

    #region ProjectList
    public class ProjectDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<Project> Projects { get; set; }

    }
    public class Project
    {
        public string Code { get; set; }
        public string Name { get; set; }

    }

    #endregion

    #region CompetitorList
    public class CompetitorDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<Competitor> Competitors { get; set; }

    }
    public class CompetitorDetailDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<CompetitorDetail> CompetitorsDetail { get; set; }

    }
    public class Competitor
    {
        public string Code { get; set; }
        public string Name { get; set; }

    }
    public class CompetitorDetail
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ThrearLevel { get; set; }
    }
    public class ParamCompetitor
    {

        public string EMPID { get; set; }
        public string Id { get; set; }
    }
    #endregion

    #region ServerDateTime
    public class ServerDateTime
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public string ServerTime { get; set; }

    }

    #endregion

    #region WarrentyList
    public class WarrentyDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<Warrenty> Warrenty { get; set; }


    }
    public class Warrenty
    {
        public string Code { get; set; }
        public string Name { get; set; }

    }

    #endregion

    #region OpprtunityList
    public class SalesOpprtunityForSalesQuotationDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<SalesOpprtunityForSalesQuotation> OpprtunityDataOppCodeAndCardCodeName { get; set; }
    }
    public class SalesOpprtunityForSalesQuotation
    {
        public string OpprtunityCode { get; set; }
        public string CustomerCodeName { get; set; }
    }
    public class ParamListForSalesOpprtunityForSalesQuotationDefault
    {
        public string EMPID { get; set; }
    }
    #endregion

    #region TaxCodeList
    public class TaxCodeDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<TaxCode> GetTaxCode { get; set; }
    }
    public class TaxCode
    {
        public string Code { get; set; }
        public string Value { get; set; }
    }
    public class ParamListTaxCode
    {
        public string EMPID { get; set; }
    }
    #endregion

    #region SchemaCommonModel
    public class Schema
    {
        public string EMPID { get; set; }

    }
    #endregion

    #region GetPrincipal
    public class GetPrincipal
    {
        public string EMPID { get; set; }
        public string ProductType { get; set; }

    }
    #endregion

    #region GetStateModel
    public class GetState
    {
        public string EMPID { get; set; }
        public string Country { get; set; }

    }
    #endregion

    #region GetCityModel
    public class GetCity
    {
        public string EMPID { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
    #endregion

    #region GetItemsFromProductTypeAndPrinciple
    public class GetItems
    {
        public string EMPID { get; set; }
        public string ProductType { get; set; }
        public string PrincipleCompany { get; set; }
        public string ItemModel { get; set; }
        public string ProductSubGroup { get; set; }

    }
    #endregion

    #region GetItemsDetailsByItemCode
    public class GetItemDetails
    {
        public string EMPID { get; set; }
        public string ItemCode { get; set; }

    }
    #endregion

    #region GetWarrentyDetailsByType
    public class GetWarrentyDetails
    {
        public string EMPID { get; set; }
        public string Type { get; set; }

    }
    #endregion

    #region GetContactPersonByCardCode
    public class ContactPersonDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<ContactPerson> ContactPerson { get; set; }
    }
    public class ContactPerson
    {
        public string CODE { get; set; }
        public string NAME { get; set; }
        public string OVERDUEAMOUNT { get; set; }
        public string BRANDNAME { get; set; }
    }
    public class ParamListForGetContactPerson
    {
        public string EMPID { get; set; }
        public string CardCode { get; set; }

    }
    #endregion

    #region GetContactPersonMobileNoEmailByContactPersonID
    public class ContactPersonMobileNoEmailDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<ContactPersonMobileNoEmail> ContactPersonMobileNoEmail { get; set; }
    }
    public class ContactPersonMobileNoEmail
    {
        public string MobileNo { get; set; }
        public string Email { get; set; }

    }
    public class ParamListForGetContactPersonMobileNoEmail
    {
        public string EMPID { get; set; }
        public string ContactPersonID { get; set; }

    }
    #endregion

    #region GetPaymentTerms
    public class PaymentTermsDefaultByCardCode
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<PaymentTermsByCardCode> PaymentTerms { get; set; }
    }
    public class PaymentTermsByCardCode
    {
        public string CODE { get; set; }
        public string NAME { get; set; }
    }
    public class ParamListForPaymentTerms
    {
        public string EMPID { get; set; }
        public string CardCode { get; set; }
    }
    #endregion

    #region GetOpportunityStage
    public class OpportunityStageDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<Stage> Stage { get; set; }
    }
    public class Stage
    {
        public string Number { get; set; }
        public string Description { get; set; }
        public string Step { get; set; }
        public string ClosingPer { get; set; }
    }
    public class ParamListForGetOpportunityStage
    {
        public string EMPID { get; set; }

    }
    public class PramSchemaName
    {
        public string EMPID { get; set; }
    }

    public class PramVerticals
    {
        public string EMPID { get; set; }
        public string CardType { get; set; }
    }
    #endregion

    #region ParamSubVertical
    public class PramSubVertical
    {
        public string EMPID { get; set; }
        public string VerticalID { get; set; }
    }
    #endregion

    #region ParamSubCategory
    public class ParamSubCategory
    {
        public string EMPID { get; set; }
        public string SubVerticalID { get; set; }
    }
    #endregion

    #region GetBillToShipTo
    public class AddressDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<Address> Address { get; set; }
    }
    public class Address
    {
        public string CAddress { get; set; }

    }
    public class AddressDetailDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<AddressDetail> AddressDetail { get; set; }
    }
    public class AddressDetail
    {
        public string Address { get; set; }
        public string Street { get; set; }
        public string Block { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string GSTNo { get; set; }
        public string ContactPerson { get; set; }

    }
    public class ParamBillToShipTo
    {
        public string EMPID { get; set; }
        public string CardCode { get; set; }
        public string Type { get; set; }
        public string Flag { get; set; }
        public string Address { get; set; }

    }
    #endregion

    #region GetPercentageForClosingStage
    public class PercentageDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<Percentage> Percentage { get; set; }
    }

    public class Percentage
    {
        public string STEPID { get; set; }
        public string PERCANTAGE { get; set; }

    }
    public class ParamPercentage
    {
        public string EMPID { get; set; }
        public string StepID { get; set; }

    }

    #endregion

    #region GetTermsAndcondition
    public class TermsConditionDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<TermsAndCondition> GetTermsAndConditionData { get; set; }
    }
    public class TermsAndCondition
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LineId { get; set; }
    }
    public class ParamDataTermsAndContion
    {
        public string EMPID { get; set; }
    }
    #endregion

    #region GetPaymentTerm
    public class PaymentTermsDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<PaymentTerms> GetPaymentTerms { get; set; }
    }
    public class PaymentTerms
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class ParamPaymentTerms
    {
        public string EMPID { get; set; }
    }
    #endregion

    #region GetItemDetail
    public class ItemDetailDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<ItemDetail> GetItemDetail { get; set; }
    }
    public class ItemDetail
    {
        public string ItemDescription { get; set; }
        public string HSNCode { get; set; }
        public string AdditionalWarranty { get; set; }
        public string CurrentBomItemPrice { get; set; }
        public string CurrentBomItemPriceFlag { get; set; }
        public string LOGEDINUSERFACTOR { get; set; }
        public string UOMCode { get; set; }
        public string LASTSALESPRICE { get; set; }
        public string LASTPURCHASEPRICE { get; set; }
        public string MINIMIUMORDERQTY { get; set; }
        public string MANBTCHNUM { get; set; }
        public string MANSERNUM { get; set; }
        public string SERVICECHARGE { get; set; }
        public string USDPRICE { get; set; }
        public string USDPERCENTAGE { get; set; }
        public string MARGIN { get; set; }
        public string MRPPRICE { get; set; }
        public string ITEMCODE { get; set; }
        public string ISFORECASTITEM { get; set; }
    }
    public class ParaItemDetail
    {
        public string EMPID { get; set; }
        public string ItemCode { get; set; }
        public string SlpCode { get; set; }
        public string CustomerCode { get; set; }
    }

    public class ParaAlternateItemDetail
    {
        public string EMPID { get; set; }
        public string ItemCode { get; set; }
    }

    #endregion

    #region GetSalesEmployee
    public class SalesEmployeeDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<SalesEmployee> GetSalesEmployee { get; set; }
    }
    public class SalesEmployee
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }

    }
    public class ParamSchemaNameForSalesEmployee
    {
        public string EMPID { get; set; }
    }

    public class ParamSchemaNameForSalesEmployeeBranchWise
    {
        public string EMPID { get; set; }
        public string LoginBranch { get; set; }
    }

    public class ParamEmpCodesForName
    {
        public string EMPID { get; set; }
        public string EmpCodes { get; set; }
    }
    #endregion

    #region GetWareHouse
    public class WareHouseDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<WareHouse> GetWareHouse { get; set; }
    }
    public class WareHouse
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class ParamWareHouse
    {
        public string EMPID { get; set; }
        public string UserName { get; set; }
    }
    #endregion

    #region GetEmployeeHierarchy
    public class EmpHierarchyDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<EmpHierarchy> EmpHierarchyList { get; set; }
    }
    public class EmpHierarchy
    {
        public string ExternalEmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class ParamEmpHierarchy
    {
        public string EMPID { get; set; }

    }
    #endregion

    #region GetCustomerServiceStatus
    public class CustomerServiceStatusDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<CustomerServiceStatus> GetCustomerServiceStatus { get; set; }
    }
    public class CustomerServiceStatus
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class ParamCustomerServiceStatus
    {
        public string EMPID { get; set; }
        public string EmpID { get; set; }
    }
    #endregion

    #region GetCompetitorListByCardCode
    public class CompetitorListDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<CompetitorData> CompetitorList { get; set; }
    }
    public class CompetitorData
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class ParamCompetitorData
    {
        public string EMPID { get; set; }
        public string CardCode { get; set; }
    }
    #endregion

    #region GetNatureOfComplaint
    public class NatureOfComplainListDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<NatureOfComplain> NatureOfComplainList { get; set; }
    }
    public class NatureOfComplain
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class ParamNatureOfComplainStatus
    {
        public string EMPID { get; set; }
        public string EmpID { get; set; }
    }
    #endregion

    #region GetDiagnosisList
    public class DiagnosisListDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<Diagnosis> DiagnosisList { get; set; }
    }
    public class Diagnosis
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class ParamDiagnosisStatus
    {
        public string EMPID { get; set; }
        public string EmpID { get; set; }
    }
    #endregion

    #region GetActionTakenList
    public class ActionTakenListDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<ActionTaken> ActionTakenList { get; set; }
    }
    public class ActionTaken
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class ParamActionTakenStatus
    {
        public string EMPID { get; set; }
        public string EmpID { get; set; }
    }
    #endregion

    #region GetCustomerItemList
    public class CustomerItemListDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<CustomerItemList> CustomerItemList { get; set; }
    }
    public class CustomerItemList
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string SerialNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ServiceType { get; set; }
        public string ProductType { get; set; }
        public string PrincipalCompany { get; set; }
    }
    public class ParamCustomerItemList
    {
        public string EMPID { get; set; }
        public string CardCode { get; set; }
    }
    #endregion

    #region LocationTypeList
    public class LocationTypeDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<LocationType> LocationTypeList { get; set; }
    }
    public class LocationType
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    #endregion

    #region GetDataListForInwardOutWard
    public class ItemDataListInwardOutWardDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<InwardOutWardData> DataList { get; set; }
    }
    public class InwardOutWardData
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class ParamInwardOutWard
    {
        public string EMPID { get; set; }
    }
    #endregion

    #region GetPriorityList
    public class PriorityListDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<PriorityList> PriorityList { get; set; }
    }
    public class PriorityList
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    public class ParamPriorityList
    {
        public string EMPID { get; set; }
        public string EmpID { get; set; }
    }
    #endregion

    #region GetTeamHierarchy
    public class TeamHierarchyDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<TeamHierarchy> TeamHierarchyList { get; set; }
    }
    public class TeamHierarchy
    {
        public string EmployeeCode { get; set; }
        public string EmpName { get; set; }
        public string ManagerCode { get; set; }
        public string ManagerName { get; set; }
        public string CardLevel { get; set; }
    }
    public class ParamTeamHierarchy
    {
        public string EMPID { get; set; }
        public string EmpCode { get; set; }
    }
    #endregion

    #region GetBranch

    public class ParamBranch
    {
        public string EMPID { get; set; }
        public string BranchCode { get; set; }
    }

    #endregion

    #region GetItem

    public class ParamItem
    {
        public string EMPID { get; set; }
        public string ItemCode { get; set; }
        public string SalesPerson { get; set; }
    }

    #endregion

    #region GetCustomer

    public class ParamCustomer
    {
        public string EMPID { get; set; }
        public string CardCode { get; set; }
    }

    #endregion

    #region GetEstimateGiven

    public class ParamEstimateGiven
    {
        public string EMPID { get; set; }
        public string InwardId { get; set; }
    }

    #endregion

    #region GetSalesPerson

    public class ParamSalesPerson
    {
        public string EMPID { get; set; }
        public string SalesPersonID { get; set; }
    }

    #endregion

    #region GetEmployeeTravelAmount

    public class ParamEmployeeTravelAmount
    {
        public string EMPID { get; set; }

        public string EXPENSEMODE { get; set; }
    }

    public class ParamNotification
    {
        public string EMPID { get; set; }
    }
    #endregion

    #region GetEmployeeTravelAmount

    public class ParamTemplate
    {
        public string EMPID { get; set; }
        public string TEMPLATECODE { get; set; }
    }

    #endregion

    #region GetCountOfMobileNoForContactPerson
    public class ParamMobile
    {
        public string EMPID { get; set; }
        public string MOBILENO { get; set; }
    }
    #endregion

    #region SFAVersion

    public class ParamSFAVersion
    {
        public string EMPID { get; set; }
        public string SFAVERSION { get; set; }
    }

    #endregion

    #region ClosingDuration

    public class ClosingDurationDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<ClosingDuration> ClosingDurationList { get; set; }

    }

    public class ParamClosingDuration
    {
        public string EMPID { get; set; }
        public string Date { get; set; }
    }

    public class ClosingDuration
    {
        public string Code { get; set; }
        public string Name { get; set; }

    }

    #endregion

    #region ParamLostCompititor
    public class ParamLostCompititor
    {
        public string EMPID { get; set; }
        public string OpportunityID { get; set; }
    }
    #endregion

    #region ParamSalesEmpID
    public class ParamSalesEmpID
    {
        public string EMPID { get; set; }
        public string SalesEmpID { get; set; }
    }
    #endregion

    #region ParamActivitySubject
    public class ParamActivitySubject
    {
        public string EMPID { get; set; }
        public string ACTIVITYSUBJECT { get; set; }
    }
    #endregion

    #region ParamSHOWRPT
    public class ParamShowRPT
    {
        public string EMPID { get; set; }
        public string docEntry { get; set; }
        public string flag { get; set; }
        public string objType { get; set; }
        public string RPTName { get; set; }
    }

    public class ShowRPTInfoDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }

    }
    #endregion

    #region ParamMessagesHistory
    public class ParamMessagesHistory
    {
        public string EMPID { get; set; }
        public string DocEntry { get; set; }
        public string ObjTyp { get; set; }
    }
    #endregion

    #region ParamPrincipalItem
    public class ParamPrincipalItem
    {
        public string EMPID { get; set; }
        public string ItemCode { get; set; }
    }
    #endregion

    #region ParamAttendance
    public class ParamAttendance
    {
        public string EMPID { get; set; }
    }
    #endregion

    #region ParamSAPB1UpdatePriceList
    public class ParamSAPB1UpdatePriceList
    {
        public string EMPID { get; set; }
        public string PriceListCode { get; set; }
        public string ItemCode { get; set; }
        public string Factor { get; set; }
    }

    public class SAPB1Item
    {
        public SAPB1Item()
        {
            ItemPrices = new List<ItemPrices>();
        }

        public string ItemCode { get; set; }

        public List<ItemPrices> ItemPrices { get; set; }
    }

    public class ItemPrices
    {
        public int? PriceList { get; set; }
        public double? Factor { get; set; }
        public double? Price { get; set; }
    }


    #endregion

    #region ParamGetCustomerByName

    public class ParamGetCustomerByName
    {
        public string EMPID { get; set; }
        public string CustomerName { get; set; }
    }

    #endregion

    #region ParamCustomerNameByCustomerCode

    public class ParamCustomerNameByCustomerCode
    {
        public string EMPID { get; set; }
        public string CustomerCode { get; set; }
    }

    #endregion

    #region ParamCustomerNameByCustomerCode

    public class ParamSerialNumberByItemCode
    {
        public string EMPID { get; set; }
        public string ItemCode { get; set; }
    }

    #region NatureOfBusiness
    public class NatureOfBusinessDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<NatureOfBusiness> NatureBusinessList { get; set; }

    }
    public class NatureOfBusiness
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
    #endregion
    #endregion

    #region  GetPriceFromPriceList
    public class ParamPriceFromPriceList 
    {
        public string EMPID { get; set; }
        public string ItemCode { get; set; }
        public string PriceList { get; set; }
    }
    public class ParamGetPriceFromPriceList 
    {
        public List<ItemPriceFromPriceList> ItemPriceFromPriceList { get; set; }
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
    }
    public class ItemPriceFromPriceList 
    {
        public string Price { get; set; }
    }

    #endregion

}

