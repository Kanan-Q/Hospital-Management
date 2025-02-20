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
    public class DoctorRepository(AppDbContext _sql) : IDoctorRepository
    {
        public async Task DeleteAsync(Doctor doctor)
        {
            _sql.Doctors.Remove(doctor);
            await _sql.SaveChangesAsync();
        }
        public async Task UpdateAsync(Doctor doctor)
        {
            var data = await _sql.Doctors.FindAsync(doctor.Id);
            data.Name = doctor.Name;
            data.Surname = doctor.Surname;
            data.Age = doctor.Age;
            data.FIN = doctor.FIN;
            data.Salary = doctor.Salary;
            data.Address = doctor.Address;
            data.Email = doctor.Email;
            data.Series = doctor.Series;
            data.DepartmentId = doctor.DepartmentId;
            await _sql.SaveChangesAsync();
        }
        public async Task<ICollection<Doctor>> GetAllAsync() => await _sql.Doctors.Include(x => x.Department).AsNoTracking().ToListAsync();
        public async Task<Doctor?> GetByIdAsync(int id) => await _sql.Doctors.Include(x => x.Department).Where(x => x.Id == id).FirstOrDefaultAsync();
        public async Task<IEnumerable<Doctor>> SearchAsync(string query) => await _sql.Doctors.Where(p => p.Name.Contains(query) || p.Surname.Contains(query) || p.Email.Contains(query) || p.FIN.Contains(query) || p.Series.Contains(query) || p.Address.Contains(query) || p.Age.ToString().Contains(query)).ToListAsync();

    }
}
