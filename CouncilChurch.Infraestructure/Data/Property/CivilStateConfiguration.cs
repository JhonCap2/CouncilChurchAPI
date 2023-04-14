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
    public class CivilStateConfiguration : IEntityTypeConfiguration<CivilState>
    {
        public void Configure(EntityTypeBuilder<CivilState> builder)
        {
            builder.HasKey(e => e.IdCivilStates).HasName("PK__Civil_St__F9ADC50969032E27");

            builder.ToTable("Civil_States");

            builder.Property(e => e.IdCivilStates)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Id_Civil_States");
            builder.Property(e => e.NameCivilState)
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}
