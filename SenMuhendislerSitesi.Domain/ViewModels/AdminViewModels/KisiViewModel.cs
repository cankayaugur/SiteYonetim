using SenMuhendislerSitesi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.Domain.ViewModels.AdminViewModels
{
    public class KisiViewModel : BaseViewModel
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Eposta { get; set; }
        public Cinsiyet Cinsiyet { get; set; }
        public KisiTur KisiTur{ get; set; }
        public Bina Bina { get; set; }
        public DateTime DogumTarihi { get; set; }


        public bool OdendiMi { get; set; }
        public decimal Ucret { get; set; }

    }
}
