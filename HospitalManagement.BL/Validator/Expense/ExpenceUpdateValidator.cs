using FluentValidation;
using HospitalManagement.BL.DTO.Expense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.BL.Validator.Expense
{
    public class ExpenceUpdateValidator : AbstractValidator<ExpenseUpdateDTO>
    {
        public ExpenceUpdateValidator()
        {
            RuleFor(x=>x.Expenses).Null().Empty();
        }
    }
}
