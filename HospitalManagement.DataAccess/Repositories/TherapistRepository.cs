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
    public class TherapistRepository(AppDbContext _sql):ITherapistRepository
    {
        public async Task AddAsync(Therapist therapist)
        {
            await _sql.Therapists.AddAsync(therapist);
            await _sql.SaveChangesAsync();
        }
        public async Task DeleteAsync(Therapist therapist)
        {
            _sql.Therapists.Remove(therapist);
            await _sql.SaveChangesAsync();
        }
        public async Task UpdateAsync(Therapist therapist)
        {
            var data = await _sql.Therapists.FindAsync(therapist.Id);
            data.Name = therapist.Name;
            data.Surname = therapist.Surname;
            data.Age = therapist.Age;
            data.Email = therapist.Email;
            data.FIN = therapist.FIN;
            data.Education = therapist.Education;
            data.Phone = therapist.Phone;
            data.Salary = therapist.Salary;
            data.Series = therapist.Series;
            data.Address = therapist.Address;
            data.DepartmentId = therapist.DepartmentId;
            await _sql.SaveChangesAsync();
        }
        public async Task<IEnumerable<Therapist>> GetAllAsync() => await _sql.Therapists.Include(x => x.Department).AsNoTracking().ToListAsync();
        public async Task<Therapist?> GetByIdAsync(int id) => await _sql.Therapists.Include(x => x.Department).Where(x => x.Id == id).FirstOrDefaultAsync();
        public async Task<IEnumerable<Therapist>> SearchAsync(string query) => await _sql.Therapists.Where(p => p.Name.Contains(query) || p.Surname.Contains(query) || p.Email.Contains(query) || p.FIN.Contains(query) || p.Series.Contains(query) || p.Age.ToString().Contains(query)).ToListAsync();
    }
}
