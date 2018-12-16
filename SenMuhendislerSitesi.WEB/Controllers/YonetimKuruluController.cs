using SenMuhendislerSitesi.Services.SiteServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SenMuhendislerSitesi.WEB.Controllers
{
    public class YonetimKuruluController : BaseController
    {
        

        public ActionResult Index()
        {
            return View();
        }
    }
}