using SenMuhendislerSitesi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.DAL.Mappings
{
    public class GuncelYonetimKuruluMap : BaseMap<GuncelYonetimKurulu>
    {
        public GuncelYonetimKuruluMap()
        {
            ToTable("GuncelYonetimKurullari");

            Property(x => x.Ad)
                .IsRequired();
            Property(x => x.Soyad)
                .IsRequired();
            Property(x => x.FotografUrl)
                .IsOptional();
            Property(x => x.GorevSuresi)
                .IsRequired();
            Property(x => x.Unvan)
                .IsRequired();
        }
    }
}
