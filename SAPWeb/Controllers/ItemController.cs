using SAPWeb.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAPWeb.Controllers
{
    public class ItemController : Controller
    {
        ItemRepository itemRepository;
        public ItemController()
        {
                itemRepository = new ItemRepository();
        }
        // GET: Item
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetItemDetails(string code)
        {
            var response = itemRepository.GetItem(code);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}