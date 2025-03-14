using HospitalManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Repositories
{
    public interface IWorkDayRepository
    {
        Task AddWorkDaysAsync(ICollection<DoctorWorkDay> workDays);
        Task<ICollection<DoctorWorkDay>> GetAllWorkDaysAsync();
        Task UpdateWorkDaysAsync(ICollection<DoctorWorkDay> workDays);
        Task DeleteWorkDayAsync(int id);
        Task DeleteAllWorkDaysByDoctorIdAsync(int id);
    }
}
