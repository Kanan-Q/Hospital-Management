using HospitalManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Repositories
{
    public interface INurseWorkDayRepository
    {
        Task AddWorkDaysAsync(ICollection<NurseWorkDay> workDays);
        Task<ICollection<NurseWorkDay>> GetAllWorkDaysAsync();
        Task UpdateWorkDaysAsync(ICollection<NurseWorkDay> workDays);
        Task DeleteWorkDayAsync(int id);
        Task DeleteAllWorkDaysByNurseIdAsync(int id);
    }
}
