using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Enum;
using HospitalManagement.Core.Repositories;
using HospitalManagement.DataAccess.Context;
using HospitalManagement.DataAccess.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.DataAccess.Repositories
{
    public class PatientRepository(AppDbContext _sql) : IPatientRepository
    {
        public async Task AddAsync(Patient patient)
        {
            await _sql.Patients.AddAsync(patient);
            await _sql.SaveChangesAsync();
        }
        public async Task DeleteAsync(Patient patient)
        {
            _sql.Patients.Remove(patient);
            await _sql.SaveChangesAsync();
        }
        public async Task UpdateAsync(Patient patient)
        {
            var data = await _sql.Patients.FindAsync(patient.Id);
            data.Name = patient.Name;
            data.Surname = patient.Surname;
            data.Age = patient.Age;
            data.Email = patient.Email;
            data.FIN = patient.FIN;
            data.Series = patient.Series;
            data.Address = patient.Address;
            await _sql.SaveChangesAsync();
        }
        //public async Task<ICollection<Patient>> GetPatientsByGenderAsync(int gender) => await _sql.Patients.Where(x => x.Gender == (Gender)gender).ToListAsync();
        //public async Task<ICollection<Patient>> GetPatientsByDepartmentAsync(string department) => await _sql.Patients.Include(x => x.Department.DepartmentName == department).ToListAsync();
        public async Task<Patient?> GetByIdAsync(int id) => await _sql.Patients.Include(x => x.Prescriptions).ThenInclude(x=>x.Doctor.Department).Where(x => x.Id == id).FirstOrDefaultAsync();
        public async Task<Patient?> GetByIdForDoctorAsync(int id, ClaimsPrincipal user)
        {
            var userEmail = user.FindFirst(ClaimTypes.Name)?.Value;

            return await _sql.Patients.Include(x => x.Prescriptions)
                .ThenInclude(x => x.Doctor.Department)
                .Where(p => p.DoctorPatients.Any(dp => dp.Doctor.Email == userEmail))
                .Select(p => new Patient
                {
                    Id = p.Id,
                    Name = p.Name,
                    Surname = p.Surname,
                    Age = p.Age,
                    Email = p.Email,
                    Count = p.Count,
                    CreatedTime = p.CreatedTime,
                    FIN = p.FIN,
                    Series = p.Series,
                    Address = p.Address,
                    DoctorPatients = p.DoctorPatients,
                    Prescriptions = p.Prescriptions
                        .Where(pr => pr.Doctor.Email == userEmail)
                        .Select(pr => new Prescription
                        {
                            Id = pr.Id,
                            MedicationName = pr.MedicationName,
                            Doctor = pr.Doctor,
                            CreatedTime = pr.CreatedTime
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Patient?> GetByFinCodeAsync(string finCode) => await _sql.Patients.Include(x => x.Prescriptions).ThenInclude(p => p.Doctor.Department).Where(x => x.FIN == finCode).FirstOrDefaultAsync();
        public async Task<IEnumerable<Patient>> AllAsync(ClaimsPrincipal user)
        {
            var userRole = user.FindFirst(ClaimTypes.Role)?.Value;
            var userEmail = user.FindFirst(ClaimTypes.Name)?.Value;

            if (userRole == "Admin")
            {
                return await _sql.Patients.AsNoTracking().Include(p => p.DoctorPatients).ThenInclude(dp => dp.Doctor).Include(p => p.Prescriptions).ThenInclude(x => x.Doctor).ToListAsync();
            }
            else if (userRole == "Doctor")
            {
                return await _sql.Patients.AsNoTracking().Where(p => p.DoctorPatients.Any(dp => dp.Doctor.Email == userEmail)).Include(p => p.DoctorPatients).ThenInclude(dp => dp.Doctor).Include(p => p.Prescriptions).ThenInclude(x => x.Doctor).ToListAsync();
            }

            return new List<Patient>();
        }
        public async Task<IEnumerable<Patient>> SearchAsync(string query, ClaimsPrincipal user)
        {
            var role = user.FindFirst(ClaimTypes.Role)?.Value;
            var doctorEmail = user.FindFirst(ClaimTypes.Name)?.Value;

            var patientsQuery = _sql.Patients.AsQueryable();

            if (role == "Doctor")
            {
                patientsQuery = patientsQuery.Where(p => p.DoctorPatients.Any(dp => dp.Doctor.Email == doctorEmail));
            }

            return await patientsQuery.Where(p => p.Name.Contains(query) || p.Surname.Contains(query) || p.Email.Contains(query) || p.FIN.Contains(query) || p.Series.Contains(query) || p.Address.Contains(query) || p.Age.ToString().Contains(query)).ToListAsync();
        }
    }
}
