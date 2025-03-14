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
    public class SanitaryWorkDayRepository(AppDbContext _sql):ISanitaryWorkDayRepository
    {
        public async Task AddWorkDaysAsync(ICollection<SanitaryWorkDay> workDays)
        {
            await _sql.SanitaryWorkDays.AddRangeAsync(workDays);
            await _sql.SaveChangesAsync();
        }

        public async Task<ICollection<SanitaryWorkDay>> GetAllWorkDaysAsync() => await _sql.SanitaryWorkDays.Include(x => x.SanitaryWorkHours).ToListAsync();


        public async Task UpdateWorkDaysAsync(ICollection<SanitaryWorkDay> workDays)
        {
            foreach (var workDay in workDays)
            {
                var existingWorkDay = await _sql.SanitaryWorkDays.Include(x => x.SanitaryWorkHours).FirstOrDefaultAsync(x => x.SanitaryId == workDay.SanitaryId && x.Day == workDay.Day);

                if (existingWorkDay != null)
                {
                    existingWorkDay.SanitaryWorkHours = workDay.SanitaryWorkHours;
                }
            }

            await _sql.SaveChangesAsync();
        }


        public async Task DeleteWorkDayAsync(int id)
        {
            var workDay = await _sql.SanitaryWorkDays.FindAsync(id);
            if (workDay != null)
            {
                _sql.SanitaryWorkDays.Remove(workDay);
                await _sql.SaveChangesAsync();
            }
        }
        public async Task DeleteAllWorkDaysBySanitaryIdAsync(int id)
        {
            var workDays = await _sql.SanitaryWorkDays.Where(x => x.SanitaryId == id).ToListAsync();

            if (workDays.Any())
            {
                _sql.SanitaryWorkDays.RemoveRange(workDays);
                await _sql.SaveChangesAsync();
            }
        }
    }
}
