using SAPWeb.Models;
using SAPWeb.Repository.Implementation;
using SAPWeb.Repository.Interface;
using SAPWeb.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAPWeb.Controllers
{
    public class InvoiceController : BaseController
    {
        ItemRepository itemRepository;
        ARInvoiceRepository invoiceRepository;

        public InvoiceController()
        {
            itemRepository = new ItemRepository();
            invoiceRepository = new ARInvoiceRepository();
        }
        // GET: Invoice
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetARInvoices(int skip = 0)
        {
            var response = new QuotationListDefault();
            if (skip == 0)
            {
                response = invoiceRepository.SAPARInvoiceListUser(SessionUtility.Code, skip);
            }
            if (SessionUtility.U_AdminRights == "Y")
            {
                var data = invoiceRepository.SAPARInvoiceList(skip);
                response.QuotationDetails.NextLink = data.QuotationDetails.NextLink;
                response.QuotationDetails.Value.AddRange(data.QuotationDetails.Value);
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Save(SalesOrderQuotationDocument model)
        {
            SalesDocumentsDefault response = new SalesDocumentsDefault();
            if (string.IsNullOrEmpty(SessionUtility.Code))
            {
                response.errorCode = "0";
                response.errorMsg = "You Session is timeout, Please logout and login again.!";
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            model.EMPID = SessionUtility.Code;
            if ((model.DocEntry != null && model.DocEntry > 0) || model.DocumentStatus == "A")
            {
                response = invoiceRepository.SAPARInvoiceInsertUpdate(model);
            }
            else
            {
                response = invoiceRepository.SAPARInvoiceInsertUpdateUser(model);
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        [Route("Invoice/Create/{id}/{type}")]
        public ActionResult Create(int id = 0,string type="")
        {
            Init();
            var response = new SalesOrderQuotationDocument();
            ViewBag.Approved = false;
            if (id > 0)
            {
                if (type == "DRAFT" || SessionUtility.U_AdminRights == "N" || string.IsNullOrEmpty(SessionUtility.U_AdminRights))
                {
                    response = invoiceRepository.GetARInvoiceUserById(id);
                }
                else
                {
                    response = invoiceRepository.GetARInvoiceById(id);
                }
                if(response.DocumentLines.Count > 0)
                {
                    foreach (var line in response.DocumentLines) {
                        var item = itemRepository.GetItem(line.ItemItemCode, SessionUtility.U_WhsCode);
                        if(item!=null && item.errorCode=="1" )
                        {
                            var itemCodeData = item.Items.FirstOrDefault();
                            if(itemCodeData!=null && !string.IsNullOrEmpty(itemCodeData.Code))
                            {
                                line.Weight = itemCodeData.Weight;
                                line.ItemCost = itemCodeData.ItemCost;
                                line.InStock = itemCodeData.InStock;
                            }
                        }
                    }
                }
                if (response.DocumentStatus == "A" || type != "DRAFT" || response.DocumentStatus== "bost_Close")
                {
                    ViewBag.Approved = true;
                }
            }
            return View(response);  
        }
        public void Init()
        {
            ViewBag.TaxCode = itemRepository.GetTaxCode().GetTaxCode;
            ViewBag.WarHouseCode = itemRepository.GetWarHouse().GetWareHouse;
        }
        [HttpGet]
        public ActionResult GetReport(string id)
        {
            ReportRequest reportRequest = new ReportRequest();
            reportRequest.ReportName = Convert.ToString(ConfigurationManager.AppSettings["ARInvoiceReport"]);
            reportRequest.DocKey = id;
            reportRequest.ObjectId = "13";
            var response = ReportUtility.GetReport(reportRequest);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult CancelInvoice(int id)
        {
            SalesDocumentsDefault response = new SalesDocumentsDefault();
            response = invoiceRepository.CancelInvoice(id); 
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}