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
    public class SanitaryRepository(AppDbContext _sql):ISanitaryRepository
    {
        public async Task AddAsync(Sanitary sanitary)
        {
            await _sql.Sanitaries.AddAsync(sanitary);
            await _sql.SaveChangesAsync();
        }
        public async Task DeleteAsync(Sanitary sanitary)
        {
            _sql.Sanitaries.Remove(sanitary);
            await _sql.SaveChangesAsync();
        }
        public async Task UpdateAsync(Sanitary sanitary)
        {
            var data = await _sql.Sanitaries.FindAsync(sanitary.Id);
            data.Name = sanitary.Name;
            data.Surname = sanitary.Surname;
            data.Age = sanitary.Age;
            data.Email = sanitary.Email;
            data.FIN = sanitary.FIN;
            data.Education = sanitary.Education;
            data.Phone = sanitary.Phone;
            data.Salary = sanitary.Salary;
            data.Series = sanitary.Series;
            data.Address = sanitary.Address;
            data.DepartmentId = sanitary.DepartmentId;
            await _sql.SaveChangesAsync();
        }
        public async Task<IEnumerable<Sanitary>> GetAllAsync() => await _sql.Sanitaries.Include(x => x.Department).AsNoTracking().ToListAsync();
        public async Task<Sanitary?> GetByIdAsync(int id) => await _sql.Sanitaries.Include(x => x.Department).Where(x => x.Id == id).FirstOrDefaultAsync();
        public async Task<IEnumerable<Sanitary>> SearchAsync(string query) => await _sql.Sanitaries.Where(p => p.Name.Contains(query) || p.Surname.Contains(query) || p.Email.Contains(query) || p.FIN.Contains(query) || p.Series.Contains(query) || p.Age.ToString().Contains(query)).ToListAsync();
    }
}
