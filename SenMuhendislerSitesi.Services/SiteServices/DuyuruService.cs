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
    public class DuyuruService : BaseService
    {
        private readonly Repository<Duyuru> _duyuruRepository;
        public DuyuruService(UnitOfWork uow) : base(uow)
        {
            _duyuruRepository = new Repository<Duyuru>(_uowBase);
        }

        public IQueryable<DuyuruViewModel> DuyuruListele()
        {
            var viewModel = _duyuruRepository.GetList(null, x => x.Id).Select(x => new DuyuruViewModel
            {
                Id = x.Id,
                Baslik = x.Baslik,
                Durum = x.Durum,
                DuyuruTarihi = x.DuyuruTarihi,
                FotografUrl = x.FotografUrl,
                Icerik = x.Icerik,
                OlusturulmaTarihi = x.OlusturulmaTarihi,
                SilindiMi = x.SilindiMi,
                GuncellemeTarihi = x.GuncellemeTarihi
            });
            return viewModel;
        }
        public DuyuruViewModel DuyuruGetir(int Id)
        {
            Duyuru model = _duyuruRepository.Get(x => x.Id == Id);

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
            };
        }
    }
}
