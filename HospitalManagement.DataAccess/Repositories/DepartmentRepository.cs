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
    public class DepartmentRepository(AppDbContext _sql) : IDepartmentRepository
    {
        public async Task AddAsync(Department department)
        {
            await _sql.Departments.AddAsync(department);
            await _sql.SaveChangesAsync();
        }
        public async Task UpdateAsync(Department department)
        {
            var data=await _sql.Departments.FindAsync(department.Id);
            data.DepartmentName=department.DepartmentName;
            await _sql.SaveChangesAsync();
        }

        public async Task DeleteAsync(Department department)
        {
            _sql.Departments.Remove(department);
            await _sql.SaveChangesAsync();
        }

        public async Task<IEnumerable<Department>> GetAllAsync() => await _sql.Departments.AsNoTracking().ToListAsync();

        public async Task<Department?> GetByIdAsync(int id)=>await _sql.Departments.Where(x=>x.Id==id).FirstOrDefaultAsync();
        public async Task<IEnumerable<Department>> SearchAsync(string query)
        {
            return await _sql.Departments.Where(p => p.DepartmentName.Contains(query)).ToListAsync();
        }

    }
}
