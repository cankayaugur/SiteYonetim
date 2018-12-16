using SenMuhendislerSitesi.DAL.Mappings;
using SenMuhendislerSitesi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenMuhendislerSitesi.DAL.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("myConnectionString")
        {

        }

        public DbSet<Kisi> Kisiler { get; set; }
        public DbSet<Aidat> Aidatlar { get; set; }
        public DbSet<Iletisim> Iletisim { get; set; }
        public DbSet<Duyuru> Duyurular { get; set; }
        public DbSet<Apartman> Apartmanlar { get; set; }
        public DbSet<Daire> Daireler { get; set; }
        public DbSet<Galeri> Galeriler { get; set; }
        public DbSet<YonetimKurulu> Yonetimler { get; set; }
        public DbSet<Hakkimizda> Hakkimizda { get; set; }
        public DbSet<GuncelYonetimKurulu> GuncelYonetimKurulu { get; set; }
        public DbSet<GecmisYonetimKurulu> GecmisYonetimKurulu { get; set; }
        public DbSet<Adres> Adresler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new KisiMap());
            modelBuilder.Configurations.Add(new DuyuruMap());
            modelBuilder.Configurations.Add(new ApartmanMap());
            modelBuilder.Configurations.Add(new DaireMap());
            modelBuilder.Configurations.Add(new IletisimMap());
            modelBuilder.Configurations.Add(new AidatMap());
            modelBuilder.Configurations.Add(new GaleriMap());
            modelBuilder.Configurations.Add(new YonetimKuruluMap());
            modelBuilder.Configurations.Add(new HakkimizdaMap());
            modelBuilder.Configurations.Add(new GecmisYonetimKuruluMap());
            modelBuilder.Configurations.Add(new GuncelYonetimKuruluMap());
            modelBuilder.Configurations.Add(new AdresMap());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {


            var entities =
               ChangeTracker.Entries()
                   .Where(x => x.Entity is BaseModel && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        ((BaseModel)entity.Entity).OlusturulmaTarihi = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        ((BaseModel)entity.Entity).GuncellemeTarihi = DateTime.Now;
                        break;
                }

            }
            return base.SaveChanges();
        }
    }
}
