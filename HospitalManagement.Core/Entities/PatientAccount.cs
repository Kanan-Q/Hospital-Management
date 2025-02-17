using HospitalManagement.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Entities
{
    public class PatientAccount:BaseEntity
    {
        public string Name { get; set; }
        public byte Count { get; set; } = 1;
        public string PasswordHash {  get; set; }
        public string? FinCode { get; set; }
    }
}
