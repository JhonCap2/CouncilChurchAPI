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
    public class SocialNetworkConfiguration : IEntityTypeConfiguration<SocialNetwork>
    {
        public void Configure(EntityTypeBuilder<SocialNetwork> builder)
        {
            builder.HasKey(e => e.IdSocialNetworks).HasName("PK__Social_n__9A576139FD4E8BC5");

            builder.ToTable("Social_networks");

            builder.Property(e => e.IdSocialNetworks)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Id_Social_Networks");
            builder.Property(e => e.NameNetworks)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
