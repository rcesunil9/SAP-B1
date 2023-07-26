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
        public ItemDefault GetItem(string code)
        {
            ItemDefault objItemDefault = new ItemDefault();
            objItemDefault.Items = new List<Item>();    
            try
            {
                string ParamName = "@CODE";
                string ParamVal = code.Trim();
                var dtItemDetails = objCon.ByProcedureReturnDataTable("SAP_ItemMasterList", 1, ParamName, ParamVal);
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
                var Data = objCon.ByQueryReturnDataTable(@"select Code,Name from OVTG where Code in ('O1','O2','O3','X0','E5')");
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

    }
}