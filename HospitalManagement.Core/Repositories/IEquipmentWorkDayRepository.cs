using HospitalManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Repositories
{
    public interface IEquipmentWorkDayRepository
    {
        Task AddWorkDaysAsync(ICollection<EquipmentWorkDay> workDays);
        Task<ICollection<EquipmentWorkDay>> GetAllWorkDaysAsync();
        Task UpdateWorkDaysAsync(ICollection<EquipmentWorkDay> workDays);
        Task DeleteWorkDayAsync(int id);
        Task DeleteAllWorkDaysByEquipmentIdAsync(int id);
    }
}
