using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using Newtonsoft.Json;
using SAPWeb.App_Start;
using SAPWeb.Models;
using SAPWeb.Repository.Interface;
using SAPWeb.Utility;

namespace SAPWeb.Repository.Implementation
{
    public class ARInvoiceRepository : IARInvoiceRepository
    {
        string CompanyName = Convert.ToString(ConfigurationManager.AppSettings["CompanyName"]);
        SQL_CONN_Class objCon = new SQL_CONN_Class();
        private string SAPErrMsg = "";
        private Boolean UPSERT;
        private Boolean UPSERTDRAFT;
        private Boolean ISDRAFT = false;
        private string ParamName = "";
        private string ParamVal = "";
        public SalesOrderQuotationDocument GetARInvoiceById(int docEntry)
        {
            var model = new SalesOrderQuotationDocument();
            ServiceLayerSync ServiceLayerData = new ServiceLayerSync();
            Documents GetByKey = ServiceLayerData.SAPGetSalesInvoices(docEntry);
            model.DocumentLines = new List<DataItems>();
            model.DocEntry = docEntry;
            model.ContactPersonCode = GetByKey.ContactPersonCode;
            model.SalesEmployee = GetByKey.SalesPersonCode;
            model.NumAtCard = GetByKey.CardName;
            model.DocCurrency = GetByKey.DocCurrency;
            model.U_ExchRate = GetByKey.DocRate;
            model.CardCode = GetByKey.CardCode;
            model.DocumentType = "AR";
            model.DocumentStatus = GetByKey.DocumentStatus;
            model.Cancelled = GetByKey.Cancelled;
            model.U_VerCode = GetByKey.U_VerCode;
            model.U_FiscalDoc = GetByKey.U_FiscalDoc;
            model.U_URAPosted = GetByKey.U_URAPosted;
            model.Series = GetByKey.Series;
            model.PostingDate = GetByKey.DocDate.HasValue ? GetByKey.DocDate.Value : DateTime.Today;
            model.DeliveryDate = GetByKey.DocDueDate.HasValue ? GetByKey.DocDueDate.Value : DateTime.Today;
            model.DocDate = GetByKey.TaxDate.HasValue ? GetByKey.TaxDate.Value : DateTime.Today;
            model.PayToCode = GetByKey.PayToCode;
            model.ShipToCode = GetByKey.ShipToCode;
            model.U_Territory = GetByKey.U_Territory;
            model.U_USER = GetByKey.U_USER;
            model.RequestType = Convert.ToInt32(GetByKey.U_PT??"0");
            model.ARStatus = GetByKey.U_Avalibility;

            model.Comments = GetByKey.Comments;
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
        public QuotationListDefault SAPARInvoiceList(int skip)
        {
            QuotationListDefault obj = new QuotationListDefault();
            ServiceLayerSync ServiceLayerData = new ServiceLayerSync();
            try
            {
                QuotationListDetail SuccessData = new QuotationListDetail();
                SuccessData = ServiceLayerData.SAPGetSalesInvoicesList("Invoices?$skip="+skip + "&$orderby=DocEntry desc");
                if (SuccessData.Value != null && SuccessData.Value.Count > 0)
                {
                    SuccessData.Value.ForEach(x => x.DocDate = CommonAttributes.GetDate(x.DocDate).ToString("dd/MM/yyyy"));
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
        public SalesDocumentsDefault SAPARInvoiceInsertUpdate(SalesOrderQuotationDocument objModel)
        {
            SalesDocumentsDefault obj = new SalesDocumentsDefault();

            try
            {
                ServiceLayerSync ServiceLayerData = new ServiceLayerSync();
                Dictionary<int, string> Login = ServiceLayerData.SAPLogin();
                if (Login.FirstOrDefault().Key == 1)
                {
                    Documents oSalesInvoices = new Documents();
                    DocumentLines oSalesInvoicesLines = new DocumentLines();

                    if (objModel.DocEntry > 0)
                    {
                        Documents GetByKey = ServiceLayerData.SAPGetSalesInvoices(objModel.DocEntry.Value);

                        if (GetByKey.DocEntry == objModel.DocEntry.Value)
                        {
                            UPSERT = true;
                        }
                    }

                    //oSalesInvoices.U_OPPORTUNITYNO = objModel.OpportunityNo;
                    oSalesInvoices.SalesPersonCode = objModel.SalesEmployee;
                    //oSalesInvoices.U_PRICELISTCODE = objModel.PriceListCode;
                    oSalesInvoices.DocCurrency = objModel.DocCurrency;
                    oSalesInvoices.DocRate = objModel.U_ExchRate;
                    //oSalesInvoices.U_ORDERTYPE = objModel.OrderType;

                    oSalesInvoices.CardCode = objModel.CardCode;
                    //oSalesInvoices.U_CONTAINERTYPE = objModel.ContainerType;
                    //oSalesInvoices.U_BRANDINGTYPE = objModel.BrandingType;

                    oSalesInvoices.Series = objModel.Series;
                    oSalesInvoices.DocDate = objModel.PostingDate;
                    oSalesInvoices.TaxDate = objModel.DocDate;
                    oSalesInvoices.DocDueDate = objModel.DeliveryDate;
                    //oSalesInvoices.U_TRADEREGION = objModel.TradeRegion;

                    oSalesInvoices.ContactPersonCode = objModel.ContactPersonCode;
                    //oSalesInvoices.U_SUBJECT = objModel.Subject;
                    //oSalesInvoices.U_COVERINGBODY = objModel.CoveringBody;

                    //oSalesInvoices.PayToCode = objModel.PayToCode;
                    //oSalesInvoices.ShipToCode = objModel.ShipToCode;
                    if (!string.IsNullOrEmpty(objModel.PayToCode) && objModel.PayToCode != "0")
                    {

                        oSalesInvoices.PayToCode = objModel.PayToCode;
                    }
                    else
                    {
                        oSalesInvoices.PayToCode = null;
                    }
                    if (!string.IsNullOrEmpty(objModel.ShipToCode) && objModel.ShipToCode != "0")
                    {

                        oSalesInvoices.ShipToCode = objModel.ShipToCode;
                    }
                    else
                    {
                        oSalesInvoices.ShipToCode = null;
                    }
                    oSalesInvoices.Comments = objModel.Comments;
                    oSalesInvoices.Rounding = objModel.Rounding;
                    oSalesInvoices.RoundingDiffAmount = objModel.RoundingDiffAmount;
                    oSalesInvoices.U_Territory = objModel.U_Territory;
                    oSalesInvoices.U_USER = objModel.U_USER;
                    oSalesInvoices.U_Avalibility = objModel.DocumentStatus;
                    oSalesInvoices.U_PT = objModel.RequestType.ToString();
                    /*if (objModel.PaymentTerms != 0 && !String.IsNullOrEmpty(Convert.ToString(objModel.PaymentTerms)))
                      {
                          oSalesInvoices.PaymentGroupCode = objModel.PaymentTerms;
                      }
                      oSalesInvoices.U_CBM = objModel.CBM;
                      oSalesInvoices.U_TOTALGROSSWEIGHT = objModel.TotalGrossWeight;
                      oSalesInvoices.U_TOTALNETWEIGHT = objModel.TotalNetWeight;
                      oSalesInvoices.U_SHIPMENTMODE = objModel.ShipmentMode;
                      oSalesInvoices.U_FRIEGHTTERMS = objModel.FrieghtTerms;
                      oSalesInvoices.U_DESTINATIONPORT = objModel.DestinationPort;
                      oSalesInvoices.U_EXPORTCERTIFICATENO = objModel.ExportCertificateNo;
                      oSalesInvoices.U_ETD = objModel.ETD;
                      oSalesInvoices.U_PRECARRIAGEBY = objModel.PreCarriageBy;
                      oSalesInvoices.U_MANUFACTURINGDATE = objModel.ManufacturingDate;
                      oSalesInvoices.U_PRECARRIAGERECEIPTPLACE = objModel.PreCarriageReceiptPlace;
                      oSalesInvoices.U_LEONO = objModel.LeoNo;
                      oSalesInvoices.U_COMMISSION = Convert.ToDouble(objModel.Commission);
                      oSalesInvoices.U_SHIPPINGBILLNO = objModel.ShippingBillNo;
                      oSalesInvoices.U_ETA = objModel.ETA;
                      oSalesInvoices.U_VESSEL = objModel.Vessel;
                      oSalesInvoices.U_EXPIRYDATE = objModel.ExpiryDate;
                      oSalesInvoices.U_DELIVERYPLACE = objModel.DeliveryPlace;
                      oSalesInvoices.U_PORTCODE = objModel.PortCode;
                      oSalesInvoices.U_PACKAGECHARGES = objModel.PackageCharges;
                      oSalesInvoices.U_VALIDITYUPTO = objModel.ValidityUpTo;
                      oSalesInvoices.U_BOOKINGPARTY = objModel.BookingParty;
                      oSalesInvoices.U_FREIGHT = Convert.ToDouble(objModel.Freight);
                      oSalesInvoices.U_REFERENCENO = objModel.ReferenceNo;
                      oSalesInvoices.U_LOADINGPORT = objModel.LoadingPort;
                      oSalesInvoices.U_RATE = Convert.ToDouble(objModel.Rate);
                      oSalesInvoices.U_LETTERTEMPLATE = objModel.LetterTemplate;
                      oSalesInvoices.U_LETTERTEMPLATEBODY = objModel.LetterTemplateBody;
                      oSalesInvoices.U_PRODUCTTYPE = objModel.ProductType;
                      oSalesInvoices.U_PRINCIPALCOMPANY = objModel.PrincipleCompany;
                      oSalesInvoices.U_MODEL = objModel.Model;
                      oSalesInvoices.U_SYSTEMID = objModel.System;*/

                    if (UPSERT == false)
                        oSalesInvoices.U_CREATEDBY = objModel.CreatedBy;

                    oSalesInvoices.U_UPDATEDBY = objModel.CreatedBy;

                    oSalesInvoices.U_PORTALMODULE = "OINV";
                    

                    foreach (DataItems item in objModel.DocumentLines)
                    {
                        double Quantity = item.ItemQuantity.Value;
                        oSalesInvoicesLines = new DocumentLines();

                        if (Quantity != 0)
                        {
                            if (item.Linenum != -1)
                            {
                                oSalesInvoicesLines.LineNum = item.Linenum;
                            }

                            oSalesInvoicesLines.U_BRAND = item.ItemBrand;
                            oSalesInvoicesLines.ItemCode = item.ItemItemCode;
                            oSalesInvoicesLines.U_SIZE = item.ItemSize;
                            oSalesInvoicesLines.U_PKGCARTON = item.ItemPkgCarton;
                            oSalesInvoicesLines.U_NOOFCARTON = item.ItemNoofCarton;
                            oSalesInvoicesLines.Quantity = Quantity;
                            oSalesInvoicesLines.UnitPrice = item.ItemPrice;
                            oSalesInvoicesLines.TaxCode = item.ItemTax;
                            oSalesInvoicesLines.WarehouseCode = item.WarehouseCode;
                            oSalesInvoicesLines.DiscountPercent = item.DiscountPercent;
                            //oSalesInvoicesLines.LocationCode = _repo.GetLocationCode(objModel.WhsCode);
                            oSalesInvoicesLines.U_NETWEIGHT = item.ItemNetWeight;
                            oSalesInvoicesLines.U_GROSSWEIGHT = item.ItemGrossWeight;
                            oSalesInvoicesLines.U_UOM = item.ItemUOM;
                            oSalesInvoicesLines.SalesPersonCode = objModel.SalesEmployee;

                            if (!String.IsNullOrEmpty(Convert.ToString(objModel.DeliveryDate)))
                                oSalesInvoicesLines.ShipDate = Convert.ToDateTime(objModel.DeliveryDate);

                            if (item.BaseEntry != -1)
                            {
                                oSalesInvoicesLines.BaseType = item.BaseType;
                                oSalesInvoicesLines.BaseEntry = item.BaseEntry;
                                oSalesInvoicesLines.BaseLine = item.BaseLine;
                            }

                            oSalesInvoices.DocumentLines.Add(oSalesInvoicesLines);
                        }
                    }
                    Dictionary<int, string> SuccessData = new Dictionary<int, string>();
                    string data = JsonConvert.SerializeObject(oSalesInvoices,
                    new JsonSerializerSettings()
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                    Common.TraceLogInfo("digvijay3 :" + data);
                    if (UPSERT == true)
                    {
                        SuccessData = ServiceLayerData.SAPUpdateToSalesInvoices(data, objModel.DocEntry.Value);
                    }
                    else
                    {
                        SuccessData = ServiceLayerData.SAPAddToSalesInvoices(data);
                    }
                    if (SuccessData.FirstOrDefault().Key == 1)
                    {
                        int NEWDOCENTRY = 0;
                        int docNum = 0;
                        decimal? DocTotal = 0;
                        string U_VerCode;
                        string U_FiscalDoc;
                        string U_URAPosted;
                        string U_Payment;
                        string status = "";

                        if (UPSERT == true)
                        {
                            NEWDOCENTRY = objModel.DocEntry.Value;
                            docNum = objModel.DocNum.Value;
                            U_VerCode = objModel.U_VerCode;
                            U_FiscalDoc = objModel.U_FiscalDoc;
                            U_URAPosted = objModel.U_URAPosted;
                            U_Payment = objModel.RequestType.ToString();
                        }
                        else
                        {
                            Documents data1 = JsonConvert.DeserializeObject<Documents>(SuccessData.FirstOrDefault().Value);
                            NEWDOCENTRY = data1.DocEntry.Value;
                            docNum = data1.DocNum.Value;
                            U_VerCode = data1.U_VerCode;
                            U_FiscalDoc = data1.U_FiscalDoc;
                            U_URAPosted = data1.U_URAPosted;
                            U_Payment = objModel.RequestType.ToString();
                            status = data1.DocumentStatusType;
                            DocTotal = data1.DocTotal;
                            if (objModel.RequestType==1)
                            {

                           
                            PaymentIncoming paymentIncoming = new PaymentIncoming();
                            paymentIncoming.CardCode = data1.CardCode;
                            paymentIncoming.CashSum = data1.DocTotal.HasValue ? data1.DocTotal.Value:0;
                            paymentIncoming.CashAccount = SessionUtility.U_Cash;
                            paymentIncoming.PaymentInvoices = new List<PaymentInvoice>();
                            paymentIncoming.PaymentInvoices.Add(new PaymentInvoice
                            {
                                DocEntry = NEWDOCENTRY,
                                SumApplied = data1.DocTotal.HasValue ? data1.DocTotal.Value : 0,
                            InvoiceType = "it_Invoice"
                            });
                            data = JsonConvert.SerializeObject(paymentIncoming,
                    new JsonSerializerSettings()
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                            ServiceLayerData.SAPIncomingPayments(data);
                        }
                        }
                        if (UPSERT == false || objModel.DocEntry == null)
                        {
                            objModel.DocEntry = NEWDOCENTRY;
                            objModel.DocNum = docNum;
                            objModel.U_FiscalDoc = U_FiscalDoc;
                            objModel.U_VerCode = U_VerCode;
                            objModel.U_URAPosted = U_URAPosted;
                            objModel.RequestType = Convert.ToInt32(U_Payment);
                            objModel.DocTotal = DocTotal;
                            objModel.ARStatus = "A";
                            objModel.DocumentStatus = status;
                            SAPARInvoiceInsertUpdateUser(objModel);
                        }
                        SAPErrMsg = "AR Invoice Submitted Successfully. Document Number : " + NEWDOCENTRY.ToString();//Common.SAP_DOCUMENTNUMBER("OINV", NEWDOCENTRY.ToString(), "DocEntry");

                        obj.errorCode = "1";
                        obj.errorMsg = SAPErrMsg;
                    }
                    else if (SuccessData.FirstOrDefault().Key == 2)
                    {
                        ErrorObject Data = JsonConvert.DeserializeObject<ErrorObject>(SuccessData.FirstOrDefault().Value.ToString());
                        SAPErrMsg = Data.error.code + " - " + Data.error.message.value;
                        obj.errorCode = "0";
                        obj.errorMsg = SAPErrMsg;
                    }
                    else
                    {
                        SAPErrMsg = SuccessData.FirstOrDefault().Value.ToString();
                        obj.errorCode = "0";
                        obj.errorMsg = SAPErrMsg;
                    }
                }
                else if (Login.FirstOrDefault().Key == 2)
                {
                    ErrorObject Data = JsonConvert.DeserializeObject<ErrorObject>(Login.FirstOrDefault().Value.ToString());
                    SAPErrMsg = Data.error.code + " - " + Data.error.message.value;
                    obj.errorCode = "0";
                    obj.errorMsg = SAPErrMsg;
                }
                else
                {
                    SAPErrMsg = Login.FirstOrDefault().Value.ToString();
                    obj.errorCode = "0";
                    obj.errorMsg = SAPErrMsg;
                }
            }
            catch (Exception ex)
            {
                obj.errorCode = "0";
                obj.errorMsg = ex.Message.ToString();
            }
            return obj;
        }

        public SalesDocumentsDefault CancelInvoice(int docEntry)
        {
            SalesDocumentsDefault obj = new SalesDocumentsDefault();
            try
            {
                ServiceLayerSync ServiceLayerData = new ServiceLayerSync();
                Dictionary<int, string> Login = ServiceLayerData.SAPLogin();
                if (Login.FirstOrDefault().Key == 1)
                {
                    Dictionary<int, string> SuccessData = new Dictionary<int, string>();
                    SuccessData = ServiceLayerData.SAPCancelToSalesInvoices(docEntry);
                    if (SuccessData.FirstOrDefault().Key == 1)
                    {
                        SAPErrMsg = "Sales Invoice Cancel Successfully. Document Number : " + docEntry.ToString();//Common.SAP_DOCUMENTNUMBER("OINV", NEWDOCENTRY.ToString(), "DocEntry");
                        obj.errorCode = "1";
                        obj.errorMsg = SAPErrMsg;
                    }
                    else if (SuccessData.FirstOrDefault().Key == 2)
                    {
                        ErrorObject Data = JsonConvert.DeserializeObject<ErrorObject>(SuccessData.FirstOrDefault().Value.ToString());
                        SAPErrMsg = Data.error.code + " - " + Data.error.message.value;
                        obj.errorCode = "0";
                        obj.errorMsg = SAPErrMsg;
                    }
                    else
                    {
                        SAPErrMsg = SuccessData.FirstOrDefault().Value.ToString();
                        obj.errorCode = "0";
                        obj.errorMsg = SAPErrMsg;
                    }
                }
                else if (Login.FirstOrDefault().Key == 2)
                {
                    ErrorObject Data = JsonConvert.DeserializeObject<ErrorObject>(Login.FirstOrDefault().Value.ToString());
                    SAPErrMsg = Data.error.code + " - " + Data.error.message.value;
                    obj.errorCode = "0";
                    obj.errorMsg = SAPErrMsg;
                }
                else
                {
                    SAPErrMsg = Login.FirstOrDefault().Value.ToString();
                    obj.errorCode = "0";
                    obj.errorMsg = SAPErrMsg;
                }
            }
            catch (Exception ex)
            {
                obj.errorCode = "0";
                obj.errorMsg = ex.Message.ToString();
            }
            return obj;
        }

        #region User
        public SalesDocumentsDefault SAPARInvoiceInsertUpdateUser(SalesOrderQuotationDocument objModel)
        {
            SalesDocumentsDefault obj = new SalesDocumentsDefault();
            try
            {
                objCon = new SQL_CONN_Class();

                string ParamName = "";
                string ParamVal = "";
                ParamName = "@InvoiceID|@DocEntry|@DocNum|@DocStatus|@DocDate|@DocDueDate|@TaxDate|@CardCode|@CardName" +
                    "|@DocCur" +
                    "|@SlpCode|@CntctCode|@Series|@UserSign|@PayToCode|@ShipToCode|@Comments|" +
                    "@U_Territory|@U_VerCode|@U_FiscalDoc|@U_URAPosted|@U_Payment" +
                    "|@RoundDif|@DocTotal|@Rounding|@ARStatus|@RETURNID";
                ParamVal = objModel.QuotaionID + "|" + objModel.DocEntry + "|" + objModel.DocNum
                    + "|" + objModel.DocumentStatus + "|" + Convert.ToDateTime(objModel.PostingDate).ToString("yyyy-MM-dd") + "|" + Convert.ToDateTime(objModel.DeliveryDate).ToString("yyyy-MM-dd") + "|" + Convert.ToDateTime(objModel.DocDate).ToString("yyyy-MM-dd")
                    + "|" + objModel.CardCode + "|" + objModel.CardName
                    + "|" + objModel.DocCurrency + "|" + objModel.SalesEmployee + "|" + objModel.ContactPersonCode + "|" + objModel.Series
                    + "|" + SessionUtility.Code + "|" + objModel.PayToCode + "|" + objModel.ShipToCode + "|" + objModel.Comments
                    + "|" + objModel.U_Territory +  "|" + objModel.U_VerCode + "|" + objModel.U_FiscalDoc + "|" + objModel.U_URAPosted + "|" + objModel.RequestType.ToString()
                    + "|" + objModel.RoundingDiffAmount + "|" + objModel.DocTotal + "|" + objModel.Rounding + "|" + objModel.ARStatus
                    + "|" + objModel.RETURNID;

                var dtItemDetails = objCon.ByProcedureExecScalar_Return("SAP_U_OINVInsertUpdate", 27, ParamName, ParamVal);
                if (dtItemDetails > 0)
                {
                    SAPErrMsg = "AR Invoice Submitted Successfully. Document Number : " + dtItemDetails.ToString();//Common.SAP_DOCUMENTNUMBER("OQUT", NEWDOCENTRY.ToString(), "DocEntry");
                    foreach (var item in objModel.DocumentLines)
                    {
                        ParamName = "@InvoiceDetailsID|@InvoiceID|@ItemCode|@Dscription|@Quantity|@DiscPrcnt|@WhsCode|@TaxCode|@UnitPrice|@RETURNID";
                        ParamVal = item.QuotaionDetailsID + "|" + dtItemDetails + "|" + item.ItemItemCode
                            + "|" + item.ItemDescription + "|" + item.ItemQuantity + "|" + item.DiscountPercent + "|" + item.WarehouseCode + "|" + item.ItemTax + "|" + item.ItemPrice + "|" + objModel.RETURNID;
                        objCon.ByProcedureExecScalar_Return("SAP_U_INV1InsertUpdate", 10, ParamName, ParamVal);
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
        public QuotationListDefault SAPARInvoiceListUser(string userID, int skip)
        {
            QuotationListDefault obj = new QuotationListDefault();
            try
            {
                string query = @"SELECT  InvoiceID,
 (CASE WHEN DocEntry = 0 OR DocEntry is null THEN InvoiceID ELSE DocEntry end) as DocEntry,
 DocNum,
CONVERT(varchar, CAST(DocDate AS datetime), 103) as DocDate,
CardCode as CardCode,
CardName as CardName,
DocStatus as DocumentStatus,U.Name as U_USER,U_VerCode,U_FiscalDoc,U_URAPosted, ISNULL(DocTotal,0) AS DocTotal,U_Payment as U_PT,ARStatus   FROM U_OINV INNER JOIN [@USER] U ON U.Code = U_OINV.UserSign WHERE UserSign='" + userID + "'";
                if (SessionUtility.U_AdminRights == "Y")
                {
                    query = @"SELECT (CASE WHEN DocEntry = 0 OR DocEntry is null THEN InvoiceID ELSE DocEntry end) as DocEntry,
 DocNum,
CONVERT(varchar, CAST(DocDate AS datetime), 103) as DocDate,
CardCode as CardCode,
CardName as CardName,
DocStatus as DocumentStatus,U.Name as U_USER,U_VerCode,U_FiscalDoc,U_URAPosted, ISNULL(DocTotal,0) AS DocTotal,U_Payment as U_PT,ARStatus  FROM U_OINV INNER JOIN [@USER] U ON U.Code = U_OINV.UserSign WHERE ARStatus='O'";
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
        public SalesOrderQuotationDocument GetARInvoiceUserById(int docEntry)
        {
            var model = new SalesOrderQuotationDocument();
            try
            {
                string queryHeader = @"select 
                InvoiceID as QuotaionID,
                DocEntry as DocEntry,
                CardCode as CardCode,
                CardName as CardName,
                SlpCode as SalesEmployee,
                CntctCode as ContactPersonCode,
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
                U_Territory as U_Territory
,
U.Name as U_USER,U_Payment,U_VerCode,U_FiscalDoc,U_URAPosted,ARStatus
                from U_OINV INNER JOIN [@USER] U ON U.Code = U_OINV.UserSign  WHERE InvoiceID = " + docEntry;
                var Data = objCon.ByQueryReturnDataTable(queryHeader);
                if (Data != null && Data.Rows.Count > 0)
                {
                    model.DocumentLines = new List<DataItems>();
                    model.DocEntry = Convert.ToInt32(Data.Rows[0]["DocEntry"]);
                    model.DocumentType = "AR";
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
                    model.Rounding = Data.Rows[0]["Rounding"].ToString();
                    model.U_Territory = Data.Rows[0]["U_Territory"].ToString();
                    model.U_VerCode = Data.Rows[0]["U_VerCode"].ToString();
                    model.U_FiscalDoc = Data.Rows[0]["U_FiscalDoc"].ToString();
                    model.U_URAPosted = Data.Rows[0]["U_URAPosted"].ToString();
                    model.U_USER = Data.Rows[0]["U_USER"].ToString();
                    model.RequestType = Convert.ToInt32(Data.Rows[0]["U_Payment"].ToString() ?? "0");
                    model.ARStatus = Data.Rows[0]["ARStatus"].ToString();
                    model.RoundingDiffAmount = Convert.ToDouble(Data.Rows[0]["RoundingDiffAmount"].ToString());
                    var queryList = @"SELECT * FROM U_INV1 WHERE InvoiceID = " + docEntry;
                    var listItem = objCon.ByQueryReturnDataTable(queryList);
                    if (listItem != null && listItem.Rows.Count > 0)
                    {
                        foreach (DataRow item in listItem.Rows)
                        {
                            model.DocumentLines.Add(new DataItems
                            {
                                QuotaionDetailsID = Convert.ToInt32(item["InvoiceDetailsID"]),
                                ItemDescription = item["Dscription"].ToString(),
                                ItemItemCode = item["ItemCode"].ToString(),
                                ItemQuantity = Convert.ToDouble(item["Quantity"].ToString()),
                                ItemPrice = Convert.ToDouble(item["UnitPrice"].ToString()),
                                DiscountPercent = Convert.ToDouble(!string.IsNullOrEmpty(item["DiscPrcnt"].ToString()) ? item["DiscPrcnt"].ToString() : "0"),
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