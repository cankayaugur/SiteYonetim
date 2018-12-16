using SenMuhendislerSitesi.DAL.UnitOfWork;
using SenMuhendislerSitesi.Domain.ViewModels.SiteViewModels;
using SenMuhendislerSitesi.Services.SiteServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SenMuhendislerSitesi.WEB.Controllers
{
    public class BaseController : Controller
    {
        public UnitOfWork _unitOfWork;

        private readonly DuyuruService _duyuruService;
        private readonly GaleriService _galeriService;
        private readonly AdresService _adresService;
        public BaseController()
        {
            _unitOfWork = new UnitOfWork();
            _duyuruService = new DuyuruService(_unitOfWork);
            _galeriService = new GaleriService(_unitOfWork);
            _adresService = new AdresService(_unitOfWork);

            CreateIndex();
        }
        public void CreateIndex()
        {
            AnasayfaViewModel Avm = new AnasayfaViewModel
            {
                Duyurular = _duyuruService.DuyuruListele().ToList(),
                Galeriler = _galeriService.GaleriListele().ToList(),
                Adresler = _adresService.AdresGetir(1),
            };

            ViewBag.AnasayfaCompositeViewModel = Avm;
        }

    }
}