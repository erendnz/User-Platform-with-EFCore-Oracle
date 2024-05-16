using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErenDenizEF.Models;

namespace ErenDenizEF.Configurations
{
    internal class Admin_CFG : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("ADMINLER");

            builder.Property(x => x.AdminID)
                .HasColumnName("ADMIN_ID");

            builder.Property(x => x.Ad)
             .HasColumnName("ADMIN_ADI")
             .HasMaxLength(200)
             .IsRequired();

            builder.Property(x => x.Soyad)
             .HasColumnName("ADMIN_SOYADI")
             .HasMaxLength(200)
             .IsRequired();

            builder.Property(x => x.KullaniciAdi)
             .HasColumnName("KULLANICI_ADI")
             .HasMaxLength(20)
             .IsRequired(true);

            builder.Property(x => x.Sifre)
            .HasColumnName("SIFRE")
            .HasMaxLength(100)
            .IsRequired(true);

            builder.HasData(new Admin { AdminID = 1, Ad = "Eren", Soyad = "Kilic", KullaniciAdi = "erendnz", Sifre = Utilities.SifreUtility.sha256_hash("erendeniz11") });
        }
    }
}
