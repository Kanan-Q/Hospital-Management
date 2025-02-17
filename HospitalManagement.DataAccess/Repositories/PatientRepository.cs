using HospitalManagement.Core.Entities;
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
        //public async Task<IEnumerable<Patient>> GetAllAsync() => await _sql.Patients.Include(x => x.DoctorPatients).ThenInclude(x => x.Doctor).AsNoTracking().ToListAsync();

        public async Task<Patient?> GetByIdAsync(int id) => await _sql.Patients.Include(x=>x.Prescriptions).Where(x => x.Id == id).FirstOrDefaultAsync();
        public async Task<Patient?> GetByFinCodeAsync(string finCode) => await _sql.Patients.FirstOrDefaultAsync(x =>x.FIN==finCode);
        public async Task<IEnumerable<Patient>> GetPatientWithReceiptsAsync(string finCode)
        {
            return await _sql.Patients
                .Where(p => p.FIN == finCode)
                .Include(p => p.Prescriptions)
                .ThenInclude(p => p.Doctor) // Həkim məlumatlarını da gətir
                .ToListAsync();
        }




        public async Task<IEnumerable<Patient>> AllAsync(ClaimsPrincipal user)
        {
            var userRole = user.FindFirst(ClaimTypes.Role)?.Value;
            var userEmail = user.FindFirst(ClaimTypes.Name)?.Value;

            if (userRole == "Admin")
            {
                // Admin bütün pasiyentləri görə bilər
                return await _sql.Patients.AsNoTracking().Include(p => p.DoctorPatients).ThenInclude(dp => dp.Doctor).Include(p=>p.Prescriptions).ThenInclude(x=>x.Doctor).ToListAsync();
            }
            else if (userRole == "Doctor")
            {
                // Doctor yalnız öz pasiyentlərini görür
                return await _sql.Patients.AsNoTracking().Where(p => p.DoctorPatients.Any(dp => dp.Doctor.Email == userEmail)).Include(p => p.DoctorPatients).ThenInclude(dp => dp.Doctor).Include(p => p.Prescriptions).ThenInclude(x=>x.Doctor).ToListAsync();
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
                patientsQuery = patientsQuery
                    .Where(p => p.DoctorPatients.Any(dp => dp.Doctor.Email == doctorEmail));
            }

            return await patientsQuery.Where(p => p.Name.Contains(query) || p.Surname.Contains(query) || p.Email.Contains(query) || p.FIN.Contains(query) || p.Series.Contains(query) || p.Address.Contains(query) || p.Age.ToString().Contains(query)).ToListAsync();
        }
    }
}
