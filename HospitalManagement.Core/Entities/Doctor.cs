using HospitalManagement.Core.Entities.Common;
using HospitalManagement.Core.Enum;
using System.Text.Json.Serialization;
namespace HospitalManagement.Core.Entities
{
    public class Doctor:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }
        public decimal? Salary { get; set; }
        public string Email { get; set; }
        public string FIN { get; set; }
        public string Series { get; set; }
        public string Address { get; set; }
        public byte Count { get; set; } = 1;
        public string Education { get; set; }
        public Gender Gender { get; set; }
        public DateOnly Birthday { get; set; }
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public bool IsActive { get; set; }=false;
        [JsonIgnore]
        public ICollection<DoctorPatient> DoctorPatients { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }


    }
}
