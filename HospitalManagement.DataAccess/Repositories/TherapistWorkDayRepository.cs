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
    public class TherapistWorkDayRepository(AppDbContext _sql):ITherapistWorkDayRepository
    {
        public async Task AddWorkDaysAsync(ICollection<TherapistWorkDay> workDays)
        {
            await _sql.TherapistWorkDays.AddRangeAsync(workDays);
            await _sql.SaveChangesAsync();
        }

        public async Task<ICollection<TherapistWorkDay>> GetAllWorkDaysAsync() => await _sql.TherapistWorkDays.Include(x => x.TherapistWorkHours).ToListAsync();


        public async Task UpdateWorkDaysAsync(ICollection<TherapistWorkDay> workDays)
        {
            foreach (var workDay in workDays)
            {
                var existingWorkDay = await _sql.TherapistWorkDays.Include(x => x.TherapistWorkHours).FirstOrDefaultAsync(x => x.TherapistId == workDay.TherapistId && x.Day == workDay.Day);

                if (existingWorkDay != null)
                {
                    existingWorkDay.TherapistWorkHours = workDay.TherapistWorkHours;
                }
            }

            await _sql.SaveChangesAsync();
        }


        public async Task DeleteWorkDayAsync(int id)
        {
            var workDay = await _sql.TherapistWorkDays.FindAsync(id);
            if (workDay != null)
            {
                _sql.TherapistWorkDays.Remove(workDay);
                await _sql.SaveChangesAsync();
            }
        }
        public async Task DeleteAllWorkDaysByTherapistIdAsync(int id)
        {
            var workDays = await _sql.TherapistWorkDays.Where(x => x.TherapistId == id).ToListAsync();

            if (workDays.Any())
            {
                _sql.TherapistWorkDays.RemoveRange(workDays);
                await _sql.SaveChangesAsync();
            }
        }
    }
}
