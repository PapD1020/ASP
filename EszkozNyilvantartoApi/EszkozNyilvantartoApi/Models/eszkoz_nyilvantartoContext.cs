using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EszkozNyilvantartoApi.Models
{
    public partial class eszkoz_nyilvantartoContext : DbContext
    {
        public eszkoz_nyilvantartoContext()
        {
        }

        public eszkoz_nyilvantartoContext(DbContextOptions<eszkoz_nyilvantartoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Coworker> Coworkers { get; set; }
        public virtual DbSet<Notebook> Notebooks { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;port=3306;database=eszkoz_nyilvantarto;user=root;password=;SSL mode=none;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coworker>(entity =>
            {
                entity.ToTable("coworker");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Notebook>(entity =>
            {
                entity.ToTable("notebook");

                entity.HasIndex(e => e.NotebookCoworkerId, "coworker_notebook_fk_id");

                entity.Property(e => e.NotebookId)
                    .HasColumnType("int(11)")
                    .HasColumnName("notebookId");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("brand");

                entity.Property(e => e.NotebookCoworkerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("notebookCoworkerId");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("type");

                entity.HasOne(d => d.NotebookCoworker)
                    .WithMany(p => p.Notebooks)
                    .HasForeignKey(d => d.NotebookCoworkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("coworker_notebook_fk_id");
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.ToTable("phone");

                entity.HasIndex(e => e.PhoneCoworkerId, "coworker_phone_fk_id");

                entity.Property(e => e.PhoneId)
                    .HasColumnType("int(11)")
                    .HasColumnName("phoneId");

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("brand");

                entity.Property(e => e.PhoneCoworkerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("phoneCoworkerId");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("type");

                entity.HasOne(d => d.PhoneCoworker)
                    .WithMany(p => p.Phones)
                    .HasForeignKey(d => d.PhoneCoworkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("coworker_phone_fk_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
