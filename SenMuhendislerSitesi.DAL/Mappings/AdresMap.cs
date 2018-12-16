using SenMuhendislerSitesi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.DAL.Mappings
{
    public class AdresMap : BaseMap<Adres>
    {
        public AdresMap()
        {
            ToTable("Adresler");

            Property(x => x.Avm)
                .IsOptional();
            Property(x => x.AcikAdres)
                .IsRequired();
            Property(x => x.Benzinlik)
                .IsOptional();
            Property(x => x.Carsi)
                .IsOptional();
            Property(x => x.OtobusDuragi)
                .IsOptional();
            Property(x => x.Okul)
                .IsOptional();
            Property(x => x.Mahalle)
                .IsRequired();
          
        }
    }
}
