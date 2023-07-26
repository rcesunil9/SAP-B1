using SAPWeb.Models;
using SAPWeb.Repository.Implementation;
using SAPWeb.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
                if (objUser != null && objUser.errorCode=="0")
                {
                    TempData["Athentication"] = objUser;
                    return View(model);
                }
                AddSession(objUser.User.FirstOrDefault());
                return RedirectToAction("", "Dashboard");
            }
            else
            {
                objUser.errorCode = "0";
                objUser.errorMsg = "UserName or Password cannot be blank !";
                TempData["Athentication"] = objUser;
            }
            return View(model);
        }
        private void AddSession(User user)
        {
            SessionUtility.Code = user.Code;
            SessionUtility.U_CashAc = user.U_CashAc;
            SessionUtility.U_WHS = user.U_WHS;
            SessionUtility.U_SERIES = user.U_SERIES;
            SessionUtility.U_SERIESSQ = user.U_SERIESSQ;
        }
        public ActionResult Logout()
        {
            try
            {
                FormsAuthentication.SignOut();
                TempData = null;
                Session.Abandon();
                string[] myCookies = Request.Cookies.AllKeys;
                foreach (string cookie in myCookies)
                {
                    var httpCookie = Response.Cookies[cookie];
                    if (httpCookie != null) httpCookie.Expires = DateTime.Now.AddDays(-1);
                }
                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}