using HospitalManagement.BL.DTO.DiagnosticWorkDay;
using HospitalManagement.BL.DTO.EquipmentWorkDay;
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
    public class EquipmentWorkDayController(IEquipmentWorkDayRepository _repo) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddWorkDays(EquipmentWorkDayDTO dto)
        {
            if (dto.EquipmentWorkDays == null || !dto.EquipmentWorkDays.Any())
                return BadRequest();

            var workDays = new List<EquipmentWorkDay>();

            foreach (var wd in dto.EquipmentWorkDays)
            {
                if (string.IsNullOrEmpty(wd.Day))
                    return BadRequest();

                var workHours = new List<EquipmentWorkHour>();

                foreach (var wh in wd.EquipmentWorkHours)
                {
                    try
                    {
                        var startTime = TimeSpan.Parse(wh.StartTime);
                        var endTime = TimeSpan.Parse(wh.EndTime);
                        workHours.Add(new EquipmentWorkHour
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

                workDays.Add(new EquipmentWorkDay
                {
                    EquipmentId = dto.EquipmentId,
                    Day = wd.Day,
                    EquipmentWorkHours = workHours
                });
            }

            await _repo.AddWorkDaysAsync(workDays);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWorkDays() => Ok(await _repo.GetAllWorkDaysAsync());

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllWorkDaysByEquipment(int id)
        {
            await _repo.DeleteAllWorkDaysByEquipmentIdAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWorkDays(EquipmentWorkDayDTO dto)
        {
            if (dto.EquipmentWorkDays == null || !dto.EquipmentWorkDays.Any())
            {
                return BadRequest();
            }

            var existingWorkDays = await _repo.GetAllWorkDaysAsync();

            foreach (var workDay in dto.EquipmentWorkDays)
            {
                var existingWorkDay = existingWorkDays.FirstOrDefault(x => x.EquipmentId == dto.EquipmentId && x.Day == workDay.Day);

                if (existingWorkDay != null)
                {
                    var updatedWorkHours = new List<EquipmentWorkHour>();

                    foreach (var workHour in workDay.EquipmentWorkHours)
                    {
                        try
                        {
                            var startTime = TimeSpan.Parse(workHour.StartTime);
                            var endTime = TimeSpan.Parse(workHour.EndTime);

                            updatedWorkHours.Add(new EquipmentWorkHour
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

                    existingWorkDay.EquipmentWorkHours = updatedWorkHours;
                }
            }

            await _repo.UpdateWorkDaysAsync(existingWorkDays);

            return Ok();
        }
    }
}
