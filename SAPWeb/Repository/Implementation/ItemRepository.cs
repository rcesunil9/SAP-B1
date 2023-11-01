using SAPWeb.App_Start;
using SAPWeb.Models;
using SAPWeb.Repository.Interface;
using SAPWeb.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SAPWeb.Repository.Implementation
{
    public class ItemRepository : IItemRepository
    {
        string SAPErrMsg = "";
        #region UserProperty
        SQL_CONN_Class objCon = new SQL_CONN_Class();
        #endregion
        public ItemDefault GetItem(string code,string whsCode)
        {
            ItemDefault objItemDefault = new ItemDefault();
            objItemDefault.Items = new List<Item>();    
            try
            {
                string ParamName = "@CODE|@WhsCode";
                string ParamVal = code.Trim()+"|"+whsCode;
                var dtItemDetails = objCon.ByProcedureReturnDataTable("SAP_ItemMasterList", 2, ParamName, ParamVal);
                if (dtItemDetails != null && dtItemDetails.Rows.Count > 0)
                {
                    objItemDefault.Items = dtItemDetails.ConvertToList<Item>();
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
        public TaxCodeDefault GetTaxCode()
        {
            TaxCodeDefault ObjUser = new TaxCodeDefault();
            ObjUser.GetTaxCode = new List<TaxCode>();
            try
            {
                var Data = objCon.ByQueryReturnDataTable(@"select Code,Name,Rate as Value from OVTG where Code in ('O1','O2','O3','X0','E5')");
                if (Data != null && Data.Rows.Count > 0)
                {
                    ObjUser.GetTaxCode = Data.ConvertToList<TaxCode>();
                    ObjUser.errorCode = "1";
                    ObjUser.errorMsg = "";
                }
                else
                {
                    ObjUser.errorCode = "0";
                    ObjUser.errorMsg = "Wrong Username/Password.";
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
        public WareHouseDefault GetWarHouse()
        {
            WareHouseDefault ObjUser = new WareHouseDefault();
            ObjUser.GetWareHouse = new List<WareHouse>();
            try
            {
                var Data = objCon.ByQueryReturnDataTable(@"select WHSCode as Code,WHSName as Name from OWHS");
                if (Data != null && Data.Rows.Count > 0)
                {
                    ObjUser.GetWareHouse = Data.ConvertToList<WareHouse>();
                    ObjUser.errorCode = "1";
                    ObjUser.errorMsg = "";
                }
                else
                {
                    ObjUser.errorCode = "0";
                    ObjUser.errorMsg = "";
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

    }
}