using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Entities
{
    public class TherapistWorkDay
    {
        public int Id { get; set; }
        public int TherapistId { get; set; }
        public string Day { get; set; }
        public ICollection<TherapistWorkHour> TherapistWorkHours { get; set; }
        public Therapist Therapist { get; set; }
    }
}
