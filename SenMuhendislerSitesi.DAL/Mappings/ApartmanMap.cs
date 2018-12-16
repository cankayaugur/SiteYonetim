using SenMuhendislerSitesi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.DAL.Mappings
{
    public class ApartmanMap : BaseMap<Apartman>
    {
        public ApartmanMap()
        {
            ToTable("Apartmanlar");

            Property(x => x.ApartmanNo)
                .IsRequired();

           
        }

    }
}
