using SenMuhendislerSitesi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.DAL.Models
{
    public class Kisi : BaseModel
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string KapiNo { get; set; }
        public string ApartmanNo { get; set; }
        public string Telefon { get; set; }
        public string Eposta { get; set; }
        public Cinsiyet Cinsiyet { get; set; }
        public KisiTur KisiTur { get; set; }
        public Bina Bina{ get; set; }
        public decimal Ucret { get; set; }
        public bool  OdendiMi { get; set; }


        public List<Daire> Daireler { get; set; }
        public List<Duyuru> Duyurular { get; set; }
        public List<YonetimKurulu> YonetimKurullari { get; set; }
    }
}
