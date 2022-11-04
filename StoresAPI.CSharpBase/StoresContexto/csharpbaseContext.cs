using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StoresAPI.CSharpBase.StoresContexto
{
    public partial class CSharpbaseContext : DbContext
    {
        public CSharpbaseContext()
        {
        }

        public CSharpbaseContext(DbContextOptions<CSharpbaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Branch> Branches { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Report> Reports { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>(entity =>
            {
                entity.HasKey("BranchId");

                entity.Property(e => e.Location).HasMaxLength(150);

                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryId).ValueGeneratedNever();

                entity.Property(e => e.CountryCode).HasMaxLength(3);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.Property(e => e.ReportId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ClientCity)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ClientCountryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.ClientDocument)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ClientDocumentNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ClientEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ClientName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ClientNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ClientPhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Photo1)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Photo2)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Photo3)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Photo4)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ReportDate).HasColumnType("datetime");

                entity.Property(e => e.ReportDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
