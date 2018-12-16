using SenMuhendislerSitesi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.DAL.Mappings
{
    public class IletisimMap : BaseMap<Iletisim>
    {
        public IletisimMap()
        {
            ToTable("Iletisim");

            Property(x => x.Konu)
                .IsRequired()
                .HasMaxLength(300);

            Property(x => x.Telefon)
                .IsOptional()
                .HasMaxLength(15);

            Property(x => x.Eposta)
                .IsOptional()
                .HasMaxLength(100);

            Property(x => x.Mesaj)
                .IsRequired()
                .HasMaxLength(4000);

        }
    }
}
