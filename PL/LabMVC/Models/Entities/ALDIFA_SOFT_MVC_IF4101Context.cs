using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ALDIFASOFT_MVC.Models.Entities
{
    public partial class ALDIFA_SOFT_MVC_IF4101Context : DbContext
    {
        public ALDIFA_SOFT_MVC_IF4101Context()
        {
        }

        public ALDIFA_SOFT_MVC_IF4101Context(DbContextOptions<ALDIFA_SOFT_MVC_IF4101Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<ForumComment> ForumComments { get; set; }
        public virtual DbSet<ForumCommentAnswer> ForumCommentAnswers { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<ProfessorConsultation> ProfessorConsultations { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=163.178.107.10;Initial Catalog=ALDIFA_SOFT_MVC_IF4101;User ID=laboratorios;Password=KmZpo.2796");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreationUser)
                    .HasMaxLength(15)
                    .HasDefaultValueSql("('Administrador')");

                entity.Property(e => e.Initials)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ScheduleId).HasColumnName("Schedule_Id");

                entity.Property(e => e.Semester).HasMaxLength(8);
            });

            modelBuilder.Entity<ForumComment>(entity =>
            {
                entity.ToTable("ForumComment");

                entity.Property(e => e.Author).HasMaxLength(100);

                entity.Property(e => e.CourseInitials).HasMaxLength(6);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreationUser)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('Estudiante')");
            });

            modelBuilder.Entity<ForumCommentAnswer>(entity =>
            {
                entity.ToTable("ForumCommentAnswer");

                entity.Property(e => e.Author).HasMaxLength(50);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreationUser)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('Estudiante')");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("Group");

                entity.Property(e => e.GroupId).HasColumnName("Group_Id");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreationUser)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('Administrador')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ScheduleId).HasColumnName("Schedule_Id");
            });

            modelBuilder.Entity<ProfessorConsultation>(entity =>
            {
                entity.ToTable("ProfessorConsultation");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreationUser)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('Estudiante')");

                entity.Property(e => e.IdCardProffesor).HasMaxLength(6);

                entity.Property(e => e.IdCardStudent).HasMaxLength(6);

                entity.Property(e => e.StudentName).HasMaxLength(20);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.IdCard, "UQ__User__3B7B33C35C2288B7")
                    .IsUnique();

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Approval).HasMaxLength(15);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreationUser)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('Administrador')");

                entity.Property(e => e.DateTime)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('N/A')");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Facebook)
                    .HasMaxLength(70)
                    .HasDefaultValueSql("('https://www.facebook.com/')");

                entity.Property(e => e.IdCard)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.Instagram)
                    .HasMaxLength(70)
                    .HasDefaultValueSql("('https://www.instagram.com/')");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(15);

                entity.Property(e => e.Photo).HasDefaultValueSql("(0x)");

                entity.Property(e => e.Presidency).HasDefaultValueSql("((0))");

                entity.Property(e => e.Rol).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
