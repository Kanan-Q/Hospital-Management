using HospitalManagement.BL.DTO.Department;
using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class DepartmentController(IDepartmentRepository _repo) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()=> Ok(await _repo.GetAllAsync());
        
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentCreateDTO dto)
        {
            Department department = new Department()
            {
                DepartmentName=dto.DepartmentName,
            };
            await _repo.AddAsync(department);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(department);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string query) => Ok(await _repo.SearchAsync(query));
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _repo.GetByIdAsync(id));
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,DepartmentUpdateDTO dto)
        {
            var department=await _repo.GetByIdAsync(id);
            department.DepartmentName=dto.DepartmentName;
            await _repo.UpdateAsync(department);
            return Ok();
        }
    }
}
