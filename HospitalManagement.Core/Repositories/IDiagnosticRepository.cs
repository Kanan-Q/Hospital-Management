using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Repositories
{
    public interface IDiagnosticRepository
    {
        Task AddAsync(Diagnostic diagnostic);
        Task UpdateAsync(Diagnostic diagnostic);
        Task DeleteAsync(Diagnostic diagnostic);
        Task<IEnumerable<Diagnostic>> GetAllAsync();
        Task<Diagnostic?> GetByIdAsync(int id);
        Task<IEnumerable<Diagnostic>> SearchAsync(string query);
        Task<ICollection<Diagnostic>> GetDiagnosticsByDepartmentAsync(string department);
        Task<ICollection<Diagnostic>> GetDiagnosticsByGenderAsync(int gender);
    }
}
