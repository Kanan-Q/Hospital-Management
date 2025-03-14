using HospitalManagement.BL.DTO.NurseWorkDay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.BL.DTO.DiagnosticWorkDay
{
    public class DiagnosticWorkDayDTO
    {
        public int DiagnosticId { get; set; }
        public ICollection<DiagnosticWorkDayDetailDTO> DiagnosticWorkDays { get; set; }
    }

    public class DiagnosticWorkDayDetailDTO
    {
        public string Day { get; set; }
        public ICollection<DiagnosticWorkHourDTO> DiagnosticWorkHours { get; set; }
    }
}
