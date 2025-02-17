using HospitalManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Repositories
{
    public interface IExpensesRepsitories
    {
        Task AddAsync(Expense expenses);
        Task UpdateAsync(Expense expenses);
        Task DeleteAsync(Expense expenses);
        Task<Expense?> GetByIdAsync(int id);
        Task<IEnumerable<Expense>> GetAllAsync();
        Task<IEnumerable<Expense>> SearchAsync(string query);


    }
}
