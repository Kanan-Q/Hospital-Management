using HospitalManagement.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Entities
{
    public class Department:BaseEntity
    {
        public string DepartmentName { get; set; }
        public ICollection<Nurse> Nurses { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
}
