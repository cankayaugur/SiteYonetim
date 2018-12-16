using SenMuhendislerSitesi.Domain.ViewModels.SiteViewModels;
using SenMuhendislerSitesi.Services.AdminServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SenMuhendislerSitesi.WEB.Areas.SSAdmin.Controllers
{
    public class AdresController : BaseController
    {
        public const string AdresForm = "Form";
        public const string AdresList = "List";

        private readonly AdresService _adresService;

        public AdresController()
        {
            _adresService = new AdresService(_unitOfWork);
        }

        public ActionResult Ekle()
        {
            return View(AdresForm, new AdresViewModel());
        }

        public ActionResult Index()
        {
            var viewModel = _adresService.AdresListele().ToList();
            return View(AdresList, viewModel);
        }
        public ActionResult Duzenle(int Id)
        {
            ViewBag.Adresler = _adresService.AdresGetir(Id);

            var viewModel = _adresService.AdresGetir(Id);
            return View(AdresForm, viewModel);
        }
        public ActionResult Kaydet(AdresViewModel viewModel)
        {
            if (viewModel.Id == 0)
            {
                _adresService.AdresEkle(viewModel);
            }
            else
            {
                _adresService.AdresGuncelle(viewModel);
            }

            _unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public JsonResult Sil(int Id)
        {
            _adresService.AdresSil(Id);
            _unitOfWork.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAdresList()
        {
            var viewModel = _adresService.AdresListele().ToList();
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }
    }
}