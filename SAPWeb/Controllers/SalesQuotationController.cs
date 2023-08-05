using SAPWeb.Models;
using SAPWeb.Repository.Implementation;
using SAPWeb.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAPWeb.Controllers
{
    public class SalesQuotationController : Controller
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
        public ActionResult Create()
        {
            Init();
            return View();
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
            response = salesQuotationRepository.SAPSalesQuotation(model);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        public void Init()
        {
            ViewBag.TaxCode = itemRepository.GetTaxCode().GetTaxCode;
        }
    }
}