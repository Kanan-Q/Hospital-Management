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
        public DbSet<DoctorWorkDay> WorkDays { get; set; }
        public DbSet<DoctorWorkHour> WorkHours { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<DoctorPatient> DoctorPatients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<PatientAccount> PatientAccounts { get; set; }
        public DbSet<Sanitary> Sanitaries { get; set; }
        public DbSet<Therapist> Therapists { get; set; }
        public DbSet<Diagnostic> Diagnostics { get; set; }
        public DbSet<EquipmentWorkDay> EquipmentWorkDays { get; set; }
        public DbSet<EquipmentWorkHour> EquipmentWorkHours { get; set; }
        public DbSet<NurseWorkDay> NurseWorkDays { get; set; }
        public DbSet<NurseWorkHour> NurseWorkHours { get; set; }
        public DbSet<SanitaryWorkDay> SanitaryWorkDays { get; set; }
        public DbSet<SanitaryWorkHour> SanitaryWorkHours { get; set; }
        public DbSet<TherapistWorkDay> TherapistWorkDays { get; set; }
        public DbSet<TherapistWorkHour> TherapistWorkHours { get; set; }
        public DbSet<DiagnosticWorkDay> DiagnosticWorkDays { get; set; }
        public DbSet<DiagnosticWorkHour> DiagnosticWorkHours { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorWorkDay>(entity =>
            {
                entity.ToTable("WorkDays");

                entity.HasKey(w => w.Id);

                entity.Property(w => w.Day)
                      .IsRequired();

                entity.HasMany(w => w.WorkHours)
                      .WithOne(wh => wh.DoctorWorkDay)
                      .HasForeignKey(wh => wh.DoctorWorkDayId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<DoctorWorkHour>(entity =>
            {
                entity.ToTable("WorkHours");

                entity.HasKey(wh => wh.Id);

                entity.Property(wh => wh.StartTime)
                      .IsRequired();

                entity.Property(wh => wh.EndTime)
                      .IsRequired();
            });

            modelBuilder.Entity<NurseWorkDay>(entity =>
            {
                entity.ToTable("NurseWorkDays");

                entity.HasKey(w => w.Id);

                entity.Property(w => w.Day)
                      .IsRequired();

                entity.HasMany(w => w.NurseWorkHours)
                      .WithOne(wh => wh.NurseWorkDay)
                      .HasForeignKey(wh => wh.NurseWorkDayId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<NurseWorkHour>(entity =>
            {
                entity.ToTable("NurseWorkHours");

                entity.HasKey(wh => wh.Id);

                entity.Property(wh => wh.StartTime)
                      .IsRequired();

                entity.Property(wh => wh.EndTime)
                      .IsRequired();
            });

            modelBuilder.Entity<SanitaryWorkDay>(entity =>
            {
                entity.ToTable("SanitaryWorkDays");

                entity.HasKey(w => w.Id);

                entity.Property(w => w.Day)
                      .IsRequired();

                entity.HasMany(w => w.SanitaryWorkHours)
                      .WithOne(wh => wh.SanitaryWorkDay)
                      .HasForeignKey(wh => wh.SanitaryWorkDayId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<SanitaryWorkHour>(entity =>
            {
                entity.ToTable("SanitaryWorkHours");

                entity.HasKey(wh => wh.Id);

                entity.Property(wh => wh.StartTime)
                      .IsRequired();

                entity.Property(wh => wh.EndTime)
                      .IsRequired();
            });

            modelBuilder.Entity<TherapistWorkDay>(entity =>
            {
                entity.ToTable("TherapistWorkDays");

                entity.HasKey(w => w.Id);

                entity.Property(w => w.Day)
                      .IsRequired();

                entity.HasMany(w => w.TherapistWorkHours)
                      .WithOne(wh => wh.TherapistWorkDay)
                      .HasForeignKey(wh => wh.TherapistWorkDayId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TherapistWorkHour>(entity =>
            {
                entity.ToTable("TherapistWorkHours");

                entity.HasKey(wh => wh.Id);

                entity.Property(wh => wh.StartTime)
                      .IsRequired();

                entity.Property(wh => wh.EndTime)
                      .IsRequired();
            });

            modelBuilder.Entity<EquipmentWorkDay>(entity =>
            {
                entity.ToTable("EquipmentWorkDays");

                entity.HasKey(w => w.Id);

                entity.Property(w => w.Day)
                      .IsRequired();

                entity.HasMany(w => w.EquipmentWorkHours)
                      .WithOne(wh => wh.EquipmentWorkDay)
                      .HasForeignKey(wh => wh.EquipmentWorkDayId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<EquipmentWorkHour>(entity =>
            {
                entity.ToTable("EquipmentWorkHours");

                entity.HasKey(wh => wh.Id);

                entity.Property(wh => wh.StartTime)
                      .IsRequired();

                entity.Property(wh => wh.EndTime)
                      .IsRequired();
            });

            modelBuilder.Entity<DiagnosticWorkDay>(entity =>
            {
                entity.ToTable("DiagnosticWorkDays");

                entity.HasKey(w => w.Id);

                entity.Property(w => w.Day)
                      .IsRequired();

                entity.HasMany(w => w.DiagnosticWorkHours)
                      .WithOne(wh => wh.DiagnosticWorkDay)
                      .HasForeignKey(wh => wh.DiagnosticWorkDayId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<DiagnosticWorkHour>(entity =>
            {
                entity.ToTable("DiagnosticWorkHours");

                entity.HasKey(wh => wh.Id);

                entity.Property(wh => wh.StartTime)
                      .IsRequired();

                entity.Property(wh => wh.EndTime)
                      .IsRequired();
            });


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public AppDbContext(DbContextOptions opt) : base(opt) { }

    }
}
