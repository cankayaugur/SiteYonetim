using SenMuhendislerSitesi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.DAL.Mappings
{
    public class DaireMap : BaseMap<Daire>
    {
        public DaireMap()
        {
            ToTable("Daireler");

            Property(x => x.ApartmanId)
                .IsRequired();
            Property(x => x.KisiId)
                .IsRequired();
        }
    }
}
