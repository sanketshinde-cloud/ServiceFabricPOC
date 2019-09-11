using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;

namespace DepartmentMicroservice.Models
{
    public partial class DepartmentContext : DbContext
    {


        public DepartmentContext()
        {
        }

        public DepartmentContext( DbContextOptions<DepartmentContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Departments> Departments { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                

        //        optionsBuilder.UseSqlServer("Server=tcp:departmentpoc.database.windows.net,1433;Initial Catalog=Department;Persist Security Info=False;User ID=departmentadmin;Password=Department@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DeptId)
                    .HasName("PK__Departme__014881AEA1503DC2");

                entity.Property(e => e.DeptDescription).HasMaxLength(4000);

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ShiftTime).HasMaxLength(50);
            });
        }
    }
}
