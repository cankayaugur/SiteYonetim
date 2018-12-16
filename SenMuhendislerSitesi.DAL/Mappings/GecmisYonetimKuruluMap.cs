using SenMuhendislerSitesi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.DAL.Mappings
{
    public class GecmisYonetimKuruluMap : BaseMap<GecmisYonetimKurulu>
    {
        public GecmisYonetimKuruluMap()
        {
            ToTable("GecmisYonetimKurullari");

            Property(x => x.GorevSuresi)
                .IsRequired();
            Property(x => x.Ad)
                .IsRequired();
            Property(x => x.Soyad)
                .IsRequired();
            Property(x => x.Unvan)
                .IsRequired();
        }
    }
}
