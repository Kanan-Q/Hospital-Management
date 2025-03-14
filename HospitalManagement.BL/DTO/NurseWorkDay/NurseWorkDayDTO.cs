using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.BL.DTO.NurseWorkDay
{
    public class NurseWorkDayDTO
    {
        public int NurseId { get; set; }
        public ICollection<NurseWorkDayDetailDTO> NurseWorkDays { get; set; } 
    }

    public class NurseWorkDayDetailDTO
    {
        public string Day { get; set; }
        public ICollection<NurseWorkHourDTO> NurseWorkHours { get; set; }
    }

}

