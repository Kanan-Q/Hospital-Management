using HospitalManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Repositories
{
    public interface IPatientRepository
    {
        Task AddAsync(Patient patient);
        Task UpdateAsync(Patient patient);
        Task DeleteAsync(Patient patient);
        Task <Patient> GetByIdAsync(int id);
        Task <Patient?> GetByFinCodeAsync(string finCode);
        Task<IEnumerable<Patient>> AllAsync(ClaimsPrincipal user);
        Task<IEnumerable<Patient>> SearchAsync(string query,ClaimsPrincipal user);
        Task<IEnumerable<Patient>> GetPatientWithReceiptsAsync(string finCode);

    }
}
