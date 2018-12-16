using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SenMuhendislerSitesi.WEB.Areas.SSAdmin.Controllers
{
    public class AidatController : BaseController
    {
        // GET: SSAdmin/Aidat
        public ActionResult Index()
        {
            return View();
        }
    }
}