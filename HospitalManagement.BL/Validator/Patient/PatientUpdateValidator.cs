using FluentValidation;
using HospitalManagement.BL.DTO.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.BL.Validator.Patient
{
    public class PatientUpdateValidator:AbstractValidator<PatientUpdateDTO>
    {
        public PatientUpdateValidator()
        {
            RuleFor(x => x.Name).Null().MinimumLength(3).MaximumLength(50);

            RuleFor(x => x.Surname).Null().MinimumLength(3).MaximumLength(50);

            RuleFor(x => x.Age).Null().InclusiveBetween(0, 150);

            RuleFor(x => x.Email).Null().EmailAddress();

            RuleFor(x => x.FIN).Null().Length(7);

            RuleFor(x => x.Series).Null().Matches("^[A-Z]{2}$");

            RuleFor(x => x.Address).Null().MaximumLength(200);

            RuleFor(x => x.DoctorId).Null();
        }
    }
}
