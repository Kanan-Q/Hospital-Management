using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Entities
{
    public class SanitaryWorkHour
    {
        public int Id { get; set; }
        public int SanitaryWorkDayId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public SanitaryWorkDay SanitaryWorkDay { get; set; }
    }
}
