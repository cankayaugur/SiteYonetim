using SenMuhendislerSitesi.Services.SiteServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SenMuhendislerSitesi.WEB.Controllers
{
    public class GecmisYonetimKuruluController : BaseController
    {
        public readonly GecmisYonetimKuruluService _gecmisYonetimKuruluService;
        public GecmisYonetimKuruluController()
        {
            _gecmisYonetimKuruluService = new GecmisYonetimKuruluService(_unitOfWork);
        }


      

        public ActionResult Index()
        {
            var viewModel = _gecmisYonetimKuruluService.GecmisYonetimKuruluListele();

            return View(viewModel);
        }
        //public ActionResult Getir(int Id)
        //{
        //    var viewModel = _gecmisYonetimKuruluService.GecmisYonetimKuruluGetir(Id);
        //    return View(viewModel);
        //}
    }
}