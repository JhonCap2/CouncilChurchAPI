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
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(e => e.IdAddress).HasName("PK__Addresse__132A5500E48375A2");

            builder.Property(e => e.IdAddress)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Id_Address");
            builder.Property(e => e.AddressChurch)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Address_Church");
        }
    }
}
