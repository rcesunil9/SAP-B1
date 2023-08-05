using Newtonsoft.Json;
using SAPWeb.App_Start;
using SAPWeb.Models;
using SAPWeb.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;

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
                    oSalesQuotations.SalesPersonCode = objModel.ContactPersonCode;
                    //oSalesQuotations.U_PRICELISTCODE = objModel.PriceListCode;
                    oSalesQuotations.DocCurrency = objModel.DocCurrency;
                    oSalesQuotations.DocRate = objModel.U_ExchRate;
                   //oSalesQuotations.U_ORDERTYPE = objModel.OrderType;

                    oSalesQuotations.CardCode = objModel.CardCode;
                    //oSalesQuotations.U_CONTAINERTYPE = objModel.ContainerType;
                   // oSalesQuotations.U_BRANDINGTYPE = objModel.BrandingType;

                    oSalesQuotations.Series = objModel.Series;
                    oSalesQuotations.DocDate = objModel.DocDate;
                    oSalesQuotations.TaxDate = objModel.DocDate;
                    //oSalesQuotations.DocDueDate = objModel.DeliveryDate;
                    //oSalesQuotations.U_TRADEREGION = objModel.TradeRegion;

                    //oSalesQuotations.ContactPersonCode = objModel.ContactPersonVal;
                    //oSalesQuotations.U_SUBJECT = objModel.Subject;
                    //oSalesQuotations.U_COVERINGBODY = objModel.CoveringBody;

                    oSalesQuotations.PayToCode = objModel.PayToCode;
                    oSalesQuotations.ShipToCode = objModel.ShipToCode;
                    oSalesQuotations.Comments = objModel.Comments;

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
                            oSalesQuotationsLines.TaxCode = item.ItemTax;
                            oSalesQuotationsLines.WarehouseCode = objModel.WhsCode;
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
                        if (UPSERT == true)
                        {
                            NEWDOCENTRY = objModel.DocEntry.Value;
                        }
                        else
                        {
                            Documents data1 = JsonConvert.DeserializeObject<Documents>(SuccessData.FirstOrDefault().Value);
                            NEWDOCENTRY = data1.DocEntry.Value;
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
                            SAPErrMsg = "Sales Quotation Submitted Successfully. Document Number : " + Common.SAP_DOCUMENTNUMBER("OQUT", NEWDOCENTRY.ToString(), "DocEntry");

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
        #endregion
    }
}