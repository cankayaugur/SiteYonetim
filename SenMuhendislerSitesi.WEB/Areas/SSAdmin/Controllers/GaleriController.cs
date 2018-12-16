using SenMuhendislerSitesi.Domain.ViewModels.AdminViewModels;
using SenMuhendislerSitesi.Services.AdminServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SenMuhendislerSitesi.WEB.Areas.SSAdmin.Controllers
{
   
        public class  GaleriController : BaseController
        {
            public const string GaleriForm = "Form";
            public const string GaleriList = "List";

            private readonly GaleriService _galeriService;

            public GaleriController()
            {
                _galeriService = new GaleriService(_unitOfWork);
            }

            public ActionResult Ekle()
            {
                //ViewBag.Galeriler = _duyuruService.DuyuruListele();
                return View(GaleriForm, new GaleriViewModel());
            }

            public ActionResult Index()
            {
                var viewModel = _galeriService.GaleriListele().ToList();
                return View(GaleriList, viewModel);
            }
            public ActionResult Duzenle(int Id)
            {

                var viewModel = _galeriService.GaleriGetir(Id);
                return View(GaleriForm, viewModel);
            }
            public ActionResult Kaydet(GaleriViewModel viewModel)
            {
                if (viewModel.Id == 0)
                {
                    _galeriService.GaleriEkle(viewModel);
                }
                else
                {
                    _galeriService.GaleriGuncelle(viewModel);
                }

                _unitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            public JsonResult Sil(int Id)
            {
                _galeriService.GaleriSil(Id);
                _unitOfWork.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            public JsonResult GetGaleriList()
            {
                var viewModel = _galeriService.GaleriListele().ToList();
                return Json(viewModel, JsonRequestBehavior.AllowGet);
            }

        }
}