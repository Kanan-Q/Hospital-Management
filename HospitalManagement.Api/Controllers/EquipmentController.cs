using HospitalManagement.BL.DTO.Equipment;
using HospitalManagement.BL.DTO.Therapist;
using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Entities.Common;
using HospitalManagement.Core.Enum;
using HospitalManagement.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class EquipmentController(IEquipmentRepository _repo) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());
        [HttpGet]
        public async Task<IActionResult> Search(string query) => Ok(await _repo.SearchAsync(query));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _repo.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(EquipmentCreateDTO dto)
        {
            Equipment equipment = new Equipment()
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Age = dto.Age,
                Salary = dto.Salary,
                Email = dto.Email,
                FIN = dto.FIN,
                Series = dto.Series,
                Address = dto.Address,
                Education = dto.Education,
                Phone = dto.Phone,
                DepartmentId = dto.DepartmentId,
                Gender = (Gender)dto.Gender,
                Birthday = dto.Birthday,
            };
            await _repo.AddAsync(equipment);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var equipment = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(equipment);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EquipmentUpdateDTO dto)
        {
            var equipment = await _repo.GetByIdAsync(id);
            equipment.Name = dto.Name;
            equipment.Surname = dto.Surname;
            equipment.Age = dto.Age;
            equipment.Phone = dto.Phone;
            equipment.Email = dto.Email;
            equipment.FIN = dto.FIN;
            equipment.Salary = dto.Salary;
            equipment.Series = dto.Series;
            equipment.Education = dto.Education;
            equipment.Address = dto.Address;
            equipment.DepartmentId = dto.DepartmentId;
            equipment.Gender = (Gender)dto.Gender;
            equipment.Birthday = dto.Birthday;
            await _repo.UpdateAsync(equipment);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetEquipmentByGender(int gender) => Ok(await _repo.GetEquipmentsByGenderAsync(gender));
        [HttpGet]
        public async Task<IActionResult> GetEquipmentByDepartment(string department) => Ok(await _repo.GetEquipmentsByDepartmentAsync(department));
    }
}
