using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CouncilChurch.Core.Entities;

namespace CouncilChurch.Infraestructure.Data.Property
{
    public class ChurchConfiguration : IEntityTypeConfiguration<Church>
    {
        public void Configure(EntityTypeBuilder<Church> builder)
        {
            builder.HasKey(e => e.IdChurch).HasName("PK__Church__3F625C1CDAB3B652");

            builder.ToTable("Church");

            builder.Property(e => e.IdChurch)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Id_Church");
            builder.Property(e => e.IdAddress)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Id_Address");
            builder.Property(e => e.IdCouncil)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Id_Council");
            builder.Property(e => e.NameChurch)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.Web)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.HasOne(d => d.IdAddressNavigation).WithMany(p => p.Churches)
                .HasForeignKey(d => d.IdAddress)
                .HasConstraintName("FK_Addresses_Churches");

            builder.HasOne(d => d.IdCouncilNavigation).WithMany(p => p.Churches)
                .HasForeignKey(d => d.IdCouncil)
                .HasConstraintName("FK_Councils_Churches");
        }
    }
}
