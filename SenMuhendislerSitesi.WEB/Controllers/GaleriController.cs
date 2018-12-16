using SenMuhendislerSitesi.Services.SiteServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SenMuhendislerSitesi.WEB.Controllers
{
    public class GaleriController : BaseController
    {
        public readonly GaleriService _galeriService;
        public GaleriController()
        {
            _galeriService = new GaleriService(_unitOfWork);
        }
        // GET: Galeri
        public ActionResult Index()
        {
            return View();
        }
    }
}