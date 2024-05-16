using ErenDenizEF.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErenDenizEF.Enums;

namespace ErenDenizEF.Configurations
{
    internal class Album_CFG : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.ToTable("ALBUMLER");

            builder.Property(x => x.AlbumId)
                .HasColumnName("ALBUM_ID");

            builder.Property(x => x.AlbumAdi)
             .HasColumnName("ALBUM_ADI")
             .HasMaxLength(200)
             .IsRequired();

            builder.Property(x => x.CikisTarihi)
             .HasColumnName("CIKIS_TARIHI")
             .IsRequired()
             .HasDefaultValue(DateTime.Now);

            builder.Property(x => x.Fiyat)
             .HasColumnName("FIYAT")
             .IsRequired(true);

            builder.Property(x => x.IndirimOrani)
             .HasColumnName("INDIRIM_ORANI")
             .IsRequired(true)
             .HasDefaultValue(0);

            builder.Property(x => x.AlbumDurumu)
             .HasColumnName("ALBUM_DURUMU")
             .IsRequired(true)
             .HasDefaultValue(AlbumDurumu.Aktif);

            builder.Property(x => x.SanatciId)
             .HasColumnName("SANATCI_ID")
             .IsRequired(true);

            builder.HasData(new Album { AlbumId = 1, AlbumAdi = "The Wall", CikisTarihi = DateTime.Today, Fiyat = 50, SanatciId = 1 });
            builder.HasData(new Album { AlbumId = 2, AlbumAdi = "Use Your Illısıon-1", CikisTarihi = DateTime.Today, Fiyat = 35, SanatciId = 2 });
        }
    }
}
