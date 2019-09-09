using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Clean.Data.Entities;

namespace Clean.Infrastructure.Persistence
{
    public partial class CareHomeContext : DbContext
    {
        public CareHomeContext()
        {
        }

        public CareHomeContext(DbContextOptions<CareHomeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Homes> Homes { get; set; }
        public virtual DbSet<Qualifications> Qualifications { get; set; }
        public virtual DbSet<Staffs> Staffs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // if (!optionsBuilder.IsConfigured)
            // {
            //     optionsBuilder.UseSqlServer("Server=.\\SqlExpress;Integrated Security=SSPI;Database=carehome;Trusted_Connection=True;");
            // }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Homes>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Qualifications>(entity =>
            {
                entity.HasIndex(e => e.StaffId);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Qualifications)
                    .HasForeignKey(d => d.StaffId);
            });

            modelBuilder.Entity<Staffs>(entity =>
            {
                entity.HasIndex(e => e.HomeId);

                entity.Property(e => e.AnnualSalary).HasColumnType("money");

                entity.Property(e => e.Forename)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Home)
                    .WithMany(p => p.Staffs)
                    .HasForeignKey(d => d.HomeId);
            });
        }
    }
}
