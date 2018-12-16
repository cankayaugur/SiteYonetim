using SenMuhendislerSitesi.Domain.ViewModels.AdminViewModels;
using SenMuhendislerSitesi.Services.AdminServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SenMuhendislerSitesi.WEB.Areas.SSAdmin.Controllers
{
    public class DuyuruController : BaseController
    {
        public const string DuyuruForm = "Form";
        public const string DuyuruList = "List";

        private readonly DuyuruService _duyuruService;

        public DuyuruController()
        {
            _duyuruService = new DuyuruService(_unitOfWork);
        }

        public ActionResult Ekle()
        {
            //ViewBag.Duyurular = _duyuruService.DuyuruListele();
            return View(DuyuruForm, new DuyuruViewModel());
        }

        public ActionResult Index()
        {
            var viewModel = _duyuruService.DuyuruListele().ToList();
            return View(DuyuruList, viewModel);
        }
        public ActionResult Duzenle(int Id)
        {
            ViewBag.Duyurular = _duyuruService.DuyuruListele();
            var viewModel = _duyuruService.DuyuruGetir(Id);
            return View(DuyuruForm, viewModel);
        }
        public ActionResult Kaydet(DuyuruViewModel viewModel)
        {
            if (viewModel.Id == 0)
            {
                viewModel.KisiId = _kisi.Id;
                _duyuruService.DuyuruEkle(viewModel);
            }
            else
            {
                viewModel.KisiId = _kisi.Id;
                _duyuruService.DuyuruGuncelle(viewModel);
            }

            _unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public JsonResult Sil(int Id)
        {
            _duyuruService.DuyuruSil(Id);
            _unitOfWork.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDuyuruList()
        {
            var viewModel = _duyuruService.DuyuruListele().ToList();
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }
    }
}