using SenMuhendislerSitesi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.DAL.Mappings
{
    public class YonetimKuruluMap : BaseMap<YonetimKurulu>
    {
        public YonetimKuruluMap()
        {
            ToTable("Yonetimler");

            Property(x => x.Ad)
                .IsRequired();
            Property(x => x.Soyad)
                .IsRequired();
            //Property(x => x.FotografUrl)
            //    .IsRequired();
            Property(x => x.GorevSuresi)
                .IsRequired();
            
        }
    }
}
