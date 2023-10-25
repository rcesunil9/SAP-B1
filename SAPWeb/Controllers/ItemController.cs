using SAPWeb.Repository.Implementation;
using SAPWeb.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAPWeb.Controllers
{
    public class ItemController : BaseController
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
            var response = itemRepository.GetItem(code,SessionUtility.U_WhsCode);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}