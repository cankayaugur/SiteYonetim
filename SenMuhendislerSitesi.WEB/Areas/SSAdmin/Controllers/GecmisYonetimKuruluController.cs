using SenMuhendislerSitesi.Domain.ViewModels.AdminViewModels;
using SenMuhendislerSitesi.Services.AdminServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SenMuhendislerSitesi.WEB.Areas.SSAdmin.Controllers
{
    public class GecmisYonetimKuruluController : BaseController
    {
        public const string GecmisYonetimKuruluForm = "Form";
        public const string GecmisYonetimKuruluList = "List";

        private readonly GecmisYonetimKuruluService _gecmisYonetimKuruluService;

        public GecmisYonetimKuruluController()
        {
            _gecmisYonetimKuruluService = new GecmisYonetimKuruluService(_unitOfWork);
        }

        public ActionResult Ekle()
        {

            return View(GecmisYonetimKuruluForm, new GecmisYonetimKuruluViewModel());
        }

        public ActionResult Index() 
        {
            var viewModel = _gecmisYonetimKuruluService.GecmisYonetimKuruluListele().ToList();
            return View(GecmisYonetimKuruluList, viewModel);
        }
        public ActionResult Duzenle(int Id)
        {

            var viewModel = _gecmisYonetimKuruluService.GecmisYonetimKuruluGetir(Id);
            return View(GecmisYonetimKuruluForm, viewModel);
        }

        public ActionResult Kaydet(GecmisYonetimKuruluViewModel viewModel)
        {
            if (viewModel.Id == 0)
            {
                viewModel.KisiId = _kisi.Id;
                _gecmisYonetimKuruluService.GecmisYonetimKuruluEkle(viewModel);
            }
            else
            {
                viewModel.KisiId = _kisi.Id;
                _gecmisYonetimKuruluService.GecmisYonetimKuruluGuncelle(viewModel);
            }

            _unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public JsonResult Sil(int Id)
        {
            _gecmisYonetimKuruluService.GecmisYonetimKuruluSil(Id);
            _unitOfWork.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetGecmisYonetimKuruluList()
        {
            var viewModel = _gecmisYonetimKuruluService.GecmisYonetimKuruluListele().ToList();
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }
    }
}