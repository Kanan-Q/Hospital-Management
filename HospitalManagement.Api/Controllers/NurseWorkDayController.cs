using HospitalManagement.BL.DTO.DiagnosticWorkDay;
using HospitalManagement.BL.DTO.NurseWorkDay;
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
    public class NurseWorkDayController(INurseWorkDayRepository _repo) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddWorkDays(NurseWorkDayDTO dto)
        {
            if (dto.NurseWorkDays == null || !dto.NurseWorkDays.Any())
                return BadRequest();

            var workDays = new List<NurseWorkDay>();

            foreach (var wd in dto.NurseWorkDays)
            {
                if (string.IsNullOrEmpty(wd.Day))
                    return BadRequest();

                var workHours = new List<NurseWorkHour>();

                foreach (var wh in wd.NurseWorkHours)
                {
                    try
                    {
                        var startTime = TimeSpan.Parse(wh.StartTime);
                        var endTime = TimeSpan.Parse(wh.EndTime);
                        workHours.Add(new NurseWorkHour
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

                workDays.Add(new NurseWorkDay
                {
                    NurseId = dto.NurseId,
                    Day = wd.Day,
                    NurseWorkHours = workHours
                });
            }

            await _repo.AddWorkDaysAsync(workDays);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWorkDays() => Ok(await _repo.GetAllWorkDaysAsync());

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllWorkDaysByNurse(int id)
        {
            await _repo.DeleteAllWorkDaysByNurseIdAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWorkDays(NurseWorkDayDTO dto)
        {
            if (dto.NurseWorkDays == null || !dto.NurseWorkDays.Any())
            {
                return BadRequest();
            }

            var existingWorkDays = await _repo.GetAllWorkDaysAsync();

            foreach (var workDay in dto.NurseWorkDays)
            {
                var existingWorkDay = existingWorkDays.FirstOrDefault(x => x.NurseId == dto.NurseId && x.Day == workDay.Day);

                if (existingWorkDay != null)
                {
                    var updatedWorkHours = new List<NurseWorkHour>();

                    foreach (var workHour in workDay.NurseWorkHours)
                    {
                        try
                        {
                            var startTime = TimeSpan.Parse(workHour.StartTime);
                            var endTime = TimeSpan.Parse(workHour.EndTime);

                            updatedWorkHours.Add(new NurseWorkHour
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

                    existingWorkDay.NurseWorkHours = updatedWorkHours;
                }
            }

            await _repo.UpdateWorkDaysAsync(existingWorkDays);

            return Ok();
        }
    }
}

