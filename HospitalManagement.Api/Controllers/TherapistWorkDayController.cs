using HospitalManagement.BL.DTO.DiagnosticWorkDay;
using HospitalManagement.BL.DTO.TherapistWorkDay;
using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class TherapistWorkDayController(ITherapistWorkDayRepository _repo) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddWorkDays(TherapistWorkDayDTO dto)
        {
            if (dto.TherapistWorkDays == null || !dto.TherapistWorkDays.Any())
                return BadRequest();

            var workDays = new List<TherapistWorkDay>();

            foreach (var x in dto.TherapistWorkDays)
            {
                if (string.IsNullOrEmpty(x.Day))
                    return BadRequest();

                var workHours = new List<TherapistWorkHour>();

                foreach (var item in x.TherapistWorkHours)
                {
                    try
                    {
                        var startTime = TimeSpan.Parse(item.StartTime);
                        var endTime = TimeSpan.Parse(item.EndTime);
                        workHours.Add(new TherapistWorkHour
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

                workDays.Add(new TherapistWorkDay
                {
                    TherapistId = dto.TherapistId,
                    Day = x.Day,
                    TherapistWorkHours = workHours
                });
            }

            await _repo.AddWorkDaysAsync(workDays);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWorkDays() => Ok(await _repo.GetAllWorkDaysAsync());

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllWorkDaysByTherapist(int id)
        {
            await _repo.DeleteAllWorkDaysByTherapistIdAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWorkDays(TherapistWorkDayDTO dto)
        {
            if (dto.TherapistWorkDays == null || !dto.TherapistWorkDays.Any())
            {
                return BadRequest();
            }

            var existingWorkDays = await _repo.GetAllWorkDaysAsync();

            foreach (var workDay in dto.TherapistWorkDays)
            {
                var existingWorkDay = existingWorkDays.FirstOrDefault(x => x.TherapistId == dto.TherapistId && x.Day == workDay.Day);

                if (existingWorkDay != null)
                {
                    var updatedWorkHours = new List<TherapistWorkHour>();

                    foreach (var workHour in workDay.TherapistWorkHours)
                    {
                        try
                        {
                            var startTime = TimeSpan.Parse(workHour.StartTime);
                            var endTime = TimeSpan.Parse(workHour.EndTime);

                            updatedWorkHours.Add(new TherapistWorkHour
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

                    existingWorkDay.TherapistWorkHours = updatedWorkHours;
                }
            }

            await _repo.UpdateWorkDaysAsync(existingWorkDays);

            return Ok();
        }
    }
}

