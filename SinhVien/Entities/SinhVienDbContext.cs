namespace SinhVien.Entities
{
     using System;
     using System.Data.Entity;
     using System.ComponentModel.DataAnnotations.Schema;
     using System.Linq;

     public partial class SinhVienDbContext : DbContext
     {
          public SinhVienDbContext()
              : base("name=SinhVienDbContext")
          {
          }

          public virtual DbSet<DANTOC> DANTOCs { get; set; }
          public virtual DbSet<LOP> LOPs { get; set; }
          public virtual DbSet<SINHVIEN> SINHVIENs { get; set; }
          public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

          protected override void OnModelCreating(DbModelBuilder modelBuilder)
          {
               modelBuilder.Entity<DANTOC>()
                   .HasMany(e => e.SINHVIENs)
                   .WithOptional(e => e.DANTOC1)
                   .HasForeignKey(e => e.DANTOC);

               modelBuilder.Entity<LOP>()
                   .HasMany(e => e.SINHVIENs)
                   .WithOptional(e => e.LOP1)
                   .HasForeignKey(e => e.LOP);
          }
     }
}
