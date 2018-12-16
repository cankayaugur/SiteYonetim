using SenMuhendislerSitesi.Services.AdminServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SenMuhendislerSitesi.WEB.Controllers
{
    public class AdresController : BaseController
    {
        public readonly AdresService _adresService;
        public AdresController()
        {
            _adresService = new AdresService(_unitOfWork);
        }
        // GET: Adres
        public ActionResult Index()
        {
            return View();
        }
    }
}