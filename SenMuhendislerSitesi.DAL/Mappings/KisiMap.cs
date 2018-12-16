using SenMuhendislerSitesi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.DAL.Mappings
{
    public class KisiMap : BaseMap<Kisi>
    {
        public KisiMap()
        {
            ToTable("Kişiler");

            Property(x => x.Ad)
                .IsRequired()
                .HasMaxLength(25);
            Property(x => x.Soyad)
                .IsRequired()
                .HasMaxLength(30);

            Property(x => x.KullaniciAdi)
                .IsRequired()
                .HasMaxLength(25);
            Property(x => x.Sifre)
                .IsRequired()
                .HasMaxLength(15);
            Property(x => x.Telefon)
                .IsOptional()
                .HasMaxLength(12);
            Property(x => x.KapiNo)
                .IsRequired()
                .HasMaxLength(10);
            Property(x => x.ApartmanNo)
                .IsRequired()
                .HasMaxLength(10);
            Property(x => x.KisiTur)
                .IsRequired();
            Property(x => x.Cinsiyet)
                .IsRequired();
            Property(x => x.DogumTarihi)
                .IsOptional();
            Property(x => x.OdendiMi)
                .IsRequired();
            Property(x => x.Ucret)
                .IsRequired();
            Property(x => x.Bina)
                .IsRequired();

        }
    }
}
