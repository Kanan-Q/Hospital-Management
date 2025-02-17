using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Entities
{
    public class Prescription
    {
        public int Id { get; set; }
        public int? DoctorId { get; set; }  
        public Doctor? Doctor { get; set; }
        public int? PatientId { get; set; } 
        public Patient? Patient { get; set; }
        public string? MedicationName { get; set; }  
        public DateTime CreatedTime { get; set; }=DateTime.Now;
    }
}
