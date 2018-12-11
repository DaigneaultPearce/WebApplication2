using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication2.Models
{
    public partial class TodoappContext : DbContext
    {
        public TodoappContext()
        {
        }

        public TodoappContext(DbContextOptions<TodoappContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Lists> Lists { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-Q5N7L53\\SQLEXPRESS;Database=todoapp;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lists>(entity =>
            {
                entity.ToTable("lists");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.ToTable("tasks");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Desc)
                    .HasColumnName("desc")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Listid).HasColumnName("listid");

                entity.HasOne(d => d.List)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.Listid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tasks_lists");
            });
        }
    }
}
