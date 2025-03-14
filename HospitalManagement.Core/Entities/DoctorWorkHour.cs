using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Entities
{
    public class DoctorWorkHour
    {
        public int Id { get; set; }
        public int DoctorWorkDayId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DoctorWorkDay DoctorWorkDay { get; set; }
    }
}
