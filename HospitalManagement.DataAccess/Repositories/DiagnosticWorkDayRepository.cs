using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Repositories;
using HospitalManagement.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.DataAccess.Repositories
{
    public class DiagnosticWorkDayRepository(AppDbContext _sql) : IDiagnosticWorkDayRepository
    {
        public async Task AddWorkDaysAsync(ICollection<DiagnosticWorkDay> workDays)
        {
            await _sql.DiagnosticWorkDays.AddRangeAsync(workDays);
            await _sql.SaveChangesAsync();
        }

        public async Task<ICollection<DiagnosticWorkDay>> GetAllWorkDaysAsync() => await _sql.DiagnosticWorkDays.Include(x => x.DiagnosticWorkHours).ToListAsync();


        public async Task UpdateWorkDaysAsync(ICollection<DiagnosticWorkDay> workDays)
        {
            foreach (var workDay in workDays)
            {
                var existingWorkDay = await _sql.DiagnosticWorkDays.Include(x => x.DiagnosticWorkHours).FirstOrDefaultAsync(x => x.DiagnosticId == workDay.DiagnosticId && x.Day == workDay.Day);

                if (existingWorkDay != null)
                {
                    existingWorkDay.DiagnosticWorkHours = workDay.DiagnosticWorkHours;
                }
            }

            await _sql.SaveChangesAsync();
        }


        public async Task DeleteWorkDayAsync(int id)
        {
            var workDay = await _sql.DiagnosticWorkDays.FindAsync(id);
            if (workDay != null)
            {
                _sql.DiagnosticWorkDays.Remove(workDay);
                await _sql.SaveChangesAsync();
            }
        }
        public async Task DeleteAllWorkDaysByDiagnosticIdAsync(int id)
        {
            var workDays = await _sql.DiagnosticWorkDays.Where(x => x.DiagnosticId == id).ToListAsync();
            if (workDays.Any())
            {
                _sql.DiagnosticWorkDays.RemoveRange(workDays);
                await _sql.SaveChangesAsync();
            }
        }
    }
}
