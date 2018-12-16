using SenMuhendislerSitesi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.DAL.Mappings
{
    public class HakkimizdaMap : BaseMap<Hakkimizda>
    {
        public HakkimizdaMap()
        {
            ToTable("Hakkimizda");

            Property(x => x.Baslik)
                .IsRequired();
            Property(x => x.Icerik)
                .IsRequired();
        }
    }
}
