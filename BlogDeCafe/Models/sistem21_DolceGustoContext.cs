using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlogDeCafe.Models
{
    public partial class sistem21_DolceGustoContext : DbContext
    {
        public sistem21_DolceGustoContext()
        {
        }

        public sistem21_DolceGustoContext(DbContextOptions<sistem21_DolceGustoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Comentario> Comentarios { get; set; } = null!;
        public virtual DbSet<Publicacion> Publicacions { get; set; } = null!;
        public virtual DbSet<Usuariosnewsletter> Usuariosnewsletters { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.ToTable("categoria");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Nombre).HasMaxLength(45);
            });

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.ToTable("comentario");

                entity.HasIndex(e => e.Idpublicacion, "fkPublicacionPost_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Autor).HasMaxLength(45);

                entity.Property(e => e.Comentario1)
                    .HasColumnType("tinytext")
                    .HasColumnName("Comentario");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Idpublicacion)
                    .HasColumnType("int(11)")
                    .HasColumnName("idpublicacion");

                entity.HasOne(d => d.IdpublicacionNavigation)
                    .WithMany(p => p.Comentarios)
                    .HasForeignKey(d => d.Idpublicacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkPublicacionComentario");
            });

            modelBuilder.Entity<Publicacion>(entity =>
            {
                entity.ToTable("publicacion");

                entity.HasIndex(e => e.IdCategoria, "fkCategoria_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Autor).HasMaxLength(40);

                entity.Property(e => e.Contenido).HasColumnType("mediumtext");

                entity.Property(e => e.FechaPublicacion).HasColumnType("datetime");

                entity.Property(e => e.IdCategoria).HasColumnType("int(11)");

                entity.Property(e => e.Publicacioncol)
                    .HasMaxLength(45)
                    .HasColumnName("publicacioncol");

                entity.Property(e => e.Titulo).HasMaxLength(70);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Publicacions)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("fkCategoria");
            });

            modelBuilder.Entity<Usuariosnewsletter>(entity =>
            {
                entity.ToTable("usuariosnewsletter");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Correo).HasMaxLength(60);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
