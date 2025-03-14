using HospitalManagement.BL.DTO.SanitaryWorkDay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.BL.DTO.TherapistWorkDay
{
    public class TherapistWorkDayDTO
    {
        public int TherapistId { get; set; }
        public ICollection<TherapistWorkDayDetailDTO> TherapistWorkDays { get; set; }
    }

    public class TherapistWorkDayDetailDTO
    {
        public string Day { get; set; }
        public ICollection<TherapistWorkHourDTO> TherapistWorkHours { get; set; }
    }
}
