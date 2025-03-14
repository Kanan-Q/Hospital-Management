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
    public class EquipmentWorkDayRepository(AppDbContext _sql):IEquipmentWorkDayRepository
    {
        public async Task AddWorkDaysAsync(ICollection<EquipmentWorkDay> workDays)
        {
            await _sql.EquipmentWorkDays.AddRangeAsync(workDays);
            await _sql.SaveChangesAsync();
        }

        public async Task<ICollection<EquipmentWorkDay>> GetAllWorkDaysAsync() => await _sql.EquipmentWorkDays.Include(x => x.EquipmentWorkHours).ToListAsync();


        public async Task UpdateWorkDaysAsync(ICollection<EquipmentWorkDay> workDays)
        {
            foreach (var workDay in workDays)
            {
                var existingWorkDay = await _sql.EquipmentWorkDays.Include(x => x.EquipmentWorkHours).FirstOrDefaultAsync(x => x.EquipmentId == workDay.EquipmentId && x.Day == workDay.Day);

                if (existingWorkDay != null)
                {
                    existingWorkDay.EquipmentWorkHours = workDay.EquipmentWorkHours;
                }
            }

            await _sql.SaveChangesAsync();
        }


        public async Task DeleteWorkDayAsync(int id)
        {
            var workDay = await _sql.EquipmentWorkDays.FindAsync(id);
            if (workDay != null)
            {
                _sql.EquipmentWorkDays.Remove(workDay);
                await _sql.SaveChangesAsync();
            }
        }
        public async Task DeleteAllWorkDaysByEquipmentIdAsync(int id)
        {
            var workDays = await _sql.EquipmentWorkDays.Where(x => x.EquipmentId == id).ToListAsync();

            if (workDays.Any())
            {
                _sql.EquipmentWorkDays.RemoveRange(workDays);
                await _sql.SaveChangesAsync();
            }
        }
    }
}
