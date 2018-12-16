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
    public class GecmisYonetimKuruluService : BaseService
    {
        public readonly Repository<GecmisYonetimKurulu> _gecmisYonetimKuruluRepository;
        public GecmisYonetimKuruluService(UnitOfWork uow) : base(uow)
        {
            _gecmisYonetimKuruluRepository = new Repository<GecmisYonetimKurulu>(_uowBase);
        }
        public IQueryable<GecmisYonetimKuruluViewModel> GecmisYonetimKuruluListele()
        {
            var viewModel = _gecmisYonetimKuruluRepository.GetList().Select(x => new GecmisYonetimKuruluViewModel
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
        public GecmisYonetimKuruluViewModel GecmisYonetimKuruluGetir(int Id)
        {
            var model = _gecmisYonetimKuruluRepository.Get(x => x.Id == Id);

            return new GecmisYonetimKuruluViewModel
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
        public void GecmisYonetimKuruluGuncelle(GecmisYonetimKuruluViewModel viewModel)
        {

            var model = _gecmisYonetimKuruluRepository.Get(x => x.Id == viewModel.Id);


            model.Durum = viewModel.Durum;
            model.KisiId = viewModel.KisiId;
            model.Ad = viewModel.Ad;
            model.Soyad = viewModel.Soyad;
            model.Unvan = viewModel.Unvan;
            model.GorevSuresi = viewModel.GorevSuresi;


            //if (viewModel.Fotograf != null)
            //{
            //    var fotografUrl = JsonConvert.DeserializeObject<SlimDto>(viewModel.Fotograf);
            //    model.FotografUrl = fotografUrl.SaveAndGetFileName(Globals.DuyuruResim);
            //}

            _gecmisYonetimKuruluRepository.Update(model);

        }
        public void GecmisYonetimKuruluEkle(GecmisYonetimKuruluViewModel viewModel)
        {

            //var fotografUrl = JsonConvert.DeserializeObject<SlimDto>(viewModel.Fotograf);

            _gecmisYonetimKuruluRepository.Add(new GecmisYonetimKurulu
            {
                Durum = viewModel.Durum,
                KisiId = viewModel.KisiId,
                Ad = viewModel.Ad,
                Soyad = viewModel.Soyad,
                GorevSuresi = viewModel.GorevSuresi,
                Unvan = viewModel.Unvan,
                
                
            });

        }
        public void GecmisYonetimKuruluSil(int Id)
        {
            _gecmisYonetimKuruluRepository.Delete(x => x.Id == Id);
        }
    }
}
