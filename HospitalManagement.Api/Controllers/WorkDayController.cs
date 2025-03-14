using HospitalManagement.BL.DTO;
using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class WorkDayController(IWorkDayRepository _repo) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddWorkDays(WorkDayDto dto)
    {
        if (dto.WorkDays == null || !dto.WorkDays.Any())
            return BadRequest();

        var workDays = new List<DoctorWorkDay>();

        foreach (var x in dto.WorkDays)
        {
            if (string.IsNullOrEmpty(x.Day))
                return BadRequest();

            var workHours = new List<DoctorWorkHour>();

            foreach (var item in x.WorkHours)
            {
                try
                {
                    var startTime = TimeSpan.Parse(item.StartTime);
                    var endTime = TimeSpan.Parse(item.EndTime);
                    workHours.Add(new DoctorWorkHour
                    {
                        StartTime = startTime,
                        EndTime = endTime
                    });
                }
                catch (FormatException)
                {
                    return BadRequest();
                }
            }

            workDays.Add(new DoctorWorkDay
            {
                DoctorId = dto.DoctorId,
                Day = x.Day,
                WorkHours = workHours
            });
        }

        await _repo.AddWorkDaysAsync(workDays);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllWorkDays()
    {
        var workDays = await _repo.GetAllWorkDaysAsync();
        return Ok(workDays);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAllWorkDaysByDoctor(int id)
    {
        await _repo.DeleteAllWorkDaysByDoctorIdAsync(id);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateWorkDays(WorkDayDto dto)
    {
        if (dto.WorkDays == null || !dto.WorkDays.Any())
        {
            return BadRequest();
        }

        var existingWorkDays = await _repo.GetAllWorkDaysAsync();

        foreach (var workDay in dto.WorkDays)
        {
            var existingWorkDay = existingWorkDays.FirstOrDefault(x => x.DoctorId == dto.DoctorId && x.Day == workDay.Day);

            if (existingWorkDay != null)
            {
                var updatedWorkHours = new List<DoctorWorkHour>();

                foreach (var workHour in workDay.WorkHours)
                {
                    try
                    {
                        var startTime = TimeSpan.Parse(workHour.StartTime);
                        var endTime = TimeSpan.Parse(workHour.EndTime);

                        updatedWorkHours.Add(new DoctorWorkHour
                        {
                            StartTime = startTime,
                            EndTime = endTime
                        });
                    }
                    catch (FormatException)
                    {
                        return BadRequest();
                    }
                }

                existingWorkDay.WorkHours = updatedWorkHours;
            }
        }

        await _repo.UpdateWorkDaysAsync(existingWorkDays);

        return Ok();
    }
}
