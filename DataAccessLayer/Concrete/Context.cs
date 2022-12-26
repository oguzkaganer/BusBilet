using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=DBBusBilet;Trusted_Connection=true");
        }

        public DbSet<Firma> firmalar { get; set; }
        public DbSet<Guzergah> guzergahlar { get; set; }
        public DbSet<Otobus> otobusler { get; set; }
        public DbSet<Kullanici> kullanicilar { get; set; }
        public DbSet<GuzergahOtobus> guzergahOtobusler { get; set; }
        public DbSet<GuzergahOtobusKullanici> guzergahOtobusKullaniciler { get; set; }


    }
}
