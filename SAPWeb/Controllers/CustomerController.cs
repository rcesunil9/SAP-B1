using SAPWeb.Models;
using SAPWeb.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAPWeb.Controllers
{
    public class CustomerController : BaseController
    {
        CustomerRepository customerRepository;
        public CustomerController()
        {
                customerRepository = new CustomerRepository();
        }
        [HttpGet]
        public JsonResult GetCustomer(string q)
        {
            var response = customerRepository.GetCustomer(q);
            return Json(response,JsonRequestBehavior.AllowGet);    
        }
        [HttpGet]
        public JsonResult GetContactPerson(string code)
        {
            var response = customerRepository.GetContactPerson(code);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetBillAddress(string code)
        {
            var response = customerRepository.GetBillToId(code);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetShipAddress(string code)
        {
            var response = customerRepository.GetShipToId(code);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetSalesQuotation(string code,string username)
        {
            var response = customerRepository.GetSalesQuotation(code,username);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetARInvoice(string code, string username)
        {
            var response = customerRepository.GetARInvoice(code,username);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}