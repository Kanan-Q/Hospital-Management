using HospitalManagement.BL.DTO.Nurse;
using HospitalManagement.BL.DTO.Sanitary;
using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SanitaryController(ISanitaryRepository _repo) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());
        [HttpGet]
        public async Task<IActionResult> Search(string query) => Ok(await _repo.SearchAsync(query));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _repo.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(SanitaryCreateDTO dto)
        {
            Sanitary sanitary = new Sanitary()
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Age = dto.Age,
                Salary = dto.Salary,
                Email = dto.Email,
                FIN = dto.FIN,
                Series = dto.Series,
                Address = dto.Address,
                Education=dto.Education,
                Phone = dto.Phone,
                DepartmentId = dto.DepartmentId,
            };
            await _repo.AddAsync(sanitary);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sanitary = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(sanitary);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SanitaryUpdateDTO dto)
        {
            var sanitary = await _repo.GetByIdAsync(id);
            sanitary.Name = dto.Name;
            sanitary.Surname = dto.Surname;
            sanitary.Age = dto.Age;
            sanitary.Phone = dto.Phone;
            sanitary.Email = dto.Email;
            sanitary.FIN = dto.FIN;
            sanitary.Salary = dto.Salary;
            sanitary.Series = dto.Series;
            sanitary.Education = dto.Education;
            sanitary.Address = dto.Address;
            sanitary.DepartmentId = dto.DepartmentId;
            await _repo.UpdateAsync(sanitary);
            return Ok();
        }
    }
}
