using SenMuhendislerSitesi.Domain.ViewModels.AdminViewModels;
using SenMuhendislerSitesi.Services.AdminServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SenMuhendislerSitesi.WEB.Areas.SSAdmin.Controllers
{
    public class GuncelYonetimKuruluController : BaseController
    {
        public const string GuncelYonetimKuruluForm = "Form";
        public const string GuncelYonetimKuruluList = "List";

        private readonly GuncelYonetimKuruluService _guncelYonetimKuruluService;

        public GuncelYonetimKuruluController()
        {
            _guncelYonetimKuruluService = new GuncelYonetimKuruluService(_unitOfWork);
        }

        public ActionResult Ekle()
        {

            return View(GuncelYonetimKuruluForm, new GuncelYonetimKuruluViewModel());
        }

        public ActionResult Index()
        {
            var viewModel = _guncelYonetimKuruluService.GuncelYonetimKuruluListele().ToList();
            return View(GuncelYonetimKuruluList, viewModel);
        }
        public ActionResult Duzenle(int Id)
        {

            var viewModel = _guncelYonetimKuruluService.GuncelYonetimKuruluGetir(Id);
            return View(GuncelYonetimKuruluForm, viewModel);
        }
        public ActionResult Kaydet(GuncelYonetimKuruluViewModel viewModel)
        {
            if (viewModel.Id == 0)
            {
                viewModel.KisiId = _kisi.Id;
                _guncelYonetimKuruluService.GuncelYonetimKuruluEkle(viewModel);
            }
            else
            {
                viewModel.KisiId = _kisi.Id;
                _guncelYonetimKuruluService.GuncelYonetimKuruluGuncelle(viewModel);
            }

            _unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public JsonResult Sil(int Id)
        {
            _guncelYonetimKuruluService.GuncelYonetimKuruluSil(Id);
            _unitOfWork.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetGuncelYonetimKuruluList()
        {
            var viewModel = _guncelYonetimKuruluService.GuncelYonetimKuruluListele().ToList();
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }
    }
}