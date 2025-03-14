using HospitalManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Repositories
{
    public interface IDepartmentRepository
    {
        Task AddAsync(Department department);
        Task UpdateAsync(Department department);
        Task DeleteAsync(Department department);
        Task<Department?> GetByIdAsync(int id);
        Task<IEnumerable<Department>> GetAllAsync();
        Task<IEnumerable<Department>> SearchAsync(string query);
        Task<ICollection<Department>> GetSearchByDepartments(string department);

    }
}
