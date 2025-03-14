using HospitalManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Repositories
{
    public interface ITherapistWorkDayRepository
    {
        Task AddWorkDaysAsync(ICollection<TherapistWorkDay> workDays);
        Task<ICollection<TherapistWorkDay>> GetAllWorkDaysAsync();
        Task UpdateWorkDaysAsync(ICollection<TherapistWorkDay> workDays);
        Task DeleteWorkDayAsync(int id);
        Task DeleteAllWorkDaysByTherapistIdAsync(int id);
    }
}
