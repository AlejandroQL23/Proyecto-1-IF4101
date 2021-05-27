using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LabMVC.Models.Entities
{
    public partial class ALDIFA_SOFT_API_IF4101Context : DbContext
    {
        public ALDIFA_SOFT_API_IF4101Context()
        {
        }

        public ALDIFA_SOFT_API_IF4101Context(DbContextOptions<ALDIFA_SOFT_API_IF4101Context> options)
            : base(options)
        {
        }

        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsComment> NewsComments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=163.178.107.10;Initial Catalog=ALDIFA_SOFT_API_IF4101;User ID=laboratorios;Password=KmZpo.2796");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.Author).HasMaxLength(70);

                entity.Property(e => e.Category).HasMaxLength(70);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExtraFile).HasDefaultValueSql("(0x)");

                entity.Property(e => e.TextContent).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(70);
            });

            modelBuilder.Entity<NewsComment>(entity =>
            {
                entity.ToTable("NewsComment");

                entity.Property(e => e.Author).HasMaxLength(70);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TextContent).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
