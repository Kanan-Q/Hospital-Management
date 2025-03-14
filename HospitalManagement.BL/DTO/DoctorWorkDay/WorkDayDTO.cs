using HospitalManagement.BL.DTO.DoctorWorkDay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.BL.DTO
{
    public class WorkDayDto
    {
        public int DoctorId { get; set; }
        public ICollection<WorkDayDetailDto> WorkDays { get; set; } 
    }

    public class WorkDayDetailDto
    {
        public string Day { get; set; }
        public ICollection<WorkHourDTO> WorkHours { get; set; }
    }

}
