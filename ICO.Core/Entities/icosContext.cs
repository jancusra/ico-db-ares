using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ICO.Core.Entities
{
    public partial class icosContext : DbContext
    {
        public virtual DbSet<Data> Data { get; set; }
        public virtual DbSet<Obce> Obce { get; set; }
        public virtual DbSet<Okresy> Okresy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=VIRTO-PC\SQLEXPRESS;Database=icos;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Data>(entity =>
            {
                entity.ToTable("data");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CisloDomovni).HasColumnName("Cislo_domovni");

                entity.Property(e => e.CisloOrientacni)
                    .IsRequired()
                    .HasColumnName("Cislo_orientacni")
                    .HasMaxLength(50);

                entity.Property(e => e.Ico).HasColumnName("ICO");

                entity.Property(e => e.IdAdresy).HasColumnName("ID_adresy");

                entity.Property(e => e.KodStatu).HasColumnName("Kod_statu");

                entity.Property(e => e.ObchodniFirma)
                    .IsRequired()
                    .HasColumnName("Obchodni_firma")
                    .HasMaxLength(255);

                entity.Property(e => e.Psc).HasColumnName("PSC");

                entity.Property(e => e.Ulice)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.ObecNavigation)
                    .WithMany(p => p.Data)
                    .HasForeignKey(d => d.Obec)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_data_obce");

                entity.HasOne(d => d.OkresNavigation)
                    .WithMany(p => p.Data)
                    .HasForeignKey(d => d.Okres)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_data_okresy");
            });

            modelBuilder.Entity<Obce>(entity =>
            {
                entity.ToTable("obce");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NazevObce)
                    .IsRequired()
                    .HasColumnName("Nazev_obce")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Okresy>(entity =>
            {
                entity.ToTable("okresy");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NazevOkresu)
                    .IsRequired()
                    .HasColumnName("Nazev_okresu")
                    .HasMaxLength(255);
            });
        }
    }
}
