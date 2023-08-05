using SAPWeb.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAPWeb.Controllers
{
    public class InvoiceController : Controller
    {
        ItemRepository itemRepository;

        public InvoiceController()
        {
            itemRepository = new ItemRepository();
        }
        // GET: Invoice
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            Init();
            return View();  
        }
        public void Init()
        {
            ViewBag.TaxCode = itemRepository.GetTaxCode().GetTaxCode;
        }
    }
}