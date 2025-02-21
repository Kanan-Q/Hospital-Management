using HospitalManagement.BL.DTO.Nurse;
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
    public class NurseController(INurseRepository _repo) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());
        [HttpGet]
        public async Task<IActionResult> Search(string query) => Ok(await _repo.SearchAsync(query));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _repo.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(NurseCreateDTO dto)
        {
            Nurse nurse = new Nurse()
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Age = dto.Age,
                Salary = dto.Salary,
                Email = dto.Email,
                FIN = dto.FIN,
                Series = dto.Series,
                Address = dto.Address,
                Phone = dto.Phone,
                DepartmentId = dto.DepartmentId,
            };
            await _repo.AddAsync(nurse);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var nurse = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(nurse);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, NurseUpdateDTO dto)
        {
            var nurse = await _repo.GetByIdAsync(id);
            nurse.Name = dto.Name;
            nurse.Surname = dto.Surname;
            nurse.Age = dto.Age;
            nurse.Salary = dto.Salary;
            nurse.Email = dto.Email;
            nurse.FIN = dto.FIN;
            nurse.Series = dto.Series;
            nurse.Address = dto.Address;
            nurse.DepartmentId = dto.DepartmentId;
            await _repo.UpdateAsync(nurse);
            return Ok();
        }
    }
}
