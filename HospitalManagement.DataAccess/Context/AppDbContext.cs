using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Entities.Common;
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
        public DbSet<Sanitary> Sanitaries { get; set; }
        public DbSet<Therapist> Therapists { get; set; }
        public DbSet<Diagnostic> Diagnostics { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public AppDbContext(DbContextOptions opt) : base(opt) { }

    }
}
