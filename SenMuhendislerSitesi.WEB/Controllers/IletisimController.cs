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
    public class IletisimController : BaseController
    {
        private readonly IletisimService _iletisimService;
        public IletisimController()
        {
            _iletisimService = new IletisimService(_unitOfWork);
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Ekle(IletisimViewModel viewModel)
        {
            if (!string.IsNullOrWhiteSpace(viewModel.Konu) && !string.IsNullOrWhiteSpace(viewModel.Mesaj))
            {
                _iletisimService.IletisimEkle(viewModel);
                _unitOfWork.SaveChanges();
                return Json(true);
            }

            return Json(false);
        }
    }
}