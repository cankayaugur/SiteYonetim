using SenMuhendislerSitesi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.DAL.Mappings
{
    public class AidatMap : BaseMap<Aidat>
    {
        public AidatMap()
        {
            ToTable("Aidatlar");

            Property(x => x.Tutar)
                .IsRequired();
            Property(x => x.OdendiMi)
                .IsRequired();
            Property(x => x.DaireId)
                .IsRequired();
        }
    }
}
