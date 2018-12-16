using SenMuhendislerSitesi.Domain.ViewModels.AdminViewModels;
using SenMuhendislerSitesi.Services.AdminServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SenMuhendislerSitesi.WEB.Areas.SSAdmin.Controllers
{
    public class YonetimKuruluController : BaseController
    {
        public const string YonetimKuruluForm = "Form";
        public const string YonetimKuruluList = "List";

        private readonly YonetimKuruluService _yonetimKuruluService;

        public YonetimKuruluController()
        {
            _yonetimKuruluService = new YonetimKuruluService(_unitOfWork);
        }

        public ActionResult Ekle()
        {

            return View(YonetimKuruluForm, new YonetimKuruluViewModel());
        }

        public ActionResult Index()
        {
            var viewModel = _yonetimKuruluService.YonetimKuruluListele().ToList();
            return View(YonetimKuruluList, viewModel);
        }
        public ActionResult Duzenle(int Id)
        {

            //ViewBag.Kategoriler = _yonetimKuruluService.YonetimKuruluListele();

            var viewModel = _yonetimKuruluService.YonetimKuruluGetir(Id);
            return View(YonetimKuruluForm, viewModel);
        }
        public ActionResult Kaydet(YonetimKuruluViewModel viewModel)
        {
            if (viewModel.Id == 0)
            {
                viewModel.KisiId = _kisi.Id;
                _yonetimKuruluService.YonetimKuruluEkle(viewModel);
            }
            else
            {
                viewModel.KisiId = _kisi.Id;
                _yonetimKuruluService.YonetimKuruluGuncelle(viewModel);
            }

            _unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public JsonResult Sil(int Id)
        {
            _yonetimKuruluService.YonetimKuruluSil(Id);
            _unitOfWork.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetYonetimKuruluList()
        {
            var viewModel = _yonetimKuruluService.YonetimKuruluListele().ToList();
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }
    }
}