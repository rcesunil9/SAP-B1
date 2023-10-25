using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPWeb.Models
{
    public class UserDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<User> User { get; set; }

    }


    public class User
    {
        public string EmpID { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ParentID { get; set; }
        public string Position { get; set; }
        public string UserRole { get; set; }
        public string SlpID { get; set; }
        public string PositionID { get; set; }
        public string ManagerName { get; set; }
        public string SapSourceAttachPath { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string StateCode { get; set; }
        public string CountryCode { get; set; }
        public string AttachmentPath { get; set; }
        public string DATEINCREMENTDAYS { get; set; }
        public string ISAPPROVER { get; set; }
        public string MINBGCHARGES { get; set; }
        public string BGCHARGES { get; set; }
        public string PMCPER { get; set; }
        //added by ashwin on 2023-07-25
        public string Code { get; set; }
        public string U_Pass { get; set; }
        public string U_CashAc { get; set; }
        public string U_WHS { get; set; }
        public string U_SERIES { get; set; }
        public string U_SERIESSQ { get; set; }
        public string U_WhsCode { get; set; }
        public string U_Cash { get; set; }
        public string U_IN_Series { get; set; }
        public string U_Sale { get; set; }
        public string U_DiscRigths { get; set; }
        public string U_AdminRights { get; set; }


    }


    public class UserLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ModelNo { get; set; }
        public string AndroidVersion { get; set; }
        public string OSName { get; set; }
        public string KernelVersion { get; set; }
        public string BuildNo { get; set; }
        public string SDK { get; set; }
        public string IMEINo { get; set; }
        public string DeviceID { get; set; }
        public string TokenID { get; set; }
        public string EmailID { get; set; }
        public string MACAddress { get; set; }
        public string SlpCode { get; set; }
        public string SchemaName { get; set; }
    }
    public class ErrorClassForSchema
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<SchemaList> SchemaList { get; set; }
    }
    public class SchemaList
    {
        public string SchemaID { get; set; }
        public string SchemaCode { get; set; }
        public string SchemaName { get; set; }
    }

    public class AuthorizationDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public List<MenuAuthorize> Menus { get; set; }

    }

    public class MenuAuthorize
    {
        public string ModuleID { get; set; }
        public string ModuleName { get; set; }
        public string ModuleClassIcon { get; set; }
        public string MenuID { get; set; }
        public string MenuName { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string Parameters { get; set; }
        public string ViewType { get; set; }
        public string ParentMenuID { get; set; }

    }
    public class ParamMenu
    {
        public string SystemID { get; set; }
        public string EmpID { get; set; }
        public string PositionID { get; set; }
    }

    public class ForgotDefault
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }

    }



}