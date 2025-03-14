using HospitalManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Repositories
{
    public interface IDiagnosticWorkDayRepository
    {
        Task AddWorkDaysAsync(ICollection<DiagnosticWorkDay> workDays);
        Task<ICollection<DiagnosticWorkDay>> GetAllWorkDaysAsync();
        Task UpdateWorkDaysAsync(ICollection<DiagnosticWorkDay> workDays);
        Task DeleteWorkDayAsync(int id);
        Task DeleteAllWorkDaysByDiagnosticIdAsync(int id);
    }
}
