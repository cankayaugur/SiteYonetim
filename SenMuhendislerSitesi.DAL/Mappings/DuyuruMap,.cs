using SenMuhendislerSitesi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.DAL.Mappings
{
  public  class DuyuruMap : BaseMap<Duyuru>
    {
        public DuyuruMap()
        {
            ToTable("Duyurular");

            Property(x => x.Baslik)
                .IsRequired()
                .HasMaxLength(300);
            Property(x => x.DuyuruTarihi)
                .IsRequired();
            Property(x => x.FotografUrl)
                .IsOptional();
            Property(x => x.Icerik)
                .IsRequired()
                .HasMaxLength(100000);
            Property(x => x.AltBaslik)
                .IsOptional();
        }
    }
}
