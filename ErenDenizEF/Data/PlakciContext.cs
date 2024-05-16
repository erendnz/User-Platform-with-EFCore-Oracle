using ErenDenizEF.Configurations;
using ErenDenizEF.Enums;
using ErenDenizEF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErenDenizEF.Data
{
    // PlakciContext sınıfı, Entity Framework DbContext sınıfından türetilmiş ve veritabanı bağlantısını yöneten sınıftır.
    internal class PlakciContext : DbContext
    {
        public PlakciContext()
        {

        }

        public PlakciContext(DbContextOptions<PlakciContext> options) : base(options)
        {

        }

        public DbSet<Album> Albumler { get; set; }
        public DbSet<Sanatci> Sanatcilar { get; set; }
        public DbSet<Admin> Adminler { get; set; }

       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // Oracle veritabanı bağlantısı için gerekli bağlantı bilgileri tanımlanmıştır.
            optionsBuilder.UseOracle("User Id=plakci;Password=plakci;Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=127.0.0.1)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SID=orcl)))");
        }

        // Fluent API ile model konfigürasyonlarını uygulayan metot. Her bir model için ayrı ayrı konfigürasyon sınıfları kullanılmıştır.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new Album_CFG());
            modelBuilder.ApplyConfiguration(new Admin_CFG());
            modelBuilder.ApplyConfiguration(new Sanatci_CFG());
        }
    }
}
