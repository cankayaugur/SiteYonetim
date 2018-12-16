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
    public class DuyuruService : BaseService
    {
        public readonly Repository<Duyuru> _duyuruRepository;
        public DuyuruService(UnitOfWork uow) : base(uow)
        {
            _duyuruRepository = new Repository<Duyuru>(_uowBase);
        }
        public IQueryable<DuyuruViewModel> DuyuruListele()
        {
            var viewModel = _duyuruRepository.GetList().Select(x => new DuyuruViewModel
            {
                Id = x.Id,
                Baslik = x.Baslik,
                Durum = x.Durum,
                FotografUrl = x.FotografUrl,
                GuncellemeTarihi = x.GuncellemeTarihi,
                Icerik = x.Icerik,
                SilindiMi = x.SilindiMi,
                DuyuruTarihi = x.DuyuruTarihi,
                OlusturulmaTarihi = x.OlusturulmaTarihi,
                AltBaslik = x.AltBaslik,
            });


            return viewModel;
        }
        public DuyuruViewModel DuyuruGetir(int Id)
        {
            var model = _duyuruRepository.Get(x => x.Id == Id);

            return new DuyuruViewModel
            {
                Id = model.Id,
                Baslik = model.Baslik,
                Durum = model.Durum,
                FotografUrl = model.FotografUrl,
                GuncellemeTarihi = model.GuncellemeTarihi,
                Icerik = model.Icerik,
                SilindiMi = model.SilindiMi,
                DuyuruTarihi = model.DuyuruTarihi,
                OlusturulmaTarihi = model.OlusturulmaTarihi,
                AltBaslik = model.AltBaslik,
                
            };

        }
        public void DuyuruGuncelle(DuyuruViewModel viewModel)
        {
            
            var model = _duyuruRepository.Get(x => x.Id == viewModel.Id);

           
            model.Baslik = viewModel.Baslik;
            model.Durum = viewModel.Durum;
            model.Icerik = viewModel.Icerik;
            model.KisiId = viewModel.KisiId;
            model.DuyuruTarihi = viewModel.DuyuruTarihi;
            model.AltBaslik = viewModel.AltBaslik;

            if (viewModel.Fotograf != null)
            {
                var fotografUrl = JsonConvert.DeserializeObject<SlimDto>(viewModel.Fotograf); 
                model.FotografUrl = fotografUrl.SaveAndGetFileName(Globals.DuyuruResim); 
            }

            _duyuruRepository.Update(model);

        }
        public void DuyuruEkle(DuyuruViewModel viewModel)
        {

            var fotografUrl = JsonConvert.DeserializeObject<SlimDto>(viewModel.Fotograf);

            //viewModel.FotografUrl = fotografUrl.SaveAndGetFileName(Globals.DuyuruResim); // sill olmazsa


            _duyuruRepository.Add(new Duyuru
            {
                Baslik = viewModel.Baslik,
                Durum = viewModel.Durum,
                FotografUrl = fotografUrl.SaveAndGetFileName(Globals.DuyuruResim),
                Icerik = viewModel.Icerik,
                KisiId = viewModel.KisiId,
                DuyuruTarihi = viewModel.DuyuruTarihi,
                AltBaslik = viewModel.AltBaslik,
            });

        }
        public void DuyuruSil(int Id)
        {
            _duyuruRepository.Delete(x => x.Id == Id);
        }

    }
}
