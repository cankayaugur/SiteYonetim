using SenMuhendislerSitesi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.DAL.Mappings
{
    public class BaseMap<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : BaseModel
    {
        public BaseMap()
        {
            Property(x => x.Id)
                .IsRequired();

            Property(x => x.Durum)
                .IsRequired();

            Property(x => x.GuncellemeTarihi)
                .IsOptional();

            Property(x => x.SilindiMi)
                .IsRequired();

            Property(x => x.OlusturulmaTarihi)
                .IsRequired();
        }
    }
}
