using HospitalManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Repositories
{
    public interface IEquipmentRepository
    {
        Task AddAsync(Equipment equipment);
        Task UpdateAsync(Equipment equipment);
        Task DeleteAsync(Equipment equipment);
        Task<IEnumerable<Equipment>> GetAllAsync();
        Task<Equipment?> GetByIdAsync(int id);
        Task<IEnumerable<Equipment>> SearchAsync(string query);
        Task<ICollection<Equipment>> GetEquipmentsByDepartmentAsync(string department);
        Task<ICollection<Equipment>> GetEquipmentsByGenderAsync(int gender);
    }
}
