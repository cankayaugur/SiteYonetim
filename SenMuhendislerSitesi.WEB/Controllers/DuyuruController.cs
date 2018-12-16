using SenMuhendislerSitesi.Services.SiteServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SenMuhendislerSitesi.WEB.Controllers
{
    public class DuyuruController : BaseController
    {
        // GET: Duyuru
        public readonly DuyuruService _duyuruService;
        public DuyuruController()
        {
            _duyuruService = new DuyuruService(_unitOfWork);
        }
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult Getir(int Id)
        {
            var viewModel = _duyuruService.DuyuruGetir(Id);
            return View(viewModel);
        }
        public ActionResult Listele()
        {
            var viewModel = _duyuruService.DuyuruListele().ToList();
            return View(viewModel);
        }
       
        
        
    }
}