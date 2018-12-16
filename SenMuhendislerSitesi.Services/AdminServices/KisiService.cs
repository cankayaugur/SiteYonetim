using SenMuhendislerSitesi.DAL.Models;
using SenMuhendislerSitesi.DAL.Repository;
using SenMuhendislerSitesi.DAL.UnitOfWork;
using SenMuhendislerSitesi.Domain.DTOS;
using SenMuhendislerSitesi.Domain.ViewModels.AdminViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.Services.AdminServices
{
    public class KisiService : BaseService
    {
        private readonly Repository<Kisi> _kisiRepository;
        public KisiService(UnitOfWork uow) : base(uow)
        {
            _kisiRepository = new Repository<Kisi>(_uowBase);
        }

        public KisiViewModel Getir(KisiViewModel viewModel)
        {
            var model = _kisiRepository.Get(x => x.KullaniciAdi == viewModel.KullaniciAdi && x.Sifre == viewModel.Sifre);

            if (model != null)
            {
                return new KisiViewModel
                {
                    Id = model.Id,
                    Durum = model.Durum,
                    KullaniciAdi = model.KullaniciAdi,
                    GuncellemeTarihi = model.GuncellemeTarihi,
                    OlusturulmaTarihi = model.OlusturulmaTarihi,
                    Sifre = model.Sifre,
                    Ad = model.Ad,
                    Cinsiyet = model.Cinsiyet,
                    DogumTarihi = model.DogumTarihi,
                    Eposta = model.Eposta,
                    KisiTur = model.KisiTur,
                    OdendiMi = model.OdendiMi,
                    Soyad = model.Soyad,
                    Ucret = model.Ucret,
                    Bina = model.Bina
                    
                };
            }
            else
            {
                return new KisiViewModel();
            }


        }

        public KisiViewModel IdGetir(int Id)
        {
            var model = _kisiRepository.Get(x => x.Id == Id);

            if (model != null)
            {
                return new KisiViewModel
                {
                    Id = model.Id,
                    Durum = model.Durum,
                    GuncellemeTarihi = model.GuncellemeTarihi,
                    OlusturulmaTarihi = model.OlusturulmaTarihi,
                    SilindiMi = model.SilindiMi,
                };
            }
            else
            {
                return new KisiViewModel();
            }

        }
        public IQueryable<KisiViewModel> Listele()
        {
            var viewModel = _kisiRepository.GetList().Select(x => new KisiViewModel  
            {
                Durum = x.Durum,                                
                KullaniciAdi = x.KullaniciAdi,                  
                GuncellemeTarihi = x.GuncellemeTarihi,          
                Id = x.Id,                                      
                OlusturulmaTarihi = x.OlusturulmaTarihi,        
                Sifre = x.Sifre,                                
                SilindiMi = x.SilindiMi ,
                Ad = x.Ad,
                Cinsiyet = x.Cinsiyet,
                DogumTarihi = x.DogumTarihi,
                Eposta = x.Eposta,
                KisiTur = x.KisiTur,
                OdendiMi = x.OdendiMi,
                Soyad =x.Soyad,
                Ucret = x.Ucret,
                Bina = x.Bina
            });

            return viewModel;
        }

        public void Ekle(KisiViewModel viewModel)
        {
            //var fotografUrl = JsonConvert.DeserializeObject<SlimDto>(viewModel.Fotograf);
            _kisiRepository.Add(new Kisi
            {
                Ad = viewModel.Ad,
                Cinsiyet = viewModel.Cinsiyet,
                DogumTarihi = viewModel.DogumTarihi,
                Durum = viewModel.Durum,
                Eposta = viewModel.Eposta,
                OlusturulmaTarihi = DateTime.Now,
                SilindiMi = false,
                KisiTur = viewModel.KisiTur,
                Soyad = viewModel.Soyad,
                OdendiMi = viewModel.OdendiMi,
                Ucret = viewModel.Ucret,
                Bina = viewModel.Bina
                
            });
        }

        public void Sil(int id)
        {
            _kisiRepository.Delete(x => x.Id == id);

        }

        public void Guncelle(KisiViewModel viewModel)
        {
            var model = _kisiRepository.Get(x => x.Id == viewModel.Id);

            model.Eposta = viewModel.Eposta;
            model.Durum = viewModel.Durum;
            model.GuncellemeTarihi = DateTime.Now;
            model.Ad = viewModel.Ad;
            model.Soyad = viewModel.Soyad;
            model.SilindiMi = viewModel.SilindiMi;
            model.KisiTur= viewModel.KisiTur;
            model.Sifre = viewModel.Sifre;
            model.OdendiMi = viewModel.OdendiMi;
            model.Ucret = viewModel.Ucret;
            model.Bina = viewModel.Bina;
            


            //if (viewModel.Fotograf != null)
            //{

            //    var fotografUrl = JsonConvert.DeserializeObject<SlimDto>(viewModel.Fotograf);

            //}

            _kisiRepository.Update(model);
        }




    }
}

