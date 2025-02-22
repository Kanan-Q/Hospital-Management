using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.BL.DTO.Therapist
{
    public class TherapistCreateDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }
        public string Education { get; set; }
        public string FIN { get; set; }
        public int Gender { get; set; }
        public DateOnly Birthday { get; set; }
        public string Series { get; set; }
        public string Address { get; set; }
        public byte Count { get; set; } = 1;
        public int DepartmentId { get; set; }
    }
}
