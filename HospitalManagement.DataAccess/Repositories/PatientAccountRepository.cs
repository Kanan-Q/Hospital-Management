using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Repositories;
using HospitalManagement.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.DataAccess.Repositories
{
    public class PatientAccountRepository : IPatientAccountRepository
    {
        private readonly AppDbContext _context;

        public PatientAccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PatientAccount>> GetAllAsync()
        {
            return await _context.PatientAccounts.ToListAsync();
        }

        public async Task<PatientAccount> GetByFinCodeAsync(string finCode)
        {
            return await _context.PatientAccounts.FirstOrDefaultAsync(a => a.FinCode == finCode);
        }

        public async Task AddAsync(PatientAccount patientAccount)
        {
            await _context.PatientAccounts.AddAsync(patientAccount);
            await _context.SaveChangesAsync();
        }
    }
}
