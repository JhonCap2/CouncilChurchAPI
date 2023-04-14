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
    public class ProfessionConfiguration : IEntityTypeConfiguration<Profession>
    {
        public void Configure(EntityTypeBuilder<Profession> builder)
        {
            builder.HasKey(e => e.IdProfession).HasName("PK__Professi__D53C0B2567F21D55");

            builder.Property(e => e.IdProfession)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Id_Profession");
            builder.Property(e => e.NameProfession)
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}
