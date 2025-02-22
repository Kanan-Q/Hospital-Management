using HospitalManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Repositories
{
    public interface IDoctorRepository
    {
        Task <ICollection<Doctor>> GetAllAsync();
        Task UpdateAsync(Doctor doctor);
        Task DeleteAsync(Doctor doctor);
        Task<Doctor?> GetByIdAsync(int id);
        Task<IEnumerable<Doctor>> SearchAsync(string query);
        Task<ICollection<Doctor>> GetDoctorsByGenderAsync(int gender);
        Task<ICollection<Doctor>> GetDoctorsByDepartmentAsync(string department);

    }
}
