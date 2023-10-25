﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SAPWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Auth", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "SalesQuotationCreate",
                url: "SalesQuotation/Create/{id}/{type}",
                defaults: new { controller = "SalesQuotation", action = "Create" }
            );
            routes.MapRoute(
                name: "InvoiceCreate",
                url: "Invoice/Create/{id}/{type}",
                defaults: new { controller = "Invoice", action = "Create" }
            );
        }
    }
}
