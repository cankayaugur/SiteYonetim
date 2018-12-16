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
    public class GaleriService : BaseService
    {
        public readonly Repository<Galeri> _galeriRepository;
        public GaleriService(UnitOfWork uow) : base(uow)
        {
            _galeriRepository = new Repository<Galeri>(uow);
        }

        public IQueryable<GaleriViewModel> GaleriListele()
        {
            var viewModel = _galeriRepository.GetList(null, x => x.Id).Select(x => new GaleriViewModel
            {
                Id = x.Id,
                Durum = x.Durum,
                FotografUrl = x.FotografUrl,
                OlusturulmaTarihi = x.OlusturulmaTarihi,
                SilindiMi = x.SilindiMi,
                GuncellemeTarihi = x.GuncellemeTarihi,
                Ad = x.Ad
            });
            return viewModel;
        }
        public GaleriViewModel GaleriGetir(int Id)
        {
            Galeri model = _galeriRepository.Get(x => x.Id == Id);

            return new GaleriViewModel
            {
                Id = model.Id,
                Durum = model.Durum,
                FotografUrl = model.FotografUrl,
                GuncellemeTarihi = model.GuncellemeTarihi,
                SilindiMi = model.SilindiMi,
                OlusturulmaTarihi = model.OlusturulmaTarihi,
                Ad = model.Ad
            };
        }
    }
}
