using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Entities
{
    public class DoctorWorkDay
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string Day { get; set; }
        public ICollection<DoctorWorkHour> WorkHours { get; set; }
        public Doctor Doctor { get; set; }
    }

}
