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
                var Data = objCon.ByQueryReturnDataTable(@"SELECT CardCode,CardName,Currency,SlpCode FROM OCRD WHERE CardCode LIKE '%" + q+"%'");
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
    }
}