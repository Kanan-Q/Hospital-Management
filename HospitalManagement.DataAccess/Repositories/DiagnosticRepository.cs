using HospitalManagement.Core.Entities.Common;
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
    public class DiagnosticRepository(AppDbContext _sql):IDiagnosticRepository
    {
        public async Task AddAsync(Diagnostic diagnostic)
        {
            await _sql.Diagnostics.AddAsync(diagnostic);
            await _sql.SaveChangesAsync();
        }
        public async Task DeleteAsync(Diagnostic diagnostic)
        {
            _sql.Diagnostics.Remove(diagnostic);
            await _sql.SaveChangesAsync();
        }
        public async Task UpdateAsync(Diagnostic diagnostic)
        {
            var data = await _sql.Diagnostics.FindAsync(diagnostic.Id);
            data.Name = diagnostic.Name;
            data.Surname = diagnostic.Surname;
            data.Age = diagnostic.Age;
            data.Email = diagnostic.Email;
            data.FIN = diagnostic.FIN;
            data.Education = diagnostic.Education;
            data.Phone = diagnostic.Phone;
            data.Salary = diagnostic.Salary;
            data.Series = diagnostic.Series;
            data.Address = diagnostic.Address;
            data.DepartmentId = diagnostic.DepartmentId;
            await _sql.SaveChangesAsync();
        }
        public async Task<IEnumerable<Diagnostic>> GetAllAsync() => await _sql.Diagnostics.Include(x => x.Department).AsNoTracking().ToListAsync();
        public async Task<Diagnostic?> GetByIdAsync(int id) => await _sql.Diagnostics.Include(x => x.Department).Where(x => x.Id == id).FirstOrDefaultAsync();
        public async Task<IEnumerable<Diagnostic>> SearchAsync(string query) => await _sql.Diagnostics.Where(p => p.Name.Contains(query) || p.Surname.Contains(query) || p.Email.Contains(query) || p.FIN.Contains(query) || p.Series.Contains(query) || p.Age.ToString().Contains(query)).ToListAsync();
    }
}

