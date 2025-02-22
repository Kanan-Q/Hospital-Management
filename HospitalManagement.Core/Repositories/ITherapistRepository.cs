using HospitalManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Repositories
{
    public interface ITherapistRepository
    {
        Task AddAsync(Therapist therapist);
        Task UpdateAsync(Therapist therapist);
        Task DeleteAsync(Therapist therapist);
        Task<IEnumerable<Therapist>> GetAllAsync();
        Task<Therapist?> GetByIdAsync(int id);
        Task<IEnumerable<Therapist>> SearchAsync(string query);
        Task<ICollection<Therapist>> GetTherapistsByDepartmentAsync(string department);
        Task<ICollection<Therapist>> GetTherapistsByGenderAsync(int gender);
    }
}
