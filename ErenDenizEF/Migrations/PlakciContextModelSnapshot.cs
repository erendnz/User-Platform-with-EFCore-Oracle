﻿// <auto-generated />
using System;
using ErenDenizEF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace ErenDenizEF.Migrations
{
    [DbContext(typeof(PlakciContext))]
    partial class PlakciContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ErenDenizEF.Models.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("ADMIN_ID");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminID"), 1L, 1);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)")
                        .HasColumnName("ADMIN_ADI");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR2(20)")
                        .HasColumnName("KULLANICI_ADI");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)")
                        .HasColumnName("SIFRE");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)")
                        .HasColumnName("ADMIN_SOYADI");

                    b.HasKey("AdminID");

                    b.ToTable("ADMINLER", (string)null);

                    b.HasData(
                        new
                        {
                            AdminID = 1,
                            Ad = "Eren",
                            KullaniciAdi = "erendnz",
                            Sifre = "B22F18A5A24EAA5E0A6673DDE1D64DC4C0A7595C4B263F947426736A59D1ED20",
                            Soyad = "Kilic"
                        });
                });

            modelBuilder.Entity("ErenDenizEF.Models.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("ALBUM_ID");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlbumId"), 1L, 1);

                    b.Property<string>("AlbumAdi")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)")
                        .HasColumnName("ALBUM_ADI");

                    b.Property<int>("AlbumDurumu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasDefaultValue(1)
                        .HasColumnName("ALBUM_DURUMU");

                    b.Property<DateTime>("CikisTarihi")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("CIKIS_TARIHI");

                    b.Property<double>("Fiyat")
                        .HasColumnType("BINARY_DOUBLE")
                        .HasColumnName("FIYAT");

                    b.Property<double>("IndirimOrani")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BINARY_DOUBLE")
                        .HasDefaultValue(0.0)
                        .HasColumnName("INDIRIM_ORANI");

                    b.Property<int>("SanatciId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("SANATCI_ID");

                    b.HasKey("AlbumId");

                    b.HasIndex("SanatciId");

                    b.ToTable("ALBUMLER", (string)null);

                    b.HasData(
                        new
                        {
                            AlbumId = 1,
                            AlbumAdi = "The Wall",
                            AlbumDurumu = 0,
                            CikisTarihi = new DateTime(2023, 11, 13, 0, 0, 0, 0, DateTimeKind.Local),
                            Fiyat = 50.0,
                            IndirimOrani = 0.0,
                            SanatciId = 1
                        },
                        new
                        {
                            AlbumId = 2,
                            AlbumAdi = "Use Your Illısıon-1",
                            AlbumDurumu = 0,
                            CikisTarihi = new DateTime(2023, 11, 13, 0, 0, 0, 0, DateTimeKind.Local),
                            Fiyat = 35.0,
                            IndirimOrani = 0.0,
                            SanatciId = 2
                        });
                });

            modelBuilder.Entity("ErenDenizEF.Models.Sanatci", b =>
                {
                    b.Property<int>("SanatciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("SANATCI_ID");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SanatciId"), 1L, 1);

                    b.Property<string>("SanatciAdi")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)")
                        .HasColumnName("SANATCI_ADI");

                    b.HasKey("SanatciId");

                    b.ToTable("SANATCİLAR", (string)null);

                    b.HasData(
                        new
                        {
                            SanatciId = 1,
                            SanatciAdi = "Pink Floyd"
                        },
                        new
                        {
                            SanatciId = 2,
                            SanatciAdi = "GunsNRoses"
                        });
                });

            modelBuilder.Entity("ErenDenizEF.Models.Album", b =>
                {
                    b.HasOne("ErenDenizEF.Models.Sanatci", "Sanatci")
                        .WithMany("Albumler")
                        .HasForeignKey("SanatciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sanatci");
                });

            modelBuilder.Entity("ErenDenizEF.Models.Sanatci", b =>
                {
                    b.Navigation("Albumler");
                });
#pragma warning restore 612, 618
        }
    }
}
