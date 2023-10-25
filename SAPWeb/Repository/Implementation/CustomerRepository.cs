using SAPWeb.App_Start;
using SAPWeb.Models;
using SAPWeb.Repository.Interface;
using SAPWeb.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPWeb.Repository.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        string SAPErrMsg = "";
        #region UserProperty
        SQL_CONN_Class objCon = new SQL_CONN_Class();

        public AddressDetailDefault GetBillToId(string code)
        {
            AddressDetailDefault objAddressDetail = new AddressDetailDefault();
            objAddressDetail.AddressDetail = new List<AddressDetail>();
            try
            {
                string ParamVal = code.Trim();
                var Data = objCon.ByQueryReturnDataTable(@"SELECT [Address],[Street], [Block],[City],[ZipCode], [State], [Country]  FROM CRD1 Where AdresType = 'B' and CardCode = '"+code+"'");
                if (Data != null && Data.Rows.Count > 0)
                {
                    objAddressDetail.AddressDetail = Data.ConvertToList<AddressDetail>();
                    objAddressDetail.errorCode = "1";
                    objAddressDetail.errorMsg = "";
                }
                else
                {
                    objAddressDetail.errorCode = "0";
                    objAddressDetail.errorMsg = "Data Not Found.";
                }
            }
            catch (Exception ex)
            {
                objAddressDetail.errorCode = "0";
                objAddressDetail.errorMsg = ex.Message;
                return objAddressDetail;
            }
            return objAddressDetail;
        }

        public ContactPersonDefault GetContactPerson(string code)
        {
            ContactPersonDefault objContactPerson = new ContactPersonDefault();
            objContactPerson.ContactPerson = new List<ContactPerson>();
            try
            {
                string ParamVal = code.Trim();
                var Data = objCon.ByQueryReturnDataTable(@"SELECT CntctCode as CODE,Name as [NAME] from OCPR WHERE CardCode='" + code + "'");
                if (Data != null && Data.Rows.Count > 0)
                {
                    objContactPerson.ContactPerson = Data.ConvertToList<ContactPerson>();
                    objContactPerson.errorCode = "1";
                    objContactPerson.errorMsg = "";
                }
                else
                {
                    objContactPerson.errorCode = "0";
                    objContactPerson.errorMsg = "Data Not Found.";
                }
            }
            catch (Exception ex)
            {
                objContactPerson.errorCode = "0";
                objContactPerson.errorMsg = ex.Message;
                return objContactPerson;
            }
            return objContactPerson;
        }
        #endregion
        public CustomerDefault GetCustomer(string q)
        {
            CustomerDefault ObjUser = new CustomerDefault();
            ObjUser.Customer = new List<Customer>();
            try
            {
                string ParamVal = q.Trim();
                var Data = objCon.ByQueryReturnDataTable(@"SELECT CardCode,CardName,t0.Currency,SlpCode,U_Territory,t1.Rate AS Rate FROM OCRD t0 LEFT JOIN ORTT t1 ON t1.Currency=t0.Currency and t1.Currency='USD' and CONVERT(DATE, t1.RateDate) >= CONVERT(DATE, GETDATE()) WHERE CardCode LIKE '%" + q+ "%' OR CardName LIKE '%" + q+"%'");
                if(Data!=null && Data.Rows.Count>0)
                {
                    ObjUser.Customer = Data.ConvertToList<Customer>();
                    ObjUser.errorCode = "1";
                    ObjUser.errorMsg = "";
                }
                else
                {
                    ObjUser.errorCode = "0";
                    ObjUser.errorMsg = "Data Not Found.";
                }
            }
            catch (Exception ex)
            {
                ObjUser.errorCode = "0";
                ObjUser.errorMsg = ex.Message;
                return ObjUser;
            }
            return ObjUser;
        }

        public AddressDetailDefault GetShipToId(string code)
        {
            AddressDetailDefault objAddressDetail = new AddressDetailDefault();
            objAddressDetail.AddressDetail = new List<AddressDetail>();
            try
            {
                string ParamVal = code.Trim();
                var Data = objCon.ByQueryReturnDataTable(@"SELECT [Address],[Street], [Block],[City],[ZipCode], [State], [Country]  FROM CRD1 Where AdresType = 'S' and CardCode = '" + code + "'");
                if (Data != null && Data.Rows.Count > 0)
                {
                    objAddressDetail.AddressDetail = Data.ConvertToList<AddressDetail>();
                    objAddressDetail.errorCode = "1";
                    objAddressDetail.errorMsg = "";
                }
                else
                {
                    objAddressDetail.errorCode = "0";
                    objAddressDetail.errorMsg = "Data Not Found.";
                }
            }
            catch (Exception ex)
            {
                objAddressDetail.errorCode = "0";
                objAddressDetail.errorMsg = ex.Message;
                return objAddressDetail;
            }
            return objAddressDetail;
        }

        public CommonSalesQuotation GetSalesQuotation(string code)
        {
            CommonSalesQuotation objItemDefault = new CommonSalesQuotation();
            objItemDefault.SalesEmployee = new List<SalesEmployee>();
            objItemDefault.ContactPerson = new List<ContactPerson>();
            objItemDefault.ShipToAddressDetail = new List<AddressDetail>();
            objItemDefault.BillToAddressDetail = new List<AddressDetail>();
            objItemDefault.SeriesQuotation = new List<SeriesQuotation>();
            try
            {
                string ParamName = "@CODE|@seriessq|@LogiID";
                string ParamVal = code.Trim() + "|" + SessionUtility.U_SERIES+"|"+SessionUtility.Code;
                var dtItemDetails = objCon.ByProcedureReturnDataSet("SAP_SalesQuotationHeaderList", 2, ParamName, ParamVal);
                if(dtItemDetails!=null && dtItemDetails.Tables.Count > 0)
                {
                    objItemDefault.ContactPerson = dtItemDetails.Tables[0]?.ConvertToList<ContactPerson>();
                    objItemDefault.SalesEmployee = dtItemDetails.Tables[1]?.ConvertToList<SalesEmployee>();
                    objItemDefault.ShipToAddressDetail = dtItemDetails.Tables[2]?.ConvertToList<AddressDetail>();
                    objItemDefault.BillToAddressDetail = dtItemDetails.Tables[3]?.ConvertToList<AddressDetail>();
                    objItemDefault.SeriesQuotation = dtItemDetails.Tables[4]?.ConvertToList<SeriesQuotation>();
                    objItemDefault.errorCode = "1";
                    objItemDefault.errorMsg = "";
                }
                else
                {
                    objItemDefault.errorCode = "0";
                    objItemDefault.errorMsg = "Data Not Found.";
                }
            }
            catch (Exception ex)
            {
                objItemDefault.errorCode = "0";
                objItemDefault.errorMsg = ex.Message;
                return objItemDefault;
            }
            return objItemDefault;
        }

        public CommonSalesQuotation GetARInvoice(string code)
        {
            CommonSalesQuotation objItemDefault = new CommonSalesQuotation();
            objItemDefault.SalesEmployee = new List<SalesEmployee>();
            objItemDefault.ContactPerson = new List<ContactPerson>();
            objItemDefault.ShipToAddressDetail = new List<AddressDetail>();
            objItemDefault.BillToAddressDetail = new List<AddressDetail>();
            objItemDefault.SeriesQuotation = new List<SeriesQuotation>();
            try
            {
                string ParamName = "@CODE|@seriessq|@LogiID";
                string ParamVal = code.Trim() + "|" + SessionUtility.U_IN_Series + "|" + SessionUtility.Code;
                var dtItemDetails = objCon.ByProcedureReturnDataSet("SAP_ARInoviceHeaderList", 2, ParamName, ParamVal);
                if (dtItemDetails != null && dtItemDetails.Tables.Count > 0)
                {
                    objItemDefault.ContactPerson = dtItemDetails.Tables[0]?.ConvertToList<ContactPerson>();
                    objItemDefault.SalesEmployee = dtItemDetails.Tables[1]?.ConvertToList<SalesEmployee>();
                    objItemDefault.ShipToAddressDetail = dtItemDetails.Tables[2]?.ConvertToList<AddressDetail>();
                    objItemDefault.BillToAddressDetail = dtItemDetails.Tables[3]?.ConvertToList<AddressDetail>();
                    objItemDefault.SeriesQuotation = dtItemDetails.Tables[4]?.ConvertToList<SeriesQuotation>();
                    objItemDefault.errorCode = "1";
                    objItemDefault.errorMsg = "";
                }
                else
                {
                    objItemDefault.errorCode = "0";
                    objItemDefault.errorMsg = "Data Not Found.";
                }
            }
            catch (Exception ex)
            {
                objItemDefault.errorCode = "0";
                objItemDefault.errorMsg = ex.Message;
                return objItemDefault;
            }
            return objItemDefault;
        }
    }
}