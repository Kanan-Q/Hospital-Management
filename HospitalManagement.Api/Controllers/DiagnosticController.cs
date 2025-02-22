using HospitalManagement.BL.DTO.Diagnostic;
using HospitalManagement.BL.DTO.Therapist;
using HospitalManagement.Core.Entities.Common;
using HospitalManagement.Core.Enum;
using HospitalManagement.Core.Repositories;
using HospitalManagement.DataAccess.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DiagnosticController(IDiagnosticRepository _repo) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());
        [HttpGet]
        public async Task<IActionResult> Search(string query) => Ok(await _repo.SearchAsync(query));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _repo.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(DiagnosticCreateDTO dto)
        {
            Diagnostic diagnostic = new Diagnostic()
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Age = dto.Age,
                Salary = dto.Salary,
                Email = dto.Email,
                FIN = dto.FIN,
                Series = dto.Series,
                Address = dto.Address,
                Gender = (Gender)dto.Gender,
                Birthday = dto.Birthday,
                Education = dto.Education,
                Phone = dto.Phone,
                DepartmentId = dto.DepartmentId,
            };
            await _repo.AddAsync(diagnostic);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var diagnostic = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(diagnostic);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DiagnosticUpdateDTO dto)
        {
            var diagnostic = await _repo.GetByIdAsync(id);
            diagnostic.Name = dto.Name;
            diagnostic.Surname = dto.Surname;
            diagnostic.Age = dto.Age;
            diagnostic.Phone = dto.Phone;
            diagnostic.Email = dto.Email;
            diagnostic.FIN = dto.FIN;
            diagnostic.Salary = dto.Salary;
            diagnostic.Series = dto.Series;
            diagnostic.Education = dto.Education;
            diagnostic.Address = dto.Address;
            diagnostic.DepartmentId = dto.DepartmentId;
            diagnostic.Gender = (Gender)dto.Gender;
            diagnostic.Birthday = dto.Birthday;
            await _repo.UpdateAsync(diagnostic);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetDiagnosticByGender(int gender) => Ok(await _repo.GetDiagnosticsByGenderAsync(gender));
        [HttpGet]
        public async Task<IActionResult> GetDiagnosticByDepartment(string department) => Ok(await _repo.GetDiagnosticsByDepartmentAsync(department));
    }
}
