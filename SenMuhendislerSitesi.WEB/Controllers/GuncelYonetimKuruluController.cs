using SenMuhendislerSitesi.Services.SiteServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SenMuhendislerSitesi.WEB.Controllers
{
    public class GuncelYonetimKuruluController : BaseController
    {
        public readonly GuncelYonetimKuruluService _guncelYonetimKuruluService;
        public GuncelYonetimKuruluController()
        {
            _guncelYonetimKuruluService = new GuncelYonetimKuruluService(_unitOfWork);
        }


        public ActionResult Index()
        {
            var viewModel = _guncelYonetimKuruluService.GuncelYonetimKuruluListele().ToList();

            return View(viewModel);
        }
        
    }
}