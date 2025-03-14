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
    public class NurseWorkDayRepository(AppDbContext _sql):INurseWorkDayRepository
    {
        public async Task AddWorkDaysAsync(ICollection<NurseWorkDay> workDays)
        {
            await _sql.NurseWorkDays.AddRangeAsync(workDays);
            await _sql.SaveChangesAsync();
        }

        public async Task<ICollection<NurseWorkDay>> GetAllWorkDaysAsync() => await _sql.NurseWorkDays.Include(x => x.NurseWorkHours).ToListAsync();


        public async Task UpdateWorkDaysAsync(ICollection<NurseWorkDay> workDays)
        {
            foreach (var workDay in workDays)
            {
                var existingWorkDay = await _sql.NurseWorkDays.Include(x => x.NurseWorkHours).FirstOrDefaultAsync(x => x.NurseId == workDay.NurseId && x.Day == workDay.Day);

                if (existingWorkDay != null)
                {
                    existingWorkDay.NurseWorkHours = workDay.NurseWorkHours;
                }
            }

            await _sql.SaveChangesAsync();
        }

        public async Task DeleteWorkDayAsync(int id)
        {
            var workDay = await _sql.NurseWorkDays.FindAsync(id);
            if (workDay != null)
            {
                _sql.NurseWorkDays.Remove(workDay);
                await _sql.SaveChangesAsync();
            }
        }
        public async Task DeleteAllWorkDaysByNurseIdAsync(int id)
        {
            var workDays = await _sql.NurseWorkDays.Where(x => x.NurseId == id).ToListAsync();

            if (workDays.Any())
            {
                _sql.NurseWorkDays.RemoveRange(workDays);
                await _sql.SaveChangesAsync();
            }
        }
    }
}
