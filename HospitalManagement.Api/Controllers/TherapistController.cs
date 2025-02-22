using HospitalManagement.BL.DTO.Sanitary;
using HospitalManagement.BL.DTO.Therapist;
using HospitalManagement.Core.Entities;
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
    public class TherapistController(ITherapistRepository _repo) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());
        [HttpGet]
        public async Task<IActionResult> Search(string query) => Ok(await _repo.SearchAsync(query));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _repo.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(TherapistCreateDTO dto)
        {
            Therapist therapist = new Therapist()
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
            await _repo.AddAsync(therapist);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var therapist = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(therapist);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TherapistUpdateDTO dto)
        {
            var therapist = await _repo.GetByIdAsync(id);
            therapist.Name = dto.Name;
            therapist.Surname = dto.Surname;
            therapist.Age = dto.Age;
            therapist.Phone = dto.Phone;
            therapist.Email = dto.Email;
            therapist.FIN = dto.FIN;
            therapist.Salary = dto.Salary;
            therapist.Series = dto.Series;
            therapist.Education = dto.Education;
            therapist.Address = dto.Address;
            therapist.DepartmentId = dto.DepartmentId;
            therapist.Gender = (Gender)dto.Gender;
            therapist.Birthday = dto.Birthday;
            await _repo.UpdateAsync(therapist);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetTherapistByGender(int gender) => Ok(await _repo.GetTherapistsByGenderAsync(gender));
        [HttpGet]
        public async Task<IActionResult> GetTherapistByDepartment(string department) => Ok(await _repo.GetTherapistsByDepartmentAsync(department));
    }
}
