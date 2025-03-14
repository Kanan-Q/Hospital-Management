using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Entities
{
    public class DiagnosticWorkHour
    {
        public int Id { get; set; }
        public int DiagnosticWorkDayId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DiagnosticWorkDay DiagnosticWorkDay { get; set; }
    }
}
