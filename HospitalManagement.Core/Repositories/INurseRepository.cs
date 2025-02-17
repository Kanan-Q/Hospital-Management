using HospitalManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Repositories
{
    public interface INurseRepository
    {
        Task AddAsync(Nurse nurse);
        Task UpdateAsync(Nurse nurse);
        Task DeleteAsync(Nurse nurse);
        Task<IEnumerable<Nurse>> GetAllAsync();
        Task <Nurse?> GetByIdAsync(int id);
        Task<IEnumerable<Nurse>> SearchAsync(string query);

    }
}
