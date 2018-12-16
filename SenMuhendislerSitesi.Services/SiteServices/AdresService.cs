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
    public class AdresService : BaseService
    {
        public readonly Repository<Adres> _adresRepository;
        public AdresService(UnitOfWork uow) : base(uow)
        {
            _adresRepository = new Repository<Adres>(uow);
        }

        public IQueryable<AdresViewModel> AdresListele()
        {
            var viewModel = _adresRepository.GetList().Select(x => new AdresViewModel
            {
                Id = x.Id,
                Durum = x.Durum,
                GuncellemeTarihi = x.GuncellemeTarihi,
                SilindiMi = x.SilindiMi,
                OlusturulmaTarihi = x.OlusturulmaTarihi,
                AcikAdres = x.AcikAdres,
                Avm = x.Avm,
                Benzinlik = x.Benzinlik,
                Carsi = x.Carsi,
                Mahalle = x.Mahalle,
                Okul = x.Okul,
                OtobusDuragi = x.OtobusDuragi,
            });


            return viewModel;
        }
        public AdresViewModel AdresGetir(int Id)
        {
            var model = _adresRepository.Get(x => x.Id == Id);

            return new AdresViewModel
            {
                Id = model.Id,
                Durum = model.Durum,
                GuncellemeTarihi = model.GuncellemeTarihi,
                SilindiMi = model.SilindiMi,
                OlusturulmaTarihi = model.OlusturulmaTarihi,
                AcikAdres = model.AcikAdres,
                Avm = model.Avm,
                Benzinlik = model.Benzinlik,
                Carsi = model.Carsi,
                Mahalle = model.Mahalle,
                Okul = model.Okul,
                OtobusDuragi = model.OtobusDuragi,
            };

        }
    }
}
