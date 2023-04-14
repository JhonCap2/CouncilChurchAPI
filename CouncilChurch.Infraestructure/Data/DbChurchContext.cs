using System;
using System.Collections.Generic;
using CouncilChurch.Core.Entities;
using CouncilChurch.Infraestructure.Data.Property;
using Microsoft.EntityFrameworkCore;

namespace CouncilChurch.Infraestructure.Data;

public partial class DbChurchContext : DbContext
{
    public DbChurchContext()
    {
    }

    public DbChurchContext(DbContextOptions<DbChurchContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Church> Churches { get; set; }

    public virtual DbSet<CivilState> CivilStates { get; set; }

    public virtual DbSet<Council> Councils { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Profession> Professions { get; set; }

    public virtual DbSet<SocialNetwork> SocialNetworks { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfiguration(new AddressConfiguration());
        modelBuilder.ApplyConfiguration(new ChurchConfiguration());
        modelBuilder.ApplyConfiguration(new CivilStateConfiguration());
        modelBuilder.ApplyConfiguration(new CouncilConfiguration());
        modelBuilder.ApplyConfiguration(new MemberConfiguration());
        modelBuilder.ApplyConfiguration(new ProfessionConfiguration());
        modelBuilder.ApplyConfiguration(new SocialNetworkConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
