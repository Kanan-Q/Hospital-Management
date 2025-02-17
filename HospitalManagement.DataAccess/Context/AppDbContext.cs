using HospitalManagement.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<DoctorPatient> DoctorPatients { get; set; }
        public DbSet<BlackListedToken> BlackListedTokens { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<PatientAccount> PatientAccounts { get; set; }
        
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Doctor>(opt =>
            //{
            //    opt.HasIndex(x => x.Id).IsUnique();
            //    opt.Property(x => x.Name).IsRequired(false).HasMaxLength(20).HasComment("You can use 20 symbol");
            //    opt.Property(x => x.Surname).IsRequired(false).HasMaxLength(20).HasComment("You can use 20 symbol");
            //    opt.Property(x => x.Age).IsRequired(false).HasDefaultValue(0).HasAnnotation("MinValue", 18).HasAnnotation("MaxValue", 65).HasColumnType("int");
            //    opt.Property(x => x.Salary).IsRequired(false).HasDefaultValue(0).HasColumnType("decimal(18,2)");
            //    opt.Property(x => x.Email).IsRequired(false).HasMaxLength(30);
            //    opt.Property(x => x.FIN).IsRequired(false).HasMaxLength(8).HasComment("Max 8 symbol");
            //    opt.Property(x => x.Series).IsRequired(false).HasMaxLength(9).HasComment("Max 9 symbol");
            //    opt.Property(x => x.Address).IsRequired(false).HasMaxLength(50).HasComment("Max 50 symbols can use");
            //    opt.Property(x => x.DepartmentId).IsRequired(false);
            //    opt.HasOne(x => x.Department).WithMany(x => x.Doctors).HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.Cascade);
            //});

            //modelBuilder.Entity<Nurse>(opt =>
            //{
            //    opt.HasIndex(x => x.Id).IsUnique();
            //    opt.Property(x => x.Name).IsRequired(false).HasMaxLength(20).HasComment("You can use 20 symbol");
            //    opt.Property(x => x.Surname).IsRequired(false).HasMaxLength(20).HasComment("You can use 20 symbol");
            //    opt.Property(x => x.Age).IsRequired(false).HasDefaultValue(0).HasAnnotation("MinValue", 18).HasAnnotation("MaxValue", 65).HasColumnType("int");
            //    opt.Property(x => x.Salary).IsRequired(false).HasDefaultValue(0).HasColumnType("decimal(18,2)");
            //    opt.Property(x => x.Email).IsRequired(false).HasMaxLength(30);
            //    opt.Property(x => x.FIN).IsRequired(false).HasMaxLength(8).HasComment("Max 8 symbol");
            //    opt.Property(x => x.Series).IsRequired(false).HasMaxLength(9).HasComment("Max 9 symbol");
            //    opt.Property(x => x.Address).IsRequired(false).HasMaxLength(50).HasComment("Max 50 symbols can use");
            //    opt.Property(x => x.DepartmentId).IsRequired(false);
            //    opt.HasOne(x => x.Department).WithMany(x => x.Nurses).HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.Cascade);
            //});
            //modelBuilder.Entity<Patient>(opt =>
            //{
            //    opt.HasIndex(x => x.Id).IsUnique();
            //    opt.Property(x => x.Name).IsRequired(false).HasMaxLength(20).HasComment("You can use 20 symbol");
            //    opt.Property(x => x.Surname).IsRequired(false).HasMaxLength(20).HasComment("You can use 20 symbol");
            //    opt.Property(x => x.Age).IsRequired(false).HasDefaultValue(0).HasColumnType("int");
            //    opt.Property(x => x.Email).IsRequired(false).HasMaxLength(30);
            //    opt.Property(x => x.FIN).IsRequired(false).HasMaxLength(8).HasComment("Max 8 symbol");
            //    opt.Property(x => x.Series).IsRequired(false).HasMaxLength(9).HasComment("Max 9 symbol");
            //    opt.Property(x => x.Address).IsRequired(false).HasMaxLength(50).HasComment("Max 50 symbols can use");
            //    opt.Property(x => x.DoctorId).IsRequired(false);
            //    opt.HasOne(x => x.Doctor).WithMany(x => x.Patients).HasForeignKey(x => x.DoctorId).OnDelete(DeleteBehavior.Cascade);
            //});
            //modelBuilder.Entity<Department>(opt =>
            //{
            //    opt.HasIndex(x => x.Id).IsUnique();
            //    opt.Property(x => x.DepartmentName).IsRequired(false).HasMaxLength(20).HasComment("You can use 20 symbol");

            //});
            //modelBuilder.Entity<DoctorPatient>().HasKey(x=> new {x.DoctorId,x.PatientId});
            //modelBuilder.Entity<DoctorPatient>().HasOne(x => x.Doctor).WithMany(x => x.DoctorPatients).HasForeignKey(x => x.DoctorId).OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<DoctorPatient>().HasOne(x => x.Patient).WithMany(x => x.DoctorPatients).HasForeignKey(x => x.PatientId).OnDelete(DeleteBehavior.Cascade);


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public AppDbContext(DbContextOptions opt) : base(opt) { }

    }
}
