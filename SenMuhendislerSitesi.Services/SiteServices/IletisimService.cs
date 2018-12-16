using SenMuhendislerSitesi.DAL.Models;
using SenMuhendislerSitesi.DAL.Repository;
using SenMuhendislerSitesi.DAL.UnitOfWork;
using SenMuhendislerSitesi.Domain.ViewModels.SiteViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.Services.SiteServices
{
    public class IletisimService : BaseService
    {
        private readonly Repository<Iletisim> _iletisimRepository;
        public IletisimService(UnitOfWork uow) : base(uow)
        {
            _iletisimRepository = new Repository<Iletisim>(_uowBase);
        }

        public void IletisimEkle(IletisimViewModel viewModel)
        {
            _iletisimRepository.Add(new Iletisim
            {
                Durum = true,
                SilindiMi = false,
                Eposta = viewModel.Eposta,
                Konu = viewModel.Konu,
                Mesaj = viewModel.Mesaj,
                Telefon = viewModel.Telefon,
                OlusturulmaTarihi = DateTime.Now
                
            });
        }
    }
}
