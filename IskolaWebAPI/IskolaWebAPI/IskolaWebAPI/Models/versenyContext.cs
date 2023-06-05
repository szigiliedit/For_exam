using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IskolaWebAPI.Models
{
    public partial class versenyContext : DbContext
    {
        public versenyContext()
        {
        }

        public versenyContext(DbContextOptions<versenyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Diakok> Diakoks { get; set; } = null!;
        public virtual DbSet<Iskolak> Iskolaks { get; set; } = null!;
        public virtual DbSet<Iskolalogok> Iskolalogoks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;database=verseny;user=root;password=;sslmode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diakok>(entity =>
            {
                entity.ToTable("diakok");

                entity.HasIndex(e => e.IskolaId, "iskolaId");

                entity.HasIndex(e => e.OktatasiAzonosito, "oktatasiAzonosito")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.IskolaId)
                    .HasColumnType("int(3)")
                    .HasColumnName("iskolaId");

                entity.Property(e => e.Nev).HasMaxLength(40);

                entity.Property(e => e.OktatasiAzonosito)
                    .HasMaxLength(11)
                    .HasColumnName("oktatasiAzonosito");

                entity.Property(e => e.Osztaly).HasMaxLength(12);

                entity.Property(e => e.Tanev).HasMaxLength(9);

                entity.HasOne(d => d.Iskola)
                    .WithMany(p => p.Diakoks)
                    .HasPrincipalKey(p => p.IskolaId)
                    .HasForeignKey(d => d.IskolaId)
                    .HasConstraintName("diakok_ibfk_1");
            });

            modelBuilder.Entity<Iskolak>(entity =>
            {
                entity.ToTable("iskolak");

                entity.HasIndex(e => e.IskolaId, "iskolaId")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(2)")
                    .HasColumnName("id");

                entity.Property(e => e.IskolaId)
                    .HasColumnType("int(3)")
                    .HasColumnName("iskolaId");

                entity.Property(e => e.Nev)
                    .HasMaxLength(70)
                    .HasColumnName("nev");

                entity.Property(e => e.SmallLogo)
                    .HasColumnType("mediumblob")
                    .HasColumnName("smallLogo");
            });

            modelBuilder.Entity<Iskolalogok>(entity =>
            {
                entity.ToTable("iskolalogok");

                entity.HasIndex(e => e.IskolaId, "iskola_id")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(2)")
                    .HasColumnName("id");

                entity.Property(e => e.IskolaId)
                    .HasColumnType("int(3)")
                    .HasColumnName("iskola_id");

                entity.Property(e => e.Logo)
                    .HasColumnType("mediumblob")
                    .HasColumnName("logo");

                entity.HasOne(d => d.Iskola)
                    .WithOne(p => p.Iskolalogok)
                    .HasPrincipalKey<Iskolak>(p => p.IskolaId)
                    .HasForeignKey<Iskolalogok>(d => d.IskolaId)
                    .HasConstraintName("iskolalogok_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
