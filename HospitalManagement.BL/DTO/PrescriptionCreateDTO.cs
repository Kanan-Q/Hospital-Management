using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.BL.DTO
{
    public class PrescriptionCreateDTO
    {
        public int PatientId { get; set; }
        public string? MedicationName { get; set; }
    }
}
