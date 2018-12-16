using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SenMuhendislerSitesi.DAL.Models;
using SenMuhendislerSitesi.DAL.Repository;
using SenMuhendislerSitesi.DAL.UnitOfWork;
using SenMuhendislerSitesi.Domain.ViewModels.AdminViewModels;

namespace SenMuhendislerSitesi.Services.AdminServices
{
    public class YonetimKuruluService : BaseService
    {
        public readonly Repository<YonetimKurulu> _yonetimKuruluRepository;
        public YonetimKuruluService(UnitOfWork uow) : base(uow)
        {
            _yonetimKuruluRepository = new Repository<YonetimKurulu>(_uowBase);
        }

        public IQueryable<YonetimKuruluViewModel> YonetimKuruluListele()
        {
            var viewmodel = _yonetimKuruluRepository.GetList().Select(x => new YonetimKuruluViewModel
            {
                Ad = x.Ad,
                Durum = x.Durum,
                //FotografUrl = x.FotografUrl,
                GorevSuresi = x.GorevSuresi,
                Id = x.Id,
                OlusturulmaTarihi = x.OlusturulmaTarihi,
                SilindiMi = x.SilindiMi,
                Soyad = x.Soyad
            });
            return viewmodel;
        }
        public YonetimKuruluViewModel YonetimKuruluGetir(int Id)
        {
            var model = _yonetimKuruluRepository.Get(x => x.Id == Id);

            return new YonetimKuruluViewModel
            {
                Id = model.Id,
                Ad = model.Ad,
                Durum = model.Durum,
                //FotografUrl = model.FotografUrl,
                GorevSuresi = model.GorevSuresi,
                OlusturulmaTarihi = model.OlusturulmaTarihi,
                SilindiMi = model.SilindiMi,
                Soyad = model.Soyad
            };
        }
        public void YonetimKuruluGuncelle (YonetimKuruluViewModel viewModel)
        {
            var model = _yonetimKuruluRepository.Get(x => x.Id == viewModel.Id);

            model.GorevSuresi = viewModel.GorevSuresi;
            model.Ad = viewModel.Ad;
            model.Soyad = viewModel.Soyad;
            model.Durum = viewModel.Durum;
            //model.FotografUrl = viewModel.FotografUrl;
            model.KisiId = viewModel.KisiId;

            _yonetimKuruluRepository.Update(model);

        }
        public void YonetimKuruluEkle(YonetimKuruluViewModel viewModel)
        {
            _yonetimKuruluRepository.Add(new YonetimKurulu
            {
                Ad = viewModel.Ad,
                Soyad = viewModel.Soyad,
                GorevSuresi = viewModel.GorevSuresi,
                KisiId = viewModel.KisiId,
                
            });
        }
        public void YonetimKuruluSil(int Id)
        {
            _yonetimKuruluRepository.Delete(x => x.Id == Id);
        }

    }
}
