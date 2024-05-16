using ErenDenizEF.Enums;
using ErenDenizEF.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErenDenizEF.Configurations
{
    internal class Sanatci_CFG : IEntityTypeConfiguration<Sanatci>
    {
        public void Configure(EntityTypeBuilder<Sanatci> builder)
        {
            builder.ToTable("SANATCİLAR");

            builder.Property(x => x.SanatciId)
                .HasColumnName("SANATCI_ID");

            builder.Property(x => x.SanatciAdi)
             .HasColumnName("SANATCI_ADI")
             .HasMaxLength(200)
             .IsRequired();

            builder.HasData(new Sanatci { SanatciId = 1, SanatciAdi = "Pink Floyd"});
            builder.HasData(new Sanatci { SanatciId = 2, SanatciAdi = "GunsNRoses"});
        }
    }
}
