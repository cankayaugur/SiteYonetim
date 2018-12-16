using SenMuhendislerSitesi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.DAL.Mappings
{
    public class GaleriMap : BaseMap<Galeri>
    {
        public GaleriMap()
        {
            ToTable("Galeriler");

            Property(x => x.FotografUrl)
                .IsRequired();
            Property(x => x.Ad)
                .IsRequired();
        }
    }
}
