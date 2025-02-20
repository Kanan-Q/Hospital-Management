using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Repositories;
using HospitalManagement.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.DataAccess.Repositories
{
    public class PatientAccountRepository(AppDbContext _sql) : IPatientAccountRepository
    {

        public async Task AddAsync(PatientAccount patientAccount)
        {
            await _sql.PatientAccounts.AddAsync(patientAccount);
            await _sql.SaveChangesAsync();
        }
        public async Task<IEnumerable<PatientAccount>> GetAllAsync() => await _sql.PatientAccounts.ToListAsync();
        public async Task<PatientAccount> GetByFinCodeAsync(string finCode) => await _sql.PatientAccounts.FirstOrDefaultAsync(a => a.FinCode == finCode);
        public async Task<IEnumerable<Prescription>> SearchAsync(string query) => await _sql.Prescriptions.AsQueryable().Where(x => x.Doctor.Name.Contains(query) || x.Doctor.Surname.Contains(query) || x.Doctor.Email.Contains(query) || x.Doctor.Department.DepartmentName.Contains(query)).ToListAsync();

    }
}
