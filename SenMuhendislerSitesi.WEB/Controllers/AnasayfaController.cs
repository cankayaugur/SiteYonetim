using SenMuhendislerSitesi.Domain.ViewModels.SiteViewModels;
using SenMuhendislerSitesi.Services.SiteServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SenMuhendislerSitesi.WEB.Controllers
{
    public class AnasayfaController : BaseController
    {
        public readonly DuyuruService _duyuruService;


        public AnasayfaController()
        {
            _duyuruService = new DuyuruService(_unitOfWork);
        }
        // GET: Anasayfa
        public ActionResult Index()
        {
            List<DuyuruViewModel> duyuruViewModel = _duyuruService.DuyuruListele().ToList();

            return View(duyuruViewModel);
        }
    }
}