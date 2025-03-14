using HospitalManagement.BL.DTO;
using HospitalManagement.BL.DTO.DiagnosticWorkDay;
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
    public class DiagnosticWorkDayController(IDiagnosticWorkDayRepository _repo) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddWorkDays(DiagnosticWorkDayDTO dto)
        {
            if (dto.DiagnosticWorkDays == null || !dto.DiagnosticWorkDays.Any())
                return BadRequest();

            var workDays = new List<DiagnosticWorkDay>();

            foreach (var wd in dto.DiagnosticWorkDays)
            {
                if (string.IsNullOrEmpty(wd.Day))
                    return BadRequest();

                var workHours = new List<DiagnosticWorkHour>();

                foreach (var wh in wd.DiagnosticWorkHours)
                {
                    try
                    {
                        var startTime = TimeSpan.Parse(wh.StartTime);
                        var endTime = TimeSpan.Parse(wh.EndTime);
                        workHours.Add(new DiagnosticWorkHour
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

                workDays.Add(new DiagnosticWorkDay
                {
                    DiagnosticId = dto.DiagnosticId,
                    Day = wd.Day,
                    DiagnosticWorkHours = workHours
                });
            }

            await _repo.AddWorkDaysAsync(workDays);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWorkDays()=> Ok(await _repo.GetAllWorkDaysAsync());
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllWorkDaysByDiagnostic(int id)
        {
            await _repo.DeleteAllWorkDaysByDiagnosticIdAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWorkDays(DiagnosticWorkDayDTO dto)
        {
            if (dto.DiagnosticWorkDays == null || !dto.DiagnosticWorkDays.Any())
            {
                return BadRequest();
            }

            var existingWorkDays = await _repo.GetAllWorkDaysAsync();

            foreach (var workDay in dto.DiagnosticWorkDays)
            {
                var existingWorkDay = existingWorkDays.FirstOrDefault(x => x.DiagnosticId == dto.DiagnosticId && x.Day == workDay.Day);

                if (existingWorkDay != null)
                {
                    var updatedWorkHours = new List<DiagnosticWorkHour>();

                    foreach (var workHour in workDay.DiagnosticWorkHours)
                    {
                        try
                        {
                            var startTime = TimeSpan.Parse(workHour.StartTime);
                            var endTime = TimeSpan.Parse(workHour.EndTime);

                            updatedWorkHours.Add(new DiagnosticWorkHour
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

                    existingWorkDay.DiagnosticWorkHours = updatedWorkHours;
                }
            }

            await _repo.UpdateWorkDaysAsync(existingWorkDays);

            return Ok();
        }
    }
}
