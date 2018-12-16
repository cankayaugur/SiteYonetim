using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SenMuhendislerSitesi.DAL.Models;
using SenMuhendislerSitesi.DAL.Repository;
using SenMuhendislerSitesi.DAL.UnitOfWork;
using SenMuhendislerSitesi.Domain.DTOS;
using SenMuhendislerSitesi.Domain.Globals;
using SenMuhendislerSitesi.Domain.Methods;
using SenMuhendislerSitesi.Domain.ViewModels.AdminViewModels;

namespace SenMuhendislerSitesi.Services.AdminServices
{
    public class GuncelYonetimKuruluService : BaseService
    {
        public readonly Repository<GuncelYonetimKurulu> _guncelYonetimKuruluRepository;
        public GuncelYonetimKuruluService(UnitOfWork uow) : base(uow)
        {
            _guncelYonetimKuruluRepository = new Repository<GuncelYonetimKurulu>(_uowBase);
        }
        public IQueryable<GuncelYonetimKuruluViewModel> GuncelYonetimKuruluListele()
        {
            var viewModel = _guncelYonetimKuruluRepository.GetList().Select(x => new GuncelYonetimKuruluViewModel
            {
                Id = x.Id,
                Durum = x.Durum,
                GuncellemeTarihi = x.GuncellemeTarihi,
                SilindiMi = x.SilindiMi,
                OlusturulmaTarihi = x.OlusturulmaTarihi,
                Ad = x.Ad,
                GorevSuresi = x.GorevSuresi,
                Soyad = x.Soyad,
                Unvan = x.Unvan
            });


            return viewModel;
        }
        public GuncelYonetimKuruluViewModel GuncelYonetimKuruluGetir(int Id)
        {
            var model = _guncelYonetimKuruluRepository.Get(x => x.Id == Id);

            return new GuncelYonetimKuruluViewModel
            {
                Id = model.Id,
                Durum = model.Durum,
                GuncellemeTarihi = model.GuncellemeTarihi,
                SilindiMi = model.SilindiMi,
                OlusturulmaTarihi = model.OlusturulmaTarihi,
                Ad = model.Ad,
                GorevSuresi = model.GorevSuresi,
                Soyad = model.Soyad,
                Unvan = model.Unvan

            };

        }
        public void GuncelYonetimKuruluGuncelle(GuncelYonetimKuruluViewModel viewModel)
        {

            var model = _guncelYonetimKuruluRepository.Get(x => x.Id == viewModel.Id);


            model.Durum = viewModel.Durum;
            model.KisiId = viewModel.KisiId;
            model.Ad = viewModel.Ad;
            model.Soyad = viewModel.Soyad;
            model.Unvan = viewModel.Unvan;
            model.GorevSuresi = viewModel.GorevSuresi;

            if (viewModel.Fotograf != null)
            {
                var fotografUrl = JsonConvert.DeserializeObject<SlimDto>(viewModel.Fotograf);
                model.FotografUrl = fotografUrl.SaveAndGetFileName(Globals.DuyuruResim);
            }

            _guncelYonetimKuruluRepository.Update(model);

        }
        public void GuncelYonetimKuruluEkle(GuncelYonetimKuruluViewModel viewModel)
        {

            var fotografUrl = JsonConvert.DeserializeObject<SlimDto>(viewModel.Fotograf);

            _guncelYonetimKuruluRepository.Add(new GuncelYonetimKurulu
            {
                Durum = viewModel.Durum,
                KisiId = viewModel.KisiId,
                Ad = viewModel.Ad,
                Soyad = viewModel.Soyad,
                GorevSuresi = viewModel.GorevSuresi,
                Unvan = viewModel.Unvan,


            });

        }
        public void GuncelYonetimKuruluSil(int Id)
        {
            _guncelYonetimKuruluRepository.Delete(x => x.Id == Id);
        }
    }
}
