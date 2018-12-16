namespace SenMuhendislerSitesi.DAL.Migrations
{
    using SenMuhendislerSitesi.DAL.Models;
    using SenMuhendislerSitesi.Domain.Enums;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SenMuhendislerSitesi.DAL.Context.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SenMuhendislerSitesi.DAL.Context.ApplicationContext context)
        {
            KisiSeed(context);
            DuyuruSeed(context);
            ApartmanSeed(context);
            DaireSeed(context);
            AidatSeed(context);
            GaleriSeed(context);
            YonetimKuruluSeed(context);
            IletisimSeed(context);
            HakkimizdaSeed(context);
            GuncelYonetimKuruluSeed(context);
            GecmisYonetimKuruluSeed(context);
            AdresSeed(context);
        }

        public void KisiSeed(Context.ApplicationContext _context)
        {
            for (int i = 1; i < 10; i++)
            {
                _context.Kisiler.AddOrUpdate(x => x.Id, new Kisi
                {
                    Id = i,
                    Ad = $"ejder",
                    ApartmanNo = "i",
                    Cinsiyet = Cinsiyet.belirsiz,
                    DogumTarihi = new DateTime(1990, 08, 05),
                    Durum = true,
                    Eposta = $"Eposta {i}",
                    KapiNo = $"kapi{i}",
                    KisiTur = KisiTur.EvSahibi,
                    KullaniciAdi = "Sen",
                    Sifre = "123",
                    OlusturulmaTarihi = DateTime.Now,
                    SilindiMi = false,
                    Soyad = "turgut",
                    Telefon = "01234",
                    OdendiMi = true,
                    Ucret = 200,
                    Bina = Bina.DorduncuBlok

                });
            }
            _context.SaveChanges();

        }
        public void DuyuruSeed(Context.ApplicationContext _context)
        {
            for (int i = 1; i < 10; i++)
            {
                _context.Duyurular.AddOrUpdate(x => x.Id, new Duyuru
                {
                    Baslik = $"baslik{i}",
                    SilindiMi = false,
                    OlusturulmaTarihi = DateTime.Now,
                    Durum = true,
                    DuyuruTarihi = DateTime.Now,
                    FotografUrl = $"url {i}",
                    Icerik = "selam selam selam selam sleam",
                    Id = i,
                    KisiId = i,
                    AltBaslik = $"altbaslik{i}"

                });
                _context.SaveChanges();
            }

        }
        public void ApartmanSeed(Context.ApplicationContext _context)
        {
            for (int i = 1; i < 10; i++)
            {
                _context.Apartmanlar.AddOrUpdate(x => x.Id, new Apartman
                {
                    ApartmanNo = "i",
                    Durum = true,
                    Id = i,
                    OlusturulmaTarihi = DateTime.Now,
                    SilindiMi = false,


                });
            }
            _context.SaveChanges();

        }
        public void DaireSeed(Context.ApplicationContext _context)
        {
            for (int i = 1; i < 10; i++)
            {
                _context.Daireler.AddOrUpdate(x => x.Id, new Daire
                {
                    Id = i,
                    KisiId = i,
                    SilindiMi = false,
                    OlusturulmaTarihi = DateTime.Now,
                    ApartmanId = i,
                    DaireNo = "i",
                    Durum = true,


                });
                _context.SaveChanges();
            }
        }
        public void AidatSeed(Context.ApplicationContext _context)
        {
            for (int i = 1; i < 10; i++)
            {
                _context.Aidatlar.AddOrUpdate(x => x.Id, new Aidat
                {
                    DaireId = i,
                    Durum = true,
                    Id = i,
                    OdendiMi = true,
                    OlusturulmaTarihi = DateTime.Now,
                    SilindiMi = false,
                    Tutar = 5,

                });
            }
            _context.SaveChanges();


        }
        public void GaleriSeed(Context.ApplicationContext _context)
        {
            for (int i = 1; i < 10; i++)
            {
                _context.Galeriler.AddOrUpdate(x => x.Id, new Galeri
                {
                    Ad = $"Fotoğraf {i}",
                    Durum = true,
                    FotografUrl = "url",
                    Id = i,
                    OlusturulmaTarihi = DateTime.Now,
                    SilindiMi = false
                });
            }
            _context.SaveChanges();
        }
        public void YonetimKuruluSeed(Context.ApplicationContext _context)
        {
            for (int i = 1; i < 10; i++)
            {
                _context.Yonetimler.AddOrUpdate(x => x.Id, new YonetimKurulu
                {
                    Ad = "yonetim",
                    Id = i,
                    Durum = true,
                    //FotografUrl = "a",
                    GorevSuresi = "1",
                    OlusturulmaTarihi = DateTime.Now,
                    SilindiMi = false,
                    Soyad = "soyad",
                    KisiId = i
                });
            }
            _context.SaveChanges();
        }
        public void IletisimSeed(Context.ApplicationContext _context)
        {
            _context.Iletisim.AddOrUpdate(x => x.Id, new Iletisim
            {
                Durum = true,
                Eposta = $"Eposta",
                Id = 1,
                Konu = "konu",
                Mesaj = "mesaj",
                OlusturulmaTarihi = DateTime.Now,
                SilindiMi = false,
                Telefon = "123"
            });
            _context.SaveChanges();
        }
        public void HakkimizdaSeed(Context.ApplicationContext _context)
        {
            _context.Hakkimizda.AddOrUpdate(x => x.Id, new Hakkimizda
            {
                Baslik = $"Baslik",
                Icerik = $"İcerik",
                Durum = true,
                Id = 1,
                OlusturulmaTarihi = DateTime.Now,
                SilindiMi = false
            });
            _context.SaveChanges();
        }
        public void GecmisYonetimKuruluSeed(Context.ApplicationContext _context)
        {
            for (int i = 1; i < 5; i++)
            {
                _context.GecmisYonetimKurulu.AddOrUpdate(x => x.Id, new GecmisYonetimKurulu
                {
                    Ad = "Gecmis yonetim",
                    Id = i,
                    Durum = true,
                    //FotografUrl = "a",
                    GorevSuresi = "1",
                    OlusturulmaTarihi = DateTime.Now,
                    SilindiMi = false,
                    Soyad = "soyad",
                    KisiId = i,
                    Unvan = Unvan.Denetici,
                });
            }
            _context.SaveChanges();
        }
        public void GuncelYonetimKuruluSeed(Context.ApplicationContext _context)
        {
            for (int i = 1; i < 8; i++)
            {
                _context.GuncelYonetimKurulu.AddOrUpdate(x => x.Id, new GuncelYonetimKurulu
                {
                    Ad = "Nuri",
                    Id = i,
                    Durum = true,
                    FotografUrl = "FotografUrl",
                    GorevSuresi = "2016-...",
                    OlusturulmaTarihi = DateTime.Now,
                    SilindiMi = false,
                    Soyad = "Cindoruk",
                    KisiId = i,
                    Unvan = i % 7 == 1? Unvan.Baskan : Unvan.BaskanYardimcisi

                });
            }
            _context.SaveChanges();
        }
        public void AdresSeed(Context.ApplicationContext _context)
        {
            _context.Adresler.AddOrUpdate(x => x.Id, new Adres
            {
                Id = 1,
                AcikAdres = "1821.Cadde 1820.Sokak Şen Mühendisler Sitesi ( Royal Düğün Salonu Karşısı)",
                Avm = "Atlantis Alışveriş Merkezi",
                Benzinlik = "Shell",
                Carsi = "İpekYolu Çarşısı",
                Durum = true,
                Mahalle = "Ergazi Mahallesi",
                Okul = "Ahmet Hamdi Tanpınar İ.Ö.O.",
                OtobusDuragi = "296 Ergazi Otobüs Durağı",
                SilindiMi = false,
                OlusturulmaTarihi = DateTime.Now,
            });
            _context.SaveChanges();
        }
    }
}

