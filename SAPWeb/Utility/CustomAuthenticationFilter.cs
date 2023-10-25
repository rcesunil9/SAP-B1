using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SAPWeb.Utility
{
    public class CustomAuthenticationFilter : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            var Code = Convert.ToInt32(httpContext.Session["Code"]);
            if (Code != null && Code > 0)
            {
                authorize = true;
            }
            return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                    { "controller", "Auth" },
                     { "action", "Index" }
               });
        }
    }
}