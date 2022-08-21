using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiSQR.Models
{
    public partial class BaseSQRContext : DbContext
    {
        public BaseSQRContext()
        {
        }

        public BaseSQRContext(DbContextOptions<BaseSQRContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Docente> Docentes { get; set; } = null!;
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<Proydocente> Proydocentes { get; set; } = null!;
        public virtual DbSet<Proyecto> Proyectos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
              optionsBuilder.UseNpgsql("Host=localhost;Database=BaseSQR;Username=postgres;Password=3827");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.Idadmin)
                    .HasName("admin_pkey");

                entity.ToTable("admin");

                entity.Property(e => e.Idadmin)
                    .ValueGeneratedNever()
                    .HasColumnName("idadmin");

                entity.Property(e => e.Apeadmin)
                    .HasMaxLength(45)
                    .HasColumnName("apeadmin");

                entity.Property(e => e.Nomadmin)
                    .HasMaxLength(45)
                    .HasColumnName("nomadmin");

                entity.Property(e => e.Paswadim)
                    .HasMaxLength(45)
                    .HasColumnName("paswadim");
            });

            modelBuilder.Entity<Docente>(entity =>
            {
                entity.HasKey(e => e.Iddoc)
                    .HasName("docente_pkey");

                entity.ToTable("docente");

                entity.Property(e => e.Iddoc)
                    .ValueGeneratedNever()
                    .HasColumnName("iddoc");

                entity.Property(e => e.Apedoc)
                    .HasMaxLength(45)
                    .HasColumnName("apedoc");

                entity.Property(e => e.Coddoc).HasColumnName("coddoc");

                entity.Property(e => e.Nomdoc)
                    .HasMaxLength(45)
                    .HasColumnName("nomdoc");

                entity.Property(e => e.Pawdoc)
                    .HasMaxLength(45)
                    .HasColumnName("pawdoc");

                entity.Property(e => e.Roldoc)
                    .HasMaxLength(45)
                    .HasColumnName("roldoc")
                    .HasDefaultValueSql("NULL::character varying");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.Idest)
                    .HasName("estudiante_pkey");

                entity.ToTable("estudiante");

                entity.Property(e => e.Idest)
                    .ValueGeneratedNever()
                    .HasColumnName("idest");

                entity.Property(e => e.Apeest)
                    .HasMaxLength(45)
                    .HasColumnName("apeest");

                entity.Property(e => e.Codest).HasColumnName("codest");

                entity.Property(e => e.Nomest)
                    .HasMaxLength(45)
                    .HasColumnName("nomest");

                entity.Property(e => e.Paswest)
                    .HasMaxLength(45)
                    .HasColumnName("paswest");

                entity.Property(e => e.Semest).HasColumnName("semest");
            });

            modelBuilder.Entity<Proydocente>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("proydocente");

                entity.Property(e => e.Codproy).HasColumnName("codproy");

                entity.Property(e => e.Iddoc).HasColumnName("iddoc");

                entity.HasOne(d => d.CodproyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Codproy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("proydocente_codproy_fkey");

                entity.HasOne(d => d.IddocNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Iddoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("proydocente_iddoc_fkey");
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.HasKey(e => e.Codproy)
                    .HasName("proyecto_pkey");

                entity.ToTable("proyecto");

                entity.Property(e => e.Codproy)
                    .ValueGeneratedNever()
                    .HasColumnName("codproy");

                entity.Property(e => e.Archivoproy).HasColumnName("archivoproy");

                entity.Property(e => e.Idadmin).HasColumnName("idadmin");

                entity.Property(e => e.Idest).HasColumnName("idest");

                entity.Property(e => e.Nomproy)
                    .HasMaxLength(45)
                    .HasColumnName("nomproy");

                entity.HasOne(d => d.IdadminNavigation)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.Idadmin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("proyecto_idadmin_fkey");

                entity.HasOne(d => d.IdestNavigation)
                    .WithMany(p => p.Proyectos)
                    .HasForeignKey(d => d.Idest)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("proyecto_idest_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
