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
        public void GaleriGuncelle(GaleriViewModel viewModel)
        {

            var model = _galeriRepository.Get(x => x.Id == viewModel.Id);


            model.Durum = viewModel.Durum;
            model.Ad = viewModel.Ad;

            if (viewModel.Fotograf != null)
            {
                var fotografUrl = JsonConvert.DeserializeObject<SlimDto>(viewModel.Fotograf);
                model.FotografUrl = fotografUrl.SaveAndGetFileName(Globals.DuyuruResim);
            }

            _galeriRepository.Update(model);

        }
        public void GaleriEkle(GaleriViewModel viewModel)
        {

            var fotografUrl = JsonConvert.DeserializeObject<SlimDto>(viewModel.Fotograf);

            //viewModel.FotografUrl = fotografUrl.SaveAndGetFileName(Globals.DuyuruResim); // sill olmazsa


            _galeriRepository.Add(new Galeri
            {
                Durum = viewModel.Durum,
                FotografUrl = fotografUrl.SaveAndGetFileName(Globals.DuyuruResim),
                Ad = viewModel.Ad,
                
                
            });

        }
        public void GaleriSil(int Id)
        {
            _galeriRepository.Delete(x => x.Id == Id);
        }
    }
}
