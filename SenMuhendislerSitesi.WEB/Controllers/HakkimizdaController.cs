using SenMuhendislerSitesi.Services.SiteServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SenMuhendislerSitesi.WEB.Controllers
{
    public class HakkimizdaController : BaseController
    {
        private readonly HakkimizdaService _hakkimizdaService;
        public HakkimizdaController()
        {
            _hakkimizdaService = new HakkimizdaService(_unitOfWork);
        }
        // GET: Hakkimizda
        public ActionResult Index()
        {
            return View();
        }
    }
}