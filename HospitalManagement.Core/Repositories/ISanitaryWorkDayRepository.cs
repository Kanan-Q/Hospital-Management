using HospitalManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Repositories
{
    public interface ISanitaryWorkDayRepository
    {
        Task AddWorkDaysAsync(ICollection<SanitaryWorkDay> workDays);
        Task<ICollection<SanitaryWorkDay>> GetAllWorkDaysAsync();
        Task UpdateWorkDaysAsync(ICollection<SanitaryWorkDay> workDays);
        Task DeleteWorkDayAsync(int id);
        Task DeleteAllWorkDaysBySanitaryIdAsync(int id);
    }
}
