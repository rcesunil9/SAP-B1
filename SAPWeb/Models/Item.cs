using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace SAPWeb.Models
{
    public class ItemDefaultTab
    {
        public string errorCode { get; set; }
        public string errorMsg { get; set; }
        public DataTable tab { get; set; }
    }

    public class ParamItemICF
    {
        public string SchemaName { get; set; }
    }

    #region ItemMaster

    public class ItemMaster
    {
        public string SchemaName { get; set; } // SchemaName
        public string Code { get; set; } // Item Code Temp Code
        public string ItemCode { get; set; } // Item Code
        public string ItemName { get; set; } // Item Name
        public string ForeignName { get; set; }  // Item Name
        public string SupplierCatalogNo { get; set; }  // Vendor Part No. 
        public int? ChapterID { get; set; } // HSN Code
        public string U_Rate { get; set; } // GST%
        public int? Manufacturer { get; set; } // Principal
        public string U_ITMMGRP { get; set; } // Item Main Group
        public int? ItemsGroupCode { get; set; } //  Item Group
        public string U_ProdGroup { get; set; } // Product Group
        public string U_ProdSubGrp { get; set; } // Product Sub Group
        public string U_MODEL { get; set; } // Model
        public string U_PT { get; set; } // Label Type  U_LABELTYPE-----
        public string U_LSJW { get; set; } // Label Size / Job Width
        public string U_LSJH { get; set; } // Label Size / Job Height
        public string U_CoreID { get; set; } // Core ID
        public string U_Across { get; set; } // Across
        public string U_ADDREMARKS { get; set; } // Adiitional Remarks -----
        public string U_ITMPURFROM { get; set; } // Item Purchase From -----
        public string InventoryItem { get; set; } // Inventory Item
        public string SalesItem { get; set; } // Sales Item
        public string PurchaseItem { get; set; } // Purchase Item
        public string ManageSerialNumbers { get; set; } // Serial Number
        public string ManageBatchNumbers { get; set; } // Batch Number
        public string WarrantyTemplate { get; set; } // Warranty Template
        public string Excisable { get; set; } // Excisable
        public string GSTRelevnt { get; set; } // GSTRelevnt
        public string MaterialType { get; set; } // Material Type
        public string GSTTaxCategory { get; set; } // Tax Category
        public string CustomsGroupCode { get; set; } //  Customs GroupCode
        public string GLMethod { get; set; } // G/L Method
        public string CostAccountingMethod { get; set; } // Valuation Method
        public string ManageStockByWarehouse { get; set; } // Manage Stock By Warehouse
        public string DefaultWarehouse { get; set; } // Default Warehouse
        public string PlanningSystem { get; set; } // Planning Method
        public string ProcurementMethod { get; set; } // Procurement Method
        public double? MinOrderQuantity { get; set; } // Min Order Quantity
        public double? OrderMultiple { get; set; } // Order Multiple
        public string IssueMethod { get; set; } // Issue Method -- im_Manual
        public double? U_SWSRT { get; set; } // SWS Rate
        public double? U_STDIS { get; set; } // Standard Discount
        public string U_PriceLCode { get; set; } // PriceList Code

        public string U_colour { get; set; } // Per Roll Quantity
        public string U_Pattern { get; set; } // Pattern
        public string U_CUT { get; set; } // Overhead Cost
        public string U_JS { get; set; } // Jump Size
        public string U_DA { get; set; } // Die Across
        public string U_DH { get; set; } // Die Height
        public string U_DU { get; set; } // Die UPS
        public string U_PS { get; set; } // Paper Size
        public string U_Die { get; set; } // Yield/Hour
        public string U_PG { get; set; } // Paper Part #
        public string U_PR { get; set; } // RM Basic Rate

        public string U_Status { get; set; } // Status 
        public string U_CREATEDBY { get; set; } // Created By 
        public string U_UPDATEDBY { get; set; } // Updated By 
        public string U_APPROVEDID { get; set; } // Approver By
        public string U_APPROVEDLEVEL { get; set; } // Approver Level
        public string U_APPROVEDPOSITIONID { get; set; } // Approver Position
    }

    #endregion

    #region A_OITM

    public class A_OITM
    {
        public string Code { get; set; } // Item Name
        public string U_ItemCode { get; set; } // Item Name
        public string U_ItemName { get; set; } // Item Name
        public string U_SupplierCatalogNo { get; set; }  // Vendor Part No. 
        public int? U_ChapterID { get; set; } // HSN Code
        public string U_Rate { get; set; } // GST%
        public string U_LABELTYPE { get; set; } // Label Type 
        public string U_LSJW { get; set; } // Label Size / Job Width
        public string U_LSJH { get; set; } // Label Size / Job Height
        public string U_CoreID { get; set; } // Core ID
        public string U_Across { get; set; } // Across
        public string U_ADDREMARKS { get; set; } // Adiitional Remarks  
        public string U_ITMPURFROM { get; set; } // Item Purchase From  
        public string U_WarrantyTemplate { get; set; } // Warranty Template

        public string U_colour { get; set; } // Per Roll Quantity

        public string U_Status { get; set; } // Status 
        public string U_CREATEDBY { get; set; } // Created By 
        public string U_UPDATEDBY { get; set; } // Updated By 
        public string U_APPROVEDID { get; set; } // Approver By
        public string U_APPROVEDLEVEL { get; set; } // Approver Level
        public string U_APPROVEDPOSITIONID { get; set; } // Approver Position

    }

    #endregion

    #region ParamICFList

    public class ParamICFList
    {
        public string SchemaName { get; set; }
        public string EMPID { get; set; }
        public string ITEMCODE { get; set; }
    }

    #endregion

    #region ParamICFApprovalList

    public class ParamICFApprovalList
    {
        public string SchemaName { get; set; }
        public string EMPID { get; set; }
    }

    #endregion

    #region ParamICFDetailsByItemCode

    public class ParamICFDetailsByItemCode
    {
        public string SchemaName { get; set; }
        public string ITEMCODE { get; set; }
        public string CODE { get; set; }
    }

    #endregion

}