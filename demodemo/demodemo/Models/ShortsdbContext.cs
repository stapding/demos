using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace demodemo.Models;

public partial class ShortsdbContext : DbContext
{
    public ShortsdbContext()
    {
    }

    public ShortsdbContext(DbContextOptions<ShortsdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Agent> Agents { get; set; }

    public virtual DbSet<AgentType> AgentTypes { get; set; }

    public virtual DbSet<AgentsShort> AgentsShorts { get; set; }

    public virtual DbSet<Director> Directors { get; set; }

    public virtual DbSet<Short> Shorts { get; set; }

    public virtual DbSet<ShortType> ShortTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=1234;database=shortsdb", ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.IdAddress).HasName("PRIMARY");

            entity.ToTable("addresses");

            entity.Property(e => e.IdAddress).HasColumnName("id_address");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.Home).HasColumnName("home");
            entity.Property(e => e.Postcode).HasColumnName("postcode");
            entity.Property(e => e.Region)
                .HasMaxLength(100)
                .HasColumnName("region");
            entity.Property(e => e.Street)
                .HasMaxLength(100)
                .HasColumnName("street");
        });

        modelBuilder.Entity<Agent>(entity =>
        {
            entity.HasKey(e => e.IdAgent).HasName("PRIMARY");

            entity.ToTable("agents");

            entity.HasIndex(e => e.IdAddress, "fk_agents_adresses_idx");

            entity.HasIndex(e => e.IdAgentType, "fk_agents_agent_types_idx");

            entity.HasIndex(e => e.IdDirector, "fk_agents_directors_idx");

            entity.Property(e => e.IdAgent).HasColumnName("id_agent");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.IdAddress).HasColumnName("id_address");
            entity.Property(e => e.IdAgentType).HasColumnName("id_agent_type");
            entity.Property(e => e.IdDirector).HasColumnName("id_director");
            entity.Property(e => e.Inn)
                .HasMaxLength(45)
                .HasColumnName("inn");
            entity.Property(e => e.Kpp)
                .HasMaxLength(45)
                .HasColumnName("kpp");
            entity.Property(e => e.Logo)
                .HasMaxLength(100)
                .HasColumnName("logo");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(100)
                .HasColumnName("phone");
            entity.Property(e => e.Priority).HasColumnName("priority");

            entity.HasOne(d => d.IdAddressNavigation).WithMany(p => p.Agents)
                .HasForeignKey(d => d.IdAddress)
                .HasConstraintName("fk_agents_adresses");

            entity.HasOne(d => d.IdAgentTypeNavigation).WithMany(p => p.Agents)
                .HasForeignKey(d => d.IdAgentType)
                .HasConstraintName("fk_agents_agent_types");

            entity.HasOne(d => d.IdDirectorNavigation).WithMany(p => p.Agents)
                .HasForeignKey(d => d.IdDirector)
                .HasConstraintName("fk_agents_directors");
        });

        modelBuilder.Entity<AgentType>(entity =>
        {
            entity.HasKey(e => e.IdAgentType).HasName("PRIMARY");

            entity.ToTable("agent_types");

            entity.Property(e => e.IdAgentType).HasColumnName("id_agent_type");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<AgentsShort>(entity =>
        {
            entity.HasKey(e => new { e.IdShort, e.IdAgent })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("agents_shorts");

            entity.HasIndex(e => e.IdAgent, "fk_agents_shorts_agents_idx");

            entity.Property(e => e.IdShort).HasColumnName("id_short");
            entity.Property(e => e.IdAgent).HasColumnName("id_agent");
            entity.Property(e => e.DateRealisation).HasColumnName("date_realisation");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdAgentNavigation).WithMany(p => p.AgentsShorts)
                .HasForeignKey(d => d.IdAgent)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_agents_shorts_agents");

            entity.HasOne(d => d.IdShortNavigation).WithMany(p => p.AgentsShorts)
                .HasForeignKey(d => d.IdShort)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_agents_shorts_shorts");
        });

        modelBuilder.Entity<Director>(entity =>
        {
            entity.HasKey(e => e.IdDirector).HasName("PRIMARY");

            entity.ToTable("directors");

            entity.Property(e => e.IdDirector).HasColumnName("id_director");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(100)
                .HasColumnName("middle_name");
        });

        modelBuilder.Entity<Short>(entity =>
        {
            entity.HasKey(e => e.IdShort).HasName("PRIMARY");

            entity.ToTable("shorts");

            entity.HasIndex(e => e.IdShortType, "fk_shorts_short_types_idx");

            entity.Property(e => e.IdShort).HasColumnName("id_short");
            entity.Property(e => e.Articul).HasColumnName("articul");
            entity.Property(e => e.IdShortType).HasColumnName("id_short_type");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Num).HasColumnName("num");
            entity.Property(e => e.People).HasColumnName("people");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.IdShortTypeNavigation).WithMany(p => p.Shorts)
                .HasForeignKey(d => d.IdShortType)
                .HasConstraintName("fk_shorts_short_types");
        });

        modelBuilder.Entity<ShortType>(entity =>
        {
            entity.HasKey(e => e.IdShortType).HasName("PRIMARY");

            entity.ToTable("short_types");

            entity.Property(e => e.IdShortType).HasColumnName("id_short_type");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
