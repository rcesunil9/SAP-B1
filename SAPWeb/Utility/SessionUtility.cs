using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SAPWeb.Utility
{
    public class SessionUtility
    {
        private string ObjectCode = Convert.ToString(ConfigurationManager.AppSettings["ObjectCode"]);

        private static string GetFromSession(string key)
        {
            string returnValue = "";
            if (HttpContext.Current.Session != null && HttpContext.Current.Session[key] != null)
                returnValue = System.Web.HttpContext.Current.Session[key].ToString().Trim();
            return returnValue;
        }
        public static string Name
        {
            get { return GetFromSession("Name"); }
            set { System.Web.HttpContext.Current.Session["Name"] = value; }
        }
        public static string Code
        {
            get { return GetFromSession("Code"); }
            set { System.Web.HttpContext.Current.Session["Code"] = value; }
        }
        public static string U_SlpCode
        {
            get { return GetFromSession("U_SlpCode"); }
            set { System.Web.HttpContext.Current.Session["U_SlpCode"] = value; }
        }
        public static string U_CashAc
        {
            get { return GetFromSession("U_CashAc"); }
            set { System.Web.HttpContext.Current.Session["U_CashAc"] = value; }
        }
        public static string U_WHS
        {
            get { return GetFromSession("U_WHS"); }
            set { System.Web.HttpContext.Current.Session["U_WHS"] = value; }
        }
        public static string U_SERIES
        {
            get { return GetFromSession("U_SERIES"); }
            set { System.Web.HttpContext.Current.Session["U_SERIES"] = value; }
        }
        public static string U_SERIESSQ
        {
            get { return GetFromSession("U_SERIESSQ"); }
            set { System.Web.HttpContext.Current.Session["U_SERIESSQ"] = value; }
        }
        public static string U_WhsCode
        {
            get { return GetFromSession("U_WhsCode"); }
            set { System.Web.HttpContext.Current.Session["U_WhsCode"] = value; }
        }
        public static string U_Cash
        {
            get { return GetFromSession("U_Cash"); }
            set { System.Web.HttpContext.Current.Session["U_Cash"] = value; }
        }
        public static string U_IN_Series
        {
            get { return GetFromSession("U_IN_Series"); }
            set { System.Web.HttpContext.Current.Session["U_IN_Series"] = value; }
        }
        public static string U_Sale
        {
            get { return GetFromSession("U_Sale"); }
            set { System.Web.HttpContext.Current.Session["U_Sale"] = value; }
        }
        public static string U_DiscRigths
        {
            get { return GetFromSession("U_DiscRigths"); }
            set { System.Web.HttpContext.Current.Session["U_DiscRigths"] = value; }
        }
        public static string U_AdminRights
        {
            get { return GetFromSession("U_AdminRights"); }
            set { System.Web.HttpContext.Current.Session["U_AdminRights"] = value; }
        }
    }
}