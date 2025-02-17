using HospitalManagement.BL.DTO.Department;
using HospitalManagement.BL.DTO.Expense;
using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace HospitalManagement.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ExpenseController(IExpensesRepsitories _repo) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> Create(ExpenseCreateDTO dto)
        {
            Expense expense = new Expense()
            {
                Expenses = dto.Expenses,
                Name = dto.Name,
                Source = dto.Source,
                Surname = dto.Surname,
                BuyDate = dto.BuyDate,
                Phone = dto.Phone,
                Quantity = dto.Quantity,

            };
            await _repo.AddAsync(expense);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var expense = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(expense);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string query) => Ok(await _repo.SearchAsync(query));
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _repo.GetByIdAsync(id));
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ExpenseUpdateDTO dto)
        {
            var expense = await _repo.GetByIdAsync(id);
            expense.Name = dto.Name;
            expense.Expenses = dto.Expenses;
            expense.Source = dto.Source;
            expense.Surname = dto.Surname;
            expense.BuyDate = dto.BuyDate;
            expense.Phone = dto.Phone;
            expense.Quantity = dto.Quantity;

            await _repo.UpdateAsync(expense);
            return Ok();
        }
    }
}
