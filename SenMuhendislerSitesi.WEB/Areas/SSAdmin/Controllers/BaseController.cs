using SenMuhendislerSitesi.DAL.UnitOfWork;
using SenMuhendislerSitesi.Domain.ViewModels.AdminViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SenMuhendislerSitesi.WEB.Areas.SSAdmin.Controllers
{
    public class BaseController : Controller
    {
        protected readonly UnitOfWork _unitOfWork;
        public KisiViewModel _kisi;
        public BaseController()
        {
            _unitOfWork = new UnitOfWork();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _kisi = (KisiViewModel)Session["KullaniciBilgileri"];

            base.OnActionExecuting(filterContext);
        }
        protected override void OnActionExecuted(ActionExecutedContext filterContext)//BaseController çalışamdan önce
        {
            //siteye giriş yapılıp yapılmadığını kontrol eden kısım
            if (Session["KullaniciBilgileri"] == null)//Session bilgileri dolumu onu bi kontrol et boşsa
            {
                Response.Redirect("/ssadmin/giris/index");//sen kullanıcı giriş ekranına yönlendir.
            }
            base.OnActionExecuted(filterContext);
        }
       
    }
}