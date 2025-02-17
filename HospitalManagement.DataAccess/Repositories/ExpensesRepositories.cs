using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Repositories;
using HospitalManagement.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.DataAccess.Repositories
{
    public class ExpensesRepositories(AppDbContext _sql) : IExpensesRepsitories
    {
        public async Task AddAsync(Expense expenses)
        {
            await _sql.Expenses.AddAsync(expenses);
            await _sql.SaveChangesAsync();
        }
        public async Task UpdateAsync(Expense expenses)
        {
            var data = await _sql.Expenses.FindAsync(expenses.Id);
            data.Expenses = expenses.Expenses;
            data.Name = expenses.Name;
            data.Surname = expenses.Surname;
            data.Quantity = expenses.Quantity;
            data.Source = expenses.Source;
            data.BuyDate = expenses.BuyDate;
            data.Phone = expenses.Phone;
            await _sql.SaveChangesAsync();
        }

        public async Task DeleteAsync(Expense expenses)
        {
            _sql.Expenses.Remove(expenses);
            await _sql.SaveChangesAsync();
        }

        public async Task<IEnumerable<Expense>> GetAllAsync() => await _sql.Expenses.AsNoTracking().ToListAsync();

        public async Task<Expense?> GetByIdAsync(int id) => await _sql.Expenses.Where(x => x.Id == id).FirstOrDefaultAsync();
        public async Task<IEnumerable<Expense>> SearchAsync(string query)
        {
            return await _sql.Expenses.Where(p => p.Expenses.ToString().Contains(query) || p.Name.Contains(query) || p.Surname.Contains(query)||p.Phone.Contains(query)|| p.Source.Contains(query)||p.Quantity.ToString().Contains(query)).ToListAsync();
        }

    }
}
