using System;
using System.Configuration;
using System.Web.Mvc;
using SAPWeb.Models;
using SAPWeb.Repository.Implementation;
using SAPWeb.Utility;

namespace SAPWeb.Controllers
{
    public class SalesQuotationController : BaseController
    {
        ItemRepository itemRepository;
        SalesQuotationRepository salesQuotationRepository;
        public SalesQuotationController()
        {
            itemRepository = new ItemRepository();
            salesQuotationRepository = new SalesQuotationRepository();
        }
        // GET: SalesQuotation
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetSalesQuotation(int skip = 0)
        {
            var response = new QuotationListDefault();
            if(skip==0)
            {
                response = salesQuotationRepository.SAPSalesQuotationListUser(SessionUtility.Code,skip);
            }
            if(SessionUtility.U_AdminRights=="Y")
            {
                var data = salesQuotationRepository.SAPSalesQuotationList(skip);
                response.QuotationDetails.NextLink = data.QuotationDetails.NextLink;
                response.QuotationDetails.Value.AddRange(data.QuotationDetails.Value);
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        [Route("SalesQuotation/Create/{id}/{type}")]
        public ActionResult Create(int id = 0,string type="")
        {
            Init();
            var response = new SalesOrderQuotationDocument();
            ViewBag.Approved = false;
            if (id>0)
            {
                //response = salesQuotationRepository.GetSalesQuotationById(id);
                if (type=="DRAFT" || SessionUtility.U_AdminRights=="N" || string.IsNullOrEmpty(SessionUtility.U_AdminRights))
                {
                    response = salesQuotationRepository.GetSalesQuotationUserById(id);
                }
                else
                {
                    response = salesQuotationRepository.GetSalesQuotationById(id);
                
                }
                if(response.DocumentStatus=="A" || type != "DRAFT")
                {
                    ViewBag.Approved = true;
                }
            }
            return View(response);
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
            if((model.DocEntry!=null && model.DocEntry>0) || model.DocumentStatus=="A")
            {
                response = salesQuotationRepository.SAPSalesQuotation(model);
            }
            else
            {
                response = salesQuotationRepository.SAPSalesQuotaionUser(model);
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetReport(string id)
        {
            ReportRequest reportRequest = new ReportRequest();
            reportRequest.ReportName = Convert.ToString(ConfigurationManager.AppSettings["SalesQuationReport"]);
            reportRequest.DocKey = id;
            reportRequest.ObjectId = "23";
            var response = ReportUtility.GetReport(reportRequest);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        public void Init()
        {
            
            ViewBag.TaxCode = itemRepository.GetTaxCode().GetTaxCode;
            ViewBag.WarHouseCode = itemRepository.GetWarHouse().GetWareHouse;
        }
    }
}