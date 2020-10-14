using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using App13_EFCoreDBFirst.Models;

namespace App13_EFCoreDBFirst.Models
{
    public partial class BITM9Context : DbContext
    {
        public BITM9Context()
        {
        }

        public BITM9Context(DbContextOptions<BITM9Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=DESKTOP-HFP8OSQ\\SQLEXPRESS;Database=BITM9;Trusted_Connection=true;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PayBasis)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PositionTitle)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<App13_EFCoreDBFirst.Models.Category> Category { get; set; }

        public DbSet<App13_EFCoreDBFirst.Models.Product> Product { get; set; }

        public DbSet<App13_EFCoreDBFirst.Models.Student> Student { get; set; }

        public DbSet<App13_EFCoreDBFirst.Models.Course> Course { get; set; }

        public DbSet<App13_EFCoreDBFirst.Models.StudentCourse> StudentCourse { get; set; }
    }
}
