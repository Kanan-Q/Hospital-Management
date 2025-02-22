using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Enum;
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
    public class EquipmentRepository(AppDbContext _sql) : IEquipmentRepository
    {
        public async Task AddAsync(Equipment equipment)
        {
            await _sql.Equipments.AddAsync(equipment);
            await _sql.SaveChangesAsync();
        }
        public async Task DeleteAsync(Equipment equipment)
        {
            _sql.Equipments.Remove(equipment);
            await _sql.SaveChangesAsync();
        }
        public async Task UpdateAsync(Equipment equipment)
        {
            var data = await _sql.Equipments.FindAsync(equipment.Id);
            data.Name = equipment.Name;
            data.Surname = equipment.Surname;
            data.Age = equipment.Age;
            data.Email = equipment.Email;
            data.FIN = equipment.FIN;
            data.Education = equipment.Education;
            data.Phone = equipment.Phone;
            data.Salary = equipment.Salary;
            data.Series = equipment.Series;
            data.Address = equipment.Address;
            data.DepartmentId = equipment.DepartmentId;
            data.Birthday = equipment.Birthday;
            data.Gender = equipment.Gender;
            await _sql.SaveChangesAsync();
        }
        public async Task<ICollection<Equipment>> GetEquipmentsByGenderAsync(int gender) => await _sql.Equipments.Where(x => x.Gender == (Gender)gender).ToListAsync();
        public async Task<ICollection<Equipment>> GetEquipmentsByDepartmentAsync(string department) => await _sql.Equipments.Where(x => x.Department.DepartmentName == department).ToListAsync();
        public async Task<IEnumerable<Equipment>> GetAllAsync() => await _sql.Equipments.Include(x => x.Department).AsNoTracking().ToListAsync();
        public async Task<Equipment?> GetByIdAsync(int id) => await _sql.Equipments.Include(x => x.Department).Where(x => x.Id == id).FirstOrDefaultAsync();
        public async Task<IEnumerable<Equipment>> SearchAsync(string query) => await _sql.Equipments.Where(p => p.Name.Contains(query) || p.Surname.Contains(query) || p.Email.Contains(query) || p.FIN.Contains(query) || p.Series.Contains(query) || p.Age.ToString().Contains(query)).ToListAsync();
    }
}

