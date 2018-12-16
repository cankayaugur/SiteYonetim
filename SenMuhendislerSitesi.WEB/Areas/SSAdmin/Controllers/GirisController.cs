using SenMuhendislerSitesi.DAL.UnitOfWork;
using SenMuhendislerSitesi.Domain.ViewModels.AdminViewModels;
using SenMuhendislerSitesi.Services.AdminServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SenMuhendislerSitesi.WEB.Areas.SSAdmin.Controllers
{
    public class GirisController : Controller
    {
        private readonly KisiService _kisiService;
        private UnitOfWork _unitOfWork;
        public GirisController()
        {
            _unitOfWork = new UnitOfWork();
            _kisiService = new KisiService(_unitOfWork);
        }

        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Giris(KisiViewModel viewModel)
        {
            var kisiViewModel = _kisiService.Getir(viewModel);

            if (kisiViewModel.KullaniciAdi != null)
            {
                DateTime girisSaati = new DateTime();
                if (Request.Cookies["giris"] != null)
                {
                    HttpCookie saat = Request.Cookies["giris"];

                    girisSaati = Convert.ToDateTime(saat["giriszamani"]);

                }


                HttpCookie cerez = new HttpCookie("giris");
                cerez.Values.Add("giriszamani", DateTime.Now.ToString());
                cerez.Values.Add("songiriszamani", girisSaati.ToString());


                cerez.Expires = DateTime.Now.AddDays(15);

               
                Response.Cookies.Add(cerez);



                
                Session["KullaniciBilgileri"] = kisiViewModel;
                return Redirect("/SSAdmin/Anasayfa/index");

            }
            else 
            {

                
                TempData["giris"] = "Kullanıcı sistemde bulunamadı";
                return RedirectToAction(nameof(Index));
            }


        }

        public ActionResult Cikis()
        {

            Session["KullaniciBilgileri"] = null;
            return RedirectToAction(nameof(Index));
        }

    }
}