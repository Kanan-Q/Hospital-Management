using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.BL.DTO.Patient
{
    public class PatientUpdateDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string FIN { get; set; }
        public string Series { get; set; }
        public string Address { get; set; }
        public byte Count { get; set; } = 1;
        public List<int>? DoctorId { get; set; }

    }
}
