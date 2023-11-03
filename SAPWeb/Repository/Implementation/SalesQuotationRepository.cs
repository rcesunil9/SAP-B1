using Newtonsoft.Json;
using SAPWeb.App_Start;
using SAPWeb.Models;
using SAPWeb.Repository.Interface;
using SAPWeb.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace SAPWeb.Repository.Implementation
{
    public class SalesQuotationRepository : ISalesQuotationRepository
    {
        string CompanyName = Convert.ToString(ConfigurationManager.AppSettings["CompanyName"]);
        private string SAPErrMsg = "";
        private Boolean UPSERT;
        private Boolean UPSERTDRAFT;
        private Boolean ISDRAFT = false;
        private string ParamName = "";
        private string ParamVal = "";
        SQL_CONN_Class objCon = new SQL_CONN_Class();

        #region SAPSalesQuotation
        public SalesDocumentsDefault SAPSalesQuotation(SalesOrderQuotationDocument objModel)
        {
            ISDRAFT = false;

            SalesDocumentsDefault obj = new SalesDocumentsDefault();
            try
            {

                ServiceLayerSync ServiceLayerData = new ServiceLayerSync();
                Dictionary<int, string> Login = ServiceLayerData.SAPLogin();
                if (Login.FirstOrDefault().Key == 1)
                {
                    Documents oSalesQuotations = new Documents();
                    DocumentLines oSalesQuotationsLines = new DocumentLines();
                    string NextApprover = "";
                    string NextApproverLevel = "";
                    string NextApproverPositionID = "";
                    string MenuID = "6";
                    if (objModel.DocEntry > 0)
                    {
                        Documents GetByKey = ServiceLayerData.SAPGetSalesQuotations(objModel.DocEntry.Value);

                        if (GetByKey.DocEntry == objModel.DocEntry.Value)
                        {
                            UPSERT = true;
                            ISDRAFT = false;
                        }
                    }
                    //oSalesQuotations.U_OPPORTUNITYNO = objModel.OpportunityNo;
                    oSalesQuotations.SalesPersonCode = objModel.SalesEmployee;
                    //oSalesQuotations.U_PRICELISTCODE = objModel.PriceListCode;
                    oSalesQuotations.DocCurrency = objModel.DocCurrency;
                    oSalesQuotations.DocRate = objModel.U_ExchRate;
                   //oSalesQuotations.U_ORDERTYPE = objModel.OrderType;

                    oSalesQuotations.CardCode = objModel.CardCode;
                    //oSalesQuotations.U_CONTAINERTYPE = objModel.ContainerType;
                    // oSalesQuotations.U_BRANDINGTYPE = objModel.BrandingType;

                    oSalesQuotations.Series = objModel.Series;
                    oSalesQuotations.DocDate = objModel.PostingDate;
                    oSalesQuotations.TaxDate = objModel.DocDate;
                    oSalesQuotations.DocDueDate = objModel.DeliveryDate;
                    oSalesQuotations.U_USER = objModel.U_USER;
                    //oSalesQuotations.DocDueDate = objModel.DeliveryDate;
                    //oSalesQuotations.U_TRADEREGION = objModel.TradeRegion;

                    oSalesQuotations.ContactPersonCode = objModel.ContactPersonCode;
                    //oSalesQuotations.U_SUBJECT = objModel.Subject;
                    //oSalesQuotations.U_COVERINGBODY = objModel.CoveringBody;

                    oSalesQuotations.PayToCode = objModel.PayToCode;
                    oSalesQuotations.ShipToCode = objModel.ShipToCode;
                    oSalesQuotations.Comments = objModel.Comments;
                    oSalesQuotations.Rounding = objModel.Rounding;
                    oSalesQuotations.RoundingDiffAmount = objModel.RoundingDiffAmount;
                    oSalesQuotations.U_Territory = objModel.U_Territory;
                    //if (objModel.PaymentTerms != 0 && !String.IsNullOrEmpty(Convert.ToString(objModel.PaymentTerms)))
                    //{
                    //    oSalesQuotations.PaymentGroupCode = objModel.PaymentTerms;
                    //}

                    //oSalesQuotations.U_CBM = objModel.CBM;
                    //oSalesQuotations.U_TOTALGROSSWEIGHT = objModel.TotalGrossWeight;
                    //oSalesQuotations.U_TOTALNETWEIGHT = objModel.TotalNetWeight;

                    //oSalesQuotations.U_PRODUCTTYPE = objModel.ProductType;
                    //oSalesQuotations.U_PRINCIPALCOMPANY = objModel.PrincipleCompany;
                    //oSalesQuotations.U_MODEL = objModel.Model;

                    //oSalesQuotations.U_SYSTEMID = objModel.System;

                    if (UPSERT == false)
                        oSalesQuotations.U_CREATEDBY = objModel.CreatedBy;

                    oSalesQuotations.U_UPDATEDBY = objModel.CreatedBy;

                    oSalesQuotations.U_PORTALMODULE = "OQUT";
                    //oSalesQuotations.U_COMMERCIALREMARK = objModel.CommercialRemark;

                    if (String.IsNullOrEmpty(NextApprover))
                    {
                        oSalesQuotations.U_LASTAPPROVEDBY = objModel.CreatedBy;
                        oSalesQuotations.U_LASTAPPROVEDDATETIME = Convert.ToString(DateTime.Now);
                    }

                    if (ISDRAFT == false)
                    {
                        oSalesQuotations.U_DRAFTDOCENTRY = Convert.ToString(objModel.DraftDocEntry);
                    }

                    foreach (DataItems item in objModel.DocumentLines)
                    {
                        oSalesQuotationsLines = new DocumentLines();
                        double Quantity = item.ItemQuantity.Value;

                        if (Quantity != 0)
                        {
                            if (item.Linenum != -1)
                            {
                                oSalesQuotationsLines.LineNum = item.Linenum;
                            }

                            oSalesQuotationsLines.U_BRAND = item.ItemBrand;
                            oSalesQuotationsLines.ItemCode = item.ItemItemCode;
                            oSalesQuotationsLines.U_SIZE = item.ItemSize;
                            oSalesQuotationsLines.U_PKGCARTON = item.ItemPkgCarton;
                            oSalesQuotationsLines.U_NOOFCARTON = item.ItemNoofCarton;
                            oSalesQuotationsLines.Quantity = Quantity;
                            oSalesQuotationsLines.UnitPrice = item.ItemPrice;
                            oSalesQuotationsLines.DiscountPercent = item.DiscountPercent;
                            oSalesQuotationsLines.TaxCode = item.ItemTax;
                            oSalesQuotationsLines.WarehouseCode = item.WarehouseCode;
                            //oSalesQuotationsLines.LocationCode = _repo.GetLocationCode(objModel.WhsCode);
                            oSalesQuotationsLines.U_NETWEIGHT = item.ItemNetWeight;
                            oSalesQuotationsLines.U_GROSSWEIGHT = item.ItemGrossWeight;
                            oSalesQuotationsLines.U_UOM = item.ItemUOM;
                            oSalesQuotationsLines.SalesPersonCode = objModel.SalesEmployee;
                            oSalesQuotationsLines.U_CBM = item.ItemCBM;

                            if (!String.IsNullOrEmpty(Convert.ToString(objModel.DeliveryDate)))
                                oSalesQuotationsLines.ShipDate = Convert.ToDateTime(objModel.DeliveryDate);

                            oSalesQuotations.DocumentLines.Add(oSalesQuotationsLines);
                        }
                    }


                    Dictionary<int, string> SuccessData = new Dictionary<int, string>();

                    string data = JsonConvert.SerializeObject(oSalesQuotations,
                    new JsonSerializerSettings()
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });


                    if (UPSERT == true)
                    {
                        SuccessData = ServiceLayerData.SAPUpdateToSalesQuotations(data, objModel.DocEntry.Value);
                    }
                    else
                    {
                        SuccessData = ServiceLayerData.SAPAddToSalesQuotations(data);

                    }

                    if (SuccessData.FirstOrDefault().Key == 1)
                    {
                        int NEWDOCENTRY = 0;
                        int docNum = 0;
                        if (UPSERT == true)
                        {
                            NEWDOCENTRY = objModel.DocEntry.Value;
                            docNum = objModel.DocNum.Value;
                        }
                        else
                        {
                            Documents data1 = JsonConvert.DeserializeObject<Documents>(SuccessData.FirstOrDefault().Value);
                            NEWDOCENTRY = data1.DocEntry.Value;
                            docNum = data1.DocNum.Value;
                        }
                        //--------------------------------------------------------

                        //if (ISDRAFT == true)
                        //{
                        //    if (objModel.ApproverStatus == "REJECTED")
                        //    {
                        //        SAPErrMsg = "Sales Quotation Submitted Successfully. Documnet is Rejected. Document Number : " + Common.SAP_DOCUMENTNUMBER("ODRF", NEWDOCENTRY.ToString(), "DocEntry");
                        //    }
                        //    else
                        //    {
                        //        SAPErrMsg = "Sales Quotation Submitted Successfully send for the Approval. Document Number : " + Common.SAP_DOCUMENTNUMBER("ODRF", NEWDOCENTRY.ToString(), "DocEntry");
                        //    }
                        //}
                        //else
                        //{
                        //}
                        if (NEWDOCENTRY > 0)
                        {
                            if (UPSERT == false || objModel.DocEntry==null)
                            {
                                objModel.DocEntry = NEWDOCENTRY;
                                objModel.DocNum = docNum;
                                SAPSalesQuotaionUser(objModel);
                            }
                            SAPErrMsg = "Sales Quotation Submitted Successfully. Document Number : " + NEWDOCENTRY.ToString();//Common.SAP_DOCUMENTNUMBER("OQUT", NEWDOCENTRY.ToString(), "DocEntry");
                        }
                        obj.errorCode = "1";
                        obj.errorMsg = SAPErrMsg;
                        //return obj;
                        Common.TraceLogInfo("SAPWeb :" + SAPErrMsg);
                    }
                    else if (SuccessData.FirstOrDefault().Key == 2)
                    {
                        ErrorObject Data = JsonConvert.DeserializeObject<ErrorObject>(SuccessData.FirstOrDefault().Value.ToString());
                        SAPErrMsg = Data.error.code + " - " + Data.error.message.value;
                        obj.errorCode = "0";
                        obj.errorMsg = SAPErrMsg;
                        //return obj;
                        Common.TraceLogInfo("SAPWeb :" + SAPErrMsg);
                    }
                    else
                    {
                        SAPErrMsg = SuccessData.FirstOrDefault().Value.ToString();
                        obj.errorCode = "0";
                        obj.errorMsg = SAPErrMsg;
                        //return obj;
                        Common.TraceLogInfo("SAPWeb :" + SAPErrMsg);
                    }
                }
                else if (Login.FirstOrDefault().Key == 2)
                {
                    ErrorObject Data = JsonConvert.DeserializeObject<ErrorObject>(Login.FirstOrDefault().Value.ToString());
                    SAPErrMsg = Data.error.code + " - " + Data.error.message.value;
                    obj.errorCode = "0";
                    obj.errorMsg = SAPErrMsg;
                    //return obj;
                    Common.TraceLogInfo("SAPWeb :" + SAPErrMsg);
                }
                else
                {
                    SAPErrMsg = Login.FirstOrDefault().Value.ToString();
                    obj.errorCode = "0";
                    obj.errorMsg = SAPErrMsg;
                    //return obj;
                    Common.TraceLogInfo("SAPWeb :" + SAPErrMsg);
                }
            }
            catch (Exception ex)
            {
                obj.errorCode = "0";
                obj.errorMsg = ex.Message.ToString();
                Common.TraceLogInfo("SAPWeb :" + ex.Message.ToString());
            }
            return obj;
        }
        public QuotationListDefault SAPSalesQuotationList(int skip)
        {
            QuotationListDefault obj = new QuotationListDefault();
            ServiceLayerSync ServiceLayerData = new ServiceLayerSync();
            try
            {
                QuotationListDetail SuccessData = new QuotationListDetail();
                SuccessData = ServiceLayerData.SAPGetSalesQuotations("Quotations?$skip=" + skip + "&$orderby=DocEntry desc");
                if (SuccessData.Value != null && SuccessData.Value.Count > 0)
                {
                    obj.QuotationDetails = SuccessData;
                    obj.errorCode = "1";
                    obj.errorMsg = "Data Found";
                }
                else
                {
                    obj.errorCode = "0";
                    obj.errorMsg = "Data Not Found";
                }
            }
            catch (Exception ex)
            {
                obj.errorCode = "0";
                obj.errorMsg = ex.Message.ToString();
                Common.TraceLogInfo("SAPWeb :" + ex.Message.ToString());
            }
            return obj;
        }
        public SalesOrderQuotationDocument GetSalesQuotationById(int docEntry)
        {
            var model = new SalesOrderQuotationDocument();
            ServiceLayerSync ServiceLayerData = new ServiceLayerSync();
            Documents GetByKey = ServiceLayerData.SAPGetSalesQuotations(docEntry);
            model.DocumentLines = new List<DataItems>();
            model.DocEntry = docEntry;
            model.ContactPersonCode = GetByKey.ContactPersonCode;
            model.SalesEmployee = GetByKey.SalesPersonCode;
            model.NumAtCard = GetByKey.CardName;
            model.DocCurrency = GetByKey.DocCurrency;
            model.DocumentStatus = GetByKey.DocumentStatus;
            model.Cancelled = GetByKey.Cancelled;
            model.U_ExchRate = GetByKey.DocRate;
            model.CardCode = GetByKey.CardCode;
            model.Series = GetByKey.Series;
            //model.DocDate = GetByKey.DocDate.HasValue?GetByKey.DocDate.Value:DateTime.Today;
            model.DeliveryDate = GetByKey.DocDueDate.HasValue ? GetByKey.DocDueDate.Value : DateTime.Today;
            model.DocDate = GetByKey.TaxDate.HasValue ? GetByKey.TaxDate.Value : DateTime.Today;
            model.PayToCode = GetByKey.PayToCode;
            model.ShipToCode = GetByKey.ShipToCode;
            model.Comments = GetByKey.Comments;
            model.Rounding = GetByKey.Rounding;
            model.U_USER = GetByKey.U_USER;
            model.U_Territory = GetByKey.U_Territory;
            model.RoundingDiffAmount = GetByKey.RoundingDiffAmount;
            foreach (var item in GetByKey.DocumentLines)
            {
                model.DocumentLines.Add(new DataItems
                {
                    Linenum = item.LineNum,
                    ItemBrand = item.U_BRAND,
                    ItemItemCode = item.ItemCode,
                    ItemDescription = item.ItemDescription,
                    DiscountPercent = item.DiscountPercent,
                    ItemPkgCarton = item.U_PKGCARTON,
                    ItemNoofCarton = item.U_NOOFCARTON,
                    ItemQuantity = item.Quantity,
                    ItemPrice = item.UnitPrice,
                    ItemTax = item.TaxCode,
                    WarehouseCode = item.WarehouseCode
                });
            }

            return model;
        }
        #endregion
        #region User
        public SalesDocumentsDefault SAPSalesQuotaionUser(SalesOrderQuotationDocument objModel)
        {
            SalesDocumentsDefault obj = new SalesDocumentsDefault();
            try
            {
                objCon = new SQL_CONN_Class();

                string ParamName = "";
                string ParamVal = "";
                ParamName = "@QuotaionID|@DocEntry|@DocNum|@DocStatus|@DocDate|@DocDueDate|@TaxDate|@CardCode|@CardName" +
                    "|@DocCur" +
                    "|@SlpCode|@CntctCode|@Series|@UserSign|@PayToCode|@ShipToCode|@Comments|@U_Territory|@RoundDif|@Rounding|@RETURNID";
                ParamVal = objModel.QuotaionID + "|" + objModel.DocEntry + "|" + objModel.DocNum
                    + "|" + objModel.DocumentStatus + "|" + Convert.ToDateTime(objModel.PostingDate).ToString("yyyy-MM-dd") + "|" + Convert.ToDateTime(objModel.DeliveryDate).ToString("yyyy-MM-dd") + "|" + Convert.ToDateTime(objModel.DocDate).ToString("yyyy-MM-dd")
                    + "|" + objModel.CardCode + "|" + objModel.CardName 
                    + "|" + objModel.DocCurrency + "|" + objModel.SalesEmployee + "|" + objModel.ContactPersonCode + "|" + objModel.Series
                    + "|" + SessionUtility.Code + "|" + objModel.PayToCode + "|" + objModel.ShipToCode + "|" + objModel.Comments
                    +"|"+ objModel.U_Territory +"|"+objModel.RoundingDiffAmount +"|"+objModel.Rounding
                    +"|"+objModel.RETURNID;

                var dtItemDetails = objCon.ByProcedureExecScalar_Return("SAP_U_OQUTInsertUpdate", 21, ParamName, ParamVal);
                if(dtItemDetails>0)
                {
                    SAPErrMsg = "Sales Quotation Submitted Successfully. Document Number : " + dtItemDetails.ToString();//Common.SAP_DOCUMENTNUMBER("OQUT", NEWDOCENTRY.ToString(), "DocEntry");
                    foreach (var item in objModel.DocumentLines)
                    {
                        ParamName = "@QuotaionDetailsID|@QuotaionID|@ItemCode|@Dscription|@Quantity|@DiscPrcnt|@WhsCode|@TaxCode|@UnitPrice|@RETURNID";
                        ParamVal = item.QuotaionDetailsID + "|" + dtItemDetails+"|"+ item.ItemItemCode
                            + "|" + item.ItemDescription + "|" + item.ItemQuantity + "|" + item.DiscountPercent + "|" + item.WarehouseCode + "|" + item.ItemTax +"|"+item.ItemPrice + "|" + objModel.RETURNID;
                        objCon.ByProcedureExecScalar_Return("SAP_U_QUT1InsertUpdate", 10, ParamName, ParamVal);
                    }
                   
                }
                obj.errorCode = "1";
                obj.errorMsg = SAPErrMsg;
            }
            catch (Exception ex)
            {
                obj.errorCode = "0";
                obj.errorMsg = ex.Message.ToString();
                Common.TraceLogInfo("SAPWeb :" + ex.Message.ToString());
            }
            return obj;
        }
        public QuotationListDefault SAPSalesQuotationListUser(string userID,int skip)
        {
            QuotationListDefault obj = new QuotationListDefault();
            try
            {
                string query = @"SELECT   (CASE WHEN DocEntry = 0 OR DocEntry is null THEN QuotaionID ELSE DocEntry end) as DocEntry,
 DocNum,
CONVERT(varchar, CAST(DocDate AS datetime), 23) as DocDate,
CardCode as CardCode,
CardName as CardName,
DocStatus as DocumentStatus,U.Name as U_USER 
FROM U_OQUT INNER JOIN [@USER] U ON U.Code = U_OQUT.UserSign WHERE UserSign='" + userID+"'";
                if(SessionUtility.U_AdminRights=="Y")
                {
                    query = @"SELECT 
(CASE WHEN DocEntry = 0 OR DocEntry is null THEN QuotaionID ELSE DocEntry end) as DocEntry,
 DocNum,
CONVERT(varchar, CAST(DocDate AS datetime), 23) as DocDate,
CardCode as CardCode,
CardName as CardName,
DocStatus as DocumentStatus,U.Name as U_USER FROM U_OQUT INNER JOIN [@USER] U ON U.Code = U_OQUT.UserSign WHERE DocStatus='O'";
                }
                var Data = objCon.ByQueryReturnDataTable(query);
                if (Data != null && Data.Rows.Count > 0)
                {
                    obj.QuotationDetails.Value = Data.ConvertToList<SalesQuotationDetails>();
                    obj.errorCode = "1";
                    obj.errorMsg = "";
                }
                else
                {
                    obj.errorCode = "0";
                    obj.errorMsg = "Data Not Found.";
                }
            }
            catch (Exception ex)
            {
                obj.errorCode = "0";
                obj.errorMsg = ex.Message.ToString();
                Common.TraceLogInfo("SAPWeb :" + ex.Message.ToString());
            }
            return obj;
        }
        public SalesOrderQuotationDocument GetSalesQuotationUserById(int docEntry)
        {
            var model = new SalesOrderQuotationDocument();
            try
            {
                string queryHeader = @"select 
                QuotaionID,
                DocEntry as DocEntry,
                CardCode as CardCode,
                CardName as CardName,
                SlpCode as SalesEmployee,
                CntctCode as ContactPersonCode,
                U_Territory,
                DocCur as DocCurrency,
                PayToCode,
                ShipToCode,
                Series as Series,
                Comments as  Comments,
                Rounding as  Rounding,
                DocDate as PostingDate,
                DocDueDate as DeliveryDate,
                RoundDif as RoundingDiffAmount,
                DocStatus as DocumentStatus,
                DocDueDate as DeliveryDate,
				TaxDate as DocDate,
U_Territory as U_Territory,
U.Name as U_USER
                from U_OQUT INNER JOIN [@USER] U ON U.Code = U_OQUT.UserSign WHERE QuotaionID = " + docEntry;
                var Data = objCon.ByQueryReturnDataTable(queryHeader);
                if (Data != null && Data.Rows.Count > 0)
                {
                    model.DocumentLines = new List<DataItems>();
                    model.DocEntry = Convert.ToInt32(Data.Rows[0]["DocEntry"]);
                    model.QuotaionID = Convert.ToInt32(Data.Rows[0]["QuotaionID"]);
                    model.SalesEmployee = Convert.ToInt32(Data.Rows[0]["SalesEmployee"]);
                    model.ContactPersonCode = Convert.ToInt32(!string.IsNullOrEmpty(Data.Rows[0]["ContactPersonCode"].ToString()) ? Data.Rows[0]["ContactPersonCode"].ToString() : "0");
                    model.NumAtCard = Data.Rows[0]["CardName"].ToString();
                    model.DocCurrency = Data.Rows[0]["DocCurrency"].ToString();
                    model.DocumentStatus = Data.Rows[0]["DocumentStatus"].ToString();
                    model.CardCode = Data.Rows[0]["CardCode"].ToString();
                    model.Series = Convert.ToInt32(Data.Rows[0]["Series"].ToString());
                    model.DeliveryDate = Convert.ToDateTime(Data.Rows[0]["DeliveryDate"].ToString());
                    model.DocDate = Convert.ToDateTime(Data.Rows[0]["DocDate"].ToString());
                    model.PayToCode = Data.Rows[0]["PayToCode"].ToString();
                    model.ShipToCode = Data.Rows[0]["ShipToCode"].ToString();
                    model.Comments = Data.Rows[0]["Comments"].ToString();
                    model.U_Territory = Data.Rows[0]["U_Territory"].ToString();
                    model.Rounding = Data.Rows[0]["Rounding"].ToString();
                    model.U_USER = Data.Rows[0]["U_USER"].ToString();
                    model.RoundingDiffAmount = Convert.ToDouble(Data.Rows[0]["RoundingDiffAmount"].ToString());
                    var queryList = @"SELECT * FROM U_QUT1 WHERE QuotaionID = " + docEntry;
                    var listItem = objCon.ByQueryReturnDataTable(queryList);
                    if (listItem != null && listItem.Rows.Count>0)
                    {
                        foreach (DataRow item in listItem.Rows)
                        {
                            model.DocumentLines.Add(new DataItems
                            {
                                QuotaionDetailsID = Convert.ToInt32(item["QuotaionDetailsID"]),
                                ItemDescription = item["Dscription"].ToString(),
                                ItemItemCode = item["ItemCode"].ToString(),
                                ItemQuantity = Convert.ToDouble(item["Quantity"].ToString()),
                                ItemPrice = Convert.ToDouble(item["UnitPrice"].ToString()),
                                DiscountPercent = Convert.ToDouble(!string.IsNullOrEmpty(item["DiscPrcnt"].ToString())? item["DiscPrcnt"].ToString() : "0"),
                                WarehouseCode = item["WhsCode"].ToString(),
                                ItemTax = item["TaxCode"].ToString(),
                            });
                        }
                    }
                }

           }
            catch (Exception ex)
            {

                
            }
            return model;
        }
        #endregion
    }
}