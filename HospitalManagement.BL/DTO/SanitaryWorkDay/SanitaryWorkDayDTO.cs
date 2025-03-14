using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.BL.DTO.SanitaryWorkDay
{
    public class SanitaryWorkDayDTO
    {
        public int SanitaryId { get; set; }
        public ICollection<SanitaryWorkDayDetailDTO> SanitaryWorkDays { get; set; }
    }

    public class SanitaryWorkDayDetailDTO
    {
        public string Day { get; set; }
        public ICollection<SanitaryWorkHourDTO> SanitaryWorkHours { get; set; }
    }
}
