using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CouncilChurch.Core.Entities;
using System.Threading.Tasks;

namespace CouncilChurch.Infraestructure.Data.Property
{
    public class CouncilConfiguration : IEntityTypeConfiguration<Council>
    {
        public void Configure(EntityTypeBuilder<Council> builder)
        {
            builder.HasKey(e => e.IdCouncil).HasName("PK__Council__B0CCDB9B2A5EB1EA");

            builder.ToTable("Council");

            builder.Property(e => e.IdCouncil)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Id_Council");
            builder.Property(e => e.IdSocialNetworks)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Id_Social_Networks");
            builder.Property(e => e.Imail)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.Rnc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RNC");
            builder.Property(e => e.Web)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.IdSocialNetworksNavigation).WithMany(p => p.Councils)
                .HasForeignKey(d => d.IdSocialNetworks)
                .HasConstraintName("FK_Social_Networks_Council");
        }
    }
}
