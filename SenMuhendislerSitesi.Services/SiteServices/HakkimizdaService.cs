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
    public class HakkimizdaService : BaseService
    {
        private readonly Repository<Hakkimizda> _hakkimizdaRepository;
        public HakkimizdaService(UnitOfWork uow) : base(uow)
        {
            _hakkimizdaRepository = new Repository<Hakkimizda>(_uowBase);
        }


        public HakkimizdaViewModel Hakkimizda()
        {
            var model = _hakkimizdaRepository.Get(x => x.Id == 1);

            HakkimizdaViewModel hakkimizdaViewModel = new HakkimizdaViewModel
            {
                Id = model.Id,
                Baslik = model.Baslik,
                Durum = model.Durum,
                GuncellemeTarihi = model.GuncellemeTarihi,
                Icerik = model.Icerik,
                OlusturulmaTarihi = model.OlusturulmaTarihi,
                SilindiMi = model.SilindiMi,
            };



            return hakkimizdaViewModel;
        }
    }
}
