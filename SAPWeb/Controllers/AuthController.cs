using SAPWeb.Models;
using SAPWeb.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAPWeb.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthRepository db = new AuthRepository();
        // GET: Auth
        public ActionResult Index()
        {
            return View("Login");
        }
        public ActionResult Login(UserLogin model)
        {
            UserDefault objUser = new UserDefault();
            if (!string.IsNullOrEmpty(model.UserName) && !string.IsNullOrEmpty(model.Password))
            {
                objUser = db.CheckLogin(model);
            }
            else
            {
                objUser.errorCode = "0";
                objUser.errorMsg = "UserName or Password cannot be blank !";
            }
            return View(objUser);
        }
    }
}