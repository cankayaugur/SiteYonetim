using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SenMuhendislerSitesi.WEB
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



           // routes.MapRoute(
           //    name: "YonetimKuruluDetay",
           //    url: "{controller}-{id}",
           //    defaults: new { controller = "YonetimKurulu", action = "Index", id = UrlParameter.Optional },
           //    namespaces: new[] { "SenMuhendislerSitesi.WEB.Controllers" }
           //);

           // routes.MapRoute(
           //     name: "DuyuruDetay",
           //     url: "{controller}-{id}",
           //     defaults: new { controller = "Duyuru", action = "Index", id = UrlParameter.Optional },
           //     namespaces: new[] { "SenMuhendislerSitesi.WEB.Controllers" }
           // );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Anasayfa", action = "Index", id = UrlParameter.Optional },
                                namespaces: new[] { "SenMuhendislerSitesi.WEB.Controllers" }

            );
        }
    }
}
