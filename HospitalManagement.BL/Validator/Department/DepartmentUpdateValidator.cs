using FluentValidation;
using HospitalManagement.BL.DTO.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.BL.Validator.Department
{
    public class DepartmentUpdateValidator : AbstractValidator<DepartmentUpdateDTO>
    {
        public DepartmentUpdateValidator()
        {
            RuleFor(x => x.DepartmentName).MinimumLength(3).MaximumLength(20);
        }
    }
}
