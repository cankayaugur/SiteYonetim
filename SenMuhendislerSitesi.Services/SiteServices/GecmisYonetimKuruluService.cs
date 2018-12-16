using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SenMuhendislerSitesi.DAL.Models;
using SenMuhendislerSitesi.DAL.Repository;
using SenMuhendislerSitesi.DAL.UnitOfWork;
using SenMuhendislerSitesi.Domain.ViewModels.SiteViewModels;

namespace SenMuhendislerSitesi.Services.SiteServices
{
    public class GecmisYonetimKuruluService : BaseService
    {
        private readonly Repository<GecmisYonetimKurulu> _gecmisyonetimKuruluRepository;

        public GecmisYonetimKuruluService(UnitOfWork uow) : base(uow)
        {
            _gecmisyonetimKuruluRepository = new Repository<GecmisYonetimKurulu>(_uowBase);
        }

        public IQueryable<GecmisYonetimKuruluViewModel> GecmisYonetimKuruluListele()
        {
            var viewModel = _gecmisyonetimKuruluRepository.GetList(null, x => x.Id).Select(x => new GecmisYonetimKuruluViewModel
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
        public GecmisYonetimKuruluViewModel GecmisYonetimKuruluGetir(int Id)
        {
            GecmisYonetimKurulu model = _gecmisyonetimKuruluRepository.Get(x => x.Id == Id);

            return new GecmisYonetimKuruluViewModel
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
