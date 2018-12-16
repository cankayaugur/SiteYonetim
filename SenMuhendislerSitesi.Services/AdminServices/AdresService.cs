using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SenMuhendislerSitesi.DAL.Models;
using SenMuhendislerSitesi.DAL.Repository;
using SenMuhendislerSitesi.DAL.UnitOfWork;
using SenMuhendislerSitesi.Domain.ViewModels.SiteViewModels;

namespace SenMuhendislerSitesi.Services.AdminServices
{
    public class AdresService : BaseService
    {
        public readonly Repository<Adres> _adresRepository;
        public AdresService(UnitOfWork uow) : base(uow)
        {
            _adresRepository = new Repository<Adres>(uow);
        }
        public void AdresGuncelle(AdresViewModel viewModel)
        {

            var model = _adresRepository.Get(x => x.Id == viewModel.Id);


            model.Durum = viewModel.Durum;
            model.AcikAdres = viewModel.AcikAdres;
            model.Avm = viewModel.Avm;
            model.Benzinlik = viewModel.Benzinlik;
            model.Carsi = viewModel.Carsi;
            model.Mahalle = viewModel.Mahalle;
            model.Okul = viewModel.Okul;
            model.OtobusDuragi = viewModel.OtobusDuragi;
            

            

            _adresRepository.Update(model);

        }
        public void AdresEkle(AdresViewModel viewModel)
        {
            _adresRepository.Add(new Adres
            {
                Durum = viewModel.Durum,
                AcikAdres = viewModel.AcikAdres,
                Benzinlik = viewModel.Benzinlik,
                Avm = viewModel.Avm,
                Carsi = viewModel.Carsi,
                Mahalle = viewModel.Mahalle,
                Okul = viewModel.Okul,
                OtobusDuragi = viewModel.OtobusDuragi,
                
            });

        }
        public void AdresSil(int Id)
        {
            _adresRepository.Delete(x => x.Id == Id);
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
