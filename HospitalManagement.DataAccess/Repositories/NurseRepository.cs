using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Repositories;
using HospitalManagement.DataAccess.Context;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.DataAccess.Repositories
{
    public class NurseRepository(AppDbContext _sql) : INurseRepository
    {
        public async Task AddAsync(Nurse nurse)
        {
            await _sql.Nurses.AddAsync(nurse);
            await _sql.SaveChangesAsync();
        }
        public async Task DeleteAsync(Nurse nurse)
        {
            _sql.Nurses.Remove(nurse);
            await _sql.SaveChangesAsync();
        }
        public async Task UpdateAsync(Nurse nurse)
        {
            var data = await _sql.Nurses.FindAsync(nurse.Id);
            data.Name = nurse.Name;
            data.Surname = nurse.Surname;
            data.Age = nurse.Age;
            data.Email = nurse.Email;
            data.FIN = nurse.FIN;
            data.Series = nurse.Series;
            data.Address = nurse.Address;
            data.DepartmentId = nurse.DepartmentId;
            await _sql.SaveChangesAsync();
        }
        public async Task<IEnumerable<Nurse>> GetAllAsync() => await _sql.Nurses.Include(x => x.Department).AsNoTracking().ToListAsync();
        public async Task<Nurse?> GetByIdAsync(int id) => await _sql.Nurses.Include(x => x.Department).Where(x => x.Id == id).FirstOrDefaultAsync();
        public async Task<IEnumerable<Nurse>> SearchAsync(string query) => await _sql.Nurses.Where(p => p.Name.Contains(query) || p.Surname.Contains(query) || p.Email.Contains(query) || p.FIN.Contains(query) || p.Series.Contains(query) || p.Age.ToString().Contains(query)).ToListAsync();

    }
}
