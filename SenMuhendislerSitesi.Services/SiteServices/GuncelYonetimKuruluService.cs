using SenMuhendislerSitesi.DAL.Models;
using SenMuhendislerSitesi.DAL.Repository;
using SenMuhendislerSitesi.DAL.UnitOfWork;
using SenMuhendislerSitesi.Domain.Enums;
using SenMuhendislerSitesi.Domain.ViewModels.SiteViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.Services.SiteServices
{
    public class GuncelYonetimKuruluService : BaseService
    {
        private readonly Repository<GuncelYonetimKurulu> _GuncelYonetimKuruluRepository;

        public GuncelYonetimKuruluService(UnitOfWork uow) : base(uow)
        {
            _GuncelYonetimKuruluRepository = new Repository<GuncelYonetimKurulu>(_uowBase);
        }

        public IQueryable<GuncelYonetimKuruluViewModel> GuncelYonetimKuruluListele()
        {
            var viewModel = _GuncelYonetimKuruluRepository.GetList(null, x => x.Id).Select(x => new GuncelYonetimKuruluViewModel
            {
                Id = x.Id,
                Durum = x.Durum,
                //FotografUrl = x.FotografUrl,
                OlusturulmaTarihi = x.OlusturulmaTarihi,
                SilindiMi = x.SilindiMi,
                GuncellemeTarihi = x.GuncellemeTarihi,
                Ad = x.Ad,
                GorevSuresi = x.GorevSuresi,
                Soyad = x.Soyad,
                Unvan = x.Unvan
               });
            return viewModel;
        }
        public GuncelYonetimKuruluViewModel GuncelYonetimKuruluGetir(int Id)
        {
            GuncelYonetimKurulu model = _GuncelYonetimKuruluRepository.Get(x => x.Id == Id);

            return new GuncelYonetimKuruluViewModel
            {
                Id = model.Id,
                Durum = model.Durum,
                //FotografUrl = model.FotografUrl,
                GuncellemeTarihi = model.GuncellemeTarihi,
                SilindiMi = model.SilindiMi,
                OlusturulmaTarihi = model.OlusturulmaTarihi,
                Ad = model.Ad,
                GorevSuresi = model.GorevSuresi,
                Soyad = model.Soyad,
                Unvan = model.Unvan
            };
        }
    }
}
