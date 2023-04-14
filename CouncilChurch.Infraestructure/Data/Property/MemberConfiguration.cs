using CouncilChurch.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouncilChurch.Infraestructure.Data.Property
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(e => e.IdMembers).HasName("PK__Members__AD460155685B5294");

            builder.Property(e => e.IdMembers)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Id_Members");
            builder.Property(e => e.Birthdate).HasColumnType("date");
            builder.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            builder.Property(e => e.FirstSurname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Surname");
            builder.Property(e => e.IdAddress)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Id_Address");
            builder.Property(e => e.IdChurch)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Id_Church");
            builder.Property(e => e.IdCivilStates)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Id_Civil_States");
            builder.Property(e => e.IdProfession)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Id_Profession");
            builder.Property(e => e.Nickname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nickname");
            builder.Property(e => e.SecondName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Second_Name");
            builder.Property(e => e.SecondSurname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Second_Surname");

            builder.HasOne(d => d.IdAddressNavigation).WithMany(p => p.Members)
                .HasForeignKey(d => d.IdAddress)
                .HasConstraintName("FK_Addresses_Members");

            builder.HasOne(d => d.IdChurchNavigation).WithMany(p => p.Members)
                .HasForeignKey(d => d.IdChurch)
                .HasConstraintName("FK_Churches_Members");

            builder.HasOne(d => d.IdCivilStatesNavigation).WithMany(p => p.Members)
                .HasForeignKey(d => d.IdCivilStates)
                .HasConstraintName("FK_State_Civilians_Members");

            builder.HasOne(d => d.IdProfessionNavigation).WithMany(p => p.Members)
                .HasForeignKey(d => d.IdProfession)
                .HasConstraintName("FK_Professions_Members");
        }
    }
}
