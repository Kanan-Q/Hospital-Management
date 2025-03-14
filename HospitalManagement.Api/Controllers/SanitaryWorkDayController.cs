using HospitalManagement.BL.DTO.DiagnosticWorkDay;
using HospitalManagement.BL.DTO.SanitaryWorkDay;
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
    public class SanitaryWorkDayController(ISanitaryWorkDayRepository _repo) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddWorkDays(SanitaryWorkDayDTO dto)
        {
            if (dto.SanitaryWorkDays == null || !dto.SanitaryWorkDays.Any())
                return BadRequest();

            var workDays = new List<SanitaryWorkDay>();

            foreach (var x in dto.SanitaryWorkDays)
            {
                if (string.IsNullOrEmpty(x.Day))
                    return BadRequest();

                var workHours = new List<SanitaryWorkHour>();

                foreach (var item in x.SanitaryWorkHours)
                {
                    try
                    {
                        var startTime = TimeSpan.Parse(item.StartTime);
                        var endTime = TimeSpan.Parse(item.EndTime);
                        workHours.Add(new SanitaryWorkHour
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

                workDays.Add(new SanitaryWorkDay
                {
                    SanitaryId = dto.SanitaryId,
                    Day = x.Day,
                    SanitaryWorkHours = workHours
                });
            }

            await _repo.AddWorkDaysAsync(workDays);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWorkDays() => Ok(await _repo.GetAllWorkDaysAsync());

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllWorkDaysBySanitary(int id)
        {
            await _repo.DeleteAllWorkDaysBySanitaryIdAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWorkDays(SanitaryWorkDayDTO dto)
        {
            if (dto.SanitaryWorkDays == null || !dto.SanitaryWorkDays.Any())
            {
                return BadRequest();
            }

            var existingWorkDays = await _repo.GetAllWorkDaysAsync();

            foreach (var workDay in dto.SanitaryWorkDays)
            {
                var existingWorkDay = existingWorkDays.FirstOrDefault(x => x.SanitaryId == dto.SanitaryId && x.Day == workDay.Day);

                if (existingWorkDay != null)
                {
                    var updatedWorkHours = new List<SanitaryWorkHour>();

                    foreach (var workHour in workDay.SanitaryWorkHours)
                    {
                        try
                        {
                            var startTime = TimeSpan.Parse(workHour.StartTime);
                            var endTime = TimeSpan.Parse(workHour.EndTime);

                            updatedWorkHours.Add(new SanitaryWorkHour
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

                    existingWorkDay.SanitaryWorkHours = updatedWorkHours;
                }
            }

            await _repo.UpdateWorkDaysAsync(existingWorkDays);

            return Ok();
        }
    }
}

