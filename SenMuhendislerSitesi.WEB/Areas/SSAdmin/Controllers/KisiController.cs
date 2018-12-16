using SenMuhendislerSitesi.Domain.ViewModels.AdminViewModels;
using SenMuhendislerSitesi.Services.AdminServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SenMuhendislerSitesi.WEB.Areas.SSAdmin.Controllers
{
    public class KisiController : BaseController
    {
        public const string KisiForm = "Form";
        public const string KisiList = "List";

        private readonly KisiService _kisiService;

        public KisiController()
        {
            _kisiService = new KisiService(_unitOfWork);
        }

        public ActionResult Ekle()
        {
            return View(KisiForm, new KisiViewModel());
        }

        public ActionResult Index()
        {
            var viewModel = _kisiService.Listele().ToList();
            return View(viewModel);
        }
        public ActionResult Duzenle(int Id)
        {
            var viewModel = _kisiService.IdGetir(Id);
            return View(KisiForm, viewModel);
        }
        public ActionResult Kaydet(DuyuruViewModel viewModel)
        {
            if (viewModel.Id == 0)
            {
                //viewModel.KisiId = _kisi.Id;
                //_kisiService.Ekle(viewModel);
            }
            else
            {
                //viewModel.KisiId = _kisi.Id;
                //_kisiService.Guncelle(viewModel);
            }

            _unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public JsonResult Sil(int Id)
        {
            _kisiService.Sil(Id);
            _unitOfWork.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetKisiList()
        {
            var viewModel = _kisiService.Listele().ToList();
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }
    }
}