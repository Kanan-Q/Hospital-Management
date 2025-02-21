using HospitalManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Repositories
{
    public interface ISanitaryRepository
    {
        Task AddAsync(Sanitary sanitary);
        Task UpdateAsync(Sanitary sanitary);
        Task DeleteAsync(Sanitary sanitary);
        Task<IEnumerable<Sanitary>> GetAllAsync();
        Task<Sanitary?> GetByIdAsync(int id);
        Task<IEnumerable<Sanitary>> SearchAsync(string query);
    }
}
