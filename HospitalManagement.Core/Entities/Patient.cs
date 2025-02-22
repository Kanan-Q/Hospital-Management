using HospitalManagement.Core.Entities.Common;
using HospitalManagement.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Entities
{
    public class Patient : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
        public string FIN { get; set; }
        public string Series { get; set; }
        public string Address { get; set; }
        public byte Count { get; set; } = 1;
        [JsonIgnore]
        public ICollection<DoctorPatient> DoctorPatients { get; set; }
        //[JsonIgnore]
        public ICollection<Prescription> Prescriptions { get; set; }
    }
}
