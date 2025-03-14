using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Entities
{
    public class TherapistWorkHour
    {
        public int Id { get; set; }
        public int TherapistWorkDayId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TherapistWorkDay TherapistWorkDay { get; set; }
    }
}
