using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Repositories;
using HospitalManagement.DataAccess.Context;
using HospitalManagement.DataAccess.Migrations;
using Microsoft.EntityFrameworkCore;

public class WorkDayRepository(AppDbContext _sql) : IWorkDayRepository
{
    public async Task AddWorkDaysAsync(ICollection<DoctorWorkDay> workDays)
    {
        await _sql.WorkDays.AddRangeAsync(workDays);
        await _sql.SaveChangesAsync();
    }

    public async Task<ICollection<DoctorWorkDay>> GetAllWorkDaysAsync() => await _sql.WorkDays.Include(x => x.WorkHours).ToListAsync();


    public async Task UpdateWorkDaysAsync(ICollection<DoctorWorkDay> workDays)
    {
        foreach (var workDay in workDays)
        {
            var existingWorkDay = await _sql.WorkDays.Include(x => x.WorkHours).FirstOrDefaultAsync(x => x.DoctorId == workDay.DoctorId && x.Day == workDay.Day);

            if (existingWorkDay != null)
            {
                existingWorkDay.WorkHours = workDay.WorkHours;
            }
        }

        await _sql.SaveChangesAsync();
    }


    public async Task DeleteWorkDayAsync(int id)
    {
        var workDay = await _sql.WorkDays.FindAsync(id);
        if (workDay != null)
        {
            _sql.WorkDays.Remove(workDay);
            await _sql.SaveChangesAsync();
        }
    }
    public async Task DeleteAllWorkDaysByDoctorIdAsync(int id)
    {
        var workDays = await _sql.WorkDays.Where(x => x.DoctorId == id).ToListAsync();

        if (workDays.Any())
        {
            _sql.WorkDays.RemoveRange(workDays);
            await _sql.SaveChangesAsync();
        }
    }

}